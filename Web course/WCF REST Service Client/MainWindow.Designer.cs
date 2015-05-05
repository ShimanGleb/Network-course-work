namespace WCF_REST_Service_Client
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.passiveSkillDescription = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buffSkillDescription = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.attackSkillDescription = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.luck = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.agility = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.defense = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.attack = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.health = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AnimationTimer1 = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.passiveSkillDescription);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.buffSkillDescription);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.attackSkillDescription);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 339);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose your hero:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Passive skill:";
            // 
            // passiveSkillDescription
            // 
            this.passiveSkillDescription.Location = new System.Drawing.Point(302, 253);
            this.passiveSkillDescription.Name = "passiveSkillDescription";
            this.passiveSkillDescription.Size = new System.Drawing.Size(290, 80);
            this.passiveSkillDescription.TabIndex = 10;
            this.passiveSkillDescription.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Buff skill:";
            // 
            // buffSkillDescription
            // 
            this.buffSkillDescription.Location = new System.Drawing.Point(6, 253);
            this.buffSkillDescription.Name = "buffSkillDescription";
            this.buffSkillDescription.Size = new System.Drawing.Size(290, 80);
            this.buffSkillDescription.TabIndex = 8;
            this.buffSkillDescription.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Attack skill:";
            // 
            // attackSkillDescription
            // 
            this.attackSkillDescription.Location = new System.Drawing.Point(303, 143);
            this.attackSkillDescription.Name = "attackSkillDescription";
            this.attackSkillDescription.Size = new System.Drawing.Size(290, 80);
            this.attackSkillDescription.TabIndex = 6;
            this.attackSkillDescription.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Basic attack:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 143);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(290, 80);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Usual attack dealing normal damage. I know it`s boring and not interesting. Every" +
                " character must have usual attack.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.luck);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.agility);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.defense);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.attack);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.health);
            this.groupBox2.Location = new System.Drawing.Point(137, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stats:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(153, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "10";
            // 
            // luck
            // 
            this.luck.AutoSize = true;
            this.luck.ForeColor = System.Drawing.Color.Turquoise;
            this.luck.Location = new System.Drawing.Point(119, 40);
            this.luck.Name = "luck";
            this.luck.Size = new System.Drawing.Size(34, 13);
            this.luck.TabIndex = 8;
            this.luck.Text = "Luck:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "10";
            // 
            // agility
            // 
            this.agility.AutoSize = true;
            this.agility.ForeColor = System.Drawing.Color.Olive;
            this.agility.Location = new System.Drawing.Point(119, 16);
            this.agility.Name = "agility";
            this.agility.Size = new System.Drawing.Size(37, 13);
            this.agility.TabIndex = 6;
            this.agility.Text = "Agility:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "10";
            // 
            // defense
            // 
            this.defense.AutoSize = true;
            this.defense.ForeColor = System.Drawing.Color.Blue;
            this.defense.Location = new System.Drawing.Point(6, 63);
            this.defense.Name = "defense";
            this.defense.Size = new System.Drawing.Size(50, 13);
            this.defense.TabIndex = 4;
            this.defense.Text = "Defense:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "10";
            // 
            // attack
            // 
            this.attack.AutoSize = true;
            this.attack.ForeColor = System.Drawing.Color.Red;
            this.attack.Location = new System.Drawing.Point(6, 40);
            this.attack.Name = "attack";
            this.attack.Size = new System.Drawing.Size(41, 13);
            this.attack.TabIndex = 2;
            this.attack.Text = "Attack:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "100";
            // 
            // health
            // 
            this.health.AutoSize = true;
            this.health.ForeColor = System.Drawing.Color.Lime;
            this.health.Location = new System.Drawing.Point(6, 16);
            this.health.Name = "health";
            this.health.Size = new System.Drawing.Size(41, 13);
            this.health.TabIndex = 0;
            this.health.Text = "Health:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(599, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "SUBMIT!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter your name:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox1.Location = new System.Drawing.Point(136, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 5;
            // 
            // AnimationTimer1
            // 
            this.AnimationTimer1.Interval = 1;
            // 
            // AnimationTimer2
            // 
            this.AnimationTimer2.Interval = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "Dreams of phantasm";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label defense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label attack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label health;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox passiveSkillDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox buffSkillDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox attackSkillDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label agility;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label luck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer AnimationTimer1;
        private System.Windows.Forms.Timer AnimationTimer2;

    }
}