
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace WorkComm.TestInfo
{
    public partial class FrmChengePWD : DevExpress.XtraEditors.XtraForm
    {
        DataRow DRInfo;
        public FrmChengePWD(DataRow DRuserInfo)
        {
            InitializeComponent();
            DRInfo = DRuserInfo;
            if (DRInfo != null)
                TEUserName.EditValue = DRInfo["names"] != DBNull.Value ? DRInfo["names"].ToString() : "";

            TEUserPWD.Focus();
        }

        string userName = "";
        public string returNname()
        {
            return userName;
        }

        private void BTOK_Click(object sender, EventArgs e)
        {
            if (TEUserPWD.EditValue != null && TEUserPWD.EditValue.ToString().Trim().Length > 0)
            {
                string userPWD = DRInfo["pwd"] != DBNull.Value ? DRInfo["pwd"].ToString() : "";
                if (TEUserPWD.Text == userPWD)
                {
                    userName = TEUserName.EditValue.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("输入密码为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
