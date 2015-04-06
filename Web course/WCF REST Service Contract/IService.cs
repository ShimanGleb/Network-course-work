using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using GameplayClasses;

namespace WCFRESTServiceContract
{
    [ServiceContract]
    public interface IService
    {                

        [WebGet(UriTemplate = "")]
        List<Hero> GetHeroes();

        [WebGet(UriTemplate = "{name},{character}")]
        void AddPendingPlayer(string name, string character);

        [WebGet(UriTemplate = "sender {name},{type}")]
        Hero GiveEnemy(string name, string type);

        [WebInvoke(UriTemplate = "", Method = "POST")]
        SampleItem Create(SampleItem instance);
        

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        SampleItem Update(string id, SampleItem instance);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }
}
