﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenNos.Import.Console.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LocalizedResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizedResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OpenNos.Import.Console.Resource.LocalizedResources", typeof(LocalizedResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Database has been initialized..
        /// </summary>
        internal static string DATABASE_HAS_BEEN_INITIALISE {
            get {
                return ResourceManager.GetString("DATABASE_HAS_BEEN_INITIALISE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter the directory of files to parse.
        /// </summary>
        internal static string ENTER_PATH {
            get {
                return ResourceManager.GetString("ENTER_PATH", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} maps parsed.
        /// </summary>
        internal static string MAPS_PARSED {
            get {
                return ResourceManager.GetString("MAPS_PARSED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You need a directory tree like this :.
        /// </summary>
        internal static string NEED_TREE {
            get {
                return ResourceManager.GetString("NEED_TREE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} npcs parsed.
        /// </summary>
        internal static string NPCS_PARSED {
            get {
                return ResourceManager.GetString("NPCS_PARSED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} portals parsed.
        /// </summary>
        internal static string PORTALS_PARSED {
            get {
                return ResourceManager.GetString("PORTALS_PARSED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} shops parsed.
        /// </summary>
        internal static string SHOPS_PARSED {
            get {
                return ResourceManager.GetString("SHOPS_PARSED", resourceCulture);
            }
        }
    }
}