using Common.BLL;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmChengePWD : DevExpress.XtraEditors.XtraForm
    {

        public FrmChengePWD()
        {
            InitializeComponent();
            TBUserName.Text = CommonData.UserInfo.names;
        }

        private void BTChangeOK_Click(object sender, EventArgs e)
        {
            if (TBUserPWD1.Text.Trim().Length == 0 || TBUserPWD2.Text.Length == 0)
            {
                MessageBox.Show("请填写修改后的密码！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (TBUserPWD1.Text.Trim() == TBUserPWD2.Text.Trim())
                {

                    string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$";
                    if (!Regex.IsMatch(TBUserPWD2.Text.Trim(), pattern))
                    {
                        MessageBox.Show("密码格式错误！\r\n（密码至少要包含6个字符，同时包含至少一个大写字母、一个小写字母、一个数字和一个特殊字符）", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("是否确认修改！", "系统提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {

                            int ValueID = CommonData.UserInfo.id;
                            uInfo updateInfo = new uInfo();
                            updateInfo.TableName = "Common.UserInfo";
                            updateInfo.value = $"pwd='{TBUserPWD2.Text.Trim()}'";
                            updateInfo.wheres = $"id={ValueID}";
                            int i = ApiHelpers.postInfo(updateInfo);
                            MessageBox.Show("修改成功！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请确认两次输入的密码一致！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBUserPWD1.Text = null;
                    TBUserPWD2.Text = null;
                }
            }
        }

        private void BTchangeClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
