namespace GoRacingIV
{
    partial class frmSetupWizard
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
            this.numLines = new System.Windows.Forms.NumericUpDown();
            this.lNumLanes = new System.Windows.Forms.Label();
            this.btnLineState1 = new System.Windows.Forms.Button();
            this.btnLineState2 = new System.Windows.Forms.Button();
            this.btnLineState3 = new System.Windows.Forms.Button();
            this.btnLineState4 = new System.Windows.Forms.Button();
            this.btnLineState5 = new System.Windows.Forms.Button();
            this.btnLineState6 = new System.Windows.Forms.Button();
            this.btnLineState7 = new System.Windows.Forms.Button();
            this.btnLineState8 = new System.Windows.Forms.Button();
            this.lLaneStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.laneType1 = new System.Windows.Forms.ComboBox();
            this.laneType2 = new System.Windows.Forms.ComboBox();
            this.laneType3 = new System.Windows.Forms.ComboBox();
            this.laneType4 = new System.Windows.Forms.ComboBox();
            this.laneType5 = new System.Windows.Forms.ComboBox();
            this.laneType6 = new System.Windows.Forms.ComboBox();
            this.laneType7 = new System.Windows.Forms.ComboBox();
            this.laneType8 = new System.Windows.Forms.ComboBox();
            this.lColours = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.timerTester = new System.Windows.Forms.Timer(this.components);
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnStopTest = new System.Windows.Forms.Button();
            this.txtLptData = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.laneColor1 = new System.Windows.Forms.Button();
            this.laneColor2 = new System.Windows.Forms.Button();
            this.laneColor3 = new System.Windows.Forms.Button();
            this.laneColor4 = new System.Windows.Forms.Button();
            this.laneColor5 = new System.Windows.Forms.Button();
            this.laneColor6 = new System.Windows.Forms.Button();
            this.laneColor7 = new System.Windows.Forms.Button();
            this.laneColor8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bitLine1 = new System.Windows.Forms.NumericUpDown();
            this.bitLine2 = new System.Windows.Forms.NumericUpDown();
            this.bitLine3 = new System.Windows.Forms.NumericUpDown();
            this.bitLine4 = new System.Windows.Forms.NumericUpDown();
            this.bitLine5 = new System.Windows.Forms.NumericUpDown();
            this.bitLine6 = new System.Windows.Forms.NumericUpDown();
            this.bitLine7 = new System.Windows.Forms.NumericUpDown();
            this.bitLine8 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTestRace = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine8)).BeginInit();
            this.SuspendLayout();
            // 
            // numLines
            // 
            this.numLines.Location = new System.Drawing.Point(97, 27);
            this.numLines.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numLines.Name = "numLines";
            this.numLines.Size = new System.Drawing.Size(38, 20);
            this.numLines.TabIndex = 0;
            this.numLines.ValueChanged += new System.EventHandler(this.numLanes_ValueChanged);
            // 
            // lNumLanes
            // 
            this.lNumLanes.AutoSize = true;
            this.lNumLanes.Location = new System.Drawing.Point(13, 29);
            this.lNumLanes.Name = "lNumLanes";
            this.lNumLanes.Size = new System.Drawing.Size(61, 13);
            this.lNumLanes.TabIndex = 1;
            this.lNumLanes.Text = "Data Lines:";
            // 
            // btnLineState1
            // 
            this.btnLineState1.Location = new System.Drawing.Point(155, 27);
            this.btnLineState1.Name = "btnLineState1";
            this.btnLineState1.Size = new System.Drawing.Size(42, 42);
            this.btnLineState1.TabIndex = 2;
            this.btnLineState1.Text = "Lane 1";
            this.btnLineState1.UseVisualStyleBackColor = true;
            this.btnLineState1.Click += new System.EventHandler(this.btnLineState1_Click);
            // 
            // btnLineState2
            // 
            this.btnLineState2.Location = new System.Drawing.Point(203, 27);
            this.btnLineState2.Name = "btnLineState2";
            this.btnLineState2.Size = new System.Drawing.Size(42, 42);
            this.btnLineState2.TabIndex = 3;
            this.btnLineState2.Text = "Lane 2";
            this.btnLineState2.UseVisualStyleBackColor = true;
            this.btnLineState2.Click += new System.EventHandler(this.btnLineState2_Click);
            // 
            // btnLineState3
            // 
            this.btnLineState3.Location = new System.Drawing.Point(251, 27);
            this.btnLineState3.Name = "btnLineState3";
            this.btnLineState3.Size = new System.Drawing.Size(42, 42);
            this.btnLineState3.TabIndex = 4;
            this.btnLineState3.Text = "Lane 3";
            this.btnLineState3.UseVisualStyleBackColor = true;
            this.btnLineState3.Click += new System.EventHandler(this.btnLineState3_Click);
            // 
            // btnLineState4
            // 
            this.btnLineState4.Location = new System.Drawing.Point(299, 27);
            this.btnLineState4.Name = "btnLineState4";
            this.btnLineState4.Size = new System.Drawing.Size(42, 42);
            this.btnLineState4.TabIndex = 5;
            this.btnLineState4.Text = "Lane 4";
            this.btnLineState4.UseVisualStyleBackColor = true;
            this.btnLineState4.Click += new System.EventHandler(this.btnLineState4_Click);
            // 
            // btnLineState5
            // 
            this.btnLineState5.Location = new System.Drawing.Point(347, 27);
            this.btnLineState5.Name = "btnLineState5";
            this.btnLineState5.Size = new System.Drawing.Size(42, 42);
            this.btnLineState5.TabIndex = 6;
            this.btnLineState5.Text = "Lane 5";
            this.btnLineState5.UseVisualStyleBackColor = true;
            this.btnLineState5.Click += new System.EventHandler(this.btnLineState5_Click);
            // 
            // btnLineState6
            // 
            this.btnLineState6.Location = new System.Drawing.Point(395, 27);
            this.btnLineState6.Name = "btnLineState6";
            this.btnLineState6.Size = new System.Drawing.Size(42, 42);
            this.btnLineState6.TabIndex = 7;
            this.btnLineState6.Text = "Lane 6";
            this.btnLineState6.UseVisualStyleBackColor = true;
            this.btnLineState6.Click += new System.EventHandler(this.btnLineState6_Click);
            // 
            // btnLineState7
            // 
            this.btnLineState7.Location = new System.Drawing.Point(443, 27);
            this.btnLineState7.Name = "btnLineState7";
            this.btnLineState7.Size = new System.Drawing.Size(42, 42);
            this.btnLineState7.TabIndex = 8;
            this.btnLineState7.Text = "Lane 7";
            this.btnLineState7.UseVisualStyleBackColor = true;
            this.btnLineState7.Click += new System.EventHandler(this.btnLineState7_Click);
            // 
            // btnLineState8
            // 
            this.btnLineState8.Location = new System.Drawing.Point(491, 27);
            this.btnLineState8.Name = "btnLineState8";
            this.btnLineState8.Size = new System.Drawing.Size(42, 42);
            this.btnLineState8.TabIndex = 9;
            this.btnLineState8.Text = "Lane 8";
            this.btnLineState8.UseVisualStyleBackColor = true;
            this.btnLineState8.Click += new System.EventHandler(this.btnLineState8_Click);
            // 
            // lLaneStatus
            // 
            this.lLaneStatus.AutoSize = true;
            this.lLaneStatus.Location = new System.Drawing.Point(13, 56);
            this.lLaneStatus.Name = "lLaneStatus";
            this.lLaneStatus.Size = new System.Drawing.Size(128, 13);
            this.lLaneStatus.TabIndex = 10;
            this.lLaneStatus.Text = "Status of Lane Data Line:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Data Line Assignments:";
            // 
            // laneType1
            // 
            this.laneType1.FormattingEnabled = true;
            this.laneType1.Items.AddRange(new object[] {
            "--",
            "SS",
            "SG",
            "FG"});
            this.laneType1.Location = new System.Drawing.Point(155, 76);
            this.laneType1.Name = "laneType1";
            this.laneType1.Size = new System.Drawing.Size(42, 21);
            this.laneType1.TabIndex = 12;
            this.laneType1.SelectedIndexChanged += new System.EventHandler(this.laneType1_SelectedIndexChanged);
            // 
            // laneType2
            // 
            this.laneType2.FormattingEnabled = true;
            this.laneType2.Items.AddRange(new object[] {
            "--",
            "SG",
            "FG"});
            this.laneType2.Location = new System.Drawing.Point(203, 76);
            this.laneType2.Name = "laneType2";
            this.laneType2.Size = new System.Drawing.Size(42, 21);
            this.laneType2.TabIndex = 13;
            this.laneType2.SelectedIndexChanged += new System.EventHandler(this.laneType2_SelectedIndexChanged);
            // 
            // laneType3
            // 
            this.laneType3.FormattingEnabled = true;
            this.laneType3.Items.AddRange(new object[] {
            "--",
            "FG"});
            this.laneType3.Location = new System.Drawing.Point(251, 76);
            this.laneType3.Name = "laneType3";
            this.laneType3.Size = new System.Drawing.Size(42, 21);
            this.laneType3.TabIndex = 14;
            this.laneType3.SelectedIndexChanged += new System.EventHandler(this.laneType3_SelectedIndexChanged);
            // 
            // laneType4
            // 
            this.laneType4.FormattingEnabled = true;
            this.laneType4.Items.AddRange(new object[] {
            "--",
            "FG"});
            this.laneType4.Location = new System.Drawing.Point(299, 76);
            this.laneType4.Name = "laneType4";
            this.laneType4.Size = new System.Drawing.Size(42, 21);
            this.laneType4.TabIndex = 15;
            this.laneType4.SelectedIndexChanged += new System.EventHandler(this.laneType4_SelectedIndexChanged);
            // 
            // laneType5
            // 
            this.laneType5.FormattingEnabled = true;
            this.laneType5.Items.AddRange(new object[] {
            "--",
            "FG"});
            this.laneType5.Location = new System.Drawing.Point(347, 76);
            this.laneType5.Name = "laneType5";
            this.laneType5.Size = new System.Drawing.Size(42, 21);
            this.laneType5.TabIndex = 16;
            this.laneType5.SelectedIndexChanged += new System.EventHandler(this.laneType5_SelectedIndexChanged);
            // 
            // laneType6
            // 
            this.laneType6.FormattingEnabled = true;
            this.laneType6.Items.AddRange(new object[] {
            "--",
            "FG"});
            this.laneType6.Location = new System.Drawing.Point(395, 76);
            this.laneType6.Name = "laneType6";
            this.laneType6.Size = new System.Drawing.Size(42, 21);
            this.laneType6.TabIndex = 17;
            this.laneType6.SelectedIndexChanged += new System.EventHandler(this.laneType6_SelectedIndexChanged);
            // 
            // laneType7
            // 
            this.laneType7.FormattingEnabled = true;
            this.laneType7.Items.AddRange(new object[] {
            "--",
            "FG"});
            this.laneType7.Location = new System.Drawing.Point(443, 76);
            this.laneType7.Name = "laneType7";
            this.laneType7.Size = new System.Drawing.Size(42, 21);
            this.laneType7.TabIndex = 18;
            this.laneType7.SelectedIndexChanged += new System.EventHandler(this.laneType7_SelectedIndexChanged);
            // 
            // laneType8
            // 
            this.laneType8.FormattingEnabled = true;
            this.laneType8.Items.AddRange(new object[] {
            "--",
            "FG"});
            this.laneType8.Location = new System.Drawing.Point(491, 76);
            this.laneType8.Name = "laneType8";
            this.laneType8.Size = new System.Drawing.Size(42, 21);
            this.laneType8.TabIndex = 19;
            this.laneType8.SelectedIndexChanged += new System.EventHandler(this.laneType8_SelectedIndexChanged);
            // 
            // lColours
            // 
            this.lColours.AutoSize = true;
            this.lColours.Location = new System.Drawing.Point(13, 106);
            this.lColours.Name = "lColours";
            this.lColours.Size = new System.Drawing.Size(72, 13);
            this.lColours.TabIndex = 20;
            this.lColours.Text = "Lane Colours:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(461, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(380, 298);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timerTester
            // 
            this.timerTester.Interval = 250;
            this.timerTester.Tick += new System.EventHandler(this.timerTester_Tick);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(8, 298);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 32;
            this.btnStartTest.Text = "Start Testing";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnStopTest
            // 
            this.btnStopTest.Location = new System.Drawing.Point(170, 298);
            this.btnStopTest.Name = "btnStopTest";
            this.btnStopTest.Size = new System.Drawing.Size(75, 23);
            this.btnStopTest.TabIndex = 33;
            this.btnStopTest.Text = "Stop Testing";
            this.btnStopTest.UseVisualStyleBackColor = true;
            this.btnStopTest.Click += new System.EventHandler(this.btnStopTest_Click);
            // 
            // txtLptData
            // 
            this.txtLptData.Location = new System.Drawing.Point(488, 161);
            this.txtLptData.Name = "txtLptData";
            this.txtLptData.Size = new System.Drawing.Size(45, 20);
            this.txtLptData.TabIndex = 34;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            // 
            // laneColor1
            // 
            this.laneColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor1.Location = new System.Drawing.Point(155, 103);
            this.laneColor1.Name = "laneColor1";
            this.laneColor1.Size = new System.Drawing.Size(42, 23);
            this.laneColor1.TabIndex = 40;
            this.laneColor1.Text = "Color";
            this.laneColor1.UseVisualStyleBackColor = false;
            this.laneColor1.Click += new System.EventHandler(this.laneColor1_Click);
            // 
            // laneColor2
            // 
            this.laneColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor2.Location = new System.Drawing.Point(203, 103);
            this.laneColor2.Name = "laneColor2";
            this.laneColor2.Size = new System.Drawing.Size(42, 23);
            this.laneColor2.TabIndex = 41;
            this.laneColor2.Text = "Color";
            this.laneColor2.UseVisualStyleBackColor = false;
            this.laneColor2.Click += new System.EventHandler(this.laneColor2_Click);
            // 
            // laneColor3
            // 
            this.laneColor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor3.Location = new System.Drawing.Point(251, 103);
            this.laneColor3.Name = "laneColor3";
            this.laneColor3.Size = new System.Drawing.Size(42, 23);
            this.laneColor3.TabIndex = 42;
            this.laneColor3.Text = "Color";
            this.laneColor3.UseVisualStyleBackColor = false;
            this.laneColor3.Click += new System.EventHandler(this.laneColor3_Click);
            // 
            // laneColor4
            // 
            this.laneColor4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor4.Location = new System.Drawing.Point(299, 103);
            this.laneColor4.Name = "laneColor4";
            this.laneColor4.Size = new System.Drawing.Size(42, 23);
            this.laneColor4.TabIndex = 43;
            this.laneColor4.Text = "Color";
            this.laneColor4.UseVisualStyleBackColor = false;
            this.laneColor4.Click += new System.EventHandler(this.laneColor4_Click);
            // 
            // laneColor5
            // 
            this.laneColor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor5.Location = new System.Drawing.Point(347, 103);
            this.laneColor5.Name = "laneColor5";
            this.laneColor5.Size = new System.Drawing.Size(42, 23);
            this.laneColor5.TabIndex = 44;
            this.laneColor5.Text = "Color";
            this.laneColor5.UseVisualStyleBackColor = false;
            this.laneColor5.Click += new System.EventHandler(this.laneColor5_Click);
            // 
            // laneColor6
            // 
            this.laneColor6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor6.Location = new System.Drawing.Point(395, 103);
            this.laneColor6.Name = "laneColor6";
            this.laneColor6.Size = new System.Drawing.Size(42, 23);
            this.laneColor6.TabIndex = 45;
            this.laneColor6.Text = "Color";
            this.laneColor6.UseVisualStyleBackColor = false;
            this.laneColor6.Click += new System.EventHandler(this.laneColor6_Click);
            // 
            // laneColor7
            // 
            this.laneColor7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor7.Location = new System.Drawing.Point(443, 103);
            this.laneColor7.Name = "laneColor7";
            this.laneColor7.Size = new System.Drawing.Size(42, 23);
            this.laneColor7.TabIndex = 46;
            this.laneColor7.Text = "Color";
            this.laneColor7.UseVisualStyleBackColor = false;
            this.laneColor7.Click += new System.EventHandler(this.laneColor7_Click);
            // 
            // laneColor8
            // 
            this.laneColor8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.laneColor8.Location = new System.Drawing.Point(491, 103);
            this.laneColor8.Name = "laneColor8";
            this.laneColor8.Size = new System.Drawing.Size(42, 23);
            this.laneColor8.TabIndex = 47;
            this.laneColor8.Text = "Color";
            this.laneColor8.UseVisualStyleBackColor = false;
            this.laneColor8.Click += new System.EventHandler(this.laneColor8_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Instructions:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "1. Ensure the start gate is closed (if used) and that the finish gate is clear.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(443, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "3. Click on each of the buttons that shows up as RED. They should all be green to" +
                " start with.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(508, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "4. Test each finish gate to make sure the button turns RED when triggered. Also d" +
                "o this with the start gate.";
            // 
            // bitLine1
            // 
            this.bitLine1.Location = new System.Drawing.Point(155, 132);
            this.bitLine1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine1.Name = "bitLine1";
            this.bitLine1.Size = new System.Drawing.Size(42, 20);
            this.bitLine1.TabIndex = 52;
            this.bitLine1.ValueChanged += new System.EventHandler(this.bitLine1_ValueChanged);
            // 
            // bitLine2
            // 
            this.bitLine2.Location = new System.Drawing.Point(203, 132);
            this.bitLine2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine2.Name = "bitLine2";
            this.bitLine2.Size = new System.Drawing.Size(42, 20);
            this.bitLine2.TabIndex = 53;
            this.bitLine2.ValueChanged += new System.EventHandler(this.bitLine2_ValueChanged);
            // 
            // bitLine3
            // 
            this.bitLine3.Location = new System.Drawing.Point(251, 132);
            this.bitLine3.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine3.Name = "bitLine3";
            this.bitLine3.Size = new System.Drawing.Size(42, 20);
            this.bitLine3.TabIndex = 54;
            this.bitLine3.ValueChanged += new System.EventHandler(this.bitLine3_ValueChanged);
            // 
            // bitLine4
            // 
            this.bitLine4.Location = new System.Drawing.Point(299, 132);
            this.bitLine4.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine4.Name = "bitLine4";
            this.bitLine4.Size = new System.Drawing.Size(42, 20);
            this.bitLine4.TabIndex = 55;
            this.bitLine4.ValueChanged += new System.EventHandler(this.bitLine4_ValueChanged);
            // 
            // bitLine5
            // 
            this.bitLine5.Location = new System.Drawing.Point(347, 132);
            this.bitLine5.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine5.Name = "bitLine5";
            this.bitLine5.Size = new System.Drawing.Size(42, 20);
            this.bitLine5.TabIndex = 56;
            this.bitLine5.ValueChanged += new System.EventHandler(this.bitLine5_ValueChanged);
            // 
            // bitLine6
            // 
            this.bitLine6.Location = new System.Drawing.Point(395, 132);
            this.bitLine6.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine6.Name = "bitLine6";
            this.bitLine6.Size = new System.Drawing.Size(42, 20);
            this.bitLine6.TabIndex = 57;
            this.bitLine6.ValueChanged += new System.EventHandler(this.bitLine6_ValueChanged);
            // 
            // bitLine7
            // 
            this.bitLine7.Location = new System.Drawing.Point(443, 132);
            this.bitLine7.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine7.Name = "bitLine7";
            this.bitLine7.Size = new System.Drawing.Size(42, 20);
            this.bitLine7.TabIndex = 58;
            this.bitLine7.ValueChanged += new System.EventHandler(this.bitLine7_ValueChanged);
            // 
            // bitLine8
            // 
            this.bitLine8.Location = new System.Drawing.Point(491, 132);
            this.bitLine8.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.bitLine8.Name = "bitLine8";
            this.bitLine8.Size = new System.Drawing.Size(42, 20);
            this.bitLine8.TabIndex = 59;
            this.bitLine8.ValueChanged += new System.EventHandler(this.bitLine8_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "2. Change the bit numbers to match your hardware";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Bit Numbers:";
            // 
            // btnTestRace
            // 
            this.btnTestRace.Location = new System.Drawing.Point(89, 298);
            this.btnTestRace.Name = "btnTestRace";
            this.btnTestRace.Size = new System.Drawing.Size(75, 23);
            this.btnTestRace.TabIndex = 62;
            this.btnTestRace.Text = "Test Race";
            this.btnTestRace.UseVisualStyleBackColor = true;
            this.btnTestRace.Click += new System.EventHandler(this.btnTestRace_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "5. Finally press Test Race to simulate a race";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Race Track Setup";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 65;
            this.button1.Text = "Race Timing";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSetupWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(547, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnTestRace);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bitLine8);
            this.Controls.Add(this.bitLine7);
            this.Controls.Add(this.bitLine6);
            this.Controls.Add(this.bitLine5);
            this.Controls.Add(this.bitLine4);
            this.Controls.Add(this.bitLine3);
            this.Controls.Add(this.bitLine2);
            this.Controls.Add(this.bitLine1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.laneColor8);
            this.Controls.Add(this.laneColor7);
            this.Controls.Add(this.laneColor6);
            this.Controls.Add(this.laneColor5);
            this.Controls.Add(this.laneColor4);
            this.Controls.Add(this.laneColor3);
            this.Controls.Add(this.laneColor2);
            this.Controls.Add(this.laneColor1);
            this.Controls.Add(this.txtLptData);
            this.Controls.Add(this.btnStopTest);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lColours);
            this.Controls.Add(this.laneType8);
            this.Controls.Add(this.laneType7);
            this.Controls.Add(this.laneType6);
            this.Controls.Add(this.laneType5);
            this.Controls.Add(this.laneType4);
            this.Controls.Add(this.laneType3);
            this.Controls.Add(this.laneType2);
            this.Controls.Add(this.laneType1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lLaneStatus);
            this.Controls.Add(this.btnLineState8);
            this.Controls.Add(this.btnLineState7);
            this.Controls.Add(this.btnLineState6);
            this.Controls.Add(this.btnLineState5);
            this.Controls.Add(this.btnLineState4);
            this.Controls.Add(this.btnLineState3);
            this.Controls.Add(this.btnLineState2);
            this.Controls.Add(this.btnLineState1);
            this.Controls.Add(this.lNumLanes);
            this.Controls.Add(this.numLines);
            this.Name = "frmSetupWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Wizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetupWizard_FormClosing);
            this.Load += new System.EventHandler(this.frmSetupWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitLine8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numLines;
        private System.Windows.Forms.Label lNumLanes;
        private System.Windows.Forms.Button btnLineState1;
        private System.Windows.Forms.Button btnLineState2;
        private System.Windows.Forms.Button btnLineState3;
        private System.Windows.Forms.Button btnLineState4;
        private System.Windows.Forms.Button btnLineState5;
        private System.Windows.Forms.Button btnLineState6;
        private System.Windows.Forms.Button btnLineState7;
        private System.Windows.Forms.Button btnLineState8;
        private System.Windows.Forms.Label lLaneStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox laneType1;
        private System.Windows.Forms.ComboBox laneType2;
        private System.Windows.Forms.ComboBox laneType3;
        private System.Windows.Forms.ComboBox laneType4;
        private System.Windows.Forms.ComboBox laneType5;
        private System.Windows.Forms.ComboBox laneType6;
        private System.Windows.Forms.ComboBox laneType7;
        private System.Windows.Forms.ComboBox laneType8;
        private System.Windows.Forms.Label lColours;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Timer timerTester;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnStopTest;
        private System.Windows.Forms.TextBox txtLptData;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button laneColor1;
        private System.Windows.Forms.Button laneColor2;
        private System.Windows.Forms.Button laneColor3;
        private System.Windows.Forms.Button laneColor4;
        private System.Windows.Forms.Button laneColor5;
        private System.Windows.Forms.Button laneColor6;
        private System.Windows.Forms.Button laneColor7;
        private System.Windows.Forms.Button laneColor8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bitLine1;
        private System.Windows.Forms.NumericUpDown bitLine2;
        private System.Windows.Forms.NumericUpDown bitLine3;
        private System.Windows.Forms.NumericUpDown bitLine4;
        private System.Windows.Forms.NumericUpDown bitLine5;
        private System.Windows.Forms.NumericUpDown bitLine6;
        private System.Windows.Forms.NumericUpDown bitLine7;
        private System.Windows.Forms.NumericUpDown bitLine8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTestRace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}