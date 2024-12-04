using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Items
{
    public partial class FrmItemGroup : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ItemGroup";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmItemGroup()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GEcontainerTypeNO);
            GridLookUpEdites.Formats(GEdelegeteCompanyNO);
            GridLookUpEdites.Formats(GEitemTypeNO);
            GridLookUpEdites.Formats(GEreportTypeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);
            GridLookUpEdites.Formats(GEworkNO);
            GridLookUpEdites.Formats(GEclientNO);
            GridLookUpEdites.Formats(GEgroupNO);

            GridLookUpEdites.Formats(RGEGsampleTypeNO);
            GridLookUpEdites.Formats(RGEIsampleTypeNO);
            GridLookUpEdites.Formats(RGEImethodNO);
            GridLookUpEdites.Formats(RGEworkNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEgroupNOs);
            GridLookUpEdites.Formats(RGEgroupFlowNO);
            GridLookUpEdites.Formats(GEgroupFlowNO);


            TextEdits.TextFormat(TEsort);
            TextEdits.TextFormat(TEtimeUse);

            GridControls.formartGridView(GVGroupInfo);

            GridControls.showEmbeddedNavigator(GCGroupInfo);
            GridControls.formartGridView(GVItemInfo);

            GridControls.showEmbeddedNavigator(GCItemInfo);
        }

        private void FrmCompanyinfo_Load(object sender, EventArgs e)
        {

            //EnabledColors.SetControlEnabled(GroupInfo, false);
            GroupInfo.Enabled = false;
            RGEGsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEIsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEImethodNO.DataSource = WorkCommData.DTTypeMethod;
            RGEworkNO.DataSource = WorkCommData.DTGroupWork;
            RGEgroupNOs.DataSource = RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEgroupFlowNO.DataSource = WorkCommData.DTItemFlow;





            GEgroupFlowNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTItemFlow);
            GEcontainerTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeContainer);
            GEdelegeteCompanyNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);
            GEitemTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeItem);
            GEreportTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeReport);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            GEworkNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupWork);
            GEclientNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GEgroupNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);
            GCGroupInfo.DataSource = DTHelper.DTVisible(WorkCommData.DTItemGroup);




            FrmDT = WorkCommData.DTItemTest.Clone();
            GCItemInfo.DataSource = FrmDT;

            //gridControl1.DataSource = CommonData.DTCommonyInfoAll;
            GVGroupInfo.ExpandAllGroups();
            GVGroupInfo.BestFitColumns();

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
        private void BTAddCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GroupInfo.Enabled = true;
            EditState = 1;
            if (WorkCommData.DTItemGroup == null)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(WorkCommData.DTItemGroup.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            CEdelegeteState.Checked = false;
            CEreportState.Checked = false;
            CEstate.Checked = true;
            TEsort.EditValue = 999;
            TEbloodVolume.EditValue = "";
            GEworkNO.EditValue = "";
            GEcontainerTypeNO.EditValue = "";
            TEcustomCode.EditValue = "";
            GEdelegeteCompanyNO.EditValue = "";
            TEdisNames.EditValue = "";
            GEitemTypeNO.EditValue = "";
            TEnames.EditValue = "";
            TEremark.EditValue = "";
            GEreportTypeNO.EditValue = "";
            GEsampleTypeNO.EditValue = "";
            TEshortNames.EditValue = "";
            TEtakeSample.EditValue = "";
            TEtimeUse.EditValue = "";
            GEgroupFlowNO.EditValue = "";
            GEgroupNO.EditValue = "";
            itemList = "";
            CEihcState.Checked = false;


            TEclinicalDiagnosis.EditValue = "";
            TEotherInfo.EditValue = "";
            TEreferenceDocument.EditValue = "";
            TEsuggestedExplanation.EditValue = "";
            TEtakeSamples.EditValue = "";






            FrmDT.Rows.Clear();
        }

        private void BTEditCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //EnabledColors.SetControlEnabled(GroupInfo, true);
            GroupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TEno.EditValue != null && TEnames.EditValue != null && GEgroupNO.EditValue != null)
            {
                if (TEno.EditValue.ToString() != "" && TEnames.EditValue.ToString() != "" && GEgroupNO.EditValue.ToString() != "")
                {
                    if (EditState == 1)
                    {
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("delegeteState", CEdelegeteState.EditValue);
                        pairs.Add("ihcState", CEihcState.EditValue);
                        pairs.Add("dstate", 0);
                        pairs.Add("reportState", CEreportState.EditValue);
                        pairs.Add("state", CEstate.EditValue);
                        pairs.Add("no", TEno.EditValue);
                        pairs.Add("sort", TEsort.EditValue);
                        pairs.Add("bloodVolume", TEbloodVolume.EditValue);
                        //pairs.Add("companyNO", GEcompanyNO.EditValue);
                        pairs.Add("containerTypeNO", GEcontainerTypeNO.EditValue);
                        pairs.Add("customCode", TEcustomCode.EditValue);
                        pairs.Add("delegeteCompanyNO", GEdelegeteCompanyNO.EditValue);
                        pairs.Add("disNames", TEdisNames.EditValue);
                        pairs.Add("itemTypeNO", GEitemTypeNO.EditValue);
                        pairs.Add("names", TEnames.EditValue);
                        pairs.Add("remark", TEremark.EditValue);
                        pairs.Add("reportTypeNO", GEreportTypeNO.EditValue);
                        pairs.Add("sampleTypeNO", GEsampleTypeNO.EditValue);
                        pairs.Add("shortNames", TEshortNames.EditValue);
                        pairs.Add("takeSample", TEtakeSample.EditValue);
                        pairs.Add("testItemList", GetitemList());
                        pairs.Add("timeUse", TEtimeUse.EditValue);
                        pairs.Add("workNO", GEworkNO.EditValue);
                        pairs.Add("groupNO", GEgroupNO.EditValue);
                        pairs.Add("groupFlowNO", GEgroupFlowNO.EditValue);

                        iInfo insertInfo = new iInfo();
                        insertInfo.TableName = tableName;
                        insertInfo.values = pairs;
                        int a = ApiHelpers.postInfo(insertInfo);

                        if (a == 1)
                        {
                            Dictionary<string, object> otherpairs = new Dictionary<string, object>();
                            otherpairs.Add("clinicalDiagnosis", TEclinicalDiagnosis.EditValue);
                            otherpairs.Add("otherInfo", TEotherInfo.EditValue);
                            otherpairs.Add("referenceDocument", TEreferenceDocument.EditValue);
                            otherpairs.Add("suggestedExplanation", TEsuggestedExplanation.EditValue);
                            otherpairs.Add("takeSample", TEtakeSamples.EditValue);
                            otherpairs.Add("testNO", TEno.EditValue);
                            iInfo insertInfor = new iInfo();
                            insertInfor.TableName = "WorkComm.ItemGroupOtherInfo";
                            insertInfor.values = otherpairs;
                            insertInfor.MessageShow = 1;
                            a = ApiHelpers.postInfo(insertInfor);
                        }


                    }
                    if (SelectValueID != 0)
                    {
                        if (EditState == 2)
                        {
                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                            pairs.Add("delegeteState", CEdelegeteState.EditValue);
                            pairs.Add("ihcState", CEihcState.EditValue);
                            pairs.Add("dstate", 0);
                            pairs.Add("reportState", CEreportState.EditValue);
                            pairs.Add("state", CEstate.EditValue);
                            pairs.Add("no", TEno.EditValue);
                            pairs.Add("sort", TEsort.EditValue);
                            pairs.Add("bloodVolume", TEbloodVolume.EditValue);
                            //pairs.Add("companyNO", GEcompanyNO.EditValue);
                            pairs.Add("containerTypeNO", GEcontainerTypeNO.EditValue);
                            pairs.Add("customCode", TEcustomCode.EditValue);
                            pairs.Add("delegeteCompanyNO", GEdelegeteCompanyNO.EditValue);
                            pairs.Add("disNames", TEdisNames.EditValue);
                            pairs.Add("itemTypeNO", GEitemTypeNO.EditValue);
                            pairs.Add("names", TEnames.EditValue);
                            pairs.Add("remark", TEremark.EditValue);
                            pairs.Add("reportTypeNO", GEreportTypeNO.EditValue);
                            pairs.Add("sampleTypeNO", GEsampleTypeNO.EditValue);
                            pairs.Add("shortNames", TEshortNames.EditValue);
                            pairs.Add("takeSample", TEtakeSample.EditValue);
                            pairs.Add("testItemList", GetitemList());
                            pairs.Add("timeUse", TEtimeUse.EditValue);
                            pairs.Add("workNO", GEworkNO.EditValue);
                            pairs.Add("groupNO", GEgroupNO.EditValue);

                            pairs.Add("groupFlowNO", GEgroupFlowNO.EditValue);
                            uInfo updateInfo = new uInfo();
                            updateInfo.TableName = tableName;
                            updateInfo.values = pairs;
                            updateInfo.DataValueID = SelectValueID;
                            int a = ApiHelpers.postInfo(updateInfo);
                            if (a == 1)
                            {
                                Dictionary<string, object> otherpairs = new Dictionary<string, object>();
                                otherpairs.Add("clinicalDiagnosis", TEclinicalDiagnosis.EditValue);
                                otherpairs.Add("otherInfo", TEotherInfo.EditValue);
                                otherpairs.Add("referenceDocument", TEreferenceDocument.EditValue);
                                otherpairs.Add("suggestedExplanation", TEsuggestedExplanation.EditValue);
                                otherpairs.Add("takeSample", TEtakeSamples.EditValue);
                                //otherpairs.Add("testNO", TEno.EditValue);
                                uInfo updateInfor = new uInfo();
                                updateInfor.TableName = "WorkComm.ItemGroupOtherInfo";
                                updateInfor.MessageShow = 1;
                                updateInfor.values = otherpairs;
                                updateInfor.wheres = $"testNO='{TEno.EditValue}'";
                                a = ApiHelpers.postInfo(updateInfor);
                            }
                        }
                    }


                    EditState = 0;
                    CommonDataRefresh.GetItemGroup();
                    GCGroupInfo.DataSource = WorkCommData.DTItemGroup;
                    GroupInfo.Enabled = false;
                }
                else
                {
                    MessageBox.Show("必填项信息不能为空", "系统提示");
                }
            }
        }
        #endregion

        private void GVGroupInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (WorkCommData.DTItemGroup != null)
                {

                    SelectValueID = Convert.ToInt32(GVGroupInfo.GetFocusedRowCellValue("id"));
                    DataRow[] rows = WorkCommData.DTItemGroup.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        CEdelegeteState.Checked = Convert.ToBoolean(rows[0]["delegeteState"]);
                        //CEdstate.Checked = Convert.ToBoolean(rows[0]["dstate"]);
                        CEreportState.Checked = Convert.ToBoolean(rows[0]["reportState"]);
                        CEstate.Checked = Convert.ToBoolean(rows[0]["state"]);
                        //TEid.EditValue = rows[0]["id"];
                        TEno.EditValue = rows[0]["no"];
                        TEsort.EditValue = rows[0]["sort"];
                        TEbloodVolume.EditValue = rows[0]["bloodVolume"];
                        //GEcompanyNO.EditValue = rows[0]["companyNO"];
                        GEcontainerTypeNO.EditValue = rows[0]["containerTypeNO"];
                        TEcustomCode.EditValue = rows[0]["customCode"];
                        //TEcustomNames.EditValue = rows[0]["customNames"];
                        GEdelegeteCompanyNO.EditValue = rows[0]["delegeteCompanyNO"];
                        TEdisNames.EditValue = rows[0]["disNames"];
                        GEitemTypeNO.EditValue = rows[0]["itemTypeNO"];
                        TEnames.EditValue = rows[0]["names"];
                        TEremark.EditValue = rows[0]["remark"];
                        GEreportTypeNO.EditValue = rows[0]["reportTypeNO"];
                        GEsampleTypeNO.EditValue = rows[0]["sampleTypeNO"];
                        TEshortNames.EditValue = rows[0]["shortNames"];
                        TEtakeSample.EditValue = rows[0]["takeSample"];
                        GEgroupFlowNO.EditValue = rows[0]["groupFlowNO"];
                        GEgroupNO.EditValue = rows[0]["groupNO"];
                        CEihcState.Checked = Convert.ToBoolean(rows[0]["ihcState"]);

                        if (WorkCommData.DTItemGroupOtherInfo != null)
                        {
                            if (WorkCommData.DTItemGroupOtherInfo.Select($"testNO='{TEno.EditValue}'").Count() > 0)
                            {
                                DataRow[] dataRow = WorkCommData.DTItemGroupOtherInfo.Select($"testNO='{TEno.EditValue}'");
                                TEclinicalDiagnosis.EditValue = dataRow[0]["clinicalDiagnosis"];
                                TEotherInfo.EditValue = dataRow[0]["otherInfo"];
                                TEreferenceDocument.EditValue = dataRow[0]["referenceDocument"];
                                TEsuggestedExplanation.EditValue = dataRow[0]["suggestedExplanation"];
                                TEtakeSamples.EditValue = dataRow[0]["takeSample"];
                                //GEtestNO.EditValue = rows[0]["testNO"];
                            }
                        }


                        if (!Convert.IsDBNull(rows[0]["testItemList"]))
                        {
                            itemList = rows[0]["testItemList"].ToString();
                        }
                        TEtimeUse.EditValue = rows[0]["timeUse"];
                        GEworkNO.EditValue = rows[0]["workNO"];





                    }
                }

            }
            GetitemInfo(itemList);
        }


        private void splitContainerControl2_Paint(object sender, PaintEventArgs e)
        {

        }



        Func<DataRow> Func;
        private void BTShowItem_Click(object sender, EventArgs e)
        {
            FrmShowItem frmShowItem = new FrmShowItem(GetitemList());
            Func = frmShowItem.ReturnResult;
            frmShowItem.ShowDialog();
            if (Func() != null)
            {
                DataRow dataRow = FrmDT.NewRow();
                dataRow.ItemArray = Func().ItemArray;
                FrmDT.Rows.Add(dataRow);
                GVItemInfo.BestFitColumns();
            }

        }

        private void BTUp_Click(object sender, EventArgs e)
        {
            int ii = GVItemInfo.FocusedRowHandle;
            if (ii != 0)
            {
                DataRow newdata = FrmDT.NewRow();
                newdata.ItemArray = FrmDT.Rows[ii].ItemArray;
                FrmDT.Rows.RemoveAt(ii);
                FrmDT.Rows.InsertAt(newdata, ii - 1);
                FrmDT.AcceptChanges();
                GVItemInfo.FocusedRowHandle = ii - 1;
                //GVItemInfo.FocusedRowHandle = GVItemInfo.FocusedRowHandle - 2;
            }

        }

        private void BTDown_Click(object sender, EventArgs e)
        {
            int ii = GVItemInfo.FocusedRowHandle;
            if (ii < GVItemInfo.RowCount - 1)
            {
                DataRow newdata = FrmDT.NewRow();
                newdata.ItemArray = FrmDT.Rows[ii].ItemArray;
                FrmDT.Rows.RemoveAt(ii);
                FrmDT.Rows.InsertAt(newdata, ii + 1);
                FrmDT.AcceptChanges();
                GVItemInfo.FocusedRowHandle = ii + 1;
            }
        }
        string itemList = "";
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            itemList = "";
            for (int i = 0; i < GVItemInfo.RowCount; i++)
            {
                itemList += GVItemInfo.GetRowCellValue(i, "no") + ",";
            }
            TEremark.EditValue = itemList;
        }

        /// <summary>
        /// 获取子项集合信息。（包含优先级）
        /// </summary>
        /// <returns></returns>
        public string GetitemList()
        {
            itemList = "";
            for (int i = 0; i < GVItemInfo.RowCount; i++)
            {
                itemList += GVItemInfo.GetRowCellValue(i, "no") + ",";
            }
            return itemList;
        }
        /// <summary>
        /// 读取项目子项信息
        /// </summary>
        /// <param name="itemlists"></param>
        public void GetitemInfo(string itemlists)
        {
            FrmDT.Rows.Clear();
            if (itemlists != "")
            {
                string[] itemNOs = itemlists.Split(',');
                for (int i = 0; i < itemNOs.Count(); i++)
                {
                    if (!Convert.IsDBNull(itemNOs[i]))
                    {
                        if (itemNOs[i] != "")
                        {
                            DataRow dataRow = FrmDT.NewRow();
                            dataRow.ItemArray = WorkCommData.DTItemTest.Select($"no='{itemNOs[i]}'")[0].ItemArray;
                            FrmDT.Rows.InsertAt(dataRow, i);
                            GVItemInfo.BestFitColumns();
                        }
                    }
                }
            }
        }

        private void TEnames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
                TEshortNames.EditValue = Common.ConvertShort.ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GVItemInfo.DeleteSelectedRows();
        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GVGroupInfo.GetFocusedDataRow() != null)
            {
                int id = Convert.ToInt32(GVGroupInfo.GetFocusedRowCellValue("id"));


                        if (id != 0)
                        {
                            int a = DeleteHelper.hideinfo(id, tableName);
                            if (a > 0)
                            {
                                CommonDataRefresh.GetItemGroup();
                                GVGroupInfo.DeleteSelectedRows();
                            }
                        }
                    
                
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示");
            }
        }
    }
}
