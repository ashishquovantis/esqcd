using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESQ.Infrastructure.Services.App;
using CD.Infrastructure.Services.App;

namespace CD.Infrastructure.Services.App
{
    public interface IAuthorizationServiceProxyProvider
    {
        /// <summary>
        /// Gets the service by specifying IAuthorizationService type.
        /// </summary>
        /// <typeparam name="IServiceContract">The type of the contract.</typeparam>
        /// <returns></returns>
       // IServiceProxy<IAuthorizationService> GetService();
    }
}
