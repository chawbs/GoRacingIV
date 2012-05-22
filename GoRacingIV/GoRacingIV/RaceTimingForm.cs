using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoRacingIV
{
    public partial class RaceTimingForm : Form
    {
        public RaceTimingForm()
        {
            InitializeComponent();
        }

        private void RaceTimingForm_Load(object sender, EventArgs e)
        {
            txtBetweenRaceTime.Text = Program.cfg.getBetweenRaceTime().ToString();
            txtMaxRaceTime.Text = Program.cfg.getMaxRaceTime().Seconds.ToString();
            txtStartGateTime.Text = Program.cfg.getStartGateTime().Seconds.ToString();
            txtNumberRuns.Text = Program.cfg.getNumberRuns().ToString();
        }

        public int getBetweenRaceTime()
        {
            int val = 10;
            try { val = int.Parse(txtBetweenRaceTime.Text); }
            catch { val = 10; }
            return val;
        }

        public TimeSpan getStartGateTime()
        {
            int val = 10;
            try { val = int.Parse(txtStartGateTime.Text); }
            catch { val = 10; }
            TimeSpan tval = new TimeSpan(0, 0, val);
            return tval;
        }

        public TimeSpan getMaxRaceTime()
        { 
            int val = 10;
            try { val = int.Parse(txtMaxRaceTime.Text); }
            catch { val = 10; }
            TimeSpan tval = new TimeSpan(0, 0, val);
            return tval;
        }

        public int getNumberRuns()
        {
            int val = 1;
            try { val = int.Parse(txtNumberRuns.Text); }
            catch { val = 1; }
            return val;
        }

    }
}