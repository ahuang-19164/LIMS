using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmCompanyinfo : DevExpress.XtraEditors.XtraForm
    {
        string tableName = "Common.CompanyInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmCompanyinfo()
        {
            InitializeComponent();
            GridControls.formartGridView(GVInfo);

            TextEdits.TextFormat(TESort);
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

        }

        private void FrmCompanyinfo_Load(object sender, EventArgs e)
        {
            TextEdits.TextFormat(TESort);
            GCInfo.DataSource =DTHelper.DTVisible(CommonData.DTCommonyInfoAll);
            GVInfo.BestFitColumns();
        }
        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {

            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager1.Items)
            {
                if (CommonData.UserInfo.id != 1)
                if (CommonData.UserInfo.id != 1)
                {
                    if (BT.Tag != null)
                    {
                        if (CommonData.powerList.Contains(BT.Tag.ToString()))
                        {
                            BT.Enabled = true;
                        }
                        else
                        {
                            BT.Enabled = false;
                        }
                    }
                    else
                    {
                        BT.Enabled = false;
                    }
                }
                else
                {
                    BT.Enabled = true;
                }

            }

        }



        private void gridView1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                int handle = GVInfo.FocusedRowHandle;
                DataRow dr = GVInfo.GetFocusedDataRow();
                SelectValueID = Convert.ToInt32(dr["id"]);
                TENO.EditValue = dr["no"];
                TECompanyName.EditValue = dr["names"];
                TECompanyPhone.EditValue = dr["companyPhone"];
                TEShortNames.EditValue = dr["shortNames"];
                TECustomCode.EditValue = dr["customCode"];
                TECompanyFax.EditValue = dr["companyFax"];
                TECompanyEmail.EditValue = dr["companyEmail"];
                TECompanyAddress.EditValue = dr["companyAddress"];
                TECompanyWebsite.EditValue = dr["companyWebsite"];
                TECompanyPostalcode.EditValue = dr["companyPostalcode"];
                TECompanyRemark.EditValue = dr["companyRemark"];
                TECompanyBank.EditValue = dr["companyBank"];
                TECompanyAccount.EditValue = dr["companyAccount"];
                TESort.EditValue = dr["sort"];
                CBState.Checked = dr["state"]!=DBNull.Value? Convert.ToBoolean(dr["state"]):false;
            }

        }
        private void BTAddCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GroupInfo.Enabled = true;
            EditState = 1;
            if (CommonData.DTCommonyInfoAll != null)
            {
                if (CommonData.DTCommonyInfoAll.Select("no is not NULL", "no DESC").Count() == 0)
                {
                    TENO.EditValue = 1;
                }
                else
                {
                    TENO.EditValue = Convert.ToInt32(CommonData.DTCommonyInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
                }
            }
            else
            {
                TENO.EditValue = 1;
            }
            TECompanyName.EditValue = "";
            TEShortNames.EditValue = "";
            TECustomCode.EditValue = "";
            TECompanyPhone.EditValue = "";
            TECompanyFax.EditValue = "";
            TECompanyEmail.EditValue = "";
            TECompanyAddress.EditValue = "";
            TECompanyWebsite.EditValue = "";
            TECompanyPostalcode.EditValue = "";
            TECompanyRemark.EditValue = "";
            TECompanyBank.EditValue = "";
            TECompanyAccount.EditValue = "";
            TESort.EditValue = 999;
            CBState.Checked = false;
        }

        private void BTEditCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GroupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue);
                pairs.Add("names", TECompanyName.EditValue);
                pairs.Add("shortNames", TEShortNames.EditValue);
                pairs.Add("customCode", TECustomCode.EditValue);
                pairs.Add("companyPhone", TECompanyPhone.EditValue);
                pairs.Add("companyFax", TECompanyFax.EditValue);
                pairs.Add("companyEmail", TECompanyEmail.EditValue);
                pairs.Add("companyAddress", TECompanyAddress.EditValue);
                pairs.Add("companyWebsite", TECompanyWebsite.EditValue);
                pairs.Add("companyPostalcode", TECompanyPostalcode.EditValue);
                pairs.Add("companyRemark", TECompanyRemark.EditValue);
                pairs.Add("companyBank", TECompanyBank.EditValue);
                pairs.Add("companyAccount", TECompanyAccount.EditValue);
                pairs.Add("creatDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                pairs.Add("creater", CommonData.UserInfo.names);
                pairs.Add("state", CBState.Checked.ToString());
                pairs.Add("sort", TESort.EditValue);
                pairs.Add("dstate", 0);

                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = Convert.ToInt32(ApiHelpers.postInfo(insertInfo));

            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    //pairs.Add("no", TENO.EditValue);
                    pairs.Add("names", TECompanyName.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("customCode", TECustomCode.EditValue);
                    pairs.Add("companyPhone", TECompanyPhone.EditValue);
                    pairs.Add("companyFax", TECompanyFax.EditValue);
                    pairs.Add("companyEmail", TECompanyEmail.EditValue);
                    pairs.Add("companyAddress", TECompanyAddress.EditValue);
                    pairs.Add("companyWebsite", TECompanyWebsite.EditValue);
                    pairs.Add("companyPostalcode", TECompanyPostalcode.EditValue);
                    pairs.Add("companyRemark", TECompanyRemark.EditValue);
                    pairs.Add("companyBank", TECompanyBank.EditValue);
                    pairs.Add("companyAccount", TECompanyAccount.EditValue);
                    pairs.Add("creatDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    pairs.Add("creater", CommonData.UserInfo.names);
                    pairs.Add("state", CBState.Checked.ToString());
                    pairs.Add("sort", TESort.EditValue);
                    pairs.Add("dstate", 0);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;

                    int a = Convert.ToInt32(ApiHelpers.postInfo(updateInfo));
                    //int a = Convert.ToInt32(ApiHelpers.postInfo(updateInfo));
                }
            }
            EditState = 0;
            CommonDataRefresh.GetCommpanyInfo();
            FrmCompanyinfo_Load(null, null);
            GroupInfo.Enabled = false;

        }

        private void TECompanyName_Leave(object sender, EventArgs e)
        {
            TEShortNames.EditValue = Common.ConvertShort.ConvertShortName.GetChineseSpell(TECompanyName.EditValue.ToString());
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void BTDelectCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                if (a > 0)
                {
                    CommonDataRefresh.GetCommpanyInfo();
                    GVInfo.DeleteSelectedRows();
                }
            }
        }
    }
}
