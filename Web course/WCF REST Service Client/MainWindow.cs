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
        int playerMessageX = 100;
        int enemyMessageX = 380;
        int messageY = 100;
        PictureBox resultPicture = new PictureBox();
        Button yesButton = new Button();
        Button noButton = new Button();


        static Label characterHealthValue = new Label();
        static Label characterAttackValue = new Label();
        static Label characterDefenseValue = new Label();
        static Label characterAgilityValue = new Label();
        static Label characterLuckValue = new Label();
        static Label enemyHealthValue = new Label();
        static Label enemyAttackValue = new Label();
        static Label enemyDefenseValue = new Label();
        static Label enemyAgilityValue = new Label();
        static Label enemyLuckValue = new Label();
        static Label messageLabel = new Label();
        Button firstAction = new Button();
        Button secondAction = new Button();
        Button thirdAction = new Button();

        List<Hero> heroes = new List<Hero>();
        List<string> actions = new List<string>();
        Hero playerHero = new Hero();
        Hero enemy = new Hero();
        static string serviceUri = "http://localhost:9117";
        ChannelFactory<IService> serviceChannelFactory = new ChannelFactory<IService>(new WebHttpBinding(), serviceUri);
        WCFRESTServiceContract.IService serviceChannel;

        System.Windows.Forms.Timer turnChecker = new System.Windows.Forms.Timer();        

        public MainWindow()
        {
            InitializeComponent();
            RunServiceChannel();            
        }

        public bool CheckBattleOver()
        {            
            if (enemy.health <= 0 || playerHero.health<=0)
            {                
                if (playerHero.health > 0 && enemy.health<=0)
                {
                    InitializeOverWindow("win");
                }
                if (playerHero.health <= 0 && enemy.health > 0)
                {
                    InitializeOverWindow("defeat");
                }
                if (playerHero.health <= 0 && enemy.health <= 0)
                {
                    InitializeOverWindow("tie");
                }
                return true;
            }
            return false;            
        }

        public void ShowMessage(string message, int height, int width)
        {
            messageLabel.AutoSize = true;
            messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            messageLabel.Name = "messageLabel";
            messageLabel.ForeColor = System.Drawing.Color.Red;
            messageLabel.Location = new System.Drawing.Point(height, width);
            messageLabel.TabIndex = 4;
            messageLabel.BackColor = System.Drawing.Color.White;
            messageLabel.Text = message;
            this.Controls.Add(messageLabel);
            this.Controls[this.Controls.Count - 1].BringToFront();            
            
            this.Refresh();
            System.Threading.Thread.Sleep(750);            
            this.Controls.Remove(messageLabel);                             
        }

        public void RunServiceChannel()
        {                        
            serviceChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            serviceChannel = serviceChannelFactory.CreateChannel();
        }

        public void InitializeWaitingWindow()
        {           
            PictureBox waitingWindow = new PictureBox();
            waitingWindow.Location = new System.Drawing.Point(13, 13);
            waitingWindow.Name = "waitingWindow";
            waitingWindow.Size = new System.Drawing.Size(600, 410);
            waitingWindow.TabIndex = 10;
            waitingWindow.Text = "Please, wait.";
            Bitmap image = new Bitmap(Image.FromFile(Application.StartupPath + @"\Images\System\SearchingWindow.png"), waitingWindow.Size);
            waitingWindow.Image = (Image)image;
            this.Controls.Add(waitingWindow);
            this.Refresh();
        }

        public void InitializeBattle()
        {
            int firstAnimationShift = -119;
            int secondAnimationShift = 450;
            //Add character picture     
            PictureBox characterPicture = new PictureBox();
            characterPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            characterPicture.Location = new System.Drawing.Point(12, 12);
            characterPicture.Name = "characterPicture";
            characterPicture.Size = new System.Drawing.Size(295, 214);
            characterPicture.TabIndex = 0;
            characterPicture.TabStop = false;
            Bitmap image = new Bitmap(Image.FromFile(Application.StartupPath + @"\Images\Heroes\" + playerHero.name + ".jpg"), characterPicture.Size);
            characterPicture.Image = (Image)image;
            this.Controls.Add(characterPicture);
            AnimationTimer1.Tick += new EventHandler((object sender, EventArgs e) =>
            {
                firstAnimationShift++;
                characterPicture.Location = new System.Drawing.Point(firstAnimationShift, 12);
                if (firstAnimationShift==12) AnimationTimer1.Stop();
            });
            AnimationTimer1.Start();
            //Add enemy picture
            PictureBox enemyPicture = new PictureBox();
            enemyPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            enemyPicture.Location = new System.Drawing.Point(317, 12);
            enemyPicture.Name = "enemyPicture";
            enemyPicture.Size = new System.Drawing.Size(295, 214);
            enemyPicture.TabIndex = 0;
            enemyPicture.TabStop = false;
            image = new Bitmap(Image.FromFile(Application.StartupPath + @"\Images\Heroes\" + enemy.name + ".jpg"), characterPicture.Size);
            enemyPicture.Image = (Image)image;    
            this.Controls.Add(enemyPicture);
            AnimationTimer2.Tick += new EventHandler((object sender, EventArgs e) =>
            {
                secondAnimationShift--;
                enemyPicture.Location = new System.Drawing.Point(secondAnimationShift, 12);
                if (secondAnimationShift == 317) AnimationTimer2.Stop();
            });
            AnimationTimer2.Start();
            //Add character info
            GroupBox characterData = new GroupBox();
            characterData.Location = new System.Drawing.Point(13, 233);
            characterData.Name = "characterData";
            characterData.Size = new System.Drawing.Size(599, 75);
            characterData.TabIndex = 2;
            characterData.TabStop = false;
            characterData.Text = "Character";
            this.Controls.Add(characterData);
            // label1
            Label characterHealthLabel = new Label();
            characterHealthLabel.AutoSize = true;
            characterHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterHealthLabel.Location = new System.Drawing.Point(6, 30);
            characterHealthLabel.Name = "characterHealthLabel";
            characterHealthLabel.Size = new System.Drawing.Size(67, 22);
            characterHealthLabel.TabIndex = 0;
            characterHealthLabel.Text = "Health:";
            // label2                
            characterHealthValue.AutoSize = true;
            characterHealthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterHealthValue.Location = new System.Drawing.Point(69, 30);
            characterHealthValue.Name = "characterHealthValue";
            characterHealthValue.Size = new System.Drawing.Size(40, 22);
            characterHealthValue.TabIndex = 1;
            characterHealthValue.Text = playerHero.health.ToString();
            // label3
            Label characterAttackLabel = new Label();
            characterAttackLabel.AutoSize = true;
            characterAttackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterAttackLabel.Location = new System.Drawing.Point(115, 30);
            characterAttackLabel.Name = "characterAttackLabel";
            characterAttackLabel.Size = new System.Drawing.Size(65, 22);
            characterAttackLabel.TabIndex = 2;
            characterAttackLabel.Text = "Attack:";
            // 
            // label4
            //             
            characterAttackValue.AutoSize = true;
            characterAttackValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterAttackValue.Location = new System.Drawing.Point(176, 30);
            characterAttackValue.Name = "characterAttackValue";
            characterAttackValue.Size = new System.Drawing.Size(30, 22);
            characterAttackValue.TabIndex = 3;
            characterAttackValue.Text = playerHero.attack.ToString();
            // 
            // label5
            // 
            Label characterDefenseLabel = new Label();
            characterDefenseLabel.AutoSize = true;
            characterDefenseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterDefenseLabel.Location = new System.Drawing.Point(212, 30);
            characterDefenseLabel.Name = "characterDefenseLabel";
            characterDefenseLabel.Size = new System.Drawing.Size(82, 22);
            characterDefenseLabel.TabIndex = 4;
            characterDefenseLabel.Text = "Defense:";
            // 
            // label6
            //            
            characterDefenseValue.AutoSize = true;
            characterDefenseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterDefenseValue.Location = new System.Drawing.Point(290, 30);
            characterDefenseValue.Name = "characterDefenseValue";
            characterDefenseValue.Size = new System.Drawing.Size(30, 22);
            characterDefenseValue.TabIndex = 5;
            characterDefenseValue.Text = playerHero.defence.ToString();
            // 
            // label7
            // 
            Label characterAgilityLabel = new Label();
            characterAgilityLabel.AutoSize = true;
            characterAgilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterAgilityLabel.Location = new System.Drawing.Point(326, 30);
            characterAgilityLabel.Name = "characterAgilityLabel";
            characterAgilityLabel.Size = new System.Drawing.Size(63, 22);
            characterAgilityLabel.TabIndex = 6;
            characterAgilityLabel.Text = "Agility:";
            // 
            // label8
            //             
            characterAgilityValue.AutoSize = true;
            characterAgilityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterAgilityValue.Location = new System.Drawing.Point(384, 30);
            characterAgilityValue.Name = "characterAgilityValue";
            characterAgilityValue.Size = new System.Drawing.Size(30, 22);
            characterAgilityValue.TabIndex = 7;
            characterAgilityValue.Text = playerHero.agility.ToString();
            // 
            // label9
            // 
            Label characterLuckLabel = new Label();
            characterLuckLabel.AutoSize = true;
            characterLuckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterLuckLabel.Location = new System.Drawing.Point(420, 30);
            characterLuckLabel.Name = "characterLuckLabel";
            characterLuckLabel.Size = new System.Drawing.Size(53, 22);
            characterLuckLabel.TabIndex = 8;
            characterLuckLabel.Text = "Luck:";
            // 
            // label10
            //            
            characterLuckValue.AutoSize = true;
            characterLuckValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterLuckValue.Location = new System.Drawing.Point(470, 30);
            characterLuckValue.Name = "characterLuckValue";
            characterLuckValue.Size = new System.Drawing.Size(30, 22);
            characterLuckValue.TabIndex = 9;
            characterLuckValue.Text = playerHero.luck.ToString();
            // add to groupbox
            characterData.Controls.Add(characterHealthLabel);
            characterData.Controls.Add(characterHealthValue);
            characterData.Controls.Add(characterAttackLabel);
            characterData.Controls.Add(characterAttackValue);
            characterData.Controls.Add(characterDefenseLabel);
            characterData.Controls.Add(characterDefenseValue);
            characterData.Controls.Add(characterAgilityLabel);
            characterData.Controls.Add(characterAgilityValue);
            characterData.Controls.Add(characterLuckLabel);
            characterData.Controls.Add(characterLuckValue);
            
            //Add enemy info
            GroupBox enemyData = new GroupBox();
            enemyData.Location = new System.Drawing.Point(13, 314);
            enemyData.Name = "enemyData";
            enemyData.Size = new System.Drawing.Size(599, 75);
            enemyData.TabIndex = 3;
            enemyData.TabStop = false;
            enemyData.Text = "Enemy";
            this.Controls.Add(enemyData);
            // label 11
            Label enemyHealthLabel = new Label();
            enemyHealthLabel.AutoSize = true;
            enemyHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyHealthLabel.Location = new System.Drawing.Point(6, 30);
            enemyHealthLabel.Name = "enemyHealthLabel";
            enemyHealthLabel.Size = new System.Drawing.Size(67, 22);
            enemyHealthLabel.TabIndex = 0;
            enemyHealthLabel.Text = "Health:";
            // label 12                
            enemyHealthValue.AutoSize = true;
            enemyHealthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyHealthValue.Location = new System.Drawing.Point(69, 30);
            enemyHealthValue.Name = "enemyHealthValue";
            enemyHealthValue.Size = new System.Drawing.Size(40, 22);
            enemyHealthValue.TabIndex = 1;
            enemyHealthValue.Text = enemy.health.ToString();
            // label 13
            Label enemyAttackLabel = new Label();
            enemyAttackLabel.AutoSize = true;
            enemyAttackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyAttackLabel.Location = new System.Drawing.Point(115, 30);
            enemyAttackLabel.Name = "enemyAttackLabel";
            enemyAttackLabel.Size = new System.Drawing.Size(65, 22);
            enemyAttackLabel.TabIndex = 2;
            enemyAttackLabel.Text = "Attack:";
            // 
            // label 14
            //             
            enemyAttackValue.AutoSize = true;
            enemyAttackValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyAttackValue.Location = new System.Drawing.Point(176, 30);
            enemyAttackValue.Name = "enemyAttackValue";
            enemyAttackValue.Size = new System.Drawing.Size(30, 22);
            enemyAttackValue.TabIndex = 3;
            enemyAttackValue.Text = enemy.attack.ToString();
            // 
            // label 15
            // 
            Label enemyDefenseLabel = new Label();
            enemyDefenseLabel.AutoSize = true;
            enemyDefenseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyDefenseLabel.Location = new System.Drawing.Point(212, 30);
            enemyDefenseLabel.Name = "enemyDefenseLabel";
            enemyDefenseLabel.Size = new System.Drawing.Size(82, 22);
            enemyDefenseLabel.TabIndex = 4;
            enemyDefenseLabel.Text = "Defence:";
            // 
            // label 16
            //             
            enemyDefenseValue.AutoSize = true;
            enemyDefenseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyDefenseValue.Location = new System.Drawing.Point(290, 30);
            enemyDefenseValue.Name = "enemyDefenseValue";
            enemyDefenseValue.Size = new System.Drawing.Size(30, 22);
            enemyDefenseValue.TabIndex = 5;
            enemyDefenseValue.Text = enemy.defence.ToString();
            // 
            // label 17
            // 
            Label enemyAgilityLabel = new Label();
            enemyAgilityLabel.AutoSize = true;
            enemyAgilityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyAgilityLabel.Location = new System.Drawing.Point(326, 30);
            enemyAgilityLabel.Name = "enemyAgilityLabel";
            enemyAgilityLabel.Size = new System.Drawing.Size(63, 22);
            enemyAgilityLabel.TabIndex = 6;
            enemyAgilityLabel.Text = "Agility:";
            // 
            // label 18
            //             
            enemyAgilityValue.AutoSize = true;
            enemyAgilityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyAgilityValue.Location = new System.Drawing.Point(384, 30);
            enemyAgilityValue.Name = "enemyAgilityValue";
            enemyAgilityValue.Size = new System.Drawing.Size(30, 22);
            enemyAgilityValue.TabIndex = 7;
            enemyAgilityValue.Text = enemy.agility.ToString();
            // 
            // label 19
            // 
            Label enemyLuckLabel = new Label();
            enemyLuckLabel.AutoSize = true;
            enemyLuckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyLuckLabel.Location = new System.Drawing.Point(420, 30);
            enemyLuckLabel.Name = "enemyLuckLabel";
            enemyLuckLabel.Size = new System.Drawing.Size(53, 22);
            enemyLuckLabel.TabIndex = 8;
            enemyLuckLabel.Text = "Luck:";
            // 
            // label 20
            //            
            enemyLuckValue.AutoSize = true;
            enemyLuckValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyLuckValue.Location = new System.Drawing.Point(470, 30);
            enemyLuckValue.Name = "enemyLuckValue";
            enemyLuckValue.Size = new System.Drawing.Size(30, 22);
            enemyLuckValue.TabIndex = 9;
            enemyLuckValue.Text = enemy.luck.ToString();
            enemyData.Controls.Add(enemyHealthLabel);
            enemyData.Controls.Add(enemyHealthValue);
            enemyData.Controls.Add(enemyAttackLabel);
            enemyData.Controls.Add(enemyAttackValue);
            enemyData.Controls.Add(enemyDefenseLabel);
            enemyData.Controls.Add(enemyDefenseValue);
            enemyData.Controls.Add(enemyAgilityLabel);
            enemyData.Controls.Add(enemyAgilityValue);
            enemyData.Controls.Add(enemyLuckLabel);
            enemyData.Controls.Add(enemyLuckValue);

            // first button            
            firstAction.Location = new System.Drawing.Point(12, 396);
            firstAction.Name = "firstAction";
            firstAction.Size = new System.Drawing.Size(195, 33);
            firstAction.TabIndex = 4;
            firstAction.Text = "Usual attack";
            firstAction.UseVisualStyleBackColor = true;
                       
            // second button            
            secondAction.Location = new System.Drawing.Point(213, 396);
            secondAction.Name = "secondAction";
            secondAction.Size = new System.Drawing.Size(195, 33);
            secondAction.TabIndex = 5;
            secondAction.Text = "Attack skill";
            secondAction.UseVisualStyleBackColor = true;  
          
            // third button            
            thirdAction.Location = new System.Drawing.Point(414, 396);
            thirdAction.Name = "thirdAction";
            thirdAction.Size = new System.Drawing.Size(195, 32);
            thirdAction.TabIndex = 6;
            thirdAction.Text = "Buff skill";
            thirdAction.UseVisualStyleBackColor = true;

            
            this.Controls.Add(firstAction);
            this.Controls.Add(secondAction);
            this.Controls.Add(thirdAction);             
            this.Refresh();                    
        }

        public void InitializeOverWindow(string result)
        {
            this.Controls.Clear();
            resultPicture.Location = new System.Drawing.Point(12, 12);
            resultPicture.Name = "resultPicture";
            resultPicture.Size = new System.Drawing.Size(600, 270);
            resultPicture.TabIndex = 6;
            resultPicture.TabStop = false;
            Bitmap image = new Bitmap(Image.FromFile(Application.StartupPath + @"\Images\System\" + result + ".png"), resultPicture.Size);
            resultPicture.Image = (Image)image;

            yesButton.Location = new System.Drawing.Point(12, 393);
            yesButton.Name = "yesButton";
            yesButton.Size = new System.Drawing.Size(298, 36);
            yesButton.TabIndex = 7;
            yesButton.Text = "Yes";
            yesButton.UseVisualStyleBackColor = true;
           
            noButton.Location = new System.Drawing.Point(316, 393);
            noButton.Name = "noButton";
            noButton.Size = new System.Drawing.Size(298, 36);
            noButton.TabIndex = 8;
            noButton.Text = "No";
            noButton.UseVisualStyleBackColor = true;

            this.Controls.Add(resultPicture);
            this.Controls.Add(yesButton);
            this.Controls.Add(noButton);
        }

        public void RefreshStats()
        {
            characterHealthValue.Text = playerHero.health.ToString();
            characterAttackValue.Text = playerHero.attack.ToString();
            characterDefenseValue.Text = playerHero.defence.ToString();
            characterAgilityValue.Text = playerHero.agility.ToString();
            characterLuckValue.Text = playerHero.luck.ToString();
            enemyHealthValue.Text = enemy.health.ToString();
            enemyAttackValue.Text = enemy.attack.ToString();
            enemyDefenseValue.Text = enemy.defence.ToString();
            enemyAgilityValue.Text = enemy.agility.ToString();
            enemyLuckValue.Text = enemy.luck.ToString();
        }

        public void RemoveBuff(Hero character,string buffName)
        {
            string[] buffData = buffName.Split('+');
            int buffPower=Convert.ToInt32(buffData[1]);
            if (buffData[0] == "attack") character.attack -= buffPower;
            if (buffData[0] == "defence") character.defence -= buffPower;
            if (buffData[0] == "agility") character.agility -= buffPower;
            if (buffData[0] == "luck") character.luck -= buffPower;
        }

        public void AddBuff(Hero character, string type, int power)
        {
            if (type == "attack") character.attack += power;
            if (type == "defence") character.defence += power;
            if (type == "agility") character.agility += power;
            if (type == "luck") character.luck += power;
        }

        public void UsualAttack(object sender, EventArgs e)
        {
            if (serviceChannel.CheckPresence(playerHero.playerName) == false)
            {
                serviceChannel.RemovePlayer(playerHero.playerName);
                InitializeOverWindow("out_of_time");
                return;
            }
            ShowMessage("attack!", playerMessageX, messageY);
            DamageDealer attack = new DamageDealer();
            if (playerHero.passiveSkill is BuffAbort && enemy.buffs.Count!=0)
            {
                Random buffAbortChance = new Random();
                if (buffAbortChance.Next(0, 100) <= playerHero.passiveSkill.power)
                {
                    actions.Add("remove buff");
                    ShowMessage(playerHero.passiveSkill.name + "!", playerMessageX, messageY);                    
                    int removedBuff = buffAbortChance.Next(0,enemy.buffs.Count-1);
                    ShowMessage(enemy.buffs.Keys[removedBuff].Split('+')[0] + " is normal", enemyMessageX, messageY);

                    actions.Add(enemy.buffs.Keys[removedBuff]);
                    RemoveBuff(enemy, enemy.buffs.Keys[removedBuff]);
                    enemy.buffs.Remove(enemy.buffs.Keys[removedBuff]);
                }
            }
            actions.Add("enemy attacks");            
            int damage=attack.attack(enemy.defence,enemy.agility,playerHero.attack,playerHero.agility,playerHero.luck);
            if (damage == -1)
            {
                ShowMessage("miss!", enemyMessageX, messageY);
                actions.Add("miss");
            }
            else
            {
                if (enemy.passiveSkill is DamageBlock)
                {
                    Random blockChance = new Random();
                    if (blockChance.Next(0, 100) <= enemy.passiveSkill.power)
                    {
                        damage = 0;
                        ShowMessage("blocked!", enemyMessageX, messageY);
                        actions.Add("blocked");
                    }
                }
                    actions.Add(damage.ToString());
                    ShowMessage("gained " + damage + " damage!", enemyMessageX, messageY);
                    enemy.health -= damage;
                    if (playerHero.passiveSkill is Vampire)
                    {
                        double heal = damage * playerHero.passiveSkill.power;
                        playerHero.health += (int)heal;
                        ShowMessage("restored " + (int)heal + " health!", playerMessageX, messageY);
                        actions.Add("enemy heals");
                        actions.Add(((int)damage * playerHero.passiveSkill.power).ToString());
                    }
                
            }
            serviceChannel.ChangeState(actions);
            RefreshStats();
            this.Refresh();
            if (CheckBattleOver() == false)
            {
                WaitForTurn();
            }
        }

        public void UseSkill(object sender, EventArgs e)
        {
            if (serviceChannel.CheckPresence(playerHero.playerName) == false)
            {
                serviceChannel.RemovePlayer(playerHero.playerName);
                InitializeOverWindow("out_of_time");
                return;
            }
            ShowMessage(playerHero.attackSkill.name + '!', playerMessageX, messageY);            
            if (playerHero.passiveSkill is BuffAbort && enemy.buffs.Count != 0)
            {
                Random buffAbortChance = new Random();
                if (buffAbortChance.Next(0, 100) <= playerHero.passiveSkill.power)
                {
                    actions.Add("remove buff");
                    ShowMessage(playerHero.passiveSkill.name + "!", playerMessageX, messageY);
                    int removedBuff = buffAbortChance.Next(0, enemy.buffs.Count - 1);
                    ShowMessage(enemy.buffs.Keys[removedBuff].Split('+')[0] + " is normal", enemyMessageX, messageY);

                    actions.Add(enemy.buffs.Keys[removedBuff]);
                    RemoveBuff(enemy, enemy.buffs.Keys[removedBuff]);
                    enemy.buffs.Remove(enemy.buffs.Keys[removedBuff]);
                }
            }
            actions.Add("enemy attacks");
            int initialHealth = playerHero.health;
            int damage = playerHero.attackSkill.HitEnemy(enemy,playerHero);            
            if (damage == -1)
            {
                ShowMessage("miss!", enemyMessageX, messageY);
                actions.Add("miss");
                if (initialHealth != playerHero.health)
                {
                    ShowMessage("gained " + (initialHealth - playerHero.health) + " damage!", playerMessageX, messageY);
                    actions.Add("enemy damaged");
                    actions.Add((initialHealth - playerHero.health).ToString());
                }
            }
            else
            {
                if (enemy.passiveSkill is DamageBlock)
                {
                    Random blockChance = new Random();
                    if (blockChance.Next(0, 100) <= enemy.passiveSkill.power)
                    {
                        damage = 0;
                        ShowMessage("blocked!", enemyMessageX, messageY);
                        actions.Add("blocked");
                    }
                }
                actions.Add(damage.ToString());
                ShowMessage("gained " + damage + " damage!", enemyMessageX, messageY);
                enemy.health -= damage;
                if (initialHealth != playerHero.health)
                {
                    ShowMessage("gained " + (initialHealth - playerHero.health) + " damage!", playerMessageX, messageY);
                    actions.Add("enemy damaged");
                    actions.Add((initialHealth - playerHero.health).ToString());
                }
                if (playerHero.passiveSkill is Vampire)
                {
                    double heal = damage * playerHero.passiveSkill.power;
                    playerHero.health += (int)heal;
                    ShowMessage("restored " + (int)heal + " health!", playerMessageX, messageY);
                    actions.Add("enemy heals");
                    actions.Add(((int)damage * playerHero.passiveSkill.power).ToString());
                }
            }            
            serviceChannel.ChangeState(actions);
            RefreshStats();
            this.Refresh();
            if (CheckBattleOver() == false)
            {
                WaitForTurn();
            }
        }

        public void UseBuff(object sender, EventArgs e)
        {
            if (serviceChannel.CheckPresence(playerHero.playerName) == false)
            {
                serviceChannel.RemovePlayer(playerHero.playerName);
                InitializeOverWindow("out_of_time");
                return;
            }
            if (!playerHero.buffs.ContainsKey(playerHero.buffSkill.buffType + '+' + playerHero.buffSkill.power))
            {
                playerHero.buffs.Add(playerHero.buffSkill.buffType + '+' + playerHero.buffSkill.power, playerHero.buffSkill.timer);

                AddBuff(playerHero, playerHero.buffSkill.buffType, playerHero.buffSkill.power);                
                actions.Add("enemy buffs");
                actions.Add(playerHero.buffSkill.buffType + '+' + playerHero.buffSkill.power);
                actions.Add(playerHero.buffSkill.timer.ToString());
                serviceChannel.ChangeState(actions);
                ShowMessage("buff!", playerMessageX, messageY);
                ShowMessage(playerHero.buffSkill.buffType + " up!", playerMessageX, messageY);
                RefreshStats();
                WaitForTurn();
            }
            else
            {
                ShowMessage("Already buffed!",playerMessageX,messageY);
            }
        }

        public void CheckTurn(object sender, EventArgs e)
        {
            firstAction.Click -= new EventHandler(UsualAttack);
            secondAction.Click -= new EventHandler(UseSkill);
            thirdAction.Click -= new EventHandler(UseBuff);            
            try
            {                
                actions = serviceChannel.CheckTurn(playerHero.playerName);
            }
            catch { }
            if (actions.Count != 0)
            {
                for (int i = 0; i < actions.Count; i++)
                {
                    if (actions[i] == "enemy attacks")
                    {
                        ShowMessage("enemy attacks!", enemyMessageX, messageY);
                        if (i != actions.Count - 1 && actions[i + 1] == "miss")
                        {
                            ShowMessage("miss!", playerMessageX, messageY);
                        }
                        else if (i != actions.Count - 1 && actions[i + 1] == "blocked")
                        {
                            ShowMessage("blocked!", playerMessageX, messageY);
                        }
                        else
                        {
                            playerHero.health -= Convert.ToInt32(actions[i + 1]);
                            ShowMessage("gained " + Convert.ToInt32(actions[i + 1]) + " damage!", playerMessageX, messageY);
                        }
                        i++;
                    }
                    if (actions[i] == "enemy heals")
                    {

                        enemy.health += Convert.ToInt32(actions[i + 1]);
                        ShowMessage("restored " + Convert.ToInt32(actions[i + 1]) + " health!", enemyMessageX, messageY);
                        i++;
                    }
                    if (actions[i] == "enemy buffs")
                    {                        
                        string[] buffData = actions[i + 1].Split('+');
                        enemy.buffs.Add(actions[i + 1], Convert.ToInt32(actions[i + 2]));
                        AddBuff(enemy, buffData[0], Convert.ToInt32(buffData[1]));
                        ShowMessage("enemy buffs!", enemyMessageX, messageY);
                        ShowMessage(buffData[0] + " up!", enemyMessageX, messageY);
                        i++;
                    }
                    if (actions[i] == "enemy loses buff")
                    {
                        RemoveBuff(enemy, actions[i + 1]);
                        ShowMessage("enemy loses buff!", enemyMessageX, messageY);                        
                        ShowMessage(actions[i + 1].Split('+')[0] + " is normal!", enemyMessageX, messageY);
                        i++;
                    }
                    if (actions[i] == "remove buff")
                    {
                        RemoveBuff(playerHero, actions[i + 1]);
                        ShowMessage("buff lost!", playerMessageX, messageY);
                        ShowMessage(actions[i + 1].Split('+')[0] + " is normal!", playerMessageX, messageY);
                        playerHero.buffs.Remove(actions[i + 1]);
                        i++;
                    }
                    if (actions[i] == "enemy damaged")
                    {
                        enemy.health -= Convert.ToInt32(actions[i+1]);
                        ShowMessage("gained " + Convert.ToInt32(actions[i + 1]) + " damage!", enemyMessageX, messageY);
                    }
                }

                if (CheckBattleOver() == false)
                {


                    actions = new List<string>();
                    actions.Add(enemy.playerName);
                    for (int i = 0; i < playerHero.buffs.Keys.Count; i++)
                    {
                        playerHero.buffs[playerHero.buffs.Keys[i]]--;
                        if (playerHero.buffs[playerHero.buffs.Keys[i]] == 0)
                        {

                            ShowMessage("buff lost!", playerMessageX, messageY);
                            ShowMessage(playerHero.buffs.Keys[i].Split('+')[0] + " is normal!", playerMessageX, messageY);
                            RemoveBuff(playerHero, playerHero.buffs.Keys[i]);
                            actions.Add("enemy loses buff");
                            actions.Add(playerHero.buffs.Keys[i]);
                            playerHero.buffs.Remove(playerHero.buffs.Keys[i]);
                        }
                    }
                    RefreshStats();
                    firstAction.Click += new EventHandler(UsualAttack);
                    secondAction.Click += new EventHandler(UseSkill);
                    thirdAction.Click += new EventHandler(UseBuff);
                }
                turnChecker.Stop();

            }
        }

        public void WaitForTurn()
        {
            actions.Clear();
            turnChecker.Start();            
        }

        public Hero ResolveHero(Hero hero)
        {
            if (hero.type == "Psycho")
            {
                Psycho psycho = new Psycho();
                psycho.playerName = hero.playerName;
                return psycho;
            }
            if (hero.type == "Soul")
            {
                Soul soul = new Soul();
                soul.playerName = hero.playerName;
                return soul;
            }
            if (hero.type == "Shrine maiden")
            {
                ShrineMaiden shrineMaiden = new ShrineMaiden();
                shrineMaiden.playerName = hero.playerName;
                return shrineMaiden;
            }
            return hero;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {         
            List<Hero> heroTemps = new List<Hero>();
            heroTemps = serviceChannel.GetHeroes();
            foreach (var hero in heroTemps)
            {
                heroes.Add(ResolveHero(hero));
                comboBox1.Items.Add(hero.name);
            }
            comboBox1.Text = heroes[0].name;
            turnChecker.Tick += new EventHandler(CheckTurn);                    
            yesButton.Click += new EventHandler((object newSender, EventArgs newE) =>
                {
                    actions.Clear();                    
                    actions.Add(playerHero.playerName);
                    actions.Add("continues");                    
                    serviceChannel.ChangeState(actions);
                    actions.Clear();
                    string decision = "";
                    while (true)
                    {
                        try
                        {
                            decision = serviceChannel.AskContinuation(playerHero.playerName, enemy.playerName);
                        }
                        catch { }
                        if (decision == "out")
                        {
                            serviceChannel.RemovePlayer(playerHero.playerName);
                            playerHero = new Hero();
                            enemy = new Hero();
                            this.Controls.Clear();
                            InitializeComponent();
                            heroTemps = new List<Hero>();
                            heroTemps = serviceChannel.GetHeroes();
                            heroes.Clear();
                            foreach (var hero in heroTemps)
                            {
                                heroes.Add(ResolveHero(hero));
                                comboBox1.Items.Add(hero.name);
                            }
                            comboBox1.Text = heroes[0].name;
                            break;
                        }
                        if (decision == "continues")
                        {                            
                            this.Controls.Clear();

                            string playerName = playerHero.playerName;
                            playerHero = ResolveHero(playerHero);
                            playerHero.playerName = playerName;                            

                            string enemyName = enemy.playerName;
                            enemy = ResolveHero(enemy);
                            enemy.playerName = enemyName;
                            actions.Add(enemy.playerName);                            
                            InitializeBattle();
                            firstAction.Click += new EventHandler(UsualAttack);
                            secondAction.Click += new EventHandler(UseSkill);
                            thirdAction.Click += new EventHandler(UseBuff);
                            WaitForTurn();
                            
                            break;
                        }
                    }
                                   
                });
            noButton.Click += new EventHandler((object newSender, EventArgs newE) =>
            {
                serviceChannel.RemovePlayer(playerHero.playerName);
                Application.Exit();
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var hero in heroes)
            {
                if (hero.name == comboBox1.Text)
                {
                    label9.Text = hero.attackSkill.name;
                    label10.Text = hero.buffSkill.name;
                    label11.Text = hero.passiveSkill.name;
                    attackSkillDescription.Text = hero.attackSkill.description;
                    buffSkillDescription.Text = hero.buffSkill.description;
                    passiveSkillDescription.Text = hero.passiveSkill.description;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerHero = new Hero();
            enemy = new Hero();
            foreach (var hero in heroes)
            {
                if (hero.name == comboBox1.Text)
                {
                    playerHero = hero;
                    playerHero.playerName = textBox1.Text;
                    break;
                }
            }
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                serviceChannel.AddPendingPlayer(textBox1.Text, playerHero.type);
            }
            this.Controls.Clear();
            InitializeWaitingWindow();            
            while (true)
            {
                Hero enemyTemp= serviceChannel.GiveEnemy(playerHero.playerName,playerHero.type);
                enemy = ResolveHero(enemyTemp);
                enemy.playerName = enemyTemp.playerName;
                if (enemy.type != null)
                {
                    this.Controls.Clear();                    
                    InitializeBattle();
                    firstAction.Click += new EventHandler(UsualAttack);
                    secondAction.Click += new EventHandler(UseSkill);
                    thirdAction.Click += new EventHandler(UseBuff);

                    turnChecker.Interval = 3;                                
                    WaitForTurn();                                
                    break;
                }
            }            
        }
    }
}
