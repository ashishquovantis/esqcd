using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using ESQ.Infrastructure.Services.App;
using ESQ.RemoteServiceProxy;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Util;
using CD.AuthorizationServiceLocalProxy;


namespace CD.AuthorizationServiceProxyProvider
{
    public class AuthorizationServiceProxyProvider : IAuthorizationServiceProxyProvider
    {
        public static AuthorizationServiceProxyProvider instance = new AuthorizationServiceProxyProvider();

        private readonly IRemoteServiceProxyProvider remoteServiceProxyProvider;
        static AuthorizationServiceProxyProvider() { }


        public static AuthorizationServiceProxyProvider Instance
        {
            get { return instance; }
        }

        private AuthorizationServiceProxyProvider()
        {
            remoteServiceProxyProvider = RemoteServiceProxyProvider.Instance;
        }

        private bool RemoteProxy
        {
            get { return Config.AuthorizationServiceRemoteProxy; }
        }

        public IServiceProxy<IAuthorizationService> GetService()
        {
            if (RemoteProxy)
            {
                return remoteServiceProxyProvider.GetRemoteService<IAuthorizationService>();
            }

            return new AuthorizationServiceLocalProxy.AuthorizationServiceLocalProxy();
        }
    }
}
