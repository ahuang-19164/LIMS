using Common.BLL;
using Common.Data;
using System;
using System.Windows.Forms;

namespace Finance.ClientFundInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sys_userinfo userInfo = new sys_userinfo();;
            userInfo.names = "aaa";
            userInfo.id = 1;

            CommonData.UserInfo = userInfo;
            string startPath = Application.StartupPath;
            ConfigInfos.GetConfigInfo(startPath);
            CommonDataRefresh.GetSystemInfo();
            //http://localhost:8800/api/HLimsSelectInfo/PostInfo
            //http://localhost:8800/api/HLimsSelectInfo//PostInfo
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmFundInfo frmFundInfo = new FrmFundInfo();
            frmFundInfo.ShowDialog();
        }
    }
}
