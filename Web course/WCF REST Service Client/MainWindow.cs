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
        List<Hero> heroes = new List<Hero>();
        Hero playerHero = new Hero();
        static string serviceUri = "http://localhost:9117";
        ChannelFactory<IService> serviceChannelFactory = new ChannelFactory<IService>(new WebHttpBinding(), serviceUri);
        WCFRESTServiceContract.IService serviceChannel;
        public MainWindow()
        {
            InitializeComponent();
            RunServiceChannel();           
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
            waitingWindow.Text = "";
            this.Controls.Add(waitingWindow);
        }

        public void InitializeBattle()
        {
            //Add character picture
            PictureBox characterPicture = new PictureBox();
            characterPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            characterPicture.Location = new System.Drawing.Point(12, 12);
            characterPicture.Name = "characterPicture";
            characterPicture.Size = new System.Drawing.Size(295, 214);
            characterPicture.TabIndex = 0;
            characterPicture.TabStop = false;            
            this.Controls.Add(characterPicture);
            //Add enemy picture
            PictureBox enemyPicture = new PictureBox();
            enemyPicture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            enemyPicture.Location = new System.Drawing.Point(317, 12);
            enemyPicture.Name = "enemyPicture";
            enemyPicture.Size = new System.Drawing.Size(295, 214);
            enemyPicture.TabIndex = 0;
            enemyPicture.TabStop = false;                        
            this.Controls.Add(enemyPicture);
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
            Label characterHealthValue = new Label();
            characterHealthValue.AutoSize = true;
            characterHealthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterHealthValue.Location = new System.Drawing.Point(69, 30);
            characterHealthValue.Name = "characterHealthValue";
            characterHealthValue.Size = new System.Drawing.Size(40, 22);
            characterHealthValue.TabIndex = 1;
            characterHealthValue.Text = "100";
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
            Label characterAttackValue = new Label();
            characterAttackValue.AutoSize = true;
            characterAttackValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterAttackValue.Location = new System.Drawing.Point(176, 30);
            characterAttackValue.Name = "characterAttackValue";
            characterAttackValue.Size = new System.Drawing.Size(30, 22);
            characterAttackValue.TabIndex = 3;
            characterAttackValue.Text = "10";
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
            Label characterDefenseValue = new Label();
            characterDefenseValue.AutoSize = true;
            characterDefenseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterDefenseValue.Location = new System.Drawing.Point(290, 30);
            characterDefenseValue.Name = "characterDefenseValue";
            characterDefenseValue.Size = new System.Drawing.Size(30, 22);
            characterDefenseValue.TabIndex = 5;
            characterDefenseValue.Text = "10";
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
            Label characterAgilityValue = new Label();
            characterAgilityValue.AutoSize = true;
            characterAgilityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterAgilityValue.Location = new System.Drawing.Point(384, 30);
            characterAgilityValue.Name = "characterAgilityValue";
            characterAgilityValue.Size = new System.Drawing.Size(30, 22);
            characterAgilityValue.TabIndex = 7;
            characterAgilityValue.Text = "10";
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
            Label characterLuckValue = new Label();
            characterLuckValue.AutoSize = true;
            characterLuckValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            characterLuckValue.Location = new System.Drawing.Point(470, 30);
            characterLuckValue.Name = "characterLuckValue";
            characterLuckValue.Size = new System.Drawing.Size(30, 22);
            characterLuckValue.TabIndex = 9;
            characterLuckValue.Text = "20";
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
            Label enemyHealthValue = new Label();
            enemyHealthValue.AutoSize = true;
            enemyHealthValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyHealthValue.Location = new System.Drawing.Point(69, 30);
            enemyHealthValue.Name = "enemyHealthValue";
            enemyHealthValue.Size = new System.Drawing.Size(40, 22);
            enemyHealthValue.TabIndex = 1;
            enemyHealthValue.Text = "100";
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
            Label enemyAttackValue = new Label();
            enemyAttackValue.AutoSize = true;
            enemyAttackValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyAttackValue.Location = new System.Drawing.Point(176, 30);
            enemyAttackValue.Name = "enemyAttackValue";
            enemyAttackValue.Size = new System.Drawing.Size(30, 22);
            enemyAttackValue.TabIndex = 3;
            enemyAttackValue.Text = "10";
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
            enemyDefenseLabel.Text = "Defense:";
            // 
            // label 16
            // 
            Label enemyDefenseValue = new Label();
            enemyDefenseValue.AutoSize = true;
            enemyDefenseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyDefenseValue.Location = new System.Drawing.Point(290, 30);
            enemyDefenseValue.Name = "enemyDefenseValue";
            enemyDefenseValue.Size = new System.Drawing.Size(30, 22);
            enemyDefenseValue.TabIndex = 5;
            enemyDefenseValue.Text = "10";
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
            Label enemyAgilityValue = new Label();
            enemyAgilityValue.AutoSize = true;
            enemyAgilityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyAgilityValue.Location = new System.Drawing.Point(384, 30);
            enemyAgilityValue.Name = "enemyAgilityValue";
            enemyAgilityValue.Size = new System.Drawing.Size(30, 22);
            enemyAgilityValue.TabIndex = 7;
            enemyAgilityValue.Text = "10";
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
            Label enemyLuckValue = new Label();
            enemyLuckValue.AutoSize = true;
            enemyLuckValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            enemyLuckValue.Location = new System.Drawing.Point(470, 30);
            enemyLuckValue.Name = "enemyLuckValue";
            enemyLuckValue.Size = new System.Drawing.Size(30, 22);
            enemyLuckValue.TabIndex = 9;
            enemyLuckValue.Text = "20";
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
            Button firstAction = new Button();
            firstAction.Location = new System.Drawing.Point(12, 396);
            firstAction.Name = "firstAction";
            firstAction.Size = new System.Drawing.Size(195, 33);
            firstAction.TabIndex = 4;
            firstAction.Text = "Usual attack";
            firstAction.UseVisualStyleBackColor = true;
            // second button
            Button secondAction = new Button();
            secondAction.Location = new System.Drawing.Point(213, 396);
            secondAction.Name = "secondAction";
            secondAction.Size = new System.Drawing.Size(195, 33);
            secondAction.TabIndex = 5;
            secondAction.Text = "Attack skill";
            secondAction.UseVisualStyleBackColor = true;
            // third button
            Button thirdAction = new Button();
            thirdAction.Location = new System.Drawing.Point(414, 396);
            thirdAction.Name = "thirdAction";
            thirdAction.Size = new System.Drawing.Size(195, 32);
            thirdAction.TabIndex = 6;
            thirdAction.Text = "Buff skill";
            thirdAction.UseVisualStyleBackColor = true;
            this.Controls.Add(firstAction);
            this.Controls.Add(secondAction);
            this.Controls.Add(thirdAction);
        }

        public Hero ResolveHero(Hero hero)
        {
            if (hero.type == "Psycho")
            {
                Psycho psycho = new Psycho();
                psycho.name = hero.name;
                return psycho;
            }
            if (hero.type == "Soul")
            {
                Soul soul = new Soul();
                soul.name = hero.name;
                return soul;
            }
            if (hero.type == "Shrine maiden")
            {
                ShrineMaiden shrineMaiden = new ShrineMaiden();
                shrineMaiden.name = hero.name;
                return shrineMaiden;
            }
            return hero;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {                       
            SkillNamer namer = new SkillNamer();                    
            List<Hero> heroTemps = new List<Hero>();
            heroTemps = serviceChannel.GetHeroes();            
            foreach (var hero in heroTemps)
            {                
                heroes.Add(ResolveHero(hero));                
                comboBox1.Items.Add(hero.name);                                                      
            }
            comboBox1.Text = heroes[0].name;
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
                Hero enemy = ResolveHero(enemyTemp);
                enemy.playerName = enemyTemp.playerName;
                if (enemy.type != null)
                {
                    this.Controls.Clear();
                    InitializeBattle();
                    break;
                }
            }            
        }
    }
}
