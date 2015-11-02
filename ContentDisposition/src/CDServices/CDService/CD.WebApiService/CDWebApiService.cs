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
    }
}
