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
            Console.WriteLine("Creating player list file");
            string filename = "PendingPlayers.txt";
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, false);            
            writer.Close();

            Console.WriteLine("Creating player states file");
            filename = "Player_states.txt";
            writer = new System.IO.StreamWriter(filename, false);
            writer.Close();

            Console.WriteLine("Creating player activity file");
            filename = "Player_activities.txt";
            writer = new System.IO.StreamWriter(filename, false);
            writer.Close();

            System.Threading.AutoResetEvent autoEvent = new System.Threading.AutoResetEvent(false);           
            System.Threading.TimerCallback timerCallBack = CheckActivities;
            System.Threading.Timer activityChecker = new System.Threading.Timer(timerCallBack, autoEvent, 1000, 1000);

            Console.WriteLine("Creating Service Host");
            var host = CreateServiceHost();            
            host.Open();            

            Console.WriteLine("Service Host is up and running");
            Console.WriteLine("Press any key to quit");
            Console.ReadLine();
            host.Close();
        }

        static void CheckActivities(Object stateInfo)
        {
            string fileName = "Player_activities.txt";
            string[] strings = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                int remainigTime =Convert.ToInt32(playerData[1]);
                remainigTime--;
                if (remainigTime == 0)
                {
                    strings[i] = "";
                }
                else
                {
                    strings[i] = playerData[0] + '=' + remainigTime;
                }
            }
            System.IO.StreamWriter stateRewriter = new System.IO.StreamWriter(fileName);
            foreach (string line in strings)
            {
                if (line != "")
                {
                    stateRewriter.Write(line + "\r\n");
                }
            }
            stateRewriter.Close();
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
