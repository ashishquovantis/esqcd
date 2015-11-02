using CD.Infrastructure.Poco;
using ESQ.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Services.Persistance
{
    public interface ICDDataProvider
    {
        UserProfile AuthenticateUser(string userName, IDbContext dbContext);

        IList<Template> GetTemplates(IDbContext dbContext);
        Template GetTemplate(string templateId, IDbContext dbContext);
        Template GetTemplateByName(string templateName, IDbContext dbContext);
        bool CreateTemplate(Template template, ITransactionContext transactionContext);
        bool UpdateTemplate(string templateId, Template template, ITransactionContext transactionContext);
        bool DeleteTemplate(string templateId, ITransactionContext transactionContext);
        bool UpdateTemplateByName(string templateName, Template template, ITransactionContext transactionContext);
        bool DeleteTemplateByName(string templateName, ITransactionContext transactionContext);
    }
}
