﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AncillaryApplication {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AncillaryApplication.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The queued message was not valid JSON for its type: &apos;{0}&apos;, message was: {1}.
        /// </summary>
        internal static string AncillaryApplication_InvalidQueuedMessage {
            get {
                return ResourceManager.GetString("AncillaryApplication_InvalidQueuedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The audit message is missing a &apos;AuditCode&apos;.
        /// </summary>
        internal static string AncillaryApplication_MissingAuditCode {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingAuditCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The email message is missing a &apos;HtmlBody&apos;.
        /// </summary>
        internal static string AncillaryApplication_MissingEmailBody {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingEmailBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The email message is missing the &apos;HTML&apos; email.
        /// </summary>
        internal static string AncillaryApplication_MissingEmailHtml {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingEmailHtml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The email message is missing a &apos;ToEmailAddress&apos; recipient.
        /// </summary>
        internal static string AncillaryApplication_MissingEmailRecipient {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingEmailRecipient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The email message is missing a &apos;FromEmailAddress&apos; sender.
        /// </summary>
        internal static string AncillaryApplication_MissingEmailSender {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingEmailSender", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The email message is missing a &apos;Subject&apos;.
        /// </summary>
        internal static string AncillaryApplication_MissingEmailSubject {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingEmailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The audit message is missing a &apos;TenantId&apos;.
        /// </summary>
        internal static string AncillaryApplication_MissingTenantId {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingTenantId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The usage message is missing a &apos;EventName&apos;.
        /// </summary>
        internal static string AncillaryApplication_MissingUsageEventName {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingUsageEventName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The usage message is missing a &apos;ForId&apos;.
        /// </summary>
        internal static string AncillaryApplication_MissingUsageForId {
            get {
                return ResourceManager.GetString("AncillaryApplication_MissingUsageForId", resourceCulture);
            }
        }
    }
}
