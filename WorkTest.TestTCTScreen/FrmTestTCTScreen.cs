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



namespace WorkTest.TestTCTScreen
{
    public partial class FrmTestTCTScreen : DevExpress.XtraEditors.XtraForm
    {
        string SetResultTCTScreen = "";
        public static PictureEdit Picture { get; set; }
        public static SuperPictureEdit SuperPicture { get; set; }


        //public static string FileSampleImgPath = Environment.CurrentDirectory + "\\SaveTCTScreen";
        public static string FileImgPath = Environment.CurrentDirectory + "\\SaveTestTCTScreenImg";
        public FrmTestTCTScreen()
        {
            InitializeComponent();

            SetResultTCTScreen = ConfigInfos.ReadConfigInfo("SetResultTCTScreen");
        }

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private void FrmTestTCT_Load(object sender, EventArgs e)
        {
            FileImgPath += "\\" + DateTime.Now.ToString("yyyy-MM-dd");
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            MemoEdits.AddDoubleMethod(MEDiagnosis);
            MemoEdits.AddDoubleMethod(MEDiagnosisRemark);

            //MEDiagnosis.DoubleClick += MEEyeVisible_DoubleClick;
            //MEDiagnosisRemark.DoubleClick += MEEyeVisible_DoubleClick;
        }

        //private void MEEyeVisible_DoubleClick(object sender, EventArgs e)
        //{
        //    MemoEdit memoEdit = sender as MemoEdit;
        //    if(memoEdit.Tag!=null)
        //    {
        //        FrmShowDictionary frmShowDictionary = new FrmShowDictionary(memoEdit.Tag.ToString());
        //        Func<string> func = frmShowDictionary.ReturnResult;
        //        frmShowDictionary.ShowDialog();
        //        memoEdit.EditValue = func();
        //    }

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
        /// <param name="barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {
            xtraScrollableControl.Controls.Clear();
            pictureEditLocationxs = 0;
            Task<DataTable> ResultTask = new Task<DataTable>(() =>
            {
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkTest.ResultTCTScreen";
                selectInfo.wheres = $"testid='{testid}' and dstate=0";
                selectInfo.OrderColumns = "createTime desc";
                //DataTable DTResult = ApiHelpers.postInfo(selectInfo);
                return ApiHelpers.postInfo(selectInfo);
            });
            ResultTask.Start();
            Task<DataTable> ImgListTask = new Task<DataTable>(() =>
            {
                sInfo selectPicture = new sInfo();
                selectPicture.values = "id,testid,barcode,pictureDye,pictureNames,classNo,className,filestring";
                selectPicture.TableName = "WorkTest.ResultTCTScreenImg";
                selectPicture.wheres = $"testid='{testid}' and state=1 and dstate=0";
                selectPicture.OrderColumns = "classNo,sort";
                //DataTable DTPicture = ApiHelpers.postInfo(selectPicture);
                return ApiHelpers.postInfo(selectPicture);
            });
            ImgListTask.Start();
            DataTable imgDT = ImgListTask.Result;
            if (ResultTask.Result != null)
            {

                CEtct1.Checked = ResultTask.Result.Rows[0]["tct1"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct1"]) : true;
                CEtct2.Checked = ResultTask.Result.Rows[0]["tct2"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct2"]) : false;
                CEtct3.Checked = ResultTask.Result.Rows[0]["tct3"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct3"]) : false;
                CEtct4.Checked = ResultTask.Result.Rows[0]["tct4"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct4"]) : true;
                CEtct5.Checked = ResultTask.Result.Rows[0]["tct5"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct5"]) : false;
                CEtct6.Checked = ResultTask.Result.Rows[0]["tct6"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct6"]) : false;
                CEtct7.Checked = ResultTask.Result.Rows[0]["tct7"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct7"]) : false;
                CEtct8.Checked = ResultTask.Result.Rows[0]["tct8"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct8"]) : false;
                CEtct9.Checked = ResultTask.Result.Rows[0]["tct9"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct9"]) : false;
                CEtct10.Checked = ResultTask.Result.Rows[0]["tct10"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct10"]) : false;
                CEtct11.Checked = ResultTask.Result.Rows[0]["tct11"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct11"]) : false;
                CEtct12.Checked = ResultTask.Result.Rows[0]["tct12"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct12"]) : false;
                CEtct13.Checked = ResultTask.Result.Rows[0]["tct13"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct13"]) : false;
                CEtct14.Checked = ResultTask.Result.Rows[0]["tct14"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct14"]) : false;
                CEtct15.Checked = ResultTask.Result.Rows[0]["tct15"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct15"]) : false;
                CEtct16.Checked = ResultTask.Result.Rows[0]["tct16"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct16"]) : false;
                CEtct17.Checked = ResultTask.Result.Rows[0]["tct17"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct17"]) : false;
                CEtct18.Checked = ResultTask.Result.Rows[0]["tct18"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct18"]) : false;
                CEtct19.Checked = ResultTask.Result.Rows[0]["tct19"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct19"]) : false;
                CEtct20.Checked = ResultTask.Result.Rows[0]["tct20"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct20"]) : false;
                CEtct21.Checked = ResultTask.Result.Rows[0]["tct21"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct21"]) : false;
                CEtct22.Checked = ResultTask.Result.Rows[0]["tct22"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct22"]) : false;
                CEtct23.Checked = ResultTask.Result.Rows[0]["tct23"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct23"]) : false;
                CEtct25.Checked = ResultTask.Result.Rows[0]["tct25"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct25"]) : false;
                CEtct26.Checked = ResultTask.Result.Rows[0]["tct26"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct26"]) : false;
                CEtct27.Checked = ResultTask.Result.Rows[0]["tct27"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct27"]) : false;
                CEtct28.Checked = ResultTask.Result.Rows[0]["tct28"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct28"]) : false;
                CEtct29.Checked = ResultTask.Result.Rows[0]["tct29"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct29"]) : false;
                CEtct30.Checked = ResultTask.Result.Rows[0]["tct30"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct30"]) : false;
                CEtct31.Checked = ResultTask.Result.Rows[0]["tct31"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct31"]) : false;
                CEtct32.Checked = ResultTask.Result.Rows[0]["tct32"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct32"]) : false;
                CEtct33.Checked = ResultTask.Result.Rows[0]["tct33"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct33"]) : false;
                CEtct34.Checked = ResultTask.Result.Rows[0]["tct34"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct34"]) : false;
                CEtct35.Checked = ResultTask.Result.Rows[0]["tct35"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct35"]) : false;
                CEtct36.Checked = ResultTask.Result.Rows[0]["tct36"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct36"]) : false;
                CEtct37.Checked = ResultTask.Result.Rows[0]["tct37"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct37"]) : false;
                CEtct38.Checked = ResultTask.Result.Rows[0]["tct38"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct38"]) : false;
                CEtct39.Checked = ResultTask.Result.Rows[0]["tct39"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct39"]) : false;
                CEtct40.Checked = ResultTask.Result.Rows[0]["tct40"] != DBNull.Value ? Convert.ToBoolean(ResultTask.Result.Rows[0]["tct40"]) : false;

                //MEDiagnosis.EditValue = ResultTask.Result.Rows[0]["Diagnosis"];
                MEDiagnosis.EditValue = ResultTask.Result.Rows[0]["diagnosis"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosis"] : "未见上皮内病变细胞或恶性细胞";
                //if (!Convert.IsDBNull(ResultTask.Result.Rows[0]["DiagnosisRemark"]))
                //    MEDiagnosisRemark.EditValue = ResultTask.Result.Rows[0]["DiagnosisRemark"];
                MEDiagnosisRemark.EditValue = ResultTask.Result.Rows[0]["diagnosisRemark"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosisRemark"] : "";
            }
            else
            {
                MEDiagnosis.EditValue = "";
                MEDiagnosisRemark.EditValue = "";
                CEtct1.Checked = false;
                CEtct2.Checked = false;
                CEtct3.Checked = false;
                CEtct4.Checked = false;
                CEtct5.Checked = false;
                CEtct6.Checked = false;
                CEtct7.Checked = false;
                CEtct8.Checked = false;
                CEtct9.Checked = false;
                CEtct10.Checked = false;
                CEtct11.Checked = false;
                CEtct12.Checked = false;
                CEtct13.Checked = false;
                CEtct14.Checked = false;
                CEtct15.Checked = false;
                CEtct16.Checked = false;
                CEtct17.Checked = false;
                CEtct18.Checked = false;
                CEtct19.Checked = false;
                CEtct20.Checked = false;
                CEtct21.Checked = false;
                CEtct22.Checked = false;
                CEtct23.Checked = false;
                CEtct25.Checked = false;
                CEtct26.Checked = false;
                CEtct27.Checked = false;
                CEtct28.Checked = false;
                CEtct29.Checked = false;
                CEtct30.Checked = false;
                CEtct31.Checked = false;
                CEtct32.Checked = false;
                CEtct33.Checked = false;
                CEtct34.Checked = false;
                CEtct35.Checked = false;
                CEtct36.Checked = false;
                CEtct37.Checked = false;
                CEtct38.Checked = false;
                CEtct39.Checked = false;
                CEtct40.Checked = false;
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
                    //CommResultModel<TCTInfoModel> resultTCTInfo = new CommResultModel<TCTInfoModel>();
                    //CommResultModel<TCTInfoModel> resultTCTInfo = new CommResultModel<TCTInfoModel>();
                    resultTCTInfo.UserName = CommonData.UserInfo.names;
                    
                    if (info != null)
                    {
                        resultTCTInfo.AutographInfo = info;
                    }
                    //TCTInfoModel pathnology = new TCTInfoModel();
                    TCTInfoModel pathnology = new TCTInfoModel();


                    resultTCTInfo.ResultState = ResultState;
                    pathnology.State = true;
                    pathnology.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //pathnology.PathologyNo = PNO;
                    pathnology.Barcode = barcode;
                    pathnology.PictureCode = barcode;
                    pathnology.groupNO = groupNO;
                    pathnology.perid = perid;
                    pathnology.testid = testid; pathnology.sampleID = sampleid;
                    if (MEDiagnosis.EditValue != null)
                        pathnology.diagnosis = MEDiagnosis.EditValue.ToString();
                    if (MEDiagnosisRemark.EditValue != null)
                        pathnology.diagnosisRemark = MEDiagnosisRemark.EditValue.ToString();
                    if (CEtct1.Checked == true) { pathnology.TCT1 = true; } else { pathnology.TCT1 = false; };
                    if (CEtct2.Checked == true) { pathnology.TCT2 = true; } else { pathnology.TCT2 = false; };
                    if (CEtct3.Checked == true) { pathnology.TCT3 = true; } else { pathnology.TCT3 = false; };
                    if (CEtct4.Checked == true) { pathnology.TCT4 = true; } else { pathnology.TCT4 = false; };
                    if (CEtct5.Checked == true) { pathnology.TCT5 = true; } else { pathnology.TCT5 = false; };
                    if (CEtct6.Checked == true) { pathnology.TCT6 = true; } else { pathnology.TCT6 = false; };
                    if (CEtct7.Checked == true) { pathnology.TCT7 = true; } else { pathnology.TCT7 = false; };
                    if (CEtct8.Checked == true) { pathnology.TCT8 = true; } else { pathnology.TCT8 = false; };
                    if (CEtct9.Checked == true) { pathnology.TCT9 = true; } else { pathnology.TCT9 = false; };
                    if (CEtct10.Checked == true) { pathnology.TCT10 = true; } else { pathnology.TCT10 = false; };
                    if (CEtct11.Checked == true) { pathnology.TCT11 = true; } else { pathnology.TCT11 = false; };
                    if (CEtct12.Checked == true) { pathnology.TCT12 = true; } else { pathnology.TCT12 = false; };
                    if (CEtct13.Checked == true) { pathnology.TCT13 = true; } else { pathnology.TCT13 = false; };
                    if (CEtct14.Checked == true) { pathnology.TCT14 = true; } else { pathnology.TCT14 = false; };
                    if (CEtct15.Checked == true) { pathnology.TCT15 = true; } else { pathnology.TCT15 = false; };
                    if (CEtct16.Checked == true) { pathnology.TCT16 = true; } else { pathnology.TCT16 = false; };
                    if (CEtct17.Checked == true) { pathnology.TCT17 = true; } else { pathnology.TCT17 = false; };
                    if (CEtct18.Checked == true) { pathnology.TCT18 = true; } else { pathnology.TCT18 = false; };
                    if (CEtct19.Checked == true) { pathnology.TCT19 = true; } else { pathnology.TCT19 = false; };
                    if (CEtct20.Checked == true) { pathnology.TCT20 = true; } else { pathnology.TCT20 = false; };
                    if (CEtct21.Checked == true) { pathnology.TCT21 = true; } else { pathnology.TCT21 = false; };
                    if (CEtct22.Checked == true) { pathnology.TCT22 = true; } else { pathnology.TCT22 = false; };
                    if (CEtct23.Checked == true) { pathnology.TCT23 = true; } else { pathnology.TCT23 = false; };
                    //if (CEtct24.Checked == true) { pathnology.TCT24 = true; } else { pathnology.TCT24 = false; };
                    if (CEtct25.Checked == true) { pathnology.TCT25 = true; } else { pathnology.TCT25 = false; };
                    if (CEtct26.Checked == true) { pathnology.TCT26 = true; } else { pathnology.TCT26 = false; };
                    if (CEtct27.Checked == true) { pathnology.TCT27 = true; } else { pathnology.TCT27 = false; };
                    if (CEtct28.Checked == true) { pathnology.TCT28 = true; } else { pathnology.TCT28 = false; };
                    if (CEtct29.Checked == true) { pathnology.TCT29 = true; } else { pathnology.TCT29 = false; };
                    if (CEtct30.Checked == true) { pathnology.TCT30 = true; } else { pathnology.TCT30 = false; };
                    if (CEtct31.Checked == true) { pathnology.TCT31 = true; } else { pathnology.TCT31 = false; };
                    if (CEtct32.Checked == true) { pathnology.TCT32 = true; } else { pathnology.TCT32 = false; };
                    if (CEtct33.Checked == true) { pathnology.TCT33 = true; } else { pathnology.TCT33 = false; };
                    if (CEtct34.Checked == true) { pathnology.TCT34 = true; } else { pathnology.TCT34 = false; };
                    if (CEtct35.Checked == true) { pathnology.TCT35 = true; } else { pathnology.TCT35 = false; };
                    if (CEtct36.Checked == true) { pathnology.TCT36 = true; } else { pathnology.TCT36 = false; };
                    if (CEtct37.Checked == true) { pathnology.TCT37 = true; } else { pathnology.TCT37 = false; };
                    if (CEtct38.Checked == true) { pathnology.TCT38 = true; } else { pathnology.TCT38 = false; };
                    if (CEtct39.Checked == true) { pathnology.TCT39 = true; } else { pathnology.TCT39 = false; };
                    if (CEtct40.Checked == true) { pathnology.TCT40 = true; } else { pathnology.TCT40 = false; };

                    List<PictureInfoModel> results = new List<PictureInfoModel>();
                    int a = 0;
                    //FileSampleImgPath += "\\" + DateTime.Now.ToString("yyyy-MM-dd");

                    foreach (Control control in xtraScrollableControl.Controls)
                    {
                        PictureInfoModel resultPictureInfo = new PictureInfoModel();
                        a = a + 1;
                        resultPictureInfo.Barcode = barcode;
                        resultPictureInfo.perid = perid;
                        resultPictureInfo.testid = testid;
                        resultPictureInfo.ClassName = "阅片采图";
                        //resultPictureInfo.pathologyNo = PNO;
                        resultPictureInfo.ClassNo = "TCT";
                        resultPictureInfo.Sort = a;
                        resultPictureInfo.createTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    resultTCTInfo.Result = pathnology;
                    string s = JsonHelper.SerializeObjct(resultTCTInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(SetResultTCTScreen, s);
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
        #region 满意度联动
        private void CEtct1_CheckedChanged(object sender, EventArgs e)
        {
            if (CEtct1.Checked)
            {
                CEtct1.Checked = true; CEtct2.Checked = false; CEtct3.Checked = false;
            }

        }

        private void CEtct2_CheckedChanged(object sender, EventArgs e)
        {
            if (CEtct2.Checked)
            {
                CEtct1.Checked = false; CEtct2.Checked = true; CEtct3.Checked = false;
            }

        }

        private void CEtct3_CheckedChanged(object sender, EventArgs e)
        {
            if (CEtct3.Checked)
            {
                CEtct1.Checked = false; CEtct2.Checked = false; CEtct3.Checked = true;
            }

        }
        #endregion

        #region 炎性细胞联动
        private void CEtct33_CheckedChanged(object sender, EventArgs e)
        {
            if (!CEtct33.Checked)
            {
                CEtct34.Checked = false; CEtct35.Checked = false; CEtct36.Checked = false;
            }
        }

        private void CEtct34_CheckedChanged(object sender, EventArgs e)
        {
            if (CEtct34.Checked)
            {
                CEtct33.Checked = true; CEtct34.Checked = true; CEtct35.Checked = false; CEtct36.Checked = false;
            }

        }

        private void CEtct35_CheckedChanged(object sender, EventArgs e)
        {
            if (CEtct35.Checked)
            {
                CEtct33.Checked = true; CEtct34.Checked = false; CEtct35.Checked = true; CEtct36.Checked = false;
            }

        }

        private void CEtct36_CheckedChanged(object sender, EventArgs e)
        {
            if (CEtct36.Checked)
            {
                CEtct33.Checked = true; CEtct34.Checked = false; CEtct35.Checked = false; CEtct36.Checked = true;
            }
        }

        #endregion


    }
}
