using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using WCFRESTServiceContract;
using GameplayClasses;
using System.IO;

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
                string[] strings = System.IO.File.ReadAllLines(fileName);                
                foreach (string line in strings)
                    {
                        string[] characterData = line.Split('=');
                        Hero hero = new Hero();
                        hero.name = characterData[0];
                        hero.type = characterData[1];
                        heroes.Add(hero);
                    }
            return heroes;
        }        

        public void AddPendingPlayer(string name, string character)
        {
            string filename = "PendingPlayers.txt";
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, true);
            writer.WriteLine(name+"="+character+"=pending");
            writer.Close();
        }

        public void RewriteStates(string fileName,string[] strings)
        {            
            StreamWriter stateRewriter = new StreamWriter(fileName);
            foreach (string line in strings)
            {                
                if (line != "")
                {
                    stateRewriter.Write(line + "\r\n");
                }
            }
            stateRewriter.Close();
        }

        public Hero GiveEnemy(string name,string type)
        {
            Hero enemy = new Hero();
            string fileName = "PendingPlayers.txt";
            string[] strings = System.IO.File.ReadAllLines(fileName);

            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == name && playerData[2]!="pending")
                {
                    if (playerData[3] == "Psycho")
                    {
                        enemy.type = "Psycho";
                    }
                    if (playerData[3] == "Soul")
                    {
                        enemy.type = "Soul";
                    }
                    if (playerData[3] == "Shrine maiden")
                    {
                        enemy.type = "Shrine maiden";
                    }
                    enemy.playerName = playerData[2];
                    strings[i] = "";
                    RewriteStates(fileName,strings);
                    return enemy;
                }
            }

            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[2] == "pending" && playerData[0] != name)
                {
                    if (playerData[1] == "Psycho")
                    {
                        enemy.type = "Psycho";
                    }
                    if (playerData[1] == "Soul")
                    {
                        enemy.type = "Soul";
                    }
                    if (playerData[1] == "Shrine maiden")
                    {
                        enemy.type = "Shrine maiden";
                    }
                    enemy.playerName = playerData[0];
                    strings[i]=playerData[0]+"="+playerData[1]+"=" + name + "=" + type;
                    for (int j = 0; j < strings.Length; j++)
                    {
                        string[] line = strings[j].Split('=');
                        if (line[0] == name)
                        {
                            strings[j] = "";
                            break;
                        }
                    }

                    string filename = "Player_states.txt";
                    System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, true);
                    writer.WriteLine(playerData[0] + "=waiting");
                    writer.WriteLine(name + "=ready");
                    writer.Close();
                    RewriteStates(fileName,strings);

                    const int time = 180;
                    filename = "Player_activities.txt";
                    writer = new System.IO.StreamWriter(filename, true);
                    writer.WriteLine(playerData[0] + '=' + time);
                    writer.WriteLine(name + '=' + time);
                    writer.Close();

                    return enemy;
                }
            }
            RewriteStates(fileName,strings);
            return enemy;
        }

        public List<string> CheckTurn(string name)
        {
            string fileName = "Player_states.txt";
            List<string> states = new List<string>();            
            string[] strings = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < strings.Length; i++ )
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == name && playerData[1] != "waiting")
                {
                    for (int j = 1; j < playerData.Length; j++)
                    {
                        states.Add(playerData[j]);
                    }
                    strings[i] = name + "=waiting";
                    RewriteStates(fileName,strings);
                    break;
                }
            }            
            return states;
        }

        public void ChangeState(List<string> actions)
        {
            const int time = 120;
            string fileName = "Player_states.txt";
            string[] strings = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == actions[0])
                {
                    strings[i]="";
                    for (int j = 0; j < actions.Count; j++)
                    {
                        strings[i] += actions[j];
                        if (j != actions.Count - 1)
                        {
                            strings[i] += "=";
                        }
                    }
                    RewriteStates(fileName, strings);
                    break;
                }
            }

            fileName = "Player_activities.txt";            
            strings = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == actions[0])
                {
                    strings[i] = playerData[0] + '=' + time;
                    RewriteStates(fileName, strings);
                    break;
                }
            }
        }

        public bool CheckPresence(string playerName)
        {
            const int time = 120;
            string fileName = "Player_activities.txt";
            string[] strings = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == playerName)
                {
                    strings[i] = playerData[0] + '=' + time;
                    RewriteStates(fileName, strings);
                    return true;
                }
            }
            return false;
        }

        public string AskContinuation(string playerName, string enemyName)
        {
            string fileName = "Player_states.txt";
            string[] strings = System.IO.File.ReadAllLines(fileName);

            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == playerName && playerData[1]!="continues")
                {                    
                    return "continues";
                }
            }

            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == enemyName)
                {
                    if (playerData[1] == "continues")
                    {
                        strings[i] = playerData[0] + "=waiting";
                        RewriteStates(fileName,strings);
                        return "continues";
                    }
                    else
                    {
                        return "decides";
                    }
                }
            }
            return "out";
        }

        public void RemovePlayer(string playerName)
        {
            string fileName = "Player_states.txt";
            List<string> states = new List<string>();
            string[] strings = System.IO.File.ReadAllLines(fileName);
            for (int i = 0; i < strings.Length; i++)
            {
                string[] playerData = strings[i].Split('=');
                if (playerData[0] == playerName)
                {
                    strings[i] = "";                    
                    RewriteStates(fileName, strings);
                    break;
                }
            }
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
