using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.Persistance;
using CD.Infrastructure.Util;
using ESQ.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Persistance.DataProvider
{
    public class CDDataProvider: ICDDataProvider
    {

        public UserProfile AuthenticateUser(string userName, IDbContext dbContext)
        {
            String sql = Config.DataProvider_AuthenticateUser;

            SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);

            cmd.Parameters.AddWithValue("@UserName", userName);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    var userProfle = EntityMapper.FillUserProfileFromReader(reader);

                    return userProfle;
                }
            }
            return null; // user not found
        }

    }
}
