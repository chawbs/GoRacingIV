using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using inpoutclass;

namespace GoRacingIV
{
    public partial class frmSetupWizard : Form
    {
        private static string component = "SetupForm";

        private int visibleLanes = 0;
        private int visibleStart = 0;
        private int visibleSolenoid = 0;
        private Boolean mustDoChanges = true;

        Button[] Lane = new Button[6];
        Button Start = null;
        Button Solenoid = null;

        public frmSetupWizard()
        {
            InitializeComponent();
        }

        private void LaneState(int bit, bool hide)
        {
            switch (bit)
            {
                case 0:
                    btnLineState1.Visible = hide;
                    laneType1.Visible = hide;
                    laneColor1.Visible = hide;
                    bitLine1.Visible = hide;
                    break;
                case 1:
                    btnLineState2.Visible = hide;
                    laneType2.Visible = hide;
                    laneColor2.Visible = hide;
                    bitLine2.Visible = hide;
                    break;
                case 2:
                    btnLineState3.Visible = hide;
                    laneType3.Visible = hide;
                    laneColor3.Visible = hide;
                    bitLine3.Visible = hide;
                    break;
                case 3:
                    btnLineState4.Visible = hide;
                    laneType4.Visible = hide;
                    laneColor4.Visible = hide;
                    bitLine4.Visible = hide;
                    break;
                case 4:
                    btnLineState5.Visible = hide;
                    laneType5.Visible = hide;
                    laneColor5.Visible = hide;
                    bitLine5.Visible = hide;
                    break;
                case 5:
                    btnLineState6.Visible = hide;
                    laneType6.Visible = hide;
                    laneColor6.Visible = hide;
                    bitLine6.Visible = hide;
                    break;
                case 6:
                    btnLineState7.Visible = hide;
                    laneType7.Visible = hide;
                    laneColor7.Visible = hide;
                    bitLine7.Visible = hide;
                    break;
                case 7:
                    btnLineState8.Visible = hide;
                    laneType8.Visible = hide;
                    laneColor8.Visible = hide;
                    bitLine8.Visible = hide;
                    break;
                default:
                    Program.log.fatal(component, "Can only check 8 bits [" + bit.ToString() + "]");
                    break;
            }
        }

        private void LaneColour(int lane, Color col)
        {
            switch (lane)
            {
                case 0:
                    laneColor1.BackColor = col;
                    break;
                case 1:
                    laneColor2.BackColor = col;
                    break;
                case 2:
                    laneColor3.BackColor = col;
                    break;
                case 3:
                    laneColor4.BackColor = col;
                    break;
                case 4:
                    laneColor5.BackColor = col;
                    break;
                case 5:
                    laneColor6.BackColor = col;
                    break;
                case 6:
                    laneColor7.BackColor = col;
                    break;
                case 7:
                    laneColor8.BackColor = col;
                    break;
                default:
                    Program.log.fatal(component, "Can only set 8 bits [" + lane.ToString() + "]");
                    break;
            }
        }

        private void HideLane(int lane)
        {
            LaneState(lane, false);
        }

        private void ShowLane(int lane)
        {
            LaneState(lane, true);
        }

        private void frmSetupWizard_Load(object sender, EventArgs e)
        {
            //
            // Load the config XML file
            Program.cfg.LoadConfig();

            visibleLanes = Program.cfg.getNumberOfLanes();

            if (Program.cfg.getStartSolenoid() >= 0)
            {
                visibleSolenoid = 1;
            }
            else
            {
                visibleSolenoid = 0;
            }

            if (Program.cfg.getStartGate() >= 0)
            {
                visibleStart = 1;
            }
            else
            {
                visibleStart = 0;
            }

            numLines.Value = visibleLanes + (visibleSolenoid + visibleStart);

        }

        private void numLanes_ValueChanged(object sender, EventArgs e)
        {
            mustDoChanges = true;
            doLaneChanges();
        }

        private void doLaneChanges()
        {
            mustDoChanges = false;
            Button curLane = btnLineState1;
            ComboBox curType = laneType1;
            NumericUpDown curLine = bitLine1;
            Button nextLane = btnLineState2;
            ComboBox nextType = laneType2;
            NumericUpDown nextLine = bitLine2;

            if (Program.cfg.getStartSolenoid() >= 0)
            {
                visibleSolenoid = 1;
            }
            else
            {
                visibleSolenoid = 0;
            }

            if (Program.cfg.getStartGate() >= 0)
            {
                visibleStart = 1;
            }
            else
            {
                visibleStart = 0;
            }

            visibleLanes = int.Parse(numLines.Value.ToString()) - (visibleSolenoid + visibleStart);

            for (int x = (visibleLanes + (visibleSolenoid + visibleStart)); x < 8; x++)
            {
                HideLane(x);
            }
            for (int x = 0; x < (visibleLanes + (visibleSolenoid + visibleStart)); x++)
            {
                ShowLane(x);
                if (x < (visibleSolenoid + visibleStart))
                {
                    LaneColour(x, Color.White);
                    if ((visibleSolenoid > 0) && (x == 0))
                    {
                        curLine.Value = Program.cfg.getStartSolenoid();
                        Solenoid = curLane;
                        curLane.Text = "Solenoid";
                        curType.SelectedText = "SS";
                        curType.Text = "SS";
                    }
                    else if (visibleStart > 0)
                    {
                        curLine.Value = Program.cfg.getStartGate();
                        Start = curLane;
                        curLane.Text = "Start";
                        curType.SelectedText = "SG";
                        curType.Text = "SG";
                    }
                }
                else
                {
                    try
                    {
                        curLine.Value = Program.cfg.getLaneBit((x - (visibleSolenoid + visibleStart)) + 1);
                    }
                    catch
                    {
                        curLine.Value = 0;
                    }
                    Lane[(x - (visibleSolenoid + visibleStart))] = curLane;
                    try
                    {
                        LaneColour(x, Program.cfg.getLaneColor(x - (visibleSolenoid + visibleStart) + 1));
                    }
                    catch
                    {
                        LaneColour(x, Color.Violet);
                    }
                    curLane.Text = "Lane " + ((int)(x - (visibleSolenoid + visibleStart) + 1)).ToString();
                    if (curType.Text == "")
                        curType.SelectedText = "FG";
                }
                curLane = nextLane;
                curType = nextType;
                curLine = nextLine;
                if (nextLane == btnLineState7)
                {
                    nextLane = btnLineState8;
                    nextType = laneType8;
                    nextLine = bitLine8;
                }
                else if (nextLane == btnLineState6)
                {
                    nextLane = btnLineState7;
                    nextType = laneType7;
                    nextLine = bitLine7;
                }
                else if (nextLane == btnLineState5)
                {
                    nextLane = btnLineState6;
                    nextType = laneType6;
                    nextLine = bitLine6;
                }
                else if (nextLane == btnLineState4)
                {
                    nextLane = btnLineState5;
                    nextType = laneType5;
                    nextLine = bitLine5;
                }
                else if (nextLane == btnLineState3)
                {
                    nextLane = btnLineState4;
                    nextType = laneType4;
                    nextLine = bitLine4;
                }
                else if (nextLane == btnLineState2)
                {
                    nextLane = btnLineState3;
                    nextType = laneType3;
                    nextLine = bitLine3;
                }
            }

            Program.cfg.setNumberOfLanes(visibleLanes);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            timerTester.Enabled = true;
        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {
            timerTester.Enabled = false;
        }

        private void btnTestRace_Click(object sender, EventArgs e)
        {
            // Stop the timer
            timerTester.Enabled = false;

            // Initialise the race
            pulsedReader test = new pulsedReader();

            test.setSolenoid(Program.cfg.getStartSolenoid());
            if (Program.cfg.isSolenoidInvert())
                test.setInvert(Program.cfg.getStartSolenoid());
            test.setStartGate(Program.cfg.getStartGate());
            if (Program.cfg.isStartInvert())
                test.setInvert(Program.cfg.getStartGate());
            for (int x = 1; x <= 6; x++)
            {
                test.setFinishGate(Program.cfg.getLaneBit(x), x);
                if (Program.cfg.isLaneInvert(x))
                    test.setInvert(Program.cfg.getLaneBit(x));
            }
            test.reset();


            // Run the race
            txtLptData.Text = "Soleniod";
            test.solenoidTrigger();

            btnLineState1.BackColor = Color.Orange;
            btnLineState2.BackColor = Color.Orange;
            btnLineState3.BackColor = Color.Orange;
            btnLineState4.BackColor = Color.Orange;

            while (!test.startTriggered())
            {
                test.raceTick();
                Refresh();
                Thread.Sleep(5);
            }
            txtLptData.Text = "Started";
            btnLineState1.BackColor = Color.Yellow;

            while (!test.allFinished())
            {
                test.raceTick();
                for (int x = 1; x <= Program.cfg.getNumberOfLanes(); x++)
                {
                    if (test.laneFinished(x))
                    {
                        txtLptData.Text = x.ToString() + " finished";
                        if (x == 1) btnLineState2.BackColor = Color.Yellow;
                        if (x == 2) btnLineState3.BackColor = Color.Yellow;
                        if (x == 3) btnLineState4.BackColor = Color.Yellow;
                    }
                }
                Refresh();
                Thread.Sleep(5);

            }
            txtLptData.Text = "ALL Finished";

            // Give results somewhere :-)
        }

        private void timerTester_Tick(object sender, EventArgs e)
        {
            // Do the testing
            int res = PPort.LptIn(1);
            //res = 0x35;
            txtLptData.Text = Convert.ToString(res, 16).PadLeft(4, '0').ToUpper();

            if (Start != null)
            {
                if (Program.cfg.isStartGateOn(res))
                    Start.BackColor = Color.Red;
                else
                    Start.BackColor = Color.Green;
            }

            if (Solenoid != null)
            {
                if (Program.cfg.isSolenoidOn(res))
                    Solenoid.BackColor = Color.Red;
                else
                    Solenoid.BackColor = Color.Green;
            }

            for (int x = 0; x < 6; x++)
            {
                if (Lane[x] != null)
                {
                    if (Program.cfg.isLaneOn(res, x + 1))
                        Lane[x].BackColor = Color.Red;
                    else
                        Lane[x].BackColor = Color.Green;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Program.cfg.SaveConfig();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void frmSetupWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerTester.Enabled = false;
        }

        private void laneColor1_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor1.BackColor = colorDialog.Color;
            if (btnLineState1 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState1 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState1 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState1 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState1 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState1 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor2_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor2.BackColor = colorDialog.Color;
            if (btnLineState2 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState2 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState2 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState2 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState2 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState2 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor3_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor3.BackColor = colorDialog.Color;
            if (btnLineState3 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState3 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState3 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState3 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState3 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState3 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor4_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor4.BackColor = colorDialog.Color;
            if (btnLineState4 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState4 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState4 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState4 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState4 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState4 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor5_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor5.BackColor = colorDialog.Color;
            if (btnLineState5 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState5 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState5 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState5 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState5 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState5 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor6_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor6.BackColor = colorDialog.Color;
            if (btnLineState6 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState6 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState6 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState6 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState6 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState6 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor7_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor7.BackColor = colorDialog.Color;
            if (btnLineState7 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState7 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState7 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState7 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState7 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState7 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void laneColor8_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
                laneColor8.BackColor = colorDialog.Color;
            if (btnLineState8 == Lane[0])
                Program.cfg.setLaneColor(1, colorDialog.Color);
            if (btnLineState8 == Lane[1])
                Program.cfg.setLaneColor(2, colorDialog.Color);
            if (btnLineState8 == Lane[2])
                Program.cfg.setLaneColor(3, colorDialog.Color);
            if (btnLineState8 == Lane[3])
                Program.cfg.setLaneColor(4, colorDialog.Color);
            if (btnLineState8 == Lane[4])
                Program.cfg.setLaneColor(5, colorDialog.Color);
            if (btnLineState8 == Lane[5])
                Program.cfg.setLaneColor(6, colorDialog.Color);
        }

        private void btnLineState1_Click(object sender, EventArgs e)
        {
            if (btnLineState1 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState1 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState1 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState1 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState1 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState1 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState1 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState1 == Lane[5])
                Program.cfg.invertLane(6);
        }

        private void btnLineState2_Click(object sender, EventArgs e)
        {
            if (btnLineState2 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState2 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState2 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState2 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState2 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState2 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState2 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState2 == Lane[5])
                Program.cfg.invertLane(6);
        }

        private void btnLineState3_Click(object sender, EventArgs e)
        {
            if (btnLineState3 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState3 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState3 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState3 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState3 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState3 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState3 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState3 == Lane[5])
                Program.cfg.invertLane(6);
        }

        private void btnLineState4_Click(object sender, EventArgs e)
        {
            if (btnLineState4 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState4 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState4 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState4 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState4 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState4 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState4 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState4 == Lane[5])
                Program.cfg.invertLane(6);
        }

        private void btnLineState5_Click(object sender, EventArgs e)
        {
            if (btnLineState5 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState5 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState5 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState5 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState5 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState5 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState5 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState5 == Lane[5])
                Program.cfg.invertLane(6);
        }

        private void btnLineState6_Click(object sender, EventArgs e)
        {
            if (btnLineState6 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState6 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState6 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState6 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState6 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState6 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState6 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState6 == Lane[5])
                Program.cfg.invertLane(6);
        }

        private void btnLineState7_Click(object sender, EventArgs e)
        {
            if (btnLineState1 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState1 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState1 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState1 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState1 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState1 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState1 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState1 == Lane[5])
                Program.cfg.invertLane(6);

        }

        private void btnLineState8_Click(object sender, EventArgs e)
        {
            if (btnLineState1 == Start)
                Program.cfg.invertStartGate();
            else if (btnLineState1 == Solenoid)
                Program.cfg.invertSolenoid();
            else if (btnLineState1 == Lane[0])
                Program.cfg.invertLane(1);
            else if (btnLineState1 == Lane[1])
                Program.cfg.invertLane(2);
            else if (btnLineState1 == Lane[2])
                Program.cfg.invertLane(3);
            else if (btnLineState1 == Lane[3])
                Program.cfg.invertLane(4);
            else if (btnLineState1 == Lane[4])
                Program.cfg.invertLane(5);
            else if (btnLineState1 == Lane[5])
                Program.cfg.invertLane(6);

        }

        private void bitLine1_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState1 == Start)
                Program.cfg.setStartGate((int)(bitLine1.Value));
            else if (btnLineState1 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine1.Value));
            else if (btnLineState1 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine1.Value));
            else if (btnLineState1 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine1.Value));
            else if (btnLineState1 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine1.Value));
            else if (btnLineState1 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine1.Value));
            else if (btnLineState1 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine1.Value));
            else if (btnLineState1 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine1.Value));
        }

        private void bitLine2_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState2 == Start)
                Program.cfg.setStartGate((int)(bitLine2.Value));
            else if (btnLineState2 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine2.Value));
            else if (btnLineState2 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine2.Value));
            else if (btnLineState2 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine2.Value));
            else if (btnLineState2 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine2.Value));
            else if (btnLineState2 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine2.Value));
            else if (btnLineState2 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine2.Value));
            else if (btnLineState2 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine2.Value));
        }

        private void bitLine3_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState3 == Start)
                Program.cfg.setStartGate((int)(bitLine3.Value));
            else if (btnLineState3 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine3.Value));
            else if (btnLineState3 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine3.Value));
            else if (btnLineState3 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine3.Value));
            else if (btnLineState3 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine3.Value));
            else if (btnLineState3 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine3.Value));
            else if (btnLineState3 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine3.Value));
            else if (btnLineState3 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine3.Value));
        }

        private void bitLine4_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState4 == Start)
                Program.cfg.setStartGate((int)(bitLine4.Value));
            else if (btnLineState4 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine4.Value));
            else if (btnLineState4 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine4.Value));
            else if (btnLineState4 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine4.Value));
            else if (btnLineState4 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine4.Value));
            else if (btnLineState4 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine4.Value));
            else if (btnLineState4 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine4.Value));
            else if (btnLineState4 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine4.Value));
        }

        private void bitLine5_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState5 == Start)
                Program.cfg.setStartGate((int)(bitLine5.Value));
            else if (btnLineState5 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine5.Value));
            else if (btnLineState5 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine5.Value));
            else if (btnLineState5 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine5.Value));
            else if (btnLineState5 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine5.Value));
            else if (btnLineState5 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine5.Value));
            else if (btnLineState5 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine5.Value));
            else if (btnLineState5 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine5.Value));
        }

        private void bitLine6_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState6 == Start)
                Program.cfg.setStartGate((int)(bitLine6.Value));
            else if (btnLineState6 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine6.Value));
            else if (btnLineState6 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine6.Value));
            else if (btnLineState6 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine6.Value));
            else if (btnLineState6 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine6.Value));
            else if (btnLineState6 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine6.Value));
            else if (btnLineState6 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine6.Value));
            else if (btnLineState6 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine6.Value));
        }

        private void bitLine7_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState7 == Start)
                Program.cfg.setStartGate((int)(bitLine7.Value));
            else if (btnLineState7 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine7.Value));
            else if (btnLineState7 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine7.Value));
            else if (btnLineState7 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine7.Value));
            else if (btnLineState7 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine7.Value));
            else if (btnLineState7 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine7.Value));
            else if (btnLineState7 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine7.Value));
            else if (btnLineState7 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine7.Value));
        }

        private void bitLine8_ValueChanged(object sender, EventArgs e)
        {
            if (btnLineState8 == Start)
                Program.cfg.setStartGate((int)(bitLine8.Value));
            else if (btnLineState8 == Solenoid)
                Program.cfg.setSolenoid((int)(bitLine8.Value));
            else if (btnLineState8 == Lane[0])
                Program.cfg.setLaneBit(1, (int)(bitLine8.Value));
            else if (btnLineState8 == Lane[1])
                Program.cfg.setLaneBit(2, (int)(bitLine8.Value));
            else if (btnLineState8 == Lane[2])
                Program.cfg.setLaneBit(3, (int)(bitLine8.Value));
            else if (btnLineState8 == Lane[3])
                Program.cfg.setLaneBit(4, (int)(bitLine8.Value));
            else if (btnLineState8 == Lane[4])
                Program.cfg.setLaneBit(5, (int)(bitLine8.Value));
            else if (btnLineState8 == Lane[5])
                Program.cfg.setLaneBit(6, (int)(bitLine8.Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            // Set up inter-race / class / start timing
            RaceTimingForm times = new RaceTimingForm();
            DialogResult res = times.ShowDialog();

            switch (res)
            {
                case DialogResult.OK:
                    Program.cfg.setBetweenRaceTime(times.getBetweenRaceTime());
                    Program.cfg.setMaxRaceTime(times.getMaxRaceTime());
                    Program.cfg.setStartGateTime(times.getStartGateTime());
                    Program.cfg.setNumberRuns(times.getNumberRuns());
                    Program.cfg.SaveConfig();
                    break;
                case DialogResult.Cancel:
                    break;
            }

        }

        private void laneType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((laneType1.Text == "SS") && (btnLineState1.Text != "Solenoid"))
                mustDoChanges = true;
            else if ((laneType1.Text == "SG") && (btnLineState1.Text != "Start"))
                mustDoChanges = true;
            else if ((laneType1.Text == "FG") && (btnLineState1.Text != "Lane 1"))
                mustDoChanges = true;
            if (laneType1.Text == "SS")
            {
                Program.cfg.setSolenoid(int.Parse(bitLine1.Value.ToString()));
                visibleSolenoid = 1;
                if ((visibleStart == 1) && ((laneType2.Text != "SG") && (laneType2.Text != "")))
                {
                    Program.cfg.setStartGate(-1);
                    visibleStart = 0;
                }
            }
            else if (laneType1.Text == "SG")
            {
                if (laneType2.Text == "SG")
                {
                    laneType2.SelectedText = "FG";
                }
                Program.cfg.setSolenoid(-1);
                Program.cfg.setStartGate(int.Parse(bitLine1.Value.ToString()));
                visibleSolenoid = 0;
                visibleStart = 1;
            }
            else if (laneType1.Text == "FG")
            {
                Program.cfg.setSolenoid(-1);
                Program.cfg.setStartGate(-1);
                Program.cfg.setLaneBit(1, int.Parse(bitLine1.Value.ToString()));
                visibleSolenoid = 0;
                visibleStart = 0;
            }
            if (mustDoChanges)
                doLaneChanges();
        }

        private void laneType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((laneType2.Text == "SG") && (btnLineState2.Text != "Start"))
                mustDoChanges = true;
            else if ((laneType2.Text == "FG") && (btnLineState2.Text.Substring(0,4) != "Lane"))
                mustDoChanges = true;
            if ((laneType2.Text == "SG") && (laneType1.Text == "SS"))
            {
                Program.cfg.setStartGate(int.Parse(bitLine2.Value.ToString()));
                visibleStart = 1;
            }
            else if ((laneType1.Text == "SG") && (laneType2.Text == "SG"))
            {
                laneType2.Text = "FG";
                Program.cfg.setLaneBit(1, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType2.Text == "FG")
            {
                if (laneType1.Text == "SG")
                {
                    Program.cfg.setLaneBit(1, int.Parse(bitLine2.Value.ToString()));
                }
                else
                {
                    Program.cfg.setLaneBit(2, int.Parse(bitLine2.Value.ToString()));
                }
                visibleStart = 0;
            }
            if (mustDoChanges)
                doLaneChanges();
        }

        private void laneType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laneType2.Text == "SG")
            {
                Program.cfg.setLaneBit(1, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType1.Text == "SG")
            {
                Program.cfg.setLaneBit(2, int.Parse(bitLine2.Value.ToString()));
            }
            else
            {
                Program.cfg.setLaneBit(3, int.Parse(bitLine2.Value.ToString()));
            }
        }

        private void laneType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laneType2.Text == "SG")
            {
                Program.cfg.setLaneBit(2, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType1.Text == "SG")
            {
                Program.cfg.setLaneBit(3, int.Parse(bitLine2.Value.ToString()));
            }
            else
            {
                Program.cfg.setLaneBit(4, int.Parse(bitLine2.Value.ToString()));
            }
        }

        private void laneType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laneType2.Text == "SG")
            {
                Program.cfg.setLaneBit(3, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType1.Text == "SG")
            {
                Program.cfg.setLaneBit(4, int.Parse(bitLine2.Value.ToString()));
            }
            else
            {
                Program.cfg.setLaneBit(5, int.Parse(bitLine2.Value.ToString()));
            }
        }

        private void laneType6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laneType2.Text == "SG")
            {
                Program.cfg.setLaneBit(4, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType1.Text == "SG")
            {
                Program.cfg.setLaneBit(5, int.Parse(bitLine2.Value.ToString()));
            }
            else
            {
                Program.cfg.setLaneBit(6, int.Parse(bitLine2.Value.ToString()));
            }
        }

        private void laneType7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laneType2.Text == "SG")
            {
                Program.cfg.setLaneBit(5, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType1.Text == "SG")
            {
                Program.cfg.setLaneBit(6, int.Parse(bitLine2.Value.ToString()));
            }
            else
            {
                Program.cfg.setLaneBit(7, int.Parse(bitLine2.Value.ToString()));
            }
        }

        private void laneType8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (laneType2.Text == "SG")
            {
                Program.cfg.setLaneBit(6, int.Parse(bitLine2.Value.ToString()));
            }
            else if (laneType1.Text == "SG")
            {
                Program.cfg.setLaneBit(7, int.Parse(bitLine2.Value.ToString()));
            }
            else
            {
                Program.cfg.setLaneBit(8, int.Parse(bitLine2.Value.ToString()));
            }
        }

    }
}