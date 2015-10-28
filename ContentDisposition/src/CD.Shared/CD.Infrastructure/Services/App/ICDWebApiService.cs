using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Services.App
{
    [ServiceContract]
    public interface ICDWebApiService
    {
        //[WebInvoke(Method = "POST",
        //  UriTemplate = "incident/{incidentId}/operation/{operationName}?formatType={formatType}")]
        //[OperationContract]

        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,  UriTemplate = "user/{userName}?formatType={formatType}")]
        [OperationContract]
        string UserExists(string userName,string formatType);
    }
}
