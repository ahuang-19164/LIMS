using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Finance.GroupChargeInfo
{
    public partial class FrmClientDiscountInfo : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ClientInfo";







        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmClientDiscountInfo()
        {
            InitializeComponent();

            SysPowerHelper.UserPower(barManager1);



            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GEPersonNO);
            GridLookUpEdites.Formats(GEChargeLevelNO);
            GridLookUpEdites.Formats(GEDistributionNO);
            GridLookUpEdites.Formats(GEClientTypeNO);
            GridLookUpEdites.Formats(GEAgentNO);
            GridLookUpEdites.Formats(RGEChargeLevelNO);
            GridLookUpEdites.Formats(RGEgroupchargeLevelNO);
            GridLookUpEdites.Formats(RGEPersonNO);
            GridLookUpEdites.Formats(RGEagentNO);
            GridLookUpEdites.Formats(RGEGroupNO);//格式化专业组控件


            TextEdits.TextFormatDecimal(TEDiscount);
            TextEdits.TextFormatDecimal(RTEDiscount);

            TextEdits.TextFormat(TEExceedDay);
            TextEdits.TextFormat(TESort);
            GridControls.formartGridView(GVClientInfo);
            GridControls.formartGridView(GVGroupInfo);

            groupControl1.Enabled = false;

            GCGroupInfo.DataSource = resetClientDT();

        }
        private DataTable resetClientDT()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("clientid", typeof(string));
            dataTable.Columns.Add("clientNO", typeof(string));
            dataTable.Columns.Add("groupNO", typeof(string));
            dataTable.Columns.Add("chargeLevelNO", typeof(string));
            dataTable.Columns.Add("discount", typeof(string));
            dataTable.Columns.Add("createTime", typeof(string));
            dataTable.Columns.Add("creater", typeof(string));
            dataTable.Columns.Add("state", typeof(bool));
            dataTable.Columns.Add("dstate", typeof(bool));


            return dataTable;
        }


        private void Frminfo_Load(object sender, EventArgs e)
        {


            GCClientnfo.DataSource = FrmDT = DTHelper.DTVisible(WorkCommData.DTClientInfo);
            GVClientInfo.BestFitColumns();


            RGEagentNO.DataSource = WorkCommData.DTClientAgent;
            RGEChargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEgroupchargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEPersonNO.DataSource = CommonData.DTUserInfoAll;
            RGEGroupNO.DataSource = WorkCommData.DTGroupTest;

            GEDistributionNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);
            GEPersonNO.Properties.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
            GEAgentNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);
            GEChargeLevelNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeLevel);
            GEClientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeClient);
            GEDistributionNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeDistribution);

            GVClientInfo.ExpandAllGroups();
            GVClientInfo.BestFitColumns();

        }

        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {

            //string[] PowerList = CommonData.powerList;
            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager1.Items)
            {
                if (CommonData.UserInfo.id != 1)
                {
                    if (BT.Tag != null)
                    {
                        //if (CommonData.powerList.Contains(BT.Tag.ToString()))
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
        //private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{

        //    groupControl1.Enabled = true;
        //    EditState = 1;

        //    if (WorkCommData.DTClientInfo == null)
        //    {
        //        TENO.EditValue = 1;
        //    }
        //    else
        //    {
        //        TENO.EditValue = Convert.ToInt32(WorkCommData.DTClientInfo.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
        //    }

        //    DESignTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        //    DEExpireTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        //    TENames.EditValue = "";
        //    TEShortNames.EditValue = "";
        //    GEClientTypeNO.EditValue = "";
        //    GEAgentNO.EditValue = "";
        //    TEProvince.EditValue = "";
        //    TEInvoiceNames.EditValue = "";
        //    TEInvoiceCode.EditValue = "";
        //    TEInvoicePhone.EditValue = "";
        //    TEInvoiceAddress.EditValue = "";
        //    TEPersonalize.EditValue = "";
        //    TERemark.EditValue = "";
        //    GEChargeLevelNO.EditValue = "";
        //    TEDiscount.EditValue = "";
        //    GEDistributionNO.EditValue = "";
        //    TEPassWord.EditValue = "";
        //    TEExceedDay.EditValue = "";
        //    TEAddress.EditValue = "";
        //    TEQQ.EditValue = "";
        //    TEWechat.EditValue = "";
        //    TEEmail.EditValue = "";
        //    GEPersonNO.EditValue = "";
        //    TECity.EditValue = "";
        //    TEArea.EditValue = "";
        //    TEReportNames.EditValue = "";
        //    TENamesEn.EditValue = "";
        //    TEContacts.EditValue = "";
        //    TEContactsPhone.EditValue = "";
        //    TESort.EditValue = 999;
        //}

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


                pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                pairs.Add("discount", TEDiscount.EditValue);
                //pairs.Add("signTime", DESignTime.EditValue);
                //    pairs.Add("expireTime", DEExpireTime.EditValue);
                //    pairs.Add("dstate",0);
                //    pairs.Add("no", TENO.EditValue);
                //    pairs.Add("names", TENames.EditValue);
                //    pairs.Add("shortNames", TEShortNames.EditValue);
                //    pairs.Add("clientTypeNO", GEClientTypeNO.EditValue);
                //    pairs.Add("agentNO", GEAgentNO.EditValue);
                //    pairs.Add("province", TEProvince.EditValue);
                //    pairs.Add("invoicePhone", TEInvoicePhone.EditValue);
                //    pairs.Add("invoiceAddress", TEInvoiceAddress.EditValue);
                //    pairs.Add("personalize", TEPersonalize.EditValue);
                //    pairs.Add("remark", TERemark.EditValue);
                //    //pairs.Add("discount", TEDiscount.EditValue);
                //    pairs.Add("distributionNO", GEDistributionNO.EditValue);
                //    pairs.Add("passWord", TEPassWord.EditValue);
                //    pairs.Add("exceedDay", TEExceedDay.EditValue);
                //    pairs.Add("invoiceNames", TEInvoiceNames.EditValue);
                //    pairs.Add("invoiceCode", TEInvoiceCode.EditValue);
                //    pairs.Add("address", TEAddress.EditValue);
                //    pairs.Add("qq", TEQQ.EditValue);
                //    pairs.Add("wechat", TEWechat.EditValue);
                //    pairs.Add("email", TEEmail.EditValue);
                //    pairs.Add("personNO", GEPersonNO.EditValue);
                //    //pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                //    pairs.Add("city", TECity.EditValue);
                //    pairs.Add("area", TEArea.EditValue);
                //    pairs.Add("reportNames", TEReportNames.EditValue);
                //    pairs.Add("namesEn", TENamesEn.EditValue);
                //    pairs.Add("contacts", TEContacts.EditValue);
                //    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                //    pairs.Add("sort", TESort.EditValue);

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
                    pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                    pairs.Add("discount", TEDiscount.EditValue);
                    //pairs.Add("signTime", DESignTime.EditValue);
                    //    pairs.Add("expireTime", DEExpireTime.EditValue);
                    //    pairs.Add("dstate",0);
                    //    pairs.Add("no", TENO.EditValue);
                    //    pairs.Add("names", TENames.EditValue);
                    //    pairs.Add("shortNames", TEShortNames.EditValue);
                    //    pairs.Add("clientTypeNO", GEClientTypeNO.EditValue);
                    //    pairs.Add("agentNO", GEAgentNO.EditValue);
                    //    pairs.Add("province", TEProvince.EditValue);
                    //    pairs.Add("invoicePhone", TEInvoicePhone.EditValue);
                    //    pairs.Add("invoiceAddress", TEInvoiceAddress.EditValue);
                    //    pairs.Add("personalize", TEPersonalize.EditValue);
                    //    pairs.Add("remark", TERemark.EditValue);
                    //    //pairs.Add("discount", TEDiscount.EditValue);
                    //    pairs.Add("distributionNO", GEDistributionNO.EditValue);
                    //    pairs.Add("passWord", TEPassWord.EditValue);
                    //    pairs.Add("exceedDay", TEExceedDay.EditValue);
                    //    pairs.Add("invoiceNames", TEInvoiceNames.EditValue);
                    //    pairs.Add("invoiceCode", TEInvoiceCode.EditValue);
                    //    pairs.Add("address", TEAddress.EditValue);
                    //    pairs.Add("qq", TEQQ.EditValue);
                    //    pairs.Add("wechat", TEWechat.EditValue);
                    //    pairs.Add("email", TEEmail.EditValue);
                    //    pairs.Add("personNO", GEPersonNO.EditValue);
                    //    //pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                    //    pairs.Add("city", TECity.EditValue);
                    //    pairs.Add("area", TEArea.EditValue);
                    //    pairs.Add("reportNames", TEReportNames.EditValue);
                    //    pairs.Add("namesEn", TENamesEn.EditValue);
                    //    pairs.Add("contacts", TEContacts.EditValue);
                    //    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                    //    pairs.Add("sort", TESort.EditValue);

                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);

                }
            }


            EditState = 0;
            CommonDataRefresh.GetClientInfo();
            Frminfo_Load(null, null);
            groupControl1.Enabled = false;

        }

        //private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (SelectValueID != 0)
        //    {
        //        DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            hideInfo hideInfo = new hideInfo();
        //            hideInfo.TableName = tableName;
        //            hideInfo.DataValueID = SelectValueID;
        //            ApiHelpers.postInfo(hideInfo);
        //            CommonDataRefresh.GetClientInfo();
        //            GVClientInfo.DeleteSelectedRows();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        #endregion




        #region gridcontrol 方法
        private void gridView1_Click(object sender, EventArgs e)
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
                        TENO.EditValue = rows[0]["no"];
                        TENames.EditValue = rows[0]["names"];
                        TEShortNames.EditValue = rows[0]["shortNames"];
                        GEClientTypeNO.EditValue = rows[0]["clientTypeNO"];
                        GEAgentNO.EditValue = rows[0]["agentNO"];
                        TEProvince.EditValue = rows[0]["province"];
                        TEInvoicePhone.EditValue = rows[0]["invoicePhone"];
                        TEInvoiceAddress.EditValue = rows[0]["invoiceAddress"];
                        TEPersonalize.EditValue = rows[0]["personalize"];
                        TERemark.EditValue = rows[0]["remark"];
                        TEDiscount.EditValue = rows[0]["Discount"];
                        GEDistributionNO.EditValue = rows[0]["distributionNO"];
                        TEPassWord.EditValue = rows[0]["passWord"];
                        TEExceedDay.EditValue = rows[0]["exceedDay"];
                        TEInvoiceNames.EditValue = rows[0]["invoiceNames"];
                        TEInvoiceCode.EditValue = rows[0]["invoiceCode"];
                        TEAddress.EditValue = rows[0]["address"];
                        TEQQ.EditValue = rows[0]["qq"];
                        TEWechat.EditValue = rows[0]["wechat"];
                        TEEmail.EditValue = rows[0]["email"];
                        GEPersonNO.EditValue = rows[0]["personNO"];
                        GEChargeLevelNO.EditValue = rows[0]["chargeLevelNO"];
                        TECity.EditValue = rows[0]["city"];
                        TEArea.EditValue = rows[0]["area"];
                        TEReportNames.EditValue = rows[0]["reportNames"];
                        TENamesEn.EditValue = rows[0]["namesEn"];
                        TEContacts.EditValue = rows[0]["contacts"];
                        TEContactsPhone.EditValue = rows[0]["contactsPhone"];
                        TESort.EditValue = rows[0]["sort"];

                        sInfo selectimg = new sInfo();
                        //selectimg.values = "filestring";
                        selectimg.TableName = "WorkComm.ClientGroup";
                        selectimg.wheres = $"clientNO='{TENO.EditValue}' and dstate=0";
                        DataTable dt = ApiHelpers.postInfo(selectimg);
                        if (dt != null)
                        {
                            GCGroupInfo.DataSource = dt;
                        }
                        else
                        {
                            GCGroupInfo.DataSource = resetClientDT();
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            if (e.Info.IsRowIndicator && e.RowHandle >= -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        #endregion

        private void TENames_Leave(object sender, EventArgs e)
        {

        }

        #region  toolStrip事件


        private void TBTAdd_Click(object sender, EventArgs e)
        {
            if (TENO.EditValue != null)
            {
                //EnabledColors.SetControlEnabled(GCReference, true);
                GVGroupInfo.AddNewRow();
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的客户信息", "系统提示");
            }
        }

        private void TBTSave_Click(object sender, EventArgs e)
        {
            if (TENO.EditValue != null)
            {
                GVGroupInfo.FocusedRowHandle = -1;
                DataTable dataTable = GCGroupInfo.DataSource as DataTable;


                ApiHelpers.postInfo(dataTable, "WorkComm.ClientGroup");
                //EnabledColors.SetControlEnabled(GCReference, false);
                CommonDataRefresh.GetItemReference();
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TBTEdit_Click(object sender, EventArgs e)
        {

        }

        private void TBEDel_Click(object sender, EventArgs e)
        {
            if (GVGroupInfo.GetFocusedDataRow() != null)
            {
                int id = Convert.ToInt32(GVGroupInfo.GetFocusedRowCellValue("id"));
                DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = "WorkComm.ClientGroup";
                    hideInfo.DataValueID = id;
                    //ApiHelpers.postInfo(hideInfo);
                    ApiHelpers.postInfo(hideInfo);
                    GVGroupInfo.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的客户信息", "系统提示");
            }
        }

        #endregion

        private void GVGroupInfo_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

            if (GVClientInfo.GetFocusedDataRow() != null)
            {
                int id = Convert.ToInt32(GVClientInfo.GetFocusedRowCellValue("id"));
                GridView view = sender as GridView;
                view.SetRowCellValue(e.RowHandle, view.Columns["clientid"], id);
                view.SetRowCellValue(e.RowHandle, view.Columns["clientNO"], GVClientInfo.GetFocusedRowCellValue("no"));
                view.SetRowCellValue(e.RowHandle, view.Columns["state"], true);
                view.SetRowCellValue(e.RowHandle, view.Columns["dstate"], false);
                view.SetRowCellValue(e.RowHandle, view.Columns["creater"], CommonData.UserInfo.names);
                view.SetRowCellValue(e.RowHandle, view.Columns["createTime"], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //view.SetRowCellValue(e.RowHandle, view.Columns["state"], true);
                //view.SetRowCellValue(e.RowHandle, view.Columns["dstate"], false);
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的客户信息", "系统提示");
            }

        }
    }
}
