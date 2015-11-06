using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Services.Business;
using CD.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.WebMessageHandler
{
    public class WebMessageHandler : IWebMessageHandler
    {
        private ICDManager cdManager;
        private UserProfile user;

        public WebMessageHandler(ICDManager cdManager)
        {
            this.cdManager = cdManager;
            user = cdManager.GetUserProfile(Config.WebMessageHandler_Username, Config.WebMessageHandler_Password);
        }

        public string UserExists(string userName, string formatType)
        {
            if (string.IsNullOrEmpty(formatType))
                formatType = "json";

            bool formatTypeJson = formatType.Equals("json", StringComparison.OrdinalIgnoreCase) ? true : false;


            if (!string.IsNullOrWhiteSpace(userName))
            {
                var result = cdManager.UserExists(userName, formatTypeJson);
                return Result(result, formatTypeJson);
            }
            else
            {
                return Result(new OperationResult() { Result = false, Message = "username can't be blank." },
                    formatTypeJson);
            }

        }

        private string Result(IOperationResult result, bool formatTypeJson)
        {
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            if (formatTypeJson)
                return jsonResult;
            else
                return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult).ToString();
        }

        public IWebOperationResult CreateTemplate(Template template)
        {
            template.UserId = user.UserId;
            var result = cdManager.CreateTemplate(template);

            return new WebOperationResult(result.Result, result.Result
                                                                   ? "Template created successfully"
                                                                   : result.Message,"", result.ResultCode);
        }

        public IWebOperationResult DeleteTemplate(string templateId)
        {
            var result = cdManager.DeleteTemplate(templateId);
            return new WebOperationResult(result.Result, result.Result
                                                                   ? "Template removed successfully"
                                                                   : result.Message, "", result.ResultCode);
        }

        public IWebOperationResult UpdateTemplate(string templateId, Template template)
        {
                var result = cdManager.UpdateTemplate(templateId, template);
                return new WebOperationResult(result.Result, result.Result
                                                                          ? "Template updated successfully"
                                                                          : result.Message, result.Data, result.ResultCode);
        }

        public IList<Template> GetTemplates()
        {
            return cdManager.GetTemplates();
        }

        public IWebOperationResult DeleteTemplateByName(string templateName)
        {
            var result = cdManager.DeleteTemplateByName(templateName);
            return new WebOperationResult(result.Result, result.Result
                                                                   ? "Template removed successfully"
                                                                   : result.Message, "", result.ResultCode);
        }

        public Template GetTemplate(string templateId)
        {
            return cdManager.GetTemplate(templateId);
        }

        public Template GetTemplateByName(string templateName)
        {
            return cdManager.GetTemplateByName(templateName);
        }

        public IWebOperationResult UpdateTemplateByName(string templateName, Template template)
        {
            var result = cdManager.UpdateTemplateByName(templateName, template);

            return new WebOperationResult(result.Result, result.Result
                                                                      ? "Template updated successfully"
                                                                      : result.Message, result.Data, result.ResultCode);
        }

        public IList<FilterDefs> GetTerminalFilters()
        {
            return cdManager.GetTerminalFilters();
        }

        public IList<Terminal> GetTerminalSets()
        {
            return cdManager.GetTerminalSets();
        }

        public IList<Terminal> GetTerminals()
        {
            return cdManager.GetTerminals();
        }

        public WebOperationResult CreateTerminalFilter(FilterDefs terminalFilter)
        {
            terminalFilter.CreatedBy= user.UserId;

            var result= cdManager.CreateTerminalFilter(terminalFilter);
            return new WebOperationResult(result.Result, result.Result
                                                              ? "Template created successfully"
                                                              : result.Message, "", result.ResultCode);

        }

        public WebOperationResult DeleteTerminalFilter(string filterId)
        {
            var result = cdManager.DeleteTerminalFilter(filterId);
            return new WebOperationResult(result.Result, result.Result
                                                                   ? "Template removed successfully"
                                                                   : result.Message, "", result.ResultCode);
        }

        public WebOperationResult UpdateTerminalFilter(string filterId, FilterDefs terminalFilter)
        {
            terminalFilter.CreatedBy = user.UserId;
            var result = cdManager.UpdateTerminalFilter(filterId, terminalFilter);

            return new WebOperationResult(result.Result, result.Result
                                                                      ? "Template updated successfully"
                                                                      : result.Message, result.Data, result.ResultCode);
        }
    }
}
