using Common.BLL;
using Common.Data;

using System;
using System.Collections.Generic;
using System.Configuration;

namespace Finance.GroupChargeInfo
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
                throw ex;
                
            }
            //CommonData.apiCommonUrl = ConfigurationManager.ConnectionStrings["urlstring"].ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmGroupChargeInfo frmGroupChargeInfo = new FrmGroupChargeInfo();
            frmGroupChargeInfo.ShowDialog();
        }
    }
}
