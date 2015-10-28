using CD.Business.Logic.CD;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD.Service
{
   public partial  class CDService: ICDService, IAuthorizationService
    {
       private readonly ICDManager cdManager;

       public CDService()
       {
          cdManager = new CDManager();
       }


       // <summary>
        /// For remote usage
        /// </summary>
        /// <param name="CDManager"></param>
       public CDService(ICDManager cdManager)
       {
           this.cdManager = cdManager;
       }

       #region public

       public UserProfile GetUserProfile(string username, string password)
       {
           return cdManager.GetUserProfile(username, password);
       }

       #endregion


    }
}
