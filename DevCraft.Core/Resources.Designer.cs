﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevCraft.Core {
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
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DevCraft.Core.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm Close.
        /// </summary>
        public static string ConfirmClose {
            get {
                return ResourceManager.GetString("ConfirmClose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [DevCraft]:.
        /// </summary>
        public static string DevCraftOutputPrefix {
            get {
                return ResourceManager.GetString("DevCraftOutputPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server folder was null, empty, or whitespace and should point to an actual directory..
        /// </summary>
        public static string ErrorPropertiesFolder {
            get {
                return ResourceManager.GetString("ErrorPropertiesFolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error starting Minecraft:.
        /// </summary>
        public static string ErrorStarting {
            get {
                return ResourceManager.GetString("ErrorStarting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error stopping Minecraft:.
        /// </summary>
        public static string ErrorStopping {
            get {
                return ResourceManager.GetString("ErrorStopping", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Minecraft Map Backup Directory.
        /// </summary>
        public static string MinecraftMapBackupDirectory {
            get {
                return ResourceManager.GetString("MinecraftMapBackupDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Minecraft Server Directory.
        /// </summary>
        public static string MinecraftServerDirectory {
            get {
                return ResourceManager.GetString("MinecraftServerDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Closing DevCraft will shut down your minecraft server (safely), continue?.
        /// </summary>
        public static string SafelyCloseContinue {
            get {
                return ResourceManager.GetString("SafelyCloseContinue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Minecraft server started.
        /// </summary>
        public static string Started {
            get {
                return ResourceManager.GetString("Started", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting Minecraft server....
        /// </summary>
        public static string Starting {
            get {
                return ResourceManager.GetString("Starting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Minecraft server stopped.
        /// </summary>
        public static string Stopped {
            get {
                return ResourceManager.GetString("Stopped", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stopping Minecraft server....
        /// </summary>
        public static string Stopping {
            get {
                return ResourceManager.GetString("Stopping", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to write input, server hasn&apos;t been started yet..
        /// </summary>
        public static string UnableToWriteInput {
            get {
                return ResourceManager.GetString("UnableToWriteInput", resourceCulture);
            }
        }
    }
}