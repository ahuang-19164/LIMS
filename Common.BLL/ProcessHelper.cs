using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Common.BLL
{
    public class ProcessHelper
    {
        /// <summary>
        /// 关闭进程方法
        /// </summary>
        /// <param name="strProcessesByName"></param>
        public static void KillProcess(string strProcessesByName)//关闭线程
        {


            Process[] proInfos = Process.GetProcesses();
            foreach (Process p in proInfos)//GetProcessesByName(strProcessesByName))
            {
                string aaa = p.ProcessName.ToUpper();
                string bbb = strProcessesByName.ToUpper();
                //if (p.ProcessName.ToUpper().Contains(strProcessesByName.ToUpper()))
                if (aaa == bbb)
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());   // process was terminating or can't be terminated - deal with it
                    }
                }
            }
        }
    }
}
