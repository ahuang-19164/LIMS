using Common.BLL;
using Common.Data;

using System;
using System.Windows.Forms;

namespace Common.CreateReport
{
    public partial class FrmReportHandle : DevExpress.XtraEditors.XtraForm
    {
        public FrmReportHandle()
        {
            InitializeComponent();
        }

        private void FrmReportHandle_Load(object sender, EventArgs e)
        {
            ModelUserInfo modelUserInfo = new ModelUserInfo();
            modelUserInfo.Names = "aaa";

            CommonData.UserInfo = modelUserInfo;
            CommonDataRefresh.GetSystemInfo();

            NBReportBind.LinkClicked += NBReportBind_LinkClicked;
            NBReportEdit.LinkClicked += NBReportEdit_LinkClicked;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void NBReportEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmReportEdit frmReportEdit = new FrmReportEdit();
            form(frmReportEdit);
        }
        private void NBReportBind_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmReportBind frmReportBind = new FrmReportBind();
            form(frmReportBind);
        }
        //panl内部切换窗体方法
        private void form(Form form)
        {
            foreach (Control item in this.panel1.Controls)
            {
                if (item is Form)
                {
                    Form ctl = (Form)item;
                    ctl.Close();
                    //((Form)item).Close();
                }
            }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.ControlBox = false;
            form.Parent = this.panel1;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
    }
}
