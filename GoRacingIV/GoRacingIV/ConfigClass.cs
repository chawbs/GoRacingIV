using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Configuration;


namespace GoRacingIV
{
    class ConfigClass
    {
        private static string component = "Config";

        private static bool hasChanged = false;

        private static string TrackPort = "";
        private static string PrinterPort = "";
        private static string DataPath = "";

        private static int NumberOfLanes = 0;
        private static int[] LaneBit = { -1, -1, -1, -1, -1, -1 };
        private static bool[] LaneInvert = { false, false, false, false, false, false };
        private static Color[] LaneColors = new Color[6];
        private static int StartGate = -1;
        private static int StartSolenoid = -1;
        private static bool StartInvert = false;
        private static bool SolenoidInvert = false;

        private static int betweenRaceTime = 0;
        private static TimeSpan startGateTime = new TimeSpan(0, 0, 0);
        private static TimeSpan maxRaceTime = new TimeSpan(0, 0, 0);

        private static int numberRuns = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigClass()
        {
        }

        /// <summary>
        /// Set the level of logging
        /// </summary>
        /// <param name="lvl"></param>
        public void setLogLevel(int lvl)
        {
            if ((lvl < 0) || (lvl > 5))
                Program.log.fatal(component, "Log level can only be between 0 and 5");
            else
                Program.log.setLevel(lvl);
        }

        /// <summary>
        /// Return the number of lanes
        /// </summary>
        /// <returns></returns>
        public int getNumberOfLanes()
        {
            return NumberOfLanes;
        }

        /// <summary>
        /// Set the number of lanes to be used by the track
        /// </summary>
        /// <param name="l"></param>
        public void setNumberOfLanes(int l)
        {
            NumberOfLanes = l;

            if (l > 0)
            {
                Properties.Settings.Default.Lane1Exists = true;
                l--;
            }
            else
            {
                Properties.Settings.Default.Lane1Exists = false;
            }

            if (l > 0)
            {
                Properties.Settings.Default.Lane2Exists = true;
                l--;
            }
            else
            {
                Properties.Settings.Default.Lane2Exists = false;
            }

            if (l > 0)
            {
                Properties.Settings.Default.Lane3Exists = true;
                l--;
            }
            else
            {
                Properties.Settings.Default.Lane3Exists = false;
            }

            if (l > 0)
            {
                Properties.Settings.Default.Lane4Exists = true;
                l--;
            }
            else
            {
                Properties.Settings.Default.Lane4Exists = false;
            }

            if (l > 0)
            {
                Properties.Settings.Default.Lane5Exists = true;
                l--;
            }
            else
            {
                Properties.Settings.Default.Lane5Exists = false;
            }

            if (l > 0)
            {
                Properties.Settings.Default.Lane6Exists = true;
                l--;
            }
            else
            {
                Properties.Settings.Default.Lane6Exists = false;
            }

            Properties.Settings.Default.Save();

            hasChanged = true;
        }

        /// <summary>
        /// Return the Lane Label (real life lane numbers [1 - 6])
        /// </summary>
        /// <param name="lane"></param>
        /// <returns></returns>
        public string getLaneLabel(int lane)
        {
            return "Lane "+lane.ToString();
        }

        /// <summary>
        /// Return the Lane number based on the bit being checked (real life lane number [1-6])
        /// Returns -1 if not found
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public int getLaneNumber(int bit)
        {
            for (int x = 0; x < 6; x++)
            {
                if (LaneBit[x] == bit)
                    return x + 1;
            }
            Program.log.error(component, "Bit pattern not found in setup");
            return -1;
        }

        /// <summary>
        /// Return the bit number used to check this Lane (real life lane number [1-6])
        /// </summary>
        /// <param name="lane"></param>
        /// <returns></returns>
        public int getLaneBit(int lane)
        {
            return LaneBit[lane-1];
        }

        /// <summary>
        /// Set the bit pattern used to check this Lane (real life lane number [1-6])
        /// </summary>
        /// <param name="lane"></param>
        /// <param name="bit"></param>
        public void setLaneBit(int lane, int bit)
        {
            LaneBit[lane - 1] = bit;
        }

        /// <summary>
        /// Return label associated with bit mask
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public string getLabel(int bit)
        {
            if (bit == StartSolenoid)
                return "Solenoid";
            else if (bit == StartGate)
                return "Start Gate";
            else
                return getLaneLabel(getLaneNumber(bit));
        }

        /// <summary>
        /// Set the bit pattern to trigger the solenoid
        /// </summary>
        /// <param name="bit"></param>
        public void setSolenoid(int bit)
        {
            StartSolenoid = bit;
            hasChanged = true;
        }

        /// <summary>
        /// Set the bit pattern to show the start gate is open
        /// </summary>
        /// <param name="bit"></param>
        public void setStartGate(int bit)
        {
            StartGate = bit;
            hasChanged = true;
        }

        /// <summary>
        /// Return Lane Colour (real life lane number [1-6])
        /// </summary>
        /// <param name="lane"></param>
        /// <returns></returns>
        public Color getLaneColor(int lane)
        {
            return LaneColors[lane-1];
        }

        /// <summary>
        /// Set the lane colour (real life lane number [1-6])
        /// </summary>
        /// <param name="lane"></param>
        /// <param name="color"></param>
        public void setLaneColor(int lane, Color color)
        {
            LaneColors[lane-1] = color;
            hasChanged = true;
        }

        /// <summary>
        /// Return Color from bit map
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public Color getColor(int bit)
        {
            return LaneColors[getLaneNumber(bit)];
        }

        /// <summary>
        /// Return bit pattern to check start gate is open
        /// </summary>
        /// <returns></returns>
        public int getStartGate()
        {
            return StartGate;
        }

        /// <summary>
        /// Is the bit pattern inverted for the start gate
        /// </summary>
        /// <returns></returns>
        public bool isStartInvert()
        {
            return StartInvert;
        }

        /// <summary>
        /// Invert the bit pattern for the start gate
        /// </summary>
        public void invertStartGate()
        {
            StartInvert = !StartInvert;
            hasChanged = true;
        }

        /// <summary>
        /// Is the bit pattern inverted for the solenoid
        /// </summary>
        /// <returns></returns>
        public bool isSolenoidInvert()
        {
            return SolenoidInvert;
        }

        /// <summary>
        /// Invert the bit pattern for the solenoid
        /// </summary>
        public void invertSolenoid()
        {
            SolenoidInvert = !SolenoidInvert;
            hasChanged = true;
        }

        /// <summary>
        /// Is the bit pattern inverted for the Lane (real life lane number [1-6])
        /// </summary>
        /// <param name="lane"></param>
        /// <returns></returns>
        public bool isLaneInvert(int lane)
        {
            return LaneInvert[lane - 1];
        }

        /// <summary>
        /// Invert the bit pattern for the lane (real life lane number [1-6])
        /// </summary>
        /// <param name="lane"></param>
        public void invertLane(int lane)
        {
            LaneInvert[lane - 1] = !LaneInvert[lane - 1];
            hasChanged = true;
        }

        /// <summary>
        /// Is the start gate currently triggered
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public bool isStartGateOn(int bits)
        {
            int val = (bits & (1 << StartGate));
            bool trip = (val == (1 << StartGate));
            if (StartInvert) trip = !trip;
            return trip;
        }

        /// <summary>
        /// Is the solenoid currently triggered
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public bool isSolenoidOn(int bits)
        {
            int val = (bits & (1 << StartSolenoid));
            bool trip = (val == (1 << StartSolenoid));
            if (SolenoidInvert) trip = !trip;
            return trip;
        }

        /// <summary>
        /// Is the lane currently triggered (real life lane number [1-6])
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="lane"></param>
        /// <returns></returns>
        public bool isLaneOn(int bits, int lane)
        {
            int val = (bits & (1 << LaneBit[lane-1]));
            bool trip = (val == (1 << LaneBit[lane-1]));
            if (LaneInvert[lane-1]) trip = !trip;
            return trip;
        }

        /// <summary>
        /// Return bit pattern to trigger solenoid
        /// </summary>
        /// <returns></returns>
        public int getStartSolenoid()
        {
            return StartSolenoid;
        }

        /// <summary>
        /// Get the port number (index 1-8) used for the track (LPT1 through LPT8)
        /// </summary>
        /// <returns></returns>
        public int getTrackPort()
        {
            int p = 1;
            string portnum = "1";
            try
            {
                portnum = TrackPort.ToUpper().Substring(3);
                p = int.Parse(portnum);
            }
            catch
            {
                Program.log.error(component, "Track Port string not set");
                p = 1;
            }
            return p;
        }

        /// <summary>
        /// Set the track port  string (LPT1 through LPT8)
        /// </summary>
        /// <param name="port"></param>
        public void setTrackPort(string port)
        {
            TrackPort = port.ToUpper();
            hasChanged = true;
        }

        /// <summary>
        /// Get the port number (index 1-8) used for the printer (LPT1 through LPT8)
        /// </summary>
        /// <returns></returns>
        public int getPrinterPort()
        {
            int p = 1;
            string portnum = "1";
            try
            {
                portnum = PrinterPort.ToUpper().Substring(3);
                p = int.Parse(portnum);
            }
            catch
            {
                Program.log.error(component, "Printer Port string not set");
                p = 1;
            }
            return p;
        }

        /// <summary>
        /// Set the printer port string (LPT1 through LPT8)
        /// </summary>
        /// <param name="port"></param>
        public void setPrinterPort(string port)
        {
            PrinterPort = port.ToUpper();
            hasChanged = true;
        }

        /// <summary>
        /// Get the DataPath - where the data will be saved
        /// </summary>
        /// <returns></returns>
        public string getDataPath()
        {
            return DataPath;
        }

        /// <summary>
        /// Set the Data Path - where the data will be saved
        /// </summary>
        /// <param name="dp"></param>
        public void setDataPath(string dp)
        {
            DataPath = dp;
        }


        /// <summary>
        /// Get the timeout between races
        /// </summary>
        /// <returns></returns>
        public int getBetweenRaceTime()
        {
            return betweenRaceTime;
        }

        public void setBetweenRaceTime(int newval)
        {
            betweenRaceTime = newval;
        }

        /// <summary>
        /// Get the timeout for the start gate
        /// </summary>
        /// <returns></returns>
        public TimeSpan getStartGateTime()
        {
            return startGateTime;
        }

        public void setStartGateTime(TimeSpan newval)
        {
            startGateTime = newval;
        }

        /// <summary>
        /// Get max time a race can run for
        /// </summary>
        /// <returns></returns>
        public TimeSpan getMaxRaceTime()
        {
            return maxRaceTime;
        }

        public void setMaxRaceTime(TimeSpan newval)
        {
            maxRaceTime = newval;
        }

        /// <summary>
        /// Get number of runs (extend race time if few competitors)
        /// </summary>
        /// <returns></returns>
        public int getNumberRuns()
        {
            return numberRuns;
        }

        public void setNumberRuns(int iRun)
        {
            numberRuns = iRun;
        }

        /// <summary>
        /// Load the configuration from the Program Settings
        /// </summary>
        /// <returns></returns>
        public bool LoadConfig()
        {
            Program.log.log("Load Configuration");
            hasChanged = true;

            Program.log.setLevel(Properties.Settings.Default.LogLevel);

            TrackPort = Properties.Settings.Default.TrackPort;
            Program.log.info(component, "Track Port: " + TrackPort);

            PrinterPort = Properties.Settings.Default.PrinterPort;
            Program.log.info(component, "Printer Port: " + PrinterPort);

            DataPath = Properties.Settings.Default.dataPath;
            Program.log.info(component, "Data Path: " + DataPath);

            NumberOfLanes = 0;
            if (Properties.Settings.Default.Lane1Exists)
            {
                NumberOfLanes++;
                LaneBit[0] = Properties.Settings.Default.Lane1Bit;
                LaneColors[0] = Properties.Settings.Default.Lane1Color;
                LaneInvert[0] = Properties.Settings.Default.Lane1Invert;
            }
            if (Properties.Settings.Default.Lane2Exists)
            {
                NumberOfLanes++;
                LaneBit[1] = Properties.Settings.Default.Lane2Bit;
                LaneColors[1] = Properties.Settings.Default.Lane2Color;
                LaneInvert[1] = Properties.Settings.Default.Lane2Invert;
            }
            if (Properties.Settings.Default.Lane3Exists)
            {
                NumberOfLanes++;
                LaneBit[2] = Properties.Settings.Default.Lane3Bit;
                LaneColors[2] = Properties.Settings.Default.Lane3Color;
                LaneInvert[2] = Properties.Settings.Default.Lane3Invert;
            }
            if (Properties.Settings.Default.Lane4Exists)
            {
                NumberOfLanes++;
                LaneBit[3] = Properties.Settings.Default.Lane4Bit;
                LaneColors[3] = Properties.Settings.Default.Lane4Color;
                LaneInvert[3] = Properties.Settings.Default.Lane4Invert;
            }
            if (Properties.Settings.Default.Lane5Exists)
            {
                NumberOfLanes++;
                LaneBit[4] = Properties.Settings.Default.Lane5Bit;
                LaneColors[4] = Properties.Settings.Default.Lane5Color;
                LaneInvert[4] = Properties.Settings.Default.Lane5Invert;
            }
            if (Properties.Settings.Default.Lane6Exists)
            {
                NumberOfLanes++;
                LaneBit[5] = Properties.Settings.Default.Lane6Bit;
                LaneColors[5] = Properties.Settings.Default.Lane6Color;
                LaneInvert[5] = Properties.Settings.Default.Lane6Invert;
            }

            if (Properties.Settings.Default.StartExists)
            {
                StartGate = Properties.Settings.Default.StartBit;
                StartInvert = Properties.Settings.Default.StartInvert;
            }
            if (Properties.Settings.Default.SolenoidExists)
            {
                StartSolenoid = Properties.Settings.Default.SolenoidBit;
                SolenoidInvert = Properties.Settings.Default.SolenoidInvert;
            }

            int t = Properties.Settings.Default.betweenRaceTime;
            betweenRaceTime = t;

            t = Properties.Settings.Default.startGateTime;
            startGateTime = new TimeSpan(0, 0, t);

            t = Properties.Settings.Default.maxRaceTime;
            maxRaceTime = new TimeSpan(0, 0, t);

            numberRuns = Properties.Settings.Default.numberRuns;

            return true;
        }

        /// <summary>
        /// Save the configuration to the Program Settings
        /// </summary>
        /// <returns></returns>
        public bool SaveConfig()
        {
            if (hasChanged)
            {
                Properties.Settings.Default.LogLevel = Program.log.getLevel();

                Properties.Settings.Default.TrackPort = TrackPort;
                Properties.Settings.Default.PrinterPort = PrinterPort;
                Properties.Settings.Default.dataPath = DataPath;

                if (NumberOfLanes > 0)
                {
                    Properties.Settings.Default.Lane1Exists = true;
                    Properties.Settings.Default.Lane1Bit = LaneBit[0];
                    Properties.Settings.Default.Lane1Color = LaneColors[0];
                    Properties.Settings.Default.Lane1Invert = LaneInvert[0];
                    NumberOfLanes--;
                }

                if (NumberOfLanes > 0)
                {
                    Properties.Settings.Default.Lane2Exists = true;
                    Properties.Settings.Default.Lane2Bit = LaneBit[1];
                    Properties.Settings.Default.Lane2Color = LaneColors[1];
                    Properties.Settings.Default.Lane2Invert = LaneInvert[1];
                    NumberOfLanes--;
                }

                if (NumberOfLanes > 0)
                {
                    Properties.Settings.Default.Lane3Exists = true;
                    Properties.Settings.Default.Lane3Bit = LaneBit[2];
                    Properties.Settings.Default.Lane3Color = LaneColors[2];
                    Properties.Settings.Default.Lane3Invert = LaneInvert[2];
                    NumberOfLanes--;
                }

                if (NumberOfLanes > 0)
                {
                    Properties.Settings.Default.Lane4Exists = true;
                    Properties.Settings.Default.Lane4Bit = LaneBit[3];
                    Properties.Settings.Default.Lane4Color = LaneColors[3];
                    Properties.Settings.Default.Lane4Invert = LaneInvert[3];
                    NumberOfLanes--;
                }

                if (NumberOfLanes > 0)
                {
                    Properties.Settings.Default.Lane5Exists = true;
                    Properties.Settings.Default.Lane5Bit = LaneBit[4];
                    Properties.Settings.Default.Lane5Color = LaneColors[4];
                    Properties.Settings.Default.Lane5Invert = LaneInvert[4];
                    NumberOfLanes--;
                }

                if (NumberOfLanes > 0)
                {
                    Properties.Settings.Default.Lane6Exists = true;
                    Properties.Settings.Default.Lane6Bit = LaneBit[5];
                    Properties.Settings.Default.Lane6Color = LaneColors[5];
                    Properties.Settings.Default.Lane6Invert = LaneInvert[5];
                    NumberOfLanes--;
                }

                if (StartGate >= 0)
                {
                    Properties.Settings.Default.StartExists = true;
                    Properties.Settings.Default.StartBit = StartGate;
                    Properties.Settings.Default.StartInvert = StartInvert;
                }
                else
                {
                    Properties.Settings.Default.StartExists = false;
                }

                if (StartSolenoid >= 0)
                {
                    Properties.Settings.Default.SolenoidExists = true;
                    Properties.Settings.Default.SolenoidBit = StartSolenoid;
                    Properties.Settings.Default.SolenoidInvert = SolenoidInvert;
                }
                else
                {
                    Properties.Settings.Default.SolenoidExists = false;
                }

                Properties.Settings.Default.startGateTime = startGateTime.Seconds;
                Properties.Settings.Default.betweenRaceTime = betweenRaceTime;
                Properties.Settings.Default.maxRaceTime = maxRaceTime.Seconds;
                Properties.Settings.Default.numberRuns = numberRuns;

                Properties.Settings.Default.Save();

                hasChanged = false;
            }
            return true;
        }

        /// <summary>
        /// Has the configuration changed
        /// </summary>
        /// <returns></returns>
        public bool HasChanged()
        {
            return hasChanged;
        }
    }
}
