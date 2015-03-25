using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCFRESTServiceContract;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace WCF_REST_Service_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());                        
        }
    }
}
