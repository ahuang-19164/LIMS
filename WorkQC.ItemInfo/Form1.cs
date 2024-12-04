using Common.BLL;
using Common.Data;
using Common.SqlModel;
using System;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
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
            CommonDataRefresh.GetWorkType();
            GetQCInfo();
        }

        private void GetQCInfo()
        {
            sInfo sg = new sInfo();
            sg.TableName = "QC.RuleGroup";
            QCInfoData.DTRuleGroup = ApiHelpers.postInfo(sg);
            sInfo sqc = new sInfo();
            sqc.TableName = "QC.RuleQC";
            QCInfoData.DTRuleQC = ApiHelpers.postInfo(sqc);
            sInfo Plan = new sInfo();
            Plan.TableName = "QC.QCPlan";
            QCInfoData.DTQCPlan = ApiHelpers.postInfo(Plan);
            sInfo Grade = new sInfo();
            Grade.TableName = "QC.QCGrade";
            QCInfoData.DTQCGrade = ApiHelpers.postInfo(Grade);
            sInfo Batch = new sInfo();
            Batch.TableName = "QC.QCBatch";
            QCInfoData.DTQCBatch = ApiHelpers.postInfo(Batch);
            sInfo leC = new sInfo();
            leC.TableName = "QC.RuleClass";
            QCInfoData.DTRuleClass = ApiHelpers.postInfo(leC);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmQCSort qCSort = new FrmQCSort();
            qCSort.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmQCRule frmQCRule = new FrmQCRule();
            frmQCRule.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmQCGrade frmQCGrade = new FrmQCGrade();
            frmQCGrade.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FrmQCGroup frmQCGroup = new FrmQCGroup();
            frmQCGroup.Show();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            FrmQCPlan frmPlanInfo = new FrmQCPlan();
            frmPlanInfo.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmQCBatch frmQCBatch = new FrmQCBatch();
            frmQCBatch.Show();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            FrmQCItem frmQCItem = new FrmQCItem();
            frmQCItem.Show();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            FrmQCResultImg frmQCResulta = new FrmQCResultImg();
            frmQCResulta.Show();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            FrmQCResult frmQCResulta = new FrmQCResult();
            frmQCResulta.Show();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            FrmQCResultReport frmQCResultReport = new FrmQCResultReport();
            frmQCResultReport.ShowDialog();
        }
    }
}
