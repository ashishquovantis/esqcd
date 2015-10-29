using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Services.Business;
using CD.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.WebMessageHandler
{
    public class WebMessageHandler : IWebMessageHandler
    {
        private ICDManager cdManager;
        private UserProfile user;

        public WebMessageHandler(ICDManager cdManager)
        {
            this.cdManager = cdManager;
            user = cdManager.GetUserProfile(Config.WebMessageHandler_Username, Config.WebMessageHandler_Password);
        }

        public string UserExists(string userName, string formatType)
        {
            if (string.IsNullOrEmpty(formatType))
                formatType = "json";

            bool formatTypeJson = formatType.Equals("json", StringComparison.OrdinalIgnoreCase) ? true : false;


            if (!string.IsNullOrWhiteSpace(userName))
            {
                var result = cdManager.UserExists(userName, formatTypeJson);
                return Result(result, formatTypeJson);
            }
            else
            {
                return Result(new OperationResult() { Result = false, Message = "username can't be blank." },
                    formatTypeJson);
            }

        }

        private string Result(IOperationResult result, bool formatTypeJson)
        {
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            if (formatTypeJson)
                return jsonResult;
            else
                return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult).ToString();
        }
    }
}
