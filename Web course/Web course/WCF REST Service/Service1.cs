using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using WCFRESTServiceContract;
using GameplayClasses;

namespace WCFRESTService
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class Service1 : IService
    {
        // TODO: Implement the collection resource that will contain the Hero instances        

        public List<Hero> GetHeroes()
        {
            List<Hero> heroes=new List<Hero>();
            string fileName = "Heroes.txt";
            try
            {
                string[] strings = System.IO.File.ReadAllLines(fileName);
                foreach (string character in strings)
                {
                    Hero hero = new Hero();
                    hero.name = character;
                    heroes.Add(hero);
                }
            }
            catch { }
            return heroes;
        }

        public SampleItem Create(SampleItem instance)
        {
            // TODO: Add the new instance of SampleItem to the collection
            throw new NotImplementedException();
        }


        public SampleItem Get(string id)
        {
            // TODO: Return the instance of SampleItem with the given id
            throw new NotImplementedException();
        }


        public SampleItem Update(string id, SampleItem instance)
        {
            // TODO: Update the given instance of SampleItem in the collection
            throw new NotImplementedException();
        }


        public void Delete(string id)
        {
            // TODO: Remove the instance of SampleItem with the given id from the collection
            throw new NotImplementedException();
        }

    }
}
