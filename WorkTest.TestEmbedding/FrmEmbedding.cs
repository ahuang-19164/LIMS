using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace WorkTest.TestEmbedding
{
    public partial class FrmEmbedding : DevExpress.XtraEditors.XtraForm
    {
        string tableName = "WorkTest.ResultPathologyBlock";
        string PathologyBlockHandle = "";
        public FrmEmbedding()
        {
            InitializeComponent();
            DEStartTime.EditValue = DateTime.Now;
            DEEndTime.EditValue = DateTime.Now;
        }
        private void FrmEmbedding_Load(object sender, EventArgs e)
        {
            getPrintInfo();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("no", typeof(int));
            dataTable.Columns.Add("names", typeof(string));
            dataTable.Columns.Add("shortNames", typeof(string));
            dataTable.Columns.Add("customCode", typeof(string));
            dataTable.Rows.Add(0, "大体取材", "dtqc", "QC");
            dataTable.Rows.Add(1, "包埋等待", "bmdd", "BM");
            dataTable.Rows.Add(2, "包埋确认", "bmqr", "BM");
            dataTable.Rows.Add(3, "切片确认", "qpqr", "qp");

            GridLookUpEdites.Formats(RGEState, dataTable);


            PathologyBlockHandle = ConfigInfos.ReadConfigInfo("PathologyBlockHandle");
            DEStartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");



            GridControls.formartGridView(GVEmbedding);
            GridControls.showEmbeddedNavigator(GCEmbedding);

        }
        public void getPrintInfo()
        {
            try
            {
                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    RCBPrintInfo.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CBPrintInfo.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CBPrintInfo.EditValue = null;
            }
        }

        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;

            string stringWhere = $"dstate=0 and createTime>='{Convert.ToDateTime(DEStartTime.EditValue).ToString("yyyy-MM-dd")}' and createTime<'{Convert.ToDateTime(DEEndTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}'";
            if (TEBarcode.EditValue != null && TEBarcode.EditValue.ToString() != "")
            {
                stringWhere += $" and barcode like '%{TEBarcode.EditValue}%'";
            }
            if (TEpathologyNo.EditValue != null && TEpathologyNo.EditValue.ToString() != "")
            {
                stringWhere += $" and pathologyNo like '%{TEpathologyNo.EditValue}%'";
            }
            sInfo.wheres = stringWhere;
            DataTable DT = ApiHelpers.postInfo(sInfo);
            if (DT != null)
            {
                DT.Columns.Add("check", typeof(bool));
                GCEmbedding.DataSource = DT;
                GVEmbedding.BestFitColumns();
                GVEmbedding.ExpandAllGroups();
            }
        }

        private void CECheckAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVEmbedding.RowCount > 0)
            {
                if (CECheckAll.Checked)
                {
                    for (int a = 0; a < GVEmbedding.RowCount; a++)
                    {
                        GVEmbedding.SetRowCellValue(a, "check", true);
                    }
                }
                else
                {
                    for (int a = 0; a < GVEmbedding.RowCount; a++)
                    {
                        GVEmbedding.SetRowCellValue(a, "check", false);
                    }
                }
            }
        }

        private void BTbm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVEmbedding.FocusedRowHandle = -1;
            DataTable dataTable = GCEmbedding.DataSource as DataTable;
            CommResultModel<List<BlockInfoModel>> commInfo = new CommResultModel<List<BlockInfoModel>>();
            commInfo.UserName = CommonData.UserInfo.names;
            
            List<BlockInfoModel> blockInfos = new List<BlockInfoModel>();
            commInfo.Result = blockInfos;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int pathologyStateNO= dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                    bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (BlockCheck&& pathologyStateNO==1)
                    {
                        BlockInfoModel blockInfo = new BlockInfoModel();
                        blockInfo.id = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        blockInfo.testid = dataRow["testid"] != DBNull.Value ? Convert.ToInt32(dataRow["testid"]) : 0;
                        blockInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                        blockInfo.state = 2;
                        blockInfos.Add(blockInfo);
                    }
                }
                if (blockInfos.Count > 0)
                {
                    string sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(PathologyBlockHandle, sr);
                    commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                    if (commReInfo.code == 0)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                            bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                            if (BlockCheck && pathologyStateNO == 1)
                            {
                                dataRow["state"] = 2;
                                dataRow["bmPerson"] = CommonData.UserInfo.names;
                                dataRow["bmTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            }
                        }
                        GCEmbedding.RefreshDataSource();
                        GVEmbedding.BestFitColumns();
                    }

                }
                else
                {
                    MessageBox.Show($"提交包埋信息为空，请选择需要包埋信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BTRebm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVEmbedding.FocusedRowHandle = -1;
            DataTable dataTable = GCEmbedding.DataSource as DataTable;
            CommResultModel<List<BlockInfoModel>> commInfo = new CommResultModel<List<BlockInfoModel>>();
            commInfo.UserName = CommonData.UserInfo.names;
            
            List<BlockInfoModel> blockInfos = new List<BlockInfoModel>();
            commInfo.Result = blockInfos;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                    bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (BlockCheck && pathologyStateNO == 2)
                    {
                        BlockInfoModel blockInfo = new BlockInfoModel();
                        blockInfo.id = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        blockInfo.testid = dataRow["testid"] != DBNull.Value ? Convert.ToInt32(dataRow["testid"]) : 0;
                        blockInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                        blockInfo.state = 4;
                        blockInfos.Add(blockInfo);
                    }
                }
                if (blockInfos.Count > 0)
                {
                    string sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(PathologyBlockHandle, sr);
                    commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                    if (commReInfo.code == 0)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                            bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                            if (BlockCheck && pathologyStateNO == 2)
                            {
                                dataRow["state"] = 1;
                                dataRow["bmPerson"] = "";
                                dataRow["bmTime"] = null;
                            }
                        }
                        GCEmbedding.RefreshDataSource();
                    }

                }
                else
                {
                    MessageBox.Show($"提交反包埋信息为空，请选择需要提交反包埋信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BTqp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVEmbedding.FocusedRowHandle = -1;
            DataTable dataTable = GCEmbedding.DataSource as DataTable;
            CommResultModel<List<BlockInfoModel>> commInfo = new CommResultModel<List<BlockInfoModel>>();
            commInfo.UserName = CommonData.UserInfo.names;
            
            List<BlockInfoModel> blockInfos = new List<BlockInfoModel>();
            commInfo.Result = blockInfos;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                    bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (BlockCheck && pathologyStateNO == 2)
                    {
                        BlockInfoModel blockInfo = new BlockInfoModel();
                        blockInfo.id = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        blockInfo.testid = dataRow["testid"] != DBNull.Value ? Convert.ToInt32(dataRow["testid"]) : 0;
                        blockInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";

                        blockInfo.state = 3;
                        blockInfos.Add(blockInfo);
                    }
                }
                if (blockInfos.Count > 0)
                {
                    string sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(PathologyBlockHandle, sr);
                    commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                    if (commReInfo.code == 0)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                            bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                            if (BlockCheck && pathologyStateNO == 2)
                            {
                                dataRow["state"] = 3;
                                dataRow["qpPerson"] = CommonData.UserInfo.names;
                                dataRow["qpTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        GCEmbedding.RefreshDataSource();
                        GVEmbedding.BestFitColumns();
                    }

                }
                else
                {
                    MessageBox.Show($"提交切片信息为空，请选择需要提交切片信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BTReqp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVEmbedding.FocusedRowHandle = -1;
            DataTable dataTable = GCEmbedding.DataSource as DataTable;
            CommResultModel<List<BlockInfoModel>> commInfo = new CommResultModel<List<BlockInfoModel>>();
            commInfo.UserName = CommonData.UserInfo.names;
            
            List<BlockInfoModel> blockInfos = new List<BlockInfoModel>();
            commInfo.Result = blockInfos;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                    bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (BlockCheck && pathologyStateNO == 3)
                    {
                        BlockInfoModel blockInfo = new BlockInfoModel();
                        blockInfo.id = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        blockInfo.testid = dataRow["testid"] != DBNull.Value ? Convert.ToInt32(dataRow["testid"]) : 0;
                        blockInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                        blockInfo.state = 5;
                        blockInfos.Add(blockInfo);
                    }
                }
                if (blockInfos.Count > 0)
                {
                    commInfo.Result = blockInfos;
                    string sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(PathologyBlockHandle, sr);
                    commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                    if (commReInfo.code == 0)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                            bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                            if (BlockCheck && pathologyStateNO == 3)
                            {
                                dataRow["state"] = 2;
                                dataRow["qpPerson"] = "";
                                dataRow["qpTime"] = null;
                            }
                        }
                        GCEmbedding.RefreshDataSource();
                    }

                }
                else
                {
                    MessageBox.Show($"提交反切片信息为空，请选择需要提交反切片信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BTPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {


                DataTable dataTable = GCEmbedding.DataSource as DataTable;


                BarTender.Application btApp = new BarTender.Application();
                BarTender.Format btFormat = new BarTender.Format();
                btFormat = btApp.Formats.Open(AppDomain.CurrentDomain.BaseDirectory + "\\BarCodeTemplateInfo\\BlockInfo.btw", false, "");

                //向bartender模板传递变量,SN为条形码数据的一个共享名称
                //btFormat.SetNamedSubStringValue("barcode", "1111");
                //btFormat.SetNamedSubStringValue("code", "1111");

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                        if (BlockCheck)
                        {
                            string barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                            string pathologyNo = dataRow["pathologyNo"] != DBNull.Value ? dataRow["pathologyNo"].ToString() : "";
                            btFormat.SetNamedSubStringValue("barcode", pathologyNo);
                            btFormat.SetNamedSubStringValue("names", "测试取材");
                            btFormat.SetNamedSubStringValue("codes", pathologyNo);
                            //选择打印机
                            btFormat.Printer = CBPrintInfo.EditValue.ToString();

                            //设置打印份数
                            //int CopiesOfLabel = Int32.Parse(TENumbers.EditValue.ToString());
                            int CopiesOfLabel = 1;
                            btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;

                            //设置打印时是否跳出打印属性
                            btFormat.PrintOut(false, false);

                            //退出时是否保存标签
                            btFormat.Close();

                            //btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
                        }
                    }
                }





                ////选择打印机
                //btFormat.Printer = CBPrintInfo.EditValue.ToString();

                ////设置打印份数
                ////int CopiesOfLabel = Int32.Parse(TENumbers.EditValue.ToString());
                //int CopiesOfLabel = 1;
                //btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;

                ////设置打印时是否跳出打印属性
                //btFormat.PrintOut(false, false);

                ////退出时是否保存标签
                //btFormat.Close();

                ////btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息: " + ex.Message);
                return;
            }
        }

        private void BTReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVEmbedding.FocusedRowHandle = -1;
            DataTable dataTable = GCEmbedding.DataSource as DataTable;
            commInfoModel<BlockInfoModel> commInfo = new commInfoModel<BlockInfoModel>();
            commInfo.UserName = CommonData.UserInfo.names;
            
            List<BlockInfoModel> blockInfos = new List<BlockInfoModel>();
            commInfo.infos = blockInfos;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                    bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (BlockCheck && pathologyStateNO == 3)
                    {
                        BlockInfoModel blockInfo = new BlockInfoModel();
                        blockInfo.testid = dataRow["testid"] != DBNull.Value ? Convert.ToInt32(dataRow["testid"]) : 0;
                        blockInfo.state = 6;
                        if (!blockInfos.Contains(blockInfo))
                            blockInfos.Add(blockInfo);
                    }
                }
                if (blockInfos.Count > 0)
                {
                    string sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(PathologyBlockHandle, sr);
                    commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                    if (commReInfo.code == 0)
                    {
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            int pathologyStateNO = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 0;
                            bool BlockCheck = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                            if (BlockCheck && pathologyStateNO == 3)
                            {
                                dataTable.Rows.Remove(dataRow);
                            }
                        }
                        GCEmbedding.RefreshDataSource();
                    }

                }
                else
                {
                    MessageBox.Show($"提交退回信息为空，请选择需要提交退回信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GVEmbedding_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = GVEmbedding.GetFocusedDataRow();

            if (dataRow != null)
            {

                bool check = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                string barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                string pathologyNo = dataRow["pathologyNo"] != DBNull.Value ? dataRow["pathologyNo"].ToString() : "";
                if (!check)
                {
                    for (int a = 0; a < GVEmbedding.RowCount; a++)
                    {
                        string barcodes = GVEmbedding.GetRowCellValue(a, "barcode") != null ? GVEmbedding.GetRowCellValue(a, "barcode").ToString() : "";
                        string pathologyNos = GVEmbedding.GetRowCellValue(a, "pathologyNo") != null ? GVEmbedding.GetRowCellValue(a, "pathologyNo").ToString() : "";
                        if (barcode == barcodes && pathologyNo == pathologyNos)
                            GVEmbedding.SetRowCellValue(a, "check", true);
                    }
                }
                else
                {
                    for (int a = 0; a < GVEmbedding.RowCount; a++)
                    {
                        string barcodes = GVEmbedding.GetRowCellValue(a, "barcode") != null ? GVEmbedding.GetRowCellValue(a, "barcode").ToString() : "";
                        string pathologyNos = GVEmbedding.GetRowCellValue(a, "pathologyNo") != null ? GVEmbedding.GetRowCellValue(a, "pathologyNo").ToString() : "";
                        if (barcode == barcodes && pathologyNo == pathologyNos)
                            GVEmbedding.SetRowCellValue(a, "check", false);
                    }
                }

            }
        }

        private void GVEmbedding_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "state")
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "0")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                        if (e.CellValue.ToString() == "1")
                        {
                            e.Appearance.BackColor = Color.BlueViolet;
                        }
                        if (e.CellValue.ToString() == "2")
                        {
                            e.Appearance.BackColor = Color.IndianRed;
                        }
                        if (e.CellValue.ToString() == "3")
                        {
                            e.Appearance.BackColor = Color.CadetBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
