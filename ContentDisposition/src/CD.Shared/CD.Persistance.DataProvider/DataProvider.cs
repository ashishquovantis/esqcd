using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using ESQ.CrossCutting.Instrumentation;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Services;
using ESQ.Infrastructure.Services;
using CD.Infrastructure.Util;
using Extensions = ESQ.Infrastructure.Util.Extensions;


namespace CD.Persistance.DataProvider
{
    [ExceptionAspect(AttributePriority = 2)]
    public class DataProvider : IDataProvider
    {
        [ExceptionLoggingAspect(AttributeExclude = true)]
        public DataProvider() { }

        //public IDictionary<string, string> GetAppParameterDBList(IDbContext dbContext)
        //{
        //    IDictionary<string, string> appParameterDB = new Dictionary<string, string>();

        //    var sql = String.Format(Config.DataProvider_AppParameterQuery);
        //    var cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;

        //    using (IDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            appParameterDB.Add(reader.GetString(reader.GetOrdinal("ParamName")), reader.GetString(reader.GetOrdinal("ParamValue")));
        //        }
        //    }
        //    return appParameterDB;
        //}

        //public IEnumerable<T> GetItems<T>(string source, string sourceType, string keyField, IDbContext dbContext)
        //{
        //    var cmd = new SqlCommand(source, dbContext.Connection);
        //    cmd.CommandTimeout = Config.SqlCommandTimeoutCacheInitialization;
        //    cmd.CommandType = (CommandType)Enum.Parse(typeof(CommandType), sourceType);

        //    using (IDataReader reader = cmd.ExecuteReader())
        //    {
        //        return Extensions.MapDataToEntity<T>(reader, keyField);
        //    }
        //}

        //public IEnumerable<UserDef> GetAllUsers(IDbContext dbContext)
        //{
        //    var cmd = new SqlCommand("proc_getAllUsers_HD", dbContext.Connection);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    using (IDataReader reader = cmd.ExecuteReader())
        //    {
        //        return Extensions.MapDataToEntity<UserDef>(reader);
        //    }
        //}

        //public IList<AtmSet> GetAllTerminalSets(IDbContext dbContext)
        //{
        //    IList<AtmSet> list = new List<AtmSet>();
        //    var sql = Config.DataProvider_GetAllTerminalSets;

        //    SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandTimeout = Config.SqlCommandTimeoutCacheInitialization;
        //    cmd.CommandType = CommandType.Text;


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var atmset = EntityMapper.FillAtmSetFromReader(reader);

        //            list.Add(atmset);
        //        }
        //    }
        //    foreach (var atmSet in list)
        //    {
        //        atmSet.Atms = GetAllTerminalInTerminalSet(atmSet, dbContext);
        //    }
        //    return list;
        //}

        //public object GetLastTerminalSetUpdatedTime(IDbContext dbContext)
        //{
        //    var sql = string.Format(Config.DataProvider_AppParams, "LastTerminalSetUpdateTime");

        //    SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;

        //    object lastUpdatedAt = cmd.ExecuteScalar();
        //    return lastUpdatedAt;
        //}

        //public IList<AtmSet> GetAllTerminalSetsForSpecUser(int userId, IDbContext dbContext)
        //{
        //    IList<AtmSet> list = new List<AtmSet>();

        //    var sql = String.Format(Config.DataProvider_GetAllTerminalSetsForSpecUser, userId);

        //    SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var atmset = EntityMapper.FillAtmSetFromReader(reader);
        //            list.Add(atmset);
        //        }
        //    }
        //    //foreach (var atmset in list)
        //    //{
        //    //    atmset.Atms = GetAllTerminalInTerminalSet(atmset, dbContext);
        //    //}

        //    return list;
        //}

        //private IList<Atm> GetAllTerminalInTerminalSet(AtmSet atmSet, IDbContext dbContext)
        //{
        //    IList<Atm> list = new List<Atm>();
        //    var sql = String.Format(Config.DataProvider_GetAllTerminalInTerminalSet, atmSet.Sql);

        //    SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;

        //    try
        //    {
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                var atm = EntityMapper.FillAtmFromReader(reader);
        //                atm.AtmSetId = atmSet.AtmSetId;
        //                list.Add(atm);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Logger.Log.InfoFormat("Issue exist in where sql for AtmSetId : {0}", atmSet.AtmSetId);
        //    }

        //    return list;
        //}

        //public DateTime? GetCachedDataUpdateStatus(string testCondition, DateTime? lastUpdated, IDbContext dbContext)
        //{
        //    DateTime? DataUpdated = null;

        //    using (SqlCommand cmd = new SqlCommand(Config.GetKeyAppSettings(testCondition), dbContext.Connection))
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        //cmd.Parameters.AddWithValue("@LastUpdatedOn", lastUpdated);
        //        object LastUpdatedOn = cmd.ExecuteScalar();
        //        if (LastUpdatedOn != null)
        //        {
        //            DataUpdated = Convert.ToDateTime(LastUpdatedOn);
        //        }
        //    }
        //    return DataUpdated;
        //}

        //public IDictionary<long, Dictionary<string, object>> GetUpdatedCachedData(DateTime? lastUpdated, string RefreshSet, IDbContext dbContext)
        //{
        //    var customAtmData = new Dictionary<long, Dictionary<string, object>>();

        //    SqlCommand cmd = new SqlCommand(string.Format(Config.DataRefreshQuery(RefreshSet)), dbContext.Connection);
        //    cmd.Parameters.AddWithValue("@LastUpdatedOn", lastUpdated);
        //    cmd.CommandType = CommandType.Text;

        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var atmData = EntityMapper.FillCustomAtmDataFromReader(reader);

        //            customAtmData.Add(atmData.Key, atmData.Value);
        //        }
        //    }

        //    return customAtmData;
        //}

        //public IDictionary<long, Dictionary<string, object>> GetCustomAtmData(IDbContext dbContext)
        //{
        //    var customAtmData = new Dictionary<long, Dictionary<string, object>>();


        //    SqlCommand cmd = new SqlCommand(Config.CustomAtmDataQuery, dbContext.Connection);
        //    cmd.CommandTimeout = Config.SqlCommandTimeoutCacheInitialization;
        //    cmd.CommandType = CommandType.Text;

        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var atmData = EntityMapper.FillCustomAtmDataFromReader(reader);

        //            customAtmData.Add(atmData.Key, atmData.Value);
        //        }
        //    }

        //    return customAtmData;
        //}

        //public object GetItems(string source, string sourceType, IList<Tuple<string, string, object>> parameters, Type resultType, IDbContext dbContext)
        //{
        //    var propertyInfo = typeof(Config).GetProperty(source, BindingFlags.Public | BindingFlags.Static);

        //    string value;

        //    if (propertyInfo != null)
        //    {
        //        value = (string)propertyInfo.GetValue(null, null);
        //    }
        //    else
        //    {
        //        var methodInfo = typeof(Config).GetMethod(source, BindingFlags.Public | BindingFlags.Static);
        //        if (methodInfo != null)
        //        {
        //            value = (string)methodInfo.Invoke(null, new[] { parameters[0].Item3 });
        //            parameters.RemoveAt(0);
        //        }
        //        else
        //        {
        //            value = ConfigurationManager.AppSettings[source];
        //        }
        //    }

        //    var cmd = new SqlCommand(String.IsNullOrEmpty(value) ? source : value, dbContext.Connection);
        //    cmd.CommandType = (CommandType)Enum.Parse(typeof(CommandType), sourceType);

        //    PopulateParameters(cmd, parameters);

        //    try
        //    {
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            return EntityMapper.FillObjectCollection(reader, resultType);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Log.Error("Unable to get data : " + ex.Message + " " + ex.StackTrace);
        //    }
        //    return null;
        //}

        //public object GetKeyValueItems(string source, string sourceType, IList<Tuple<string, string, object>> parameters, Type resultType, IDbContext dbContext)
        //{
        //    var propertyInfo = typeof(Config).GetProperty(source, BindingFlags.Public | BindingFlags.Static);

        //    string value;

        //    if (propertyInfo != null)
        //    {
        //        value = (string)propertyInfo.GetValue(null, null);
        //    }
        //    else
        //    {
        //        var methodInfo = typeof(Config).GetMethod(source, BindingFlags.Public | BindingFlags.Static);
        //        if (methodInfo != null)
        //        {
        //            value = (string)methodInfo.Invoke(null, new[] { parameters[0].Item3 });
        //            parameters.RemoveAt(0);
        //        }
        //        else
        //        {
        //            value = ConfigurationManager.AppSettings[source];
        //        }
        //    }

        //    var cmd = new SqlCommand(String.IsNullOrEmpty(value) ? source : value, dbContext.Connection);
        //    cmd.CommandType = (CommandType)Enum.Parse(typeof(CommandType), sourceType);

        //    PopulateParameters(cmd, parameters);


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        return EntityMapper.FillKeyValueObjectCollection(reader, resultType);
        //    }
        //}

        //private void PopulateParameters(SqlCommand command, IList<Tuple<string, string, object>> parameters)
        //{
        //    if (command.CommandType == CommandType.StoredProcedure
        //           || command.CommandText.Contains("@"))
        //    {
        //        foreach (var parameter in parameters)
        //        {
        //            var prm = command.Parameters.Add(string.Format("@{0}", parameter.Item1),
        //                (SqlDbType)Enum.Parse(typeof(SqlDbType), parameter.Item2));
        //            prm.Value = DataHelper.SetValue(parameter.Item3);
        //        }
        //    }
        //    else
        //    {
        //        command.CommandText = string.Format(command.CommandText, parameters.Select(prm => prm.Item3).ToArray());
        //    }
        //}



        //public IList<Atm> GetTerminals(UserProfile currentUser, IDbContext dbContext)
        //{
        //    IList<Atm> list = new List<Atm>();

        //    var deviceSql = GetTerminalSetPermFilterQuery(currentUser, dbContext);
        //    var sql = string.Format(deviceSql.Length != 0 ? Config.DataProvider_GetTerminalsForDevice : Config.DataProvider_GetTerminals, deviceSql);

        //    var cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var atm = EntityMapper.FillAtmFromReader(reader);
        //            list.Add(atm);

        //        }
        //    }

        //    return list;

        //}

        //public IList<Site> GetSites(UserProfile currentUser, IDbContext dbContext)
        //{
        //    IList<Site> list = new List<Site>();

        //    var deviceSql = GetTerminalSetPermFilterQuery(currentUser, dbContext);
        //    var sql = string.Format(deviceSql.Length != 0 ? Config.DataProvider_GetSitesForDevice : Config.DataProvider_GetSites, deviceSql);

        //    var cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var site = EntityMapper.FillSiteFromReader(reader);
        //            list.Add(site);

        //        }
        //    }

        //    return list;

        //}

        //public IList<AtmSet> GetTerminalSets(UserProfile currentUser, IDbContext dbContext)
        //{
        //    IList<AtmSet> list = new List<AtmSet>();
        //    var sql = string.Format(currentUser.IsAdmin ? Config.DataProvider_GetTerminalSetsForAdmin : Config.DataProvider_GetTerminalSets, currentUser.UserId);

        //    var cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var atmSet = EntityMapper.FillAtmSetFromReader(reader);
        //            list.Add(atmSet);

        //        }
        //    }

        //    return list;

        //}

        //public String GetTerminalSetPermFilterQuery(UserProfile currentUser, IDbContext dbContext)
        //{
        //    String permSql = String.Format(Config.DataProvider_GetTerminalSetPermFilterQuery_1, 1, currentUser.UserId);

        //    StringBuilder sb = new StringBuilder();
        //    bool bAll = false;

        //    if (currentUser.IsAdmin)
        //    {
        //        bAll = true;
        //    }
        //    else
        //    {
        //        var cmd = new SqlCommand(permSql, dbContext.Connection);

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                if (reader.IsDBNull(0))
        //                {
        //                    bAll = true;
        //                    break;
        //                }

        //                if (sb.Length > 0)
        //                    sb.Append(" OR ");

        //                sb.Append(reader.GetString(0));
        //            }
        //        }
        //    }
        //    if (bAll)
        //        return String.Empty;

        //    return sb.ToString();
        //}



        ////IList<int> GetAllPermissionsForSpecUser(int userId, IDbContext dbContext)
        ////{
        ////    IList<int> list = new List<int>();

        ////    var sql = String.Format(Config.DataProvider_GetAllPermissionsForSpecUser, userId);

        ////    SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);
        ////    cmd.CommandType = CommandType.Text;


        ////    using (SqlDataReader reader = cmd.ExecuteReader())
        ////    {
        ////        while (reader != null && reader.Read())
        ////        {
        ////            object objPerm = reader.GetValue(0);
        ////            if (objPerm != null)
        ////            {
        ////                list.Add(Convert.ToInt32(objPerm));
        ////            }
        ////        }
        ////    }

        ////    return list;
        ////}


        //public IList<int> GetAllPermissionsForSpecUser(int userId, IDbContext dbContext)
        //{
        //    IList<int> list = new List<int>();

        //    var sql = String.Format(Config.DataProvider_GetAllPermissionsForSpecUser, userId);

        //    SqlCommand cmd = new SqlCommand(sql, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;


        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader != null && reader.Read())
        //        {
        //            object objPerm = reader.GetValue(0);
        //            if (objPerm != null)
        //            {
        //                list.Add(Convert.ToInt32(objPerm));
        //            }
        //        }
        //    }

        //    return list;
        //}

        //public List<string> GetAdditionalInformationData(IDbContext dbContext)
        //{
        //    var additionalInformationData = new List<string>();

        //    SqlCommand cmd = new SqlCommand(Config.AdditionalInformationDataQuery, dbContext.Connection);
        //    cmd.CommandType = CommandType.Text;

        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            DataTable dt = reader.GetSchemaTable();

        //            if (dt.Select("ColumnName='" + "FieldName" + "'").Length > 0)
        //                if (!reader.IsDBNull(reader.GetOrdinal("FieldName")))
        //                    additionalInformationData.Add(reader.GetString(reader.GetOrdinal("FieldName")));
        //        }
        //    }

        //    return additionalInformationData;
        //}

    }
}
