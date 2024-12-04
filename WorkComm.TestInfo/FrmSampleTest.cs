using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.HotKey;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.PerModel;
using Common.SampleInfoEdit;
using Common.SampleRecord;
using Common.SqlModel;

using Common.TestModel;
using Common.TestModel.Result;
using Common.WorkModel;
using Ms.HJInfoHandle;
using Perwork.SampleInfoReceive;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using workOther.ItemDelegate;
using workOther.ItemHandle;
using workOther.SyntheticalInfo;
using WorkTest.UploadReport;

namespace WorkComm.TestInfo
{

    public partial class FrmSampleTest : DevExpress.XtraEditors.XtraForm
    {


        //Func<int, AutographInfo, string> func;//接收结果方法
        //Action<string, string, string> actionSampleInfo;//发送信息方法
        DataTable DTTestInfo;
        Form FrmTest;
        string TestReceiveInfo = "";
        string TestReceiveReturn = "";
        string GetTestInfo = "";
        string TestSampleResultSelect = "";
        string TestItemInfoRefresh = "";

        Action<int,int,string,string,string> ShowReportMethod = null;
        public FrmSampleTest()
        {
            InitializeComponent();
            DEStarTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            TestReceiveInfo = ConfigInfos.ReadConfigInfo("TestReceiveInfo");
            TestReceiveReturn = ConfigInfos.ReadConfigInfo("TestReceiveReturn");
            GetTestInfo = ConfigInfos.ReadConfigInfo("GetTestInfo");
            TestSampleResultSelect = ConfigInfos.ReadConfigInfo("TestSampleResultSelect");
            TestItemInfoRefresh = ConfigInfos.ReadConfigInfo("TestItemInfoRefresh");


            FrmUpReport frmUpReport = new FrmUpReport();
            ShowReportMethod = frmUpReport.showReport;
            formReport(frmUpReport);





            GridLookUpEdites.Formats(GESampleSates);
            GridLookUpEdites.Formats(GESelectGroups);
            //GridLookUpEdites.Formats(GEpatientType);
            //GridLookUpEdites.Formats(GEpatientSex);
            //GridLookUpEdites.Formats(GEsampleShape);
            //GridLookUpEdites.Formats(GEsampleType);
            //GridLookUpEdites.Formats(GEagentNO);
            //GridLookUpEdites.Formats(GEhospitalNO);
            TextEdits.TextFormat(TEageYear);
            TextEdits.TextFormat(TEageMoth);
            TextEdits.TextFormat(TEageDay);

        }

        string FrmWorkNO = "";


        public void FrmLoad(object BTTag)
        {
            BTIHC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            string FrmTag = BTTag.ToString();
            switch (FrmTag)
            {
                case "140101":
                    FrmWorkNO = "5";//常规检验
                    break;
                case "140201":
                    BTIHC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    FrmWorkNO = "3";//病理检验
                    break;
                case "140301":
                    FrmWorkNO = "4";//特殊检验
                    break;
                case "140102":
                    FrmWorkNO = "6";//微生物检验
                    break;
                case "140303":
                    FrmWorkNO = "8";//核酸质谱组
                    break;
                default:
                    FrmWorkNO = "5";//默认
                    break;
            }
        }

        private void FrmSampleTest_Load(object sender, EventArgs e)
        {




            FrmPower();


            GESampleSates.DataSource = DTHelper.DTAddAll(WorkCommData.DTStateTest);
            GESampleSate.EditValue = 0;
            GESelectGroups.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);

            //GEpatientType.Properties.DataSource = WorkCommData.DTTypePatient;
            //GEsampleShape.Properties.DataSource = WorkCommData.DTTypeShape;
            //GEsampleType.Properties.DataSource = WorkCommData.DTTypeSample;
            //GEagentNO.Properties.DataSource = WorkCommData.DTClientAgent;
            //GEhospitalNO.Properties.DataSource = WorkCommData.DTClientInfo;
            //GEpatientSex.Properties.DataSource = WorkCommData.DTTypeSex;


            if (!CEEditCheck.Checked)
            {
                DEtestTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                DEcheckTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                TEtester.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                TEchecker.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            //layoutControl1.Enabled = false;



        }

        bool reviewState = false;//复审状态
        bool trequal = false;//允许检验者/复审者相同
        bool tcequal = false;//允许检验者/审核者相同
        bool rcequal = false;//允许复审者/审核者相同
        bool reportReturn = false;//打印反审权限
        /// <summary>
        /// 设置组权限信息
        /// </summary>
        public void GroupPower(string GroupTestNO)
        {
            if (WorkCommData.DTGroupTest != null)
            {
                if (WorkCommData.DTGroupTest.Select($"no='{GroupTestNO}'") != null)
                {
                    if (WorkCommData.DTGroupTest.Select($"no='{GroupTestNO}'").Count() == 1)
                    {
                        DataRow dataRow = WorkCommData.DTGroupTest.Select($"no='{GroupTestNO}'")[0];
                        reviewState = Convert.ToBoolean(dataRow["reviewState"]);
                        trequal = Convert.ToBoolean(dataRow["trequal"]);
                        tcequal = Convert.ToBoolean(dataRow["tcequal"]);
                        rcequal = Convert.ToBoolean(dataRow["rcequal"]);
                    }
                }
            }
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
        /// <summary>
        /// barmannage权限信息
        /// </summary>
        private void FrmPower()
        {
            if (GESelectGroup.EditValue != null)
            {
                if (CommonData.UserInfo.id != 1)
                {
                    DataRow[] dataRow = WorkCommData.DTGroupPower.Select($"state=1 and testNO='{GESelectGroup.EditValue}' and userNO='{CommonData.UserInfo.no}'");
                    if (dataRow.Count() == 1)
                    {

                        BTSampleEdit.Enabled = dataRow[0]["sampleEdit"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["sampleEdit"]) : false;


                        BTSampleSave.Enabled = dataRow[0]["sampleSave"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["sampleSave"]) : false;


                        CEEditCheck.Enabled = dataRow[0]["editCheck"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["editCheck"]) : false;
                        BTSampleReceive.Enabled = dataRow[0]["sampleReceive"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["sampleReceive"]) : false;
                        BTSampleReturn.Enabled = dataRow[0]["sampleReturn"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["sampleReturn"]) : false;
                        BTSampleSelect.Enabled = dataRow[0]["sampleSelect"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["sampleSelect"]) : false;
                        BTBatchReturn.Enabled = dataRow[0]["batchReturn"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batchReturn"]) : false;
                        BTSaveResult.Enabled = dataRow[0]["saveResult"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["saveResult"]) : false;
                        BTSaveReResult.Enabled = dataRow[0]["saveReResult"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["saveReResult"]) : false;
                        BTChecked.Enabled = dataRow[0]["checked"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["checked"]) : false;
                        BTReCheck.Enabled = dataRow[0]["reCheck"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["reCheck"]) : false;
                        BTBatch.Enabled = dataRow[0]["batch"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batch"]) : false;
                        BTBatchReturn.Enabled = dataRow[0]["batchReturn"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batchReturn"]) : false;
                        BTBatchSave.Enabled = dataRow[0]["batchSave"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batchSave"]) : false;
                        BTBatchReSave.Enabled = dataRow[0]["batchReSave"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batchReSave"]) : false;
                        BTBatchCheck.Enabled = dataRow[0]["batchCheck"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batchCheck"]) : false;
                        BTBatchReCheck.Enabled = dataRow[0]["batchReCheck"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["batchReCheck"]) : false;
                        reportReturn = dataRow[0]["reportReturn"] != DBNull.Value ? Convert.ToBoolean(dataRow[0]["reportReturn"]) : false;


                    }
                    else
                    {
                        MessageBox.Show("请检查权限配置", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    reportReturn = true;
                }
            }
            else
            {
                reportReturn = true;
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


        /// <summary>
        /// PanelTestResult内部切换窗体方法
        /// </summary>
        /// <param name="form"></param>
        private void formResult(Form form)
        {

            foreach (Control item in this.PanelTestResult.Controls)
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
            form.Parent = this.PanelTestResult;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        ////PanelTestResult内部切换窗体方法
        //private void formReport(Form form)
        //{
        //    foreach (Control item in this.PanelReportView.Controls)
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
        //    form.Parent = this.PanelReportView;
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
        string sampleid = "";
        string Barcode = "";
        string groupNO = "";
        string groupFlowNO = "";
        string hospitalNo = "";
        string testStateNO = "";

        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            try
            {


                SampleInfoRow = GVSampleInfo.GetFocusedDataRow();
                if (SampleInfoRow != null)
                {
                    testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                    perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                    hospitalNo = SampleInfoRow["hospitalNo"] != DBNull.Value ? SampleInfoRow["hospitalNo"].ToString() :"";
                    Barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString().Trim().ToUpper() : "";
                    testStateNO = SampleInfoRow["testStateNO"] != DBNull.Value ? SampleInfoRow["testStateNO"].ToString().Trim().ToUpper() : "";

                    //Barcode = SampleInfoRow["barcode"].ToString();
                    //TEsampleID
                    //PathologyNo = SampleInfoRow["pathologyNo"].ToString();
                    groupNO = SampleInfoRow["groupNO"].ToString();
                    DEsampleTime.EditValue = SampleInfoRow["sampleTime"];
                    TEageDay.EditValue = SampleInfoRow["ageDay"];
                    TEageMoth.EditValue = SampleInfoRow["ageMoth"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    GEagentNO.EditValue = SampleInfoRow["agentNames"];
                    TEageYear.EditValue = SampleInfoRow["ageYear"];
                    MEapplyItemNames.EditValue = SampleInfoRow["groupNames"];
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

                    TEatester.EditValue = SampleInfoRow["tester"];
                    DEatestTime.EditValue = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;

                    TEachecker.EditValue = SampleInfoRow["checker"];
                    DEacheckTime.EditValue = SampleInfoRow["checkTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;

                    string groupFlowNOs = SampleInfoRow["groupFlowNO"] != DBNull.Value && SampleInfoRow["groupFlowNO"].ToString() != "" ? SampleInfoRow["groupFlowNO"].ToString() : "1";



                    //actionSampleInfo(SampleID, Barcode, PathologyNo);

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

                    object[] paras = new object[] { testid, SampleInfoRow, 0 };

                    setResultInfos.Invoke(objpostResultInfo, paras);
                }
                else
                {
                    testid = 0;
                    sampleid = "";
                    Barcode = "";
                    groupNO = "";
                    groupFlowNO = "";
                    MessageBox.Show("没有获取到可用的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //frmWait.HideMe(this);
                }


                if (showReportState)
                {
                    ShowReportMethod(perid, testid, Barcode, hospitalNo, testStateNO);
                }



            }
            catch (Exception ex)
            {

                testid = 0;
                testid = 0;
                sampleid = "";
                Barcode = "";
                groupFlowNO = "";
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //PathologyNo = "";
            }

        }


        #region barmannage 按钮实现
        /// <summary>
        /// 切换组事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GESelectGroup_EditValueChanged(object sender, EventArgs e)
        {
            reflectionFile = "";
            reflectionFrm = "";
            FrmPower();
            Formart(GESelectGroup.EditValue.ToString());
            GroupPower(GESelectGroup.EditValue.ToString());
            if (FrmTest != null)
            {
                FrmTest.Close();
                //action(null,null);
                FrmTest = null;

            }
        }

        private void BTSelectGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (WorkCommData.DTGroupPower.Select($"workNO='{FrmWorkNO}' and userNO='{CommonData.UserInfo.id}' and state=1").Count() > 0 || CommonData.UserInfo.id == 1)
            {
                FrmGroupShow frmGroup = new FrmGroupShow(FrmWorkNO);
                Func<string> func = frmGroup.ReturnTag;
                frmGroup.ShowDialog();
                string a = func();
                if (a != "")
                {
                    GESelectGroup.EditValue = func();
                    DEtestTime.EditValue = null;
                    DEcheckTime.EditValue = null;
                    TEtester.EditValue = null;
                    TEchecker.EditValue = null;
                    groupFlowNO = "";
                }



            }
            else
            {
                MessageBox.Show("当前用户没有任何组的权限", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        string barcodestring = ""; 
        /// <summary>
        /// 查询检验中样本方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (GESelectGroup.EditValue != null)
            {

                BTSampleSelect.Enabled = false;

                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "查询信息请稍后......");
                SelectTestInfo selectTestInfo = new SelectTestInfo();
                selectTestInfo.UserName = CommonData.UserInfo.names;
                
                selectTestInfo.StartTime = DEStarTime.EditValue.ToString();
                selectTestInfo.EndTime = DEEndTime.EditValue.ToString();
                selectTestInfo.GroupNO = GESelectGroup.EditValue.ToString();
                selectTestInfo.TestStateNO = GESampleSate.EditValue.ToString();
                barcodestring = TEsbarcode.EditValue != null ? TEsbarcode.EditValue.ToString().Replace('，', ',') : "";//记录查询
                if (barcodestring != "")
                {
                    List<string> vs = new List<string>();
                    string[] codes = barcodestring.Split(',');
                    foreach (string code in codes)
                    {
                        vs.Add(code.ToUpper());
                    }
                    selectTestInfo.barcode = vs;
                }
                selectTestInfo.frameNo = TEsframeNo.EditValue != null ? TEsframeNo.EditValue.ToString() : "";
                string Sr = JsonHelper.SerializeObjct(selectTestInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(GetTestInfo, Sr);
                GCSampleInfo.DataSource = DTTestInfo =JsonHelper.StringToDT(jm);;
                GVSampleInfo.BestFitColumns();
                testState();
                BTSampleSelect.Enabled = true;
                frmWait.HideMe(this);
                //selectString = TEsbarcode.EditValue != null ? TEsbarcode.EditValue.ToString() : "";
                TEsbarcode.EditValue = "";
            }
            else
            {
                MessageBox.Show("请先选择专业组。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        /// <summary>
        /// 标本信息状态统计方法
        /// </summary>
        public void testState()
        {
            if (DTTestInfo != null&& DTTestInfo.Rows.Count>0)
            {
                LCtestState.Text = $"检验({DTTestInfo.Select("testStateNO=1").Count()})";
                LCreTestState.Text = $"初审({DTTestInfo.Select("testStateNO=2").Count()})";
                LCcheckState.Text = $"审核({DTTestInfo.Select("testStateNO=3").Count()})";
                LCwaitState.Text = $"待检({DTTestInfo.Select("testStateNO=4").Count()})";
                LCdeleState.Text = $"委托({DTTestInfo.Select("testStateNO=5").Count()})";
                LCreportState.Text = $"报告({DTTestInfo.Select("testStateNO=6").Count()})";
                LCprintState.Text = $"打印({DTTestInfo.Select("testStateNO=7").Count()})";
                LCcancelState.Text = $"退单({DTTestInfo.Select("testStateNO=8").Count()})";
            }
            else
            {
                LCtestState.Text = $"检验(0)";
                LCreTestState.Text = $"初审(0)";
                LCcheckState.Text = $"审核(0)";
                LCwaitState.Text = $"待检(0)";
                LCdeleState.Text = $"委托(0)";
                LCreportState.Text = $"报告(0)";
                LCprintState.Text = $"打印(0)";
                LCcancelState.Text = $"退单(0)";
            }
        }

        private void BTSampleReceive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GESelectGroup.EditValue != null)
            {

                //FrmReceiveGroup frmReceiveSample = new FrmReceiveGroup(GESelectGroup.EditValue.ToString());
                //frmReceiveSample.ShowDialog();
                FrmReceiveSample frmReceiveSample = new FrmReceiveSample(GESelectGroup.EditValue.ToString());
                frmReceiveSample.ShowDialog();


            }
            else
            {
                MessageBox.Show("请先选择专业组。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        /// <summary>
        /// 修改修改样本信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //layoutControl1.Enabled = true;
            int[] samplesDt = GVSampleInfo.GetSelectedRows();
            if(samplesDt.Count()>0&& SampleInfoRow!=null)
            {
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
                        else
                        {
                            data.Rows.Clear();
                            break;
                        }
                    }

                }
                if (data.Rows.Count > 0)
                {
                    FrmSampleInfoEdit frmSampleInfoEdit = new FrmSampleInfoEdit(data,2);
                    frmSampleInfoEdit.ShowDialog();
                    //BTSampleSelect_ItemClick(null, null);
                }
                else
                {
                    MessageBox.Show("不能修改已报告信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// 保存样本结果信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl1.Enabled = false;
        }
        /// <summary>
        /// 修改审核信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CEEditCheck_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEEditCheck.Checked)
            {
                DEtestTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                DEcheckTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                TEtester.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                TEchecker.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                DEtestTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                DEcheckTime.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                TEtester.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                TEchecker.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        #endregion

        #region 保存结果方法

        /// <summary>
        /// 样本退回方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                if (GVSampleInfo.GetSelectedRows().Length > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("确定需要退回样本信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ReceiveInfoModel receiveInfoModel = new ReceiveInfoModel();
                        receiveInfoModel.UserName = CommonData.UserInfo.names;
                        
                        //receiveInfoModel.ReceiveTime = Convert.ToDateTime(DEReceiveTime.EditValue).ToString("yyyy-MM-dd");
                        List<ReceiveSampleInfoModel> receiveInfos = new List<ReceiveSampleInfoModel>();
                        int[] aaa = GVSampleInfo.GetSelectedRows();
                        foreach (int a in aaa)
                        {
                            ReceiveSampleInfoModel receiveInfo = new ReceiveSampleInfoModel();
                            //receiveInfo.id = Convert.ToInt32(GVSampleInfo.GetRowCellValue(a, "id"));
                            receiveInfo.testid = Convert.ToInt32(GVSampleInfo.GetRowCellValue(a, "id"));
                            receiveInfo.barcode = GVSampleInfo.GetRowCellValue(a, "barcode").ToString();
                            receiveInfos.Add(receiveInfo);
                        }
                        if (receiveInfos.Count > 0)
                        {

                                string Sr = JsonHelper.SerializeObjct(receiveInfoModel);
                                WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveReturn, Sr);


                            if (jm.code == 0)
                            {
                                MessageBox.Show("退回成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BTSampleSelect_ItemClick(null, null);
                            }
                            else
                            {
                                MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 保存结果方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSaveResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"检测结果保存", "正在保存检测结果请稍后......");
                try
                {
                    if (testid != 0)
                    {
                        ///判断采样时间和接收时间是否为空
                        if (SampleInfoRow["sampleTime"] != DBNull.Value && SampleInfoRow["receiveTime"] != DBNull.Value)
                        {
                            DateTime sampleTime = Convert.ToDateTime(SampleInfoRow["sampleTime"]);
                            DateTime receiveTime = Convert.ToDateTime(SampleInfoRow["receiveTime"]);
                            //判断采样时间小于接收时间
                            if (sampleTime < receiveTime)
                            {
                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1)
                                {


                                    bool saveState = SaveResult(1, 1, out string reinfo);
                                    if (saveState)
                                    {
                                        if (CEEditCheck.Checked)
                                        {
                                            TEatester.EditValue = TEtester.EditValue;
                                            DEatestTime.EditValue = DEtestTime.EditValue;
                                        }
                                        else
                                        {
                                            TEatester.EditValue = CommonData.UserInfo.names;
                                            DEatestTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        }
                                    }
                                    else
                                    {
                                        if (reinfo!=null&&reinfo != "")
                                            MessageBox.Show(reinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                    {
                                        MessageBox.Show("样本结果已初审！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                        {
                                            MessageBox.Show("样本结果已审核！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("当前样本状态不能保存！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }


                                }
                            }
                            else
                            {
                                MessageBox.Show("接收时间不能小于采样时间。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                        else
                        {
                            MessageBox.Show("采样时间/接收时间不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择样本信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    frmWait.HideMe(this);
                    MessageBox.Show(ex.ToString());
                }

                frmWait.HideMe(this);
            }

        }
        /// <summary>
        /// 初审事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSaveReResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"初审结果上传", "正在初审检验结果请稍后......");
                try
                {
                    if (testid != 0)
                    {
                        if (!Convert.IsDBNull(SampleInfoRow["tester"]) && SampleInfoRow["tester"].ToString() != "")
                        {
                            if (trequal)
                            {
                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                {
                                    bool saveState = SaveResult(2, 1, out string reinfo);
                                    if (reinfo != "")
                                        MessageBox.Show(reinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("当前样本状态不能初审！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                if (SampleInfoRow["tester"].ToString() != CommonData.UserInfo.names)
                                {
                                    if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                    {
                                        bool saveState = SaveResult(2, 1, out string reinfo);
                                        if (reinfo != "")
                                            MessageBox.Show(reinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    }
                                    else
                                    {
                                        MessageBox.Show("当前样本状态不能初审！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("检验者/初审者不能为同一个人！", "检验者/初审者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("标本结果未保存！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }

        }
        /// <summary>
        /// 审核事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTChecked_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"审核结果上传", "正在审核检验结果请稍后......");
                try
                {
                    if (testid != 0)
                    {
                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) != 3)
                        {
                            if (Convert.ToInt32(SampleInfoRow["pathologyStateNO"]) != 5)
                            {
                                if (reviewState)
                                {
                                    if (!Convert.IsDBNull(SampleInfoRow["tester"]) && !Convert.IsDBNull(SampleInfoRow["retester"]))
                                    {
                                        if (SampleInfoRow["tester"].ToString() != "" && SampleInfoRow["retester"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 3)
                                            {
                                                if (tcequal)
                                                {
                                                    if (rcequal)
                                                    {
                                                        bool saveState = SaveResult(3, 1, out string reinfo);
                                                        if (saveState)
                                                        {
                                                            if (CEEditCheck.Checked)
                                                            {
                                                                TEachecker.EditValue = TEchecker.EditValue;
                                                                DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                            }
                                                            else
                                                            {
                                                                TEachecker.EditValue = CommonData.UserInfo.names;
                                                                DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (reinfo != "") 
                                                                MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    else
                                                    {

                                                        if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names || CEEditCheck.Checked)
                                                        {
                                                            bool saveState = SaveResult(3, 1, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (reinfo != "") 
                                                                    MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("初审者/审核者不能为同一个人！", "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    bool tcequalState = true;//验证状态
                                                    if (CEEditCheck.Checked)
                                                    {
                                                        if (TEchecker.EditValue == null && DEcheckTime.EditValue != null)
                                                            tcequalState = false;
                                                        if (SampleInfoRow["tester"].ToString() == TEchecker.EditValue.ToString())
                                                            tcequalState = false;
                                                    }
                                                    else
                                                    {
                                                        if (SampleInfoRow["tester"].ToString() == CommonData.UserInfo.names)
                                                            tcequalState = false;
                                                    }

                                                    if (tcequalState)
                                                    {
                                                        if (rcequal)
                                                        {
                                                            bool saveState = SaveResult(3, 1, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (reinfo != "") 
                                                                    MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names)
                                                            {
                                                                bool saveState = SaveResult(3, 1, out string reinfo);
                                                                if (saveState)
                                                                {
                                                                    if (CEEditCheck.Checked)
                                                                    {
                                                                        TEachecker.EditValue = TEchecker.EditValue;
                                                                        DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                    }
                                                                    else
                                                                    {
                                                                        TEachecker.EditValue = CommonData.UserInfo.names;
                                                                        DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (reinfo != "") 
                                                                        MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("初审者/审核者不能为同一个人！", "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (TEchecker.EditValue == null && DEcheckTime.EditValue != null)
                                                        {
                                                            MessageBox.Show("审核者/审核时间不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("检验者/审核者不能为同一个人！", "检验者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                                {
                                                    MessageBox.Show("标本结果未初审！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("当前样本状态不能审核！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("标本结果未保存！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("标本结果未初审！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    if (!Convert.IsDBNull(SampleInfoRow["tester"]))
                                    {
                                        if (SampleInfoRow["tester"].ToString() != "")
                                        {


                                            if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 3)
                                            {
                                                if (tcequal)
                                                {
                                                    if (rcequal)
                                                    {
                                                        bool saveState = SaveResult(3, 1, out string reinfo);
                                                        if (saveState)
                                                        {
                                                            if (CEEditCheck.Checked)
                                                            {
                                                                TEachecker.EditValue = TEchecker.EditValue;
                                                                DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                            }
                                                            else
                                                            {
                                                                TEachecker.EditValue = CommonData.UserInfo.names;
                                                                DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if(reinfo!="")
                                                                MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        }
                                                    }
                                                    else
                                                    {

                                                        if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names)
                                                        {
                                                            bool saveState = SaveResult(3, 1, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (reinfo != "") 
                                                                    MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("初审者/审核者不能为同一个人！", "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                    bool tcequalState = true;//验证状态
                                                    if (CEEditCheck.Checked)
                                                    {
                                                        if (TEchecker.EditValue == null && DEcheckTime.EditValue != null)
                                                            tcequalState = false;
                                                        if (SampleInfoRow["tester"].ToString() == TEchecker.EditValue.ToString())
                                                            tcequalState = false;
                                                    }
                                                    else
                                                    {
                                                        if (SampleInfoRow["tester"].ToString() == CommonData.UserInfo.names)
                                                            tcequalState = false;
                                                    }
                                                    if (tcequalState)
                                                    {
                                                        if (rcequal)
                                                        {
                                                            bool saveState = SaveResult(3, 1, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (reinfo != "")
                                                                    MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names)
                                                            {
                                                                bool saveState = SaveResult(3, 1, out string reinfo);
                                                                if (saveState)
                                                                {
                                                                    if (CEEditCheck.Checked)
                                                                    {
                                                                        TEachecker.EditValue = TEchecker.EditValue;
                                                                        DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                    }
                                                                    else
                                                                    {
                                                                        TEachecker.EditValue = CommonData.UserInfo.names;
                                                                        DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (reinfo != "") 
                                                                        MessageBox.Show(reinfo, "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("初审者/审核者不能为同一个人！", "初审者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (TEchecker.EditValue == null && DEcheckTime.EditValue != null)
                                                        {
                                                            MessageBox.Show("审核者/审核时间不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("检验者/审核者不能为同一个人！", "检验者/审核者验证提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }

                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                                {
                                                    MessageBox.Show("标本结果未初审！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("当前样本状态不能审核！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("标本结果未保存！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("标本结果未保存！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("样本已通过免疫组化申请,请到免疫组化模块中处理！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 3)
                            {
                                MessageBox.Show("当前样本状态已审核！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("当前样本状态不能进行审核！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //if (CENext.Checked)
                //{
                //    int a = GVSampleInfo.GetSelectedRows()[0];
                //    if (a < GVSampleInfo.RowCount)
                //    {
                //        //GVSampleInfo.SelectRow(a + 1);
                //        //GVSampleInfo.Focus();
                //        //GVSampleInfo.FocusedRowHandle = a + 1;
                //        GVSampleInfo.ClearSelection();
                //        GVSampleInfo.SelectRow(a + 1);
                //        GVSampleInfo.FocusedRowHandle = a + 1;
                //        SampleInfoRow = GVSampleInfo.GetFocusedDataRow();
                //        //GVSampleInfo.FocusedColumn = GVSampleInfo.Columns["barcode"];
                //        //GVSampleInfo.ShowEditor();
                //        //GVSampleInfo_RowClick(null, null);
                //    }
                //}
                frmWait.HideMe(this);
            }
        }
        /// <summary>
        /// 反审核事件CENext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTReCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                try
                {
                    if (!reportReturn)
                    {
                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) < 4)
                        {
                            DialogResult dialogResult = MessageBox.Show("确定要反审核当前信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {

                                AutographInfo autographInfo = new AutographInfo();
                                object[] paras = new object[] { 4, perid, testid,sampleid, Barcode, groupNO, "0", autographInfo };
                                string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();


                                if (ReturnState != "")
                                //if (postResultInfos.Invoke(objpostResultInfo, paras).ToString() != "0")
                                {
                                    try
                                    {


                                        commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                                        if (commReInfo.code == 0)
                                        {
                                            SampleInfoRow["testStateNO"] = 1;

                                            //SampleInfoRow["tester"] = "";
                                            //SampleInfoRow["testTime"] = DBNull.Value;
                                            //SampleInfoRow["reTester"] = "";
                                            //SampleInfoRow["reTestTime"] = DBNull.Value;
                                            //SampleInfoRow["checker"] = "";
                                            //SampleInfoRow["checkTime"] = DBNull.Value;
                                            //SampleInfoRow["realtester"] = "";
                                            //SampleInfoRow["realtestTime"] = DBNull.Value;
                                            //SampleInfoRow["realreTester"] = "";
                                            //SampleInfoRow["realreTestTime"] = DBNull.Value;
                                            //SampleInfoRow["realchecker"] = "";
                                            //SampleInfoRow["realcheckTime"] = DBNull.Value;
                                            TEatester.EditValue = null;
                                            DEatestTime.EditValue = null;
                                            TEachecker.EditValue = null;
                                            DEacheckTime.EditValue = null;

                                        }
                                        else
                                        {
                                            MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("没有权限反审已打印信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("确定要反审核当前信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            AutographInfo autographInfo = new AutographInfo();
                            object[] paras = new object[] { 4, perid, testid,sampleid, Barcode, groupNO, "0", autographInfo };
                            string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();


                            if (ReturnState != "")
                            //if (postResultInfos.Invoke(objpostResultInfo, paras).ToString() != "0")
                            {
                                try
                                {
                                    commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                                    if (commReInfo.code == 0)
                                    {
                                        SampleInfoRow["testStateNO"] = 1;
                                        SampleInfoRow["tester"] = "";
                                        SampleInfoRow["testTime"] = DBNull.Value;
                                        SampleInfoRow["reTester"] = "";
                                        SampleInfoRow["reTestTime"] = DBNull.Value;
                                        SampleInfoRow["checker"] = "";
                                        SampleInfoRow["checkTime"] = DBNull.Value;

                                        SampleInfoRow["realtester"] = "";
                                        SampleInfoRow["realtestTime"] = DBNull.Value;
                                        SampleInfoRow["realreTester"] = "";
                                        SampleInfoRow["realreTestTime"] = DBNull.Value;
                                        SampleInfoRow["realchecker"] = "";
                                        SampleInfoRow["realcheckTime"] = DBNull.Value;
                                        TEatester.EditValue = null;
                                        DEatestTime.EditValue = null;
                                        TEachecker.EditValue = null;
                                        DEacheckTime.EditValue = null;

                                    }
                                    else
                                    {
                                        MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        string exstring = "";
        /// <summary>
        /// 标本结果保存
        /// </summary>
        /// <param name="testStateNO">检验状态信息编号</param>
        /// <param name="typeNO">保存类型1，单独保存，2，批量保存</param>
        public bool SaveResult(int testStateNO, int typeNO, out string resultString)
        {
            //try
            //{
            bool SaveState = false;//保存状态
            resultString = "";//返回执行信息
            bool hcState = false;//是否是混采项目
            string groupFlowNO = SampleInfoRow["groupFlowNO"] != DBNull.Value ? SampleInfoRow["groupFlowNO"].ToString() : "1";
            //判断是否包含融合码信息
            //if (!Barcode.Contains("HJ"))
            //{
            //    if (itemString.Contains("754") || itemString.Contains("755"))
            //    {
            //        sInfo sInfo = new sInfo();
            //        sInfo.values = "1";
            //        sInfo.TableName = "WorkPer.SampleBlendInfo";
            //        sInfo.wheres = $"barcode='{Barcode}'";
            //        DataTable dataTable = ApiHelpers.postInfo(sInfo);
            //        if (dataTable == null && dataTable.Rows.Count == 0)
            //        {
            //            hcState = true;
            //        }
            //    }
            //}
            if (!hcState)
            {
                if (testid != 0)
                {
                    DateTime sampleTime = Convert.ToDateTime(SampleInfoRow["sampleTime"]);
                    DateTime receiveTime = Convert.ToDateTime(SampleInfoRow["receiveTime"]);
                    //判断接收时间是否大于采样时间
                    if (sampleTime < receiveTime)
                    {
                        bool sampleState = true;//判断采样时间是否大于接收时间3天
                        if (typeNO == 1)
                        {
                            if (sampleTime.AddDays(+3) < receiveTime)
                            {

                                DialogResult dialogResult = MessageBox.Show("接收时间超过采样时间三天，是否继续保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    //resultString = "接收时间超过采样时间三天,允许保存";
                                    sampleState = true;
                                }
                                else
                                {
                                    sampleState = false;
                                    //resultString = "接收时间超过采样时间三天,取消保存";
                                }
                            }
                        }
                        else
                        {
                            if (sampleTime.AddDays(+3) < receiveTime)
                            {
                                sampleState = false;
                                resultString = "接收时间超过采样时间三天";
                            }
                        }
                        if (sampleState)
                        {
                            if (CEEditCheck.Checked)
                            {
                                AutographInfo autographInfo = new AutographInfo();
                                //样本状态检验中
                                if (testStateNO == 1)
                                {
                                    if (TEtester.EditValue != null && DEtestTime.EditValue != null)
                                    {
                                        autographInfo.tester = TEtester.EditValue.ToString();
                                        autographInfo.testTime = Convert.ToDateTime(DEtestTime.EditValue);
                                        //判断修改保存结果信息时间是否超过三天且不能大于当前时间
                                        bool saveState = true;
                                        //检验时间不能大于接收时间
                                        if (autographInfo.testTime > receiveTime)
                                        {
                                            if (typeNO == 1)
                                            {
                                                //判断检验时间是否超过接收时间三天
                                                DateTime newRtime = receiveTime.AddDays(+3);
                                                if (autographInfo.testTime > newRtime)
                                                {

                                                    DialogResult dialogResult = MessageBox.Show("编辑保存时间超过接收时间三天，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                    if (dialogResult == DialogResult.Yes)
                                                    {
                                                        //resultString = "编辑保存时间超过接收时间三天,允许保存";
                                                        saveState = true;
                                                    }
                                                    else
                                                    {
                                                        saveState = false;
                                                        //resultString = "编辑保存时间超过接收时间三天,取消保存";
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                if (autographInfo.testTime > receiveTime.AddDays(+3))
                                                {
                                                    saveState = false;
                                                    resultString = "编辑保存时间超过接收时间三天";
                                                }
                                            }
                                            if (saveState)
                                            {

                                                if (autographInfo.testTime <= DateTime.Now)
                                                {
                                                    autographInfo.testRemark = METestRemark.EditValue == null ? "" : METestRemark.EditValue.ToString();
                                                    autographInfo.state = true;
                                                    object[] paras = new object[] { testStateNO, perid, testid, sampleid, Barcode, groupNO, groupFlowNO, autographInfo };
                                                    string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();
                                                    if (ReturnState != "")
                                                    {
                                                        commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                                                        if (commReInfo.code == 0)
                                                        {
                                                            if (commReInfo.nextFlowNO != null && commReInfo.nextFlowNO != "0" && commReInfo.nextFlowNO != "")
                                                                SampleInfoRow["groupFlowNO"] = commReInfo.nextFlowNO;
                                                            SampleInfoRow["testStateNO"] = testStateNO;
                                                            SampleInfoRow["testRemark"] = autographInfo.testRemark;
                                                            SampleInfoRow["tester"] = TEtester.EditValue != null ? TEtester.EditValue.ToString() : "";
                                                            SampleInfoRow["testTime"] = Convert.ToDateTime(DEtestTime.EditValue).ToString("yyyy-MM-dd HH:mm:ss");
                                                            SampleInfoRow["realtestTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            SampleInfoRow["realtester"] = CommonData.UserInfo.names;
                                                            SaveState = true;
                                                        }
                                                        else
                                                        {
                                                            SaveState = false;
                                                            resultString = commReInfo.msg;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        resultString = "保存信息有误！";
                                                    }
                                                }
                                                else
                                                {
                                                    resultString = "修改检验日期不能大于当前时间！";
                                                }
                                            }

                                        }
                                        else
                                        {
                                            resultString = "检验时间必须大于接收时间！";
                                        }

                                    }
                                    else
                                    {
                                        resultString = "代审核信息不能为空";
                                    }
                                }
                                else
                                {
                                    if (TEchecker.EditValue != null && DEcheckTime.EditValue != null)
                                    {
                                        DateTime testTime = DEtestTime.EditValue != null ? Convert.ToDateTime(DEtestTime.EditValue) : Convert.ToDateTime(SampleInfoRow["testTime"]);
                                        bool checkState = true;
                                        if (typeNO == 1)
                                        {
                                            DateTime newRtime = receiveTime.AddDays(+3);
                                            if (testTime > newRtime)
                                            {

                                                DialogResult dialogResult = MessageBox.Show("编辑检测时间超过接收时间三天，是否继续审核？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                if (dialogResult == DialogResult.Yes)
                                                {
                                                    //resultString = "编辑检测时间超过接收时间三天,允许审核";
                                                    checkState = true;
                                                }
                                                else
                                                {
                                                    checkState = false;
                                                    //resultString = "编辑检测时间超过接收时间三天,取消审核";
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (testTime > receiveTime.AddDays(+3))
                                            {
                                                checkState = false;
                                                resultString = "编辑检测时间超过接收时间三天";
                                            }
                                        }
                                        if (checkState)
                                        {
                                            if (tcequal)
                                            {
                                                autographInfo.tester = TEtester.EditValue != null ? TEtester.EditValue.ToString() : SampleInfoRow["tester"].ToString();
                                                autographInfo.checker = TEchecker.EditValue != null ? TEchecker.EditValue.ToString() : "";
                                                DateTime checkTime = Convert.ToDateTime(DEcheckTime.EditValue);
                                                if (checkTime <= DateTime.Now)
                                                {
                                                    if (testTime < Convert.ToDateTime(DEcheckTime.EditValue))
                                                    {
                                                        autographInfo.testTime = testTime;
                                                        autographInfo.checkTime = checkTime;
                                                        //判断修改保存结果信息时间是否超过三天且不能大于当前时间
                                                        bool saveState = true;
                                                        //if (typeNO == 1)
                                                        //{
                                                        //    if (autographInfo.testTime < receiveTime.AddDays(+3))
                                                        //    {
                                                        //        DialogResult dialogResult = MessageBox.Show("编辑样本时间超过当前时间三天，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                        //        if (dialogResult == DialogResult.Yes)
                                                        //        {
                                                        //            resultString = "编辑样本时间超过当前时间三天,允许保存";
                                                        //        }
                                                        //        else
                                                        //        {
                                                        //            saveState = false;
                                                        //            resultString = "编辑样本时间超过当前时间三天,取消保存";
                                                        //        }
                                                        //    }
                                                        //}
                                                        //else
                                                        //{
                                                        //    saveState = false;
                                                        //    resultString = "编辑样本时间超过当前时间三天";
                                                        //}
                                                        if (typeNO == 1)
                                                        {
                                                            //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+2))
                                                            //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+1))
                                                            if (autographInfo.checkTime < autographInfo.testTime.AddMinutes(+40))
                                                            {
                                                                DialogResult dialogResult = MessageBox.Show("编辑审核时间与编辑检测时间没有超过四十分钟，是继续否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                                if (dialogResult == DialogResult.Yes)
                                                                {
                                                                    //resultString = "编辑审核时间与编辑检测时间没有超过一小时,允许保存";
                                                                    saveState = true;
                                                                }
                                                                else
                                                                {
                                                                    saveState = false;
                                                                    //resultString = "编辑审核时间与编辑检测时间没有超过一小时,取消保存";
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+2))
                                                            //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+1))
                                                            if (autographInfo.checkTime < autographInfo.testTime.AddMinutes(+40))
                                                            {
                                                                saveState = false;
                                                                resultString = "编辑审核时间与编辑检测时间没有超过四十分钟";
                                                            }
                                                        }
                                                        if (saveState)
                                                        {
                                                            autographInfo.testRemark = METestRemark.EditValue == null ? "" : METestRemark.EditValue.ToString();
                                                            autographInfo.state = true;
                                                            object[] paras = new object[] { testStateNO, perid, testid, sampleid, Barcode, groupNO, groupFlowNO, autographInfo };
                                                            string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();
                                                            if (ReturnState != "")
                                                            {
                                                                commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                                                                if (commReInfo.code == 0)
                                                                {
                                                                    if (commReInfo.nextFlowNO != null && commReInfo.nextFlowNO != "0" && commReInfo.nextFlowNO != "")
                                                                        SampleInfoRow["groupFlowNO"] = commReInfo.nextFlowNO;
                                                                    SampleInfoRow["testStateNO"] = testStateNO;
                                                                    SampleInfoRow["testRemark"] = autographInfo.testRemark;

                                                                    ////PanelTestResult.Enabled = false;
                                                                    //if (testStateNO == 1)
                                                                    //{
                                                                    //    SampleInfoRow["tester"] = TEtester.EditValue != DBNull.Value ? TEtester.EditValue.ToString() : "";
                                                                    //    SampleInfoRow["testTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                    //    SampleInfoRow["realtester"] = CommonData.UserInfo.names;
                                                                    //}
                                                                    if (testStateNO == 2)
                                                                    {
                                                                        SampleInfoRow["reTester"] = CommonData.UserInfo.names;
                                                                        SampleInfoRow["reTestTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                        SampleInfoRow["realreTester"] = CommonData.UserInfo.names;
                                                                    }

                                                                    if (testStateNO == 3)
                                                                    {
                                                                        SampleInfoRow["checker"] = TEchecker.EditValue != null ? TEchecker.EditValue.ToString() : "";
                                                                        SampleInfoRow["checkTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                        SampleInfoRow["realchecker"] = CommonData.UserInfo.names;
                                                                    }
                                                                    SaveState = true;
                                                                }
                                                                else
                                                                {
                                                                    SaveState = false;
                                                                    resultString = commReInfo.msg;
                                                                }


                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    resultString = "修改检验日期超过三天！";
                                                        //}
                                                    }
                                                    else
                                                    {
                                                        resultString = "检测时间不能大于审核时间！";
                                                    }
                                                }
                                                else
                                                {
                                                    resultString = "审核时间不能大于当前时间！";
                                                }

                                            }
                                            else
                                            {
                                                autographInfo.tester = TEtester.EditValue != null ? TEtester.EditValue.ToString() : SampleInfoRow["tester"].ToString();
                                                autographInfo.checker = TEchecker.EditValue != null ? TEchecker.EditValue.ToString() : "";
                                                DateTime checkTime = Convert.ToDateTime(DEcheckTime.EditValue);
                                                if (checkTime <= DateTime.Now)
                                                {
                                                    if (autographInfo.tester != autographInfo.checker)
                                                    {
                                                        if (testTime < Convert.ToDateTime(DEcheckTime.EditValue))
                                                        {
                                                            autographInfo.testTime = testTime;
                                                            autographInfo.checkTime = checkTime;
                                                            //判断修改保存结果信息时间是否超过三天且不能大于当前时间
                                                            bool saveState = true;
                                                            //if (typeNO == 1)
                                                            //{
                                                            //    if (autographInfo.testTime > receiveTime.AddDays(+3))
                                                            //    {
                                                            //        DialogResult dialogResult = MessageBox.Show("编辑样本时间超过当前时间三天，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                            //        if (dialogResult == DialogResult.Yes)
                                                            //        {
                                                            //            resultString = "编辑样本时间超过当前时间三天,允许保存";
                                                            //        }
                                                            //        else
                                                            //        {
                                                            //            saveState = false;
                                                            //            resultString = "编辑样本时间超过当前时间三天,取消保存";
                                                            //        }
                                                            //    }
                                                            //}
                                                            //else
                                                            //{
                                                            //    if (autographInfo.testTime > receiveTime.AddDays(+3))
                                                            //    {
                                                            //        saveState = false;
                                                            //        resultString = "编辑样本时间超过当前时间三天";
                                                            //    }
                                                            //}
                                                            if (typeNO == 1)
                                                            {
                                                                //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+2))
                                                                //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+1))
                                                                if (autographInfo.checkTime < autographInfo.testTime.AddMinutes(+40))
                                                                {
                                                                    DialogResult dialogResult = MessageBox.Show("编辑审核时间与编辑检测时间没有超过四十分钟，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                                    if (dialogResult == DialogResult.Yes)
                                                                    {
                                                                        //resultString = "编辑审核时间与编辑检测时间没有超过一小时,允许保存";
                                                                        saveState = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        saveState = false;
                                                                        //resultString = "编辑审核时间与编辑检测时间没有超过一小时,取消保存";
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+2))
                                                                //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+1))
                                                                if (autographInfo.checkTime < autographInfo.testTime.AddMinutes(+40))
                                                                {
                                                                    saveState = false;
                                                                    //resultString = "编辑审核时间与编辑检测时间没有超过一小时";
                                                                    resultString = "编辑审核时间与编辑检测时间没有超过四十分钟";
                                                                }
                                                            }
                                                            if (saveState)
                                                            {
                                                                autographInfo.testRemark = METestRemark.EditValue == null ? "" : METestRemark.EditValue.ToString();
                                                                autographInfo.state = true;
                                                                object[] paras = new object[] { testStateNO, perid, testid, sampleid, Barcode, groupNO, groupFlowNO, autographInfo };
                                                                string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();
                                                                if (ReturnState != "")
                                                                {
                                                                    commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                                                                    if (commReInfo.code == 0)
                                                                    {
                                                                        if (commReInfo.nextFlowNO != null && commReInfo.nextFlowNO != "0" && commReInfo.nextFlowNO != "")
                                                                            SampleInfoRow["groupFlowNO"] = commReInfo.nextFlowNO;
                                                                        SampleInfoRow["testStateNO"] = testStateNO;
                                                                        SampleInfoRow["testRemark"] = autographInfo.testRemark;

                                                                        ////PanelTestResult.Enabled = false;
                                                                        //if (testStateNO == 1)
                                                                        //{
                                                                        //    SampleInfoRow["tester"] = TEtester.EditValue != DBNull.Value ? TEtester.EditValue.ToString() : "";
                                                                        //    SampleInfoRow["testTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                        //    SampleInfoRow["realtester"] = CommonData.UserInfo.names;
                                                                        //}
                                                                        if (testStateNO == 2)
                                                                        {
                                                                            SampleInfoRow["reTester"] = CommonData.UserInfo.names;
                                                                            SampleInfoRow["reTestTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                            SampleInfoRow["realreTester"] = CommonData.UserInfo.names;
                                                                        }

                                                                        if (testStateNO == 3)
                                                                        {
                                                                            SampleInfoRow["checker"] = TEchecker.EditValue != null ? TEchecker.EditValue.ToString() : "";
                                                                            SampleInfoRow["checkTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                            SampleInfoRow["realchecker"] = CommonData.UserInfo.names;
                                                                        }
                                                                        SaveState = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        SaveState = false;
                                                                        resultString = commReInfo.msg;
                                                                    }


                                                                }
                                                            }
                                                            //else
                                                            //{
                                                            //    resultString = "修改检验日期超过三天！";
                                                            //}
                                                        }
                                                        else
                                                        {
                                                            resultString = "检测时间不能大于审核时间！";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        resultString = "检验者/审核者不能为同一人！";
                                                    }
                                                }
                                                else
                                                {
                                                    resultString = "审核时间不能大于当前时间！";
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        resultString = "代审核信息不能为空";
                                    }
                                }
                            }
                            else
                            {
                                AutographInfo autographInfo = new AutographInfo();
                                autographInfo.tester = CommonData.UserInfo.names;
                                autographInfo.testTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                autographInfo.checker = CommonData.UserInfo.names;
                                autographInfo.checkTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                autographInfo.testRemark = METestRemark.EditValue == null ? "" : METestRemark.EditValue.ToString();
                                autographInfo.state = false; ;

                                //判断修改保存结果信息时间是否超过三天且不能大于当前时间
                                bool saveState = true;
                                if (autographInfo.testTime > receiveTime)
                                {
                                    if (typeNO == 1)
                                    {
                                        DateTime newRtime = receiveTime.AddDays(+3);
                                        if (autographInfo.testTime > newRtime)
                                        {
                                            DialogResult dialogResult = MessageBox.Show("保存时间超过接收时间三天，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                //resultString = "保存时间超过接收时间三天,允许保存";
                                                saveState = true;
                                            }
                                            else
                                            {
                                                saveState = false;
                                                //resultString = "保存时间超过接收时间三天,取消保存";
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (autographInfo.testTime > receiveTime.AddDays(+3))
                                        {
                                            saveState = false;
                                            resultString = "保存时间超过接收时间三天";
                                        }
                                    }
                                    if (testStateNO == 3)
                                    {
                                        if (typeNO == 1)
                                        {
                                            autographInfo.testTime = Convert.ToDateTime(SampleInfoRow["testTime"]);
                                            //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+2))
                                            //if (autographInfo.checkTime < autographInfo.testTime.AddHours(+1))
                                            if (autographInfo.checkTime < autographInfo.testTime.AddMinutes(+40))
                                            {
                                                DialogResult dialogResult = MessageBox.Show("审核时间与检测时间没有超过四十分钟，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                                if (dialogResult == DialogResult.Yes)
                                                {
                                                    //resultString = "审核时间与检测时间没有超过一小时,允许保存";
                                                    saveState = true;
                                                }
                                                else
                                                {
                                                    saveState = false;
                                                    //resultString = "审核时间与检测时间没有超过一小时,取消保存";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            saveState = false;
                                            resultString = "审核时间与检测时间没有超过四十分钟";
                                        }
                                    }
                                    if (saveState)
                                    {
                                        //object[] paras = new object[] { testStateNO, perid, testid, sampleid, Barcode, groupNO, groupFlowNO, autographInfo };
                                        object[] paras = new object[] { testStateNO, perid, testid, sampleid, Barcode, groupNO, groupFlowNO, autographInfo };
                                        string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();
                                        if (ReturnState != "")
                                        {
                                            commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                                            if (commReInfo.code == 0)
                                            {
                                                if (commReInfo.nextFlowNO != null && commReInfo.nextFlowNO != "0")
                                                    SampleInfoRow["groupFlowNO"] = commReInfo.nextFlowNO;
                                                SampleInfoRow["testStateNO"] = testStateNO;
                                                SampleInfoRow["testRemark"] = autographInfo.testRemark;
                                                if (testStateNO == 1)
                                                {
                                                    SampleInfoRow["tester"] = CommonData.UserInfo.names;
                                                    SampleInfoRow["testTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    SampleInfoRow["realtester"] = CommonData.UserInfo.names;
                                                }

                                                if (testStateNO == 2)
                                                {
                                                    SampleInfoRow["reTester"] = CommonData.UserInfo.names;
                                                    SampleInfoRow["reTestTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    SampleInfoRow["realreTester"] = CommonData.UserInfo.names;
                                                }

                                                if (testStateNO == 3)
                                                {
                                                    SampleInfoRow["checker"] = CommonData.UserInfo.names;
                                                    SampleInfoRow["checkTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                    SampleInfoRow["realchecker"] = CommonData.UserInfo.names;
                                                }
                                                SaveState = true;
                                            }
                                            else
                                            {
                                                SaveState = false;
                                                resultString = commReInfo.msg;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    resultString = "接收时间不能大于等于检测时间。";
                                }
                            }
                        }
                    }
                    else
                    {
                        resultString = "接收时间不能小于或等于采样时间。";
                    }
                    testState();
                }
                else
                {
                    resultString = "请先选择需要保存的样本信息。";

                }

            }
            else
            {
                resultString = "未上传混合样本信息";

            }
            return SaveState;

            //}
            //catch (Exception ex)
            //{
            //    throw ex;

            //    //MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void TEtester_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GESelectGroup.EditValue != null)
            {
                FrmUserCheck frmUserCheck = new FrmUserCheck(GESelectGroup.EditValue.ToString(), "1");
                Func<string> Funcs = frmUserCheck.ReturnUserName;
                frmUserCheck.ShowDialog();
                TEtester.EditValue = Funcs();

            }
        }

        private void TEchecker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GESelectGroup.EditValue != null)
            {
                FrmUserCheck frmUserCheck = new FrmUserCheck(GESelectGroup.EditValue.ToString(), "2");
                Func<string> Funcs = frmUserCheck.ReturnUserName;
                frmUserCheck.ShowDialog();
                TEchecker.EditValue = Funcs();

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
            //HotKeys.RegisterHotKey(Handle, 110, 0, Keys.F1);
            //HotKeys.RegisterHotKey(Handle, 111, 0, Keys.F2);
            //HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F5);
            //HotKeys.RegisterHotKey(Handle, 101, 0, Keys.F6);
            //HotKeys.RegisterHotKey(Handle, 102, 0, Keys.F7);
            ////HotKeys.RegisterHotKey(Handle, 103, 0, Keys.Enter);

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
            //HotKeys.UnregisterHotKey(Handle, 103);
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
                            if (BTSaveReResult.Enabled)
                                BTSaveReResult_ItemClick(null, null);
                            break;
                        case 102:  //按下的是F7
                            if (BTChecked.Enabled)
                                BTChecked_ItemClick(null, null);
                            break;
                            //case 103:  //按下的是enter
                            //    GVSampleInfo_RowClick(null, null);
                            //    break;
                            //    //case 103:  //按下的是Ctrl+q
                            //    //    BTNextPage_ItemClick(null, null);          //此处填写快捷键响应代码
                            //    //    break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        #endregion hotKeys


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

        #region  批量操作信息


        private void BTBatchReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetSelectedRows().Length > 0)
            {
                string resultString = "";
                DialogResult dialogResult = MessageBox.Show("确定需要退回样本信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    ReceiveInfoModel receiveInfoModel = new ReceiveInfoModel();
                    receiveInfoModel.UserName = CommonData.UserInfo.names;
                    
                    //receiveInfoModel.ReceiveTime = Convert.ToDateTime(DEReceiveTime.EditValue).ToString("yyyy-MM-dd");
                    List<ReceiveSampleInfoModel> receiveInfos = new List<ReceiveSampleInfoModel>();
                    int[] q = GVSampleInfo.GetSelectedRows();
                    int[] a = q.OrderBy(x => x).ToArray();
                    foreach (int s in a)
                    {
                        ReceiveSampleInfoModel receiveInfo = new ReceiveSampleInfoModel();

                        DataRow dataRow = GVSampleInfo.GetDataRow(s);


                        receiveInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                        receiveInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        receiveInfo.sampleid = dataRow["sampleID"] != DBNull.Value ? dataRow["sampleID"].ToString() : ""; ;
                        receiveInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : ""; ;
                        receiveInfo.testNo = dataRow["testNo"] != DBNull.Value ? dataRow["testNo"].ToString() : ""; ;
                        receiveInfo.frameNo = dataRow["frameNo"] != DBNull.Value ? dataRow["frameNo"].ToString() : ""; ;
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
                            BTSampleSelect_ItemClick(null, null);

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
            //BTSampleSelect_ItemClick(null, null);
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTBatchSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"批量保存", "正在保存检验结果请稍后......");
                try
                {
                    string resultString = "";
                    int[] q = GVSampleInfo.GetSelectedRows();
                    int[] a = q.OrderBy(x => x).ToArray();
                    for (int w = a.Length - 1; w >= 0; w--)
                    {
                        int s = a[w];
                        SampleInfoRow = GVSampleInfo.GetDataRow(s);
                        testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                        perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                        sampleid = SampleInfoRow["sampleID"] != DBNull.Value ? SampleInfoRow["sampleID"].ToString() : "";
                        Barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString().Trim().ToUpper() : "";
                        if (testid != 0)
                        {
                            if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1)
                            {
                                bool saveState = SaveResult(1, 2, out string reinfo);
                                if (saveState)
                                {
                                    if (CEEditCheck.Checked)
                                    {
                                        TEatester.EditValue = TEtester.EditValue;
                                        DEatestTime.EditValue = DEtestTime.EditValue;
                                    }
                                    else
                                    {
                                        TEatester.EditValue = CommonData.UserInfo.names;
                                        DEatestTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                }
                                else
                                {
                                    resultString += SampleInfoRow["barcode"] + ":" + reinfo + ";\r\n";
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                {
                                    resultString += SampleInfoRow["barcode"] + ":样本结果已初审！\r\n";
                                }
                                else
                                {
                                    resultString += SampleInfoRow["barcode"] + ":样本结果已审核！\r\n";
                                }
                            }
                        }
                    }
                    if (resultString != "")
                        MessageBox.Show(resultString, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                frmWait.HideMe(this);
            }

        }
        /// <summary>
        /// 批量初审
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTBatchReSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"批量初审", "正在初审检验结果请稍后......");
                try
                {

                    string resultString = "";
                    int[] q = GVSampleInfo.GetSelectedRows();
                    int[] a = q.OrderBy(x => x).ToArray();
                    for (int w = a.Length - 1; w >= 0; w--)
                    {
                        int s = a[w];
                        SampleInfoRow = GVSampleInfo.GetDataRow(s);
                        testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                        perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                        sampleid = SampleInfoRow["sampleID"] != DBNull.Value ? SampleInfoRow["sampleID"].ToString() : "";
                        Barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString().Trim().ToUpper() : "";
                        if (testid != 0)
                        {
                            if (!Convert.IsDBNull(SampleInfoRow["tester"]) && SampleInfoRow["tester"].ToString() != "")
                            {
                                if (trequal)
                                {
                                    if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                    {
                                        bool saveState = SaveResult(2, 2, out string reinfo);
                                        if (reinfo != "")
                                            resultString += SampleInfoRow["barcode"] + ":" + reinfo + ";\r\n";
                                    }
                                    else
                                    {
                                        resultString += SampleInfoRow["barcode"] + ":样本结果已审核！\r\n";
                                    }
                                }
                                else
                                {
                                    if (SampleInfoRow["tester"].ToString() != CommonData.UserInfo.names)
                                    {
                                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                        {
                                            bool saveState = SaveResult(2, 2, out string reinfo);
                                            if (reinfo != "")
                                                resultString += SampleInfoRow["barcode"] + ":" + reinfo + ";\r\n";
                                        }
                                        else
                                        {
                                            resultString += SampleInfoRow["barcode"] + ":样本结果已审核！\r\n";
                                        }
                                    }
                                    else
                                    {
                                        resultString += SampleInfoRow["barcode"] + "检验者/初审者不能为同一个人！\r\n";
                                    }
                                }
                            }
                            else
                            {
                                resultString += SampleInfoRow["barcode"] + "标本结果未保存！\r\n";
                            }
                        }
                        else
                        {
                            resultString += SampleInfoRow["barcode"] + "请先选择样本信息。\r\n";
                        }
                    }
                    if (resultString != "")
                        MessageBox.Show(resultString, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                frmWait.HideMe(this);
            }

        }
        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTBatchCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {


                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"批量审核", "正在审核检验结果请稍后......");
                try
                {
                    string resultString = "";
                    int[] q = GVSampleInfo.GetSelectedRows();
                    int[] a = q.OrderBy(x => x).ToArray();
                    for (int w = a.Length - 1; w >= 0; w--)
                    {
                        int s = a[w];
                        SampleInfoRow = GVSampleInfo.GetDataRow(s); ;
                        testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                        perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                        sampleid = SampleInfoRow["sampleID"] != DBNull.Value ? SampleInfoRow["sampleID"].ToString() : "";
                        Barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString().Trim().ToUpper() : "";
                        DateTime testTime = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]) : DateTime.Now.AddDays(+1);
                        //if (testTime < DateTime.Now.AddHours(5))
                        //{
                            if (testid != 0)
                            {
                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) != 3)
                                {
                                    if (reviewState)
                                    {
                                        //if (!Convert.IsDBNull(SampleInfoRow["tester"]) && SampleInfoRow["tester"].ToString() != "")
                                        if (!Convert.IsDBNull(SampleInfoRow["tester"]) && SampleInfoRow["tester"].ToString() != "" && !Convert.IsDBNull(SampleInfoRow["retester"]) && SampleInfoRow["retester"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 3)
                                            {
                                                if (tcequal)
                                                {
                                                    if (rcequal)
                                                    {
                                                        bool saveState = SaveResult(3, 2, out string reinfo);
                                                        if (saveState)
                                                        {
                                                            if (CEEditCheck.Checked)
                                                            {
                                                                TEachecker.EditValue = TEchecker.EditValue;
                                                                DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                            }
                                                            else
                                                            {
                                                                TEachecker.EditValue = CommonData.UserInfo.names;
                                                                DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            resultString += Barcode + ":" + reinfo + ";\r\n";
                                                        }
                                                        //SaveResult(3);

                                                    }
                                                    else
                                                    {

                                                        if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names || CEEditCheck.Checked)
                                                        {
                                                            bool saveState = SaveResult(3, 2, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                resultString += Barcode + ":" + reinfo + ";\r\n";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            resultString = Barcode + ":初审者/审核者不能为同一个人！\r\n";
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    bool tcequalState = true;//验证状态
                                                    if (CEEditCheck.Checked)
                                                    {
                                                        if (TEchecker.EditValue == null && DEacheckTime.EditValue == null)
                                                        {
                                                            resultString += "编辑审核者/审核时间不能为空！\r\n";
                                                            break;
                                                        }
                                                        if (SampleInfoRow["tester"].ToString() == TEchecker.EditValue.ToString())
                                                            tcequalState = false;
                                                    }
                                                    else
                                                    {
                                                        if (SampleInfoRow["tester"].ToString() == CommonData.UserInfo.names)
                                                            tcequalState = false;
                                                    }

                                                    if (tcequalState)
                                                    {
                                                        if (rcequal)
                                                        {
                                                            bool saveState = SaveResult(3, 2, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                resultString += Barcode + ":" + reinfo + ";\r\n";
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names)
                                                            {
                                                                bool saveState = SaveResult(3, 2, out string reinfo);
                                                                if (saveState)
                                                                {
                                                                    if (CEEditCheck.Checked)
                                                                    {
                                                                        TEachecker.EditValue = TEchecker.EditValue;
                                                                        DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                    }
                                                                    else
                                                                    {
                                                                        TEachecker.EditValue = CommonData.UserInfo.names;
                                                                        DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    resultString += Barcode + ":" + reinfo + ";\r\n";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                resultString += Barcode + ":初审者/审核者不能为同一个人！\r\n";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        resultString += Barcode + ":检验者/审核者不能为同一个人！\r\n";
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                                {
                                                    resultString += Barcode + ":标本结果未初审！\r\n";
                                                }
                                                else
                                                {
                                                    resultString = Barcode + ":标本已报告！\r\n";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            resultString += Barcode + ":标本结果未初审！\r\n";
                                        }
                                    }
                                    else
                                    {
                                        if (!Convert.IsDBNull(SampleInfoRow["tester"]) && SampleInfoRow["tester"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 3)
                                            {
                                                if (tcequal)
                                                {
                                                    if (rcequal)
                                                    {
                                                        bool saveState = SaveResult(3, 2, out string reinfo);
                                                        if (saveState)
                                                        {
                                                            if (CEEditCheck.Checked)
                                                            {
                                                                TEachecker.EditValue = TEchecker.EditValue;
                                                                DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                            }
                                                            else
                                                            {
                                                                TEachecker.EditValue = CommonData.UserInfo.names;
                                                                DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            resultString += Barcode + ":" + reinfo + ";\r\n";
                                                        }
                                                    }
                                                    else
                                                    {

                                                        if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names)
                                                        {
                                                            bool saveState = SaveResult(3, 2, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                resultString += Barcode + ":" + reinfo + ";\r\n";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            resultString += Barcode + ":初审者/审核者不能为同一个人！\r\n";
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (SampleInfoRow["tester"].ToString() != CommonData.UserInfo.names)
                                                    {
                                                        if (rcequal)
                                                        {
                                                            bool saveState = SaveResult(3, 2, out string reinfo);
                                                            if (saveState)
                                                            {
                                                                if (CEEditCheck.Checked)
                                                                {
                                                                    TEachecker.EditValue = TEchecker.EditValue;
                                                                    DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                }
                                                                else
                                                                {
                                                                    TEachecker.EditValue = CommonData.UserInfo.names;
                                                                    DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                resultString += Barcode + ":" + reinfo + ";\r\n";
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (SampleInfoRow["retester"].ToString() != CommonData.UserInfo.names)
                                                            {
                                                                bool saveState = SaveResult(3, 2, out string reinfo);
                                                                if (saveState)
                                                                {
                                                                    if (CEEditCheck.Checked)
                                                                    {
                                                                        TEachecker.EditValue = TEchecker.EditValue;
                                                                        DEacheckTime.EditValue = DEcheckTime.EditValue;
                                                                    }
                                                                    else
                                                                    {
                                                                        TEachecker.EditValue = CommonData.UserInfo.names;
                                                                        DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    resultString += Barcode + ":" + reinfo + ";\r\n";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                resultString += Barcode + ":初审者/审核者不能为同一个人！\r\n";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        resultString += Barcode + ":检验者/审核者不能为同一个人！\r\n";
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) == 1 || Convert.ToInt32(SampleInfoRow["testStateNO"]) == 2)
                                                {
                                                    resultString += Barcode + ":标本结果未初审！\r\n";
                                                }
                                                else
                                                {
                                                    resultString += Barcode + ":标本已报告！\r\n";
                                                }
                                            }

                                        }
                                        else
                                        {
                                            resultString += Barcode + ":标本结果未保存！\r\n";
                                        }
                                    }
                                }
                                else
                                {
                                    resultString += Barcode + ":样本结果已审核！\r\n";
                                }
                            }
                            else
                            {
                                resultString += Barcode + ":请先选择样本信息。\r\n";
                            }
                        //}
                        //else
                        //{
                        //    resultString += Barcode + ":检验时间不能为空。\r\n";
                        //}
                    }
                    if (resultString != "")
                        MessageBox.Show(resultString, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                frmWait.HideMe(this);
            }
        }
        /// <summary>
        /// 批量反审
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTBatchReCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (setResultInfos != null && postResultInfos != null)
            {
                string resultString = "";
                if (reportReturn == false)
                {
                    DialogResult dialogResult = MessageBox.Show("确定要反审核当前信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {

                        int[] a = GVSampleInfo.GetSelectedRows();
                        foreach (int s in a)
                        {
                            SampleInfoRow = GVSampleInfo.GetDataRow(s);
                            testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                            perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                            sampleid = SampleInfoRow["sampleID"] != DBNull.Value ? SampleInfoRow["sampleID"].ToString() : "";
                            Barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString().Trim().ToUpper() : "";
                            if (testid != 0)
                            {
                                if (Convert.ToInt32(SampleInfoRow["testStateNO"]) < 4)
                                {
                                    object[] paras = new object[] { 4, perid, testid, sampleid, Barcode, groupNO, "0", null };
                                    object ReturnState = postResultInfos.Invoke(objpostResultInfo, paras);
                                    if (ReturnState != null)
                                    {
                                        commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState.ToString());
                                        if (commReInfo.code == 0)
                                        {
                                            SampleInfoRow["testStateNO"] = 1;
                                            SampleInfoRow["tester"] = "";
                                            SampleInfoRow["testTime"] = DBNull.Value;
                                            SampleInfoRow["reTester"] = "";
                                            SampleInfoRow["reTestTime"] = DBNull.Value;
                                            SampleInfoRow["checker"] = "";
                                            SampleInfoRow["checkTime"] = DBNull.Value;
                                            SampleInfoRow["realtester"] = "";
                                            SampleInfoRow["realtestTime"] = DBNull.Value;
                                            SampleInfoRow["realreTester"] = "";
                                            SampleInfoRow["realreTestTime"] = DBNull.Value;
                                            SampleInfoRow["realchecker"] = "";
                                            SampleInfoRow["realcheckTime"] = DBNull.Value;
                                            TEatester.EditValue = null;
                                            DEatestTime.EditValue = null;
                                            TEachecker.EditValue = null;
                                            DEacheckTime.EditValue = null;
                                        }
                                        else
                                        {
                                            resultString = SampleInfoRow["barcode"] + ":没有权限反审已打印信息。";
                                        }
                                    }
                                    else
                                    {
                                        resultString = SampleInfoRow["barcode"] + ":没有权限反审已打印信息。";
                                    }
                                }
                                else
                                {
                                    resultString = SampleInfoRow["barcode"] + ":没有权限反审已打印信息。";
                                }
                            }
                            else
                            {
                                resultString = SampleInfoRow["barcode"] + ":样本信息为空。";
                            }
                        }
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("确定要反审核当前信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int[] q = GVSampleInfo.GetSelectedRows();
                        int[] a = q.OrderBy(x => x).ToArray();
                        for (int w = a.Length - 1; w >= 0; w--)
                        {
                            int s = a[w];
                            SampleInfoRow = GVSampleInfo.GetDataRow(s);

                            testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                            perid = SampleInfoRow["perid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["perid"]) : 0;
                            sampleid = SampleInfoRow["sampleID"] != DBNull.Value ? SampleInfoRow["sampleID"].ToString() : "";
                            Barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString().Trim().ToUpper() : "";
                            if (testid != 0)
                            {
                                object[] paras = new object[] { 4, perid, testid, sampleid, Barcode, groupNO, "0", null };
                                object ReturnState = postResultInfos.Invoke(objpostResultInfo, paras);
                                if (ReturnState != null)
                                {
                                    commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState.ToString());
                                    if (commReInfo.code == 0)
                                    {
                                        SampleInfoRow["testStateNO"] = 1;

                                        SampleInfoRow["tester"] = "";
                                        SampleInfoRow["testTime"] = DBNull.Value;
                                        SampleInfoRow["reTester"] = "";
                                        SampleInfoRow["reTestTime"] = DBNull.Value;
                                        SampleInfoRow["checker"] = "";
                                        SampleInfoRow["checkTime"] = DBNull.Value;
                                        SampleInfoRow["realtester"] = "";
                                        SampleInfoRow["realtestTime"] = DBNull.Value;
                                        SampleInfoRow["realreTester"] = "";
                                        SampleInfoRow["realreTestTime"] = DBNull.Value;
                                        SampleInfoRow["realchecker"] = "";
                                        SampleInfoRow["realcheckTime"] = DBNull.Value;
                                        TEatester.EditValue = null;
                                        DEatestTime.EditValue = null;
                                        TEachecker.EditValue = null;
                                        DEacheckTime.EditValue = null;
                                    }
                                    else
                                    {
                                        resultString += SampleInfoRow["barcode"] + ":反审核失败。";
                                    }
                                }
                                else
                                {
                                    resultString += SampleInfoRow["barcode"] + ":样本信息为空。";
                                }
                            }
                            else
                            {
                                resultString += SampleInfoRow["barcode"] + ":样本信息为空。";
                            }
                        }
                    }
                    testState();
                }
                if (resultString != "")
                    MessageBox.Show(resultString, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region 其他操作（掩饰，退单，增项，退项）

        /// <summary>
        /// 延迟检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTdelay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetFocusedDataRow() != null)
            {
                FrmTestOther frmTestDelay = new FrmTestOther(GVSampleInfo.GetFocusedDataRow(), "1");
                frmTestDelay.ShowDialog();
            }
        }
        /// <summary>
        /// 重新采样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTagain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetFocusedDataRow() != null)
            {
                FrmTestOther frmTestDelay = new FrmTestOther(GVSampleInfo.GetFocusedDataRow(), "2");
                frmTestDelay.ShowDialog();
            }
        }
        /// <summary>
        /// 退单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTChargeback_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetFocusedDataRow() != null)
            {
                FrmTestOther frmTestDelay = new FrmTestOther(GVSampleInfo.GetFocusedDataRow(), "3");
                frmTestDelay.ShowDialog();
            }
        }
        /// <summary>
        /// 退项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTCancelItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetFocusedDataRow() != null)
            {
                FrmTestCancel frmTestDelay = new FrmTestCancel(GVSampleInfo.GetFocusedDataRow(), "1");
                frmTestDelay.ShowDialog();
            }
        }
        /// <summary>
        /// 增项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTAddItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVSampleInfo.GetFocusedDataRow() != null)
            {
                FrmTestAdd frmTestDelay = new FrmTestAdd(GVSampleInfo.GetFocusedDataRow(), "1");
                frmTestDelay.ShowDialog();
            }
        }
        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTDelegate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (GVSampleInfo.GetFocusedDataRow() != null)
            {
                DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
                FrmDelegateTest frmDelegateTest = new FrmDelegateTest(dataRow);
                Func<string> func = frmDelegateTest.reSaveState;
                frmDelegateTest.ShowDialog();
                if (func() == "1")
                {
                    GVSampleInfo.SetFocusedRowCellValue("testStateNO", "5");
                }
            }
            else
            {
                MessageBox.Show("请先选择需要委托的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// 样本退回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            //try
            //{


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
                        receiveInfo.testNo = dataRow["testNo"] != DBNull.Value ? dataRow["testNo"].ToString() : ""; ;
                        receiveInfo.frameNo = dataRow["frameNo"] != DBNull.Value ? dataRow["frameNo"].ToString() : ""; ;
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
                            BTSampleSelect_ItemClick(null, null);

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
            //}
            //catch(Exception ex)
            //{

            //}

        }



        #endregion

        /// <summary>
        /// 查看原单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleImg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkPer.SampleImg";
            selectInfo.values = "top 1 filestring";
            selectInfo.wheres = $"barcode='{Barcode}' and filestring!=''";
            selectInfo.OrderColumns = "createTime desc";
            DataTable data = ApiHelpers.postInfo(selectInfo);
            if (data != null && data.Rows.Count > 0)
            {
                ShowImgHelper.ViewOrignalImage(FileConverHelpers.StringToBitmap(data.Rows[0][0].ToString()));
            }
            else
            {
                MessageBox.Show("未找到该信息原始单信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //PEPerImg.Image = FileConverHelpers.StringToBitmap(data.Rows[0][0].ToString());

        }
        /// <summary>
        /// 查询记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //DataRow SampleDR = GVSampleInfo.GetFocusedDataRow();


                if (GVSampleInfo.GetFocusedDataRow() != null)
                {
                    DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
                    FrmSampleRecord frmDelegateTest = new FrmSampleRecord(dataRow);
                    //Func<string> func = frmDelegateTest.reSaveState;
                    frmDelegateTest.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请先选择需要委托的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// 刷新项目信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                int[] samplesDt = GVSampleInfo.GetSelectedRows();
                if (samplesDt.Length > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("确定需要刷新项目信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {

                        string msg = "";
                        foreach (int a in samplesDt)
                        {
                            commInfoModel<TestWorkModel> commInfo = new commInfoModel<TestWorkModel>();
                            commInfo.UserName = CommonData.UserInfo.names;
                            List<TestWorkModel> listInfo = new List<TestWorkModel>();

                            TestWorkModel testSampleInfo = new TestWorkModel();
                            testSampleInfo.id = GVSampleInfo.GetDataRow(a)["id"] != DBNull.Value ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                            testSampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value ? GVSampleInfo.GetDataRow(a)["barcode"].ToString() : "";
                            //testSampleInfo.id = GVSampleInfo.GetDataRow(a)["id"].ToString();
                            listInfo.Add(testSampleInfo);
                            commInfo.infos = listInfo;
                            string Sr = JsonHelper.SerializeObjct(commInfo);
                            WebApiCallBack jm = ApiHelpers.postInfo(TestItemInfoRefresh, Sr);
                            //commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                            if (jm.code ==0)
                            {
                                ////GVSampleInfo.SetRowCellValue(a, "state", true);
                                //MessageBox.Show("接收完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GVSampleInfo_RowClick(null, null);
                            }
                            else
                            {
                                //MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                msg += testSampleInfo.barcode+":"+jm.msg+"\r\n";

                            }
                        }
                        if(msg!="")
                            MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                else
                {
                    MessageBox.Show("请选择需要刷新项目信息的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 退回流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTReturnFlow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                string testid = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                FrmFlowInfo frmFlowInfo = new FrmFlowInfo(testid);
                Func<string> func = frmFlowInfo.reFlowNO;
                frmFlowInfo.ShowDialog();
                string FlowNO = func();
                if (FlowNO != "")
                {
                    dataRow["groupFlowNO"] = FlowNO;
                    GVSampleInfo_RowClick(null, null);
                }
            }

        }
        /// <summary>
        /// 免疫组化申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTIHC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                int testStateNO = dataRow["testStateNO"] != DBNull.Value ? Convert.ToInt32(dataRow["testStateNO"]) : 0;
                if (testStateNO > 1)
                {
                    FrmIHCAdd frmIHC = new FrmIHCAdd(dataRow, "1");
                    frmIHC.ShowDialog();
                }
                else
                {
                    MessageBox.Show("初审/审核后才能提交免疫组化申请。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("请先选择需要申请的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void PanelTestResult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RDEtestTime_EditValueChanged(object sender, EventArgs e)
        {
            //DateTime SetdateTime = DEtestTime.EditValue!=null? Convert.ToDateTime(DEtestTime.EditValue):DateTime.Now;
            //if(SetdateTime>DateTime.Now)
            //{
            //    MessageBox.Show("检测时间不能大于当前时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    DEtestTime.EditValue = "";
            //}
            //DateTime receiveTime = SampleInfoRow["receiveTime"]!=null? Convert.ToDateTime(SampleInfoRow["receiveTime"]):DateTime.Now;
            //if(receiveTime>SetdateTime)
            //{
            //    MessageBox.Show("检测时间不能小于接收时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    DEtestTime.EditValue = "";
            //}
        }

        private void RDEcheckTime_EditValueChanged(object sender, EventArgs e)
        {
            //DateTime SetcheckTime = DEcheckTime.EditValue != null ? Convert.ToDateTime(DEcheckTime.EditValue) : DateTime.Now;
            //if (SetcheckTime > DateTime.Now)
            //{
            //    MessageBox.Show("审核时间不能大于当前时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    DEcheckTime.EditValue = "";
            //}
            //if(DEtestTime.EditValue != null)
            //{
            //    DateTime SetdateTime = Convert.ToDateTime(DEtestTime.EditValue);
            //    if (SetdateTime> SetcheckTime)
            //    {
            //        MessageBox.Show("审核时间不能小于检验时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        DEcheckTime.EditValue = "";
            //    }
            //    else
            //    {
            //        if (SetdateTime.AddHours(+2) > SetcheckTime)
            //        {
            //            MessageBox.Show("审核时间需要大于检验时间2小时", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            DEcheckTime.EditValue = "";
            //        }
            //    }
            //}

        }
        /// <summary>
        /// 编辑混采信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTHJinfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sampleApplyCode = SampleInfoRow["applyItemCodes"] != DBNull.Value ? SampleInfoRow["applyItemCodes"].ToString() : "";
            string sampleBarcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString() : "";


            if (sampleApplyCode != "" && sampleBarcode != "")
            {
                if (sampleApplyCode == "17" || sampleApplyCode == "19")
                {
                    if (sampleApplyCode == "17")
                    {
                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) != 6)
                        {
                            FrmRYHandle frmRYHandle = new FrmRYHandle(sampleBarcode);
                            frmRYHandle.ShowDialog();
                        }
                        else
                        {
                            FrmRYHandle frmRYHandle = new FrmRYHandle(sampleBarcode, 1);
                            frmRYHandle.ShowDialog();
                        }
                    }

                    if (sampleApplyCode == "19")
                    {
                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) != 6)
                        {
                            FrmHJHandle frmRYHandle = new FrmHJHandle(sampleBarcode);
                            frmRYHandle.ShowDialog();
                        }
                        else
                        {
                            FrmHJHandle frmRYHandle = new FrmHJHandle(sampleBarcode, 1);
                            frmRYHandle.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("选择信息不是混采项目", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请选择需要编辑的混采信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RBEButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormBarcodeInfo formBarcodeInfo = new FormBarcodeInfo(barcodestring);
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            TEsbarcode.EditValue = func();
        }



        #region 上传报告

        bool showReportState = false;
        private void xtraTabPage2_Click(object sender, EventArgs e)
        {
            //showReportState = true;
            //if(perid!=0&&testid!=0)
            //    ShowReportMethod(perid, testid, Barcode, hospitalNo);

        }

        private void xtraTabPage1_Click(object sender, EventArgs e)
        {
            showReportState = false;

        }
        /// <summary>
        /// 报告窗体内部方法
        /// </summary>
        /// <param name="form"></param>
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
            //showReportState = true;
            //if (perid != 0 && testid != 0)
            //    ShowReportMethod(perid, testid, Barcode, hospitalNo);
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
                    ShowReportMethod(perid, testid, Barcode, hospitalNo, testStateNO);

            }
        }
        #endregion
    }

}