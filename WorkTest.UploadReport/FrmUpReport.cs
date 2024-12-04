using Common.BLL;
using Common.Conn;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.ReportModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WorkTest.UploadReport
{
    public partial class FrmUpReport : XtraForm
    {
        int perid = 0;
        int testid = 0;
        string barcode = "";
        string hospitalNo = "";
        string ReprotName = "";
        string ReportUpFile = "";
        string testState = "";

        public FrmUpReport()
        {
            InitializeComponent();
            pdfViewer1.ShowFindDialog();
            pdfViewer1.NavigationPaneVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Visible;
            pdfViewer1.NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Visible;
            ReportUpFile = ConfigInfos.ReadConfigInfo("ReportUpFile");

        }
        public FrmUpReport(int Sampleperid, int Sampletestid, string Samplebarcode, string SamplehospitalNo,string testStateNO)
        {

            InitializeComponent();
            //layoutControlItem1.Visible = false;


            TEFilePath.Properties.AllowFocused = false;

            BTSelectFile.Enabled = false;
            BTUpLoad.Enabled = false;
            BTClear.Enabled = false;
            BTSelectFile.Visible = false;
            BTUpLoad.Visible = false;
            BTClear.Visible = false;

            pdfViewer1.ShowFindDialog();
            pdfViewer1.NavigationPaneVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Visible;
            pdfViewer1.NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Visible;
            ReportUpFile = ConfigInfos.ReadConfigInfo("ReportUpFile");


            TEFilePath.EditValue = null;
            pdfViewer1.CloseDocument();

            perid = Sampleperid;
            testid = Sampletestid;
            barcode = Samplebarcode;
            hospitalNo = SamplehospitalNo;
            testState = testStateNO;
            TEFilePath.EditValue = null;
            List<int> infoIDs = new List<int>();
            //int infoID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
            infoIDs.Add(Sampletestid);


            if (infoIDs.Count > 0)
            {
                GetReportModel reportModel = new GetReportModel();
                reportModel.UserName = CommonData.UserInfo.names;
                reportModel.infoID = infoIDs;
                bool s = ApiHelpers.PostDownReportFile(reportModel,out string filepath);
                if (s == true)
                {
                    //string dirfileName = Application.StartupPath + "\\TempReport";
                    //string[] fileName = Directory.GetFiles(dirfileName);
                    //string fileFullPath = fileName[0];
                    pdfViewer1.LoadDocument(filepath);
                }
                else
                {
                    pdfViewer1.CloseDocument();
                }
            }
        }

        public void showReport(int Sampleperid, int Sampletestid, string Samplebarcode, string SamplehospitalNo, string testStateNO)
        {
            TEFilePath.EditValue = null;
            pdfViewer1.CloseDocument();

            perid = Sampleperid;
            testid = Sampletestid;
            barcode = Samplebarcode;
            hospitalNo = SamplehospitalNo;
            testState = testStateNO;
            TEFilePath.EditValue = null;
            List<int> infoIDs = new List<int>();
            //int infoID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
            infoIDs.Add(Sampletestid);


            if (infoIDs.Count > 0)
            {
                GetReportModel reportModel = new GetReportModel();
                reportModel.UserName = CommonData.UserInfo.names;
                reportModel.infoID = infoIDs;
                bool s = ApiHelpers.PostDownReportFile(reportModel,out string filepath);
                //bool s = ApiHelpers.PostDownReportStream(reportModel,out Stream filestream);
                if (s == true)
                {
                    ////string dirfileName = Application.StartupPath + "\\TempReport";
                    ////string[] fileName = Directory.GetFiles(dirfileName);
                    ////string fileFullPath = fileName[0];
                    pdfViewer1.LoadDocument(filepath);
                    //pdfViewer1.LoadDocument(filestream);
                }
                else
                {
                    pdfViewer1.CloseDocument();
                }
            }
        }

        private void BTSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
                openFileDialog.InitialDirectory = "C:\\Users\\huang\\Desktop\\";
                //openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
                openFileDialog.Filter = "Text|*.pdf;*.PDF";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    TEFilePath.EditValue= openFileDialog.FileName;
                    if(TEFilePath.EditValue!=null&& TEFilePath.EditValue.ToString().Trim().Length>0)
                    {
                        pdfViewer1.LoadDocument(TEFilePath.EditValue.ToString());
                    }
                    
                }
            }
        }
        private void BTUpLoad_Click(object sender, EventArgs e)
        {
            if(testState=="3"||testState== "6")
            {
                MessageBox.Show("样本已审核不能再次上传报告", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (TEFilePath.EditValue != null && TEFilePath.EditValue.ToString().Trim().Length > 0)
                {
                    string fileString = FileConverHelpers.FileTostring(TEFilePath.EditValue.ToString());
                    UpLoadReportModel upLoadReport = new UpLoadReportModel();
                    upLoadReport.userName = CommonData.UserInfo.names;

                    upLoadReport.upState = 0;
                    upLoadReport.perid = perid;
                    upLoadReport.testid = testid;
                    upLoadReport.barcode = barcode;
                    upLoadReport.hospitalNo = hospitalNo;
                    //upLoadReport.FileName = CommonData.UserInfo.names;
                    upLoadReport.FileString = fileString;

                    string sr = JsonHelper.SerializeObjct(upLoadReport);
                    WebApiCallBack jm = ApiHelpers.postInfo(ReportUpFile, sr);
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //commReInfo<commReSampleInfo> CheckCodeModelModel = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                    //if (CheckCodeModelModel.code == 1)
                    //{
                    //    MessageBox.Show(CheckCodeModelModel.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show(CheckCodeModelModel.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}


                }
                else
                {
                    MessageBox.Show("请选择需要上传的PDF报告", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }






        }
        private void BTClear_Click(object sender, EventArgs e)
        {

            UpLoadReportModel upLoadReport = new UpLoadReportModel();
            upLoadReport.userName = CommonData.UserInfo.names;
            
            upLoadReport.upState = 1;
            upLoadReport.perid = perid;
            upLoadReport.testid = testid;
            upLoadReport.barcode = barcode;
            upLoadReport.hospitalNo = hospitalNo;
            //upLoadReport.FileName = CommonData.UserInfo.names;
            //upLoadReport.FileString = fileString;

            string sr = JsonHelper.SerializeObjct(upLoadReport);
            WebApiCallBack jm = ApiHelpers.postInfo(ReportUpFile, sr);
            MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //commReInfo<commReSampleInfo> CheckCodeModelModel = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
            //if(CheckCodeModelModel.code==1)
            //{
            //    TEFilePath.EditValue = null;
            //    pdfViewer1.CloseDocument();
            //    MessageBox.Show(CheckCodeModelModel.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show(CheckCodeModelModel.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


        }

        private void FrmUpReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            pdfViewer1.CloseDocument();
            pdfViewer1.Dispose();
        }
    }
}
