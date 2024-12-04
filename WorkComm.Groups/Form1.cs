using Common.BLL;
using Common.Data;

using System;

namespace WorkComm.Groups
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {

            InitializeComponent();
            sys_userinfo userInfo = new sys_userinfo();
            userInfo.names = "aaa";
            userInfo.id = 1;

            CommonData.UserInfo = userInfo;
            CommonDataRefresh.GetSystemInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmWorkGroup frmWork = new FrmWorkGroup();
            frmWork.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmTestGroup frmTest = new FrmTestGroup();
            frmTest.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmTestPower testPower = new FrmTestPower();
            testPower.Show();
        }
    }
}
