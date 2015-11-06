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
        public static string ApplicationNameForRBAC { get { return GetAppSettings("RBAC.Main.ApplicationName", "IMS"); } }

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
                    @"proc_DeleteTemplateById");
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

        public static string DataProvider_GetTerminals   //need to review 
        {
            get
            {
                String permSql = String.Format
            (
                @"Select distinct (case when (select COUNT(*) from ATMSETDEFS ) = (select COUNT(*) from ATMSETDEFS (NOLOCK),PERM (NOLOCK)
                                                                                    where ATMSETDEFS.AtmSetId = PERM.ObjectId and 
                                                                                    PERM.ObjectType = {0} and PERM.UserId = {2} and PERM.rView = 1) 
				                    then ' 1 = 1 ' 
				                    else  ATMSETDEFS.SQL end ) as SQL 
                from ATMSETDEFS (NOLOCK),PERM (NOLOCK) where ATMSETDEFS.AtmSetId = PERM.ObjectId and 
                PERM.ObjectType = {0} and PERM.UserId = {2} and PERM.rView = 1",
                1,
                77,
                111
            );

                return permSql;
            }
        }

        public static string DataProvider_GetTerminalsSet     // right query
        {
            get
            {
                return GetAppSettings("DataProvider_GetTerminalsSet",
                    @"SELECT *  FROM ATMSETDEFS (NOLOCK)");

                //if (!ucr.isAdmin)
                //                       {
                //                           sqlTerminalSets += "where atmsetid in (select objectid from perm (NOLOCK) where " +
                //                                              "objecttype=1 AND RVIEW=1 and userid= " + ucr.uid +
                //                                              ") order by atmsetid";
                //                       }
                //                       else
                //                       {
                //                           sqlTerminalSets += " order by atmsetid";
                //                       }
            }
        }

        //public static List<string> EnableBlackListedTerminalsScreenList
        //{
        //    get
        //    {
        //        List<string> BlackListedTerminalsScreenList = new List<string>();
        //     //   string strBlackListedTerminalsScreenList = clsAppConfig.GetApplicationParameterValue("EnableBlackListedTerminalsOnScreens");   //1

        //        if (!string.IsNullOrEmpty(strBlackListedTerminalsScreenList))
        //        {
        //            BlackListedTerminalsScreenList = strBlackListedTerminalsScreenList.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        //        }
        //        return BlackListedTerminalsScreenList;
        //    }

        //}

        //public static string GetApplicationParameterValue(string paramName)      //clsAppConfig.cs  //1
        //{
        //    object obj = HttpContext.Current != null ? HttpContext.Current.Session["APP_PARAMETERS"] : null;
        //    Dictionary<string, string> parameters = obj as Dictionary<string, string> ??
        //                                            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        //    if (parameters.Count <= 0)
        //    {
        //        using (SqlConnection con = Util.openDBConnection(null))
        //        {
        //            parameters = GetAppParametersList(con, sqlAppParams);
        //            if (HttpContext.Current != null)
        //                HttpContext.Current.Session["APP_PARAMETERS"] = parameters;
        //        }
        //    }

        //    if (parameters.ContainsKey(paramName))
        //    {
        //        return parameters[paramName];
        //    }
        //    return string.Empty;
        //}

        public static string DataProvider_GetTerminalsFilter
        {
            get
            {
                return GetAppSettings("DataProvider_GetTerminalsFilter",
                  @"select * from FILTERDEFS (NOLOCK) where 1=2");
            }
        }

        public static string DataProvider_UpdateTerminalFilter
        {
            get
            {
                return GetAppSettings("DataProvider_UpdateTerminalFilter",
                  @"proc_UpdateTerminalFilter");
            }
        }

        public static string DataProvider_InsertTerminalFilter
        {
            get
            {
                return GetAppSettings("DataProvider_InsertTerminalFilter",
                  @"proc_InsertTerminalFilter");
            }
        }

        public static string DataProvider_DeleteTerminalFilter
        {
            get
            {
                return GetAppSettings("DataProvider_DeleteTerminalFilter",
                  @"Delete from [FilterDefs] where FilterId='{0}'");
            }
        }

        public static string DataProvider_GetCommandScheduledAgainstTemplate
        {
            get
            {
                return GetAppSettings("DataProvider_DeleteTerminalFilter",
                  @"select count(taskid) from taskdefs (NOLOCK) where actionData  like '%Command:{0}%'");
            }
        }

        

        #endregion

    }
}
