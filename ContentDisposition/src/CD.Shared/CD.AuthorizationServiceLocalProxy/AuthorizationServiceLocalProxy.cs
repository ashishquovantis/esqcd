using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ESQ.Infrastructure.Services.App;
using CD.Infrastructure.Services.App;



namespace CD.AuthorizationServiceLocalProxy
{
    public class AuthorizationServiceLocalProxy : BaseLocalProxy<IAuthorizationService>
    {
        private IAuthorizationService serviceContract;

        public AuthorizationServiceLocalProxy()
        {
            serviceContract = (IAuthorizationService)Activator.CreateInstance(typeof(AuthorizationService.AuthorizationService));
        }

        public override IAuthorizationService Service
        {
            get { return serviceContract; }
        }

        public override CommunicationState CommunicationState { get { return CommunicationState.Opened; } }
    }
}
