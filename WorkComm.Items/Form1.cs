
using Common.BLL;
using Common.Conn;
using Common.Data;

using System;

namespace WorkComm.Items
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
            CommDataHandle.GetSystemInfo();
            WorkCommDataHandle.GetWorkAll();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 10; a++)
            {
                FrmItemApply frmWork = new FrmItemApply();
                frmWork.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmItemGroup frmTest = new FrmItemGroup();
            frmTest.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmItemTest testPower = new FrmItemTest();
            testPower.Show();
        }
    }
}

