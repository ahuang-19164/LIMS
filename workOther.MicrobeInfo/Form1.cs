using Common.BLL;
using Common.Data;

using System;
using System.Windows.Forms;

namespace workOther.MicrobeInfo
{
    public partial class Form1 : Form
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
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmMicrobeSmear frmMicrobeSmear = new FrmMicrobeSmear();
            frmMicrobeSmear.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmMicrobeTest frmMicrobeTest = new FrmMicrobeTest();
            frmMicrobeTest.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmAntibioticGroup frmAntibioticGroup = new FrmAntibioticGroup();
            frmAntibioticGroup.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmMicrobeAntibiotic frmMicrobeAntibiotic = new FrmMicrobeAntibiotic();
            frmMicrobeAntibiotic.ShowDialog();
        }
    }
}
