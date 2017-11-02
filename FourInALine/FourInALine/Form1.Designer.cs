namespace FourInALine
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerMoveDown = new System.Windows.Forms.Timer(this.components);
            this.timerMoveDownComputer = new System.Windows.Forms.Timer(this.components);
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelDiscsLeft = new System.Windows.Forms.Label();
            this.labelWinsLoses = new System.Windows.Forms.Label();
            this.labelGamesPlayed = new System.Windows.Forms.Label();
            this.labelDraws = new System.Windows.Forms.Label();
            this.labelWLRatio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerMoveDown
            // 
            this.timerMoveDown.Interval = 10;
            this.timerMoveDown.Tick += new System.EventHandler(this.timerMoveDown_Tick);
            // 
            // timerMoveDownComputer
            // 
            this.timerMoveDownComputer.Interval = 10;
            this.timerMoveDownComputer.Tick += new System.EventHandler(this.timerMoveDownComputer_Tick);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestart.Location = new System.Drawing.Point(12, 622);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(139, 53);
            this.buttonRestart.TabIndex = 0;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // labelDiscsLeft
            // 
            this.labelDiscsLeft.AutoSize = true;
            this.labelDiscsLeft.BackColor = System.Drawing.Color.Transparent;
            this.labelDiscsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDiscsLeft.Location = new System.Drawing.Point(2, 19);
            this.labelDiscsLeft.Name = "labelDiscsLeft";
            this.labelDiscsLeft.Size = new System.Drawing.Size(148, 29);
            this.labelDiscsLeft.TabIndex = 1;
            this.labelDiscsLeft.Text = "Discs left: 21";
            // 
            // labelWinsLoses
            // 
            this.labelWinsLoses.AutoSize = true;
            this.labelWinsLoses.BackColor = System.Drawing.Color.Transparent;
            this.labelWinsLoses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelWinsLoses.Location = new System.Drawing.Point(2, 92);
            this.labelWinsLoses.Name = "labelWinsLoses";
            this.labelWinsLoses.Size = new System.Drawing.Size(121, 20);
            this.labelWinsLoses.TabIndex = 2;
            this.labelWinsLoses.Text = "Wins/Loses: 0/0";
            // 
            // labelGamesPlayed
            // 
            this.labelGamesPlayed.AutoSize = true;
            this.labelGamesPlayed.BackColor = System.Drawing.Color.Transparent;
            this.labelGamesPlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelGamesPlayed.Location = new System.Drawing.Point(2, 63);
            this.labelGamesPlayed.Name = "labelGamesPlayed";
            this.labelGamesPlayed.Size = new System.Drawing.Size(128, 20);
            this.labelGamesPlayed.TabIndex = 4;
            this.labelGamesPlayed.Text = "Games played: 0";
            // 
            // labelDraws
            // 
            this.labelDraws.AutoSize = true;
            this.labelDraws.BackColor = System.Drawing.Color.Transparent;
            this.labelDraws.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDraws.Location = new System.Drawing.Point(3, 148);
            this.labelDraws.Name = "labelDraws";
            this.labelDraws.Size = new System.Drawing.Size(71, 20);
            this.labelDraws.TabIndex = 5;
            this.labelDraws.Text = "Draws: 0";
            // 
            // labelWLRatio
            // 
            this.labelWLRatio.AutoSize = true;
            this.labelWLRatio.BackColor = System.Drawing.Color.Transparent;
            this.labelWLRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelWLRatio.Location = new System.Drawing.Point(2, 112);
            this.labelWLRatio.Name = "labelWLRatio";
            this.labelWLRatio.Size = new System.Drawing.Size(111, 20);
            this.labelWLRatio.TabIndex = 6;
            this.labelWLRatio.Text = "W/L ratio: 0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelDiscsLeft);
            this.panel1.Controls.Add(this.labelWinsLoses);
            this.panel1.Controls.Add(this.labelWLRatio);
            this.panel1.Controls.Add(this.labelGamesPlayed);
            this.panel1.Controls.Add(this.labelDraws);
            this.panel1.Location = new System.Drawing.Point(8, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 181);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 33F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-2, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 53);
            this.label2.TabIndex = 9;
            this.label2.Text = "4 In A Line";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1093, 687);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1109, 725);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1109, 725);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Four In A Line";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Top_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerMoveDown;
        private System.Windows.Forms.Timer timerMoveDownComputer;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelDiscsLeft;
        private System.Windows.Forms.Label labelWinsLoses;
        private System.Windows.Forms.Label labelGamesPlayed;
        private System.Windows.Forms.Label labelDraws;
        private System.Windows.Forms.Label labelWLRatio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;






    }
}

