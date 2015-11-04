using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading;
using System.IO;
using CD.Infrastructure.Poco.Enum;

namespace CD.Infrastructure.Util
{
    public static class Config
    {
        private const string SuperAdminGroupNameKey = "SuperAdminGroupName";

        public static string SuperAdminGroupName { get { return GetAppSettings(SuperAdminGroupNameKey, "InternalAdminGroup-165-273-332"); } }

        // Get User
        public static string ApplicationNameForRBAC { get { return GetAppSettings("RBAC.Main.ApplicationName", "NTS"); } }

        public static bool AuthorizationServiceRemoteProxy
        {
            get
            {
                return GetAppSettingsAsBool("AuthorizationServiceRemoteProxy", false);
            }
        }

        /// <summary>
        /// Get value from AppSettings section with default if empty
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetAppSettings(string key, string defaultValue)
        {
            string value = GetAppSettings(key);

            if (string.IsNullOrEmpty(value))
                value = defaultValue;

            return value;
        }

        /// <summary>
        /// Get bool value from AppSettings section
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool GetAppSettingsAsBool(string key, bool defaultValue)
        {
            string value = GetAppSettings(key, defaultValue ? "true" : "false").ToLower();
            return value.Equals("true") || value.Equals("yes") || value.Equals("1");
        }

        /// <summary>
        /// Get value from AppSettings section
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string DataProvider_AuthenticateUser
        {
            get
            {
                return GetAppSettings("DataProvider_AuthenticateUser",
                    (string.Format(@"select userdefs.GroupId,userdefs.UserId,userdefs." + UserNameDisplayColumnName + @" as UserName,
                        CAST(usergroupdefs.IsAdmin AS int) as IsAdmin,userdefs.active as Active,UserGroupDefs.Name, 
                        dateadd(second,datediff(second, getutcdate(), getdate()),userdefs.LoginTime) as LoginTime, 
                        getutcdate() as CurrentTime, usergroupdefs.GroupRole as GroupRole, HDPreferences as Preferences
                        from userdefs (NOLOCK),usergroupdefs (NOLOCK) where 
                        userdefs.UserName = @UserName and 
                        usergroupdefs.groupid = userdefs.groupid And usergroupdefs.Application = '{0}'", ApplicationNameForRBAC)));
            }
        }

        public static string UserNameDisplayColumnName
        {
            get
            {
                string column = GetAppSettings("UserNameDisplayColumnName", "UserName");
                if (column.Equals("FullName", StringComparison.OrdinalIgnoreCase))
                    return "FullName";
                else
                    return "UserName";
            }
        }

        public static string WebMessageHandler_Username { get { return GetAppSettings("WebMessageHandler_Username", "admin"); } }

        public static string WebMessageHandler_Password { get { return GetAppSettings("WebMessageHandler_Password", "admin"); } }

        #region todo
        public static string DataProvider_DeleteTemplate
        {
            get
            {
                return GetAppSettings("DataProvider_DeleteTemplate",
                    @"proc_DeleteTemplate");
            }
        }

        public static string DataProvider_UpdateTemplate
        {
            get
            {
                return GetAppSettings("DataProvider_UpdateTemplate",
                    @"proc_UpdateTemplate");
            }
        }

        public static string DataProvider_CreateTemplate
        {
            get
            {
                return GetAppSettings("DataProvider_CreateTemplate",
                    @"proc_InsertTemplate");
            }
        }

        public static string DataProvider_GetTemplates
        {
            get
            {
                return GetAppSettings("DataProvider_GetTemplates",
                    @"proc_GetTemplates");
            }
        }

        public static string DataProvider_GetTemplateById
        {
            get
            {
                return GetAppSettings("DataProvider_GetTemplateById",
                    @"proc_GetTemplateById");
            }
        }

        public static string DataProvider_GetTemplateByName
        {
            get
            {
                return GetAppSettings("DataProvider_GetTemplateByName",
                    @"proc_GetTemplateByName");
            }
        }

        public static string DataProvider_DeleteTemplateByName
        {
            get
            {
                return GetAppSettings("DataProvider_DeleteTemplateByName",
                    @"proc_DeleteTemplateByName");
            }
        }

        public static string DataProvider_UpdateTemplateByName
        {
            get
            {
                return GetAppSettings("DataProvider_UpdateTemplateByName",
                    @"proc_UpdateTemplateByName");
            }
        }

        public static int ATMFileTransferTimeout
        {
            get
            {
                return Util.parseInt(ConfigurationManager.AppSettings["ATMFileTransferTimeout"], 30);
            }

        }


        public static string ContentDistributionCommandResultTestPatternText
        {
            get
            {
                string strCommandResultTestPatternText = ConfigurationManager.AppSettings["ContentDistributionCommandResultTestPatternText"];
                if (!string.IsNullOrEmpty(strCommandResultTestPatternText))
                    return strCommandResultTestPatternText;

                return "!RESULT = SUCCESS!";
            }
        }


        public static int ContentDistributionCommandResultTestPatternType
        {
            get
            {
                return Util.parseInt(ConfigurationManager.AppSettings["ContentDistributionCommandResultTestPatternType"], 2);
            }
        }


        public static string ATMFileTransferSourceURLParamName
        {
            get
            {
                String strURL = ConfigurationManager.AppSettings["ATMFileTransferSourceURLParamName"];
                if (!string.IsNullOrEmpty(strURL))
                {
                    return strURL.Trim();
                }
                else
                {
                    return "HTTPLinkFile";
                }
            }
        }

        public static string FileUploadIPAddressSubstitutionParamString
        {
            get
            {
                String strParamName = ConfigurationManager.AppSettings["FileUploadIPAddressSubstitutionParamString"];
                if (!string.IsNullOrEmpty(strParamName))
                {
                    return strParamName.Trim();
                }
                else
                {
                    return "%Remote Address%";
                }
            }
        }

        public static int ATMFileTransferPortNumber
        {
            get
            {
                return Util.parseInt(ConfigurationManager.AppSettings["ATMFileTransferPortNumber"], 10030);
            }

        }

        #endregion

    }
}
