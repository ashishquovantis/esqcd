using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.Persistance;
using CD.Infrastructure.Util;
using ESQ.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Persistance.DataProvider
{
    public class CDDataProvider : ICDDataProvider
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

        public bool CreateTemplate(Template template, ITransactionContext transactionContext)
        {
            string sql = Config.DataProvider_CreateTemplate;
     
            var cmd = new SqlCommand(sql, transactionContext.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            var prmreturnValue = cmd.Parameters.Add("@returnValue", SqlDbType.SmallInt);
            prmreturnValue.Direction = ParameterDirection.Output;

            var prmtemplateId = cmd.Parameters.Add("@CommandId", SqlDbType.SmallInt);
            prmtemplateId.Value = DataHelper.SetValue(template.TemplateId);

            var prmName = cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            prmName.Value = DataHelper.SetValue(template.Name);

            var prmDescription = cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
            prmDescription.Value = DataHelper.SetValue(template.Description);

            cmd.Parameters.AddWithValue("@UseCommandShell",Constants.UseCommandShell);
            cmd.Parameters.AddWithValue("@CannedCommand", Constants.CannedCommand);
            cmd.Parameters.AddWithValue("@CommandResultTestPatternText", Config.ContentDistributionCommandResultTestPatternText);
            cmd.Parameters.AddWithValue("@CommandResultTestPatternType", Config.ContentDistributionCommandResultTestPatternType);
            cmd.Parameters.AddWithValue("@TimeoutDurationSecs", Config.ATMFileTransferTimeout);
            cmd.Parameters.AddWithValue("@WaitInterval", Constants.WaitInterval);
            cmd.Parameters.AddWithValue("@UserId", 112);   // get userId 
            cmd.Parameters.AddWithValue("@AppName", Constants.AppName);
            cmd.Parameters.AddWithValue("@Params", template.Params);
            cmd.Parameters.AddWithValue("@InvokeCategory", Constants.InvokeCategory);

            cmd.ExecuteNonQuery();

            int result = Convert.ToInt32(prmreturnValue.Value);
            if (result <= 0)
            {
                return false;
            }

            return true;
        }

        public bool DeleteTemplate(string templateId, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_DeleteTemplate);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var commandId = cmd.Parameters.Add("@CommandId", SqlDbType.SmallInt);
                commandId.Value = DataHelper.SetValue(templateId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTemplate(string templateId, Template template, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_UpdateTemplate);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var prmreturnValue = cmd.Parameters.Add("@returnValue", SqlDbType.SmallInt);
                prmreturnValue.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CommandId", template.TemplateId);
                cmd.Parameters.AddWithValue("@Name", template.Name);
                cmd.Parameters.AddWithValue("@Params", template.Params);
                cmd.Parameters.AddWithValue("@CommandResultTestPatternText", Config.ContentDistributionCommandResultTestPatternText);
                cmd.Parameters.AddWithValue("@CommandResultTestPatternType", Config.ContentDistributionCommandResultTestPatternType);

                return cmd.ExecuteNonQuery() > 0;
            }

        }

        public Template GetTemplate(string templateId, IDbContext dbContext)
        {
            Template template = null;
            var sql = String.Format(Config.DataProvider_GetTemplateById);

            var cmd = new SqlCommand(sql, dbContext.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CommandId", templateId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    template = EntityMapper.FillTemplateFromReader(reader);
                }
            }
            return template;
        }

        public IList<Template> GetTemplates(IDbContext dbContext)
        {
            IList<Template> templateList = new List<Template>();
            var sql = String.Format(Config.DataProvider_GetTemplates);

            var cmd = new SqlCommand(sql, dbContext.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var template = EntityMapper.FillTemplateFromReader(reader);
                    templateList.Add(template);

                }
            }
            return templateList;
        }

        public bool DeleteTemplateByName(string templateName, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_DeleteTemplateByName);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var commandId = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                commandId.Value = DataHelper.SetValue(templateName);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Template GetTemplateByName(string templateName, IDbContext dbContext)
        {
            Template template = null;
            var sql = String.Format(Config.DataProvider_GetTemplateByName);

            var cmd = new SqlCommand(sql, dbContext.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", templateName);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    template = EntityMapper.FillTemplateFromReader(reader);
                }
            }
            return template;
        }

        public bool UpdateTemplateByName(string templateName, Template template, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_UpdateTemplateByName);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var prmreturnValue = cmd.Parameters.Add("@returnValue", SqlDbType.SmallInt);
                prmreturnValue.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@CommandId", template.TemplateId);
                cmd.Parameters.AddWithValue("@Name", template.Name);
                cmd.Parameters.AddWithValue("@Params", template.Params);
                cmd.Parameters.AddWithValue("@CommandResultTestPatternText", Config.ContentDistributionCommandResultTestPatternText);
                cmd.Parameters.AddWithValue("@CommandResultTestPatternType", Config.ContentDistributionCommandResultTestPatternType);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
