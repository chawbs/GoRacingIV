using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GoRacingIV
{
    static class Program
    {
        // The setup
        public static ConfigClass cfg = new ConfigClass();

        // The competitors
        public static CompetitorsClass racers = new CompetitorsClass();

        // our logging
        public static LOG log = new LOG();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());
        }
    }
}