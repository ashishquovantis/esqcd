using CD.Business.Logic.CD;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.Business;
using CD.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;


namespace CD.Service
{
    public class CDBehavior : IServiceBehavior
    {
        private static readonly ICDManager cdManager;

        private static UserProfile user;

        static CDBehavior()
        {
            InitLogger();

            cdManager = new CDManager();

            user = cdManager.GetUserProfile(Config.WebMessageHandler_Username, Config.WebMessageHandler_Password);

        }


        private static void InitLogger()
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
                                         BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    if (endpointDispatcher.ContractName != "IMetadataExchange")
                    {
                        endpointDispatcher.DispatchRuntime.InstanceProvider = new CDInstanceProvider(cdManager);
                    }
                }

            }

        }
    }
}
