using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Services.App
{
  [ServiceContract]
   public interface ICDService
    {
      [OperationContract]
      UserProfile GetUserProfile(string username, string password);

      //[OperationContract]
      //UserProfile GetUserProfile(string username);
    }
}
