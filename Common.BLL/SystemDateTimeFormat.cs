using System;
using System.Runtime.InteropServices;

namespace Common.BLL
{
    public class SystemDateTimeFormat
    {
        [DllImport("kernel32.dll", EntryPoint = "GetSystemDefaultLCID")]
        public static extern int GetSystemDefaultLCID();
        [DllImport("kernel32.dll", EntryPoint = "SetLocaleInfoA")]
        public static extern int SetLocaleInfo(int Locale, int LCType, string lpLCData);
        public const int LOCALE_SLONGDATE = 0x20;
        public const int LOCALE_SSHORTDATE = 0x1F;
        public const int LOCALE_STIME = 0x1003;

        public static void SetDateTimeFormat()
        {
            try
            {
                int x = GetSystemDefaultLCID();
                //SetLocaleInfo(x, LOCALE_STIME, "HH:mm:ss");        //时间格式
                SetLocaleInfo(x, LOCALE_SSHORTDATE, "yyyy-MM-dd");   //短日期格式  
                //SetLocaleInfo(x, LOCALE_SLONGDATE, "yyyy-MM-dd");   //长日期格式 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
