using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.Business;
using CD.Infrastructure.Services.Persistance;
using ESQ.Persistance.AdoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESQ.Infrastructure.Services;
using CD.Authorization.Authorization;
using CD.Persistance.DataProvider;
using CD.Infrastructure.Services.App;
using CD.Infrastructure.Poco.Enum;
using System.Configuration;


namespace CD.Business.Logic.CD
{
    public class CDManager : ICDManager
    {
        private ICDDataProvider cdDataProvider;

        public CDManager()
            : this(new CDDataProvider())
        {
        }

        private CDManager(ICDDataProvider cdDataProvider)
        {
            this.cdDataProvider = cdDataProvider;
        }

        public UserProfile GetUserProfile(string username, string password)
        {
            UserProfile userProfile = null;

            using (var dbContext = new DbContext())
            {
                userProfile = cdDataProvider.AuthenticateUser(username, dbContext);
            }
            if (userProfile != null)
            {
                   userProfile.PermissionKey = AuthorizationManager.Instance.GetTerminalSetBitmap(userProfile);
            }

            return userProfile;
        }


        public OperationResult UserExists(string userName, bool formatType)
        {

            UserProfile userProfile = null;
            using (var dbContext = new DbContext())
            {
                userProfile = cdDataProvider.AuthenticateUser(userName, dbContext);
            }

            if (userProfile != null)
            {
                //  userProfile.PermissionKey = AuthorizationManager.Instance.GetTerminalSetBitmap(userProfile);
                return new OperationResult() { ResultCode = ResultCodes.Ok, Result=true, Message = "Success" };
            }

            return new OperationResult() { ResultCode = ResultCodes.Error, Message = "faild" };
        }


        public byte[] CreateDefaultPermissionKey()
        {
            return AuthorizationManager.Instance.CreateDefaultPermissionKey();
        }

        public byte[] CreatePermissionKey(List<AtmSet> atmSets)
        {
            return AuthorizationManager.Instance.CreatePermissionKey(atmSets);
        }

        public byte[] CreateZeroPermissionKey()
        {
            return AuthorizationManager.Instance.CreateZeroPermissionKey();
        }

        public byte[] GetTerminalSetBitmapForAtm(long? atmId)
        {
            return AuthorizationManager.Instance.GetTerminalSetBitmapForAtm(atmId);
        }

    }
}
