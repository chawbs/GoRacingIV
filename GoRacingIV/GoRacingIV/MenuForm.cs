using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace GoRacingIV
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // first check to make sure everything is closed down & saved

            //
            // then close the door on the way out
            Close();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            // Show the setup wizard
            frmSetupWizard setup = new frmSetupWizard();
            DialogResult res = setup.ShowDialog();

            if (res == DialogResult.OK)
            {
                // erm...
            }
            else if (res == DialogResult.Cancel)
            {
                // re-load the previous settings
            }

            // set to null for garbage collection
            setup = null;
        }

        private void btnCompetitors_Click(object sender, EventArgs e)
        {
            CompetitorsForm racers = new CompetitorsForm();
            DialogResult res = racers.ShowDialog();

            switch (res)
            {
                case DialogResult.OK:
                    // erm
                    break;

                case DialogResult.Cancel:
                    // not sure if we will get this back
                    break;
            }
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            RacingForm race = new RacingForm();
            DialogResult res = race.ShowDialog();

            switch (res)
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            ResultsForm results = new ResultsForm();
            DialogResult res = results.ShowDialog();

            switch (res)
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Text = "Go Racing IV - " + Application.ProductVersion.ToString();
        }
    }
}