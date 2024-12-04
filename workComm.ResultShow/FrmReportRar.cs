using Common.BLL;
using Common.Conn;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.ReportModel;
using Common.SqlModel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workComm.ResultShow
{
    public partial class FrmReportRar : XtraForm
    {

        //string GetReport = "";
        public FrmReportRar()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            GridControls.formartGridView(GVSampleInfo);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("no", typeof(int));
            dataTable.Columns.Add("names", typeof(string));
            dataTable.Rows.Add(1, "未打印");
            dataTable.Rows.Add(2, "已打印");
            dataTable.Rows.Add(0, "全部");


            GEState.Properties.DataSource = dataTable;
            GEState.Properties.ValueMember = "no";
            GEState.Properties.DisplayMember = "names";

            GEState.EditValue = 1;

            //ApiHelpers.ReportDown = ConfigInfos.ReadConfigInfo("ReportDown");
            DEStartTime.EditValue = DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd"); getPrintInfo();
        }
        /// <summary>
        /// 获取打印机信息
        /// </summary>
        public void getPrintInfo()
        {
            try
            {


                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    CBPrint.Properties.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CBPrint.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CBPrint.EditValue = null;
            }

        }

        private void BTselect_Click(object sender, EventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkTest.SampleInfo";
            sInfo.wheres = $"testStateNO=6 and reportState=1 and dstate=0 and createTime>='{Convert.ToDateTime(DEStartTime.EditValue).ToString("yyyy-MM-dd")}' and createTime<='{Convert.ToDateTime(DEEndTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}'";
            string PatientNames = TEPatientNamre.EditValue != null && TEPatientNamre.EditValue.ToString().Trim() != "" ? TEPatientNamre.EditValue.ToString() : "";
            //string hosBarcodes = TEHosBarcode.EditValue != null && TEHosBarcode.EditValue.ToString().Trim() != "" ? TEHosBarcode.EditValue.ToString() : "";
            string hosBarcodes = TEHosBarcode.EditValue != null && TEHosBarcode.EditValue.ToString().Trim() != "" ? TEHosBarcode.EditValue.ToString() : "";
            string barcodes = TEBarcode.EditValue != null && TEBarcode.EditValue.ToString().Trim() != "" ? TEBarcode.EditValue.ToString() : "";
            if (PatientNames != "")
            {
                sInfo.wheres += $" and patientName like '%{PatientNames}%'";
            }
            if (hosBarcodes != "")
            {
                sInfo.wheres += $" and hospitalBarcode like '%{hosBarcodes}%'";
            }
            if (barcodes != "")
            {
                sInfo.wheres += $" and barcode like '%{barcodes}%'";
            }
            sInfo.wheres += $"  order by barcode,createTime";
            DataTable aaa = ApiHelpers.postInfo(sInfo);
            if (aaa != null)
            {
                aaa.Columns.Add("check", typeof(bool));
            }
            GCSampleInfo.DataSource = aaa;
            GVSampleInfo.BestFitColumns();
        }

        private void CECheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CECheckAll.Checked)
            {
                for (int i = 0; i < GVSampleInfo.RowCount; i++)
                {
                    GVSampleInfo.SetRowCellValue(i, "check", true);
                }
            }
            else
            {
                for (int i = 0; i < GVSampleInfo.RowCount; i++)
                {
                    GVSampleInfo.SetRowCellValue(i, "check", false);
                }
            }
        }
        FrmWait frmWait;
        private void BTReport_Click(object sender, EventArgs e)
        {
            frmWait = new FrmWait();
            frmWait.ShowMe(this,"系统提示", "正在努力下载报告中，请稍等......");
            GVSampleInfo.FocusedRowHandle = -1;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += backgroundWorker_DoWork;
            worker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            worker.RunWorkerAsync();
            BTReport.Enabled = false;
        }

        private void GVSampleInfo_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                List<int> infoIDs = new List<int>();
                int infoID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                infoIDs.Add(infoID);


                //foreach (DataRow dataRow in dataTable.Rows)
                //{
                //    bool rowState = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                //    if (rowState)
                //    {
                //        int infoID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                //        infoIDs.Add(infoID);
                //    }
                //}
                if (infoIDs.Count > 0)
                {
                    GetReportModel reportModel = new GetReportModel();
                    reportModel.reportType = 1;
                    reportModel.infoID = infoIDs;
                    bool s = ApiHelpers.GetReportRar(reportModel);
                    if (s == true)
                    {
                        FrmShow frmReportShow = new FrmShow();
                        frmReportShow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("未找到对应的报告单，请联系系统管理员。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        bool downReporState = false;


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dataTable = GCSampleInfo.DataSource as DataTable;
            if (dataTable != null)
            {

                List<int> infoIDs = new List<int>();



                foreach (DataRow dataRow in dataTable.Rows)
                {
                    bool rowState = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (rowState)
                    {
                        int infoID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        infoIDs.Add(infoID);
                    }
                }
                if (infoIDs.Count > 0)
                {
                    GetReportModel reportModel = new GetReportModel();
                    reportModel.UserName = CommonData.UserInfo.names;
                    reportModel.reportType = 0;
                    reportModel.infoID = infoIDs;
                    string sr = JsonHelper.SerializeObjct(reportModel);
                    downReporState = ApiHelpers.GetReportRar(reportModel);

                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmWait.HideMe(this);
            if (downReporState == true)
            {
                FrmShow frmReportShow = new FrmShow();
                frmReportShow.ShowDialog();
                BTReport.Enabled = true;
            }
            else
            {
                MessageBox.Show("未找到对应的报告单，请联系系统管理员。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTReport.Enabled = true;
            }
        }

        private void BTPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
