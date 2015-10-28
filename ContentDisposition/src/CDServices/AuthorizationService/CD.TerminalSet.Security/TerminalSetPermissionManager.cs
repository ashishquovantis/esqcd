using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ESQ.Persistance.AdoNet;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Services;
using CD.Persistance.DataProvider;
using ESQ.Infrastructure.Util;
using ESQ.Infrastructure.Services;
using ESQ.CrossCutting.Instrumentation;



namespace CD.TerminalSet.Security
{
    [Serializable]
    public class TerminalSetPermissionManager
    {
        private static TerminalSetPermissionManager instance = new TerminalSetPermissionManager();
        private IDataProvider dataProvider;

        #region Singleton

        static TerminalSetPermissionManager()
        {
        }

        private TerminalSetPermissionManager()
        {
            dataProvider = new DataProvider();
        }

        public static TerminalSetPermissionManager Instance { get { return instance; } }

        #endregion Singleton

    }
}
