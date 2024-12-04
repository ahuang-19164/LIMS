﻿using AForge.Video.DirectShow;
using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.HotKey;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WorkTest.TestPathology
{
    public partial class FrmTestSampling : DevExpress.XtraEditors.XtraForm
    {
        string SetResultPathology = "";
        public static PictureEdit Picture { get; set; }
        public static SuperPictureEdit SuperPicture { get; set; }

        //public static string FileSampleImgPath = Environment.CurrentDirectory + "\\SaveSampleImg";
        public static string FileImgPath = Environment.CurrentDirectory + "\\SaveTestSamplingImg";

        private string path = "";



        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        public FrmTestSampling()
        {
            path = Application.StartupPath + "\\Report";
            InitializeComponent();
            //CommonData.configInfos.TryGetValue("SetResultPathology", out string ResultPathology);
            SetResultPathology = ConfigInfos.ReadConfigInfo("SetResultPathology");





        }


        private void FrmPathologyTest_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //videoSource = new VideoCaptureDevice(videoDevices[tscbxCameras.SelectedIndex].MonikerString);
            GridControls.showEmbeddedNavigator(GCBlockInfo);
            MemoEdits.AddDoubleMethod(TEEyeVisible);
            GridLookUpEdites.Formats(GEoperater, DTHelper.DTEnable(CommonData.DTUserInfoAll));



            getPrintInfo();

        }

        public void getPrintInfo()
        {
            try
            {
                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    CEPrintInfo.Properties.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CEPrintInfo.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CEPrintInfo.EditValue = null;
            }
        }


        /// <summary>
        /// 采集图片
        /// </summary>
        public Image CameraImage { get; set; }
        ImageList imageList = new ImageList();
        int pictureEditLocationxs = 0;
        private void BTTakePicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            CameraImage = this.cameraControl1.TakeSnapshot();
            if (CameraImage != null)
            {
                Bitmap bitmap = new Bitmap(CameraImage);
                // NewCombobox();
                NewPictureEdit("取材采图", null, "1", bitmap);
            }
            else
            {
                MessageBox.Show("没有拍摄到图片，请检查摄像头链接是否正常。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void BTUpPicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string FilePath = OpenFileHelpers.GetFilePath(FileExtensionName.img);
                if (FilePath.Length != 0)
                {
                    Bitmap bitmap = new Bitmap(FilePath);
                    Bitmap bitmaps = new Bitmap(bitmap);
                    NewPictureEdit("取材采图", null, "1", bitmap);
                    bitmap.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 新建SuperPictureEdit
        /// </summary>
        /// <param name="PictureName">图片名称</param>
        /// <param name="pictureDye">染色倍数</param>
        /// <param name="bitmap">图像</param>
        private void NewPictureEdit(string className, string PictureDye, string classNO, Bitmap bitmap)
        {
            try
            {

                if (bitmap != null)
                {
                    int a = xtraScrollableControl.Controls.Count + 1;
                    SuperPicture = new SuperPictureEdit();
                    SuperPicture.Location = new System.Drawing.Point(pictureEditLocationxs, 0);
                    SuperPicture.Size = new Size(220, 220);
                    SuperPicture.bitmap = bitmap;
                    SuperPicture.pictureType = classNO;
                    SuperPicture.labstring = className;
                    //superPicture.labstring = PictureName + a.ToString();
                    if (PictureDye != null)
                    {
                        SuperPicture.combostring = PictureDye;
                    }
                    xtraScrollableControl.Controls.Add(SuperPicture);
                    pictureEditLocationxs += 220;

                }
            }
            catch
            {
                MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PictureEdit_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.pictureEdit1.Properties.ZoomPercent += 5;
            }
            else if (e.Delta < 0)
            {
                this.pictureEdit1.Properties.ZoomPercent -= 5;
            }
        }



        private void BTDeletePicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraScrollableControl.Controls.Contains(SuperPicture))
            {
                DialogResult dialogResult = MessageBox.Show("是否确定删除此照片？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    xtraScrollableControl.Controls.Remove(SuperPicture);
                    int xx = 0;
                    foreach (Control control in xtraScrollableControl.Controls)
                    {
                        control.Location = new System.Drawing.Point(xx, 0);
                        xx += 255;
                    }
                    if (pictureEditLocationxs > 0)
                    {
                        pictureEditLocationxs -= 220;
                    }
                }
            }


        }

        private void BTScreenCapture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewPictureEdit("阅片采图", null, "2", GetScreenCapture());
        }
        private Bitmap GetScreenCapture()
        {
            Rectangle tScreenRect = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Bitmap tSrcBmp = new Bitmap(tScreenRect.Width, tScreenRect.Height); // 用于屏幕原始图片保存
            Graphics gp = Graphics.FromImage(tSrcBmp);
            gp.CopyFromScreen(0, 0, 0, 0, tScreenRect.Size);
            gp.DrawImage(tSrcBmp, 0, 0, tScreenRect, GraphicsUnit.Pixel);
            return tSrcBmp;

        }
        private void BTEditPicture_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Picture != null)
            {
                Picture.ShowImageEditorDialog();
            }

        }

        //public void getPictureEdit(object a,EventArgs e)
        //{
        //    pictureEdits = a as PictureEdit;
        //}
        private void BTSetCamera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                videoSource.DisplayPropertyPage(IntPtr.Zero); //这将显示带有摄像头控件的窗体
                ////建立新的系统进程 

                //System.Diagnostics.Process process = new System.Diagnostics.Process();

                ////设置文件名，此处为图片的真实路径+文件名 

                ////process.StartInfo.FileName = picName;

                ////此为关键部分。设置进程运行参数，此时为最大化窗口显示图片。 

                //process.StartInfo.Arguments = "rundll32.exe C:\\WINDOWS\\system32\\shimgvw.dll,ImageView_Fullscreen";

                ////此项为是否使用Shell执行程序，因系统默认为true，此项也可不设，但若设置必须为true 

                //process.StartInfo.UseShellExecute = true;

                ////此处可以更改进程所打开窗体的显示样式，可以不设 

                //process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                //process.Start();

                //process.Close();
            }
            catch
            {
                MessageBox.Show("未找到可用的配置信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        //SuperPictureEdit
        private void xtraScrollableControl_Click(object sender, EventArgs e)
        {
            SuperPictureEdit superPicture = sender as SuperPictureEdit;
        }

        //string PathonlogyNO = "";
        DataRow DRSampleInfo;
        List<BlockInfoModel> ListBlock = null;
        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {
            ListBlock = new List<BlockInfoModel>();
            DRSampleInfo = SampleInfo;
            //if(DRsampleInfo!=null)
            //{
            //    PathonlogyNO = DRsampleInfo["pathologyNo"] !=DBNull.Value? DRsampleInfo["pathologyNo"].ToString():"";
            //}

            xtraScrollableControl.Controls.Clear();
            pictureEditLocationxs = 0;
            Task<DataTable> ResultTask = new Task<DataTable>(() =>
            {
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkTest.ResultPathology";
                selectInfo.wheres = $"testid='{testid}' and state=1";
                selectInfo.OrderColumns = "createTime desc";
                //DataTable DTResult = ApiHelpers.postInfo(selectInfo);
                return ApiHelpers.postInfo(selectInfo);
            });
            ResultTask.Start();
            Task<DataTable> ImgListTask = new Task<DataTable>(() =>
            {
                sInfo selectPicture = new sInfo();
                selectPicture.values = "id,testid,barcode,pictureDye,pictureNames,classNo,className,filestring";
                selectPicture.TableName = "WorkTest.ResultPathologyImg";
                selectPicture.wheres = $"testid='{testid}' and state=1";
                selectPicture.OrderColumns = "classNo,sort";
                //DataTable DTPicture = ApiHelpers.postInfo(selectPicture);
                return ApiHelpers.postInfo(selectPicture);
            });
            ImgListTask.Start();
            DataTable imgDT = ImgListTask.Result;

            if (ResultTask.Result != null)
            {
                //MEDescriptionLesions.EditValue = ResultTask.Result.Rows[0]["descriptionLesions"] != DBNull.Value ? ResultTask.Result.Rows[0]["descriptionLesions"] : "";
                //MEDiagnosisRemark.EditValue = ResultTask.Result.Rows[0]["diagnosisRemark"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosisRemark"] : "";
                //MEpathologicDiagnosis.EditValue = ResultTask.Result.Rows[0]["diagnosis"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosis"] : "";

                TEEyeVisible.EditValue = ResultTask.Result.Rows[0]["eyeVisible"] != DBNull.Value ? ResultTask.Result.Rows[0]["eyeVisible"] : "";
                sInfo selectPicture = new sInfo();
                //selectPicture.values = "id,testid,barcode,pictureDye,pictureNames,classNo,className,filestring";
                selectPicture.TableName = "WorkTest.ResultPathologyBlock";
                selectPicture.wheres = $"testid='{testid}' and dstate=0";
                selectPicture.OrderColumns = "blockNo";
                //DataTable DTPicture = ApiHelpers.postInfo(selectPicture);
                DataTable DTBlock = ApiHelpers.postInfo(selectPicture);

                if (DTBlock != null)
                    ListBlock = JsonHelper.DtConvertToModel<BlockInfoModel>(DTBlock);
                GCBlockInfo.DataSource = ListBlock;

                GCBlockInfo.RefreshDataSource();
            }
            else
            {
                //MEDescriptionLesions.EditValue = "";
                //MEDiagnosisRemark.EditValue = "";
                TEEyeVisible.EditValue = "";
                //MEpathologicDiagnosis.EditValue = "";
                GCBlockInfo.DataSource = ListBlock;
                GCBlockInfo.RefreshDataSource();
            }
            if (imgDT != null)
            {
                if (!Directory.Exists(FileImgPath))
                {
                    Directory.CreateDirectory(FileImgPath);
                }
                for (int i = 0; i < imgDT.Rows.Count; i++)
                {
                    Bitmap bitmap;
                    string pictureType = imgDT.Rows[i]["classNo"] != DBNull.Value ? imgDT.Rows[i]["classNo"].ToString() : "";
                    string filestring = imgDT.Rows[i]["filestring"] != DBNull.Value ? imgDT.Rows[i]["filestring"].ToString() : "";
                    bitmap = FileConverHelpers.StringToBitmap(filestring);
                    NewPictureEdit(imgDT.Rows[i]["className"].ToString(), imgDT.Rows[i]["pictureDye"].ToString(), pictureType, bitmap);
                }
            }


        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者</param>
        /// <returns></returns>
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {
            if (TEEyeVisible.EditValue != null && TEEyeVisible.EditValue.ToString().Trim() != "")
            {
                Task<string> task = new Task<string>(() =>
                {
                    if (ListBlock != null && ListBlock.Count > 0)
                    {
                        if (testid != 0 && barcode != "")
                        {
                            CommResultModel<PathnologyInfoModel> pathnologyInfo = new CommResultModel<PathnologyInfoModel>();
                            pathnologyInfo.UserName = CommonData.UserInfo.names;
                            
                            pathnologyInfo.testFlowNO = flowNO;
                            if (info != null)
                            {
                                pathnologyInfo.AutographInfo = info;
                            }
                            PathnologyInfoModel pathnology = new PathnologyInfoModel();


                            pathnologyInfo.ResultState = ResultState;
                            pathnology.State = true;
                            pathnology.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            pathnology.Barcode = barcode;
                            pathnology.PictureCode = barcode;
                            pathnology.groupNO = groupNO;
                            //pathnology.PathologyNo = PNO;
                            pathnology.perid = perid;
                            pathnology.testid = testid; pathnology.sampleID = sampleid;
                            if (TEEyeVisible.EditValue != null)
                                pathnology.EyeVisible = TEEyeVisible.EditValue.ToString();
                            //if (MEDescriptionLesions.EditValue != null)
                            //    pathnology.DescriptionLesions = MEDescriptionLesions.EditValue.ToString();
                            //if (MEpathologicDiagnosis.EditValue != null)
                            //    pathnology.pathologicDiagnosis = MEpathologicDiagnosis.EditValue.ToString();
                            //if (MEDiagnosisRemark.EditValue != null)
                            //    pathnology.diagnosisRemark = MEDiagnosisRemark.EditValue.ToString();


                            List<PictureInfoModel> results = new List<PictureInfoModel>();
                            int a = 0;
                            foreach (Control control in xtraScrollableControl.Controls)
                            {
                                PictureInfoModel resultPictureInfo = new PictureInfoModel();
                                a = a + 1;
                                resultPictureInfo.Barcode = barcode;
                                resultPictureInfo.testid = testid;
                                //resultPictureInfo.pathologyNo = PNO;
                                resultPictureInfo.ClassNo = "1";
                                resultPictureInfo.Sort = a;
                                if (control is SuperPictureEdit)
                                {
                                    if (!Directory.Exists(FileImgPath))
                                    {
                                        Directory.CreateDirectory(FileImgPath);
                                    }
                                    string FileSavePath = FileImgPath + "\\" + barcode + "-" + a.ToString() + ".png";
                                    resultPictureInfo.PictureNames = barcode + "-" + a.ToString() + ".png";
                                    foreach (Control item in control.Controls)
                                    {
                                        if (item is PictureEdit)
                                        {
                                            PictureEdit asa = item as PictureEdit;
                                            Bitmap bitmap = new Bitmap(asa.Image);
                                            if (File.Exists(FileSavePath))
                                            {
                                                File.Delete(FileSavePath);
                                            }
                                            Bitmap bitmaps = ImageCompressHelper.SizeImage(bitmap);
                                            bitmaps.Save(FileSavePath, ImageFormat.Png);
                                            string ssss = FileConverHelpers.BitmapTostring(bitmaps);
                                            resultPictureInfo.filestring = ssss;
                                            bitmaps.Dispose();
                                        }
                                        if (item is ComboBoxEdit)
                                        {
                                            if (item.Visible)
                                            {
                                                resultPictureInfo.ClassNo = "2";
                                                ComboBoxEdit cccc = item as ComboBoxEdit;
                                                resultPictureInfo.PictureDye = cccc.EditValue.ToString();
                                            }
                                            else
                                            {
                                                resultPictureInfo.ClassNo = "1";
                                            }
                                        }
                                        if (item is LabelControl)
                                        {
                                            LabelControl lll = item as LabelControl;
                                            resultPictureInfo.ClassName = lll.Text;
                                        }

                                    }


                                }
                                results.Add(resultPictureInfo);

                            }
                            pathnology.ListPicture = results;
                            pathnology.ListBlock = ListBlock;
                            pathnologyInfo.Result = pathnology;
                            string s = JsonHelper.SerializeObjct(pathnologyInfo);
                            WebApiCallBack jm = ApiHelpers.postInfo(SetResultPathology, s);
                            return jm.data.ToString();
                        }
                        else
                        {
                            return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息\"}";
                            //MessageBox.Show("请选择需要保存信息的标本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"蜡块信息不能为空，请添加蜡块信息。\"}";
                    }
                });
                task.Start();
                return task.Result;
            }
            else
            {
                return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"肉眼可见不能为空。\"}";
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
                        BTTakePicture_ItemClick(null, null);
                    }
                    if (values == "2")
                    {
                        BTDeletePicture_ItemClick(null, null);
                    }
                }
            }
            catch
            {

            }

        }


        #region hotKeys



        private void FrmTestPathology_Activated(object sender, EventArgs e)
        {
            HotKeys.RegisterHotKey(Handle, 110, 0, Keys.F1);
            HotKeys.RegisterHotKey(Handle, 111, 0, Keys.F2);
        }
        private void FrmPathologyTest_FormClosed(object sender, FormClosedEventArgs e)
        {

            cameraControl1.Dispose();
            HotKeys.UnregisterHotKey(Handle, 110);
            HotKeys.UnregisterHotKey(Handle, 111);
        }
        private void FrmTestPathology_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraControl1.Dispose();
            HotKeys.UnregisterHotKey(Handle, 110);
            HotKeys.UnregisterHotKey(Handle, 111);
        }
        #endregion hotKeys

        private void BTAddBlack_Click(object sender, EventArgs e)
        {
            if (DRSampleInfo != null)
            {
                if (GEoperater.EditValue != null && GEoperater.EditValue.ToString() != "")
                {
                    int a = 0;
                    if (ListBlock != null)
                    {
                        a = ListBlock.Count + 1;
                    }
                    else
                    {
                        a = 1;
                    }


                    BlockInfoModel blockInfo = new BlockInfoModel();
                    //BlockInfoModel blockInfo = new BlockInfoModel();
                    blockInfo.perid = DRSampleInfo["perid"] != DBNull.Value ? Convert.ToInt32(DRSampleInfo["perid"]) : 0;
                    blockInfo.testid = DRSampleInfo["id"] != DBNull.Value ? Convert.ToInt32(DRSampleInfo["id"]) : 0;
                    blockInfo.barcode = DRSampleInfo["barcode"] != DBNull.Value ? DRSampleInfo["barcode"].ToString() : "";
                    blockInfo.pathologyNo = DRSampleInfo["pathologyNo"] != DBNull.Value ? DRSampleInfo["pathologyNo"].ToString() : "";
                    blockInfo.blockNo = blockInfo.pathologyNo + "-" + a;
                    blockInfo.operatTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                    blockInfo.operater = GEoperater.Text;
                    blockInfo.recorder = CommonData.UserInfo.names;
                    ListBlock.Add(blockInfo);
                    GCBlockInfo.DataSource = ListBlock;
                    GCBlockInfo.RefreshDataSource();
                }
                else
                {
                    MessageBox.Show("请先选择取材师生。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void BTDeleteBlack_Click(object sender, EventArgs e)
        {
            //BlockInfo blockInfo = CVBlockInfo.GetFocusedRow() as BlockInfo;
            BlockInfoModel blockInfo = CVBlockInfo.GetFocusedRow() as BlockInfoModel;
            if (blockInfo != null)
            {
                //if(blockInfo.state)
                //{
                //    DialogResult dialogResult = MessageBox.Show("确定要删除蜡块记录吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //    if(dialogResult==DialogResult.Yes)
                //    {
                //        //dInfo dInfo = new dInfo();
                //        //dInfo.TableName = "WorkTest.ResultPathologyBlock";
                //        //dInfo.DataValueID = blockInfo.id;
                //        //ApiHelpers.postInfo(dInfo);
                //        ListBlock.Remove(blockInfo);
                //        GCBlockInfo.DataSource = ListBlock;
                //    }
                //}
                //else
                //{
                //    ListBlock.Remove(blockInfo);
                //    GCBlockInfo.DataSource = ListBlock;
                //}
                ListBlock.Remove(blockInfo);
                int nos = 0;
                foreach (BlockInfoModel block in ListBlock)
                {
                    nos += 1;
                    block.blockNo = block.pathologyNo + "-" + nos;
                }
                GCBlockInfo.DataSource = ListBlock;
                GCBlockInfo.RefreshDataSource();
            }
        }



        #region 修改切片报告


        XRDesignFormEx designForm;
        XtraReport xtraReport;
        string filePath = "";
        private void BTPrint_Click(object sender, EventArgs e)
        {
            filePath = path + "\\Sampling.repx";
            if (File.Exists(filePath))
            {
                xtraReport = new XtraReport();
                xtraReport.LoadLayout(filePath);
                XRRichText xRLabel = (XRRichText)xtraReport.FindControl("EyeVisible", true);
                xRLabel.Text = TEEyeVisible.EditValue != null ? TEEyeVisible.EditValue.ToString() : "";
                //    XRTableCell planName = (XRTableCell)xtraReport.FindControl("planName", true);

                xtraReport.PrintAsync();
            }
            else
            {
                MessageBox.Show($"没有找到可使用的质控模板。\r\n请检查{filePath}文件是否存在", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTEditReport_Click(object sender, EventArgs e)
        {
            filePath = path + "\\Sampling.repx";
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
            }
        }
        #endregion 修改切片报告
    }
}
