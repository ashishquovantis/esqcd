using CD.Infrastructure.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Infrastructure.Services.App;

namespace CD.Infrastructure.Services.Business
{
    public interface ICDManager
    {
        UserProfile GetUserProfile(string username, string password);

        OperationResult UserExists(string userName, bool formatType);

        byte[] CreateDefaultPermissionKey();

        byte[] CreatePermissionKey(List<AtmSet> atmSets);

        byte[] CreateZeroPermissionKey();

        byte[] GetTerminalSetBitmapForAtm(long? atmId);
        
        IList<Template> GetTemplates();
        Template GetTemplate(string templateId);
        Template GetTemplateByName(string templateName);
        IOperationResult CreateTemplate(Template template);
        IOperationResult UpdateTemplate(string templateId, Template template);
        IOperationResult UpdateTemplateByName(string templateName, Template template);
        IOperationResult DeleteTemplate(string templateId);
        IOperationResult DeleteTemplateByName(string templateName);

    }
}
