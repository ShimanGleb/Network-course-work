using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using WCFRESTService;
using System.ServiceModel;
using System.ServiceModel.Description;
using WCFRESTServiceContract;

namespace WCFRESTServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating WCF REST Service Host");
            var host = CreateServiceHost();            
            host.Open();
            Console.WriteLine("WCF REST Service Host is up and running");
            Console.WriteLine("Press any key to quit");
            Console.ReadLine();
            host.Close();
        }

        private static WebServiceHost CreateServiceHost()
        {
            //Create the host
            var serviceType = typeof(Service1);
            var serviceUri = new Uri("http://localhost:9117");         
            var host = new WebServiceHost(serviceType, serviceUri);
            
            //Create end point
            var serviceEndPoint = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            host.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });
            return host;
        }
    }
}
