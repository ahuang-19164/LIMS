using AForge.Video.DirectShow;
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
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WorkTest.TestTCTPathology
{
    public partial class FrmTestTCTPathology : DevExpress.XtraEditors.XtraForm
    {
        string SetResultTCT = "";
        public static PictureEdit Picture { get; set; }
        public static SuperPictureEdit SuperPicture { get; set; }

        //public static string FileSampleImgPath = Environment.CurrentDirectory + "\\SaveSampleImg";
        public static string FileImgPath = Environment.CurrentDirectory + "\\SaveTCTPathologyImg";
        public FrmTestTCTPathology()
        {
            InitializeComponent();
            //CommonData.configInfos.TryGetValue("SetResultTCT", out string ResultTCT);
            SetResultTCT = ConfigInfos.ReadConfigInfo("SetResultTCT");
        }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private void FrmPathologyTest_Load(object sender, EventArgs e)
        {
            FileImgPath += "\\" + DateTime.Now.ToString("yyyy-MM-dd");
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            MemoEdits.AddDoubleMethod(MEEyeVisible);
            MemoEdits.AddDoubleMethod(MEDiagnosisRemark);
            MemoEdits.AddDoubleMethod(MEDescriptionLesions);
            MemoEdits.AddDoubleMethod(MEpathologicDiagnosis);







            //MEEyeVisible.DoubleClick += MEEyeVisible_DoubleClick;
            //MEDiagnosisRemark.DoubleClick += MEEyeVisible_DoubleClick;
            //MEDescriptionLesions.DoubleClick += MEEyeVisible_DoubleClick;
            //MEpathologicDiagnosis.DoubleClick += MEEyeVisible_DoubleClick;
        }

        //private void MEEyeVisible_DoubleClick(object sender, EventArgs e)
        //{
        //    MemoEdit memoEdit = sender as MemoEdit;
        //    FrmShowDictionary frmShowDictionary = new FrmShowDictionary(memoEdit.Tag.ToString());
        //    Func<string> func = frmShowDictionary.ReturnResult;
        //    frmShowDictionary.ShowDialog();
        //    memoEdit.EditValue = func();
        //}

        private void FrmPathologyTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            cameraControl1.Dispose();
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
                NewPictureEdit("阅片采图", null, "2", bitmap);
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
                    NewPictureEdit("阅片采图", null, "2", bitmaps);
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
        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {
            xtraScrollableControl.Controls.Clear();
            pictureEditLocationxs = 0;
            Task<DataTable> ResultTask = new Task<DataTable>(() =>
            {
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkTest.ResultTCT";
                selectInfo.wheres = $"testid='{testid}' and state=1";
                selectInfo.OrderColumns = "createTime desc";
                return ApiHelpers.postInfo(selectInfo);
            });
            ResultTask.Start();
            Task<DataTable> ImgListTask = new Task<DataTable>(() =>
            {
                sInfo selectPicture = new sInfo();
                selectPicture.values = "id,testid,barcode,pictureDye,pictureNames,classNo,className,filestring";
                selectPicture.TableName = "WorkTest.ResultTCTImg";
                selectPicture.wheres = $"testid='{testid}' and state=1";
                selectPicture.OrderColumns = "classNo,sort";
                return ApiHelpers.postInfo(selectPicture);
            });
            ImgListTask.Start();
            DataTable imgDT = ImgListTask.Result;
            if (ResultTask.Result != null)
            {
                MEDescriptionLesions.EditValue = ResultTask.Result.Rows[0]["descriptionLesions"] != DBNull.Value ? ResultTask.Result.Rows[0]["descriptionLesions"] : "";
                MEDiagnosisRemark.EditValue = ResultTask.Result.Rows[0]["diagnosisRemark"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosisRemark"] : "";
                MEEyeVisible.EditValue = ResultTask.Result.Rows[0]["eyeVisible"] != DBNull.Value ? ResultTask.Result.Rows[0]["eyeVisible"] : "";
                MEpathologicDiagnosis.EditValue = ResultTask.Result.Rows[0]["diagnosis"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosis"] : "";
            }
            else
            {
                MEDescriptionLesions.EditValue = "";
                MEDiagnosisRemark.EditValue = "";
                MEEyeVisible.EditValue = "";
                MEpathologicDiagnosis.EditValue = "";
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
            Task<string> task = new Task<string>(() =>
            {
                if (testid != 0 && barcode != "")
                {
                    CommResultModel<TCTInfoModel> resultTCTInfo = new CommResultModel<TCTInfoModel>();
                    resultTCTInfo.UserName = CommonData.UserInfo.names;
                    
                    if (info != null)
                    {
                        resultTCTInfo.AutographInfo = info;
                    }
                    TCTInfoModel resultTCT = new TCTInfoModel();
                    //TCTInfoModel resultTCT = new TCTInfoModel();


                    resultTCTInfo.ResultState = ResultState;
                    resultTCT.State = true;
                    resultTCT.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    resultTCT.Barcode = barcode;
                    resultTCT.PictureCode = barcode;
                    resultTCT.groupNO = groupNO;
                    //resultTCT.PathologyNo = PNO;
                    resultTCT.perid = perid;
                    resultTCT.testid = testid; resultTCT.sampleID = sampleid;
                    if (MEEyeVisible.EditValue != null)
                        resultTCT.eyeVisible = MEEyeVisible.EditValue.ToString();
                    if (MEDescriptionLesions.EditValue != null)
                        resultTCT.descriptionLesions = MEDescriptionLesions.EditValue.ToString();
                    if (MEpathologicDiagnosis.EditValue != null)
                        resultTCT.diagnosis = MEpathologicDiagnosis.EditValue.ToString();
                    if (MEDiagnosisRemark.EditValue != null)
                        resultTCT.diagnosisRemark = MEDiagnosisRemark.EditValue.ToString();


                    List<PictureInfoModel> results = new List<PictureInfoModel>();
                    int a = 0;
                    //FileSampleImgPath += "\\" + DateTime.Now.ToString("yyyy-MM-dd");

                    foreach (Control control in xtraScrollableControl.Controls)
                    {
                        PictureInfoModel resultPictureInfo = new PictureInfoModel();
                        a = a + 1;
                        resultPictureInfo.Barcode = barcode;
                        resultPictureInfo.testid = testid;
                        //resultPictureInfo.ClassName = "阅片采图";
                        //resultPictureInfo.pathologyNo = PNO;
                        resultPictureInfo.ClassNo = "2";
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
                                    ComboBoxEdit cccc = item as ComboBoxEdit;
                                    resultPictureInfo.PictureDye = cccc.EditValue.ToString();
                                    if (item.Visible)
                                    {
                                        resultPictureInfo.ClassNo = "2";
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
                    resultTCT.ListPicture = results;
                    resultTCTInfo.Result = resultTCT;
                    string s = JsonHelper.SerializeObjct(resultTCTInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(SetResultTCT, s);
                    return jm.data.ToString();
                }
                else
                {
                    return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息。\"}";
                }
            });
            task.Start();
            return task.Result;

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

    }
}
