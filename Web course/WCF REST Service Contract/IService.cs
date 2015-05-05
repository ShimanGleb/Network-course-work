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

        [WebGet(UriTemplate = "{name}")]
        List<string> CheckTurn(string name);

        [WebGet(UriTemplate = "sender {name}")]
        bool CheckPresence(string name);

        [WebInvoke(UriTemplate = "change states")]
        void ChangeState(List<string> actions);

        [WebInvoke(UriTemplate = "{playerName}, {enemyName}")]
        string AskContinuation(string playerName, string enemyName);

        [WebInvoke(UriTemplate = "remove player")]
        void RemovePlayer(string playerName);

        [WebInvoke(UriTemplate = "", Method = "POST")]
        SampleItem Create(SampleItem instance);
        
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        SampleItem Update(string id, SampleItem instance);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }
}
