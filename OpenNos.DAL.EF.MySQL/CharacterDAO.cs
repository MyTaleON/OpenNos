﻿/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using AutoMapper;
using OpenNos.Core;
using OpenNos.DAL.EF.MySQL.DB;
using OpenNos.DAL.EF.MySQL.Helpers;
using OpenNos.DAL.Interface;
using OpenNos.Data;
using OpenNos.Data.Enums;
using OpenNos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenNos.DAL.EF.MySQL
{
    public class CharacterDAO : ICharacterDAO
    {
        #region Methods

        public DeleteResult Delete(long AccountId, byte CharacterSlot)
        {
            try
            {
                using (var context = DataAccessHelper.CreateContext())
                {
                    //actually a Character wont be deleted, it just will be disabled for future traces
                    byte state = (byte)CharacterState.Active;
                    Character Character = context.Character.FirstOrDefault(c => c.AccountId.Equals(AccountId) && c.Slot.Equals(CharacterSlot)
                                            && c.State.Equals(state));

                    if (Character != null)
                    {
                        byte obsoleteState = (byte)CharacterState.Inactive;
                        Character.State = obsoleteState;
                        Update(Character, Mapper.Map<CharacterDTO>(Character), context);
                    }

                    return DeleteResult.Deleted;
                }
            }
            catch (Exception e)
            {
                Logger.Log.ErrorFormat("DELETE_ERROR", CharacterSlot, e.Message);
                return DeleteResult.Error;
            }
        }

        public IEnumerable<CharacterDTO> GetTopComplimented()
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (Character Character in context.Character.Where(c => c.Account.Authority == (byte)AuthorityType.User).OrderByDescending(c => c.Compliment).Take(30).ToList())
                {
                    yield return Mapper.Map<CharacterDTO>(Character);
                }
            }
        }

        public IEnumerable<CharacterDTO> GetTopPoints()
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (Character Character in context.Character.Where(c => c.Account.Authority == (byte)AuthorityType.User).OrderByDescending(c => c.Act4Points).Take(30).ToList())
                {
                    yield return Mapper.Map<CharacterDTO>(Character);
                }
            }
        }

        public IEnumerable<CharacterDTO> GetTopReputation()
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                foreach (Character Character in context.Character.Where(c => c.Account.Authority == (byte)AuthorityType.User).OrderByDescending(c => c.Reput).Take(43).ToList())
                {
                    yield return Mapper.Map<CharacterDTO>(Character);
                }
            }
        }

        public SaveResult InsertOrUpdate(ref CharacterDTO Character)
        {
            try
            {
                using (var context = DataAccessHelper.CreateContext())
                {
                    long CharacterId = Character.CharacterId;
                    Character entity = context.Character.FirstOrDefault(c => c.CharacterId.Equals(CharacterId));

                    if (entity == null) //new entity
                    {
                        Character = Insert(Character, context);
                        return SaveResult.Inserted;
                    }
                    else //existing entity
                    {
                        Character = Update(entity, Character, context);
                        return SaveResult.Updated;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Log.ErrorFormat("INSERT_ERROR", Character, e.Message);
                return SaveResult.Error;
            }
        }

        public int IsReputHero(long CharacterId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                List<Character> heroes = context.Character.Where(c => c.Account.Authority != (byte)AuthorityType.Admin).OrderByDescending(c => c.Reput).Take(43).ToList();

                int i = 0;
                foreach (Character c in heroes)
                {
                    i++;
                    if (c.CharacterId == CharacterId)
                    {
                        if (i == 1)
                        {
                            return 5;
                        }
                        if (i == 2)
                        {
                            return 4;
                        }
                        if (i == 3)
                        {
                            return 3;
                        }
                        if (i <= 13)
                        {
                            return 2;
                        }
                        if (i <= 43)
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            }
        }

        public IEnumerable<CharacterDTO> LoadByAccount(long AccountId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                byte state = (byte)CharacterState.Active;
                foreach (Character Character in context.Character.Where(c => c.AccountId.Equals(AccountId) && c.State.Equals(state)).OrderByDescending(c => c.Slot))
                {
                    yield return Mapper.Map<CharacterDTO>(Character);
                }
            }
        }

        public CharacterDTO LoadById(long CharacterId)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                return Mapper.Map<CharacterDTO>(context.Character.FirstOrDefault(c => c.CharacterId.Equals(CharacterId)));
            }
        }

        public CharacterDTO LoadByName(string name)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                byte state = (byte)CharacterState.Active;
                return Mapper.Map<CharacterDTO>(context.Character.FirstOrDefault(c => c.Name.Equals(name) && c.State.Equals(state)));
            }
        }

        public CharacterDTO LoadBySlot(long AccountId, byte slot)
        {
            using (var context = DataAccessHelper.CreateContext())
            {
                byte state = (byte)CharacterState.Active;
                return Mapper.Map<CharacterDTO>(context.Character.FirstOrDefault(c => c.AccountId.Equals(AccountId) && c.Slot.Equals(slot)
                                                                                        && c.State.Equals(state)));
            }
        }

        private CharacterDTO Insert(CharacterDTO Character, OpenNosContext context)
        {
            Character entity = Mapper.Map<Character>(Character);
            context.Character.Add(entity);
            context.SaveChanges();
            return Mapper.Map<CharacterDTO>(entity);
        }

        private CharacterDTO Update(Character entity, CharacterDTO Character, OpenNosContext context)
        {
            using (context)
            {
                var result = context.Character.FirstOrDefault(c => c.CharacterId == Character.CharacterId);
                if (result != null)
                {
                    result = Mapper.Map<CharacterDTO, Character>(Character, entity);
                    context.SaveChanges();
                }
            }

            return Mapper.Map<CharacterDTO>(entity);
        }

        #endregion
    }
}