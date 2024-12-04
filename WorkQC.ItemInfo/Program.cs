using DevExpress.LookAndFeel;
using System;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");//皮肤主题
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
