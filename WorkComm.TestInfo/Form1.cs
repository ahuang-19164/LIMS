using Common.BLL;
using Common.Data;

using System;

namespace WorkComm.TestInfo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            //sys_userinfo userInfo = new sys_userinfo();
            //userInfo.names = "lll";
            //userInfo.id = 1;

            //CommonData.UserInfo = userInfo;
            //CommonDataRefresh.GetSystemInfo();
            //CommonData.apiCommonUrl = ConfigurationManager.ConnectionStrings["urlstring"].ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            FrmSampleTest frmSampleTest = new FrmSampleTest();
            frmSampleTest.ShowDialog();
        }
    }
}
