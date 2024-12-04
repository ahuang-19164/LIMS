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

namespace WorkComm.Items
{
    public partial class FrmItemTest : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ItemTest";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        //DataTable FrmDT;
        DataTable RDT;//参考值表

        public FrmItemTest()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GEgroupNO);
            GridLookUpEdites.Formats(GEinstrumentNO);
            GridLookUpEdites.Formats(GEmethodNO.Properties);
            GridLookUpEdites.Formats(GEresultTypeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);
            //GridLookUpEdites.Formats(GEtestFlowNO);
            GridLookUpEdites.Formats(GEtestTypeNO);
            GridLookUpEdites.Formats(GEdelegeteCompanyNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEsampleTypeNO);
            TextEdits.TextFormat(TEprecision);
            TextEdits.TextFormat(TEsort);
            TextEdits.TextFormat(TEdelegeteTime);
            GridControls.formartGridView(GVTestInfo);

            GridControls.showEmbeddedNavigator(GCTestInfo);

            TextEdits.TextFormat(RTEageDayDown);
            TextEdits.TextFormat(RTEageDayUP);
            TextEdits.TextFormat(RTEageMothDown);
            TextEdits.TextFormat(RTEageMothUP);
            TextEdits.TextFormat(RTEageYearDown);
            TextEdits.TextFormat(RTEageYearUP);
            TextEdits.TextFormats(RTEvalueDown);
            TextEdits.TextFormats(RTEvalueUP);
            TextEdits.TextFormats(RTEcrisisDown);
            TextEdits.TextFormats(RTEcrisisUP);

            GridLookUpEdites.Formats(RGERsexNO);
            GridLookUpEdites.Formats(RGERsampeTypeNO);
            GridLookUpEdites.Formats(RGERinstrumentNO);
            GridLookUpEdites.Formats(RGERclientNO);


        }







        private void FrmCompanyinfo_Load(object sender, EventArgs e)
        {

            //EnabledColors.SetControlEnabled(GCReference, false);
            groupInfos.Enabled = false;
            RGERclientNO.DataSource = WorkCommData.DTClientInfo;
            RGERsexNO.DataSource = WorkCommData.DTTypeSex;
            RGERsampeTypeNO.DataSource = RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGERinstrumentNO.DataSource = RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;

            GEinstrumentNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTInstrumentInfo);
            GEmethodNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeMethod);
            GEresultTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeResult);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            //GEtestFlowNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeTestFlow);
            GEtestTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeTest);
            GEgroupNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);
            GEdelegeteCompanyNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);
            GCTestInfo.DataSource = DTHelper.DTVisible(WorkCommData.DTItemTest);

            RDT = WorkCommData.DTItemReference.Clone();
            GCReference.DataSource = RDT;
            //FrmDT= WorkCommData.DTItemTest;
            GVTestInfo.BestFitColumns();
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


        private void BTAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            groupInfos.Enabled = true;
            EditState = 1;
            if (WorkCommData.DTItemTest == null)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(WorkCommData.DTItemTest.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            CEcalculationState.Checked = false;
            CEdelegeteState.Checked = false;
            CEresultNullState.Checked = false;
            CEstate.Checked = true;
            CEvisibleState.Checked = true;
            CEqcState.Checked = true;



            TEsort.EditValue = 999;
            TEcalculationFormula.EditValue = "";
            TEchannel.EditValue = "";
            TEcustomCode.EditValue = "";
            TEdefaultValue.EditValue = "";
            GEdelegeteCompanyNO.EditValue = "";
            TEdelegeteTime.EditValue = "";
            TEdisNames.EditValue = "";
            GEgroupNO.EditValue = "";
            GEinstrumentNO.EditValue = "";
            GEmethodNO.EditValue = "";
            TEnames.EditValue = "";
            TEnamesEN.EditValue = "";
            TEprecision.EditValue = 2;
            TEremark.EditValue = "";
            //TEresultTable.EditValue = "";
            //TEresultImg.EditValue = "";
            GEresultTypeNO.EditValue = "";
            GEsampleTypeNO.EditValue = "";
            TEshortNames.EditValue = "";
            TEsimpleNames.EditValue = "";
            GEtestTypeNO.EditValue = "";
            TEunit.EditValue = "";






            //TEid.EditValue = "";
            TEclinicalDiagnosis.EditValue = "";
            TEotherInfo.EditValue = "";
            TEreferenceDocument.EditValue = "";
            TEsuggestedExplanation.EditValue = "";
            TEtakeSample.EditValue = "";
            //GEtestNO.EditValue = "";




        }
        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupInfos.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TEno.EditValue != null && TEnames.EditValue != null && GEgroupNO.EditValue != null)
            {


                if (TEno.EditValue.ToString() != "" && TEnames.EditValue.ToString() != "" && GEgroupNO.EditValue.ToString() != "")
                {
                    if (EditState == 1)
                    {
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("calculationState", CEcalculationState.EditValue);
                        pairs.Add("delegeteState", CEdelegeteState.EditValue);
                        pairs.Add("resultNullState", CEresultNullState.EditValue);
                        pairs.Add("state", CEstate.EditValue);
                        pairs.Add("qcState", CEqcState.EditValue);
                        pairs.Add("visibleState", CEvisibleState.EditValue);
                        pairs.Add("no", TEno.EditValue);
                        pairs.Add("sort", TEsort.EditValue);
                        pairs.Add("calculationFormula", TEcalculationFormula.EditValue);
                        pairs.Add("channel", TEchannel.EditValue);
                        pairs.Add("customCode", TEcustomCode.EditValue);
                        pairs.Add("defaultValue", TEdefaultValue.EditValue);
                        pairs.Add("delegeteCompanyNO", GEdelegeteCompanyNO.EditValue);
                        pairs.Add("delegeteTime", TEdelegeteTime.EditValue);
                        pairs.Add("disNames", TEdisNames.EditValue);
                        pairs.Add("groupNO", GEgroupNO.EditValue);
                        pairs.Add("instrumentNO", GEinstrumentNO.EditValue);
                        pairs.Add("methodNO", GEmethodNO.EditValue);
                        pairs.Add("methodName", GEmethodNO.Text);
                        pairs.Add("names", TEnames.EditValue);
                        pairs.Add("namesEN", TEnamesEN.EditValue);
                        pairs.Add("precision", TEprecision.EditValue);
                        pairs.Add("remark", TEremark.EditValue);
                        //pairs.Add("resultTable", TEresultTable.EditValue);
                        //pairs.Add("resultImg", TEresultImg.EditValue);
                        pairs.Add("resultTypeNO", GEresultTypeNO.EditValue);
                        pairs.Add("sampleTypeNO", GEsampleTypeNO.EditValue);
                        pairs.Add("shortNames", TEshortNames.EditValue);
                        pairs.Add("simpleNames", TEsimpleNames.EditValue);
                        pairs.Add("testTypeNO", GEtestTypeNO.EditValue);
                        pairs.Add("unit", TEunit.EditValue);
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
                            otherpairs.Add("takeSample", TEtakeSample.EditValue);
                            otherpairs.Add("testNO", TEno.EditValue);
                            iInfo insertInfor = new iInfo();
                            insertInfor.TableName = "WorkComm.ItemTestOtherInfo";
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
                            pairs.Add("calculationState", CEcalculationState.EditValue);
                            pairs.Add("delegeteState", CEdelegeteState.EditValue);
                            pairs.Add("resultNullState", CEresultNullState.EditValue);
                            pairs.Add("state", CEstate.EditValue);
                            pairs.Add("qcState", CEqcState.EditValue);
                            pairs.Add("visibleState", CEvisibleState.EditValue);
                            //pairs.Add("no", TEno.EditValue);
                            pairs.Add("sort", TEsort.EditValue);
                            pairs.Add("calculationFormula", TEcalculationFormula.EditValue);
                            pairs.Add("channel", TEchannel.EditValue);
                            pairs.Add("customCode", TEcustomCode.EditValue);
                            pairs.Add("defaultValue", TEdefaultValue.EditValue);
                            pairs.Add("delegeteCompanyNO", GEdelegeteCompanyNO.EditValue);
                            pairs.Add("delegeteTime", TEdelegeteTime.EditValue);
                            pairs.Add("disNames", TEdisNames.EditValue);
                            pairs.Add("groupNO", GEgroupNO.EditValue);
                            pairs.Add("instrumentNO", GEinstrumentNO.EditValue);
                            pairs.Add("methodNO", GEmethodNO.EditValue);
                            pairs.Add("methodName", GEmethodNO.Text);
                            pairs.Add("names", TEnames.EditValue);
                            pairs.Add("namesEN", TEnamesEN.EditValue);
                            pairs.Add("precision", TEprecision.EditValue);
                            pairs.Add("remark", TEremark.EditValue);
                            //pairs.Add("resultTable", TEresultTable.EditValue);
                            //pairs.Add("resultImg", TEresultImg.EditValue);
                            pairs.Add("resultTypeNO", GEresultTypeNO.EditValue);
                            pairs.Add("sampleTypeNO", GEsampleTypeNO.EditValue);
                            pairs.Add("shortNames", TEshortNames.EditValue);
                            pairs.Add("simpleNames", TEsimpleNames.EditValue);
                            pairs.Add("testTypeNO", GEtestTypeNO.EditValue);
                            pairs.Add("unit", TEunit.EditValue);
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
                                otherpairs.Add("takeSample", TEtakeSample.EditValue);
                                //otherpairs.Add("testNO", TEno.EditValue);
                                uInfo updateInfor = new uInfo();
                                updateInfor.TableName = "WorkComm.ItemTestOtherInfo";
                                updateInfor.MessageShow = 1;
                                updateInfor.values = otherpairs;
                                updateInfor.wheres = $"testNO='{TEno.EditValue}'";
                                a = ApiHelpers.postInfo(updateInfor);
                            }

                        }
                    }


                    EditState = 0;
                    CommonDataRefresh.GetItemTest();
                    CommonDataRefresh.GetItemOtherInfo();
                    GCTestInfo.DataSource = WorkCommData.DTItemTest;
                    groupInfos.Enabled = false;
                }
                else
                {
                    MessageBox.Show("必填项信息不能为空", "系统提示");
                }
            }

        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否确定删除该信息！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int id = Convert.ToInt32(GVTestInfo.GetFocusedRowCellValue("id"));

                if (id != 0)
                {
                    int a = DeleteHelper.hideinfo(id, tableName);
                    if (a > 0)
                    {
                        CommonDataRefresh.GetItemTest();
                        GVTestInfo.DeleteSelectedRows();
                    }
                }

            
        }

        private void BTTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            //GVReference.AddNewRow();



            //SelectInfo selectInfo = new SelectInfo();
            //selectInfo.TableName = "WorkComm.WorkTypeInfo";
            //DataTable dt = ApiHelpers.postInfo(selectInfo);
            //string aaa = dt.GVSampleInfo.GetFocusedRowCellValue("TypeNames"].ToString();
            //byte[] array = Encoding.ASCII.GetBytes(aaa);
            //MemoryStream stream = new MemoryStream(array);
            //layoutControl1.SaveLayoutToStream(stream);
        }
        #endregion




        #region gridcontrol 方法
        private void gridView1_Click(object sender, EventArgs e)
        {
            GCReference.DataSource = null;
            if (EditState != 1)
            {
                if (WorkCommData.DTItemTest != null)
                {
                    SelectValueID = Convert.ToInt32(GVTestInfo.GetFocusedRowCellValue("id"));
                    DataRow[] rows = WorkCommData.DTItemTest.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        CEcalculationState.Checked = rows[0]["calculationState"] != DBNull.Value ? Convert.ToBoolean(rows[0]["calculationState"]) : false;
                        CEdelegeteState.Checked = rows[0]["delegeteState"] != DBNull.Value ? Convert.ToBoolean(rows[0]["delegeteState"]) : false;
                        CEresultNullState.Checked = rows[0]["resultNullState"] != DBNull.Value ? Convert.ToBoolean(rows[0]["resultNullState"]) : false;
                        CEstate.Checked = rows[0]["state"] != DBNull.Value ? Convert.ToBoolean(rows[0]["state"]) : false;
                        CEvisibleState.Checked = rows[0]["visibleState"] != DBNull.Value ? Convert.ToBoolean(rows[0]["visibleState"]) : false;
                        CEqcState.Checked = rows[0]["qcState"] != DBNull.Value ? Convert.ToBoolean(rows[0]["qcState"]) : false;
                        TEno.EditValue = rows[0]["no"];
                        TEsort.EditValue = rows[0]["sort"];
                        TEcalculationFormula.EditValue = rows[0]["calculationFormula"];
                        TEchannel.EditValue = rows[0]["channel"];
                        TEcustomCode.EditValue = rows[0]["customCode"];
                        TEdefaultValue.EditValue = rows[0]["defaultValue"];
                        GEdelegeteCompanyNO.EditValue = rows[0]["delegeteCompanyNO"];
                        TEdelegeteTime.EditValue = rows[0]["delegeteTime"];
                        TEdisNames.EditValue = rows[0]["disNames"];
                        GEgroupNO.EditValue = rows[0]["groupNO"];
                        GEinstrumentNO.EditValue = rows[0]["instrumentNO"];
                        GEmethodNO.EditValue = rows[0]["methodNO"];
                        TEnames.EditValue = rows[0]["names"];
                        TEnamesEN.EditValue = rows[0]["namesEN"];
                        TEprecision.EditValue = rows[0]["precision"];
                        TEremark.EditValue = rows[0]["remark"];
                        //TEresultTable.EditValue = rows[0]["resultTable"];
                        //TEresultImg.EditValue = rows[0]["resultImg"];
                        GEresultTypeNO.EditValue = rows[0]["resultTypeNO"];
                        GEsampleTypeNO.EditValue = rows[0]["sampleTypeNO"];
                        TEshortNames.EditValue = rows[0]["shortNames"];
                        TEsimpleNames.EditValue = rows[0]["simpleNames"];

                        GEtestTypeNO.EditValue = rows[0]["testTypeNO"];
                        TEunit.EditValue = rows[0]["unit"];

                        TEclinicalDiagnosis.EditValue = "";
                        TEotherInfo.EditValue = "";
                        TEreferenceDocument.EditValue = "";
                        TEsuggestedExplanation.EditValue = "";
                        TEtakeSample.EditValue = "";

                        if (WorkCommData.DTItemTestOtherInfo != null)
                        {
                            if (WorkCommData.DTItemTestOtherInfo.Select($"testNO='{TEno.EditValue}'").Count() > 0)
                            {
                                DataRow[] dataRow = WorkCommData.DTItemTestOtherInfo.Select($"testNO='{TEno.EditValue}'");
                                TEclinicalDiagnosis.EditValue = dataRow[0]["clinicalDiagnosis"];
                                TEotherInfo.EditValue = dataRow[0]["otherInfo"];
                                TEreferenceDocument.EditValue = dataRow[0]["referenceDocument"];
                                TEsuggestedExplanation.EditValue = dataRow[0]["suggestedExplanation"];
                                TEtakeSample.EditValue = dataRow[0]["takeSample"];
                                //GEtestNO.EditValue = rows[0]["testNO"];
                            }
                        }

                        sInfo sInfo = new sInfo();
                        sInfo.TableName = "WorkComm.ItemReference";
                        sInfo.wheres = $"testNO='{TEno.EditValue.ToString()}' and dstate=0";
                        DataTable DTItemReference = ApiHelpers.postInfo(sInfo);
                        GCReference.DataSource = DTItemReference;
                        //if (WorkCommData.DTItemReference != null)
                        //{
                        //    if (WorkCommData.DTItemReference.Select($"testNO='{TEno.EditValue.ToString()}' and dstate='0'").Count() > 0)
                        //    {

                        //        sInfo sInfo = new sInfo();
                        //        sInfo.TableName = "WorkComm.ItemReference";
                        //        sInfo.wheres = $"testNO='{TEno.EditValue.ToString()}' and dstate=0";
                        //        DataTable dt= ApiHelpers.postInfo(sInfo);
                        //        GCReference.DataSource = dt;
                        //    }
                        //    else
                        //    {
                        //        RDT.Rows.Clear();
                        //        GCReference.DataSource = RDT;
                        //    }
                        //}
                    }
                }
            }
        }




        #endregion

        private void TEnames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
                TEshortNames.EditValue = Common.ConvertShort.ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
        }

        private void splitContainerControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BTRAdd_Click(object sender, EventArgs e)
        {
            if (TEno.EditValue != null)
            {
                //EnabledColors.SetControlEnabled(GCReference, true);
                BGVReference.AddNewRow();
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示");
            }

        }

        private void BTREdit_Click(object sender, EventArgs e)
        {
            if (TEno.EditValue != null)
            {
                //EnabledColors.SetControlEnabled(GCReference, true);
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示");
            }


        }

        private void BTRSave_Click(object sender, EventArgs e)
        {
            if (TEno.EditValue != null)
            {
                BGVReference.FocusedRowHandle = -1;
                DataTable dataTable = GCReference.DataSource as DataTable;
                //ApiHelpers.postInfo(dataTable, "WorkComm.ItemReference");
                ApiHelpers.postInfo(dataTable, "WorkComm.ItemReference");
                //EnabledColors.SetControlEnabled(GCReference, false);
                CommonDataRefresh.GetItemReference();
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTRDelete_Click(object sender, EventArgs e)
        {
            if (BGVReference.GetFocusedDataRow() != null)
            {
                int id = Convert.ToInt32(BGVReference.GetFocusedRowCellValue("id"));
                DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = "WorkComm.ItemReference";
                    hideInfo.DataValueID = id;
                    ApiHelpers.postInfo(hideInfo);
                    BGVReference.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示");
            }
        }

        private void BGVReference_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["testNO"], TEno.EditValue);
            view.SetRowCellValue(e.RowHandle, view.Columns["state"], true);
            view.SetRowCellValue(e.RowHandle, view.Columns["dstate"], false);
            //view.SetRowCellValue(e.RowHandle, view.Columns["controlNO"], "1000000");
        }
    }
}
