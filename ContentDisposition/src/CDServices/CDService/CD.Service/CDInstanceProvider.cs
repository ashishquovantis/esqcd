using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Services.Business;


namespace CD.Service
{
    internal class CDInstanceProvider : IInstanceProvider
    {
        private readonly ICDManager cdManager;

        public CDInstanceProvider(ICDManager cdManager)
        {
            this.cdManager = cdManager;
        }

        #region IInstanceProvider Methods

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(System.ServiceModel.InstanceContext instanceContext)
        {
            return new CDService(cdManager);
        }

        public void ReleaseInstance(System.ServiceModel.InstanceContext instanceContext, object instance)
        {

        }

        #endregion  IInstanceProvider Methods
    }
}
