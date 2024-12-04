using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTest.Test
{
    public partial class FrmTest : DevExpress.XtraEditors.XtraForm
    {
        RepositoryItemComboBox comboBox;
        RepositoryItemTextEdit itemTextEdit;
        string SetResultTest = "";
        string TestSampleResultSelect = "";
        public FrmTest()
        {
            InitializeComponent();


            SetResultTest = ConfigInfos.ReadConfigInfo("SetResultTest");
            TestSampleResultSelect = ConfigInfos.ReadConfigInfo("TestSampleResultSelect");
            comboBox = new RepositoryItemComboBox();
            itemTextEdit = new RepositoryItemTextEdit();

            comboBox.Items.Add("阴性(-)");
            comboBox.Items.Add("阳性(+)");
            comboBox.Items.Add("未检出");
            comboBox.Items.Add("待定");
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            TextEdits.TextFormatDecimal(itemTextEdit);
            GridControls.formartGridView(GVTestInfo);
            GridControls.showEmbeddedNavigator(GCTestInfo);
            GVTestInfo.CustomRowCellEdit += GVTestInfo_CustomRowCellEdit;
            GVTestInfo.CustomDrawCell += GVTestInfo_CustomDrawCell; ;
        }
        private void GVTestInfo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column.Name == "itemResult")
            {
                DataRow itemDR = GVTestInfo.GetDataRow(e.RowHandle);

                #region
                double ReferenceDown = -9999;
                double ReferenceUp = -9999;
                double crisisDown = -9999;
                double crisisUp = -9999;
                try
                {
                    ReferenceDown = itemDR["ReferenceDown"] != DBNull.Value ? Convert.ToDouble(itemDR["ReferenceDown"]) : -9999;
                    //ReferenceUp = itemDR["ReferenceUp"] != DBNull.Value ? Convert.ToDouble(itemDR["ReferenceUp"]) : -9999;
                }
                catch
                {
                    ReferenceDown = -9999;
                    //ReferenceUp = -9999;
                }
                try
                {
                    //ReferenceDown = itemDR["ReferenceDown"] != DBNull.Value ? Convert.ToDouble(itemDR["ReferenceDown"]) : -9999;
                    ReferenceUp = itemDR["ReferenceUp"] != DBNull.Value ? Convert.ToDouble(itemDR["ReferenceUp"]) : -9999;
                }
                catch
                {
                    //ReferenceDown = -9999;
                    ReferenceUp = -9999;
                }

                try
                {
                    crisisDown = itemDR["crisisDown"] != DBNull.Value ? Convert.ToDouble(itemDR["crisisDown"]) : -9999;
                    //crisisUp = itemDR["crisisUp"] != DBNull.Value ? Convert.ToDouble(itemDR["crisisUp"]) : -9999;
                }
                catch
                {
                    crisisDown = -9999;
                    //crisisUp = -9999;
                }
                try
                {
                    //crisisDown = itemDR["crisisDown"] != DBNull.Value ? Convert.ToDouble(itemDR["crisisDown"]) : -9999;
                    crisisUp = itemDR["crisisUp"] != DBNull.Value ? Convert.ToDouble(itemDR["crisisUp"]) : -9999;
                }
                catch
                {
                    //crisisDown = -9999;
                    crisisUp = -9999;
                }
                try
                {
                    double itemResulta = Convert.ToDouble(e.Value);
                    if (ReferenceDown != -9999 && ReferenceUp != -9999)
                    {
                        if (ReferenceDown > itemResulta)
                        {
                            GVTestInfo.SetRowCellValue(e.RowHandle, "flag", "↓");
                        }
                        if (ReferenceUp < itemResulta)
                        {
                            GVTestInfo.SetRowCellValue(e.RowHandle, "flag", "↑");
                        }
                    }
                    if (crisisDown != -9999 && crisisUp != -9999)
                    {
                        if (crisisDown > itemResulta)
                        {
                            DialogResult dialogResult = MessageBox.Show("结果值超过危急值范围，是否继续？", "危急值提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GVTestInfo.SetRowCellValue(e.RowHandle, "flag", "↓↓");
                                //可加危急值方法记录
                            }
                            else
                            {
                                GVTestInfo.SetRowCellValue(e.RowHandle, "itemResult", null);
                            }
                        }
                        if (crisisUp < itemResulta)
                        {
                            DialogResult dialogResult = MessageBox.Show("结果值超过危急值范围，是否继续？", "危急值提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GVTestInfo.SetRowCellValue(e.RowHandle, "flag", "↑↑");
                                //可加危急值方法记录
                            }
                            else
                            {
                                GVTestInfo.SetRowCellValue(e.RowHandle, "itemResult", null);
                            }
                        }
                    }
                }
                catch
                {
                    //result = e.Value != null && e.Value.ToString().Trim().Length > 0 ? e.Value.ToString() : "";
                }





                #endregion

            }
        }

        private void GVTestInfo_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "flag")
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "↑↑")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                        if (e.CellValue.ToString() == "↓↓")
                        {
                            e.Appearance.BackColor = Color.BlueViolet;
                        }
                        if (e.CellValue.ToString() == "↑")
                        {
                            e.Appearance.BackColor = Color.IndianRed;
                        }
                        if (e.CellValue.ToString() == "↓")
                        {
                            e.Appearance.BackColor = Color.CadetBlue;
                        }
                    }
                }
                if (e.CellValue.ToString().Contains("阳性"))
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    if (e.CellValue.ToString().Contains("阴性"))
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                    else
                    {
                        //e.Appearance.BackColor = Color.YellowGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GVTestInfo_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //try
            //{
            if (e.Column.FieldName == "itemResult")
            {
                DataRow dataRow = GVTestInfo.GetDataRow(e.RowHandle);
                if (dataRow != null)
                {
                    if (dataRow["resultTypeNO"] != DBNull.Value)
                    {
                        if (dataRow["resultTypeNO"].ToString() == "4")
                        {
                            e.RepositoryItem = comboBox;
                        }
                        if (dataRow["resultTypeNO"].ToString() == "3")
                        {
                            e.RepositoryItem = itemTextEdit;
                        }
                    }
                }
            }
            //}
            //catch(Exception ex)
            //{

            //}
        }

        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        /// <param name="TestStateNO">0为正常检测，1为委托检验</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {

            if (SampleInfo != null)
            {
                string groupNO = SampleInfo["groupNO"] != DBNull.Value ? SampleInfo["groupNO"].ToString() : "";

                Task<DataTable> ResultTask = new Task<DataTable>(() =>
                {
                    sInfo selectInfo = new sInfo();
                    selectInfo.TableName = "WorkTest.SampleResult";
                    if (TestStateNO == 1)
                    {
                        selectInfo.wheres = $"testid='{testid}' and delegateState=1 and state=1 and dstate=0";
                    }
                    else
                    {
                        selectInfo.wheres = $"testid='{testid}' and groupNO='{groupNO}' and state=1 and dstate=0";
                    }
                    selectInfo.OrderColumns = "itemSort";
                    //DataTable DTResult = ApiHelpers.postInfo(selectInfo);
                    return ApiHelpers.postInfo(selectInfo);
                });
                ResultTask.Start();
                GCTestInfo.DataSource = ResultTask.Result;
                GVTestInfo.BestFitColumns();
            }
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者.4.反审核</param>
        /// <returns>0,保存失败，1，结果为空值，2，保存成功</returns>
        //public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {
            GVTestInfo.FocusedRowHandle = -1;


            if (ResultState == 4)
            {
                //CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
                CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
                testInfo.UserName = CommonData.UserInfo.names;
                
                testInfo.ResultState = ResultState;
                TestInfoModel resultTest = new TestInfoModel();
                resultTest.barcode = barcode;
                resultTest.perid = perid;
                resultTest.testid = testid; 
                resultTest.sampleID = sampleid;
                resultTest.groupNO = groupNO;

                resultTest.State = true;
                resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //resultTest.ListResult = itemResults;
                testInfo.AutographInfo = info;
                testInfo.Result = resultTest;
                string s = JsonHelper.SerializeObjct(testInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(SetResultTest, s);
                return jm.data.ToString();
            }
            else
            {


                if (barcode != "" && testid != 0 && groupNO != "")
                {
                    CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
                    testInfo.UserName = CommonData.UserInfo.names;
                    
                    testInfo.ResultState = ResultState;
                    TestInfoModel resultTest = new TestInfoModel();
                    resultTest.barcode = barcode;
                    resultTest.testid = testid; resultTest.sampleID = sampleid;
                    resultTest.perid = perid;
                    resultTest.groupNO = groupNO;
                    resultTest.State = true;
                    resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    List<ItemResultModel> itemResults = new List<ItemResultModel>();
                    DataTable dataTable = GCTestInfo.DataSource as DataTable;

                    bool saveState = true;
                    foreach (DataRow row in dataTable.Rows)
                    //for (int a = 0; a < GVTestInfo.RowCount; a++)
                    {
                        //DataRow row = GVTestInfo.GetDataRow(a);
                        if (row["resultNullState"] != DBNull.Value && Convert.ToBoolean(row["resultNullState"]))
                        {
                            ItemResultModel itemResult = new ItemResultModel();
                            itemResult.itemCode = row["itemCodes"] != DBNull.Value ? row["itemCodes"].ToString() : "";
                            itemResult.itemResult = row["itemResult"] != DBNull.Value ? row["itemResult"].ToString() : "";
                            itemResult.itemFlag = row["flag"] != DBNull.Value ? row["flag"].ToString() : "";
                            itemResult.itemReportState = row["reportState"] != DBNull.Value ? row["reportState"].ToString() : "true";
                            itemResult.itemSort = row["itemSort"] != DBNull.Value ? Convert.ToInt32(row["itemSort"]) : 99;
                            //itemResult.itemSort = row["itemSort"] != row.;
                            //itemResult.resultNullState = row["resultNullState"].ToString();
                            itemResults.Add(itemResult);
                        }
                        else
                        {

                            if (row["itemResult"] != DBNull.Value && row["itemResult"].ToString().Trim().Length > 0)
                            {

                                ItemResultModel itemResult = new ItemResultModel();
                                itemResult.itemCode = row["itemCodes"] != DBNull.Value ? row["itemCodes"].ToString() : "";
                                itemResult.itemResult = row["itemResult"] != DBNull.Value ? row["itemResult"].ToString() : "";
                                itemResult.itemFlag = row["flag"] != DBNull.Value ? row["flag"].ToString() : "";
                                itemResult.itemReportState = row["reportState"] != DBNull.Value ? row["reportState"].ToString() : "true";
                                itemResult.itemSort = row["itemSort"] != DBNull.Value ? Convert.ToInt32(row["itemSort"]) : 99;
                                //itemResult.resultNullState = row["resultNullState"].ToString();
                                itemResults.Add(itemResult);
                            }
                            else
                            {
                                saveState = false;
                                break;
                            }
                        }

                    }

                    resultTest.ListResult = itemResults;
                    testInfo.AutographInfo = info;
                    testInfo.Result = resultTest;


                    if (saveState && itemResults != null)
                    {
                        string s = JsonHelper.SerializeObjct(testInfo);
                        WebApiCallBack jm = ApiHelpers.postInfo(SetResultTest, s);
                        return jm.data.ToString();
                    }
                    else
                    {
                        //MessageBox.Show("检验结果有空值。请检查样本结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return "检验结果有空值。请检查样本结果！";
                        return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"检验结果有空值。请检查样本结果！\"}";
                    }

                }
                else
                {
                    return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息！\"}";
                }
            }
        }
        /// <summary>
        /// 其他功能反射
        /// </summary>
        /// <param name="ValueInfo"></param>
        /// <returns></returns>
        public void setOtherInfo(object ValueInfo)
        {
            try
            {
                if (ValueInfo != null)
                {
                    string values = ValueInfo.ToString();
                    if (values == "1")
                    {
                        //BTTakePicture_ItemClick(null, null);
                    }
                    if (values == "2")
                    {
                        //BTDeletePicture_ItemClick(null, null);
                    }
                }
            }
            catch
            {

            }

        }


        private void GVTestInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //GVTestInfo.GetNearestCanFocusedColumn("itemResult");
        }
    }
}
