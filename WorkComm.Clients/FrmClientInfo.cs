using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Clients
{
    public partial class FrmClientInfo : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ClientInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmClientInfo()
        {
            InitializeComponent();
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
            //groupControl1.Enabled = false;
            xtraTabControl1.Enabled = false;

            //RDT = WorkCommData.DTItemReference.Clone();
            GCGroupInfo.DataSource = resetClientDT();


        }

        private DataTable resetClientDT()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id",typeof(int));
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


            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "sort";
            GCClientnfo.DataSource = FrmDT = ApiHelpers.postInfo(selectInfo);



            //GCClientnfo.DataSource = FrmDT = DTHelper.DTVisible(WorkCommData.DTClientInfo);
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
            //GVClientInfo.BestFitColumns();

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

            //groupControl1.Enabled = true;
            xtraTabControl1.Enabled = true;
            EditState = 1;

            //if (WorkCommData.DTClientInfo == null)
            //{
            //    TENO.EditValue = 1;
            //}
            //else
            //{
            //    TENO.EditValue = Convert.ToInt32(WorkCommData.DTClientInfo.Select("no is not NULL and no!=''", "no DESC")[0]["no"]) + 1;
            //}
            TENO.EditValue ="";

            TENO.Enabled = true;

            DESignTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEExpireTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            CEwebstate.Checked = false;
            CEState.Checked = true;
            CEreportstate.Checked = true;
            TENames.EditValue = "";
            TEShortNames.EditValue = "";
            GEClientTypeNO.EditValue = "";
            GEAgentNO.EditValue = "";
            TEProvince.EditValue = "";
            TEInvoiceNames.EditValue = "";
            TEInvoiceCode.EditValue = "";
            TEInvoicePhone.EditValue = "";
            TEInvoiceAddress.EditValue = "";
            TEPersonalize.EditValue = "";
            TERemark.EditValue = "";
            GEChargeLevelNO.EditValue = "";
            TEDiscount.EditValue = "";
            GEDistributionNO.EditValue = "";
            TEPassWord.EditValue = "";
            TEExceedDay.EditValue = "";
            TEAddress.EditValue = "";
            TEQQ.EditValue = "";
            TEWechat.EditValue = "";
            TEEmail.EditValue = "";
            GEPersonNO.EditValue = "";
            TECity.EditValue = "";
            TEArea.EditValue = "";
            TEReportNames.EditValue = "";
            TENamesEn.EditValue = "";
            TEContacts.EditValue = "";
            TEContactsPhone.EditValue = "";
            TESort.EditValue = 999;
            PEClientImg.Image = bitmaps = null;

        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //groupControl1.Enabled = true;
            xtraTabControl1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                if(TENO.EditValue!=null&&TENO.EditValue.ToString().Trim().Length>0)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("signTime", DESignTime.EditValue);
                    pairs.Add("expireTime", DEExpireTime.EditValue);
                    pairs.Add("webstate", CEwebstate.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("reportstate", CEreportstate.EditValue);
                    pairs.Add("dstate", 0);
                    pairs.Add("no", TENO.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("clientTypeNO", GEClientTypeNO.EditValue);
                    pairs.Add("agentNO", GEAgentNO.EditValue);
                    pairs.Add("province", TEProvince.EditValue);
                    pairs.Add("invoicePhone", TEInvoicePhone.EditValue);
                    pairs.Add("invoiceAddress", TEInvoiceAddress.EditValue);
                    pairs.Add("personalize", TEPersonalize.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("discount", TEDiscount.EditValue);
                    pairs.Add("distributionNO", GEDistributionNO.EditValue);
                    pairs.Add("passWord", TEPassWord.EditValue);
                    pairs.Add("exceedDay", TEExceedDay.EditValue);
                    pairs.Add("invoiceNames", TEInvoiceNames.EditValue);
                    pairs.Add("invoiceCode", TEInvoiceCode.EditValue);
                    pairs.Add("address", TEAddress.EditValue);
                    pairs.Add("qq", TEQQ.EditValue);
                    pairs.Add("wechat", TEWechat.EditValue);
                    pairs.Add("email", TEEmail.EditValue);
                    pairs.Add("personNO", GEPersonNO.EditValue);
                    pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                    pairs.Add("city", TECity.EditValue);
                    pairs.Add("area", TEArea.EditValue);
                    pairs.Add("reportNames", TEReportNames.EditValue);
                    pairs.Add("namesEn", TENamesEn.EditValue);
                    pairs.Add("contacts", TEContacts.EditValue);
                    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                    pairs.Add("sort", TESort.EditValue);

                    iInfo insertInfo = new iInfo();
                    insertInfo.TableName = tableName;
                    insertInfo.values = pairs;
                    int a = ApiHelpers.postInfo(insertInfo);



                    iInfo insertInfoimg = new iInfo();
                    insertInfoimg.MessageShow = 1;
                    Dictionary<string, object> pairsimg = new Dictionary<string, object>();
                    pairsimg.Add("clientNO", TENO.EditValue);
                    pairsimg.Add("filestring", FileConverHelpers.BitmapTostring(bitmaps));
                    pairsimg.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    pairsimg.Add("state", 1);
                    insertInfoimg.values = pairsimg;
                    insertInfoimg.TableName = "WorkComm.ClientImg";
                    a = ApiHelpers.postInfo(insertInfoimg);
                    TENO.Enabled = false;
                }
                else
                {
                    MessageBox.Show("客户编号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();

                    pairs.Add("signTime", DESignTime.EditValue);
                    pairs.Add("expireTime", DEExpireTime.EditValue);
                    pairs.Add("webstate", CEwebstate.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("reportstate", CEreportstate.EditValue);
                    pairs.Add("dstate", 0);
                    //pairs.Add("no", TENO.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("clientTypeNO", GEClientTypeNO.EditValue);
                    pairs.Add("agentNO", GEAgentNO.EditValue);
                    pairs.Add("province", TEProvince.EditValue);
                    pairs.Add("invoicePhone", TEInvoicePhone.EditValue);
                    pairs.Add("invoiceAddress", TEInvoiceAddress.EditValue);
                    pairs.Add("personalize", TEPersonalize.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("discount", TEDiscount.EditValue);
                    pairs.Add("distributionNO", GEDistributionNO.EditValue);
                    pairs.Add("passWord", TEPassWord.EditValue);
                    pairs.Add("exceedDay", TEExceedDay.EditValue);
                    pairs.Add("invoiceNames", TEInvoiceNames.EditValue);
                    pairs.Add("invoiceCode", TEInvoiceCode.EditValue);
                    pairs.Add("address", TEAddress.EditValue);
                    pairs.Add("qq", TEQQ.EditValue);
                    pairs.Add("wechat", TEWechat.EditValue);
                    pairs.Add("email", TEEmail.EditValue);
                    pairs.Add("personNO", GEPersonNO.EditValue);
                    pairs.Add("chargeLevelNO", GEChargeLevelNO.EditValue);
                    pairs.Add("city", TECity.EditValue);
                    pairs.Add("area", TEArea.EditValue);
                    pairs.Add("reportNames", TEReportNames.EditValue);
                    pairs.Add("namesEn", TENamesEn.EditValue);
                    pairs.Add("contacts", TEContacts.EditValue);
                    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                    pairs.Add("sort", TESort.EditValue);

                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;


                    uInfo updateInfoimg = new uInfo();
                    updateInfoimg.MessageShow = 1;
                    Dictionary<string, object> pairsimg = new Dictionary<string, object>();
                    pairsimg.Add("clientNO", TENO.EditValue);
                    pairsimg.Add("filestring", FileConverHelpers.BitmapTostring(bitmaps));
                    pairsimg.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    pairsimg.Add("state", 1);
                    updateInfoimg.values = pairsimg;
                    updateInfoimg.TableName = "WorkComm.ClientImg";
                    updateInfoimg.wheres = $"clientNO='{TENO.EditValue}'";
                    int a = ApiHelpers.postInfo(updateInfo);
                    //a = ApiHelpers.postInfo(updateInfoimg);
                }
            }


            EditState = 0;
            CommonDataRefresh.GetClientInfo();
            Frminfo_Load(null, null);
            //groupControl1.Enabled = false;
            xtraTabControl1.Enabled = false;

        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {

                    if (SelectValueID != 0)
                    {
                        int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                        if (a > 0)
                        {
                            CommonDataRefresh.GetClientInfo();
                            GVClientInfo.DeleteSelectedRows();
                        }
                    }
                
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
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
                        CEwebstate.EditValue = Convert.ToBoolean(rows[0]["webstate"]);
                        CEState.EditValue = Convert.ToBoolean(rows[0]["state"]);
                        CEreportstate.EditValue = Convert.ToBoolean(rows[0]["reportstate"]);
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
                        if(dt!=null)
                        {
                            GCGroupInfo.DataSource = dt;
                        }
                        else
                        {
                            GCGroupInfo.DataSource = resetClientDT();
                        }


                        //if (dt != null && dt.Rows.Count > 0)
                        //{
                        //    if (!Convert.IsDBNull(dt.Rows[0][0]))
                        //    {
                        //        PEClientImg.Image = bitmaps = FileConverHelpers.StringToBitmap(dt.Rows[0][0].ToString());
                        //    }
                        //    else
                        //    {
                        //        PEClientImg.Image = bitmaps = null;
                        //    }
                        //}
                        //else
                        //{
                        //    PEClientImg.Image = bitmaps = null;
                        //}








                        //加载图片

                        //sInfo selectimg = new sInfo();
                        //selectimg.values = "filestring";
                        //selectimg.TableName = "WorkComm.ClientImg";
                        //selectimg.wheres = $"clientNO='{ rows[0]["no"]}' and state=1";
                        //DataTable dt = ApiHelpers.postInfo(selectimg);
                        //if (dt != null&&dt.Rows.Count>0)
                        //{
                        //    if (!Convert.IsDBNull(dt.Rows[0][0]))
                        //    {
                        //        PEClientImg.Image = bitmaps = FileConverHelpers.StringToBitmap(dt.Rows[0][0].ToString());
                        //    }
                        //    else
                        //    {
                        //        PEClientImg.Image = bitmaps = null;
                        //    }
                        //}
                        //else
                        //{
                        //    PEClientImg.Image = bitmaps = null;
                        //}

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
            if (TENames.EditValue != null)
            {
                TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
            }

        }

        private void BTUpFile_Click(object sender, EventArgs e)
        {
            //aaaa = "";
            ////string FilePath = OpenFileHelpers.GetFilePath(out string FileExtensionName);
            //string FilePath = OpenFileHelpers.GetFilePath(FileExtensionName.Other);
            //if(FilePath.Length!=0)
            //    aaaa = FileConverHelpers.FilePathToString(FilePath);
            //FrmShowPDF frmShowPDF = new FrmShowPDF(aaaa);
            //frmShowPDF.Show();
        }

        private void BTFileView_Click(object sender, EventArgs e)
        {
            //if(aaaa.Length!=0)
            //{
            //    //FileConverHelpers.StringToStream(aaaa);
            //    PdfViewer pdfViewer = new PdfViewer();
            //    Stream stream = FileConverHelpers.StringToStream(aaaa);
            //    pdfViewer.LoadDocument(stream);
            //    pdfViewer.Show();
            //}
        }
        Bitmap bitmaps;
        private void BTUpLoadFile_Click(object sender, EventArgs e)
        {
            string filepath = OpenFileHelpers.GetFilePath();
            if (filepath != "")
            {
                PEClientImg.Image = bitmaps = FileConverHelpers.FilePathToBitmap(filepath);
            }
        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            PEClientImg.Image = bitmaps = null;
        }

        private void TENO_Leave(object sender, EventArgs e)
        {
            string a = TENO.EditValue != null ? TENO.EditValue.ToString().ToUpper() : "";
            if (WorkCommData.DTClientInfo.Select($"no='{a}'").Count()>0)
            {
                MessageBox.Show("客户编号重复", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TENO.EditValue = "";
            }
            else
            {
                TENO.EditValue = a;
            }
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
        /// <summary>
        /// 验证专业组设置是否重复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RGEGroupNO_EditValueChanged(object sender, EventArgs e)
        {
            //DataTable dataTable = GCGroupInfo.DataSource as DataTable;
            //if(dataTable!=null&&dataTable.Rows.Count>0)
            //{
            //    foreach(DataRow dataRow in dataTable.Rows)
            //    {
            //        if(dataRow["groupNO"]== RGEGroupNO.)
            //    }
            //}

        }
    }
}
