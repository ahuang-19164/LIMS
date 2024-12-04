using Common.BLL;
using Common.ControlHandle;
using Common.Data;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Common.CreateReport
{
    public partial class FrmReportBind : DevExpress.XtraEditors.XtraForm
    {
        string tableName = "Report.BindInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmReportBind()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            GridLookUpEdites.Formats(GEClientNO);
            GridLookUpEdites.Formats(GEPageHeaderNO);
            GridLookUpEdites.Formats(GEDetailNO);
            GridLookUpEdites.Formats(GEGroupHeaderNO);
            GridLookUpEdites.Formats(GEReportHeaderNO);
            GridLookUpEdites.Formats(GETestGroupNO);
            GridLookUpEdites.Formats(GETestItemNO);
            GridLookUpEdites.Formats(GEWorkGroupNO);
            GridLookUpEdites.Formats(GEGroupFooterNO);
            GridLookUpEdites.Formats(GEReportFooterNO);
            GridLookUpEdites.Formats(GEPageFooterNO);
            GridLookUpEdites.Formats(GEreportPageNO);
            GridLookUpEdites.Formats(GEreportTileNO);
            GEClientNO.Properties.DataSource = Common.Data.WorkCommData.DTClientInfo;
            if (ReportCommData.DTReportSrouceInfo != null)
            {
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='1'").Count() > 0)
                    GEReportHeaderNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='1'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='2'").Count() > 0)
                    GEPageHeaderNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='2'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='3'").Count() > 0)
                    GEGroupHeaderNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='3'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='4'").Count() > 0)
                    GEDetailNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='4'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='5'").Count() > 0)
                    GEGroupFooterNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='5'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='6'").Count() > 0)
                    GEReportFooterNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='6'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='7'").Count() > 0)
                    GEPageFooterNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='7'").CopyToDataTable();
                if (ReportCommData.DTReportSrouceInfo.Select("typeNO='8'").Count() > 0)
                    GEreportTileNO.Properties.DataSource = ReportCommData.DTReportSrouceInfo.Select("typeNO='8'").CopyToDataTable();
            }
            GETestGroupNO.Properties.DataSource = Common.Data.WorkCommData.DTGroupTest;
            GETestItemNO.Properties.DataSource = Common.Data.WorkCommData.DTItemGroup;
            GEWorkGroupNO.Properties.DataSource = Common.Data.WorkCommData.DTGroupWork;
            GEreportPageNO.Properties.DataSource = Common.Data.ReportCommData.DTReportSet;
        }
        private void FrmReportBind_Load(object sender, EventArgs e)
        {
            GCInfo.DataSource = ReportCommData.DTReportBindInfo;
            GVInfo.Click += GVInfo_Click;
        }

        private void GVInfo_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                int handle = GVInfo.FocusedRowHandle;
                DataRow dr = GVInfo.GetFocusedDataRow();
                SelectValueID = Convert.ToInt32(dr["id"]);
                TENo.EditValue = dr["no"];
                TENames.EditValue = dr["names"];
                GEClientNO.EditValue = dr["clientNO"];
                GEPageHeaderNO.EditValue = dr["pageHeaderNO"];
                GEDetailNO.EditValue = dr["detailNO"];
                GEGroupHeaderNO.EditValue = dr["groupHeaderNO"];
                GEreportTileNO.EditValue = dr["reportTileNO"];
                GEReportHeaderNO.EditValue = dr["reportHeaderNO"];
                GETestGroupNO.EditValue = dr["testGroupNO"];
                GETestItemNO.EditValue = dr["testItemNO"];
                GEWorkGroupNO.EditValue = dr["workGroupNO"];
                GEreportPageNO.EditValue = dr["paperKindNO"];
                GEGroupFooterNO.EditValue = dr["groupFooterNO"];
                GEReportFooterNO.EditValue = dr["reportFooterNO"];
                GEPageFooterNO.EditValue = dr["pageFooterNO"];
                TERemark.EditValue = dr["remark"];
                CEHX.Checked = Convert.ToBoolean(dr["reportLandscape"]);
                CEState.Checked = Convert.ToBoolean(dr["state"]); ;

            }
        }

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            EditState = 1;

            if (ReportCommData.DTReportBindInfo == null)
            {
                TENo.EditValue = 1;
            }
            else
            {
                TENo.EditValue = Convert.ToInt32(ReportCommData.DTReportBindInfo.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            TENames.EditValue = "";
            GEClientNO.EditValue = "";
            GEPageHeaderNO.EditValue = "";
            GEDetailNO.EditValue = "";
            GEGroupHeaderNO.EditValue = "";
            GEreportTileNO.EditValue = "";
            GEReportHeaderNO.EditValue = "";
            GETestGroupNO.EditValue = "";
            GETestItemNO.EditValue = "";
            GEWorkGroupNO.EditValue = "";
            GEreportPageNO.EditValue = "";
            GEGroupFooterNO.EditValue = "";
            GEReportFooterNO.EditValue = "";
            GEPageFooterNO.EditValue = "";
            CEHX.Checked = false;
            CEState.Checked = true;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENo.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("clientNO", GEClientNO.EditValue);
                pairs.Add("pageHeaderNO", GEPageHeaderNO.EditValue);
                pairs.Add("detailNO", GEDetailNO.EditValue);
                pairs.Add("groupHeaderNO", GEGroupHeaderNO.EditValue);
                pairs.Add("reportTileNO", GEreportTileNO.EditValue);
                pairs.Add("reportHeaderNO", GEReportHeaderNO.EditValue);
                pairs.Add("testGroupNO", GETestGroupNO.EditValue);
                pairs.Add("testItemNO", GETestItemNO.EditValue);
                pairs.Add("workGroupNO", GEWorkGroupNO.EditValue);
                pairs.Add("paperKindNO", GEreportPageNO.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                pairs.Add("state", CEState.EditValue);
                pairs.Add("groupFooterNO", GEGroupFooterNO.EditValue);
                pairs.Add("reportFooterNO", GEReportFooterNO.EditValue);
                pairs.Add("pageFooterNO", GEPageFooterNO.EditValue);
                pairs.Add("reportLandscape", CEHX.Checked);
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                pairs.Add("dstate", 0);

                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = Convert.ToInt32(SqlConnServer.postinserts(insertInfo));

            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    //pairs.Add("no", TENo.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("clientNO", GEClientNO.EditValue);
                    pairs.Add("pageHeaderNO", GEPageHeaderNO.EditValue);
                    pairs.Add("detailNO", GEDetailNO.EditValue);
                    pairs.Add("groupHeaderNO", GEGroupHeaderNO.EditValue);
                    pairs.Add("reportTileNO", GEreportTileNO.EditValue);
                    pairs.Add("reportHeaderNO", GEReportHeaderNO.EditValue);
                    pairs.Add("testGroupNO", GETestGroupNO.EditValue);
                    pairs.Add("testItemNO", GETestItemNO.EditValue);
                    pairs.Add("workGroupNO", GEWorkGroupNO.EditValue);
                    pairs.Add("paperKindNO", GEreportPageNO.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("groupFooterNO", GEGroupFooterNO.EditValue);
                    pairs.Add("reportFooterNO", GEReportFooterNO.EditValue);
                    pairs.Add("pageFooterNO", GEPageFooterNO.EditValue);
                    pairs.Add("reportLandscape", CEHX.Checked);
                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    pairs.Add("dstate", 0);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = Convert.ToInt32(SqlConnServer.postupdates(updateInfo));
                }
            }
            EditState = 0;
            CommonDataRefresh.GetreportBind();
            FrmReportBind_Load(null, null);
            groupBox1.Enabled = false;
        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void BTReportVeiw_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportCreate();
        }

        private void BTReportVeiws_Click(object sender, EventArgs e)
        {
            //if (GEreportPageNO.EditValue!=null)
            //{
            //    string ssss = GEreportPageNO.EditValue.ToString();
            //    switch(ssss)
            //    {
            //        case "1":
            //            ReportCreateA4();
            //            break;
            //        case "2":
            //            ReportCreateA5();
            //            break;
            //        default:
            //            XtraMessageBox.Show("没有匹配的报告单母板!", "系统提示");
            //            break;
            //    }


            //}
            ReportCreate();


        }






        public void ReportCreate()
        {
            CommonReport commonReport = new CommonReport();
            commonReport.Margins = new System.Drawing.Printing.Margins(12, 12, 12, 12);
            if (GEreportPageNO.EditValue != null)
            {
                if (GEreportPageNO.EditValue.ToString() == "1")
                    commonReport.PaperKind = System.Drawing.Printing.PaperKind.A5;//判断纸张的大小
                if (GEreportPageNO.EditValue.ToString() == "2")
                    commonReport.PaperKind = System.Drawing.Printing.PaperKind.A4;//判断纸张的大小
                if (GEreportPageNO.EditValue.ToString() == "3")
                    commonReport.PaperKind = System.Drawing.Printing.PaperKind.A3;//判断纸张的大小
            }
            commonReport.Landscape = CEHX.Checked;//判断是否纸张横向
            int Subwith = commonReport.PageWidth - 24;


            //ReportHeaderNO

            if (GEReportHeaderNO.EditValue != null)
            {
                if (GEReportHeaderNO.EditValue.ToString() != "")
                {


                    commonReport.ReportHeader.Visible = true;
                    commonReport.ReportHeader.Padding = PaddingInfo.Empty;

                    commonReport.ReportHeader.BorderWidth = 0;
                    commonReport.SubReportHeader.Visible = true;
                    commonReport.SubReportHeader.SnapLineMargin = PaddingInfo.Empty;
                    //commonReport.SubReportHeader.ResetBorderWidth();

                    commonReport.SubReportHeader.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportHeaderNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportHeaderNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubReportHeader.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.ReportHeader.Visible = false;
                    commonReport.SubReportHeader.Visible = false;
                }
            }
            else
            {
                commonReport.ReportHeader.Visible = false;
                commonReport.SubReportHeader.Visible = false;
            }






            if (GEPageHeaderNO.EditValue != null)
            {
                if (GEPageHeaderNO.EditValue.ToString() != "")
                {
                    commonReport.PageHeader.BorderWidth = 0;
                    commonReport.PageHeader.Visible = true;
                    commonReport.SubPageHeader.Visible = true;
                    commonReport.PageHeader.Padding = PaddingInfo.Empty;
                    commonReport.SubPageHeader.SnapLineMargin = PaddingInfo.Empty;
                    //commonReport.PageHeader.Visible = false;
                    //commonReport.SubPageHeader.Visible = false;
                    commonReport.SubPageHeader.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEPageHeaderNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEPageHeaderNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubPageHeader.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.PageHeader.Visible = false;
                    commonReport.SubPageHeader.Visible = false;
                }

            }
            else
            {
                commonReport.PageHeader.Visible = false;
                commonReport.SubPageHeader.Visible = false;
            }







            //GroupHeaderNO
            if (GEGroupHeaderNO.EditValue != null)
            {
                if (GEGroupHeaderNO.EditValue.ToString() != "")
                {
                    commonReport.GroupHeader.Visible = true;
                    commonReport.SubGroupHeader.Visible = true;
                    commonReport.SubGroupHeader.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupHeaderNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupHeaderNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubGroupHeader.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.GroupHeader.Visible = false;
                    commonReport.SubGroupHeader.Visible = false;
                    commonReport.GroupHeader.HeightF = 0;
                    commonReport.SubGroupHeader.HeightF = 0;
                }


            }
            else
            {
                commonReport.GroupHeader.Visible = false;
                commonReport.SubGroupHeader.Visible = false;
                commonReport.GroupHeader.HeightF = 0;
                commonReport.SubGroupHeader.HeightF = 0;
            }






            //DetailNO
            if (GEDetailNO.EditValue != null)
            {
                if (GEDetailNO.EditValue.ToString() != "")
                {
                    commonReport.Detail.Visible = true;
                    commonReport.SubDetail.Visible = true;
                    commonReport.SubDetail.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEDetailNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEDetailNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubDetail.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.Detail.Visible = false;
                    commonReport.SubDetail.Visible = false;
                }


            }
            else
            {
                commonReport.Detail.Visible = false;
                commonReport.SubDetail.Visible = false;
            }







            //GroupFooterNO
            if (GEGroupFooterNO.EditValue != null)
            {
                if (GEGroupFooterNO.EditValue.ToString() != "")
                {


                    commonReport.GroupFooter.Visible = true;
                    commonReport.SubGroupFooter.Visible = true;

                    commonReport.SubGroupFooter.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupFooterNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEGroupFooterNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubGroupFooter.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.GroupFooter.Visible = false;
                    commonReport.SubGroupFooter.Visible = false;
                }


            }
            else
            {
                commonReport.GroupFooter.Visible = false;
                commonReport.SubGroupFooter.Visible = false;
            }




            //PageFooterNO
            if (GEPageFooterNO.EditValue != null)
            {
                if (GEPageFooterNO.EditValue.ToString() != "")
                {
                    commonReport.PageFooter.Visible = true;
                    commonReport.SubPageFooter.Visible = true;
                    commonReport.SubPageFooter.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEPageFooterNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEPageFooterNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubPageFooter.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.PageFooter.Visible = false;
                    commonReport.SubPageFooter.Visible = false;
                }


            }
            else
            {
                commonReport.PageFooter.Visible = false;
                commonReport.SubPageFooter.Visible = false;
            }


            //ReportFooterNO
            if (GEReportFooterNO.EditValue != null)
            {
                if (GEReportFooterNO.EditValue.ToString() != "")
                {
                    commonReport.ReportFooter.Visible = true;
                    commonReport.SubReportFooter.Visible = true;

                    commonReport.SubReportFooter.SizeF = new System.Drawing.SizeF(Subwith, 20F);
                    if (Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportFooterNO.EditValue}'").Count() > 0)
                    {
                        XtraReport xtraReport = new XtraReport();
                        DataSet dataSet = new DataSet();
                        DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='{GEReportFooterNO.EditValue}'").CopyToDataTable();
                        if (TEbarcodeView.EditValue != null && TEsampleID.EditValue != null)
                        {
                            if (!Convert.IsDBNull(DT.Rows[0]["srouceNames"]))
                            {
                                string srouceNames = DT.Rows[0]["srouceNames"].ToString();
                                string[] tablenames = srouceNames.Split(',');
                                foreach (string tablename in tablenames)
                                {
                                    if (srouceNames != "")
                                    {
                                        sInfo selectInfo = new sInfo();
                                        selectInfo.TableName = tablename;
                                        selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}'and state=1";
                                        DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                        if (dataTable != null)
                                        {
                                            dataTable.TableName = tablename.Replace(".", "");
                                            dataSet.Tables.Add(dataTable);
                                        }
                                    }
                                }
                            }
                            if (!Convert.IsDBNull(DT.Rows[0]["imgSrouce"]))
                            {
                                string imgSrouce = DT.Rows[0]["imgSrouce"].ToString();
                                string[] tableImgs = imgSrouce.Split(',');
                                foreach (string tableImg in tableImgs)
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.TableName = tableImg;
                                    selectInfo.wheres = $"barcode='{TEbarcodeView.EditValue}' and sampleID='{TEsampleID.EditValue}' and state=1";
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tableImg.Replace(".", "");
                                        dataTable.Columns.Add("img", typeof(Image));
                                        foreach (DataRow dataRow in dataTable.Rows)
                                        {
                                            string imgstr = dataRow["filestring"].ToString();
                                            dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                        }
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }

                        if (!Convert.IsDBNull(DT.Rows[0]["fileString"]))
                        {
                            string FileString = DT.Rows[0]["fileString"].ToString();
                            byte[] arr = Convert.FromBase64String(FileString);
                            Stream stream = new MemoryStream(arr);
                            //dataSet.Namespace = "dataInfo";
                            dataSet.DataSetName = "dataInfo";
                            xtraReport.DataSource = dataSet;
                            xtraReport.LoadLayout(stream);
                            xtraReport.PageWidth = Subwith;
                            commonReport.SubReportFooter.ReportSource = xtraReport;
                        }
                    }
                }
                else
                {
                    commonReport.ReportFooter.Visible = false;
                    commonReport.SubReportFooter.Visible = false;
                    commonReport.ReportFooter.HeightF = 0;
                    commonReport.SubReportFooter.HeightF = 0;
                }
            }
            else
            {
                commonReport.ReportFooter.Visible = false;
                commonReport.SubReportFooter.Visible = false;
                commonReport.ReportFooter.HeightF = 0;
                commonReport.SubReportFooter.HeightF = 0;
            }

            commonReport.ShowPreview();
        }

        private void BTReportTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataRow dataRow = GVInfo.GetFocusedDataRow();

            XtraReport xtraReport = Common.ReportHandle.CreateReportHelper.ReportCreate(TEbarcodeView.EditValue.ToString(), TEsampleID.EditValue.ToString(), dataRow);
            xtraReport.ShowPreview();







            //string FileStringa = "Ly8vIDxYUlR5cGVJbmZvPg0KLy8vICAgPEFzc2VtYmx5RnVsbE5hbWU+RGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52MjAuMSwgVmVyc2lvbj0yMC4xLjMuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iODhkMTc1NGQ3MDBlNDlhPC9Bc3NlbWJseUZ1bGxOYW1lPg0KLy8vICAgPEFzc2VtYmx5TG9jYXRpb24+QzpcV2luZG93c1xNaWNyb3NvZnQuTmV0XGFzc2VtYmx5XEdBQ19NU0lMXERldkV4cHJlc3MuWHRyYVJlcG9ydHMudjIwLjFcdjQuMF8yMC4xLjMuMF9fYjg4ZDE3NTRkNzAwZTQ5YVxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnYyMC4xLmRsbDwvQXNzZW1ibHlMb2NhdGlvbj4NCi8vLyAgIDxUeXBlTmFtZT5EZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlh0cmFSZXBvcnQ8L1R5cGVOYW1lPg0KLy8vICAgPExvY2FsaXphdGlvbj56aC1DTjwvTG9jYWxpemF0aW9uPg0KLy8vICAgPFZlcnNpb24+MjAuMTwvVmVyc2lvbj4NCi8vLyAgIDxSZXNvdXJjZXM+DQovLy8gICAgIDxSZXNvdXJjZSBOYW1lPSJYdHJhUmVwb3J0U2VyaWFsaXphdGlvbi5YdHJhUmVwb3J0Ij4NCi8vLyB6c3J2dmdFQUFBQ1JBQUFBYkZONWMzUmxiUzVTWlhOdmRYSmpaWE11VW1WemIzVnlZMlZTWldGa1pYSXNJRzF6WTI5eWJHbGlMQ0JXWlhKemFXOXVQVFF1TUM0d0xqQXNJRU4xYkhSMWNtVTlibVYxZEhKaGJDd2dVSFZpYkdsalMyVjVWRzlyWlc0OVlqYzNZVFZqTlRZeE9UTTBaVEE0T1NOVGVYTjBaVzB1VW1WemIzVnlZMlZ6TGxKMWJuUnBiV1ZTWlhOdmRYSmpaVk5sZEFJQUFBQUFBQUFBQUFBQUFGQkJSRkJCUkZDMEFBQUE8L1Jlc291cmNlPg0KLy8vICAgPC9SZXNvdXJjZXM+DQovLy8gPC9YUlR5cGVJbmZvPg0KbmFtZXNwYWNlIFh0cmFSZXBvcnRTZXJpYWxpemF0aW9uIHsNCiAgICANCiAgICBwdWJsaWMgY2xhc3MgWHRyYVJlcG9ydCA6IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWHRyYVJlcG9ydCB7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Ub3BNYXJnaW5CYW5kIFRvcE1hcmdpbjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLkRldGFpbEJhbmQgRGV0YWlsOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQgc3ViRGV0YWlsOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuQm90dG9tTWFyZ2luQmFuZCBCb3R0b21NYXJnaW47DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5SZXBvcnRIZWFkZXJCYW5kIFJlcG9ydEhlYWRlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlBhZ2VIZWFkZXJCYW5kIFBhZ2VIZWFkZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCBzdWJSZXBvcnRIZWFkZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCBzdWJQYWdlSGVhZGVyOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuR3JvdXBIZWFkZXJCYW5kIEdyb3VwSGVhZGVyOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQgc3ViR3JvdXBIZWFkZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Hcm91cEZvb3RlckJhbmQgR3JvdXBGb290ZXI7DQogICAgICAgIHByaXZhdGUgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCBzdWJHcm91cEZvb3RlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlJlcG9ydEZvb3RlckJhbmQgUmVwb3J0Rm9vdGVyOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQgc3ViUmVwb3J0Rm9vdGVyOw0KICAgICAgICBwcml2YXRlIERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUGFnZUZvb3RlckJhbmQgUGFnZUZvb3RlcjsNCiAgICAgICAgcHJpdmF0ZSBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0IHN1YlBhZ2VGb290ZXI7DQogICAgICAgIHByaXZhdGUgU3lzdGVtLlJlc291cmNlcy5SZXNvdXJjZU1hbmFnZXIgX3Jlc291cmNlczsNCiAgICAgICAgcHJpdmF0ZSBzdHJpbmcgX3Jlc291cmNlU3RyaW5nOw0KICAgICAgICBwdWJsaWMgWHRyYVJlcG9ydCgpIHsNCiAgICAgICAgICAgIHRoaXMuX3Jlc291cmNlU3RyaW5nID0gRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5TZXJpYWxpemF0aW9uLlhSUmVzb3VyY2VNYW5hZ2VyLkdldFJlc291cmNlRm9yKCJYdHJhUmVwb3J0U2VyaWFsaXphdGlvbi5YdHJhUmVwb3J0Iik7DQogICAgICAgICAgICB0aGlzLkluaXRpYWxpemVDb21wb25lbnQoKTsNCiAgICAgICAgfQ0KICAgICAgICBwcml2YXRlIFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VNYW5hZ2VyIHJlc291cmNlcyB7DQogICAgICAgICAgICBnZXQgew0KICAgICAgICAgICAgICAgIGlmIChfcmVzb3VyY2VzID09IG51bGwpIHsNCiAgICAgICAgICAgICAgICAgICAgdGhpcy5fcmVzb3VyY2VzID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuU2VyaWFsaXphdGlvbi5YUlJlc291cmNlTWFuYWdlcih0aGlzLl9yZXNvdXJjZVN0cmluZyk7DQogICAgICAgICAgICAgICAgfQ0KICAgICAgICAgICAgICAgIHJldHVybiB0aGlzLl9yZXNvdXJjZXM7DQogICAgICAgICAgICB9DQogICAgICAgIH0NCiAgICAgICAgcHJpdmF0ZSB2b2lkIEluaXRpYWxpemVDb21wb25lbnQoKSB7DQogICAgICAgICAgICB0aGlzLlRvcE1hcmdpbiA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlRvcE1hcmdpbkJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuRGV0YWlsID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuRGV0YWlsQmFuZCgpOw0KICAgICAgICAgICAgdGhpcy5Cb3R0b21NYXJnaW4gPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5Cb3R0b21NYXJnaW5CYW5kKCk7DQogICAgICAgICAgICB0aGlzLlJlcG9ydEhlYWRlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlJlcG9ydEhlYWRlckJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuUGFnZUhlYWRlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlBhZ2VIZWFkZXJCYW5kKCk7DQogICAgICAgICAgICB0aGlzLkdyb3VwSGVhZGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuR3JvdXBIZWFkZXJCYW5kKCk7DQogICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuR3JvdXBGb290ZXJCYW5kKCk7DQogICAgICAgICAgICB0aGlzLlJlcG9ydEZvb3RlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlJlcG9ydEZvb3RlckJhbmQoKTsNCiAgICAgICAgICAgIHRoaXMuUGFnZUZvb3RlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlBhZ2VGb290ZXJCYW5kKCk7DQogICAgICAgICAgICB0aGlzLnN1YkRldGFpbCA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0KCk7DQogICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEhlYWRlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0KCk7DQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VIZWFkZXIgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUlN1YnJlcG9ydCgpOw0KICAgICAgICAgICAgdGhpcy5zdWJHcm91cEhlYWRlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0KCk7DQogICAgICAgICAgICB0aGlzLnN1Ykdyb3VwRm9vdGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQoKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0Rm9vdGVyID0gbmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJTdWJyZXBvcnQoKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUGFnZUZvb3RlciA9IG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSU3VicmVwb3J0KCk7DQogICAgICAgICAgICAoKFN5c3RlbS5Db21wb25lbnRNb2RlbC5JU3VwcG9ydEluaXRpYWxpemUpKHRoaXMpKS5CZWdpbkluaXQoKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gVG9wTWFyZ2luDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuVG9wTWFyZ2luLkhlaWdodEYgPSAxMkY7DQogICAgICAgICAgICB0aGlzLlRvcE1hcmdpbi5OYW1lID0gIlRvcE1hcmdpbiI7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIERldGFpbA0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLkRldGFpbC5Db250cm9scy5BZGRSYW5nZShuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUkNvbnRyb2xbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN1YkRldGFpbH0pOw0KICAgICAgICAgICAgdGhpcy5EZXRhaWwuSGVpZ2h0RiA9IDQ0LjIwODMyRjsNCiAgICAgICAgICAgIHRoaXMuRGV0YWlsLk5hbWUgPSAiRGV0YWlsIjsNCiAgICAgICAgICAgIHRoaXMuRGV0YWlsLlNuYXBMaW5lUGFkZGluZyA9IG5ldyBEZXZFeHByZXNzLlh0cmFQcmludGluZy5QYWRkaW5nSW5mbygwLCAwLCAwLCAwLCAxMDBGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gQm90dG9tTWFyZ2luDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuQm90dG9tTWFyZ2luLkhlaWdodEYgPSAxMkY7DQogICAgICAgICAgICB0aGlzLkJvdHRvbU1hcmdpbi5OYW1lID0gIkJvdHRvbU1hcmdpbiI7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIFJlcG9ydEhlYWRlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLlJlcG9ydEhlYWRlci5IZWlnaHRGID0gNDQuMjA4MzJGOw0KICAgICAgICAgICAgdGhpcy5SZXBvcnRIZWFkZXIuTmFtZSA9ICJSZXBvcnRIZWFkZXIiOw0KICAgICAgICAgICAgdGhpcy5SZXBvcnRIZWFkZXIuU25hcExpbmVQYWRkaW5nID0gbmV3IERldkV4cHJlc3MuWHRyYVByaW50aW5nLlBhZGRpbmdJbmZvKDAsIDAsIDAsIDAsIDEwMEYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBQYWdlSGVhZGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuUGFnZUhlYWRlci5Db250cm9scy5BZGRSYW5nZShuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUkNvbnRyb2xbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN1YlJlcG9ydEhlYWRlciwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuc3ViUGFnZUhlYWRlcn0pOw0KICAgICAgICAgICAgdGhpcy5QYWdlSGVhZGVyLkhlaWdodEYgPSA0NC4yMDgzMkY7DQogICAgICAgICAgICB0aGlzLlBhZ2VIZWFkZXIuTmFtZSA9ICJQYWdlSGVhZGVyIjsNCiAgICAgICAgICAgIHRoaXMuUGFnZUhlYWRlci5TbmFwTGluZVBhZGRpbmcgPSBuZXcgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuUGFkZGluZ0luZm8oMCwgMCwgMCwgMCwgMTAwRik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIEdyb3VwSGVhZGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIuQ29udHJvbHMuQWRkUmFuZ2UobmV3IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuWFJDb250cm9sW10gew0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5zdWJHcm91cEhlYWRlcn0pOw0KICAgICAgICAgICAgdGhpcy5Hcm91cEhlYWRlci5IZWlnaHRGID0gNDQuMjA4MzJGOw0KICAgICAgICAgICAgdGhpcy5Hcm91cEhlYWRlci5OYW1lID0gIkdyb3VwSGVhZGVyIjsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIuU25hcExpbmVQYWRkaW5nID0gbmV3IERldkV4cHJlc3MuWHRyYVByaW50aW5nLlBhZGRpbmdJbmZvKDAsIDAsIDAsIDAsIDEwMEYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBHcm91cEZvb3Rlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyLkNvbnRyb2xzLkFkZFJhbmdlKG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSQ29udHJvbFtdIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBGb290ZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBGb290ZXIuSGVpZ2h0RiA9IDQ0LjIwODMyRjsNCiAgICAgICAgICAgIHRoaXMuR3JvdXBGb290ZXIuTmFtZSA9ICJHcm91cEZvb3RlciI7DQogICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyLlNuYXBMaW5lUGFkZGluZyA9IG5ldyBEZXZFeHByZXNzLlh0cmFQcmludGluZy5QYWRkaW5nSW5mbygwLCAwLCAwLCAwLCAxMDBGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gUmVwb3J0Rm9vdGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuUmVwb3J0Rm9vdGVyLkNvbnRyb2xzLkFkZFJhbmdlKG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlhSQ29udHJvbFtdIHsNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0Rm9vdGVyfSk7DQogICAgICAgICAgICB0aGlzLlJlcG9ydEZvb3Rlci5IZWlnaHRGID0gNDQuMjA4MzJGOw0KICAgICAgICAgICAgdGhpcy5SZXBvcnRGb290ZXIuTmFtZSA9ICJSZXBvcnRGb290ZXIiOw0KICAgICAgICAgICAgdGhpcy5SZXBvcnRGb290ZXIuU25hcExpbmVQYWRkaW5nID0gbmV3IERldkV4cHJlc3MuWHRyYVByaW50aW5nLlBhZGRpbmdJbmZvKDAsIDAsIDAsIDAsIDEwMEYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBQYWdlRm9vdGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuUGFnZUZvb3Rlci5Db250cm9scy5BZGRSYW5nZShuZXcgRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5YUkNvbnRyb2xbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLnN1YlBhZ2VGb290ZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuUGFnZUZvb3Rlci5IZWlnaHRGID0gNDQuMjA4MzJGOw0KICAgICAgICAgICAgdGhpcy5QYWdlRm9vdGVyLk5hbWUgPSAiUGFnZUZvb3RlciI7DQogICAgICAgICAgICB0aGlzLlBhZ2VGb290ZXIuU25hcExpbmVQYWRkaW5nID0gbmV3IERldkV4cHJlc3MuWHRyYVByaW50aW5nLlBhZGRpbmdJbmZvKDAsIDAsIDAsIDAsIDEwMEYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBzdWJEZXRhaWwNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5zdWJEZXRhaWwuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViRGV0YWlsLk5hbWUgPSAic3ViRGV0YWlsIjsNCiAgICAgICAgICAgIHRoaXMuc3ViRGV0YWlsLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgNDQuMjA4MzJGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViUmVwb3J0SGVhZGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0SGVhZGVyLkxvY2F0aW9uRmxvYXQgPSBuZXcgRGV2RXhwcmVzcy5VdGlscy5Qb2ludEZsb2F0KDkuNTM2NzQzRS0wNUYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0SGVhZGVyLk5hbWUgPSAic3ViUmVwb3J0SGVhZGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0SGVhZGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk4RiwgMjMuOTU4MzNGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViUGFnZUhlYWRlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VIZWFkZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDIzLjk1ODMzRik7DQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VIZWFkZXIuTmFtZSA9ICJzdWJQYWdlSGVhZGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViUGFnZUhlYWRlci5TaXplRiA9IG5ldyBTeXN0ZW0uRHJhd2luZy5TaXplRig4MjUuOTk5OUYsIDIwLjI0OTk3Rik7DQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIC8vIHN1Ykdyb3VwSGVhZGVyDQogICAgICAgICAgICAvLyANCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBIZWFkZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBIZWFkZXIuTmFtZSA9ICJzdWJHcm91cEhlYWRlciI7DQogICAgICAgICAgICB0aGlzLnN1Ykdyb3VwSGVhZGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgNDQuMjA4MzJGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViR3JvdXBGb290ZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5zdWJHcm91cEZvb3Rlci5Mb2NhdGlvbkZsb2F0ID0gbmV3IERldkV4cHJlc3MuVXRpbHMuUG9pbnRGbG9hdCgwRiwgMEYpOw0KICAgICAgICAgICAgdGhpcy5zdWJHcm91cEZvb3Rlci5OYW1lID0gInN1Ykdyb3VwRm9vdGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViR3JvdXBGb290ZXIuU2l6ZUYgPSBuZXcgU3lzdGVtLkRyYXdpbmcuU2l6ZUYoODI1Ljk5OTlGLCA0NC4yMDgzMkYpOw0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICAvLyBzdWJSZXBvcnRGb290ZXINCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgdGhpcy5zdWJSZXBvcnRGb290ZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0Rm9vdGVyLk5hbWUgPSAic3ViUmVwb3J0Rm9vdGVyIjsNCiAgICAgICAgICAgIHRoaXMuc3ViUmVwb3J0Rm9vdGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgNDQuMjA4MzJGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gc3ViUGFnZUZvb3Rlcg0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLnN1YlBhZ2VGb290ZXIuTG9jYXRpb25GbG9hdCA9IG5ldyBEZXZFeHByZXNzLlV0aWxzLlBvaW50RmxvYXQoMEYsIDBGKTsNCiAgICAgICAgICAgIHRoaXMuc3ViUGFnZUZvb3Rlci5OYW1lID0gInN1YlBhZ2VGb290ZXIiOw0KICAgICAgICAgICAgdGhpcy5zdWJQYWdlRm9vdGVyLlNpemVGID0gbmV3IFN5c3RlbS5EcmF3aW5nLlNpemVGKDgyNS45OTk5RiwgNDQuMjA4MzJGKTsNCiAgICAgICAgICAgIC8vIA0KICAgICAgICAgICAgLy8gWHRyYVJlcG9ydA0KICAgICAgICAgICAgLy8gDQogICAgICAgICAgICB0aGlzLkJhbmRzLkFkZFJhbmdlKG5ldyBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLkJhbmRbXSB7DQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLlRvcE1hcmdpbiwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuRGV0YWlsLA0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5Cb3R0b21NYXJnaW4sDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLlJlcG9ydEhlYWRlciwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuUGFnZUhlYWRlciwNCiAgICAgICAgICAgICAgICAgICAgICAgIHRoaXMuR3JvdXBIZWFkZXIsDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLkdyb3VwRm9vdGVyLA0KICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5SZXBvcnRGb290ZXIsDQogICAgICAgICAgICAgICAgICAgICAgICB0aGlzLlBhZ2VGb290ZXJ9KTsNCiAgICAgICAgICAgIHRoaXMuTWFyZ2lucyA9IG5ldyBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5NYXJnaW5zKDEyLCAxMiwgMTIsIDEyKTsNCiAgICAgICAgICAgIHRoaXMuTmFtZSA9ICJYdHJhUmVwb3J0IjsNCiAgICAgICAgICAgIHRoaXMuUGFnZUhlaWdodCA9IDExMDA7DQogICAgICAgICAgICB0aGlzLlBhZ2VXaWR0aCA9IDg1MDsNCiAgICAgICAgICAgIHRoaXMuVmVyc2lvbiA9ICIyMC4xIjsNCiAgICAgICAgICAgICgoU3lzdGVtLkNvbXBvbmVudE1vZGVsLklTdXBwb3J0SW5pdGlhbGl6ZSkodGhpcykpLkVuZEluaXQoKTsNCiAgICAgICAgfQ0KICAgIH0NCn0NCg==";
            //XtraReport xtraReport = new XtraReport();
            //byte[] arr = Convert.FromBase64String(FileStringa);
            //Stream stream = new MemoryStream(arr);
            //xtraReport.LoadLayout(stream);

            //XRSubreport subReportFooter = xtraReport.FindControl("subPageFooter", true) as XRSubreport;
            //XRSubreport subReportFooter2 = xtraReport.FindControl("subReportHeader", true) as XRSubreport;
            //XRSubreport subReportFooter3 = xtraReport.FindControl("subPageHeader", true) as XRSubreport;
            //PageHeaderBand pageHeader = xtraReport.FindControl("PageHeader", true) as PageHeaderBand;
            //XRSubreport subReportFooter4 = xtraReport.FindControl("subGroupHeader", true) as XRSubreport;

            //DataTable DT = Common.Data.ReportCommData.DTReportSrouceInfo.Select($"no='7'").CopyToDataTable();
            //string FileString = DT.Rows[0]["fileString"].ToString();
            //byte[] arra = Convert.FromBase64String(FileString);
            //Stream streama = new MemoryStream(arra);
            ////dataSet.Namespace = "dataInfo";
            //XtraReport xtraReporta = new XtraReport();






            //xtraReporta.LoadLayout(streama);


            //subReportFooter.ReportSource = xtraReporta;
            //subReportFooter2.ReportSource = xtraReporta;

            //subReportFooter3.ReportSource = xtraReporta;
            ////subReportFooter2.Visible = false;
            ////pageHeader.Visible = false;





            //subReportFooter4.ReportSource = xtraReporta;
            //xtraReport.ShowPreview();

        }
    }
}
