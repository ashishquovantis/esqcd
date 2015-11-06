using CD.Infrastructure.Poco;
using CD.Infrastructure.Util;
using ESQ.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Persistance.DataProvider
{
    public class EntityMapper
    {

        #region CD

        internal static UserProfile FillUserProfileFromReader(SqlDataReader reader)
        {
            var userProfile = new UserProfile();

            if (reader != null && !reader.IsClosed)
            {
                DataTable dt = reader.GetSchemaTable();
                if (dt.Select("ColumnName='" + "GroupId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("GroupId")))
                        userProfile.GroupId = reader.GetInt16(reader.GetOrdinal("GroupId"));
                if (dt.Select("ColumnName='" + "UserId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("UserId")))
                        userProfile.UserId = reader.GetInt16(reader.GetOrdinal("UserId"));
                if (dt.Select("ColumnName='" + "UserName" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("UserName")))
                        userProfile.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                if (dt.Select("ColumnName='" + "IsAdmin" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("IsAdmin")))
                        userProfile.IsAdmin = reader.GetInt32(reader.GetOrdinal("IsAdmin")) == 1;
                if (dt.Select("ColumnName='" + "Active" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Active")))
                        userProfile.IsActive = reader.GetInt16(reader.GetOrdinal("Active")) == 1;
                if (dt.Select("ColumnName='" + "Name" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                    {
                        userProfile.GroupName = reader.GetString(reader.GetOrdinal("Name"));
                        if (userProfile.GroupName != Config.SuperAdminGroupName)
                        {
                            userProfile.IsAdmin = false;
                        }
                    }
                if (dt.Select("ColumnName='" + "LoginTime" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginTime")))
                        userProfile.LastLogin = reader.GetDateTime(reader.GetOrdinal("LoginTime"));
                if (dt.Select("ColumnName='" + "CurrentTime" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CurrentTime")))
                        userProfile.CurrenLogintTime = reader.GetDateTime(reader.GetOrdinal("CurrentTime"));
                if (dt.Select("ColumnName='" + "GroupRole" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("GroupRole")))
                        userProfile.GroupRole = reader.GetString(reader.GetOrdinal("GroupRole"));

                userProfile.XmlPreference = DataHelper.GetValue(reader, "Preferences", TypeDefaultValue.StringDefaultValue);
                userProfile.GUID = Guid.NewGuid().ToString();
            }

            return userProfile;
        }

        internal static Template FillTemplateFromReader(IDataReader reader)
        {
            var template = new Template();

            if (reader != null && !reader.IsClosed)
            {
                DataTable dt = reader.GetSchemaTable();

                if (dt.Select("ColumnName='" + "CommandId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CommandId")))
                        template.TemplateId = reader.GetInt16(reader.GetOrdinal("CommandId"));
                if (dt.Select("ColumnName='" + "Name" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                        template.Name = reader.GetString(reader.GetOrdinal("Name"));
                if (dt.Select("ColumnName='" + "Description" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                        template.Description = reader.GetString(reader.GetOrdinal("Description"));
                if (dt.Select("ColumnName='" + "CannedCommand" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CannedCommand")))
                        template.CannedCommand = reader.GetByte(reader.GetOrdinal("CannedCommand"));
                if (dt.Select("ColumnName='" + "AppName" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("AppName")))
                        template.AppName = reader.GetString(reader.GetOrdinal("AppName"));
                if (dt.Select("ColumnName='" + "Params" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Params")))
                        template.Params = reader.GetString(reader.GetOrdinal("Params"));
                if (dt.Select("ColumnName='" + "UseCommandShell" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("UseCommandShell")))
                        template.UseCommandShell = reader.GetByte(reader.GetOrdinal("UseCommandShell"));
                if (dt.Select("ColumnName='" + "TimeoutDurationSecs" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("TimeoutDurationSecs")))
                        template.TimeoutDurationSecs = reader.GetInt16(reader.GetOrdinal("TimeoutDurationSecs"));
                if (dt.Select("ColumnName='" + "UserId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("UserId")))
                        template.UserId = reader.GetInt16(reader.GetOrdinal("UserId"));
                if (dt.Select("ColumnName='" + "WaitInterval" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("WaitInterval")))
                        template.WaitInterval = reader.GetInt16(reader.GetOrdinal("WaitInterval"));
                if (dt.Select("ColumnName='" + "InvokeCategory" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("InvokeCategory")))
                        template.InvokeCategory = reader.GetString(reader.GetOrdinal("InvokeCategory"));
                if (dt.Select("ColumnName='" + "InvokeItemName" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("InvokeItemName")))
                        template.InvokeItemName = reader.GetString(reader.GetOrdinal("InvokeItemName"));
                if (dt.Select("ColumnName='" + "CommandResultTestPatternText" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CommandResultTestPatternText")))
                        template.CommandResultTestPatternText = reader.GetString(reader.GetOrdinal("CommandResultTestPatternText"));
                if (dt.Select("ColumnName='" + "CommandResultTestPatternType" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CommandResultTestPatternType")))
                        template.CommandResultTestPatternType = reader.GetInt16(reader.GetOrdinal("CommandResultTestPatternType"));
                if (dt.Select("ColumnName='" + "CommandMenuGroupId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CommandMenuGroupId")))
                        template.CommandMenuGroupId = reader.GetInt16(reader.GetOrdinal("CommandMenuGroupId"));

            }

            return template;
        }

        #endregion

        internal static Terminal FillTerminalFromReader(SqlDataReader reader)
        {
            var terminal = new Terminal();

            if (reader != null && !reader.IsClosed)
            {
                DataTable dt = reader.GetSchemaTable();
                if (dt.Select("ColumnName='" + "AtmSetId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("AtmSetId")))
                        terminal.AtmSetId = reader.GetInt16(reader.GetOrdinal("AtmSetId"));
                if (dt.Select("ColumnName='" + "Name" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                        terminal.Name = reader.GetString(reader.GetOrdinal("Name"));
                //if (dt.Select("ColumnName='" + "Description" + "'").Length > 0)
                //    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                //        terminal.Description = reader.GetString(reader.GetOrdinal("Description"));
                //if (dt.Select("ColumnName='" + "QueryBlob" + "'").Length > 0)
                //    if (!reader.IsDBNull(reader.GetOrdinal("QueryBlob")))
                //        terminal.QueryBlob = reader.GetString(reader.GetOrdinal("QueryBlob"));
                //if (dt.Select("ColumnName='" + "TermIds" + "'").Length > 0)
                //    if (!reader.IsDBNull(reader.GetOrdinal("TermIds")))
                //        terminal.TermIds = reader.GetString(reader.GetOrdinal("TermIds"));
                if (dt.Select("ColumnName='" + "SQL" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("SQL")))
                        terminal.SQL = reader.GetString(reader.GetOrdinal("SQL"));
                //if (dt.Select("ColumnName='" + "UserId" + "'").Length > 0)
                //    if (!reader.IsDBNull(reader.GetOrdinal("UserId")))
                //        terminal.UserId = reader.GetInt64(reader.GetOrdinal("UserId"));

            }

            return terminal;
        }

        internal static FilterDefs FillTerminalFilterFromReader(SqlDataReader reader)
        {
            var terminalFilter = new FilterDefs();

            if (reader != null && !reader.IsClosed)
            {
                DataTable dt = reader.GetSchemaTable();
                if (dt.Select("ColumnName='" + "FilterId" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("FilterId")))
                        terminalFilter.FilterId = reader.GetInt32(reader.GetOrdinal("FilterId"));
                if (dt.Select("ColumnName='" + "FilterName" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("FilterName")))
                        terminalFilter.FilterName = reader.GetString(reader.GetOrdinal("FilterName"));
                if (dt.Select("ColumnName='" + "Description" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                        terminalFilter.Description = reader.GetString(reader.GetOrdinal("Description"));
                if (dt.Select("ColumnName='" + "SQL" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("SQL")))
                        terminalFilter.SQL = reader.GetString(reader.GetOrdinal("SQL"));
                if (dt.Select("ColumnName='" + "FilterExpression" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("FilterExpression")))
                        terminalFilter.FilterExpression = reader.GetString(reader.GetOrdinal("FilterExpression"));
                if (dt.Select("ColumnName='" + "CreatedOn" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CreatedOn")))
                        terminalFilter.CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                if (dt.Select("ColumnName='" + "CreatedBy" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("CreatedBy")))
                        terminalFilter.CreatedBy = reader.GetInt16(reader.GetOrdinal("CreatedBy"));
                if (dt.Select("ColumnName='" + "VisibleToOthers" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("VisibleToOthers")))
                        terminalFilter.VisibleToOthers = reader.GetByte(reader.GetOrdinal("VisibleToOthers"));
                if (dt.Select("ColumnName='" + "ShownOnModules" + "'").Length > 0)
                    if (!reader.IsDBNull(reader.GetOrdinal("ShownOnModules")))
                        terminalFilter.ShownOnModules = reader.GetInt32(reader.GetOrdinal("ShownOnModules"));
            }
            return terminalFilter;

        }
    }
}
