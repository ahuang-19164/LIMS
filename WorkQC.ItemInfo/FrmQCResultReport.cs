using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.QCModel;
using Common.SqlModel;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using QC.QCHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCResultReport : Form
    {
        string QCReultSelect = "";
        //GridControl gridControl;
        //BandedGridView bandedGridView;
        string itemNO = "";
        string itemName = "";
        string planid = "";
        string path = "";
        string filePath = "";
        ChartControl charcontrol;
        XRPanel xrPanel;
        XRChart xrChart;

        public FrmQCResultReport()
        {
            path = Application.StartupPath + "\\Report";
            QCReultSelect = ConfigInfos.ReadConfigInfo("QCReultSelect");
            InitializeComponent();
            DEStartTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            DEEndTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void FrmQCResult_Load(object sender, EventArgs e)
        {
            GridLookUpEdites.Formats(RGEPlanGroupNO, WorkCommData.DTGroupTest);
            GridLookUpEdites.Formats(RGEPlanWorkNO, WorkCommData.DTGroupWork);
            GridLookUpEdites.Formats(RGEgradelevelNO, QCInfoData.DTQCLevel);
            GridLookUpEdites.Formats(RGEinstrumentNO, WorkCommData.DTInstrumentInfo);
            GridLookUpEdites.Formats(RGEruleNO, QCInfoData.DTRuleGroup);




            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.PlanItemView";
            GCPlanItemInfo.DataSource = ApiHelpers.postInfo(sInfo);
            GVPlanItemInfo.BestFitColumns();
        }
        private void BTRef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void BTAddQCResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVPlanItemInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                string planID = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                string planItemID = dataRow["qcItemid"] != DBNull.Value ? dataRow["qcItemid"].ToString() : "";
                string itemNO = dataRow["itemNO"] != DBNull.Value ? dataRow["itemNO"].ToString() : "";
                if (planID != "" && planItemID != "" && itemNO != "")
                {
                    FrmAddResult frmAddResult = new FrmAddResult(planID, planItemID, itemNO);
                    frmAddResult.ShowDialog();
                }
                else
                {
                    MessageBox.Show("选择信息有误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("请选择项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BTEditQCResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DataRow dataRow = bandedGridView.GetFocusedDataRow();
            //if (dataRow != null)
            //{
            //    string qcTime= dataRow["qcTime"] != DBNull.Value ? dataRow["qcTime"].ToString() : "";
            //    string itemResultsort = dataRow["itemResultsort"] != DBNull.Value ? dataRow["itemResultsort"].ToString() : "";
            //    if(itemNO!=""&& qcTime!=""&& itemResultsort!="")
            //    {

            //        FrmEditResult frmEditResult = new FrmEditResult(itemNO, qcTime, itemResultsort);
            //        frmEditResult.ShowDialog();

            //    }
            //}
        }

        private void BTDelQCResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        GridControl gridControl;


#pragma warning disable CS0414 // 字段“FrmQCResultReport.plangradeids”已被赋值，但从未使用过它的值
        string plangradeids = "";
#pragma warning restore CS0414 // 字段“FrmQCResultReport.plangradeids”已被赋值，但从未使用过它的值
        string planItemid = "";
        DataSet DSQCInfo;
        private void GVPlanItemInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {







            DataRow dataRow = GVPlanItemInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                planid = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                //gradeids = dataRow["itemNO"] != DBNull.Value ? dataRow["itemNO"].ToString() : "";
                itemNO = dataRow["itemNO"] != DBNull.Value ? dataRow["itemNO"].ToString() : "";
                itemName = dataRow["itemName"] != DBNull.Value ? dataRow["itemName"].ToString() : "";
                planItemid = dataRow["planItemid"] != DBNull.Value ? dataRow["planItemid"].ToString() : "";
                if (planid != "" && itemNO != "")
                {
                    panelControl1.Controls.Clear();
                    gridControl = new GridControl();
                    GridControls.showEmbeddedNavigator(gridControl);
                    gridControl.Name = "GCQCResult";

                    commInfoModel<QCSelectValueModel> infos = new commInfoModel<QCSelectValueModel>();
                    infos.UserName = CommonData.UserInfo.names;
                    List<QCSelectValueModel> listinfos = new List<QCSelectValueModel>();

                    QCSelectValueModel selValue = new QCSelectValueModel();
                    selValue.planid = planid;
                    selValue.planItemid = planItemid;
                    selValue.itemNO = itemNO;
                    selValue.startTime = DEStartTime.EditValue.ToString(); ;
                    selValue.endTime = DEEndTime.EditValue.ToString();
                    listinfos.Add(selValue);
                    infos.infos = listinfos;
                    string Sr = JsonHelper.SerializeObjct(infos);
                    //DSQCInfo = SqlConnServer.postDataSet(QCReultSelect, Sr);
                    WebApiCallBack jm = ApiHelpers.postInfo(QCReultSelect, Sr);
                    DSQCInfo= JsonHelper.JsonConvertObject<DataSet>(jm);
                    if (DSQCInfo!=null&&DSQCInfo.Tables.Count == 3)
                    {
                        charcontrol = QCItemResultImg.createQCResultImg(itemName, Convert.ToDateTime(DEStartTime.EditValue).ToString("yyyy.MM.dd"), Convert.ToDateTime(DEEndTime.EditValue).ToString("yyyy.MM.dd"), DSQCInfo.Tables[0], out xrChart);
                        panelControl1.Controls.Add(charcontrol);
                        charcontrol.Dock = DockStyle.Fill;
                        GCInfo.DataSource = DSQCInfo.Tables[1];

                        GCHandle.DataSource = DSQCInfo.Tables[2];
                        GVHandle.BestFitColumns();
                        bGVInfo.BestFitColumns();
                    }
                    else
                    {
                        panelControl1.Controls.Clear();
                        gridControl.DataSource = null;
                        GCInfo.DataSource = null;
                        gridControl.Dock = DockStyle.Fill;
                    }

                }
                else
                {
                    panelControl1.Controls.Clear();
                    gridControl.DataSource = null;
                    GCInfo.DataSource = null;
                    gridControl.Dock = DockStyle.Fill;
                }

            }
            else
            {
                panelControl1.Controls.Clear();
                gridControl.DataSource = null;
                GCInfo.DataSource = null;
                gridControl.Dock = DockStyle.Fill;
            }
        }

        private void GCResult_Click(object sender, EventArgs e)
        {

        }

        private void BTPrintReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                filePath = path + "\\QCReport.repx";
                if (File.Exists(filePath))
                {
                    xtraReport = new XtraReport();
                    xtraReport.LoadLayout(filePath);
                    xrPanel = (XRPanel)xtraReport.FindControl("panel", true);
                    if (charcontrol != null && DSQCInfo != null)
                    {
                        XRTableCell planName = (XRTableCell)xtraReport.FindControl("planName", true);
                        XRTableCell planstartTime = (XRTableCell)xtraReport.FindControl("planstartTime", true);
                        XRTableCell planendTime = (XRTableCell)xtraReport.FindControl("planendTime", true);
                        XRTableCell instrument = (XRTableCell)xtraReport.FindControl("instrument", true);
                        XRTableCell ruleNO = (XRTableCell)xtraReport.FindControl("ruleNO", true);
                        XRTableCell itemName = (XRTableCell)xtraReport.FindControl("itemName", true);
                        XRTableCell itemNameunit = (XRTableCell)xtraReport.FindControl("itemNameunit", true);
                        XRTableCell methodName = (XRTableCell)xtraReport.FindControl("methodName", true);
                        XRTableCell Reporter = (XRTableCell)xtraReport.FindControl("Reporter", true);
                        XRTableCell ReportTime= (XRTableCell)xtraReport.FindControl("ReportTime", true);
                        //XRTableCell Reporter = (XRTableCell)xtraReport.FindControl("Reporter", true);
                        string gradeFile = path + "\\QCGardeInfo.repx";
                        if (File.Exists(gradeFile))
                        {

                            XRSubreport subreport = (XRSubreport)xtraReport.FindControl("subreport1", true);

                            XtraReport gradeReport = new XtraReport();
                            gradeReport.LoadLayout(gradeFile);
                            gradeReport.DataSource = DSQCInfo.Tables[1];

                            subreport.ReportSource = gradeReport;

                        }
                        string handleFile = path + "\\QCHandleInfo.repx";
                        if (File.Exists(handleFile))
                        {

                            XRSubreport subreport = (XRSubreport)xtraReport.FindControl("subreport2", true);

                            XtraReport gradeReport = new XtraReport();
                            gradeReport.LoadLayout(handleFile);
                            gradeReport.DataSource = DSQCInfo.Tables[2];

                            subreport.ReportSource = gradeReport;

                        }
                        planstartTime.Text = Convert.ToDateTime(DEStartTime.EditValue).ToString("yyyy-MM-dd");
                        planendTime.Text = Convert.ToDateTime(DEEndTime.EditValue).ToString("yyyy-MM-dd");
                        planName.Text = GVPlanItemInfo.GetFocusedRowCellDisplayText("names");
                        instrument.Text = GVPlanItemInfo.GetFocusedRowCellDisplayText("instrumentNO");
                        ruleNO.Text = GVPlanItemInfo.GetFocusedRowCellDisplayText("ruleNO");
                        itemName.Text = GVPlanItemInfo.GetFocusedRowCellDisplayText("itemName");
                        itemNameunit.Text = GVPlanItemInfo.GetFocusedRowCellDisplayText("unit");
                        methodName.Text = GVPlanItemInfo.GetFocusedRowCellDisplayText("methodName");
                        Reporter.Text = CommonData.UserInfo.names;
                        ReportTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (xrPanel != null)
                        {
                            xrPanel.Controls.Add(xrChart);
                            xrChart.SizeF = new SizeF(1100, 350);
                        }
                        else
                        {
                            MessageBox.Show("未找到质控图位置", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }





                        //xtraReport.DataSource= DSQCInfo;
                        xtraReport.ShowPreview();

                        //xrPic = (XRPictureBox)xtraReport.FindControl("QCImg", true);
                        //MemoryStream ms = new MemoryStream();
                        //charcontrol.ExportToImage(ms, ImageFormat.Png);
                        //Bitmap bmp = new Bitmap(ms);
                        //xrPic.Image = bmp;
                        //xtraReport.ShowPreview();
                        //ShowImgHelper.ViewOrignalImage(bmp);
                    }
                    else
                    {
                        MessageBox.Show("没有选择可打印数据", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"没有找到可使用的质控模板。\r\n请检查{filePath}文件是否存在", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取质控报告模板有误，请检查模板是否正确。\r\r{ex.ToString()}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        XtraReport xtraReport;
        private void BTEditReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DSQCInfo != null && DSQCInfo.Tables.Count > 1)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(filePath))
                {
                    xtraReport = new XtraReport();
                    xtraReport.LoadLayout(filePath);


                    //DataSet dataSet = new DataSet();
                    //DataTable dataTable = (GCInfo.DataSource as DataTable).Copy();
                    //dataSet.Tables.Add(dataTable);
                    //xtraReport.DataSource = DSQCInfo;
                    EditRepor(xtraReport, null);

                }
                else
                {
                    CreatNewRepor(null);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        XRDesignFormEx designForm;
        public void CreatNewRepor(DataTable dataTable)
        {
            designForm = new XRDesignFormEx();
            xtraReport = new XtraReport();
            //DataSet dataSet = new DataSet();
            //DataTable dataTable = (GCInfo.DataSource as DataTable).Copy();
            //dataSet.Tables.Add(dataTable);



            xtraReport.DataSource = dataTable;
            //隐藏按钮  这段
            designForm.DesignPanel.SetCommandVisibility(new ReportCommand[]{
                            //ReportCommand.NewReport,
                            ReportCommand.SaveFile,
                            ReportCommand.SaveFileAs,
                            ReportCommand.SaveAll,
                            ReportCommand.NewReportWizard,
                            ReportCommand.OpenFile,
                            //ReportCommand.Paste

                        }, DevExpress.XtraReports.UserDesigner.CommandVisibility.Verb);
            designForm.FormClosing += DesignForm_FormClosing;
            designForm.ReportStateChanged += DesignForm_ReportStateChanged;
            // 加载报表. 
            designForm.OpenReport(xtraReport);
            // 打开设计器
            designForm.ShowDialog();
            designForm.Dispose();
        }
        public void EditRepor(XtraReport xtraReport, DataTable dataTable)
        {
            designForm = new XRDesignFormEx();
            //xtraReport = new XtraReport();
            xtraReport.DataSource = dataTable;


            //隐藏按钮  这段
            designForm.DesignPanel.SetCommandVisibility(new ReportCommand[]{
                            //ReportCommand.NewReport,
                            ReportCommand.SaveFile,
                            ReportCommand.SaveFileAs,
                            ReportCommand.SaveAll,
                            ReportCommand.NewReportWizard,
                            ReportCommand.OpenFile,
                            //ReportCommand.Paste

                        }, DevExpress.XtraReports.UserDesigner.CommandVisibility.Verb);
            designForm.FormClosing += DesignForm_FormClosing;
            designForm.ReportStateChanged += DesignForm_ReportStateChanged;
            // 加载报表. 
            designForm.OpenReport(xtraReport);
            // 打开设计器
            designForm.ShowDialog();
            designForm.Dispose();
        }
        private void DesignForm_ReportStateChanged(object sender, ReportStateEventArgs e)
        {
            //只要报表发生改变就立即将状态设置为保存
            //避免系统默认保存对话框的出现
            if (e.ReportState == ReportState.Changed)
            {
                ((XRDesignFormEx)sender).DesignPanel.ReportState = ReportState.Saved;
            }
        }

        private void DesignForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否保存当前内容", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                xtraReport.SaveLayout(filePath);
                xrPanel = (XRPanel)xtraReport.FindControl("panel", true);
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            filePath = path + "\\QCReport.repx";
            if (DSQCInfo != null && DSQCInfo.Tables.Count > 1)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(filePath))
                {
                    xtraReport = new XtraReport();
                    xtraReport.LoadLayout(filePath);
                    EditRepor(xtraReport, null);

                }
                else
                {
                    CreatNewRepor(null);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void BTGarde_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            filePath = path + "\\QCGardeInfo.repx";
            if (DSQCInfo != null && DSQCInfo.Tables.Count > 1)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(filePath))
                {
                    xtraReport = new XtraReport();
                    xtraReport.LoadLayout(filePath);
                    EditRepor(xtraReport, DSQCInfo.Tables[1]);

                }
                else
                {
                    CreatNewRepor(DSQCInfo.Tables[1]);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void BThandle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            filePath = path + "\\QCHandleInfo.repx";
            //string gradeFile = path + "\\QCGardeInfo.repx";
            if (DSQCInfo != null && DSQCInfo.Tables.Count > 1)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(filePath))
                {
                    xtraReport = new XtraReport();
                    xtraReport.LoadLayout(filePath);
                    EditRepor(xtraReport, DSQCInfo.Tables[2]);

                }
                else
                {
                    CreatNewRepor(DSQCInfo.Tables[2]);
                }
            }
            else
            {
                MessageBox.Show("请先选择一个项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
