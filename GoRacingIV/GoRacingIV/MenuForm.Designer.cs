namespace GoRacingIV
{
    partial class frmMenu
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
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnCompetitors = new System.Windows.Forms.Button();
            this.btnRace = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lSetup = new System.Windows.Forms.Label();
            this.lCompetitors = new System.Windows.Forms.Label();
            this.lRace = new System.Windows.Forms.Label();
            this.lResults = new System.Windows.Forms.Label();
            this.lExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(12, 12);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 40);
            this.btnSetup.TabIndex = 0;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnCompetitors
            // 
            this.btnCompetitors.Location = new System.Drawing.Point(12, 58);
            this.btnCompetitors.Name = "btnCompetitors";
            this.btnCompetitors.Size = new System.Drawing.Size(75, 40);
            this.btnCompetitors.TabIndex = 1;
            this.btnCompetitors.Text = "Competitors";
            this.btnCompetitors.UseVisualStyleBackColor = true;
            this.btnCompetitors.Click += new System.EventHandler(this.btnCompetitors_Click);
            // 
            // btnRace
            // 
            this.btnRace.Location = new System.Drawing.Point(12, 104);
            this.btnRace.Name = "btnRace";
            this.btnRace.Size = new System.Drawing.Size(75, 40);
            this.btnRace.TabIndex = 2;
            this.btnRace.Text = "RACE!";
            this.btnRace.UseVisualStyleBackColor = true;
            this.btnRace.Click += new System.EventHandler(this.btnRace_Click);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(12, 150);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(75, 40);
            this.btnResults.TabIndex = 3;
            this.btnResults.Text = "Results";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 196);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lSetup
            // 
            this.lSetup.AutoSize = true;
            this.lSetup.Location = new System.Drawing.Point(93, 26);
            this.lSetup.Name = "lSetup";
            this.lSetup.Size = new System.Drawing.Size(170, 13);
            this.lSetup.TabIndex = 5;
            this.lSetup.Text = "Use this wizard to set up the track.";
            // 
            // lCompetitors
            // 
            this.lCompetitors.AutoSize = true;
            this.lCompetitors.Location = new System.Drawing.Point(94, 72);
            this.lCompetitors.Name = "lCompetitors";
            this.lCompetitors.Size = new System.Drawing.Size(238, 13);
            this.lCompetitors.TabIndex = 6;
            this.lCompetitors.Text = "Use this wizard to set up competitors and groups.";
            // 
            // lRace
            // 
            this.lRace.AutoSize = true;
            this.lRace.Location = new System.Drawing.Point(93, 118);
            this.lRace.Name = "lRace";
            this.lRace.Size = new System.Drawing.Size(246, 13);
            this.lRace.TabIndex = 7;
            this.lRace.Text = "When you\'re finished with the setup - Start Racing!";
            // 
            // lResults
            // 
            this.lResults.AutoSize = true;
            this.lResults.Location = new System.Drawing.Point(94, 164);
            this.lResults.Name = "lResults";
            this.lResults.Size = new System.Drawing.Size(209, 13);
            this.lResults.TabIndex = 8;
            this.lResults.Text = "You may want to know who actually won...";
            // 
            // lExit
            // 
            this.lExit.AutoSize = true;
            this.lExit.Location = new System.Drawing.Point(94, 210);
            this.lExit.Name = "lExit";
            this.lExit.Size = new System.Drawing.Size(143, 13);
            this.lExit.TabIndex = 9;
            this.lExit.Text = "And then there\'s resting time!";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(367, 251);
            this.Controls.Add(this.lExit);
            this.Controls.Add(this.lResults);
            this.Controls.Add(this.lRace);
            this.Controls.Add(this.lCompetitors);
            this.Controls.Add(this.lSetup);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnRace);
            this.Controls.Add(this.btnCompetitors);
            this.Controls.Add(this.btnSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Go Racing IV";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnCompetitors;
        private System.Windows.Forms.Button btnRace;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lSetup;
        private System.Windows.Forms.Label lCompetitors;
        private System.Windows.Forms.Label lRace;
        private System.Windows.Forms.Label lResults;
        private System.Windows.Forms.Label lExit;
    }
}

