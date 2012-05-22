using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GoRacingIV
{
    /// <summary>
    /// General logging
    /// </summary>
    public class LOG
    {
        private static string LogFileName = "gr4.log";
        private static int LogLevel = 4;

        private static int MaxLength = 10;

        public LOG()
        {
        }

        /// <summary>
        /// grab loacl time
        /// </summary>
        /// <returns></returns>
        private string localtime()
        {
            DateTime lt = DateTime.Now;
            string nowStr = lt.ToString("dd/MM/yyyy HH:mm:ss ");
            return nowStr;
        }

        /// <summary>
        ///  log this
        /// </summary>
        /// <param name="lvl"></param>
        /// <param name="component"></param>
        /// <param name="text"></param>
        private void logLine(string lvl, string component, string text)
        {
            StreamWriter sw = null;
            DateTime tout = DateTime.Now + (new TimeSpan(0, 0, 0, 0, 100));
            bool ok = false;
            while ((!ok) && (DateTime.Now < tout))
            {
                try
                {
                    sw = File.AppendText(LogFileName);
                    ok = true;
                }
                catch
                {
                    ok = false;
                }
            }
            if (sw != null)
            {
                sw.Write(localtime());
                sw.Write(" " + lvl + " " + component.PadRight(MaxLength) + " ");
                sw.WriteLine(text);
                sw.Close();
            }
        }

        /// <summary>
        /// log this - no log level check
        /// </summary>
        /// <param name="text"></param>
        public void log(string text)
        {
            logLine("LOG    ", "Logger", text);
        }

        /// <summary>
        /// everything goes through here
        /// </summary>
        /// <param name="lvl"></param>
        /// <param name="component"></param>
        /// <param name="text"></param>
        public void log(string lvl, string component, string text)
        {
            logLine(lvl, component, text);
        }

        /// <summary>
        /// If debug level, then log this
        /// </summary>
        /// <param name="component"></param>
        /// <param name="text"></param>
        public void debug(string component, string text)
        {
            if (LogLevel > 4)
                log("DEBUG  ", component, text);
        }

        /// <summary>
        /// if info level, then log this
        /// </summary>
        /// <param name="component"></param>
        /// <param name="text"></param>
        public void info(string component, string text)
        {
            if (LogLevel > 3)
                log("INFO   ", component, text);
        }

        /// <summary>
        ///  if warning level, then log this
        /// </summary>
        /// <param name="component"></param>
        /// <param name="text"></param>
        public void warning(string component, string text)
        {
            if (LogLevel > 2)
                log("WARNING", component, text);
        }

        /// <summary>
        /// If error level then log this
        /// </summary>
        /// <param name="component"></param>
        /// <param name="text"></param>
        public void error(string component, string text)
        {
            if (LogLevel > 1)
                log("ERROR  ", component, text);
        }

        /// <summary>
        /// FATAL - always log
        /// </summary>
        /// <param name="component"></param>
        /// <param name="text"></param>
        public void fatal(string component, string text)
        {
            log("*FATAL*", component, text);
        }

        /// <summary>
        /// Set new log level
        /// </summary>
        /// <param name="level"></param>
        public void setLevel(int level)
        {
            if (LogLevel!= level)
                log("New Log Level " + level.ToString());
            LogLevel = level;
        }

        /// <summary>
        /// Someone could pass in a string...
        /// </summary>
        /// <param name="lvl"></param>
        public void setLevel(string lvl)
        {
            int ilvl = int.Parse(lvl);
            setLevel(ilvl);
        }

        /// <summary>
        /// what level we running at
        /// </summary>
        /// <returns></returns>
        public int getLevel()
        {
            return (LogLevel);
        }

    }
}
