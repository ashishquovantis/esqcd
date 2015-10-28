using CD.Business.Logic.CD;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.WebApiService
{
    public class CDWebApiService : ICDWebApiService
    {
        private readonly IWebMessageHandler webMessageHandler;


        public CDWebApiService()
        {

            // Logger.Log.InfoFormat("Initializing HelpDeskWebApiService default constructor ");
            this.webMessageHandler = new CD.WebMessageHandler.WebMessageHandler(new CDManager());
        }

        public CDWebApiService(IWebMessageHandler webMessageHandler)
        {
            //  Logger.Log.InfoFormat("Initializing HelpDeskWebApiService parameter constructor ");
            this.webMessageHandler = webMessageHandler;
        }

        public string UserExists(string userName, string formatType)
        {
            return webMessageHandler.UserExists(userName, "");
        }
    }
}
