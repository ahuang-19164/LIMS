using Common.BLL;

using System;

namespace WorkComm.logisticsInfos
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            //sys_userinfo userInfo = new sys_userinfo();
            //userInfo.names = "aaa";
            //userInfo.id = 1;

            //CommonData.UserInfo = userInfo;
            //CommonDataRefresh.GetSystemInfo();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmLogisticsBarcode frmLogisticsBarcode = new FrmLogisticsBarcode();
            frmLogisticsBarcode.Show();
        }
    }
}
