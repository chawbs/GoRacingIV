using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using inpoutclass;

namespace GoRacingIV
{
    public partial class RacingForm : Form
    {
        private static string component = "RaceForm";

        private DateTime start = DateTime.Now;
        private DateTime finish = DateTime.Now;
        pulsedReader track = new pulsedReader();
        CompetitorsClass people = new CompetitorsClass();

        private string raceClass = "";
        private string raceList = "";
        private string prevRaceList = "";

        private int lanes = Program.cfg.getNumberOfLanes();

        private bool abortRace = false;
        private bool raceStart = true;

        private char[] sep = { '|' };

        private enum state
        {
            Unknown = 0,
            Ready = 1,
            Started = 2,
            Finished = 3,
            Aborted = 4
        }

        state raceState = state.Unknown;

        public RacingForm()
        {
            InitializeComponent();
        }

        private void RacingForm_Load(object sender, EventArgs e)
        {
            Program.cfg.LoadConfig();
            track.setSolenoid(Program.cfg.getStartSolenoid());
            if (Program.cfg.isSolenoidInvert())
                track.setInvert(Program.cfg.getStartSolenoid());
            track.setStartGate(Program.cfg.getStartGate());
            if (Program.cfg.isStartInvert())
                track.setInvert(Program.cfg.getStartGate());
            for (int x = 1; x <= 6; x++)
            {
                track.setFinishGate(Program.cfg.getLaneBit(x), x);
                if (Program.cfg.isLaneInvert(x))
                    track.setInvert(Program.cfg.getLaneBit(x));
            }
            track.reset();
            timerUpdate.Enabled = false;
            screenUpdater.Enabled = false;

            lanes = Program.cfg.getNumberOfLanes();

            if (lanes >= 1) r1Box.BackColor = Program.cfg.getLaneColor(1);
            else r1Box.Visible = false;
            if (lanes >= 2) r2Box.BackColor = Program.cfg.getLaneColor(2);
            else r2Box.Visible = false;
            if (lanes >= 3) r3Box.BackColor = Program.cfg.getLaneColor(3);
            else r3Box.Visible = false;
            if (lanes >= 4) r4Box.BackColor = Program.cfg.getLaneColor(4);
            else r4Box.Visible = false;
            if (lanes >= 5) r5Box.BackColor = Program.cfg.getLaneColor(5);
            else r5Box.Visible = false;
            if (lanes >= 6) r6Box.BackColor = Program.cfg.getLaneColor(6);
            else r6Box.Visible = false;

            track.setMaxRaceTime(Program.cfg.getMaxRaceTime());
            track.setMaxStartTime(Program.cfg.getStartGateTime());
            track.setBetweenRaceTime(Program.cfg.getBetweenRaceTime());

            betweenRaces.Interval = Program.cfg.getBetweenRaceTime() * 1000;

            people.setNumberLanes(lanes);
            people.loadClasses();
            people.loadCompetitors(1);

            r1Name.Text = "";
            r2Name.Text = "     Are you ready for racing?";
            r3Name.Text = "                       Good Luck...";

            r1Car.Text = "";
            r2Car.Text = "";
            r3Car.Text = "";

            r1Time.Text = "";
            r2Time.Text = "";
            r3Time.Text = "";

            r1Position.Text = "";
            r2Position.Text = "";
            r3Position.Text = "";

            raceClass = people.getFirstClass();
            string[] details = raceClass.Split(sep);
            offWeGo.Text = "First Class: " + details[1];
            betweenRaces.Enabled = true;
            btnGO.Enabled = false;
            raceStart = true;

            if (Program.cfg.getStartGate() != -1)
                btnGO.Text = "Start";
            else
                btnGO.Text = "GO!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            // if we are under starters orders, cancel
            if (raceState == state.Ready)
            {
                abortRace = true;
            }
            track.disableAll();
        }

        /// <summary>
        /// Fast timer tick - do not put things in here!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (abortRace)
            {
                track.reset();
                timerUpdate.Enabled = false;
                raceState = state.Aborted;
            }
            else
            {
                track.raceTick();

                switch (raceState)
                {
                    case state.Ready:
                        if (track.startTriggered())
                        {
                            start = DateTime.Now;
                            allStarted.Checked = true;
                            offWeGo.Text = "They're OFF!";
                            raceState = state.Started;
                        }
                        break;

                    case state.Started:
                        if (track.allFinished())
                        {
                            allFinished.Checked = true;
                            offWeGo.Text = "They're Finished...";
                            raceState = state.Finished;
                        }
                        break;

                    case state.Finished:
                        timerUpdate.Enabled = false;
                        break;
                }
            }
        }

        /// <summary>
        /// This is where you can update the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void screenUpdater_Tick(object sender, EventArgs e)
        {
            if (abortRace)
            {
                Program.log.log("Race Aborted");
                offWeGo.Text = "Race Aborted...";
                screenUpdater.Enabled = false;
                //btnGO.Enabled = true;
                btnPrev.Enabled = true;
                btnReRun.Enabled = true;
                betweenRaces.Enabled = true;
                btnGO.Enabled = false;
            }
            else
            {

                finish = DateTime.Now;

                //            realtimeCounter.Text = (finish - start).ToString("HH:mm:ss.ff");
                TimeSpan racetime = (finish - start);
                realtimeCounter.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");

                switch (raceState)
                {
                    case state.Ready:
                        Program.log.info(component, "Track ready...");
                        break;

                    case state.Started:
                        Program.log.info(component, "Race Started...");
                        break;

                    case state.Finished:
                        Program.log.info(component, "Race Finished...");
                        if (lanes > 0)
                        {
                            r1Position.Text = track.lanePosition(1).ToString();
                            racetime = track.laneTime(1);
                            r1Time.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");
                            people.addCompetitorTime(r1Num.Text, r1Name.Text, r1Car.Text, track.laneTime(1));
                        }
                        if (lanes > 1)
                        {
                            r2Position.Text = track.lanePosition(2).ToString();
                            racetime = track.laneTime(2);
                            r2Time.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");
                            people.addCompetitorTime(r2Num.Text, r2Name.Text, r2Car.Text, track.laneTime(2));
                        }
                        if (lanes > 2)
                        {
                            r3Position.Text = track.lanePosition(3).ToString();
                            racetime = track.laneTime(3);
                            r3Time.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");
                            people.addCompetitorTime(r3Num.Text, r3Name.Text, r3Car.Text, track.laneTime(3));
                        }
                        if (lanes > 3)
                        {
                            r4Position.Text = track.lanePosition(4).ToString();
                            racetime = track.laneTime(4);
                            r4Time.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");
                            people.addCompetitorTime(r4Num.Text, r4Name.Text, r4Car.Text, track.laneTime(4));
                        }
                        if (lanes > 4)
                        {
                            r5Position.Text = track.lanePosition(5).ToString();
                            racetime = track.laneTime(5);
                            r5Time.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");
                            people.addCompetitorTime(r5Num.Text, r5Name.Text, r5Car.Text, track.laneTime(5));
                        }
                        if (lanes > 5)
                        {
                            r6Position.Text = track.lanePosition(6).ToString();
                            racetime = track.laneTime(6);
                            r6Time.Text = racetime.Seconds.ToString("00") + "." + racetime.Milliseconds.ToString("000");
                            people.addCompetitorTime(r6Num.Text, r6Name.Text, r6Car.Text, track.laneTime(6));
                        }
                        screenUpdater.Enabled = false;
                        //btnGO.Enabled = false;
                        btnPrev.Enabled = false;
                        btnReRun.Enabled = false;
                        betweenRaces.Enabled = true;
                        btnGO.Enabled = false;
                        people.saveCompetitors(raceClass);
                        break;
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            warning.Text = "";

            prevRaceList = raceList;

            btnGO.Enabled = false;
            btnPrev.Enabled = false;
            btnReRun.Enabled = false;

            offWeGo.Text = "Under Starter's Orders...";
            allFinished.Checked = false;
            allStarted.Checked = false;
            //
            // Reset flags in track mode
            track.reset();

            //
            // If we have a solenoid - trip it after a random time
            track.solenoidTrigger();

            //
            // And start the race
            raceState = state.Ready;
            start = DateTime.Now;
            timerUpdate.Enabled = true;
            screenUpdater.Enabled = true;
        }

        private void fillRaceDetails(string dets)
        {
            string[] details = dets.Split(sep);
            int cnt = details.Length;
            int lane = 0;

            //
            // we should have 3 items per lane
            if ((cnt / 3) != lanes)
                offWeGo.Text = "Program Error!";
            else
                offWeGo.Text = "Next Racers Please...";

            track.resetStartStart();

            if (track.startTriggered())
                warning.Text = "WARNING: Start Gate Open";

            r1Time.Text = "0.0";
            r2Time.Text = "0.0";
            r3Time.Text = "0.0";
            r4Time.Text = "0.0";
            r5Time.Text = "0.0";
            r6Time.Text = "0.0";

            r1Position.Text = "";
            r2Position.Text = "";
            r3Position.Text = "";
            r4Position.Text = "";
            r5Position.Text = "";
            r6Position.Text = "";

            if (lanes > lane)
            {
                r1Num.Text = details[0];
                r1Name.Text = details[1];
                r1Car.Text = details[2];
            }
            lane++;
            if (lanes > lane)
            {
                r2Num.Text = details[3];
                r2Name.Text = details[4];
                r2Car.Text = details[5];
            }
            lane++;
            if (lanes > lane)
            {
                r3Num.Text = details[6];
                r3Name.Text = details[7];
                r3Car.Text = details[8];
            }
            lane++;
            if (lanes > lane)
            {
                r4Num.Text = details[9];
                r4Name.Text = details[10];
                r4Car.Text = details[11];
            }
            lane++;
            if (lanes > lane)
            {
                r5Num.Text = details[12];
                r5Name.Text = details[13];
                r5Car.Text = details[14];
            }
            lane++;
            if (lanes > lane)
            {
                r6Num.Text = details[15];
                r6Name.Text = details[16];
                r6Car.Text = details[17];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
            // Keep current Race List
            //
            fillRaceDetails(raceList);

        }

        private void betweenRaces_Tick(object sender, EventArgs e)
        {
            if (abortRace)
            {
                abortRace = false;
                offWeGo.Text = "Race Aborted - Resetting...";
                //btnGO.Enabled = true;
                btnPrev.Enabled = true;
                btnReRun.Enabled = true;
                betweenRaces.Enabled = false;
                btnGO.Enabled = true;
                //raceList = prevRaceList;
                fillRaceDetails(raceList);
            }
            else
            {
                //btnGO.Enabled = true;
                btnPrev.Enabled = true;
                btnReRun.Enabled = true;
                betweenRaces.Enabled = false;
                
                //
                // Get details of the next race & reload the screen
                if (raceStart)
                {
                    raceList = people.getFirstRaceDetails(raceClass);
                    raceStart = false;
                }
                else
                {
                    prevRaceList = raceList;
                    raceList = people.getNextRaceDetails();
                }

                if (raceList.IndexOf('|') > 0)
                {
                    fillRaceDetails(raceList);
                }
                else
                {
                    //
                    // Now show up the results screen
                    ResultsForm results = new ResultsForm();
                    try
                    {
                        string[] details = raceClass.Split(sep);
                        results.setClass(int.Parse(details[0]));
                    }
                    catch
                    {
                        results.setClass(1);
                    }
                    DialogResult res = results.ShowDialog();

                    switch (res)
                    {
                        case DialogResult.OK:
                            break;
                        case DialogResult.Cancel:
                            break;
                    }


                    //
                    // when we get back - continue

                    raceClass = people.getNextClass();
                    try
                    {
                        string[] details = raceClass.Split(sep);
                        offWeGo.Text = "Next Class: " + details[1];
                        raceStart = true;
                        betweenRaces.Enabled = true;

                        r1Name.Text = "";
                        r2Name.Text = "     Here goes with the next race...";
                        r3Name.Text = "";

                        r1Car.Text = "";
                        r2Car.Text = "";
                        r3Car.Text = "";

                        r1Time.Text = "";
                        r2Time.Text = "";
                        r3Time.Text = "";

                        r1Position.Text = "";
                        r2Position.Text = "";
                        r3Position.Text = "";

                    }
                    catch
                    {
                        offWeGo.Text = "Racing completed in all classes";
                        raceStart = true;
                        btnGO.Enabled = false;

                        r1Name.Text = "Thank you for coming!";
                        r2Name.Text = "We hope you enjoyed it...";
                        r3Name.Text = "";

                        r1Car.Text = "";
                        r2Car.Text = "";
                        r3Car.Text = "";

                        r1Time.Text = "";
                        r2Time.Text = "";
                        r3Time.Text = "";

                        r1Position.Text = "";
                        r2Position.Text = "";
                        r3Position.Text = "";
                    }
                    //Refresh();
                    //Thread.Sleep(betweenRaces.Interval);
                    //raceList = people.getFirstRaceDetails(raceClass);

                    //if (raceList.IndexOf('|') > 0)
                    //{
                    //    fillRaceDetails(raceList);
                    //}
                    //else
                    //{
                    //    offWeGo.Text = "Racing completed in all classes";
                    //}
                }
                if (!raceStart)
                    btnGO.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            raceList = prevRaceList;
            fillRaceDetails(raceList);
        }

    }
}