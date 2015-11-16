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

            var prmName = cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            prmName.Value = DataHelper.SetValue(template.Name);

            var prmDescription = cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
            prmDescription.Value = DataHelper.SetValue(template.Description);

            cmd.Parameters.AddWithValue("@UseCommandShell", Constants.UseCommandShell);
            cmd.Parameters.AddWithValue("@CannedCommand", Constants.CannedCommand);
            cmd.Parameters.AddWithValue("@CommandResultTestPatternText", Config.ContentDistributionCommandResultTestPatternText);
            cmd.Parameters.AddWithValue("@CommandResultTestPatternType", Config.ContentDistributionCommandResultTestPatternType);
            cmd.Parameters.AddWithValue("@TimeoutDurationSecs", Config.ATMFileTransferTimeout);
            cmd.Parameters.AddWithValue("@WaitInterval", Constants.WaitInterval);
            cmd.Parameters.AddWithValue("@UserId", template.UserId);   // get userId 
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

        public bool IsCommandScheduledAgainstTemplate(string templateName, IDbContext dbContext)
        {
            string sql = string.Format(Config.DataProvider_GetCommandScheduledAgainstTemplate, templateName);
            SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (Convert.ToInt32(reader.GetValue(0)) > 0)
                        return true;
                }
            }
            return false;
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

        public IList<FilterDefs> GetTerminalFilters(IDbContext dbContext)
        {
            IList<FilterDefs> terminalFilterList = new List<FilterDefs>();
            var sql = String.Format(Config.DataProvider_GetTerminalsFilter);

            var cmd = new SqlCommand(sql, dbContext.Connection);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var terminalFilter = EntityMapper.FillTerminalFilterFromReader(reader);
                    terminalFilterList.Add(terminalFilter);

                }
            }
            return terminalFilterList;
        }

        public IList<Terminal> GetTerminalSets(IDbContext dbContext)
        {
            IList<Terminal> terminalList = new List<Terminal>();
            var sql = String.Format(Config.DataProvider_GetTerminalsSet);

            var cmd = new SqlCommand(sql, dbContext.Connection);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var terminal = EntityMapper.FillTerminalFromReader(reader);
                    terminalList.Add(terminal);

                }
            }
            return terminalList;

        }

        public IList<Terminal> GetTerminals(IDbContext dbContext)
        {
            IList<Terminal> terminalList = new List<Terminal>();
            var sql = String.Format(Config.DataProvider_GetTerminals);

            var cmd = new SqlCommand(sql, dbContext.Connection);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var terminal = EntityMapper.FillTerminalFromReader(reader);
                    terminalList.Add(terminal);

                }
            }
            return terminalList;
        }

        public bool CreateTerminalFilter(FilterDefs terminalFilter, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_InsertTerminalFilter);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var prmreturnValue = cmd.Parameters.Add("@returnValue", SqlDbType.SmallInt);
                prmreturnValue.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@FilterName", terminalFilter.FilterName);
                cmd.Parameters.AddWithValue("@Description", terminalFilter.Description);
                cmd.Parameters.AddWithValue("@SQL", terminalFilter.SQL);
                cmd.Parameters.AddWithValue("@FilterExpression", terminalFilter.FilterExpression);
                cmd.Parameters.AddWithValue("@CreatedOn", terminalFilter.CreatedOn);
                cmd.Parameters.AddWithValue("@CreatedBy", terminalFilter.CreatedBy);
                cmd.Parameters.AddWithValue("@VisibleToOthers", terminalFilter.VisibleToOthers);
                cmd.Parameters.AddWithValue("@ShownOnModules", terminalFilter.ShownOnModules);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTerminalFilter(string filterId, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_DeleteTerminalFilter, filterId);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.Text;

                //var prmreturnValue = cmd.Parameters.Add("@returnValue", SqlDbType.SmallInt);
                //prmreturnValue.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@FilterId", filterId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTerminalFilter(string filterId, FilterDefs terminalFilter, ITransactionContext transactionContext)
        {
            string sql = string.Format(Config.DataProvider_UpdateTerminalFilter);

            using (var cmd = new SqlCommand(sql, transactionContext.Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var prmreturnValue = cmd.Parameters.Add("@returnValue", SqlDbType.SmallInt);
                prmreturnValue.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@FilterId", terminalFilter.FilterId);
                cmd.Parameters.AddWithValue("@FilterName", terminalFilter.FilterName);
                cmd.Parameters.AddWithValue("@Description", terminalFilter.Description);
                cmd.Parameters.AddWithValue("@SQL", terminalFilter.SQL);
                cmd.Parameters.AddWithValue("@FilterExpression", terminalFilter.FilterExpression);
                cmd.Parameters.AddWithValue("@CreatedOn", terminalFilter.CreatedOn);
                cmd.Parameters.AddWithValue("@CreatedBy", terminalFilter.CreatedBy);
                cmd.Parameters.AddWithValue("@VisibleToOthers", terminalFilter.VisibleToOthers);
                cmd.Parameters.AddWithValue("@ShownOnModules", terminalFilter.ShownOnModules);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
