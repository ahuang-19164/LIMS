using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.HotKey;
using Common.JsonHelper;
using Common.LoadShow;
using Common.ManageModel;
using Common.Model;
using Common.PerModel;
using Common.SampleInfoEdit;
using Common.SqlModel;

using Common.TestModel.Result;
using Common.WorkModel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using WorkTest.UploadReport;

namespace workOther.ItemDelegate
{

    public partial class FrmDelegateResultInfo : DevExpress.XtraEditors.XtraForm
    {


        //Func<int, AutographInfo, string> func;//接收结果方法
        //Action<string, string, string> actionSampleInfo;//发送信息方法
        DataTable DTTestInfo;
        Form FrmTest;
        string GetEntrustInfo = "";
        string TestReceiveReturn = "";
        public static string FileImgPath = Environment.CurrentDirectory + "\\SaveTestDelImg";
        //string TestReceiveReturn = "";
        public FrmDelegateResultInfo()
        {
            InitializeComponent();
            DEStarTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GetEntrustInfo = ConfigInfos.ReadConfigInfo("GetEntrustInfo");
            TestReceiveReturn = ConfigInfos.ReadConfigInfo("TestReceiveReturn");



            //TestReceiveReturn = ConfigInfos.ReadConfigInfo("TestReceiveReturn");
            FrmUpReport frmUpReport = new FrmUpReport();
            ShowReportMethod = frmUpReport.showReport;
            formReport(frmUpReport);
            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);


            GridLookUpEdites.Formats(GESampleSates);
            GridLookUpEdites.Formats(RGEdelegateClientNO);
            //GridLookUpEdites.Formats(GESelectGroups);
            //GridLookUpEdites.Formats(GEpatientType);
            //GridLookUpEdites.Formats(GEpatientSex);
            //GridLookUpEdites.Formats(GEsampleShape);
            //GridLookUpEdites.Formats(GEsampleType);
            //GridLookUpEdites.Formats(GEagentNO);
            //GridLookUpEdites.Formats(GEhospitalNO);
            TextEdits.TextFormat(TEageYear);
            TextEdits.TextFormat(TEageMoth);
            TextEdits.TextFormat(TEageDay);
            SysPowerHelper.UserPower(barManager1);
            Formart("1");//格式化信息列表
        }


        private void FrmSampleTest_Load(object sender, EventArgs e)
        {

            RGEdelegateClientNO.DataSource = DTHelper.DTAddAll(DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo));
            GESampleSates.DataSource = DTHelper.DTAddAll(WorkCommData.DTStateTest);
            delegateClientNO.EditValue = 0;
            GESampleSate.EditValue = 0;

        }

        /// <summary>
        /// 切换组列表信息
        /// </summary>
        /// <param name="GroupTestNO"></param>
        private void Formart(string GroupTestNO)
        {

            GCSampleInfo.DataSource = null;
            PanelTestResult.Controls.Clear();
            GVSampleInfo.Columns.Clear();
            if (WorkCommData.DTGroupGridView != null)
            {
                if (WorkCommData.DTGroupGridView.Select($"testNO='{GroupTestNO}'").Count() > 0)
                {
                    DataTable data = WorkCommData.DTGroupGridView.Select($"testNO='{GroupTestNO}'").CopyToDataTable();
                    //GCSampleInfo.MainView=Common.ControlHandle.GridControls.ProduceGridView(GVSampleInfo,data);
                    GridControls.ProduceGridView(GVSampleInfo, data, true);
                    GridControls.showEmbeddedNavigator(GCSampleInfo);
                    GridControls.ShowViewColor(GVSampleInfo);

                    GVSampleInfo.OptionsView.ColumnAutoWidth = false;
                    GVSampleInfo.BestFitColumns();
                    //GridView的OptionView中的ColumnAutoWidth = False

                    //xtraTabPage2.Controls.Add(GridControls.ProduceGridControl(data));
                }
            }

        }
        //作用 加快界面加载 

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        //PanelTestResult内部切换窗体方法
        private void formResult(Form form)
        {

            foreach (Control item in this.PanelTestResult.Controls)
            {
                if (item is Form)
                {
                    Form ctl = (Form)item;
                    ctl.Close();
                    //((Form)item).Close();
                }
            }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.ControlBox = false;
            form.Parent = this.PanelTestResult;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        ////PanelTestResult内部切换窗体方法
        //private void formReport(Form form)
        //{
        //    foreach (Control item in this.PanelTestReport.Controls)
        //    {
        //        if (item is Form)
        //        {
        //            Form ctl = (Form)item;
        //            ctl.Close();
        //            //((Form)item).Close();
        //        }
        //    }
        //    form.TopLevel = false;
        //    form.FormBorderStyle = FormBorderStyle.None;
        //    //form.ControlBox = false;
        //    form.Parent = this.PanelTestReport;
        //    form.Dock = DockStyle.Fill;
        //    form.Show();
        //}



        string reflectionFile = "";
        string reflectionFrm = "";
        MethodInfo postResultInfos;
        MethodInfo setResultInfos;
        MethodInfo FrmOtherSet;
        Type frmtype;
        object objpostResultInfo;
        DataRow SampleInfoRow;//样本信息
        int perid = 0;
        int testid = 0;
        int delid = 0;
        string barcode = "";
        string groupNO = "";
        string groupFlowNO = "";
        string hospitalNo = "";
        string testStateNO = "";

        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            try
            {

                PCImg.Controls.Clear();
                pictureEditLocationxs = 0;
                SampleInfoRow = GVSampleInfo.GetFocusedDataRow();
                if (SampleInfoRow != null)
                {
                    //if(!Convert.IsDBNull(SampleInfoRow["testStateNO"]))
                    //{
                    //    if (Convert.ToInt32(SampleInfoRow["testStateNO"]) >= 3)
                    //    {
                    //        PanelTestResult.Enabled = false;
                    //    }
                    //    else
                    //    {
                    //        PanelTestResult.Enabled = true;
                    //    }
                    //}
                    perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                    testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                    delid = SampleInfoRow["delid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["delid"]) : 0;
                    barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString() : "";
                    hospitalNo = SampleInfoRow["hospitalNo"] != DBNull.Value ? SampleInfoRow["hospitalNo"].ToString() : "";
                    testStateNO = SampleInfoRow["testStateNO"] != DBNull.Value ? SampleInfoRow["testStateNO"].ToString() : "";
                    //barcode = SampleInfoRow["barcode"].ToString();
                    //TEsampleID
                    //PathologyNo = SampleInfoRow["pathologyNo"].ToString();
                    groupNO = SampleInfoRow["groupNO"].ToString();
                    DEsampleTime.EditValue = SampleInfoRow["sampleTime"];
                    TEageDay.EditValue = SampleInfoRow["ageDay"];
                    TEageMoth.EditValue = SampleInfoRow["ageMoth"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    GEagentNO.EditValue = SampleInfoRow["agentNO"];
                    TEageYear.EditValue = SampleInfoRow["ageYear"];
                    MEapplyItemNames.EditValue = SampleInfoRow["itemNames"];
                    TEbarcode.EditValue = SampleInfoRow["barcode"];
                    TEbedNo.EditValue = SampleInfoRow["bedNo"];
                    MEclinicalDiagnosis.EditValue = SampleInfoRow["clinicalDiagnosis"];
                    TEcutPart.EditValue = SampleInfoRow["cutPart"];
                    TEdepartment.EditValue = SampleInfoRow["department"];
                    TEdoctorPhone.EditValue = SampleInfoRow["doctorPhone"];
                    GEhospitalNo.EditValue = SampleInfoRow["hospitalNames"];
                    TEmedicalNo.EditValue = SampleInfoRow["medicalNo"];
                    DEmenstrualTime.EditValue = SampleInfoRow["menstrualTime"];
                    TEpathologyNo.EditValue = SampleInfoRow["pathologyNo"];
                    DEreceiveTime.EditValue = SampleInfoRow["receiveTime"];
                    //TEpatientAddress.EditValue = SampleInfoRow["patientAddress"];
                    TEpatientCardNO.EditValue = SampleInfoRow["patientCardNo"];
                    TEpatientPhone.EditValue = SampleInfoRow["patientPhone"];
                    GEpatientSex.EditValue = SampleInfoRow["patientSexNames"];
                    GEpatientType.EditValue = SampleInfoRow["patientTypeNames"];
                    MEperRemark.EditValue = SampleInfoRow["perRemark"];
                    TEsampleID.EditValue = SampleInfoRow["id"];
                    GEsampleShape.EditValue = SampleInfoRow["sampleShapeNames"];
                    GEsampleType.EditValue = SampleInfoRow["sampleTypeNames"];
                    TEsendDoctor.EditValue = SampleInfoRow["sendDoctor"];
                    METestRemark.EditValue = SampleInfoRow["testRemark"];
                    CEurgent.Checked = SampleInfoRow["urgent"]!=DBNull.Value? Convert.ToBoolean(SampleInfoRow["urgent"]):false;

                    //TEatester.EditValue = SampleInfoRow["tester"];
                    ////if(!Convert.IsDBNull(SampleInfoRow["testTime"]))
                    ////    DEatestTime.EditValue = Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    //DEatestTime.EditValue = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                    //TEachecker.EditValue = SampleInfoRow["checker"];
                    ////if (!Convert.IsDBNull(SampleInfoRow["checkTime"])) 
                    ////    DEacheckTime.EditValue = Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    //DEacheckTime.EditValue = SampleInfoRow["checkTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                    TEatester.EditValue = SampleInfoRow["tester"];
                    DEatestTime.EditValue = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                    //TEtester.EditValue = SampleInfoRow["tester"];
                    //DEtestTime.EditValue = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                    TEachecker.EditValue = SampleInfoRow["checker"];
                    DEacheckTime.EditValue = SampleInfoRow["checkTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;

                    string groupFlowNOs = SampleInfoRow["groupFlowNO"] != DBNull.Value && SampleInfoRow["groupFlowNO"].ToString() != "" ? SampleInfoRow["groupFlowNO"].ToString() : "1";



                    //actionSampleInfo(SampleID, barcode, PathologyNo);

                    //frmWait.HideMe(this);

                    if (WorkCommData.DTItemFlow != null)
                    {
                        if (groupFlowNOs != groupFlowNO)
                        {
                            groupFlowNO = groupFlowNOs;
                            if (WorkCommData.DTItemFlow.Select($"no='{groupFlowNO}'").Count() > 0)
                            {
                                DataRow dataRow = WorkCommData.DTItemFlow.Select($"no='{groupFlowNO}'")[0];

                                if (!Convert.IsDBNull(dataRow["reflectionFile"]) && !Convert.IsDBNull(dataRow["reflectionFrm"]))
                                {
                                    reflectionFile = dataRow["reflectionFile"].ToString();
                                    reflectionFrm = dataRow["reflectionFrm"].ToString();

                                    //form(ReflectionHelper.CreateForm(reflectionFrm, reflectionFile, this));

                                    try
                                    {
                                        if (!ReflectionHelper.ShowChildForm(reflectionFrm, this))
                                        {


                                            string name = reflectionFile + "." + reflectionFrm; //类的名字
                                            Assembly ass = Assembly.Load(reflectionFile);
                                            //Form doc = (Form)ass.CreateInstance(name);
                                            //form(doc);

                                            frmtype = ass.GetType(name);//类名
                                            objpostResultInfo = Activator.CreateInstance(frmtype);
                                            FrmTest = (Form)objpostResultInfo;
                                            form(FrmTest);
                                            //FrmTestClose = frmtype.GetMethod("formClose");
                                            postResultInfos = frmtype.GetMethod("postResultInfo");
                                            setResultInfos = frmtype.GetMethod("setResultInfo");
                                            FrmOtherSet = frmtype.GetMethod("setOtherInfo");

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        MessageBox.Show("文件加载错误" + ex.ToString(), "系统提示");
                                    }
                                }
                                else
                                {
                                    reflectionFile = "WorkTest.Test";
                                    reflectionFrm = "FrmTest";
                                    try
                                    {
                                        if (!ReflectionHelper.ShowChildForm(reflectionFrm, this))
                                        {

                                            string name = reflectionFile + "." + reflectionFrm; //类的名字
                                            Assembly ass = Assembly.Load(reflectionFile);
                                            frmtype = ass.GetType(name);//类名
                                            objpostResultInfo = Activator.CreateInstance(frmtype);

                                            //objpostResultInfo = Assembly.Load(reflectionFile).GetType(name);
                                            FrmTest = (Form)objpostResultInfo;
                                            form(FrmTest);
                                            //FrmTestClose = frmtype.GetMethod("formClose");
                                            postResultInfos = frmtype.GetMethod("postResultInfo");
                                            setResultInfos = frmtype.GetMethod("setResultInfo");
                                            FrmOtherSet = frmtype.GetMethod("setOtherInfo");

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("未匹配到流程文件信息", "系统提示");
                            }
                        }

                    }
                    else
                    {

                        reflectionFile = "WorkTest.Test";
                        reflectionFrm = "FrmTest";

                        //form(ReflectionHelper.CreateForm(reflectionFrm, reflectionFile, this));

                        try
                        {
                            if (!ReflectionHelper.ShowChildForm(reflectionFrm, this))
                            {

                                string name = reflectionFile + "." + reflectionFrm; //类的名字
                                Assembly ass = Assembly.Load(reflectionFile);
                                //Form doc = (Form)ass.CreateInstance(name);
                                //form(doc);

                                frmtype = ass.GetType(name);//类名
                                objpostResultInfo = Activator.CreateInstance(frmtype);
                                FrmTest = (Form)objpostResultInfo;
                                form(FrmTest);
                                //FrmTestClose = frmtype.GetMethod("formClose");
                                postResultInfos = frmtype.GetMethod("postResultInfo");
                                setResultInfos = frmtype.GetMethod("setResultInfo");
                                FrmOtherSet = frmtype.GetMethod("setOtherInfo");

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    //object[] paras = new object[] { testid, barcode, groupNO, groupFlowNO };
                    object[] paras = new object[] { testid, SampleInfoRow, 1 };//1  表示委托检验

                    setResultInfos.Invoke(objpostResultInfo, paras);
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "WorkTest.DelegateImg";
                    sInfo.values = "filestring";
                    sInfo.wheres = $"testid='{testid}' and dstate=0";
                    sInfo.OrderColumns = "createTime desc";
                    DataTable DTImg = ApiHelpers.postInfo(sInfo);
                    if (DTImg != null && DTImg.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in DTImg.Rows)
                        {
                            Bitmap bitmapsa = FileConverHelpers.StringToBitmap(dataRow[0].ToString());
                            if (bitmapsa != null)
                            {
                                NewPictureEdit(bitmapsa);
                            }

                        }


                    }
                    //Bitmap bitmaps = ImageCompressHelper.SizeImage(bitmap);
                }
                else
                {
                    testid = 0;
                    barcode = "";
                    groupNO = "";
                    //PathologyNo = "";
                    MessageBox.Show("没有获取到可用的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //frmWait.HideMe(this);
                }
            }
            catch (Exception ex)
            {
                testid = 0;
                barcode = "";
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //PathologyNo = "";
            }

        }



        #region barmannage 按钮实现

        /// <summary>
        /// 修改状态方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //layoutControl1.Enabled = true;
            int[] samplesDt = GVSampleInfo.GetSelectedRows();
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("perid");
            data.Columns.Add("barcode");
            data.Columns.Add("patientName");



            foreach (int a in samplesDt)
            {
                if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                {
                    if (Convert.ToInt32(SampleInfoRow["testStateNO"]) != 6)
                    {
                        data.Rows.Add(GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["perid"], GVSampleInfo.GetDataRow(a)["barcode"], GVSampleInfo.GetDataRow(a)["patientName"]);
                    }
                }

            }
            FrmSampleInfoEdit frmSampleInfoEdit = new FrmSampleInfoEdit(data);
            frmSampleInfoEdit.ShowDialog();
        }
        /// <summary>
        /// 保存信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl1.Enabled = false;
        }


        #endregion

        #region 保存结果方法


        /// <summary>
        /// 保存结果方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSaveResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"检测结果上传", "正在上传检测结果请稍后......");
            try
            {
                if (testid != 0 && barcode != "")
                {
                    if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 4|| Convert.ToInt32(SampleInfoRow["testStateNO"]) == 6)
                    {
                        MessageBox.Show("样本信息已审核。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                    else
                    {
                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 5)
                        {
                            if (SaveResult(1))
                            {
                                TEatester.EditValue = CommonData.UserInfo.names;
                                DEatestTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                //GVSampleInfo.SetFocusedRowCellValue("tester", CommonData.UserInfo.names);
                                //GVSampleInfo.SetFocusedRowCellValue("testTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                SampleInfoRow["tester"] = CommonData.UserInfo.names;
                                SampleInfoRow["testTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                if (PCImg.Controls.Count > 0)
                                {
                                    if (!Directory.Exists(FileImgPath))
                                    {
                                        Directory.CreateDirectory(FileImgPath);
                                    }

                                    int a = 1;
                                    string fileString = "";
                                    foreach (Control control in PCImg.Controls)
                                    {
                                        string FileSavePath = FileImgPath + "\\" + barcode + "-" + a.ToString() + ".png";
                                        PictureEdit pictureEdit = control as PictureEdit;
                                        Bitmap bitmap = new Bitmap(pictureEdit.Image);
                                        if (File.Exists(FileSavePath))
                                        {
                                            File.Delete(FileSavePath);
                                        }
                                        Bitmap bitmaps = ImageCompressHelper.SizeImage(bitmap);
                                        bitmaps.Save(FileSavePath, ImageFormat.Png);
                                        string ssss = FileConverHelpers.BitmapTostring(bitmaps);
                                        fileString += ssss + ",";
                                        bitmaps.Dispose();
                                    }
                                    uInfo uInfo = new uInfo();
                                    uInfo.TableName = "WorkTest.DelegateImg";
                                    uInfo.value = "dstate=1";
                                    uInfo.wheres = $"delid={delid}";
                                    uInfo.MessageShow = 1;
                                    ApiHelpers.postInfo(uInfo);

                                    iInfo iInfo = new iInfo();
                                    iInfo.TableName = "WorkTest.DelegateImg";
                                    iInfo.MessageShow = 1;
                                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                                    pairs.Add("dstate", 0);
                                    pairs.Add("state", 1);
                                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    pairs.Add("sort", 0);
                                    pairs.Add("barcode", TEbarcode.EditValue);
                                    pairs.Add("className", "委托原单");
                                    pairs.Add("filestring", fileString.Substring(0, fileString.Length - 1));
                                    pairs.Add("perid", perid);
                                    pairs.Add("testid", testid);
                                    iInfo.values = pairs;
                                    ApiHelpers.postInfo(iInfo);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("样本信息未确认委托。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择样本信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                frmWait.HideMe(this);
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            frmWait.HideMe(this);
            testState();
        }


        #endregion




        //panl内部切换窗体方法
        private void form(Form form)
        {
            foreach (Control item in this.PanelTestResult.Controls)
            {
                if (item is Form)
                {
                    Form ctl = (Form)item;
                    ctl.Close();
                    //((Form)item).Close();
                }
            }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.ControlBox = false;
            form.Parent = this.PanelTestResult;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        /// <summary>
        /// 标本结果保存
        /// </summary>
        /// <param name="testStateNO">检验状态信息编号</param>
        public bool SaveResult(int testStateNO)
        {
            try
            {
                bool SaveState = false;
                if (testid != 0)
                {

                    AutographInfo autographInfo = new AutographInfo();
                    autographInfo.tester = CommonData.UserInfo.names;
                    autographInfo.checker = CommonData.UserInfo.names;
                    autographInfo.testRemark = METestRemark.EditValue == null ? "" : METestRemark.EditValue.ToString();
                    autographInfo.state = false; ;
                    //object[] paras = new object[] { testStateNO, testid, barcode, groupNO, groupFlowNO, autographInfo };
                    object[] paras = new object[] { testStateNO, perid, testid, "", barcode, groupNO, groupFlowNO, autographInfo };
                    string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();
                    if (ReturnState != "")
                    //if (postResultInfos.Invoke(objpostResultInfo, paras).ToString() != "0")
                    {
                        try
                        {

                            commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                            //commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                            if (commReInfo.code == 0)
                            {
                                if (commReInfo.nextFlowNO != null && commReInfo.nextFlowNO != "0")
                                    SampleInfoRow["groupFlowNO"] = commReInfo.nextFlowNO;
                                //SampleInfoRow["testStateNO"] = testStateNO;
                                SampleInfoRow["testRemark"] = autographInfo.testRemark;
                                //if (testStateNO == 1)
                                //{
                                //    SampleInfoRow["tester"] = CommonData.UserInfo.names;
                                //    SampleInfoRow["testTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //    SampleInfoRow["realtester"] = CommonData.UserInfo.names;
                                //}

                                //if (testStateNO == 2)
                                //{
                                //    SampleInfoRow["reTester"] = CommonData.UserInfo.names;
                                //    SampleInfoRow["reTestTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //    SampleInfoRow["realreTester"] = CommonData.UserInfo.names;
                                //}

                                //if (testStateNO == 3)
                                //{
                                //    SampleInfoRow["checker"] = CommonData.UserInfo.names;
                                //    SampleInfoRow["checkTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //    SampleInfoRow["realchecker"] = CommonData.UserInfo.names;
                                //}
                                SaveState = true;
                                //GVSampleInfo_RowClick(null, null);

                            }
                            else
                            {
                                SaveState = false;
                                MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show(ReturnState, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }



                    testState();
                }
                else
                {
                    MessageBox.Show("请先选择需要保存的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                return SaveState;
            }
            catch (Exception ex)
            {

                throw ex;
                //MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        public void SetOtherInfo(string a)
        {
            if (FrmOtherSet != null)
            {
                object[] paras = new object[] { a };
                object aaaa = FrmOtherSet.Invoke(objpostResultInfo, paras);
            }
        }

        #region hotKeys



        private void FrmSampleTest_Enter(object sender, EventArgs e)
        {
            HotKeys.RegisterHotKey(Handle, 110, 0, Keys.F1);
            HotKeys.RegisterHotKey(Handle, 111, 0, Keys.F2);
            HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F5);
            HotKeys.RegisterHotKey(Handle, 101, 0, Keys.F6);
            HotKeys.RegisterHotKey(Handle, 102, 0, Keys.F7);
        }

        private void FrmSampleTest_Leave(object sender, EventArgs e)
        {
            HotKeys.UnregisterHotKey(Handle, 110);
            HotKeys.UnregisterHotKey(Handle, 111);
            HotKeys.UnregisterHotKey(Handle, 100);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKeys.UnregisterHotKey(Handle, 101);
            ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKeys.UnregisterHotKey(Handle, 102);
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
                        case 110:  //按下的是F1
                            SetOtherInfo("1");
                            break;
                        case 111:  //按下的是F2
                            SetOtherInfo("2");
                            break;
                        case 100:  //按下的是F5
                            if (BTSaveResult.Enabled)
                                BTSaveResult_ItemClick(null, null);

                            break;
                        case 101:  //按下的是F6
                            //if (BTSaveReResult.Enabled)
                            //    BTSaveReResult_ItemClick(null, null);
                            break;
                        case 102:  //按下的是F7
                            //if (BTChecked.Enabled)
                            //    BTChecked_ItemClick(null, null);
                            break;
                            //case 103:  //按下的是Ctrl+q
                            //    BTNextPage_ItemClick(null, null);          //此处填写快捷键响应代码
                            //    break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        #endregion hotKeys

        private void GVSampleInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //gridView1_Click(null,null) ;

        }
        /// <summary>
        /// 行变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVSampleInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {


            if (GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent") != DBNull.Value)
            {
                if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent")))
                {
                    //e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));//改变背景色
                    //e.Appearance.BackColor2 = Color.LightCyan;//改变背景色
                    //e.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));//字体颜色
                    e.Appearance.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ManageInfoModel selectDelInfo = new ManageInfoModel();
            selectDelInfo.StartTime = Convert.ToDateTime(Convert.ToDateTime(DEStarTime.EditValue).ToString("yyyy-MM-dd"));
            selectDelInfo.EndTime = Convert.ToDateTime(Convert.ToDateTime(DEEndTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd"));
            selectDelInfo.patientName = TEPatientNames.EditValue != null ? TEPatientNames.EditValue.ToString() : "";
            selectDelInfo.barcode = TEBarcodes.EditValue != null ? TEBarcodes.EditValue.ToString() : "";
            string sr = JsonHelper.SerializeObjct(selectDelInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(GetEntrustInfo, sr);
            DataTable dataTable = DTTestInfo = JsonHelper.StringToDT(jm);
            GCSampleInfo.DataSource = dataTable;
            GVSampleInfo.BestFitColumns();
            testState();
        }

        /// <summary>
        /// 标本信息状态统计方法
        /// </summary>
        public void testState()
        {
            try
            {
                if (DTTestInfo != null)
                {
                    //LCWait.Text = $"等待处理({DTTestInfo.Select("delegateStateNO='2'").Count()})";
                    LCResult.Text = $"等待结果({DTTestInfo.Select("delegateStateNO='3'").Count()})";
                    LCFinish.Text = $"委托完成({DTTestInfo.Select("delegateStateNO='4'").Count()})";
                }
                else
                {
                    //LCWait.Text = $"等待处理(0)";
                    LCResult.Text = $"等待结果(0)";
                    LCFinish.Text = $"委托完成(0)";
                }
            }
            catch
            {

            }

        }

        private void BTUp_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = OpenFileHelpers.GetFilePath(FileExtensionName.img);
                if (FilePath.Length != 0)
                {
                    Bitmap bitmap = new Bitmap(FilePath);
                    Bitmap bitmaps = new Bitmap(bitmap);
                    NewPictureEdit(bitmaps);
                    bitmap.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        int pictureEditLocationxs = 0;


        /// <summary>
        /// PictureEdit
        /// </summary>
        /// <param name="PictureName">图片名称</param>
        /// <param name="pictureDye">染色倍数</param>
        /// <param name="bitmap">图像</param>
        private void NewPictureEdit(Bitmap bitmap)
        {
            try
            {

                if (bitmap != null)
                {
                    int a = PCImg.Controls.Count + 1;

                    PictureEdit Pedit = new PictureEdit();

                    Pedit.Location = new System.Drawing.Point(pictureEditLocationxs, 0);
                    Pedit.Size = new Size(200, PCImg.Size.Height);
                    Pedit.Image = bitmap;
                    Pedit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    Pedit.Click += Pedit_Click;
                    Pedit.DoubleClick += Pedit_DoubleClick; ;
                    PCImg.Controls.Add(Pedit);
                    pictureEditLocationxs += 200;


                }
            }
            catch
            {
                MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pedit_DoubleClick(object sender, EventArgs e)
        {
            pictureEdit = (PictureEdit)sender;
            Bitmap bitmap = (Bitmap)pictureEdit.Image;
            ShowImgHelper.ViewOrignalImage(bitmap);
        }

        PictureEdit pictureEdit;
        private void Pedit_Click(object sender, EventArgs e)
        {
            pictureEdit = (PictureEdit)sender;

        }
        private void BTDown_Click(object sender, EventArgs e)
        {
            if (pictureEdit != null)
            {
                DialogResult dialogResult = MessageBox.Show("是否确定删除此照片？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    PCImg.Controls.Remove(pictureEdit);
                    int xx = 0;
                    foreach (Control control in PCImg.Controls)
                    {
                        control.Location = new System.Drawing.Point(xx, 0);
                        xx += 200;
                    }
                    if (pictureEditLocationxs > 0)
                    {
                        pictureEditLocationxs -= 200;
                    }
                }
            }

        }

        private void PCImg_Click(object sender, EventArgs e)
        {
            //var control=PCImg.cont
        }

        private void BTEnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {



                testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                if (testid != 0)
                {
                    string tester = dataRow["tester"] != DBNull.Value ? SampleInfoRow["tester"].ToString() : "";
                    if (tester != "")
                    {
                        uInfo uInfo = new uInfo();
                        uInfo.TableName = "WorkTest.SampleInfo";
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("testStateNO", "3");
                        pairs.Add("checker", CommonData.UserInfo.names);
                        pairs.Add("checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        pairs.Add("realchecker", CommonData.UserInfo.names);
                        pairs.Add("realcheckTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        uInfo.values = pairs;
                        uInfo.wheres = $"id={testid}";
                        uInfo.MessageShow = 1;
                        int a= ApiHelpers.postInfo(uInfo);
                        if(a!=0)
                        {
                            uInfo uInfo2 = new uInfo();
                            uInfo2.TableName = "WorkOther.DelegeteRecord";
                            Dictionary<string, object> pairsd = new Dictionary<string, object>();
                            pairsd.Add("checker", CommonData.UserInfo.names);
                            pairsd.Add("checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //uInfo2.value = "delegateStateNO='4'";
                            uInfo2.values = pairsd;
                            uInfo2.wheres = $"testid={testid}";
                            uInfo2.MessageShow = 1;
                            a=ApiHelpers.postInfo(uInfo2);
                            //ApiHelpers.postInfo(uInfo);
                            dataRow["testStateNO"] = '3';
                            //dataRow["delegateStateNO"] = '4';
                            if (dataRow != null&& a!=0)
                            {
                                TEachecker.EditValue = CommonData.UserInfo.names;
                                DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //GVSampleInfo.SetFocusedRowCellValue("achecker", CommonData.UserInfo.names);
                                //GVSampleInfo.SetFocusedRowCellValue("acheckTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                //GVSampleInfo.SetFocusedRowCellValue("testStateNO", 3);

                                SampleInfoRow["achecker"] = CommonData.UserInfo.names;
                                SampleInfoRow["acheckTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                SampleInfoRow["testStateNO"] = 3;
                                //GVSampleInfo.SetFocusedRowCellValue("delegateStateNO", 4);
                                GVSampleInfo.BestFitColumns();


                                uInfo uInfo3 = new uInfo();
                                uInfo3.TableName = "WorkPer.SampleInfo";
                                Dictionary<string, object> pairs3 = new Dictionary<string, object>();
                                pairs3.Add("perStateNO", 4);
                                //pairsd3.Add("checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                //uInfo2.value = "delegateStateNO='4'";
                                uInfo3.values = pairs3;
                                uInfo3.wheres = $"id={perid}";
                                uInfo3.MessageShow = 1;
                                a = ApiHelpers.postInfo(uInfo3);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("请保存结果信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("没有获取到可用的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void BTReEnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认退回委托结果？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
                if (dataRow != null)
                {
                    if (testid != 0)
                    {
                        uInfo uInfo = new uInfo();
                        uInfo.TableName = "WorkTest.SampleInfo";
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("tester", "");
                        pairs.Add("testTime",null);
                        pairs.Add("realtester", "");
                        pairs.Add("realtestTime", null);
                        pairs.Add("checker", "");
                        pairs.Add("checkTime", null);
                        pairs.Add("realchecker", "");
                        pairs.Add("realcheckTime", null);
                        pairs.Add("testStateNO", "5");
                        uInfo.values = pairs;
                        uInfo.wheres = $"id={testid}";
                        uInfo.MessageShow = 1;
                        ApiHelpers.postInfo(uInfo);



                        uInfo uInfo2 = new uInfo();
                        uInfo2.TableName = "WorkOther.DelegeteRecord";
                        Dictionary<string, object> pairsd = new Dictionary<string, object>();
                        pairsd.Add("checker", "");
                        pairsd.Add("checkTime", null);
                        uInfo2.values = pairsd;
                        //uInfo2.value = "delegateStateNO='2'";
                        uInfo2.wheres = $"testid={testid}";
                        uInfo2.MessageShow = 1;
                        ApiHelpers.postInfo(uInfo2);


                        uInfo uInfo3 = new uInfo();
                        uInfo3.TableName = "WorkPer.SampleInfo";
                        Dictionary<string, object> pairs3 = new Dictionary<string, object>();
                        pairs3.Add("perStateNO", 3);
                        //pairsd3.Add("checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //uInfo2.value = "delegateStateNO='4'";
                        uInfo3.values = pairs3;
                        uInfo3.wheres = $"id={perid}";
                        uInfo3.MessageShow = 1;
                        ApiHelpers.postInfo(uInfo3);



                        TEatester.EditValue = null;
                        DEatestTime.EditValue = null;
                        TEachecker.EditValue = null;
                        DEacheckTime.EditValue = null;

                        dataRow["testStateNO"] = 5;
                        dataRow["tester"] = "";
                        dataRow["testTime"] = DBNull.Value;
                        dataRow["checker"] = "";
                        dataRow["checkTime"] = DBNull.Value;
                        dataRow["achecker"] = "";
                        dataRow["acheckTime"] = DBNull.Value;

                        GVSampleInfo.BestFitColumns();
                        //dataRow["delegateStateNO"] = '2';
                        //if (dataRow != null)
                        //{

                        //    TEatester.EditValue = null;
                        //    DEatestTime.EditValue = null;
                        //    TEachecker.EditValue = null;
                        //    DEacheckTime.EditValue = null;



                        //    GVSampleInfo.SetFocusedRowCellValue("tester", "");
                        //    GVSampleInfo.SetFocusedRowCellValue("testTime", DBNull.Value);
                        //    GVSampleInfo.SetFocusedRowCellValue("checker", "");
                        //    GVSampleInfo.SetFocusedRowCellValue("checkTime", DBNull.Value);
                        //    GVSampleInfo.SetFocusedRowCellValue("testStateNO", 5);
                        //    //GVSampleInfo.SetFocusedRowCellValue("delegateStateNO", 2);
                        //    GVSampleInfo.BestFitColumns();
                        //}
                    }
                    else
                    {
                        MessageBox.Show("没有获取到可用的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        #region 上传报告
        Action<int, int, string, string,string> ShowReportMethod = null;

        bool showReportState = false;
        private void xtraTabPage2_Click(object sender, EventArgs e)
        {
            showReportState = true;
            if (perid != 0 && testid != 0)
                ShowReportMethod(perid, testid, barcode, hospitalNo,testStateNO);

        }

        private void xtraTabPage1_Click(object sender, EventArgs e)
        {
            showReportState = false;

        }
        private void formReport(Form form)
        {

            foreach (Control item in this.PanelTestReport.Controls)
            {
                if (item is Form)
                {
                    Form ctl = (Form)item;
                    ctl.Close();
                }
            }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.ControlBox = false;
            form.Parent = this.PanelTestReport;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void xtraTabPage2_ChangeUICues(object sender, UICuesEventArgs e)
        {
            showReportState = true;
            if (perid != 0 && testid != 0)
                ShowReportMethod(perid, testid, barcode, hospitalNo, testStateNO);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //通过不同的TabPage名称，加载对应方法

            if (e.Page.Name == "xtraTabPage1")
            {
                showReportState = false;
            }

            else if (e.Page.Name == "xtraTabPage2")
            {

                showReportState = true;
                if (perid != 0 && testid != 0)
                    ShowReportMethod(perid, testid, barcode, hospitalNo,testStateNO);

            }
        }
        #endregion

        private void BTSampleReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetSelectedRows().Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("确定需要退回样本信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    ReceiveInfoModel receiveInfoModel = new ReceiveInfoModel();
                    receiveInfoModel.UserName = CommonData.UserInfo.names;




                    List<ReceiveSampleInfoModel> receiveInfos = new List<ReceiveSampleInfoModel>();
                    int[] a = GVSampleInfo.GetSelectedRows();
                    foreach (int s in a)
                    {
                        ReceiveSampleInfoModel receiveInfo = new ReceiveSampleInfoModel();

                        DataRow dataRow = GVSampleInfo.GetDataRow(s);


                        receiveInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                        receiveInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        receiveInfo.sampleid = dataRow["sampleID"] != DBNull.Value ? dataRow["sampleID"].ToString() : ""; ;
                        receiveInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : ""; ;
                        //receiveInfo.testNo = dataRow["testNo"] != DBNull.Value ? dataRow["testNo"].ToString() : ""; ;
                        //receiveInfo.frameNo = dataRow["frameNo"] != DBNull.Value ? dataRow["frameNo"].ToString() : ""; ;
                        receiveInfos.Add(receiveInfo);
                    }
                    if (receiveInfos.Count > 0)
                    {
                        receiveInfoModel.ReceiveInfos = receiveInfos;

                        string Sr = JsonHelper.SerializeObjct(receiveInfoModel);
                        WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveReturn, Sr);

                        commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                        if (commReInfo.code == 0)
                        {

                            MessageBox.Show("退回成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PanelTestResult.Controls.Clear();
                            groupFlowNO = "------";
                            BTSelect_ItemClick (null, null);

                        }
                        else
                        {
                            MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要退回的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

