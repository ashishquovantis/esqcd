using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using CD.WebApiService;
using CD.Infrastructure.Util;
using System.IO;
using ESQ.CrossCutting.Instrumentation;
using CD.Service;

namespace CD.Service.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(CDService));
            host.Open();

            var hostWeb = new ServiceHost(typeof(CDWebApiService));
            hostWeb.Open();

            //string logConfigFile = AppDomain.CurrentDomain.BaseDirectory + Config.Log4NetRelativePath;
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(logConfigFile));
            //Logger.Log.Info("Self Host HelpDesk service started");

            // The service can now be accessed.
            Console.WriteLine("The services are ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
