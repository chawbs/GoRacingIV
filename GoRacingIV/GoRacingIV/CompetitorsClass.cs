using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GoRacingIV
{
    class CompetitorsClass
    {
        private string component = "Competitors";

        private string[] competitors = new string[0];
        private string[] classes = new string[0];
        private string[] races = new string[0];

        private TimeSpan[] compTimes = new TimeSpan[0];

        private int numberLanes = 0;

        private int currentRace = 0;
        private int currentClass = 0;

        private string dataPath = "C:\\Program Files\\GoRacingIV";

        public CompetitorsClass()
        {
            competitors = new string[0];
        }

        public CompetitorsClass(int clas)
        {
            competitors = new string[0];
            currentClass = clas;
            loadCompetitors(currentClass);
        }

        public int getCurrentClass()
        {
            return currentClass;
        }

        public void setCurrentClass(int clas)
        {
            currentClass = clas;
        }

        public string getDataPath()
        {
            Program.cfg.LoadConfig();
            return Program.cfg.getDataPath();
        }

        public void setDataPath(string dp)
        {
            Program.cfg.setDataPath(dp);
            dataPath = dp;
            Program.cfg.SaveConfig();
        }

        public bool loadCompetitors(int clas)
        {
            bool ok = true;
            competitors = new string[0];
            setCurrentClass(clas);
            try
            {
                dataPath = getDataPath();
                string fn = Path.Combine(dataPath, "Competitors" + clas.ToString() + ".dat");
                using (StreamReader sr = new StreamReader(fn))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Array.Resize(ref competitors, competitors.Length + 1);
                        competitors[competitors.Length - 1] = line;
                    }
                }
            }
            catch (Exception e)
            {
                Program.log.error(component, "File Read Error:"+e.Message);
                ok = false;
            }
            compTimes = new TimeSpan[0];
            try
            {
                dataPath = getDataPath();
                string fn = Path.Combine(dataPath, "Competitors" + clas.ToString() + ".csv");
                using (StreamReader sr = new StreamReader(fn))
                {
                    string line;
                    string[] parts = new string[0];
                    char[] csv = { ',' };
                    while ((line = sr.ReadLine()) != null)
                    {
                        parts = line.Split(csv);
                        Array.Resize(ref compTimes, compTimes.Length + 1);
                        compTimes[compTimes.Length - 1] = TimeSpan.FromSeconds(double.Parse(parts[1]));
                    }
                }
            }
            catch (Exception e)
            {
                Program.log.error(component, "File Read Error:" + e.Message);
                ok = false;
            }
            if (compTimes.Length != competitors.Length)
                Array.Resize(ref compTimes, competitors.Length);
            if (competitors.Length == 0)
                ok = false;
            return ok;
        }

        public bool saveCompetitors(int clas)
        {
            //
            // Save names
            dataPath = getDataPath();
            string fn = Path.Combine(dataPath, "Competitors" + clas.ToString() + ".dat");
            using (StreamWriter sw = new StreamWriter(fn))
            {
                for (int x=0; x<competitors.Length; x++)
                    sw.WriteLine(competitors[x]);
            }
            //
            // Save times
            char[] sep = {'|'};
            fn = Path.Combine(dataPath, "Competitors" + clas.ToString() + ".csv");
            using (StreamWriter sw = new StreamWriter(fn))
            {
                for (int x = 0; x < compTimes.Length; x++)
                {
                    string[] com = competitors[x].Split(sep);
                    string tim = com[1] + "," + compTimes[x].Seconds.ToString() + "." + compTimes[x].Milliseconds.ToString();
                    sw.WriteLine(tim);
                }
            }
            return true;
        }

        public bool saveCompetitors(string inClass)
        {
            char[] cs = { '|' };
            string[] cc = inClass.Split(cs);
            return saveCompetitors(int.Parse(cc[0]));
        }

        public bool addCompetitor(string number, string name, string car, int clas)
        {
            string comp = number + "|" + name + "|" + car;
            Array.Resize(ref competitors, competitors.Length + 1);
            competitors[competitors.Length - 1] = comp;
            Array.Resize(ref compTimes, competitors.Length);
            return true;
        }

        public void addCompetitorTime(string number, string name, string car, TimeSpan tim)
        {
            string comp = number + "|" + name + "|" + car;
            for (int x = 0; x < compTimes.Length; x++)
            {
                if (competitors[x] == comp)
                    compTimes[x] = compTimes[x] + tim;
            }
        }

        public bool removeCompetitor(string number, string name, string car, int clas)
        {
            string comp = number + "|" + name + "|" + car;
            int x = 0;
            for (x = 0; x < competitors.Length; x++)
            {
                if (competitors[x] == comp)
                    break;
            }
            for (x = x+1; x < competitors.Length; x++)
            {
                competitors[x - 1] = competitors[x];
            }
            Array.Resize(ref competitors, competitors.Length - 1);
            Array.Resize(ref compTimes, competitors.Length);
            return true;
        }

        public void setNumberLanes(int numLanes)
        {
            numberLanes = numLanes;
        }

        public string getNextRaceDetails()
        {
            currentRace++;
            if (currentRace >= races.Length)
                return "";
            else
                return races[currentRace];
        }

        public string getFirstRaceDetails(string inClass)
        {
            if (inClass.IndexOf('|') > 0)
            {
                char[] cs = { '|' };
                string[] cc = inClass.Split(cs);
                currentRace = 0;
                if (loadCompetitors(int.Parse(cc[0])))
                {
                    shuffleCompetitors();
                    return races[currentRace];
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public void shuffleCompetitors()
        {
            int iRuns = Program.cfg.getNumberRuns();
            int iThis = 0;
            Array.Resize(ref races, competitors.Length * Program.cfg.getNumberRuns());
            int gap = (int)(competitors.Length / numberLanes);
            int max = competitors.Length;
            while (iThis < iRuns)
            {
                for (int x = 0; x < competitors.Length; x++)
                {
                    string race = "";
                    for (int y = 1; y <= numberLanes; y++)
                    {
                        int lane = (x + (y * gap)) % max;
                        race = race + "|" + competitors[lane];
                    }
                    race = race.Substring(1);
                    races[x + (iThis*competitors.Length)] = race;
                }
                gap += 1;
                iThis += 1;
            }
            return;
        }

        public string[] getCompetitors()
        {
            return competitors;
        }

        public TimeSpan[] getTimes()
        {
            return compTimes;
        }


        public bool loadClasses()
        {
            bool ok = true;
            classes = new string[0];
            try
            {
                dataPath = getDataPath();
                string fn = Path.Combine(dataPath, "Classes.dat");
                using (StreamReader sr = new StreamReader(fn))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Array.Resize(ref classes, classes.Length + 1);
                        classes[classes.Length - 1] = line;
                    }
                }
            }
            catch (Exception e)
            {
                Program.log.error(component, "File Read Error:" + e.Message);
                ok = false;
                Array.Resize(ref classes, 3);
                classes[0] = "1|Leaders Race";
                classes[1] = "2|Awana Race";
            }
            return ok;
        }

        public bool saveClasses()
        {
            //
            // Save names
            dataPath = getDataPath();
            string fn = Path.Combine(dataPath, "Classes.dat");
            using (StreamWriter sw = new StreamWriter(fn))
            {
                for (int x = 0; x < classes.Length; x++)
                    sw.WriteLine(classes[x]);
            }
            return true;
        }

        public string[] getClasses()
        {
            return classes;
        }

        public bool addClass(string number, string name)
        {
            string cl = number + "|" + name;
            Array.Resize(ref classes, classes.Length + 1);
            classes[classes.Length - 1] = cl;
            return true;
        }

        public bool removeClass(string number, string name)
        {
            string cl = number + "|" + name;
            int x = 0;
            for (x = 0; x < classes.Length; x++)
            {
                if (classes[x] == cl)
                    break;
            }
            for (x = x + 1; x < classes.Length; x++)
            {
                classes[x - 1] = classes[x];
            }
            Array.Resize(ref classes, classes.Length - 1);
            return true;
        }

        public string getNextClass()
        {
            currentClass++;
            if (currentClass >= classes.Length)
                return "";
            else
                return classes[currentClass];
        }

        public string getFirstClass()
        {
            currentClass = 0;
            return classes[currentClass];
        }

        public string getClassText(int clas)
        {
            return classes[clas];
        }

        public void setClassText(string txt)
        {
            char[] sep ={ '|' };
            string[] clas = null;
            try
            {
                clas = txt.Split(sep);
                if (clas.Length == 2)
                {
                    try
                    {
                        int x = int.Parse(clas[0]);
                        classes[x] = txt;
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}
