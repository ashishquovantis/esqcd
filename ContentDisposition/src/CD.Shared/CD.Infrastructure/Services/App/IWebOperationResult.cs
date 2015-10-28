using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CD.Infrastructure.Services.App
{
    public interface IWebOperationResult
    {
        bool Result { get; set; }
        string ResultText { get; set; }
        Int32 ResultCode { get; set; }
        object ResultData { get; set; }
        HttpStatusCode HttpStatusCode { get; set; }
    }
}
