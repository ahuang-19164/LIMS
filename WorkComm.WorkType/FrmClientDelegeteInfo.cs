using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.WorkType
{
    public partial class FrmClientDelegeteInfo : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ClientDelegateInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmClientDelegeteInfo()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GEPersonNO);
            GridLookUpEdites.Formats(GEChargeLevelNO);
            GridLookUpEdites.Formats(RGEChargeLevelNO);
            GridLookUpEdites.Formats(RGEPersonNO);
            GridLookUpEdites.Formats(RGEagentNO);
            TextEdits.TextFormatDecimal(TEDiscount);
            TextEdits.TextFormat(TESort);
            GridControls.formartGridView(GVClientInfo);


            groupControl1.Enabled = false;



        }

        private void Frminfo_Load(object sender, EventArgs e)
        {


            GCClientnfo.DataSource = FrmDT = DTHelper.DTVisible(WorkCommData.DTClientDelegateInfo);
            GVClientInfo.BestFitColumns();



            RGEagentNO.DataSource = WorkCommData.DTClientAgent;
            RGEChargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEPersonNO.DataSource = CommonData.DTUserInfoAll;
            GEPersonNO.Properties.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
            GEChargeLevelNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeLevel);


            GVClientInfo.ExpandAllGroups();
            GVClientInfo.BestFitColumns();

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

        #region barmassage方法
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            groupControl1.Enabled = true;
            EditState = 1;

            if (WorkCommData.DTClientDelegateInfo == null)
            {
                TENO.EditValue = 1;
            }
            else
            {
                TENO.EditValue = Convert.ToInt32(WorkCommData.DTClientDelegateInfo.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }

            DESignTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEExpireTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            CEState.Checked = false;
            TENames.EditValue = "";
            TEShortNames.EditValue = "";
            TEPersonalize.EditValue = "";
            TERemark.EditValue = "";
            GEChargeLevelNO.EditValue = "";
            TEDiscount.EditValue = "";
            TEAddress.EditValue = "";
            TEQQ.EditValue = "";
            TEWechat.EditValue = "";
            TEEmail.EditValue = "";
            GEPersonNO.EditValue = "";
            TENamesEn.EditValue = "";
            TEContacts.EditValue = "";
            TEContactsPhone.EditValue = "";
            TESort.EditValue = 999;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("signTime", DESignTime.EditValue);
                pairs.Add("expireTime", DEExpireTime.EditValue);
                pairs.Add("state", CEState.EditValue);
                pairs.Add("dstate", 0);
                pairs.Add("no", TENO.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("shortNames", TEShortNames.EditValue);
                pairs.Add("personalize", TEPersonalize.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                pairs.Add("discount", TEDiscount.EditValue);
                pairs.Add("address", TEAddress.EditValue);
                pairs.Add("qq", TEQQ.EditValue);
                pairs.Add("wechat", TEWechat.EditValue);
                pairs.Add("email", TEEmail.EditValue);
                pairs.Add("personNO", GEPersonNO.EditValue);
                pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                pairs.Add("namesEn", TENamesEn.EditValue);
                pairs.Add("contacts", TEContacts.EditValue);
                pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                pairs.Add("sort", TESort.EditValue);

                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = ApiHelpers.postInfo(insertInfo);
            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();

                    pairs.Add("signTime", DESignTime.EditValue);
                    pairs.Add("expireTime", DEExpireTime.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("dstate", 0);
                    //pairs.Add("no", TENO.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);

                    pairs.Add("personalize", TEPersonalize.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("discount", TEDiscount.EditValue);

                    pairs.Add("address", TEAddress.EditValue);
                    pairs.Add("qq", TEQQ.EditValue);
                    pairs.Add("wechat", TEWechat.EditValue);
                    pairs.Add("email", TEEmail.EditValue);
                    pairs.Add("personNO", GEPersonNO.EditValue);
                    pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                    pairs.Add("namesEn", TENamesEn.EditValue);
                    pairs.Add("contacts", TEContacts.EditValue);
                    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                    pairs.Add("sort", TESort.EditValue);

                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }
            }


            EditState = 0;
            CommonDataRefresh.GetDelegeteCompanyInfo();
            Frminfo_Load(null, null);
            groupControl1.Enabled = false;

        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                    int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                    if (a > 0)
                    {
                        CommonDataRefresh.GetDelegeteCompanyInfo();
                        GVClientInfo.DeleteSelectedRows();
                    }

                
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion




        #region gridcontrol 方法



        private void GVClientInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (FrmDT != null)
                {
                    SelectValueID = Convert.ToInt32(GVClientInfo.GetFocusedRowCellValue("id"));

                    DataRow[] rows = FrmDT.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        DESignTime.EditValue = rows[0]["signTime"];
                        DEExpireTime.EditValue = rows[0]["expireTime"];

                        CEState.EditValue = Convert.ToBoolean(rows[0]["state"]);
                        TENO.EditValue = rows[0]["no"];
                        TENames.EditValue = rows[0]["names"];
                        TEShortNames.EditValue = rows[0]["shortNames"];
                        TEPersonalize.EditValue = rows[0]["personalize"];
                        TERemark.EditValue = rows[0]["remark"];
                        TEDiscount.EditValue = rows[0]["Discount"];
                        TEAddress.EditValue = rows[0]["address"];
                        TEQQ.EditValue = rows[0]["qq"];
                        TEWechat.EditValue = rows[0]["wechat"];
                        TEEmail.EditValue = rows[0]["email"];
                        GEPersonNO.EditValue = rows[0]["personNO"];
                        GEChargeLevelNO.EditValue = rows[0]["chargeLevelNO"];
                        TENamesEn.EditValue = rows[0]["namesEn"];
                        TEContacts.EditValue = rows[0]["contacts"];
                        TEContactsPhone.EditValue = rows[0]["contactsPhone"];
                        TESort.EditValue = rows[0]["sort"];
                    }
                }
            }
        }
        #endregion

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TENames.EditValue != null)
            {
                TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
            }

        }


    }
}
