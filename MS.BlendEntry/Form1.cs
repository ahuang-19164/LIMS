
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS.BlendEntry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //sys_userinfo userInfo = new sys_userinfo();
            //userInfo.names = "lll";
            //userInfo.id = 1;

            //CommonData.UserInfo = userInfo;
            //CommonDataRefresh.GetSystemInfo();
            ////CommonData.apiCommonUrl = ConfigurationManager.ConnectionStrings["urlstring"].ToString();
            //string startPath = Application.StartupPath;
            //ConfigInfos.GetConfigInfo(startPath);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmBlendEntry frmBlendEntry = new FrmBlendEntry();
            frmBlendEntry.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmBlendEntrys frmBlendEntrys = new FrmBlendEntrys();
            frmBlendEntrys.ShowDialog();
        }
    }
}
