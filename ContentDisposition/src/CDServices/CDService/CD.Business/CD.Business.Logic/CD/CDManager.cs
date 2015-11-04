using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.Business;
using CD.Infrastructure.Services.Persistance;
using ESQ.Persistance.AdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESQ.Infrastructure.Services;
using CD.Authorization.Authorization;
using CD.Persistance.DataProvider;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Poco.Enum;
using System.Configuration;
using CD.Infrastructure.Util;


namespace CD.Business.Logic.CD
{
    public class CDManager : ICDManager
    {
        private ICDDataProvider cdDataProvider;

        public CDManager()
            : this(new CDDataProvider())
        {
        }

        private CDManager(ICDDataProvider cdDataProvider)
        {
            this.cdDataProvider = cdDataProvider;
        }

        public UserProfile GetUserProfile(string username, string password)
        {
            UserProfile userProfile = null;

            using (var dbContext = new DbContext())
            {
                userProfile = cdDataProvider.AuthenticateUser(username, dbContext);
            }
            if (userProfile != null)
            {
                userProfile.PermissionKey = AuthorizationManager.Instance.GetTerminalSetBitmap(userProfile);
            }

            return userProfile;
        }

        public OperationResult UserExists(string userName, bool formatType)
        {

            UserProfile userProfile = null;
            using (var dbContext = new DbContext())
            {
                userProfile = cdDataProvider.AuthenticateUser(userName, dbContext);
            }

            if (userProfile != null)
            {
                  userProfile.PermissionKey = AuthorizationManager.Instance.GetTerminalSetBitmap(userProfile);
                return new OperationResult() { ResultCode = ResultCodes.Ok, Result = true, Message = "Success" };
            }

            return new OperationResult() { ResultCode = ResultCodes.Error, Message = "faild" };
        }

        public byte[] CreateDefaultPermissionKey()
        {
            return AuthorizationManager.Instance.CreateDefaultPermissionKey();
        }

        public byte[] CreatePermissionKey(List<AtmSet> atmSets)
        {
            return AuthorizationManager.Instance.CreatePermissionKey(atmSets);
        }

        public byte[] CreateZeroPermissionKey()
        {
            return AuthorizationManager.Instance.CreateZeroPermissionKey();
        }

        public byte[] GetTerminalSetBitmapForAtm(long? atmId)
        {
            return AuthorizationManager.Instance.GetTerminalSetBitmapForAtm(atmId);
        }

        public IOperationResult CreateTemplate(Template template)
        {
            if (GetTemplate(template.TemplateId.ToString()) != null)
                return new OperationResult() { Result = false, Message = "template id already exist!", Data = new List<object> { template.TemplateId } };

            if (GetTemplate(template.Name) != null)
                return new OperationResult() { Result = false, Message = "template name already exist!", Data = new List<object> { template.TemplateId } };

            // Get param

            template.Params = GetParam(template);

            bool result;

            using (var transactionContext = new TransactionContext())
            {
                result = cdDataProvider.CreateTemplate(template, transactionContext);

                if (result)
                {
                    transactionContext.Commit();
                }
            }

            return new OperationResult() { Result = result, Data = new List<object> { template.TemplateId } };
        }

        public IOperationResult DeleteTemplate(string templateId)
        {
            if (GetTemplate(templateId) == null)
                return new OperationResult() { Result = false, Message = "template id does not exist!", Data = new List<object> { templateId } };

            bool result;

            using (var transactionContext = new TransactionContext())
            {
                // result = cdDataProvider.DeleteTemplate(template, transactionContext);
                result = cdDataProvider.DeleteTemplate(templateId, transactionContext);

                if (result)
                {
                    transactionContext.Commit();
                }
            }

            return new OperationResult() { Result = result, Data = new List<object> { templateId } };
        }

        public IOperationResult UpdateTemplate(string templateId, Template template)
        {
            if (GetTemplate(templateId) == null)
                return new OperationResult() { Result = false, Message="template id does not exist!", Data = new List<object> { template.TemplateId } };

            template.Params = GetParam(template);

            bool result;

            using (var transactionContext = new TransactionContext())
            {
                result = cdDataProvider.UpdateTemplate(templateId, template, transactionContext);

                if (result)
                {
                    transactionContext.Commit();
                }
            }

            return new OperationResult() { Result = result, Data = new List<object> { template.TemplateId } };
        }

        public Template GetTemplate(string templateId)
        {
            using (var dbContext = new DbContext())
            {
                return cdDataProvider.GetTemplate(templateId, dbContext);

            }
        }

        public IList<Template> GetTemplates()
        {
            using (var dbContext = new DbContext())
            {
                return cdDataProvider.GetTemplates(dbContext);
            }
        }


        public IOperationResult DeleteTemplateByName(string templateName)
        {
            // var template=null;//GetTemplateByName(templateName);

            if (GetTemplateByName(templateName) == null)
                return new OperationResult() { Result = false, Message = "template Name does not exist!", Data = new List<object> { templateName } };

            bool result;

            using (var transactionContext = new TransactionContext())
            {
                // result = cdDataProvider.DeleteTemplateByName(template, transactionContext);
                result = cdDataProvider.DeleteTemplateByName(templateName, transactionContext);

                if (result)
                {
                    transactionContext.Commit();
                }
            }

            return new OperationResult() { Result = result, Data = new List<object> { templateName } };
        }

        public Template GetTemplateByName(string templateName)
        {
             using (var dbContext = new DbContext())
            {
                return cdDataProvider.GetTemplateByName(templateName, dbContext);

            }
        }

        public IOperationResult UpdateTemplateByName(string templateName, Template template)
        {
            if (GetTemplateByName(templateName) == null)
                return new OperationResult() { Result = false, Message = "template Name does not exist!", Data = new List<object> { template.Name} };

            template.Params = GetParam(template);
            bool result;

            using (var transactionContext = new TransactionContext())
            {
                result = cdDataProvider.UpdateTemplateByName(templateName, template, transactionContext);

                if (result)
                {
                    transactionContext.Commit();
                }
            }

            return new OperationResult() { Result = result, Data = new List<object> { template.Name } };
        }

        private string GetParam(Template template)
        {
            bool isOverRide = template.IsOverride ? true : false;

            string atmPath = template.TemplatePath;
            atmPath = (atmPath.EndsWith("/") || atmPath.EndsWith("\\")) && (!atmPath.EndsWith(":\\") && !atmPath.EndsWith(":/"))
                ? atmPath.Substring(0, atmPath.Length - 1).Trim() : atmPath;

            string strParams = string.Empty;
            string strPutFileParts = "<cmd type=" + '"' + "put-file-part" + '"'
                 + " name=" + '"' + "%" + Config.ATMFileTransferSourceURLParamName + "%"
                 + '"' + " ipaddress=" + '"' + Config.FileUploadIPAddressSubstitutionParamString + '"'
                 + " port=" + '"' + Config.ATMFileTransferPortNumber + '"' + " param1=" + '"' + atmPath
                 + '"' + " param2=" + '"' + isOverRide + '"'
                 + " timeout=" + '"' + Config.ATMFileTransferTimeout + '"' + " filepartsize=" + '"' + template.FilePartSize + '"' + "/>";

            string strPutFile = "<cmd type=" + '"' + "put-file" + '"'
               + " name=" + '"' + "%" + Config.ATMFileTransferSourceURLParamName + "%"
               + '"' + " ipaddress=" + '"' + Config.FileUploadIPAddressSubstitutionParamString + '"'
               + " port=" + '"' + Config.ATMFileTransferPortNumber + '"' + " param1=" + '"' + atmPath
               + '"' + " param2=" + '"' + isOverRide + '"'
               + " timeout=" + '"' + Config.ATMFileTransferTimeout + '"' + "/>";

            strParams = template.IsOverride ? strPutFileParts : strPutFile;

            return strParams;
        }

    }
}
