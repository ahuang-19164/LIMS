using Common.BLL;
using Common.Data;

using System;
using System.Windows.Forms;

namespace Finance.GroupPriceCheckInfo
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
            string startPath = Application.StartupPath;
            ConfigInfos.GetConfigInfo(startPath);
            CommonDataRefresh.GetSystemInfo();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmCheckInfo frmCheck = new FrmCheckInfo();
            frmCheck.Show();
        }
    }
}
