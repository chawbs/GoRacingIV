using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace GoRacingIV
{
    public partial class ResultsForm : Form
    {
        private static int resultState = 0;
        private static int iClass = 0;

        CompetitorsClass people = new CompetitorsClass();

        public ResultsForm()
        {
            InitializeComponent();
        }

        public void setClass(int ic)
        {
            iClass = ic;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            resultState = 0;

            int cl = iClass;
            people.loadCompetitors(cl);
            TimeSpan[] times = people.getTimes();
            string[] racers = people.getCompetitors();
            TimeSpan firstT = new TimeSpan(1, 0, 0);
            TimeSpan secondT = new TimeSpan(1, 0, 0);
            TimeSpan thirdT = new TimeSpan(1, 0, 0);
            string first = "";
            string second = "";
            string third = "";
            for (int x = 0; x < times.Length; x++)
            {
                char[] sep ={ '|' };
                string[] content = { "", "", "", "" };
                try { content = racers[x].ToString().Split(sep); }
                catch { }

                Debug.WriteLine("line:"+racers[x].ToString());
                Debug.WriteLine("racer:"+content[1]+" with "+content[2]);

                if (times[x] < firstT)
                {
                    third = second;
                    thirdT = secondT;
                    second = first;
                    secondT = firstT;
                    first = content[1] + " with " + content[2];
                    firstT = times[x];
                }
                else if (times[x] < secondT)
                {
                    third = second;
                    thirdT = secondT;
                    second = content[1] + " with " + content[2];
                    secondT = times[x];
                }
                else if (times[x] < thirdT)
                {
                    third = content[1] + " with " + content[2];
                    thirdT = times[x];
                }

                Debug.WriteLine("1st:" + first + " 2nd:" + second + " 3rd:" + third);
            }

            double avg = 0.0;
            string avgs = thirdT.ToString().Substring(6);
            avg = double.Parse(avgs);
            avg = avg / 3.0;
            p3Name.Text = third;
            p3Time.Text = avg.ToString("00.0000");

            avgs = secondT.ToString().Substring(6);
            avg = double.Parse(avgs);
            avg = avg / 3.0;
            p2Name.Text = second;
            p2Time.Text = avg.ToString("00.0000");

            avgs = firstT.ToString().Substring(6);
            avg = double.Parse(avgs);
            avg = avg / 3.0;
            p1Name.Text = first;
            p1Time.Text = avg.ToString("00.0000");

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            switch (resultState)
            {
                case 0:
                    resultState++;
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    break;
                case 1:
                    resultState++;
                    p3Time.Visible = true;
                    p3Name.Visible = true;
                    break;
                case 2:
                    resultState++;
                    p2Time.Visible = true;
                    p2Name.Visible = true;
                    break;
                case 3:
                    resultState++;
                    p1Time.Visible = true;
                    p1Name.Visible = true;
                    break;
            }
        }
    }
}