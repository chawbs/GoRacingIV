using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoRacingIV
{
    public partial class CompetitorsForm : Form
    {
        CompetitorsClass people = new CompetitorsClass();
        bool dataChanged = false;

        public CompetitorsForm()
        {
            InitializeComponent();
        }

        private void CompetitorsForm_Load(object sender, EventArgs e)
        {
            people.loadClasses();
            cmbClass.Items.AddRange(people.getClasses());
            cmbClass.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            people.saveCompetitors(cmbClass.SelectedIndex+1);
            dataChanged = false;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult res = DialogResult.OK;
            if (dataChanged)
            {
                res = MessageBox.Show("Data has Changed. OK to loose changes?", "Data Changed",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            if (res == DialogResult.OK)
            {
                listOfRacers.Items.Clear();
                //
                // Reload the competitors
                int cl = cmbClass.SelectedIndex;
                people.loadCompetitors(cmbClass.SelectedIndex);
                foreach (string racer in people.getCompetitors())
                {
                    string aracer = cl.ToString() + "|" + racer;
                    listOfRacers.Items.Add(aracer);
                }
                dataChanged = false;
            }
            else
            {
                // reset the selected index
                dataChanged = false;
                cmbClass.SelectedIndex = people.getCurrentClass();
                dataChanged = true;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult res = DialogResult.OK;
            if (dataChanged)
            {
                res = MessageBox.Show("Data has Changed. OK to loose changes?", "Data Changed",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            if (res == DialogResult.OK)
            {
                listOfRacers.Items.Clear();
                //
                // Reload the competitors
                int cl = cmbClass.SelectedIndex;
                people.loadCompetitors(cl);
                foreach (string racer in people.getCompetitors())
                {
                    string aracer = cl.ToString() + "|" + racer;
                    listOfRacers.Items.Add(aracer);
                }
                dataChanged = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listOfRacers.SelectedIndex == -1)
                return;

            DialogResult res = DialogResult.OK;
            if (txtNumber.Text != "")
            {
                res = MessageBox.Show("Data has Changed. OK to loose changes?", "Data Changed",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            if (res == DialogResult.OK)
            {
                dataChanged = true;

                //
                // Remove the highlighted racer
                int cl = cmbClass.SelectedIndex + 1;
                string raceline = listOfRacers.Items[listOfRacers.SelectedIndex].ToString();
                char[] sep ={ '|' };
                string[] content = { "", "", "", "" };
                try { content = raceline.Split(sep); }
                catch { }
                people.removeCompetitor(content[1], content[2], content[3], cl);
                listOfRacers.Items.RemoveAt(listOfRacers.SelectedIndex);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dataChanged = true;

            //
            // Add these details to the race list
            int cl = cmbClass.SelectedIndex + 1;
            string racer = cl.ToString() + "|" + txtNumber.Text + "|" + txtCompetitor.Text + "|" + txtCar.Text;
            listOfRacers.Items.Add(racer);
            people.addCompetitor(txtNumber.Text, txtCompetitor.Text, txtCar.Text, cl);
            txtCar.Text = "";
            txtCompetitor.Text = "";
            txtNumber.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listOfRacers.SelectedIndex == -1)
                return;

            DialogResult res = DialogResult.OK;
            if (txtNumber.Text != "")
            {
                res = MessageBox.Show("Data has Changed. OK to loose changes?", "Data Changed",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            if (res == DialogResult.OK)
            {
                dataChanged = true;

                //
                // Transfer details out of list to be edited
                int cl = cmbClass.SelectedIndex + 1;
                string raceline = listOfRacers.Items[listOfRacers.SelectedIndex].ToString();
                char[] sep ={ '|' };
                string[] content = { "", "", "", "" };
                try { content = raceline.Split(sep); }
                catch { }
                txtCar.Text = content[3];
                txtCompetitor.Text = content[2];
                txtNumber.Text = content[1];
                listOfRacers.Items.RemoveAt(listOfRacers.SelectedIndex);
                people.removeCompetitor(content[1], content[2], content[3], cl);
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (dataFolder.ShowDialog() == DialogResult.OK)
            {
                people.setDataPath(dataFolder.SelectedPath);
            }
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            // remove the currently selected class
            char[] sep ={ '|' };
            string[] clas = people.getClassText(people.getCurrentClass()).Split(sep);
            people.removeClass(clas[0], clas[1]);
            people.saveClasses();
            cmbClass.Items.Clear();
            cmbClass.Items.AddRange(people.getClasses());
            cmbClass.SelectedIndex = 0;
        }

        private void btnAddNewClass_Click(object sender, EventArgs e)
        {
            people.addClass("9", "New Class");
            people.saveClasses();
            cmbClass.Items.Clear();
            cmbClass.Items.AddRange(people.getClasses());
            cmbClass.SelectedIndex = cmbClass.Items.Count-1;
        }

        private void cmbClass_TextChanged(object sender, EventArgs e)
        {
            // user must have changed text - if valid, save classes
            char[] sep ={ '|' };
            try
            {
                people.setClassText(cmbClass.Text);
                people.saveClasses();
            }
            catch { }
        }
    }
}