using CD.Business.Logic.CD;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace CD.WebApiService
{
    public class CDWebApiBehavior : IServiceBehavior
    {
         private static readonly IWebMessageHandler webMessageHandler;

         static CDWebApiBehavior()
        {
            InitLogger();

            webMessageHandler = new WebMessageHandler.WebMessageHandler(new CDManager());
        }

        private static void InitLogger()
        {
           // string logConfigFile = AppDomain.CurrentDomain.BaseDirectory + Config.Log4NetRelativePath;
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(logConfigFile));
            //Logger.Log.Info("HelpDesk WebApi service started");
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase){}

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
                                         BindingParameterCollection bindingParameters){}

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    if (endpointDispatcher.ContractName != "IMetadataExchange")
                    {
                       endpointDispatcher.DispatchRuntime.InstanceProvider = new CDWebApiInstanceProvider(webMessageHandler);
                    }
                }
                
            }
        }
    }
}
