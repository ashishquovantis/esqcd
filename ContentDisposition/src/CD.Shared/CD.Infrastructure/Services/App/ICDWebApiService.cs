using CD.Infrastructure.Poco;
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
            ResponseFormat = WebMessageFormat.Json, UriTemplate = "user/{userName}?formatType={formatType}")]
        [OperationContract]
        string UserExists(string userName, string formatType);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/")]
        [OperationContract]
        IList<Template> GetTemplates();

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "content/templates/id/{templateId}")]
        [OperationContract]
        Template GetTemplate(string templateId);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/create")]
        [OperationContract]
        WebOperationResult CreateTemplate(Template template);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/id/{templateId}/modify")]
        [OperationContract]
        WebOperationResult UpdateTemplate(string templateId, Template template);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/id/{templateId}/delete")]
        [OperationContract]
        WebOperationResult DeleteTemplate(string templateId);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "content/templates/name/{templateName}")]
        [OperationContract]
        Template GetTemplateByName(string templateName);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/name/{templateName}/delete")]
        [OperationContract]
        WebOperationResult DeleteTemplateByName(string templateName);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/name/{templateName}/modify")]
        [OperationContract]
        WebOperationResult UpdateTemplateByName(string templateName, Template template);



    }
}
