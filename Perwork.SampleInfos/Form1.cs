using Common.BLL;


using System;
using System.Windows.Forms;

namespace Perwork.SampleInfos
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            //InitializeComponent();
            //sys_userinfo userInfo = new sys_userinfo();
            //userInfo.names = "lll";
            //userInfo.id = 1;

            //CommonData.UserInfo = userInfo;
            //CommonDataRefresh.GetSystemInfo();
            ////CommonData.apiCommonUrl = ConfigurationManager.ConnectionStrings["urlstring"].ToString();
            //string startPath = Application.StartupPath;
            //ConfigInfos.GetConfigInfo(startPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSampleinfoEntry frmSampleinfoEntry = new FrmSampleinfoEntry();
            frmSampleinfoEntry.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSampleInfoExcel frmSampleInfoExcel = new FrmSampleInfoExcel();
            frmSampleInfoExcel.Show();
        }
    }
}
