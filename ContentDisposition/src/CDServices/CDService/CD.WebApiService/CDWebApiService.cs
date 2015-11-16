using CD.Business.Logic.CD;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.WebApiService
{
    public class CDWebApiService : ICDWebApiService
    {
        private readonly IWebMessageHandler webMessageHandler;


        public CDWebApiService()
        {

            // Logger.Log.InfoFormat("Initializing HelpDeskWebApiService default constructor ");
            this.webMessageHandler = new CD.WebMessageHandler.WebMessageHandler(new CDManager());
        }

        public CDWebApiService(IWebMessageHandler webMessageHandler)
        {
            //  Logger.Log.InfoFormat("Initializing HelpDeskWebApiService parameter constructor ");
            this.webMessageHandler = webMessageHandler;
        }

        public string UserExists(string userName, string formatType)
        {
            return webMessageHandler.UserExists(userName, "");
        }

        public WebOperationResult CreateTemplate(Template template)
        {
            return (WebOperationResult)webMessageHandler.CreateTemplate(template);
        }

        public WebOperationResult DeleteTemplate(string templateId)
        {
            return (WebOperationResult)webMessageHandler.DeleteTemplate(templateId);
        }

        public WebOperationResult UpdateTemplate(string templateId, Template template)
        {
            return (WebOperationResult)webMessageHandler.UpdateTemplate(templateId, template);
        }

        public IList<Template> GetTemplates()
        {
            return webMessageHandler.GetTemplates();
        }

        public WebOperationResult DeleteTemplateByName(string templateName)
        {
            return (WebOperationResult)webMessageHandler.DeleteTemplateByName(templateName);
        }

        public Template GetTemplate(string templateId)
        {
            return webMessageHandler.GetTemplate(templateId);
        }

        public Template GetTemplateByName(string templateName)
        {
            return webMessageHandler.GetTemplateByName(templateName);
        }

        public WebOperationResult UpdateTemplateByName(string templateName, Template template)
        {
            return (WebOperationResult)webMessageHandler.UpdateTemplateByName(templateName, template);
        }

        public IList<FilterDefs> GetTerminalFilters()
        {
            return webMessageHandler.GetTerminalFilters();
        }

        public IList<Terminal> GetTerminalSets()
        {
            return webMessageHandler.GetTerminalSets();
        }

        public IList<Terminal> GetTerminals()
        {
            return webMessageHandler.GetTerminals();
        }

        public WebOperationResult CreateTerminalFilter(FilterDefs terminalFilter)
        {
            return (WebOperationResult)webMessageHandler.CreateTerminalFilter(terminalFilter);
        }

        public WebOperationResult DeleteTerminalFilter(string filterId)
        {
            return (WebOperationResult)webMessageHandler.DeleteTerminalFilter(filterId);
        }

        public WebOperationResult UpdateTerminalFilter(string filterId, FilterDefs terminalFilter)
        {
           return (WebOperationResult)webMessageHandler.UpdateTerminalFilter(filterId, terminalFilter);
        }

        //private string Result(IWebOperationResult result, bool formatTypeJson)
        //{
        //    string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
        //    if (formatTypeJson)
        //        return jsonResult;
        //    else
        //        return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult).ToString();
        //}

        #region package
        public WebOperationResult CreatePackage(Package package)
        {
            return (WebOperationResult)webMessageHandler.CreatePackage(package);
        }

        public WebOperationResult DeletePackage(string id)
        {
            return (WebOperationResult)webMessageHandler.DeletePackage(id);
        }

        public Package GetPackageItem(string id, string ItemId)
        {
            return webMessageHandler.GetPackageItem(id, ItemId);
        }

        public IList<Package> GetPackages()
        {
            return webMessageHandler.GetPackages();
        }

        public IList<Package> GetPackagesWithContent(string id)
        {
            return webMessageHandler.GetPackagesWithContent(id);
        }

        public WebOperationResult UpdatePackage(string id, Package package)
        {
            return (WebOperationResult)webMessageHandler.UpdatePackage(id, package);
        }

#endregion
    }
}
