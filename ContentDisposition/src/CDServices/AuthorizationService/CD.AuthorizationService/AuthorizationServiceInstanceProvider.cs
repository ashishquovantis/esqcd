using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
//using CD.Infrastructure.Services.Business;
using CD.TerminalSet.Security;

namespace CD.AuthorizationService
{
    class AuthorizationServiceInstanceProvider : IInstanceProvider
    {

        private readonly TerminalSetPermissionManager terminalSetPermissionManager;


        public AuthorizationServiceInstanceProvider(TerminalSetPermissionManager terminalSetPermissionManager)
        {
            this.terminalSetPermissionManager = terminalSetPermissionManager;
        }

        #region IInstanceProvider Methods

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return new AuthorizationService(terminalSetPermissionManager);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {

        }
        #endregion  IInstanceProvider Methods
    }
}
