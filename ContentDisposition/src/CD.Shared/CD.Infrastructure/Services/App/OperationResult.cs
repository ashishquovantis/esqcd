using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using CD.Infrastructure.Poco.Enum;
using CD.Infrastructure.Services.App;


namespace CD.Infrastructure.Services.App
{
    [DataContract]
    public class OperationResult : IOperationResult
    {
        [DataMember]
        private bool result;

        [DataMember]
        public bool Result
        {
            get { return result; }
            set
            {
                result = value;
                if (result)
                {
                    ResultCode = ResultCodes.Ok;
                }
            }
        }

        [DataMember]
        public ResultCodes ResultCode { get; set; }

        [DataMember]
        public string MessageKey { get; set; }

        [DataMember]
        public IList<object> Data { get; set; }

        [DataMember]
        public string Message { get; set; }

        //[DataMember]
        public Exception Exception { get; set; }

        public override string ToString()
        {
            var dataValues = new StringBuilder();
            if (Data != null)
            {
                dataValues.Append(", Data: ");
                foreach (var o in Data)
                {
                    dataValues.Append(o);
                    dataValues.Append(", ");
                }
            }
            return Result.ToString() + dataValues;
        }
    }
}
