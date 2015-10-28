using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CD.Infrastructure.Poco.Enum;

namespace CD.Infrastructure.Services.App
{
    public interface IOperationResult
    {
        bool Result { get; set; }
        ResultCodes ResultCode { get; set; } 
        string MessageKey { get; set; }
        string Message { get; set; }
        IList<object> Data { get; set; }
        Exception Exception { get; set; }
     }
}
