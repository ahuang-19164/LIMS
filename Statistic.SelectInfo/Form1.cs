using Common.BLL;
using Common.Data;

using System;
using System.Windows.Forms;

namespace Statistic.optInfo
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if(GCInfos.Tag!=null)
            //{
            //    FrmSelect frmSelect = new FrmSelect(GCInfos.Tag.ToString());
            //    Func<DataTable> func = frmSelect.ReturnSelectInfo;
            //    frmSelect.ShowDialog();
            //    GCInfos.DataSource = func();
            //}
            //else
            //{
            //    MessageBox.Show("系统错误","系统提示");
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmperSampleInfo frmperSampleInfo = new FrmperSampleInfo();
            frmperSampleInfo.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmtestSampleInfo frmperSampleInfo = new FrmtestSampleInfo();
            frmperSampleInfo.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmperWorkStatistic frmperWorkStatistic = new FrmperWorkStatistic();
            frmperWorkStatistic.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmtestWorkStatistic frmtestWorkStatistic = new FrmtestWorkStatistic();
            frmtestWorkStatistic.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FrmclientStatistic frmclientStatistic = new FrmclientStatistic();
            frmclientStatistic.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            FrmapplyStatistic frmapplyStatistic = new FrmapplyStatistic();
            frmapplyStatistic.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            FrmgroupStatistic frmgroupStatistic = new FrmgroupStatistic();
            frmgroupStatistic.Show();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            FrmitemStatistic frmitemStatistic = new FrmitemStatistic();
            frmitemStatistic.Show();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            FrmrecordStatistic frmrecordStatistic = new FrmrecordStatistic();
            frmrecordStatistic.Show();
        }
    }
}
