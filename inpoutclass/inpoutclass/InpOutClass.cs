using System;
using System.Runtime.InteropServices;

namespace inpoutclass
{
    /// <summary>
    /// P. Port wrapper class for DLPortIO.dll
    /// Simple input and output based on LPT port number. Handles 1 through 8 only
    /// </summary>
    public class PPort
    {
        [DllImport("DLPortIO.dll", EntryPoint = "DlPortWritePortUshort")]
        public static extern void Output(int address, short value);

        [DllImport("DLPortIO.dll", EntryPoint = "DlPortReadPortUshort")]
        public static extern short Input(int address);

        public static short[] addr = { 0x378, 0x278, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// set the LPT port address
        /// </summary>
        /// <param name="lpt"></param>
        /// <param name="value"></param>
        public static void setAddress(int lpt, short value)
        {
            try { addr[lpt - 1] = value; }
            catch { }
        }

        /// <summary>
        /// get the LPT port address
        /// </summary>
        /// <param name="lpt"></param>
        /// <returns></returns>
        public static short getAddress(int lpt)
        {
            short value = 0;
            try { value = addr[lpt - 1]; }
            catch { }
            return value;
        }

        /// <summary>
        /// Output the short value to the specified port
        /// </summary>
        /// <param name="lpt"></param>
        /// <param name="value"></param>
        public static void LptOut(int lpt, short value)
        {
            try { Output(addr[lpt - 1], value); }
            catch { }
        }

        /// <summary>
        /// Read the short value from the specified port
        /// </summary>
        /// <param name="lpt"></param>
        /// <returns></returns>
        public static short LptIn(int lpt)
        {
            short value = 0;
            try { value = Input(addr[lpt - 1]); }
            catch { }
            return (value);
        }
    }
}
