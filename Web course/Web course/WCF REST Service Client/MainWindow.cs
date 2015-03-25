using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WCFRESTServiceContract;
using GameplayClasses;
using System.ServiceModel.Description;

namespace WCF_REST_Service_Client
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            List<Hero> heroes = new List<Hero>();
            var serviceUri = "http://localhost:9117";
            var serviceChannelFactory = new ChannelFactory<IService>(new WebHttpBinding(), serviceUri);
            serviceChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());            
            var serviceChannel = serviceChannelFactory.CreateChannel();            
            //var listFromService = serviceChannel.GetCollection();
            heroes= serviceChannel.GetHeroes();
            foreach (var hero in heroes)
            {
                comboBox1.Items.Add(hero.name);                                       
            }            
        }
    }
}
