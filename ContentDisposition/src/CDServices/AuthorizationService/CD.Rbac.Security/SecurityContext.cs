using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESQ.CrossCutting.Instrumentation;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using CD.Infrastructure.Services;
using ESQ.Infrastructure.Util;
using RBAC;
using CD.Infrastructure.Util;
using ESQ.Infrastructure.Services.Security;
using CD.Rbac.Security;

namespace CD.Rbac.Security
{
    internal class AppInfo : IApp
    {
        public string AppName { get { return Config.ApplicationNameForRBAC; } }
    } 

    [ExceptionAspect(AttributePriority = 2)]
    public class SecurityContext : ISecurityContext
    {

        public IList<ESQ.Infrastructure.Poco.Security.AuthenticatedApplications> ApplicationList(string userName, string ticket)
        {
            throw new NotImplementedException();
        }

        public ESQ.Infrastructure.Poco.Security.UserInfo CurrentUser
        {
            get { throw new NotImplementedException(); }
        }

        public IList Filter<T>(string target, string command, IList source) where T : ESQ.Infrastructure.Poco.BasePoco
        {
            throw new NotImplementedException();
        }

        public bool IsCommandAllowed<T>(string target, string command, T source) where T : ESQ.Infrastructure.Poco.BasePoco
        {
            throw new NotImplementedException();
        }

        public bool IsCommandAllowed<T>(string target, string command, IList source) where T : ESQ.Infrastructure.Poco.BasePoco
        {
            throw new NotImplementedException();
        }

        public bool IsCommandAllowed(string target, string command)
        {
            throw new NotImplementedException();
        }

        public ESQ.Infrastructure.Services.DataContracts.IOperationResult UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUserInfo(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
