namespace GoRacingIV
{
    partial class RacingForm
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
            this.offWeGo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnGO = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnReRun = new System.Windows.Forms.Button();
            this.r1Box = new System.Windows.Forms.GroupBox();
            this.r1Num = new System.Windows.Forms.Label();
            this.r1Time = new System.Windows.Forms.Label();
            this.r1Position = new System.Windows.Forms.Label();
            this.r1Car = new System.Windows.Forms.Label();
            this.r1Name = new System.Windows.Forms.Label();
            this.allStarted = new System.Windows.Forms.CheckBox();
            this.allFinished = new System.Windows.Forms.CheckBox();
            this.r2Box = new System.Windows.Forms.GroupBox();
            this.r2Num = new System.Windows.Forms.Label();
            this.r2Time = new System.Windows.Forms.Label();
            this.r2Position = new System.Windows.Forms.Label();
            this.r2Car = new System.Windows.Forms.Label();
            this.r2Name = new System.Windows.Forms.Label();
            this.r3Box = new System.Windows.Forms.GroupBox();
            this.r3Num = new System.Windows.Forms.Label();
            this.r3Time = new System.Windows.Forms.Label();
            this.r3Position = new System.Windows.Forms.Label();
            this.r3Car = new System.Windows.Forms.Label();
            this.r3Name = new System.Windows.Forms.Label();
            this.r4Box = new System.Windows.Forms.GroupBox();
            this.r4Num = new System.Windows.Forms.Label();
            this.r4Time = new System.Windows.Forms.Label();
            this.r4Position = new System.Windows.Forms.Label();
            this.r4Car = new System.Windows.Forms.Label();
            this.r4Name = new System.Windows.Forms.Label();
            this.r5Box = new System.Windows.Forms.GroupBox();
            this.r5Num = new System.Windows.Forms.Label();
            this.r5Time = new System.Windows.Forms.Label();
            this.r5Position = new System.Windows.Forms.Label();
            this.r5Car = new System.Windows.Forms.Label();
            this.r5Name = new System.Windows.Forms.Label();
            this.r6Box = new System.Windows.Forms.GroupBox();
            this.r6Num = new System.Windows.Forms.Label();
            this.r6Time = new System.Windows.Forms.Label();
            this.r6Position = new System.Windows.Forms.Label();
            this.r6Car = new System.Windows.Forms.Label();
            this.r6Name = new System.Windows.Forms.Label();
            this.realtimeCounter = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.betweenRaces = new System.Windows.Forms.Timer(this.components);
            this.warning = new System.Windows.Forms.Label();
            this.r1Box.SuspendLayout();
            this.r2Box.SuspendLayout();
            this.r3Box.SuspendLayout();
            this.r4Box.SuspendLayout();
            this.r5Box.SuspendLayout();
            this.r6Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // offWeGo
            // 
            this.offWeGo.AutoSize = true;
            this.offWeGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offWeGo.Location = new System.Drawing.Point(4, 9);
            this.offWeGo.Name = "offWeGo";
            this.offWeGo.Size = new System.Drawing.Size(351, 46);
            this.offWeGo.TabIndex = 0;
            this.offWeGo.Text = "Please get ready...";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 505);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(636, 505);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(91, 23);
            this.btnGO.TabIndex = 20;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(12, 505);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(91, 23);
            this.btnPrev.TabIndex = 21;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReRun
            // 
            this.btnReRun.Location = new System.Drawing.Point(109, 505);
            this.btnReRun.Name = "btnReRun";
            this.btnReRun.Size = new System.Drawing.Size(91, 23);
            this.btnReRun.TabIndex = 22;
            this.btnReRun.Text = "Re-Run Race";
            this.btnReRun.UseVisualStyleBackColor = true;
            this.btnReRun.Click += new System.EventHandler(this.button3_Click);
            // 
            // r1Box
            // 
            this.r1Box.BackColor = System.Drawing.Color.Red;
            this.r1Box.Controls.Add(this.r1Num);
            this.r1Box.Controls.Add(this.r1Time);
            this.r1Box.Controls.Add(this.r1Position);
            this.r1Box.Controls.Add(this.r1Car);
            this.r1Box.Controls.Add(this.r1Name);
            this.r1Box.Location = new System.Drawing.Point(12, 61);
            this.r1Box.Name = "r1Box";
            this.r1Box.Size = new System.Drawing.Size(715, 68);
            this.r1Box.TabIndex = 23;
            this.r1Box.TabStop = false;
            this.r1Box.Text = "Racer 1";
            // 
            // r1Num
            // 
            this.r1Num.AutoSize = true;
            this.r1Num.Location = new System.Drawing.Point(408, 17);
            this.r1Num.Name = "r1Num";
            this.r1Num.Size = new System.Drawing.Size(35, 13);
            this.r1Num.TabIndex = 4;
            this.r1Num.Text = "label1";
            this.r1Num.Visible = false;
            // 
            // r1Time
            // 
            this.r1Time.AutoSize = true;
            this.r1Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r1Time.Location = new System.Drawing.Point(484, 25);
            this.r1Time.Name = "r1Time";
            this.r1Time.Size = new System.Drawing.Size(84, 25);
            this.r1Time.TabIndex = 3;
            this.r1Time.Text = "00.000";
            // 
            // r1Position
            // 
            this.r1Position.AutoSize = true;
            this.r1Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r1Position.Location = new System.Drawing.Point(619, 25);
            this.r1Position.Name = "r1Position";
            this.r1Position.Size = new System.Drawing.Size(24, 25);
            this.r1Position.TabIndex = 2;
            this.r1Position.Text = "x";
            // 
            // r1Car
            // 
            this.r1Car.AutoSize = true;
            this.r1Car.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r1Car.Location = new System.Drawing.Point(253, 26);
            this.r1Car.Name = "r1Car";
            this.r1Car.Size = new System.Drawing.Size(118, 24);
            this.r1Car.TabIndex = 1;
            this.r1Car.Text = "Racer\'s car";
            // 
            // r1Name
            // 
            this.r1Name.AutoSize = true;
            this.r1Name.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r1Name.Location = new System.Drawing.Point(6, 26);
            this.r1Name.Name = "r1Name";
            this.r1Name.Size = new System.Drawing.Size(159, 24);
            this.r1Name.TabIndex = 0;
            this.r1Name.Text = "Racer in lane 1";
            // 
            // allStarted
            // 
            this.allStarted.AutoSize = true;
            this.allStarted.Location = new System.Drawing.Point(652, 9);
            this.allStarted.Name = "allStarted";
            this.allStarted.Size = new System.Drawing.Size(66, 17);
            this.allStarted.TabIndex = 24;
            this.allStarted.Text = "Start OK";
            this.allStarted.UseVisualStyleBackColor = true;
            // 
            // allFinished
            // 
            this.allFinished.AutoSize = true;
            this.allFinished.Location = new System.Drawing.Point(652, 32);
            this.allFinished.Name = "allFinished";
            this.allFinished.Size = new System.Drawing.Size(71, 17);
            this.allFinished.TabIndex = 25;
            this.allFinished.Text = "Finish OK";
            this.allFinished.UseVisualStyleBackColor = true;
            // 
            // r2Box
            // 
            this.r2Box.BackColor = System.Drawing.Color.Red;
            this.r2Box.Controls.Add(this.r2Num);
            this.r2Box.Controls.Add(this.r2Time);
            this.r2Box.Controls.Add(this.r2Position);
            this.r2Box.Controls.Add(this.r2Car);
            this.r2Box.Controls.Add(this.r2Name);
            this.r2Box.Location = new System.Drawing.Point(12, 135);
            this.r2Box.Name = "r2Box";
            this.r2Box.Size = new System.Drawing.Size(715, 68);
            this.r2Box.TabIndex = 26;
            this.r2Box.TabStop = false;
            this.r2Box.Text = "Racer 2";
            // 
            // r2Num
            // 
            this.r2Num.AutoSize = true;
            this.r2Num.Location = new System.Drawing.Point(408, 16);
            this.r2Num.Name = "r2Num";
            this.r2Num.Size = new System.Drawing.Size(35, 13);
            this.r2Num.TabIndex = 5;
            this.r2Num.Text = "label1";
            this.r2Num.Visible = false;
            // 
            // r2Time
            // 
            this.r2Time.AutoSize = true;
            this.r2Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r2Time.Location = new System.Drawing.Point(484, 25);
            this.r2Time.Name = "r2Time";
            this.r2Time.Size = new System.Drawing.Size(84, 25);
            this.r2Time.TabIndex = 4;
            this.r2Time.Text = "00.000";
            // 
            // r2Position
            // 
            this.r2Position.AutoSize = true;
            this.r2Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r2Position.Location = new System.Drawing.Point(619, 25);
            this.r2Position.Name = "r2Position";
            this.r2Position.Size = new System.Drawing.Size(24, 25);
            this.r2Position.TabIndex = 2;
            this.r2Position.Text = "x";
            // 
            // r2Car
            // 
            this.r2Car.AutoSize = true;
            this.r2Car.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r2Car.Location = new System.Drawing.Point(253, 26);
            this.r2Car.Name = "r2Car";
            this.r2Car.Size = new System.Drawing.Size(118, 24);
            this.r2Car.TabIndex = 1;
            this.r2Car.Text = "Racer\'s car";
            // 
            // r2Name
            // 
            this.r2Name.AutoSize = true;
            this.r2Name.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r2Name.Location = new System.Drawing.Point(6, 26);
            this.r2Name.Name = "r2Name";
            this.r2Name.Size = new System.Drawing.Size(159, 24);
            this.r2Name.TabIndex = 0;
            this.r2Name.Text = "Racer in lane 2";
            // 
            // r3Box
            // 
            this.r3Box.BackColor = System.Drawing.Color.Red;
            this.r3Box.Controls.Add(this.r3Num);
            this.r3Box.Controls.Add(this.r3Time);
            this.r3Box.Controls.Add(this.r3Position);
            this.r3Box.Controls.Add(this.r3Car);
            this.r3Box.Controls.Add(this.r3Name);
            this.r3Box.Location = new System.Drawing.Point(12, 209);
            this.r3Box.Name = "r3Box";
            this.r3Box.Size = new System.Drawing.Size(715, 68);
            this.r3Box.TabIndex = 27;
            this.r3Box.TabStop = false;
            this.r3Box.Text = "Racer 3";
            // 
            // r3Num
            // 
            this.r3Num.AutoSize = true;
            this.r3Num.Location = new System.Drawing.Point(408, 16);
            this.r3Num.Name = "r3Num";
            this.r3Num.Size = new System.Drawing.Size(35, 13);
            this.r3Num.TabIndex = 5;
            this.r3Num.Text = "label1";
            this.r3Num.Visible = false;
            // 
            // r3Time
            // 
            this.r3Time.AutoSize = true;
            this.r3Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r3Time.Location = new System.Drawing.Point(484, 26);
            this.r3Time.Name = "r3Time";
            this.r3Time.Size = new System.Drawing.Size(84, 25);
            this.r3Time.TabIndex = 4;
            this.r3Time.Text = "00.000";
            // 
            // r3Position
            // 
            this.r3Position.AutoSize = true;
            this.r3Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r3Position.Location = new System.Drawing.Point(619, 26);
            this.r3Position.Name = "r3Position";
            this.r3Position.Size = new System.Drawing.Size(24, 25);
            this.r3Position.TabIndex = 3;
            this.r3Position.Text = "x";
            // 
            // r3Car
            // 
            this.r3Car.AutoSize = true;
            this.r3Car.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r3Car.Location = new System.Drawing.Point(253, 27);
            this.r3Car.Name = "r3Car";
            this.r3Car.Size = new System.Drawing.Size(118, 24);
            this.r3Car.TabIndex = 1;
            this.r3Car.Text = "Racer\'s car";
            // 
            // r3Name
            // 
            this.r3Name.AutoSize = true;
            this.r3Name.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r3Name.Location = new System.Drawing.Point(6, 27);
            this.r3Name.Name = "r3Name";
            this.r3Name.Size = new System.Drawing.Size(159, 24);
            this.r3Name.TabIndex = 0;
            this.r3Name.Text = "Racer in lane 3";
            // 
            // r4Box
            // 
            this.r4Box.BackColor = System.Drawing.Color.Red;
            this.r4Box.Controls.Add(this.r4Num);
            this.r4Box.Controls.Add(this.r4Time);
            this.r4Box.Controls.Add(this.r4Position);
            this.r4Box.Controls.Add(this.r4Car);
            this.r4Box.Controls.Add(this.r4Name);
            this.r4Box.Location = new System.Drawing.Point(12, 283);
            this.r4Box.Name = "r4Box";
            this.r4Box.Size = new System.Drawing.Size(715, 68);
            this.r4Box.TabIndex = 28;
            this.r4Box.TabStop = false;
            this.r4Box.Text = "Racer 4";
            // 
            // r4Num
            // 
            this.r4Num.AutoSize = true;
            this.r4Num.Location = new System.Drawing.Point(408, 16);
            this.r4Num.Name = "r4Num";
            this.r4Num.Size = new System.Drawing.Size(35, 13);
            this.r4Num.TabIndex = 5;
            this.r4Num.Text = "label1";
            this.r4Num.Visible = false;
            // 
            // r4Time
            // 
            this.r4Time.AutoSize = true;
            this.r4Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r4Time.Location = new System.Drawing.Point(484, 25);
            this.r4Time.Name = "r4Time";
            this.r4Time.Size = new System.Drawing.Size(84, 25);
            this.r4Time.TabIndex = 4;
            this.r4Time.Text = "00.000";
            // 
            // r4Position
            // 
            this.r4Position.AutoSize = true;
            this.r4Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r4Position.Location = new System.Drawing.Point(619, 25);
            this.r4Position.Name = "r4Position";
            this.r4Position.Size = new System.Drawing.Size(24, 25);
            this.r4Position.TabIndex = 3;
            this.r4Position.Text = "x";
            // 
            // r4Car
            // 
            this.r4Car.AutoSize = true;
            this.r4Car.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r4Car.Location = new System.Drawing.Point(253, 26);
            this.r4Car.Name = "r4Car";
            this.r4Car.Size = new System.Drawing.Size(118, 24);
            this.r4Car.TabIndex = 1;
            this.r4Car.Text = "Racer\'s car";
            // 
            // r4Name
            // 
            this.r4Name.AutoSize = true;
            this.r4Name.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r4Name.Location = new System.Drawing.Point(6, 26);
            this.r4Name.Name = "r4Name";
            this.r4Name.Size = new System.Drawing.Size(159, 24);
            this.r4Name.TabIndex = 0;
            this.r4Name.Text = "Racer in lane 4";
            // 
            // r5Box
            // 
            this.r5Box.BackColor = System.Drawing.Color.Red;
            this.r5Box.Controls.Add(this.r5Num);
            this.r5Box.Controls.Add(this.r5Time);
            this.r5Box.Controls.Add(this.r5Position);
            this.r5Box.Controls.Add(this.r5Car);
            this.r5Box.Controls.Add(this.r5Name);
            this.r5Box.Location = new System.Drawing.Point(12, 357);
            this.r5Box.Name = "r5Box";
            this.r5Box.Size = new System.Drawing.Size(715, 68);
            this.r5Box.TabIndex = 29;
            this.r5Box.TabStop = false;
            this.r5Box.Text = "Racer 5";
            // 
            // r5Num
            // 
            this.r5Num.AutoSize = true;
            this.r5Num.Location = new System.Drawing.Point(408, 16);
            this.r5Num.Name = "r5Num";
            this.r5Num.Size = new System.Drawing.Size(35, 13);
            this.r5Num.TabIndex = 5;
            this.r5Num.Text = "label1";
            this.r5Num.Visible = false;
            // 
            // r5Time
            // 
            this.r5Time.AutoSize = true;
            this.r5Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r5Time.Location = new System.Drawing.Point(484, 25);
            this.r5Time.Name = "r5Time";
            this.r5Time.Size = new System.Drawing.Size(84, 25);
            this.r5Time.TabIndex = 4;
            this.r5Time.Text = "00.000";
            // 
            // r5Position
            // 
            this.r5Position.AutoSize = true;
            this.r5Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r5Position.Location = new System.Drawing.Point(619, 25);
            this.r5Position.Name = "r5Position";
            this.r5Position.Size = new System.Drawing.Size(24, 25);
            this.r5Position.TabIndex = 3;
            this.r5Position.Text = "x";
            // 
            // r5Car
            // 
            this.r5Car.AutoSize = true;
            this.r5Car.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r5Car.Location = new System.Drawing.Point(253, 26);
            this.r5Car.Name = "r5Car";
            this.r5Car.Size = new System.Drawing.Size(118, 24);
            this.r5Car.TabIndex = 1;
            this.r5Car.Text = "Racer\'s car";
            // 
            // r5Name
            // 
            this.r5Name.AutoSize = true;
            this.r5Name.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r5Name.Location = new System.Drawing.Point(6, 26);
            this.r5Name.Name = "r5Name";
            this.r5Name.Size = new System.Drawing.Size(159, 24);
            this.r5Name.TabIndex = 0;
            this.r5Name.Text = "Racer in lane 5";
            // 
            // r6Box
            // 
            this.r6Box.BackColor = System.Drawing.Color.Red;
            this.r6Box.Controls.Add(this.r6Num);
            this.r6Box.Controls.Add(this.r6Time);
            this.r6Box.Controls.Add(this.r6Position);
            this.r6Box.Controls.Add(this.r6Car);
            this.r6Box.Controls.Add(this.r6Name);
            this.r6Box.Location = new System.Drawing.Point(12, 431);
            this.r6Box.Name = "r6Box";
            this.r6Box.Size = new System.Drawing.Size(715, 68);
            this.r6Box.TabIndex = 30;
            this.r6Box.TabStop = false;
            this.r6Box.Text = "Racer 6";
            // 
            // r6Num
            // 
            this.r6Num.AutoSize = true;
            this.r6Num.Location = new System.Drawing.Point(408, 16);
            this.r6Num.Name = "r6Num";
            this.r6Num.Size = new System.Drawing.Size(35, 13);
            this.r6Num.TabIndex = 5;
            this.r6Num.Text = "label1";
            this.r6Num.Visible = false;
            // 
            // r6Time
            // 
            this.r6Time.AutoSize = true;
            this.r6Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r6Time.Location = new System.Drawing.Point(484, 25);
            this.r6Time.Name = "r6Time";
            this.r6Time.Size = new System.Drawing.Size(84, 25);
            this.r6Time.TabIndex = 4;
            this.r6Time.Text = "00.000";
            // 
            // r6Position
            // 
            this.r6Position.AutoSize = true;
            this.r6Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r6Position.Location = new System.Drawing.Point(619, 25);
            this.r6Position.Name = "r6Position";
            this.r6Position.Size = new System.Drawing.Size(24, 25);
            this.r6Position.TabIndex = 3;
            this.r6Position.Text = "x";
            // 
            // r6Car
            // 
            this.r6Car.AutoSize = true;
            this.r6Car.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r6Car.Location = new System.Drawing.Point(253, 26);
            this.r6Car.Name = "r6Car";
            this.r6Car.Size = new System.Drawing.Size(118, 24);
            this.r6Car.TabIndex = 1;
            this.r6Car.Text = "Racer\'s car";
            // 
            // r6Name
            // 
            this.r6Name.AutoSize = true;
            this.r6Name.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r6Name.Location = new System.Drawing.Point(6, 26);
            this.r6Name.Name = "r6Name";
            this.r6Name.Size = new System.Drawing.Size(159, 24);
            this.r6Name.TabIndex = 0;
            this.r6Name.Text = "Racer in lane 6";
            // 
            // realtimeCounter
            // 
            this.realtimeCounter.AutoSize = true;
            this.realtimeCounter.Location = new System.Drawing.Point(306, 510);
            this.realtimeCounter.Name = "realtimeCounter";
            this.realtimeCounter.Size = new System.Drawing.Size(0, 13);
            this.realtimeCounter.TabIndex = 31;
            // 
            // screenUpdater
            // 
            this.screenUpdater.Interval = 500;
            this.screenUpdater.Tick += new System.EventHandler(this.screenUpdater_Tick);
            // 
            // betweenRaces
            // 
            this.betweenRaces.Interval = 10000;
            this.betweenRaces.Tick += new System.EventHandler(this.betweenRaces_Tick);
            // 
            // warning
            // 
            this.warning.AutoSize = true;
            this.warning.Location = new System.Drawing.Point(420, 510);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(0, 13);
            this.warning.TabIndex = 32;
            // 
            // RacingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(739, 536);
            this.Controls.Add(this.warning);
            this.Controls.Add(this.realtimeCounter);
            this.Controls.Add(this.r6Box);
            this.Controls.Add(this.r5Box);
            this.Controls.Add(this.r4Box);
            this.Controls.Add(this.r3Box);
            this.Controls.Add(this.r2Box);
            this.Controls.Add(this.allFinished);
            this.Controls.Add(this.allStarted);
            this.Controls.Add(this.r1Box);
            this.Controls.Add(this.btnReRun);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.offWeGo);
            this.Name = "RacingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RacingForm";
            this.Load += new System.EventHandler(this.RacingForm_Load);
            this.r1Box.ResumeLayout(false);
            this.r1Box.PerformLayout();
            this.r2Box.ResumeLayout(false);
            this.r2Box.PerformLayout();
            this.r3Box.ResumeLayout(false);
            this.r3Box.PerformLayout();
            this.r4Box.ResumeLayout(false);
            this.r4Box.PerformLayout();
            this.r5Box.ResumeLayout(false);
            this.r5Box.PerformLayout();
            this.r6Box.ResumeLayout(false);
            this.r6Box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label offWeGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnReRun;
        private System.Windows.Forms.GroupBox r1Box;
        private System.Windows.Forms.CheckBox allStarted;
        private System.Windows.Forms.CheckBox allFinished;
        private System.Windows.Forms.Label r1Car;
        private System.Windows.Forms.Label r1Name;
        private System.Windows.Forms.GroupBox r2Box;
        private System.Windows.Forms.Label r2Car;
        private System.Windows.Forms.Label r2Name;
        private System.Windows.Forms.GroupBox r3Box;
        private System.Windows.Forms.Label r3Car;
        private System.Windows.Forms.Label r3Name;
        private System.Windows.Forms.GroupBox r4Box;
        private System.Windows.Forms.Label r4Car;
        private System.Windows.Forms.Label r4Name;
        private System.Windows.Forms.GroupBox r5Box;
        private System.Windows.Forms.Label r5Car;
        private System.Windows.Forms.Label r5Name;
        private System.Windows.Forms.GroupBox r6Box;
        private System.Windows.Forms.Label r6Car;
        private System.Windows.Forms.Label r6Name;
        private System.Windows.Forms.Label r1Position;
        private System.Windows.Forms.Label r2Position;
        private System.Windows.Forms.Label r3Position;
        private System.Windows.Forms.Label r4Position;
        private System.Windows.Forms.Label r5Position;
        private System.Windows.Forms.Label r6Position;
        private System.Windows.Forms.Label realtimeCounter;
        private System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.Label r1Time;
        private System.Windows.Forms.Label r2Time;
        private System.Windows.Forms.Label r3Time;
        private System.Windows.Forms.Label r4Time;
        private System.Windows.Forms.Label r5Time;
        private System.Windows.Forms.Label r6Time;
        private System.Windows.Forms.Timer betweenRaces;
        private System.Windows.Forms.Label r1Num;
        private System.Windows.Forms.Label r2Num;
        private System.Windows.Forms.Label r3Num;
        private System.Windows.Forms.Label r4Num;
        private System.Windows.Forms.Label r5Num;
        private System.Windows.Forms.Label r6Num;
        private System.Windows.Forms.Label warning;
    }
}