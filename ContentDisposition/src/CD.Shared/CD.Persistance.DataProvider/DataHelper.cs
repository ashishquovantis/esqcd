using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ESQ.Infrastructure.Util;
using System.Data;

namespace CD.Persistance.DataProvider
{
    #region Class DataHelper

    /// <summary>
    /// Summary description for DataHelper
    /// </summary>
    public class DataHelper
    {
        #region Constants
        #endregion Constants

        #region Static fields
        #endregion Static fields

        #region Private fields
        #endregion Private fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DataHelper class.
        /// </summary>
        public DataHelper()
        {
        }

        #endregion Constructors

        #region Destructors
        #endregion Destructors

        #region Static methods

        public static T GetValue<T>(IDataRecord record, string columnName, T defaultValue)
        {
            if (record[columnName] == null || record[columnName] == DBNull.Value)
            {
                return defaultValue;
            }
            return (T)record[columnName];
        }

        public static object SetValue(object value)
        {

            if (value == null || value.Equals(TypeDefaultValue.GetTypeDefaultValue(value.GetType())))
            {
                return DBNull.Value;
            }
            return value;

        }

        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }

        /*public static object ConvertValue(object value, SqlDbType type)
        {
            if (value.GetType() == typeof(string))
            {
                if (type == SqlDbType.BigInt)
                {
                    return Convert.ToInt64(value);
                }
                if (type == SqlDbType.Int)
                {
                    return Convert.ToInt32(value);
                }
                if (type == SqlDbType.SmallInt)
                {
                    return Convert.ToInt16(value);
                }
                if (type == SqlDbType.DateTime
                    || type == SqlDbType.Date
                    || type == SqlDbType.DateTime2
                    || type == SqlDbType.SmallDateTime)
                {
                    return DateTime.Parse((string)value);
                }
                if (type == SqlDbType.Bit)
                {
                    return Convert.ToBoolean(value);
                }
                if (type == SqlDbType.Float)
                {
                    return Convert.ToDouble(value);
                }
                if (type == SqlDbType.Money
                    || type == SqlDbType.Decimal
                    || type == SqlDbType.SmallMoney)
                {
                    return Convert.ToDecimal(value);
                }
                if (type == SqlDbType.TinyInt)
                {
                    return Convert.ToByte(value);
                }
                if (type == SqlDbType.UniqueIdentifier)
                {
                    return Guid.Parse((string)value);
                }
            }
            return value;
        }*/

        #endregion Static methods

        #region Properties
        #endregion Properties

        #region Abstract methods
        #endregion Abstract methods

        #region Virtual methods
        #endregion Virtual methods

        #region Override methods
        #endregion Override methods

        #region Non-virtual methods
        #endregion Non-virtual methods

        #region Delegates
        #endregion Delegates

        #region Events
        #endregion Events

        #region Inner classes
        #endregion Inner classes
    }

    #endregion Class DataHelper
}
