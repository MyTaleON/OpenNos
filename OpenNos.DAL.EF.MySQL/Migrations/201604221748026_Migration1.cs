namespace OpenNos.DAL.EF.MySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Long(nullable: false, identity: true),
                        Authority = c.Byte(nullable: false),
                        LastCompliment = c.DateTime(nullable: false, precision: 0),
                        LastSession = c.Int(nullable: false),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Password = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Long(nullable: false, identity: true),
                        AccountId = c.Long(nullable: false),
                        Act4Dead = c.Int(nullable: false),
                        Act4Kill = c.Int(nullable: false),
                        Act4Points = c.Int(nullable: false),
                        ArenaWinner = c.Int(nullable: false),
                        Backpack = c.Int(nullable: false),
                        BuffBlocked = c.Boolean(nullable: false),
                        Class = c.Byte(nullable: false),
                        Compliment = c.Short(nullable: false),
                        Dignite = c.Short(nullable: false),
                        EmoticonsBlocked = c.Boolean(nullable: false),
                        ExchangeBlocked = c.Boolean(nullable: false),
                        Faction = c.Int(nullable: false),
                        FamilyRequestBlocked = c.Boolean(nullable: false),
                        FriendRequestBlocked = c.Boolean(nullable: false),
                        Gender = c.Byte(nullable: false),
                        Gold = c.Long(nullable: false),
                        GroupRequestBlocked = c.Boolean(nullable: false),
                        HairColor = c.Byte(nullable: false),
                        HairStyle = c.Byte(nullable: false),
                        HeroChatBlocked = c.Boolean(nullable: false),
                        HeroLevel = c.Byte(nullable: false),
                        HeroXp = c.Long(nullable: false),
                        Hp = c.Int(nullable: false),
                        HpBlocked = c.Boolean(nullable: false),
                        JobLevel = c.Byte(nullable: false),
                        JobLevelXp = c.Long(nullable: false),
                        Level = c.Byte(nullable: false),
                        LevelXp = c.Long(nullable: false),
                        MapId = c.Short(nullable: false),
                        MapX = c.Short(nullable: false),
                        MapY = c.Short(nullable: false),
                        MasterPoints = c.Int(nullable: false),
                        MasterTicket = c.Int(nullable: false),
                        MinilandInviteBlocked = c.Boolean(nullable: false),
                        MouseAimLock = c.Boolean(nullable: false),
                        Mp = c.Int(nullable: false),
                        Name = c.String(maxLength: 255, unicode: false),
                        QuickGetUp = c.Boolean(nullable: false),
                        RagePoint = c.Long(nullable: false),
                        Reput = c.Long(nullable: false),
                        Slot = c.Byte(nullable: false),
                        SpAdditionPoint = c.Int(nullable: false),
                        SpPoint = c.Int(nullable: false),
                        State = c.Byte(nullable: false),
                        TalentLose = c.Int(nullable: false),
                        TalentSurrender = c.Int(nullable: false),
                        TalentWin = c.Int(nullable: false),
                        WhisperBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Map", t => t.MapId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId)
                .Index(t => t.MapId);
            
            CreateTable(
                "dbo.CharacterSkill",
                c => new
                    {
                        CharacterSkillId = c.Long(nullable: false, identity: true),
                        CharacterId = c.Long(nullable: false),
                        SkillVNum = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterSkillId)
                .ForeignKey("dbo.Skill", t => t.SkillVNum)
                .ForeignKey("dbo.Character", t => t.CharacterId)
                .Index(t => t.CharacterId)
                .Index(t => t.SkillVNum);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        SkillVNum = c.Short(nullable: false),
                        AttackAnimation = c.Short(nullable: false),
                        BuffId = c.Short(nullable: false),
                        CastAnimation = c.Short(nullable: false),
                        CastEffect = c.Short(nullable: false),
                        CastId = c.Short(nullable: false),
                        CastTime = c.Short(nullable: false),
                        Class = c.Byte(nullable: false),
                        Cooldown = c.Short(nullable: false),
                        CPCost = c.Byte(nullable: false),
                        Damage = c.Short(nullable: false),
                        Duration = c.Short(nullable: false),
                        Effect = c.Short(nullable: false),
                        Element = c.Byte(nullable: false),
                        ElementalDamage = c.Short(nullable: false),
                        HitType = c.Byte(nullable: false),
                        ItemVNum = c.Short(nullable: false),
                        Level = c.Byte(nullable: false),
                        LevelMinimum = c.Byte(nullable: false),
                        MinimumAdventurerLevel = c.Byte(nullable: false),
                        MinimumArcherLevel = c.Byte(nullable: false),
                        MinimumMagicianLevel = c.Byte(nullable: false),
                        MinimumSwordmanLevel = c.Byte(nullable: false),
                        MpCost = c.Short(nullable: false),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Price = c.Int(nullable: false),
                        Range = c.Byte(nullable: false),
                        SecondarySkillVNum = c.Short(nullable: false),
                        SkillChance = c.Short(nullable: false),
                        SkillType = c.Byte(nullable: false),
                        TargetRange = c.Byte(nullable: false),
                        TargetType = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                        UpgradeSkill = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.SkillVNum);
            
            CreateTable(
                "dbo.Combo",
                c => new
                    {
                        ComboId = c.Int(nullable: false, identity: true),
                        Animation = c.Short(nullable: false),
                        Effect = c.Short(nullable: false),
                        Hit = c.Short(nullable: false),
                        SkillVNum = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ComboId)
                .ForeignKey("dbo.Skill", t => t.SkillVNum)
                .Index(t => t.SkillVNum);
            
            CreateTable(
                "dbo.NpcMonsterSkill",
                c => new
                    {
                        CharacterSkillId = c.Long(nullable: false, identity: true),
                        NpcMonsterVNum = c.Short(nullable: false),
                        Rate = c.Short(nullable: false),
                        SkillVNum = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterSkillId)
                .ForeignKey("dbo.NpcMonster", t => t.NpcMonsterVNum)
                .ForeignKey("dbo.Skill", t => t.SkillVNum)
                .Index(t => t.NpcMonsterVNum)
                .Index(t => t.SkillVNum);
            
            CreateTable(
                "dbo.NpcMonster",
                c => new
                    {
                        NpcMonsterVNum = c.Short(nullable: false),
                        AttackClass = c.Byte(nullable: false),
                        AttackUpgrade = c.Byte(nullable: false),
                        BasicArea = c.Byte(nullable: false),
                        BasicCooldown = c.Short(nullable: false),
                        BasicRange = c.Byte(nullable: false),
                        BasicSkill = c.Short(nullable: false),
                        CloseDefence = c.Short(nullable: false),
                        Concentrate = c.Short(nullable: false),
                        CriticalLuckRate = c.Byte(nullable: false),
                        CriticalRate = c.Short(nullable: false),
                        DamageMaximum = c.Short(nullable: false),
                        DamageMinimum = c.Short(nullable: false),
                        DarkResistance = c.SByte(nullable: false),
                        DefenceDodge = c.Short(nullable: false),
                        DefenceUpgrade = c.Byte(nullable: false),
                        DistanceDefence = c.Short(nullable: false),
                        DistanceDefenceDodge = c.Short(nullable: false),
                        Element = c.Byte(nullable: false),
                        ElementRate = c.Short(nullable: false),
                        FireResistance = c.SByte(nullable: false),
                        HeroLevel = c.Byte(nullable: false),
                        IsHostile = c.Boolean(nullable: false),
                        JobXP = c.Int(nullable: false),
                        Level = c.Byte(nullable: false),
                        LightResistance = c.SByte(nullable: false),
                        MagicDefence = c.Short(nullable: false),
                        MaxHP = c.Int(nullable: false),
                        MaxMP = c.Int(nullable: false),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        RespawnTime = c.Int(nullable: false),
                        Speed = c.Byte(nullable: false),
                        WaterResistance = c.SByte(nullable: false),
                        XP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NpcMonsterVNum);
            
            CreateTable(
                "dbo.Drop",
                c => new
                    {
                        DropId = c.Short(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        DropChance = c.Int(nullable: false),
                        ItemVNum = c.Short(nullable: false),
                        MonsterVNum = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.DropId)
                .ForeignKey("dbo.Item", t => t.ItemVNum)
                .ForeignKey("dbo.NpcMonster", t => t.MonsterVNum)
                .Index(t => t.ItemVNum)
                .Index(t => t.MonsterVNum);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        VNum = c.Short(nullable: false),
                        BasicUpgrade = c.Byte(nullable: false),
                        CellonLvl = c.Byte(nullable: false),
                        Class = c.Byte(nullable: false),
                        CloseDefence = c.Short(nullable: false),
                        Color = c.Byte(nullable: false),
                        Concentrate = c.Short(nullable: false),
                        CriticalLuckRate = c.Byte(nullable: false),
                        CriticalRate = c.Short(nullable: false),
                        DamageMaximum = c.Short(nullable: false),
                        DamageMinimum = c.Short(nullable: false),
                        DarkElement = c.Byte(nullable: false),
                        DarkResistance = c.Byte(nullable: false),
                        DefenceDodge = c.Short(nullable: false),
                        DistanceDefence = c.Short(nullable: false),
                        DistanceDefenceDodge = c.Short(nullable: false),
                        Effect = c.Short(nullable: false),
                        EffectValue = c.Int(nullable: false),
                        Element = c.Byte(nullable: false),
                        ElementRate = c.Short(nullable: false),
                        EquipmentSlot = c.Byte(nullable: false),
                        FairyMaximumLevel = c.Byte(nullable: false),
                        FireElement = c.Byte(nullable: false),
                        FireResistance = c.Byte(nullable: false),
                        HitRate = c.Short(nullable: false),
                        Hp = c.Short(nullable: false),
                        HpRegeneration = c.Short(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        IsColored = c.Boolean(nullable: false),
                        IsConsumable = c.Boolean(nullable: false),
                        IsDroppable = c.Boolean(nullable: false),
                        IsMinilandObject = c.Boolean(nullable: false),
                        IsSoldable = c.Boolean(nullable: false),
                        IsTradable = c.Boolean(nullable: false),
                        IsWarehouse = c.Boolean(nullable: false),
                        ItemSubType = c.Byte(nullable: false),
                        ItemType = c.Byte(nullable: false),
                        ItemValidTime = c.Long(nullable: false),
                        LevelJobMinimum = c.Byte(nullable: false),
                        LevelMinimum = c.Byte(nullable: false),
                        LightElement = c.Byte(nullable: false),
                        LightResistance = c.Byte(nullable: false),
                        MagicDefence = c.Short(nullable: false),
                        MaxCellon = c.Byte(nullable: false),
                        MaxCellonLvl = c.Byte(nullable: false),
                        MaximumAmmo = c.Byte(nullable: false),
                        MoreHp = c.Short(nullable: false),
                        MoreMp = c.Short(nullable: false),
                        Morph = c.Short(nullable: false),
                        Mp = c.Short(nullable: false),
                        MpRegeneration = c.Short(nullable: false),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Price = c.Long(nullable: false),
                        PvpDefence = c.Short(nullable: false),
                        PvpStrength = c.Byte(nullable: false),
                        ReduceOposantResistance = c.Short(nullable: false),
                        ReputationMinimum = c.Byte(nullable: false),
                        ReputPrice = c.Long(nullable: false),
                        SecondaryElement = c.Byte(nullable: false),
                        Sex = c.Byte(nullable: false),
                        Speed = c.Byte(nullable: false),
                        SpType = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                        WaterElement = c.Byte(nullable: false),
                        WaterResistance = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.VNum);
            
            CreateTable(
                "dbo.InventoryItem",
                c => new
                    {
                        InventoryItemId = c.Long(nullable: false, identity: true),
                        Ammo = c.Byte(nullable: false),
                        Amount = c.Int(nullable: false),
                        Cellon = c.Byte(nullable: false),
                        CellonOptionId = c.Int(nullable: false),
                        CloseDefence = c.Short(nullable: false),
                        Concentrate = c.Short(nullable: false),
                        CriticalDodge = c.Short(nullable: false),
                        CriticalLuckRate = c.Byte(nullable: false),
                        CriticalRate = c.Short(nullable: false),
                        DamageMaximum = c.Short(nullable: false),
                        DamageMinimum = c.Short(nullable: false),
                        DarkElement = c.Byte(nullable: false),
                        DarkResistance = c.SByte(nullable: false),
                        DefenceDodge = c.Short(nullable: false),
                        Design = c.Short(nullable: false),
                        DistanceDefence = c.Short(nullable: false),
                        DistanceDefenceDodge = c.Short(nullable: false),
                        ElementRate = c.Short(nullable: false),
                        FireElement = c.Byte(nullable: false),
                        FireResistance = c.SByte(nullable: false),
                        HitRate = c.Short(nullable: false),
                        HP = c.Short(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        IsFixed = c.Boolean(nullable: false),
                        IsUsed = c.Boolean(nullable: false),
                        ItemDeleteTime = c.DateTime(precision: 0),
                        ItemVNum = c.Short(nullable: false),
                        LightElement = c.Byte(nullable: false),
                        LightResistance = c.SByte(nullable: false),
                        MagicDefence = c.Short(nullable: false),
                        MP = c.Short(nullable: false),
                        Rare = c.Byte(nullable: false),
                        SlDamage = c.Short(nullable: false),
                        SlDefence = c.Short(nullable: false),
                        SlElement = c.Short(nullable: false),
                        SlHP = c.Short(nullable: false),
                        SpDamage = c.Byte(nullable: false),
                        SpDark = c.Byte(nullable: false),
                        SpDefence = c.Byte(nullable: false),
                        SpElement = c.Byte(nullable: false),
                        SpFire = c.Byte(nullable: false),
                        SpHP = c.Byte(nullable: false),
                        SpLevel = c.Byte(nullable: false),
                        SpLight = c.Byte(nullable: false),
                        SpStoneUpgrade = c.Byte(nullable: false),
                        SpWater = c.Byte(nullable: false),
                        SpXp = c.Long(nullable: false),
                        Upgrade = c.Byte(nullable: false),
                        WaterElement = c.Byte(nullable: false),
                        WaterResistance = c.SByte(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryItemId)
                .ForeignKey("dbo.Item", t => t.ItemVNum)
                .Index(t => t.ItemVNum);
            
            CreateTable(
                "dbo.CellonOption",
                c => new
                    {
                        CellonOptionId = c.Int(nullable: false, identity: true),
                        InventoryItemId = c.Long(nullable: false),
                        Level = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CellonOptionId)
                .ForeignKey("dbo.InventoryItem", t => t.InventoryItemId)
                .Index(t => t.InventoryItemId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Long(nullable: false),
                        CharacterId = c.Long(nullable: false),
                        InventoryItemId = c.Long(nullable: false),
                        Slot = c.Short(nullable: false),
                        Type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.InventoryItem", t => t.InventoryId)
                .ForeignKey("dbo.Character", t => t.CharacterId)
                .Index(t => t.InventoryId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeId = c.Short(nullable: false, identity: true),
                        Amount = c.Byte(nullable: false),
                        ItemVNum = c.Short(nullable: false),
                        MapNpcId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.MapNpc", t => t.MapNpcId)
                .ForeignKey("dbo.Item", t => t.ItemVNum)
                .Index(t => t.ItemVNum)
                .Index(t => t.MapNpcId);
            
            CreateTable(
                "dbo.MapNpc",
                c => new
                    {
                        MapNpcId = c.Int(nullable: false),
                        Dialog = c.Short(nullable: false),
                        Effect = c.Short(nullable: false),
                        EffectDelay = c.Short(nullable: false),
                        IsMoving = c.Boolean(nullable: false),
                        IsSitting = c.Boolean(nullable: false),
                        MapId = c.Short(nullable: false),
                        MapX = c.Short(nullable: false),
                        MapY = c.Short(nullable: false),
                        NpcVNum = c.Short(nullable: false),
                        Position = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.MapNpcId)
                .ForeignKey("dbo.Map", t => t.MapId)
                .ForeignKey("dbo.NpcMonster", t => t.NpcVNum)
                .Index(t => t.MapId)
                .Index(t => t.NpcVNum);
            
            CreateTable(
                "dbo.Map",
                c => new
                    {
                        MapId = c.Short(nullable: false),
                        Data = c.Binary(),
                        Music = c.Int(nullable: false),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.MapId);
            
            CreateTable(
                "dbo.MapMonster",
                c => new
                    {
                        MapMonsterId = c.Int(nullable: false),
                        IsMoving = c.Boolean(nullable: false),
                        MapId = c.Short(nullable: false),
                        MapX = c.Short(nullable: false),
                        MapY = c.Short(nullable: false),
                        MonsterVNum = c.Short(nullable: false),
                        Position = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.MapMonsterId)
                .ForeignKey("dbo.Map", t => t.MapId)
                .ForeignKey("dbo.NpcMonster", t => t.MonsterVNum)
                .Index(t => t.MapId)
                .Index(t => t.MonsterVNum);
            
            CreateTable(
                "dbo.Portal",
                c => new
                    {
                        PortalId = c.Int(nullable: false, identity: true),
                        DestinationMapId = c.Short(nullable: false),
                        DestinationX = c.Short(nullable: false),
                        DestinationY = c.Short(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                        SourceMapId = c.Short(nullable: false),
                        SourceX = c.Short(nullable: false),
                        SourceY = c.Short(nullable: false),
                        Type = c.SByte(nullable: false),
                    })
                .PrimaryKey(t => t.PortalId)
                .ForeignKey("dbo.Map", t => t.DestinationMapId)
                .ForeignKey("dbo.Map", t => t.SourceMapId)
                .Index(t => t.DestinationMapId)
                .Index(t => t.SourceMapId);
            
            CreateTable(
                "dbo.Teleporter",
                c => new
                    {
                        TeleporterId = c.Short(nullable: false, identity: true),
                        Index = c.Short(nullable: false),
                        MapId = c.Short(nullable: false),
                        MapNpcId = c.Int(nullable: false),
                        MapX = c.Short(nullable: false),
                        MapY = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.TeleporterId)
                .ForeignKey("dbo.Map", t => t.MapId)
                .ForeignKey("dbo.MapNpc", t => t.MapNpcId)
                .Index(t => t.MapId)
                .Index(t => t.MapNpcId);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        MapNpcId = c.Int(nullable: false),
                        MenuType = c.Byte(nullable: false),
                        Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        ShopType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ShopId)
                .ForeignKey("dbo.MapNpc", t => t.MapNpcId)
                .Index(t => t.MapNpcId);
            
            CreateTable(
                "dbo.ShopItem",
                c => new
                    {
                        ShopItemId = c.Int(nullable: false, identity: true),
                        Color = c.Byte(nullable: false),
                        ItemVNum = c.Short(nullable: false),
                        Rare = c.Byte(nullable: false),
                        ShopId = c.Int(nullable: false),
                        Slot = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                        Upgrade = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ShopItemId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .ForeignKey("dbo.Item", t => t.ItemVNum)
                .Index(t => t.ItemVNum)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.ShopSkill",
                c => new
                    {
                        ShopSkillId = c.Int(nullable: false, identity: true),
                        ShopId = c.Int(nullable: false),
                        SkillVNum = c.Short(nullable: false),
                        Slot = c.Byte(nullable: false),
                        Type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ShopSkillId)
                .ForeignKey("dbo.Shop", t => t.ShopId)
                .ForeignKey("dbo.Skill", t => t.SkillVNum)
                .Index(t => t.ShopId)
                .Index(t => t.SkillVNum);
            
            CreateTable(
                "dbo.RecipeItem",
                c => new
                    {
                        RecipeItemId = c.Short(nullable: false, identity: true),
                        Amount = c.Byte(nullable: false),
                        ItemVNum = c.Short(nullable: false),
                        RecipeId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeItemId)
                .ForeignKey("dbo.Recipe", t => t.RecipeId)
                .ForeignKey("dbo.Item", t => t.ItemVNum)
                .Index(t => t.ItemVNum)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.GeneralLog",
                c => new
                    {
                        LogId = c.Long(nullable: false, identity: true),
                        AccountId = c.Long(nullable: false),
                        CharacterId = c.Long(),
                        IpAddress = c.String(maxLength: 255, storeType: "nvarchar"),
                        LogData = c.String(maxLength: 255, storeType: "nvarchar"),
                        LogType = c.String(unicode: false),
                        Timestamp = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Character", t => t.CharacterId)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.QuicklistEntry",
                c => new
                    {
                        EntryId = c.Long(nullable: false, identity: true),
                        CharacterId = c.Long(nullable: false),
                        Pos = c.Short(nullable: false),
                        Q1 = c.Short(nullable: false),
                        Q2 = c.Short(nullable: false),
                        Slot = c.Short(nullable: false),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Character", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Respawn",
                c => new
                    {
                        RespawnId = c.Long(nullable: false, identity: true),
                        CharacterId = c.Long(nullable: false),
                        MapId = c.Short(nullable: false),
                        RespawnType = c.Byte(nullable: false),
                        X = c.Short(nullable: false),
                        Y = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.RespawnId)
                .ForeignKey("dbo.Character", t => t.CharacterId)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralLog", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Character", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Respawn", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.QuicklistEntry", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.Inventory", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.GeneralLog", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterSkill", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.ShopSkill", "SkillVNum", "dbo.Skill");
            DropForeignKey("dbo.NpcMonsterSkill", "SkillVNum", "dbo.Skill");
            DropForeignKey("dbo.NpcMonsterSkill", "NpcMonsterVNum", "dbo.NpcMonster");
            DropForeignKey("dbo.MapNpc", "NpcVNum", "dbo.NpcMonster");
            DropForeignKey("dbo.MapMonster", "MonsterVNum", "dbo.NpcMonster");
            DropForeignKey("dbo.Drop", "MonsterVNum", "dbo.NpcMonster");
            DropForeignKey("dbo.ShopItem", "ItemVNum", "dbo.Item");
            DropForeignKey("dbo.RecipeItem", "ItemVNum", "dbo.Item");
            DropForeignKey("dbo.Recipe", "ItemVNum", "dbo.Item");
            DropForeignKey("dbo.RecipeItem", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Teleporter", "MapNpcId", "dbo.MapNpc");
            DropForeignKey("dbo.Shop", "MapNpcId", "dbo.MapNpc");
            DropForeignKey("dbo.ShopSkill", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.ShopItem", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.Recipe", "MapNpcId", "dbo.MapNpc");
            DropForeignKey("dbo.Teleporter", "MapId", "dbo.Map");
            DropForeignKey("dbo.Portal", "SourceMapId", "dbo.Map");
            DropForeignKey("dbo.Portal", "DestinationMapId", "dbo.Map");
            DropForeignKey("dbo.MapNpc", "MapId", "dbo.Map");
            DropForeignKey("dbo.MapMonster", "MapId", "dbo.Map");
            DropForeignKey("dbo.Character", "MapId", "dbo.Map");
            DropForeignKey("dbo.InventoryItem", "ItemVNum", "dbo.Item");
            DropForeignKey("dbo.Inventory", "InventoryId", "dbo.InventoryItem");
            DropForeignKey("dbo.CellonOption", "InventoryItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.Drop", "ItemVNum", "dbo.Item");
            DropForeignKey("dbo.Combo", "SkillVNum", "dbo.Skill");
            DropForeignKey("dbo.CharacterSkill", "SkillVNum", "dbo.Skill");
            DropIndex("dbo.Respawn", new[] { "CharacterId" });
            DropIndex("dbo.QuicklistEntry", new[] { "CharacterId" });
            DropIndex("dbo.GeneralLog", new[] { "CharacterId" });
            DropIndex("dbo.GeneralLog", new[] { "AccountId" });
            DropIndex("dbo.RecipeItem", new[] { "RecipeId" });
            DropIndex("dbo.RecipeItem", new[] { "ItemVNum" });
            DropIndex("dbo.ShopSkill", new[] { "SkillVNum" });
            DropIndex("dbo.ShopSkill", new[] { "ShopId" });
            DropIndex("dbo.ShopItem", new[] { "ShopId" });
            DropIndex("dbo.ShopItem", new[] { "ItemVNum" });
            DropIndex("dbo.Shop", new[] { "MapNpcId" });
            DropIndex("dbo.Teleporter", new[] { "MapNpcId" });
            DropIndex("dbo.Teleporter", new[] { "MapId" });
            DropIndex("dbo.Portal", new[] { "SourceMapId" });
            DropIndex("dbo.Portal", new[] { "DestinationMapId" });
            DropIndex("dbo.MapMonster", new[] { "MonsterVNum" });
            DropIndex("dbo.MapMonster", new[] { "MapId" });
            DropIndex("dbo.MapNpc", new[] { "NpcVNum" });
            DropIndex("dbo.MapNpc", new[] { "MapId" });
            DropIndex("dbo.Recipe", new[] { "MapNpcId" });
            DropIndex("dbo.Recipe", new[] { "ItemVNum" });
            DropIndex("dbo.Inventory", new[] { "CharacterId" });
            DropIndex("dbo.Inventory", new[] { "InventoryId" });
            DropIndex("dbo.CellonOption", new[] { "InventoryItemId" });
            DropIndex("dbo.InventoryItem", new[] { "ItemVNum" });
            DropIndex("dbo.Drop", new[] { "MonsterVNum" });
            DropIndex("dbo.Drop", new[] { "ItemVNum" });
            DropIndex("dbo.NpcMonsterSkill", new[] { "SkillVNum" });
            DropIndex("dbo.NpcMonsterSkill", new[] { "NpcMonsterVNum" });
            DropIndex("dbo.Combo", new[] { "SkillVNum" });
            DropIndex("dbo.CharacterSkill", new[] { "SkillVNum" });
            DropIndex("dbo.CharacterSkill", new[] { "CharacterId" });
            DropIndex("dbo.Character", new[] { "MapId" });
            DropIndex("dbo.Character", new[] { "AccountId" });
            DropTable("dbo.Respawn");
            DropTable("dbo.QuicklistEntry");
            DropTable("dbo.GeneralLog");
            DropTable("dbo.RecipeItem");
            DropTable("dbo.ShopSkill");
            DropTable("dbo.ShopItem");
            DropTable("dbo.Shop");
            DropTable("dbo.Teleporter");
            DropTable("dbo.Portal");
            DropTable("dbo.MapMonster");
            DropTable("dbo.Map");
            DropTable("dbo.MapNpc");
            DropTable("dbo.Recipe");
            DropTable("dbo.Inventory");
            DropTable("dbo.CellonOption");
            DropTable("dbo.InventoryItem");
            DropTable("dbo.Item");
            DropTable("dbo.Drop");
            DropTable("dbo.NpcMonster");
            DropTable("dbo.NpcMonsterSkill");
            DropTable("dbo.Combo");
            DropTable("dbo.Skill");
            DropTable("dbo.CharacterSkill");
            DropTable("dbo.Character");
            DropTable("dbo.Account");
        }
    }
}
