namespace HW3_tic_tac_toe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxPlayers = new ListBox();
            textBoxName = new TextBox();
            label1 = new Label();
            buttonLogin = new Button();
            buttonPlay = new Button();
            buttonStopGame = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            button10 = new Button();
            SuspendLayout();
            // 
            // listBoxPlayers
            // 
            listBoxPlayers.FormattingEnabled = true;
            listBoxPlayers.ItemHeight = 15;
            listBoxPlayers.Location = new Point(12, 217);
            listBoxPlayers.Name = "listBoxPlayers";
            listBoxPlayers.Size = new Size(223, 259);
            listBoxPlayers.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(58, 122);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(178, 23);
            textBoxName.TabIndex = 10;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 125);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 11;
            label1.Text = "Name";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(13, 161);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(223, 33);
            buttonLogin.TabIndex = 12;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += button1_Click;
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new Point(12, 482);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(223, 31);
            buttonPlay.TabIndex = 13;
            buttonPlay.Text = "Star game";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonStopGame
            // 
            buttonStopGame.Location = new Point(12, 514);
            buttonStopGame.Name = "buttonStopGame";
            buttonStopGame.Size = new Size(223, 31);
            buttonStopGame.TabIndex = 14;
            buttonStopGame.Text = "Stop game";
            buttonStopGame.UseVisualStyleBackColor = true;
            buttonStopGame.Click += buttonStopGame_Click;
            // 
            // button1
            // 
            button1.Location = new Point(276, 18);
            button1.Name = "button1";
            button1.Size = new Size(150, 150);
            button1.TabIndex = 15;
            button1.Tag = "0 0";
            button1.UseVisualStyleBackColor = true;
            button1.Click += board_Click;
            // 
            // button2
            // 
            button2.Location = new Point(467, 18);
            button2.Name = "button2";
            button2.Size = new Size(150, 150);
            button2.TabIndex = 16;
            button2.Tag = "0 1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += board_Click;
            // 
            // button3
            // 
            button3.Location = new Point(655, 18);
            button3.Name = "button3";
            button3.Size = new Size(150, 150);
            button3.TabIndex = 17;
            button3.Tag = "0 2";
            button3.UseVisualStyleBackColor = true;
            button3.Click += board_Click;
            // 
            // button4
            // 
            button4.Location = new Point(276, 202);
            button4.Name = "button4";
            button4.Size = new Size(150, 150);
            button4.TabIndex = 18;
            button4.Tag = "1 0";
            button4.UseVisualStyleBackColor = true;
            button4.Click += board_Click;
            // 
            // button5
            // 
            button5.Location = new Point(467, 202);
            button5.Name = "button5";
            button5.Size = new Size(150, 150);
            button5.TabIndex = 19;
            button5.Tag = "1 1";
            button5.UseVisualStyleBackColor = true;
            button5.Click += board_Click;
            // 
            // button6
            // 
            button6.Location = new Point(655, 202);
            button6.Name = "button6";
            button6.Size = new Size(150, 150);
            button6.TabIndex = 20;
            button6.Tag = "1 2";
            button6.UseVisualStyleBackColor = true;
            button6.Click += board_Click;
            // 
            // button7
            // 
            button7.Location = new Point(276, 386);
            button7.Name = "button7";
            button7.Size = new Size(150, 150);
            button7.TabIndex = 21;
            button7.Tag = "2 0";
            button7.UseVisualStyleBackColor = true;
            button7.Click += board_Click;
            // 
            // button8
            // 
            button8.Location = new Point(467, 386);
            button8.Name = "button8";
            button8.Size = new Size(150, 150);
            button8.TabIndex = 22;
            button8.Tag = "2 1";
            button8.UseVisualStyleBackColor = true;
            button8.Click += board_Click;
            // 
            // button9
            // 
            button9.Location = new Point(655, 382);
            button9.Name = "button9";
            button9.Size = new Size(150, 150);
            button9.TabIndex = 23;
            button9.Tag = "2 2";
            button9.UseVisualStyleBackColor = true;
            button9.Click += board_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(13, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 23);
            comboBox1.TabIndex = 24;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 18);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 25;
            label2.Text = "Network";
            // 
            // button10
            // 
            button10.Location = new Point(12, 68);
            button10.Name = "button10";
            button10.Size = new Size(222, 27);
            button10.TabIndex = 26;
            button10.Text = "Select network";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 556);
            Controls.Add(button10);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonStopGame);
            Controls.Add(buttonPlay);
            Controls.Add(buttonLogin);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(listBoxPlayers);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxPlayers;
        private TextBox textBoxName;
        private Label label1;
        private Button buttonLogin;
        private Button buttonPlay;
        private Button buttonStopGame;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private ComboBox comboBox1;
        private Label label2;
        private Button button10;
    }
}