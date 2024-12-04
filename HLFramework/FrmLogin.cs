using Common.BLL;
using Common.Conn;
using Common.Data;
using Common.JsonHelper;
using Common.MergePDF;
using Common.Model;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {

        log4net.ILog log = (log4net.ILog)log4net.LogManager.GetLogger("logerror");
        //string UserTokenInfo = "";
        public FrmLogin()
        {

            InitializeComponent();



            SystemDateTimeFormat.SetDateTimeFormat();

            //ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["Version"];
            //string str = cs.ConnectionString;
            //系统启动路径
            CommonData.StartPath = Application.StartupPath;
            ConnectionStringSettings urlstring = ConfigurationManager.ConnectionStrings["urlstring"];
            ConnectionStringSettings version = ConfigurationManager.ConnectionStrings["version"];
            ConnectionStringSettings style = ConfigurationManager.ConnectionStrings["style"];
            ApiConst.ConnApi= CommonData.ConnApi = urlstring.ConnectionString;
            CommonData.version = version.ConnectionString;
            CommonData.style = style.ConnectionString;





            ConfigInfos.GetConfigInfo(CommonData.StartPath);




            hyperlinkLabelControl1.Text = Application.CompanyName.ToString() + version.ConnectionString + "\n";




            ApiConst.UserToken = ConfigInfos.ReadConfigInfo("Logins");
            ApiConst.ApiHLimsInfo = ConfigInfos.ReadConfigInfo("HLimsInfo");
            ApiConst.ApiSelect = ConfigInfos.ReadConfigInfo("ApiSelect");
            ApiConst.ApiUpdate = ConfigInfos.ReadConfigInfo("ApiUpdate");
            ApiConst.ApiInsert = ConfigInfos.ReadConfigInfo("ApiInsert");
            ApiConst.ApiDelete = ConfigInfos.ReadConfigInfo("ApiDelete");
            ApiConst.ApiHide = ConfigInfos.ReadConfigInfo("ApiHide");
            ApiConst.ApiSaveDT = ConfigInfos.ReadConfigInfo("ApiSaveDT");

            ApiConst.BaseApiSelect = ConfigInfos.ReadConfigInfo("ApiSelect");
            ApiConst.BaseApiUpdate = ConfigInfos.ReadConfigInfo("ApiUpdate");
            ApiConst.BaseApiInsert = ConfigInfos.ReadConfigInfo("ApiInsert");
            ApiConst.BaseApiDelete = ConfigInfos.ReadConfigInfo("ApiDelete");
            ApiConst.BaseApiHide = ConfigInfos.ReadConfigInfo("ApiHide");
            ApiConst.BaseApiSaveDT = ConfigInfos.ReadConfigInfo("ApiSaveDT");

            ApiConst.UrlSysDownFile = ConfigInfos.ReadConfigInfo("SysDownFile");
            ApiConst.UrlSysUpFile = ConfigInfos.ReadConfigInfo("SysUpFile");
            ApiConst.UrlFlowDownFile = ConfigInfos.ReadConfigInfo("FlowDownFile");
            ApiConst.UrlFlowUpFile = ConfigInfos.ReadConfigInfo("FlowUpFile");
            ApiConst.UrlTestDownFile = ConfigInfos.ReadConfigInfo("TestDownFile");
            ApiConst.UrlTestUpFile = ConfigInfos.ReadConfigInfo("TestUpFile");
            ApiConst.UrlReportDownFile = ConfigInfos.ReadConfigInfo("ReportDownFile");
            ApiConst.UrlReportUpFile = ConfigInfos.ReadConfigInfo("ReportUpFile");

        }

        private void BTLand_Click(object sender, EventArgs e)
        {
            //FormInfo formInfo = new FormInfo();
            //formInfo.ShowDialog();
            //try
            //{
            if (TBPWD.EditValue == null && TBPWD.EditValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show("账号密码不能为空！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // 密码至少要包含6个字符，同时包含至少一个大写字母、一个小写字母、一个数字和一个特殊字符
                string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$";
                if (!Regex.IsMatch(TBPWD.EditValue.ToString().Trim(), pattern))
                {
                    MessageBox.Show("密码格式错误！\r\n（密码至少要包含6个字符，同时包含至少一个大写字母、一个小写字母、一个数字和一个特殊字符）", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TBUserName.EditValue == null || TBUserName.EditValue.ToString().Trim().Length == 0)
                    {
                        MessageBox.Show("账号密码不能为空！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoginModel info = new LoginModel();
                        info.UserNo = TBUserName.Text.Trim();
                        info.Password = TBPWD.Text.Trim();
                        info.UUID = "LoginIn";

                        string s = JsonHelper.SerializeObjct(info);
                        WebApiCallBack jm = ApiHelpers.postInfo(ApiConst.UserToken, s);

                        if (jm.code == 0)
                        {
                            UserInfoModel uinfo = JsonHelper.JsonConvertObject<UserInfoModel>(jm.data.ToString());
                            if (uinfo.userInfo.state == true)
                            {
                                CommonData.UserInfo = uinfo.userInfo;
                                CommonData.tokenInfo = uinfo.Authtoken;
                                FrmLoadInfo frmLoad = new FrmLoadInfo();
                                this.Hide();
                                frmLoad.Show();
                            }
                            else
                            {
                                MessageBox.Show("账号已经停止使用！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //else
                        //{
                        //    if(jm.msg!="")
                        //        MessageBox.Show(jm.msg, "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }
        }
        private void TBUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.TBPWD.Focus();
            }
        }

        private void TBPWD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                BTLand_Click(null, null);
            }
        }

        private void BTExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogo_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConfigurationManager.AppSettings.HasKeys())
                {
                    Dictionary<string, string> configInfos = new Dictionary<string, string>();
                    List<string> theKeys = new List<string>(); //保存Key的集合 
                                                               //List<string> theValues = new List<string>(); //保存Value的集合 
                                                               //遍历出所有的Key并添加进theKeys集合 
                    foreach (string theKey in ConfigurationManager.AppSettings.Keys)
                    {
                        configInfos.Add(theKey, ConfigurationManager.AppSettings.GetValues(theKey)[0]);
                    }
                    CommonData.configInfos = configInfos;
                    //CommonData.configInfos.TryGetValue("urlTokenString", out string a);

                }
            }
            catch (Exception ex)
            {
                log.Error(ex, ex);
            }

        }

        private void BTLand1_Click(object sender, EventArgs e)
        {
            //string[] ss = new string[] { "aaa", "bbbb", "cccc", "dddd" };
            //string asv= string.Join("****", ss);

            //MessageBox.Show(asv, "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);


            BTLand_Click(null, null);
        }

        private void BTExit1_Click(object sender, EventArgs e)
        {
            BTExit_Click(null, null);
        }

        private void TBPWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormTest formTest = new FormTest();
            formTest.ShowDialog();
        }
    }
}
