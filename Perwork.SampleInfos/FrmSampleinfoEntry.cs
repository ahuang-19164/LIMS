using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.HotKey;
using Common.JsonHelper;
using Common.Model;
using Common.PerModel;
using Common.SqlModel;

using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Perwork.SampleInfos
{
    public partial class FrmSampleinfoEntry : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 选中信息的条码号
        /// </summary>
        string selectValueID = "";
        int EditState = 1;//1.新增 2编辑
        int perSampleState = 1;//1.刚录入信息，其他状态不允许修改
        /// <summary>
        /// 选择项目
        /// </summary>
        DataTable DTcheckInfo;
        string sampleInfoEntry = "";
        string SampleInfoDelete = "";
        string GetEntryInfo = "";
        string PerBarcodeExist = "";


        public FrmSampleinfoEntry()
        {

            sampleInfoEntry = ConfigInfos.ReadConfigInfo("EntryInfo");
            SampleInfoDelete = ConfigInfos.ReadConfigInfo("SampleInfoDelete");
            GetEntryInfo = ConfigInfos.ReadConfigInfo("GetEntryInfo");
            PerBarcodeExist = ConfigInfos.ReadConfigInfo("PerBarcodeExist");

            InitializeComponent();
            GridControls.formartGridView(GVapplyInfo);
            GridControls.formartGridView(GVcheckInfo);
            GridControls.showEmbeddedNavigator(GCapplyInfo, false);
            GridControls.showEmbeddedNavigator(GCcheckInfo);




            GridControls.showEmbeddedNavigator(GCSampleInfo);
            GridControls.ShowViewColor(GVSampleInfo);
            GridControls.formartGridView(GVSampleInfo);

            TextEdits.TextFormat(TEageDay);
            TextEdits.TextFormat(TEageMoth);
            TextEdits.TextFormat(TEageYear);
            //TextEdits.TextFormat(TEbarcode);


            GridLookUpEdites.Formats(RGEperStateNO);
            GridLookUpEdites.Formats(GEagentNo);
            GridLookUpEdites.Formats(GEhospitalNo);
            GridLookUpEdites.Formats(GEpatientSexNO);
            GridLookUpEdites.Formats(GEpatientTypeNO);
            GridLookUpEdites.Formats(GEsampleShapeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);
            DEstartTime.EditValue = DateTime.Now;
            DEendTime.EditValue = DateTime.Now;
            CEseePersonal.Checked = true;
            GEagentNo.Enabled = false;


            DEreceiveTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DEsampleTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            layoutControlItem29.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem34.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem41.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem43.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem33.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem42.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem44.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem45.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem46.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem47.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem48.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem49.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem50.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem51.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem52.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem30.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem40.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem53.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem1.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem35.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem36.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem37.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem38.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem39.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem31.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem32.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem28.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem2.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem3.DoubleClick += LayoutControlItem44_DoubleClick;
            layoutControlItem4.DoubleClick += LayoutControlItem44_DoubleClick;
            q.DoubleClick += LayoutControlItem44_DoubleClick;
            PEsampleImg.EditValueChanged += PEsampleImg_EditValueChanged;


            //TEageYear.ImeMode =ImeMode.Disable;
            //TEageMoth.ImeMode = ImeMode.Off;
            //TEageDay.ImeMode = ImeMode.On;


            //TEdepartment.ImeMode = ImeMode.Disable;
            GEagentNo.ImeMode = ImeMode.Disable;
            GEhospitalNo.ImeMode = ImeMode.Disable;
            GEpatientSexNO.ImeMode = ImeMode.Disable;
            GEpatientTypeNO.ImeMode = ImeMode.Disable;
            GEsampleShapeNO.ImeMode = ImeMode.Disable;
            GEsampleTypeNO.ImeMode = ImeMode.Disable;

            SysPowerHelper.UserPower(barManager1);
            HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F1);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKeys.RegisterHotKey(Handle, 101, (uint)HotKeys.KeyModifiers.Ctrl, Keys.A);
            ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKeys.RegisterHotKey(Handle, 102, (uint)HotKeys.KeyModifiers.Ctrl, Keys.S);

        }

        private void PEsampleImg_EditValueChanged(object sender, EventArgs e)
        {
            if (PEsampleImg.Image != null)
            {
                Bitmap bitmap = new Bitmap(PEsampleImg.Image);
                Bitmap bitmaps = new Bitmap(ImageCompressHelper.ImageCompress(bitmap));
                CameraImage = bitmaps;
            }

        }

        private void FrmSampleinfoEntry_Load(object sender, EventArgs e)
        {
            RGEperStateNO.DataSource = WorkCommData.DTStatePerWork;
            GEagentNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);
            GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);



            GCapplyInfo.DataSource = DTHelper.DTEnable(WorkCommData.DTItemApply);
            DTcheckInfo = WorkCommData.DTItemApply.Clone();
            GCcheckInfo.DataSource = DTcheckInfo;
            GVapplyInfo.BestFitColumns();
            BTselect_ItemClick(null, null);
            GVSampleInfo.BestFitColumns();
            //BTAdd_ItemClick(null, null);
        }

        private void LayoutControlItem44_DoubleClick(object sender, EventArgs e)
        {
            LayoutControlItem item = sender as LayoutControlItem;
            if (item.Control.Enabled == true)
            {
                item.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
                item.Control.Enabled = false;
            }
            else
            {
                item.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
                item.Control.Enabled = true;
            }
        }



        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        bool dockPanelState = true;
        Bitmap CameraImage;

        private void dockPanel3_Click(object sender, EventArgs e)
        {
            if(sender==null&&e==null)
            {
                Bitmap bitmapa = this.cameraControl1.TakeSnapshot();
                if (bitmapa != null)
                {

                    CameraImage = new Bitmap(ImageCompressHelper.ImageCompress(bitmapa));
                    PEsampleImg.Image = CameraImage;
                }
                else
                {
                    MessageBox.Show("没有拍摄到图片，请检查摄像头链接是否正常。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dockPanelState = true;
                DevExpress.XtraBars.Docking.DockPanel dockPanel = sender as DevExpress.XtraBars.Docking.DockPanel;
                dockPanel.CustomButtonClick += DockPanel_CustomButtonClick;
            }

        }

        private void DockPanel_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if(dockPanelState)
            {
                dockPanelState = false;
                string a = ((DevExpress.XtraEditors.ButtonPanel.BaseButton)e.Button).Caption;
                if (a == "上传")
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        //openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
                        openFileDialog.InitialDirectory = "C:\\Users\\huang\\Desktop\\";
                        //openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
                        openFileDialog.Filter = "Img|*.jpg;*.png";
                        openFileDialog.RestoreDirectory = true;
                        openFileDialog.FilterIndex = 1;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = openFileDialog.FileName;
                            //FileClassa = System.IO.Path.GetExtension(openFileDialog.FileName); //文件扩展名
                            string FileClass = System.IO.Path.GetExtension(fileName); //文件扩展名
                            if (FileClass.ToLower() != ".jpg" && FileClass.ToLower() != ".png")
                            {
                                MessageBox.Show("文件类型错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                Bitmap bitmap = new Bitmap(fileName);
                                CameraImage = new Bitmap(ImageCompressHelper.ImageCompress(bitmap));
                                PEsampleImg.Image = CameraImage;
                            }
                        }
                    }
                }
                else
                {

                    if(a=="清空")
                    {
                        CameraImage = null;
                        PEsampleImg.Image = CameraImage;
                    }
                    else
                    {
                        Bitmap bitmapa = this.cameraControl1.TakeSnapshot();
                        if (bitmapa != null)
                        {

                            CameraImage = new Bitmap(ImageCompressHelper.ImageCompress(bitmapa));
                            PEsampleImg.Image = CameraImage;
                        }
                        else
                        {
                            MessageBox.Show("没有拍摄到图片，请检查摄像头链接是否正常。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }


                }
            }


        }


        #region 项目选择处理

        /// <summary>
        /// 双击选择项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVapplyInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVapplyInfo.GetFocusedDataRow() != null)
            {
                if (DTcheckInfo.Select($"no='{GVapplyInfo.GetFocusedDataRow()["no"].ToString()}'").Count() == 0)
                {
                    DataRow newdata = DTcheckInfo.NewRow();
                    newdata.ItemArray = GVapplyInfo.GetFocusedDataRow().ItemArray;
                    DTcheckInfo.Rows.InsertAt(newdata, 0);
                    DTcheckInfo.AcceptChanges();


                }
                GVapplyInfo.OptionsFind.AlwaysVisible = false;
                //GVapplyInfo.ShowFindPanel();
                GVapplyInfo.OptionsFind.AlwaysVisible = true;
            }
            GVcheckInfo.BestFitColumns();
        }

        private void GVcheckInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVcheckInfo.GetFocusedDataRow() != null)
            {
                DataRow row = GVcheckInfo.GetFocusedDataRow();
                DTcheckInfo.Rows.Remove(GVcheckInfo.GetFocusedDataRow());
                //GVcheckInfo.DeleteRow(GVcheckInfo.FocusedRowHandle);
            }

        }


        #endregion

        private void GCapplyInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnShown(null);
        }

        private void GVapplyInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GVapplyInfo_DoubleClick(null, null);
            }
            OnShown(null);
        }



        string oldbarcode = "";
        /// <summary>
        /// 根据条码判断医院和代理商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TEbarcode_Leave(object sender, EventArgs e)
        {
            if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString() != "")
            {

                TEbarcode.EditValue = TEbarcode.EditValue.ToString().ToUpper();
                //sInfo selectInfo = new sInfo();
                //selectInfo.values = "1";
                //selectInfo.TableName = "WorkPer.SampleInfo";
                //selectInfo.wheres = $"barcode='{TEbarcode.EditValue}' and dstate=0";

                string remsg = "";
                commInfoModel<string> commInfoModel = new commInfoModel<string>();
                List<string> barcodes = new List<string>();
                barcodes.Add(TEbarcode.EditValue.ToString());
                commInfoModel.infos = barcodes;
                string sr = JsonHelper.SerializeObjct(commInfoModel);
                var jm = ApiHelpers.postInfo(PerBarcodeExist, sr);
                commReInfo<commReBarcodeInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReBarcodeInfo>>(jm);
                foreach(commReBarcodeInfo reBarcodeInfo in commReInfo.infos)
                {
                    if(reBarcodeInfo.code==1)
                    {
                        remsg += "条码号:"+reBarcodeInfo.barcode+",条码号已存在！";
                    }
                }



                //DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                //DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                if (jm.status)
                {
                    if (TEbarcode.EditValue.ToString().Length == 11)
                    {
                        //string ls = TEbarcode.EditValue.ToString().Substring(6,6);
                        //if (Int64.TryParse(ls, out Int64 intA))
                        //{

                        string hosptilcode = TEbarcode.EditValue.ToString().Substring(0, 5);
                        DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{hosptilcode}'");
                        if (dataRow.Count() > 0)
                        {
                            GEhospitalNo.EditValue = hosptilcode;
                            GEhospitalNo.Enabled = false;
                        }
                        else
                        {
                            if (GEhospitalNo.Enabled == true)
                            {
                                GEhospitalNo.EditValue = "";
                                GEagentNo.EditValue = "";
                                TEpersonalize.EditValue = "";
                                GEagentNo.Enabled = true;
                            }
                        }
                    }
                }
                else
                {

                    MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //TEbarcode.EditValue = "";
                    ////BTAdd_ItemClick(null, null);
                    //TEbarcode.Focus();
                    TEbarcode.SelectAll();
                }


            }
            else
            {
                TEbarcode.EditValue = "";
                GEhospitalNo.EditValue = "";
                GEagentNo.EditValue = "";
                TEpersonalize.EditValue = "";
                GEhospitalNo.Enabled = true;
                GEagentNo.Enabled = true;
            }
        }

        ///<summary>
        /// 新增标本信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perSampleState = 1;
            EditState = 1;
            selectValueID = "";
            SImgString = "";
            TEbarcode.Enabled = true;
            //GEhospitalNo.Enabled = true;
            if (!CEContinuousEntry.Checked)
            {
                TEbarcode.EditValue = "";
                GEhospitalNo.EditValue = "";
                GEagentNo.EditValue = "";
                TEpersonalize.EditValue = "";
                GEhospitalNo.Enabled = true;
            }
            else
            {

                if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Length > 6)
                {
                    string oldbarcode = TEbarcode.EditValue.ToString();
                    string hs = oldbarcode.Substring(0, 5);
                    //string ls = oldbarcode.Substring(5, 6);
                    string ls = oldbarcode.Substring(5, oldbarcode.Length - 5);
                    string formart = "";
                    for (int a = 1; a <= oldbarcode.Length - 5; a++)
                    {
                        formart += "0";
                    }

                    if (Int64.TryParse(ls, out Int64 intA))
                    {
                        string lss = String.Format($"{{0:{formart}}}", intA + 1);
                        TEbarcode.EditValue = hs + lss.ToString();
                        string hosptilcode = TEbarcode.EditValue.ToString().Substring(0, 5);
                        DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{hosptilcode}'");
                        if (dataRow.Count() > 0)
                        {
                            GEhospitalNo.EditValue = hosptilcode;
                            GEagentNo.EditValue = dataRow[0]["agentNO"];
                            TEpersonalize.EditValue = dataRow[0]["personalize"];
                            GEhospitalNo.Enabled = false;
                        }
                        else
                        {
                            if (GEhospitalNo.Enabled == true)
                                GEhospitalNo.EditValue = "";
                            if (GEagentNo.Enabled == true)
                                GEagentNo.EditValue = "";
                            TEpersonalize.EditValue = "";
                            //GEhospitalNo.Enabled = true;
                        }

                    }
                    else
                    {
                        TEbarcode.EditValue = "";
                        GEagentNo.EditValue = "";
                        TEpersonalize.EditValue = "";
                        GEhospitalNo.EditValue = "";
                        GEhospitalNo.Enabled = true;


                    }


                }
                else
                {
                    TEbarcode.EditValue = "";
                    GEhospitalNo.EditValue = "";
                    GEagentNo.EditValue = "";
                    TEpersonalize.EditValue = "";
                    GEhospitalNo.Enabled = true;
                }

            }
            if (GEagentNo.Enabled == true)
                GEagentNo.EditValue = "";
            if (DEreceiveTime.Enabled == true)
                DEreceiveTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (DEsampleTime.Enabled == true)
                DEsampleTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (GEhospitalNo.Enabled == true)
                GEhospitalNo.EditValue = "";
            if (TEhospitalBarcode.Enabled == true)
                TEhospitalBarcode.EditValue = "";
            if (TEageDay.Enabled == true)
                TEageDay.EditValue = "";
            if (TEageMoth.Enabled == true)
                TEageMoth.EditValue = "";
            if (TEageYear.Enabled == true)
                TEageYear.EditValue = "";
            if (TEpatientName.Enabled == true)
                TEpatientName.EditValue = "";
            if (TEbedNo.Enabled == true)
                TEbedNo.EditValue = "";
            if (TEclinicalDiagnosis.Enabled == true)
                TEclinicalDiagnosis.EditValue = "";
            if (TEcutPart.Enabled == true)
                TEcutPart.EditValue = "";
            if (TEdepartment.Enabled == true)
                TEdepartment.EditValue = "";
            if (TEdoctorPhone.Enabled == true)
                TEdoctorPhone.EditValue = "";
            if (TEmedicalNo.Enabled == true)
                TEmedicalNo.EditValue = "";
            if (DEmenstrualTime.Enabled == true)
                DEmenstrualTime.EditValue = "";
            if (TEpathologyNo.Enabled == true)
                TEpathologyNo.EditValue = "";
            if (TEpatientCardNo.Enabled == true)
                TEpatientCardNo.EditValue = "";
            if (TEpatientPhone.Enabled == true)
                TEpatientPhone.EditValue = "";
            if (GEpatientSexNO.Enabled == true)
                GEpatientSexNO.EditValue = "";
            if (GEpatientTypeNO.Enabled == true)
                GEpatientTypeNO.EditValue = "";
            if (TEperRemark.Enabled == true)
                TEperRemark.EditValue = "";
            if (GEsampleShapeNO.Enabled == true)
                GEsampleShapeNO.EditValue = "";
            if (GEsampleTypeNO.Enabled == true)
                GEsampleTypeNO.EditValue = "";
            if (TEsendDoctor.Enabled == true)
                TEsendDoctor.EditValue = "";
            if (CEurgent.Enabled == true)
                CEurgent.Checked = false;
            if (TEsampleLocation.Enabled == true)
                TEsampleLocation.EditValue = "";
            if (TEpatientAddress.Enabled == true)
                TEpatientAddress.EditValue = "";
            if (TEpassportNo.Enabled == true)
                TEpassportNo.EditValue = "";
            if (TEnumber.Enabled == true)
                TEnumber.EditValue = "";


            if (!CEItemMemory.Checked)
            {
                DTcheckInfo.Rows.Clear();
                //GCcheckInfo.DataSource = null;
            }
            if (!CEImgMemory.Checked)
            {
                PEsampleImg.Image = null;
                CameraImage = null;
            }


            TEbarcode.Focus();





        }

        public static string FileImgPath = Environment.CurrentDirectory + "\\SaveSampleImg";


        public static int perstate=0;

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (perSampleState != 1)
                {
                    MessageBox.Show("标本信息已经审核，无法进行修改", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    perstate = 0;
                    GVcheckInfo.FocusedRowHandle = -1;
                    if (TEbarcode.EditValue == null || TEbarcode.EditValue.ToString() == "")
                    {
                        MessageBox.Show("条码号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        if (GEhospitalNo.EditValue == null || GEhospitalNo.EditValue.ToString() == "")
                        {
                            MessageBox.Show("医院信息不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (DTcheckInfo.Rows.Count == 0)
                            {
                                MessageBox.Show("项目信息不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {

                                string applycodes = "";
                                string applyNames = "";
                                foreach (DataRow row in DTcheckInfo.Rows)
                                {
                                    applycodes += row["no"].ToString() + ",";
                                    applyNames += row["names"].ToString() + ",";
                                }
                                applycodes = applycodes.Substring(0, applycodes.Length - 1);
                                applyNames = applyNames.Substring(0, applyNames.Length - 1);
                                string ImgString = "";
                                if (CameraImage != null)
                                {

                                    ///保存物理图片
                                    string FileSampleImgPath = FileImgPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                                    if (!Directory.Exists(FileSampleImgPath))
                                    {
                                        Directory.CreateDirectory(FileSampleImgPath);
                                    }
                                    string FileSavePath = FileSampleImgPath + "\\" + TEbarcode.EditValue + ".png";
                                    if (File.Exists(FileSavePath))
                                    {
                                        File.Delete(FileSavePath);
                                    }
                                    //Bitmap bitmaps = ImageCompressHelper.SizeImage(CameraImage, 800, 800);
                                    //Bitmap bitmap = new Bitmap(ImageCompressHelper.ImageCompress(bitmaps));
                                    //Bitmap bitmap = new Bitmap(ImageCompressHelper.ImageCompress(CameraImage));
                                    //bitmap.Save(FileSavePath, ImageFormat.Png);
                                    CameraImage.Save(FileSavePath, ImageFormat.Png);
                                    ImgString = FileConverHelpers.BitmapTostring(CameraImage);
                                }
                                //else
                                //{
                                //    if (PEsampleImg.Image != null)
                                //    {
                                //        / 保存物理图片
                                //        string FileSampleImgPath = FileImgPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                                //        if (!Directory.Exists(FileSampleImgPath))
                                //        {
                                //            Directory.CreateDirectory(FileSampleImgPath);
                                //        }
                                //        string FileSavePath = FileSampleImgPath + "\\" + TEbarcode.EditValue + ".png";
                                //        if (File.Exists(FileSavePath))
                                //        {
                                //            File.Delete(FileSavePath);
                                //        }
                                //        CameraImage = PEsampleImg.Image as Bitmap;

                                //        Bitmap bitmaps = ImageCompressHelper.SizeImage(CameraImage, 800, 800);
                                //        Bitmap bitmap = new Bitmap(ImageCompressHelper.ImageCompress(bitmaps));
                                //        bitmap.Save(FileSavePath, ImageFormat.Png);
                                //        ImgString = FileConverHelpers.BitmapTostring(bitmap);
                                //    }

                                //}

                                EntryInfoModel Infos = new EntryInfoModel();
                                Infos.UserName = CommonData.UserInfo.names;
                                List<SampleInfoModel> sampleInfos = new List<SampleInfoModel>();
                                SampleInfoModel sampleInfo = new SampleInfoModel();
                                sampleInfo.barcode = TEbarcode.EditValue.ToString();
                                sampleInfo.hospital = GEhospitalNo.EditValue.ToString();
                                sampleInfo.hospitalName = GEhospitalNo.Text;
                                sampleInfo.applyCodes = applycodes;
                                sampleInfo.applyNames = applyNames;
                                sampleInfo.fileString = ImgString;
                                List<PairsInfoModel> pairsInfos = new List<PairsInfoModel>();
                                List<PairsInfoModel> pairsOtherInfos = new List<PairsInfoModel>();
                                foreach (var control in layGroupInfos.Items)
                                {
                                    //PairsInfoModel pairs = new PairsInfoModel();
                                    string controlname = "";
                                    string controlkey = "";
                                    string controlvalue = "";
                                    string controlcolumn = "";
                                    if (control is LayoutControlItem)
                                    {
                                        LayoutControlItem tmp = control as LayoutControlItem;
                                        var first = tmp.Text;//ID,Name,Age,Adress
                                        controlname = tmp.Text.Trim().Replace(" ", "");//ID,Name,Age,Adress

                                        if (tmp.Control is TextEdit)
                                        {
                                            var aaaa = tmp.Control as TextEdit;
                                            if (aaaa.Name != "TEbarcode" && aaaa.Name != "GEhospitalNo")
                                            {
                                                controlkey = aaaa.Name;
                                                controlcolumn = aaaa.Tag != null ? aaaa.Tag.ToString() : "";
                                                if (aaaa.EditValue != null&& controlcolumn!="")
                                                {
                                                    if (controlkey.Contains("GE"))
                                                    {
                                                        controlvalue = aaaa.Text.ToString();//ID,Name,Age,Adress
                                                        if (controlvalue.Length > 0)
                                                        {
                                                            PairsInfoModel pairs = new PairsInfoModel();
                                                            //PairsInfoModel pairs = new PairsInfoModel();
                                                            pairs.caption = controlname;
                                                            pairs.keyName = controlkey;
                                                            pairs.valueString = controlvalue;
                                                            pairs.columnName = controlcolumn.Substring(0, controlcolumn.Length - 2) + "Names";
                                                            pairsInfos.Add(pairs);
                                                        }
                                                    }
                                                    //shijian
                                                    controlvalue = aaaa.EditValue.ToString();//ID,Name,Age,Adress
                                                    if (controlvalue.Length > 0)
                                                    {
                                                        PairsInfoModel pairs = new PairsInfoModel();
                                                        pairs.caption = controlname;
                                                        pairs.keyName = controlkey;
                                                        pairs.valueString = controlvalue;
                                                        pairs.columnName = aaaa.Tag != null ? aaaa.Tag.ToString() : null;
                                                        pairsInfos.Add(pairs);
                                                    }

                                                }
                                            }
                                        }
                                        else
                                        {
                                            //判断选项
                                            if (tmp.Control is CheckEdit)
                                            {
                                                PairsInfoModel pairs = new PairsInfoModel();
                                                var aaaa = tmp.Control as CheckEdit;
                                                controlkey = aaaa.Name;
                                                controlvalue = aaaa.Checked.ToString();//ID,Name,Age,Adress
                                                pairs.caption = controlname;
                                                pairs.keyName = controlkey;
                                                pairs.valueString = controlvalue;
                                                pairs.columnName = aaaa.Tag != null ? aaaa.Tag.ToString() : null;
                                                pairsInfos.Add(pairs);
                                            }
                                        }
                                    }
                                }
                                foreach (var control in layGroupOther.Items)
                                {
                                    //PairsInfoModel pairsOther = new PairsInfoModel();
                                    PairsInfoModel pairsOther = new PairsInfoModel();
                                    string controlname = "";
                                    string controlkey = "";
                                    string controlvalue = "";
                                    if (control is LayoutControlItem)
                                    {
                                        LayoutControlItem tmp = control as LayoutControlItem;
                                        var first = tmp.Text;//ID,Name,Age,Adress
                                        controlname = tmp.Text.Trim();//ID,Name,Age,Adress
                                        if (tmp.Control is TextEdit)
                                        {
                                            var aaaa = tmp.Control as TextEdit;
                                            controlkey = aaaa.Name;
                                            if (aaaa.EditValue != null)
                                            {
                                                controlvalue = aaaa.EditValue.ToString();//ID,Name,Age,Adress
                                                if (controlvalue.Length > 0)
                                                {
                                                    pairsOther.caption = controlname;
                                                    pairsOther.keyName = controlkey;
                                                    pairsOther.valueString = controlvalue;
                                                    pairsOther.columnName = aaaa.Tag != null ? aaaa.Tag.ToString() : null;
                                                    pairsOtherInfos.Add(pairsOther);
                                                }
                                            }


                                        }
                                        else
                                        {
                                            if (tmp.Control is CheckEdit)
                                            {

                                                var aaaa = tmp.Control as CheckEdit;
                                                controlkey = aaaa.Name;
                                                controlvalue = aaaa.Checked.ToString();//ID,Name,Age,Adress
                                                pairsOther.caption = controlname;
                                                pairsOther.keyName = controlkey;
                                                pairsOther.valueString = controlvalue;
                                                pairsOther.columnName = aaaa.Tag != null ? aaaa.Tag.ToString() : null;
                                                pairsOtherInfos.Add(pairsOther);
                                            }
                                        }
                                    }
                                }
                                sampleInfo.pairsInfo = pairsInfos;
                                sampleInfo.pairsOhterInfo = pairsOtherInfos;
                                sampleInfos.Add(sampleInfo);
                                Infos.sampleInfos = sampleInfos;
                                Infos.operatType = EditState;
                                string s = JsonHelper.SerializeObjct(Infos);
                                //string aaa = ApiHelpers.postInfo(sampleInfoEntry, s);
                                WebApiCallBack jm = ApiHelpers.postInfo(sampleInfoEntry, s);
                                commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                                if(commReInfo!=null)
                                {
                                    //if (commReInfo.code == 0)
                                    //{
                                    //    MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //}
                                    //else
                                    //{

                                        if (EditState == 1)
                                        {
                                            if (GVSampleInfo.RowCount == 0)
                                            {
                                                BTselect_ItemClick(null, null);
                                            }
                                            else
                                            {
                                                foreach(commReSampleInfo reSampleInfo in commReInfo.infos)
                                                {
                                                    if(reSampleInfo.code==0)
                                                    {
                                                        GVSampleInfo.AddNewRow();
                                                    }
                                                }
                                                
                                            }
                                        }
                                        else
                                        {
                                            GVSampleInfo.SetFocusedRowCellValue("patientName", TEpatientName.EditValue);
                                            GVSampleInfo.SetFocusedRowCellValue("patientSexNames", GEpatientSexNO.Text);
                                            GVSampleInfo.SetFocusedRowCellValue("ageYear", TEageYear.EditValue);
                                            GVSampleInfo.SetFocusedRowCellValue("hospitalNO", GEhospitalNo.EditValue);
                                            GVSampleInfo.SetFocusedRowCellValue("hospitalNames", GEhospitalNo.Text);
                                            GVSampleInfo.SetFocusedRowCellValue("urgent", CEurgent.Checked);

                                        }
                                        string reMsg = "";
                                        foreach(commReSampleInfo reSampleInfo in commReInfo.infos)
                                        {
                                            if (reSampleInfo.code == 1)
                                                reMsg += reSampleInfo.msg+"\r\n";
                                        }
                                        if (reMsg != "")
                                            MessageBox.Show(reMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        BTAdd_ItemClick(null, null);


                                    }
                                //}

                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                BTAdd_ItemClick(null, null);
                throw ex;
            }

        }






        /// <summary>
        /// 查询信息列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTselect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EntrySelectModel datas = new EntrySelectModel();
            datas.UserName = CommonData.UserInfo.names;
            datas.startTime = Convert.ToDateTime(DEstartTime.EditValue).ToString("yyyy-MM-dd");
            datas.endTime = Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
            datas.operatType = CEseePersonal.Checked ? "1" : "2";
            string Sr = JsonHelper.SerializeObjct(datas);
            //DataTable a = ApiHelpers.postInfo(GetEntryInfo, Sr);
            WebApiCallBack jm = ApiHelpers.postInfo(GetEntryInfo, Sr);
            DataTable dataTable = JsonHelper.StringToDT(jm);
            GCSampleInfo.DataSource = dataTable;
            GVSampleInfo.BestFitColumns();
        }

        /// <summary>
        /// 删除信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTdelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (GVSampleInfo.GetFocusedDataRow() != null)
                {
                    DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DeleteInfoModel deleteInfos = new DeleteInfoModel();
                        deleteInfos.UserName = CommonData.UserInfo.names;
                        deleteInfos.state = 1;
                        List<InfoListModel> infoLists = new List<InfoListModel>();
                        string remsg = "";
                        int[] ss = GVSampleInfo.GetSelectedRows();
                        for (int sm = ss.Count() - 1; sm >= 0; sm--)
                        {
                            if (GVSampleInfo.GetDataRow(ss[sm])["perStateNO"].ToString() == "1")
                            {
                                InfoListModel info = new InfoListModel();
                                if (GVSampleInfo.GetDataRow(ss[sm])["id"] != DBNull.Value)
                                {
                                    info.SampleID = GVSampleInfo.GetDataRow(ss[sm])["id"].ToString();
                                }
                                info.barcode = GVSampleInfo.GetDataRow(ss[sm])["barcode"].ToString();
                                infoLists.Add(info);
                                //GVSampleInfo.DeleteRow(ss[sm]);
                            }
                            else
                            {
                                remsg+= GVSampleInfo.GetDataRow(ss[sm])["barcode"].ToString()+":样本已审核删除失败";
                            }

                        }
                        if (infoLists.Count > 0)
                        {
                            deleteInfos.sampleinfos = infoLists;
                            string s = JsonHelper.SerializeObjct(deleteInfos);
                            WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoDelete, s);
                            commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                            if (commReInfo != null)
                            {
                                foreach (commReSampleInfo sampleInfo in commReInfo.infos)
                                {
                                    if (sampleInfo.code == 0)
                                    {
                                        for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
                                        {
                                            string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();
                                            if (sampleInfo.barcode == barcode)
                                            {
                                                GVSampleInfo.DeleteRow(r);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        remsg = sampleInfo.barcode + ":" + sampleInfo.msg + "\r\n";
                                    }
                                }
                                if (remsg != "")
                                    MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        string SImgString = "";
        private void GVSampleInfo_Click(object sender, EventArgs e)
        {
            EditState = 2;
            TEbarcode.Enabled = false;
            GEhospitalNo.Enabled = false;


            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();

            if (dataRow != null)
            {
                selectValueID = dataRow["barcode"].ToString(); ;
                EntrySelectModel datas = new EntrySelectModel();
                datas.UserName = CommonData.UserInfo.names;
                datas.startTime = Convert.ToDateTime(DEstartTime.EditValue).ToString("yyyy-MM-dd");
                datas.endTime = Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
                datas.operatType = CEseePersonal.Checked ? "1" : "2";
                datas.sampleCode = selectValueID;
                string Sr = JsonHelper.SerializeObjct(datas);
                //DataTable a = ApiHelpers.postInfo(GetEntryInfo, Sr);
                WebApiCallBack jm = ApiHelpers.postInfo(GetEntryInfo, Sr);
                DataTable dataTable = JsonHelper.StringToDT(jm);
                //GCSampleInfo.DataSource = dataTable;
                if (dataTable != null)
                {
                    DEreceiveTime.EditValue = dataTable.Rows[0]["receiveTime"];
                    DEsampleTime.EditValue = dataTable.Rows[0]["sampleTime"];
                    TEageDay.EditValue = dataTable.Rows[0]["ageDay"];
                    TEageMoth.EditValue = dataTable.Rows[0]["ageMoth"];
                    TEageYear.EditValue = dataTable.Rows[0]["ageYear"];
                    TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    GEagentNo.EditValue = dataTable.Rows[0]["agentNo"];
                    TEhospitalBarcode.EditValue = dataTable.Rows[0]["hospitalBarcode"];
                    //TEapplyItemCodes.EditValue = dataTable.Rows[0]["applyItemCodes"];
                    //TEapplyItemNames.EditValue = dataTable.Rows[0]["applyItemNames"];
                    TEbarcode.EditValue = dataTable.Rows[0]["barcode"];
                    TEbedNo.EditValue = dataTable.Rows[0]["bedNo"];
                    TEclinicalDiagnosis.EditValue = dataTable.Rows[0]["clinicalDiagnosis"];
                    TEsampleLocation.EditValue = dataTable.Rows[0]["sampleLocation"];
                    TEcutPart.EditValue = dataTable.Rows[0]["cutPart"];
                    TEdepartment.EditValue = dataTable.Rows[0]["department"];
                    TEdoctorPhone.EditValue = dataTable.Rows[0]["doctorPhone"];
                    GEhospitalNo.EditValue = dataTable.Rows[0]["hospitalNo"];
                    TEmedicalNo.EditValue = dataTable.Rows[0]["medicalNo"];
                    DEmenstrualTime.EditValue = dataTable.Rows[0]["menstrualTime"];
                    TEpathologyNo.EditValue = dataTable.Rows[0]["pathologyNo"];
                    TEpatientCardNo.EditValue = dataTable.Rows[0]["patientCardNo"];
                    TEpatientPhone.EditValue = dataTable.Rows[0]["patientPhone"];
                    GEpatientSexNO.EditValue = dataTable.Rows[0]["patientSexNO"];
                    GEpatientTypeNO.EditValue = dataTable.Rows[0]["patientTypeNO"];
                    TEperRemark.EditValue = dataTable.Rows[0]["perRemark"];
                    GEsampleShapeNO.EditValue = dataTable.Rows[0]["sampleShapeNO"];
                    GEsampleTypeNO.EditValue = dataTable.Rows[0]["sampleTypeNO"];
                    TEsendDoctor.EditValue = dataTable.Rows[0]["sendDoctor"];
                    TEpatientAddress.EditValue = dataTable.Rows[0]["patientAddress"];
                    TEpassportNo.EditValue = dataTable.Rows[0]["passportNo"];
                    TEnumber.EditValue = dataTable.Rows[0]["number"];


                    perSampleState = Convert.ToInt32(dataTable.Rows[0]["perStateNO"]);
                    CEurgent.Checked = Convert.ToBoolean(dataTable.Rows[0]["urgent"]);
                    if (WorkCommData.DTItemApply != null)
                    {
                        GCcheckInfo.DataSource = DTcheckInfo = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
                    }
                    sInfo selectInfoImg = new sInfo();
                    selectInfoImg.values = "top 1 *";
                    selectInfoImg.TableName = "WorkPer.SampleImg";
                    selectInfoImg.wheres = $"barcode='{selectValueID}' and dstate=0 and state=1";
                    selectInfoImg.OrderColumns = "createTime desc";
                    DataTable dataTableImg = ApiHelpers.postInfo(selectInfoImg);
                    if (dataTableImg != null)
                    {
                        if (dataTableImg.Rows[0]["filestring"] != DBNull.Value)
                        {
                            SImgString = dataTableImg.Rows[0]["filestring"].ToString();
                            PEsampleImg.Image = CameraImage = FileConverHelpers.StringToBitmap(SImgString);
                        }
                    }
                    else
                    {
                        PEsampleImg.Image = CameraImage = null;
                    }
                }

            }

        }
        /// <summary>
        ///图片放大方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PEsampleImg_DoubleClick(object sender, EventArgs e)
        {
            if (PEsampleImg.Image != null)
            {
                PEsampleImg.ShowImageEditorDialog();
            }
        }
        /// <summary>
        /// 添加数据显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVSampleInfo_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GVSampleInfo.SetRowCellValue(e.RowHandle, "perStateNO", 1);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "barcode", TEbarcode.EditValue);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "patientName", TEpatientName.EditValue);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "patientSexNames", GEpatientSexNO.Text);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "ageYear", TEageYear.EditValue);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "hospitalNO", GEhospitalNo.EditValue);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "hospitalNames", GEhospitalNo.Text);
            GVSampleInfo.SetRowCellValue(e.RowHandle, "urgent", CEurgent.Checked);
            if (EditState == 1)
            {
                GVSampleInfo.SetRowCellValue(e.RowHandle, "creater", CommonData.UserInfo.names);
                GVSampleInfo.SetRowCellValue(e.RowHandle, "createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }


        private void 查看项目清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GVapplyInfo.GetFocusedDataRow() != null)
            {
                string applyNO = GVapplyInfo.GetFocusedDataRow()["no"].ToString();
                FrmItemInfo frmItemInfo = new FrmItemInfo(applyNO);
                frmItemInfo.ShowDialog();
            }
        }





        private void GVSampleInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent") != DBNull.Value)
            {
                if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent")))
                {
                    //e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;//改变背景色
                    //e.Appearance.BackColor = Color.Transparent;//改变背景色
                    e.Appearance.ForeColor = Color.Red;//改变字体颜色
                }
            }
        }

        private void GEhospitalNo_EditValueChanged(object sender, EventArgs e)
        {
            if (GEhospitalNo.EditValue != null)
            {
                //string hosptilcode = "";
                //if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Trim().Length > 5)
                //{
                //hosptilcode = TEbarcode.EditValue.ToString().Trim().Substring(0, 5);
                DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{GEhospitalNo.EditValue}'");
                if (dataRow.Count() > 0)
                {
                    GEagentNo.EditValue = dataRow[0]["agentNO"];
                    TEpersonalize.EditValue = dataRow[0]["personalize"];
                    GEagentNo.Enabled = false;
                }
                else
                {
                    if (GEhospitalNo.Enabled != false)
                    {
                        GEhospitalNo.EditValue = "";
                        GEagentNo.EditValue = "";
                        TEpersonalize.EditValue = "";
                        GEagentNo.Enabled = true;
                    }
                }
                //}
                //else
                //{
                //    DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{GEhospitalNo.EditValue}'");
                //    if (dataRow.Count() > 0)
                //    {
                //        GEagentNo.EditValue = dataRow[0]["agentNO"];
                //        TEpersonalize.EditValue = dataRow[0]["personalize"];
                //        //GEhospitalNo.Enabled = false;
                //    }
                //}
            }
        }

        #region hotKeys

        private void FrmSampleinfoEntry_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSampleinfoEntry_Activated(object sender, EventArgs e)
        {
            ////注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            /////////////HotKeys.RegisterHotKey(Handle, 100, HotKeys.KeyModifiers.Shift, Keys.S);
            HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F1);
            ////注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKeys.RegisterHotKey(Handle, 101, (uint)HotKeys.KeyModifiers.Ctrl, Keys.A);
            ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKeys.RegisterHotKey(Handle, 102, (uint)HotKeys.KeyModifiers.Ctrl, Keys.Z);

            HotKeys.RegisterHotKey(Handle, 103, (uint)HotKeys.KeyModifiers.Ctrl, Keys.Q);

            ///////////////HotKeys.RegisterHotKeys(Handle, 103, HotKeys.KeyModifiers.Shift, Keys.S);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:  //按下的是F1
                            dockPanel3_Click(null, null);
                            break;
                        case 101:  //按下的是delete
                            if (BTAdd.Enabled)
                                BTAdd_ItemClick(null, null);
                            break;
                        case 102:  //按下的是Ctrl+s
                            if (BTSave.Enabled)
                                BTSave_ItemClick(null, null);
                            break;
                            //case 103:  //按下的是Ctrl+q
                            //    BTNextPage_ItemClick(null, null);          //此处填写快捷键响应代码
                            //    break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        private void FrmSampleinfoEntry_Leave(object sender, EventArgs e)
        {

        }



        private void FrmSampleinfoEntry_Deactivate(object sender, EventArgs e)
        {
            HotKeys.UnregisterHotKey(Handle, 100);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKeys.UnregisterHotKey(Handle, 101);
            ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKeys.UnregisterHotKey(Handle, 102);
        }






        #endregion hotKeys
        /// <summary>
        /// 身份证判断年龄和性别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TEpatientCardNo_Leave(object sender, EventArgs e)
        {

            string identityCard = TEpatientCardNo.EditValue != null ? TEpatientCardNo.EditValue.ToString().Trim() : "";
            if (TEpatientCardNo.EditValue != null)
            {
                if (identityCard.Length == 15 || identityCard.Length == 18)//身份证号码只能为15位或18位其它不合法
                {
                    string strSex = string.Empty;
                    string Birthday = string.Empty;
                    if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
                    {
                        Birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                        strSex = identityCard.Substring(14, 3);
                    }
                    if (identityCard.Length == 15)
                    {
                        Birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                        strSex = identityCard.Substring(12, 3);
                    }

                    TEageYear.EditValue = CalculateAge(Birthday).ToString();//根据生日计算年龄
                    if (int.Parse(strSex) % 2 == 0)//性别代码为偶数是女性奇数为男性
                    {
                        GEpatientSexNO.EditValue = "2";
                    }
                    else
                    {
                        GEpatientSexNO.EditValue = "1";
                    }
         
                }
            }
        }
        /// <summary>
        /// 根据出生日期，计算精确的年龄
        /// </summary>
        /// <param name="birthDate">生日</param>
        /// <returns></returns>
        public static int CalculateAge(string birthDay)
        {
            DateTime birthDate = DateTime.Parse(birthDay);
            DateTime nowDateTime = DateTime.Now;
            int age = nowDateTime.Year - birthDate.Year;
            //再考虑月、天的因素
            if (nowDateTime.Month < birthDate.Month || (nowDateTime.Month == birthDate.Month && nowDateTime.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }

        private void DEsampleTime_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(DEsampleTime.EditValue);
            }
            catch
            {
                MessageBox.Show("输入时间格式有误，请重新输入");
                DEsampleTime.EditValue = null;
            }
            
        }
    }
}
