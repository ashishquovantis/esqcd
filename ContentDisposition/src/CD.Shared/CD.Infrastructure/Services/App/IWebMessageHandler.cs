using CD.Infrastructure.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Services.App
{
    public interface IWebMessageHandler
    {
        string UserExists(string userName, string formatType);

        IList<Template> GetTemplates();
        Template GetTemplate(string templateId);
        Template GetTemplateByName(string templateName);
        IWebOperationResult CreateTemplate(Template template);
        IWebOperationResult UpdateTemplate(string templateId, Template template);
        IWebOperationResult UpdateTemplateByName(string templateName, Template template);
        IWebOperationResult DeleteTemplate(string templateId);
        IWebOperationResult DeleteTemplateByName(string templateName);
        IList<Terminal> GetTerminals();
        IList<Terminal> GetTerminalSets();
        IList<FilterDefs> GetTerminalFilters();
        WebOperationResult CreateTerminalFilter(FilterDefs terminalFilter);
        WebOperationResult DeleteTerminalFilter(string filterId);
        WebOperationResult UpdateTerminalFilter(string filterId, FilterDefs terminalFilter);
    }
}
