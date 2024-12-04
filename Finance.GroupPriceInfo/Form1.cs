using Common.BLL;
using Common.Data;

using System;
using System.Windows.Forms;

namespace Finance.GroupPriceInfo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            sys_userinfo userInfo = new sys_userinfo();
            userInfo.names = "lll";
            userInfo.id = 1;

            CommonData.UserInfo = userInfo;
            CommonDataRefresh.GetSystemInfo();
            //CommonData.apiCommonUrl = ConfigurationManager.ConnectionStrings["urlstring"].ToString();
            string startPath = Application.StartupPath;
            ConfigInfos.GetConfigInfo(startPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGroupPriceChange frmGroupPriceChange = new FrmGroupPriceChange();
            frmGroupPriceChange.Show();
        }
    }
}
