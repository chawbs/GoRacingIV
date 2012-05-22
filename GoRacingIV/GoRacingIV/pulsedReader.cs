using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using inpoutclass;

namespace GoRacingIV
{
    class pulsedReader
    {
        private static string component = "Track";

        private bool[] bit = new bool[16];
        
        private bool[] flipflop = new bool[16];
        private bool[] invert = new bool[16];

        private int solenoid = -1;
        private int startGate = -1;
        private int[] finishGate = { -1, -1, -1, -1, -1, -1 };
        private int[] positions = { -1, -1, -1, -1, -1, -1 };
        private int currentPosition = 1;

        // one for each sol / start / lane, 1/2/4/8/16/32/etc
        private int[] bitMask = { -1, -1, -1, -1, -1, -1, -1, -1 };

        private bool solenoidActive = false;
        private bool startActive = false;
        private bool[] laneActive = { false, false, false, false, false, false };

        private DateTime start;
        private DateTime startStart;
        private DateTime[] finish = new DateTime[6];

        private TimeSpan maxRaceTime = new TimeSpan(0, 0, 10);
        private TimeSpan maxStartTime = new TimeSpan(0, 0, 10);
        private int betweenTime = 10;

        private int portNumber = 1; // default LPT1

        public pulsedReader()
        {
            for (int x = 0; x < bit.Length; x++) bit[x] = false;
        }

        public void disableAll()
        {
            for (int x = 0; x < laneActive.Length; x++) laneActive[x] = false;
            solenoidActive = false;
            startActive = false;
        }

        public void setMaxRaceTime(TimeSpan newmax)
        {
            maxRaceTime = newmax;
        }

        public void setMaxStartTime(TimeSpan newmax)
        {
            maxStartTime = newmax;
        }

        public void setBetweenRaceTime(int newmax)
        {
            betweenTime = newmax;
        }

        public void setPortNumber(int number)
        {
            portNumber = number;
        }

        //
        // Don't use this routine - rather use the logic...
        public void runARace()
        {
            Program.log.fatal(component, "This should not be run as there is no interface...");
            //
            // If we have a solenoid - trip it after a random time
            solenoidTrigger();

            while (!startTriggered())
            {
                raceTick();
                Thread.Sleep(1);
            }

            while (!allFinished())
            {
                raceTick();
                Thread.Sleep(1);
            }
         
        }

        //
        // Race tick has to be dead fast!
        // All data comparisons must be done outside of this ticker
        public void raceTick()
        {
            //
            // Get the port reading
            int res = PPort.LptIn(portNumber);

            //
            // Translate the input byte into various results
            if (solenoid >= 0)
            {
                if ((res & (bitMask[0])) == (bitMask[0]))
                    bit[solenoid] = true;
                else
                    bit[solenoid] = false;
                if (invert[solenoid])
                    bit[solenoid] = !bit[solenoid];
                if (bit[solenoid])
                    if (!flipflop[solenoid])
                        flipflop[solenoid] = true;
                solenoidActive = flipflop[solenoid];
            }

            if (startGate >= 0)
            {
                if ((res & (bitMask[1])) == (bitMask[1]))
                    bit[startGate] = true;
                else
                    bit[startGate] = false;
                if (invert[startGate])
                    bit[startGate] = !bit[startGate];
                if (bit[startGate])
                    if (!flipflop[startGate])
                        flipflop[startGate] = true;
                startActive = flipflop[startGate];
            }

            int bb = 0;
            int bm = 0;
            DateTime mynow = DateTime.Now;
            for (int x = 0; x < 6; x++)
            {
                bm = x + 2;
                bb = finishGate[x];
                if (bb >= 0)
                {
                    if ((res & (bitMask[bm])) == (bitMask[bm]))
                        bit[bb] = true;
                    else
                        bit[bb] = false;
                    if (invert[bb])
                        bit[bb] = !bit[bb];

                    if (bit[bb])
                        if (!flipflop[bb])
                            flipflop[bb] = true;

                    if (laneActive[x])
                    {
                        if (flipflop[bb])
                        {
                            laneActive[x] = false;
                            finish[x] = mynow;
                            positions[x] = currentPosition;
                            currentPosition++;
                        }
                        if (mynow >= (start + maxRaceTime))
                        {
                            laneActive[x] = false;
                            finish[x] = mynow;
                            positions[x] = currentPosition;
                            currentPosition++;
                        }
                    }
                }
            }
        }

        public void setInvert(int bit)
        {
            invert[bit] = true;
        }

        public void reset()
        {
            for (int x = 0; x < 16; x++)
            {
                bit[x] = false;
                flipflop[x] = false;
            }
            for (int x = 0; x < 6; x++)
            {
                laneActive[x] = false;
            }
            currentPosition = 1;
        }

        public void solenoidTrigger()
        {
            startStart = DateTime.Now;

            if (solenoid == -1)
                return;

            //
            // Translate solenoid bit into byte to be output
            short output = (short)(1 << solenoid);

            if (invert[solenoid])
                output ^= output;

            PPort.LptOut(portNumber, output);

            return;
        }

        public void resetStartStart()
        {
            startStart = DateTime.Now;
        }

        public bool startTriggered()
        {
            if (startGate == -1)
            {
                start = DateTime.Now;
                for (int x = 0; x < 6; x++)
                {
                    if (finishGate[x] != -1)
                    {
                        laneActive[x] = true;
                        bit[finishGate[x]] = invert[x];
                    }
                    else
                    {
                        finish[x] = start;
                    }
                }
                return true;
            }
            else
            {
                // if we wait too long, start without me!
                if ((DateTime.Now - startStart) > maxStartTime)
                    startActive = true;

                if (startActive)
                {
                    start = DateTime.Now;
                    for (int x = 0; x < 6; x++)
                    {
                        if (finishGate[x] != -1)
                        {
                            laneActive[x] = true;
                            bit[finishGate[x]] = invert[x];
                        }
                        else
                        {
                            finish[x] = start;
                        }
                    }
                }
                return startActive;
            }
        }

        public bool laneFinished(int lane)
        {
            if (!laneActive[lane - 1])
                return true;
            else
                return false;
        }

        public int lanePosition(int lane)
        {
            if (laneFinished(lane))
                return positions[lane - 1];
            else
                return -1;
        }

        public bool allFinished()
        {
            for (int x = 0; x < 6; x++)
            {
                if (finishGate[x] == -1)
                {
                    // this lane is not used
                }
                else
                {
                    // we need to check this one out
                    if (laneActive[x])
                        return false;
                }
            }
            return true;
        }

        public void setFinishGate(int bit, int lane)
        {
            // if you pass in -1, you disable the lane
            finishGate[lane-1] = bit;
            bitMask[lane + 1] = (1 << bit);
        }

        public void setStartGate(int bit)
        {
            // if you pass in -1, you disable the start gate
            startGate = bit;
            bitMask[1] = (1 << bit);
        }

        public void setSolenoid(int bit)
        {
            // if you pass in -1, you disable the solenoid
            solenoid = bit;
            bitMask[0] = (1 << bit);
        }

        public TimeSpan laneTime(int lane)
        {
            return (finish[lane - 1] - start);
        }
    }
}
