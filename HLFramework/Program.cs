using Common.Data;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.UserSkins;

namespace HLFramework
{
    static class Program
    {
        public static sys_userinfo UserInfo = null;
        public static string UserToken = null;


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010");
            //UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");//皮肤主题




            //UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");//皮肤主题

            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");//皮肤主题

            BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();

            //string configFilePath = Application.StartupPath + "\\log4net.config";
            string configFilePath = Application.StartupPath + "\\log4net.xml";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));
            //log4net.Config.ConfiguratorAttribute.ConfigureAndWatch(new FileInfo(configFilePath));






            //异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"系统异常，请联系系统管理员！\r\n{e.Exception.Message}", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HandleException(e.Exception);
            //Exception ex = e.Exception;
            //CommonLogText.WriteLog(new Process().ProcessName, ex.ToString());
            ////MessageBox.Show(string.Format("捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace));
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {

                HandleException((System.Exception)e.ExceptionObject);
            }
        }

        public static void HandleException(Exception ex)
        {
            log4net.ILog log = (log4net.ILog)log4net.LogManager.GetLogger("LogToSqlite");
            log.Error(ex.Message, ex);
        }
    }
}
