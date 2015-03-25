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

        [WebInvoke(UriTemplate = "", Method = "POST")]
        SampleItem Create(SampleItem instance);

        [WebGet(UriTemplate = "{id}")]
        SampleItem Get(string id);

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        SampleItem Update(string id, SampleItem instance);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }
}
