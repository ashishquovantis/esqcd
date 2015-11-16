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
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates")]
        [OperationContract]
        IList<Template> GetTemplates();

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,UriTemplate = "content/templates/{id}")]
        [OperationContract]
        Template GetTemplate(string id);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/create")]
        [OperationContract]
        WebOperationResult CreateTemplate(Template template);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/{id}/modify")]
        [OperationContract]
        WebOperationResult UpdateTemplate(string id, Template template);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/{id}/delete")]
        [OperationContract]
        WebOperationResult DeleteTemplate(string id);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/templates/name/{templateName}")]
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


        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals")]
        [OperationContract]
        IList<Terminal> GetTerminals();


        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalSets")]
        [OperationContract]
        IList<Terminal> GetTerminalSets();


        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalFilters")]
        [OperationContract]
        IList<FilterDefs> GetTerminalFilters();

        #region Terminal

        ////Preview terminals by term set
        //[WebGet(BodyStyle = WebMessag eBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
        // ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalSets/{id}/terminals")]
        //[OperationContract]
        //IList<Terminal> GetAtmsPartByTerminalSetId();

        ////Preview terminals by term filter
        //[WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
        // ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalFilters/{id}/terminals")]
        //[OperationContract]
        //IList<FilterDefs> GetAtmsPartByTerminalFilterId();

        ////Preview terminals by filter condition
        //[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
        // ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalFilters/terminals")]
        //[OperationContract]
        //FilterDefs GetTerminalByFilterCondition(FilterDefs filter);

        //Modify Terminal Filter
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalFilters/{id}/modify")]
        [OperationContract]
        WebOperationResult UpdateTerminalFilter(string id, FilterDefs terminalFilter);

        //Delete Terminal Filter
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalFilters/{id}/delete")]
        [OperationContract]
        WebOperationResult DeleteTerminalFilter(string id);


        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json, UriTemplate = "asset/terminals/terminalFilters/create")]
        [OperationContract]
        WebOperationResult CreateTerminalFilter(FilterDefs terminalFilter);

        #endregion

        #region package
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/packages")]
        [OperationContract]
        IList<Package> GetPackages();

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/packages/{id}/Items")]
        [OperationContract]
        IList<Package> GetPackagesWithContent(string id);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/packages/create")]
        [OperationContract]
        WebOperationResult CreatePackage(Package package);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/packages/{id}/modify")]
        [OperationContract]
        WebOperationResult UpdatePackage(string id, Package package);

        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/packages/{id}/delete")]
        [OperationContract]
        WebOperationResult DeletePackage(string id);

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, UriTemplate = "content/packages/{id}/Items/{ItemId}")]
        [OperationContract]
        Package GetPackageItem(string id, string ItemId);

        #endregion

    }
}
