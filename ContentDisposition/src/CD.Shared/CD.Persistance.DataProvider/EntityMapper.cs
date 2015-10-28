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

        #endregion
    }
}
