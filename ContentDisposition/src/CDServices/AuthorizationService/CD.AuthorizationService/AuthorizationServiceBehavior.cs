using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using CD.TerminalSet.Security;

namespace CD.AuthorizationService
{
    public class AuthorizationServiceBehavior : IServiceBehavior
    {
        private static readonly TerminalSetPermissionManager terminalSetPermissionManager;

        static AuthorizationServiceBehavior()
        {
            terminalSetPermissionManager = TerminalSetPermissionManager.Instance;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, 
                                        Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }  

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    if (endpointDispatcher.ContractName != "IMetadataExchange")
                    {
                        endpointDispatcher.DispatchRuntime.InstanceProvider
                            = new AuthorizationServiceInstanceProvider(terminalSetPermissionManager);
                    }
                }
            }
        }
    }
}
