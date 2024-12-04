using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HLFramework
{
    public partial class FrmWebRoleInfo : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.RoleInfoWeb";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable DTRoleInfoAll;
        public FrmWebRoleInfo()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GroupInfo.Enabled = false;
            LookUpEdits.Formats(LEDepartmentNO);
            LookUpEdits.Formats(LECommpanyNO);
            GridLookUpEdites.Formats(GEDepartmentNO);
            GridLookUpEdites.Formats(GECompanyNO);
            GridControls.formartGridView(GVInfo);

            TextEdits.TextFormat(TESort);
        }
        private void FrmRoleInfo_Load(object sender, EventArgs e)
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "companyNO,sort";
            GCInfo.DataSource = DTRoleInfoAll = ApiHelpers.postInfo(selectInfo);
            LEDepartmentNO.DataSource = CommonData.DTDepertmentInfoAll;
            GEDepartmentNO.Properties.DataSource = CommonData.DTDepertmentInfoAll.Select("state=1 and dstate=0").CopyToDataTable();
            LECommpanyNO.DataSource = CommonData.DTCommonyInfoAll;
            GECompanyNO.Properties.DataSource = CommonData.DTCommonyInfoAll.Select("state=1 and dstate=0").CopyToDataTable();




            GVInfo.ExpandAllGroups();
            GVInfo.BestFitColumns();
        }
        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {
            foreach (BarItem BT in barManager1.Items)
            {
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

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 1;
            GroupInfo.Enabled = true;
            if (CommonData.DTRoleInfoAll != null)
            {
                if (CommonData.DTRoleInfoAll.Select("no is not NULL", "no DESC").Count() == 0)
                {
                    TENO.EditValue = 1;
                }
                else
                {
                    TENO.EditValue = Convert.ToInt32(CommonData.DTRoleInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
                }
            }
            else
            {
                TENO.EditValue = 1;
            }

            //TENO.EditValue = string.Format("{0:000}", Convert.ToInt32(DTRoleInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1);
            TEName.EditValue = "";
            TEshortNames.EditValue = "";
            TEcustomCode.EditValue = "";
            GEDepartmentNO.EditValue = "";
            TEPhone.EditValue = "";
            TEFax.EditValue = "";
            TEFunctions.EditValue = "";
            TESort.EditValue = "999";
            CBState.Checked = false;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            GroupInfo.Enabled = true;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue.ToString());
                pairs.Add("names", TEName.EditValue.ToString());
                pairs.Add("customCode", TEcustomCode.EditValue.ToString());
                pairs.Add("shortNames", TEshortNames.EditValue.ToString());
                pairs.Add("companyNO", GECompanyNO.EditValue.ToString());
                pairs.Add("departmentNO", GEDepartmentNO.EditValue.ToString());
                pairs.Add("phone", TEPhone.EditValue.ToString());
                pairs.Add("fax", TEFax.EditValue.ToString());
                pairs.Add("functions", TEFunctions.EditValue.ToString());
                pairs.Add("sort", TESort.EditValue.ToString());
                pairs.Add("state", CBState.Checked.ToString());
                pairs.Add("dstate", 0);
                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int i = ApiHelpers.postInfo(insertInfo);
            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    //pairs.Add("no", TENO.EditValue.ToString());
                    pairs.Add("names", TEName.EditValue.ToString());
                    pairs.Add("customCode", TEcustomCode.EditValue.ToString());
                    pairs.Add("shortNames", TEshortNames.EditValue.ToString());
                    pairs.Add("companyNO", GECompanyNO.EditValue.ToString());
                    pairs.Add("departmentNO", GEDepartmentNO.EditValue.ToString());
                    pairs.Add("phone", TEPhone.EditValue.ToString());
                    pairs.Add("fax", TEFax.EditValue.ToString());
                    pairs.Add("functions", TEFunctions.EditValue.ToString());
                    pairs.Add("sort", TESort.EditValue.ToString());
                    pairs.Add("state", CBState.Checked.ToString());
                    pairs.Add("dstate", 0);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int i = ApiHelpers.postInfo(updateInfo);
                }
            }
            EditState = 0;
            //CommonDataRefresh commSystem = new CommonDataRefresh();
            CommonDataRefresh.GetRoleInfo();
            FrmRoleInfo_Load(null, null);
            GroupInfo.Enabled = false;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));
                DataRow[] rows = DTRoleInfoAll.Select($"id='{SelectValueID}'");
                if (rows.Count() != 0)
                {
                    TENO.EditValue = rows[0]["no"].ToString();
                    TEName.EditValue = rows[0]["names"].ToString();
                    TEshortNames.EditValue = rows[0]["shortNames"].ToString();
                    TEcustomCode.EditValue = rows[0]["customCode"].ToString();
                    GECompanyNO.EditValue = rows[0]["companyNO"].ToString();
                    GEDepartmentNO.EditValue = rows[0]["departmentNO"].ToString();
                    TEPhone.EditValue = rows[0]["phone"].ToString();
                    TEFax.EditValue = rows[0]["fax"].ToString();
                    TEFunctions.EditValue = rows[0]["functions"].ToString();
                    TESort.EditValue = rows[0]["sort"].ToString();
                    CBState.Checked = rows[0]["state"] != DBNull.Value ? Convert.ToBoolean(Convert.ToBoolean(rows[0]["state"])) : false;
                }
            }
        }

        private void TEName_Leave(object sender, EventArgs e)
        {
            TEshortNames.EditValue = Common.ConvertShort.ConvertShortName.GetChineseSpell(TEName.EditValue.ToString());
        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                if (a > 0)
                {
                    CommonDataRefresh.GetWebRoleInfo();
                    GVInfo.DeleteSelectedRows();
                }
            }
        }
    }
}