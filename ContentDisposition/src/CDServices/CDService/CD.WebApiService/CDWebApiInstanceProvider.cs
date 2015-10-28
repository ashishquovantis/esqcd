using CD.Infrastructure.Services.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace CD.WebApiService
{
    internal class CDWebApiInstanceProvider : IInstanceProvider
    {
         private readonly IWebMessageHandler webMessageHandler;

         public CDWebApiInstanceProvider(IWebMessageHandler webMessageHandler)
        {
            this.webMessageHandler = webMessageHandler;
        }

        #region IInstanceProvider Methods

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return new CDWebApiService(webMessageHandler);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {

        }

        #endregion  IInstanceProvider Methods
    }
}
