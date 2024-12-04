using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.HotKey;
using Common.JsonHelper;
using Common.LoadShow;
using Common.ManageModel;
using Common.Model;
using Common.SampleInfoEdit;
using Common.SqlModel;

using Common.TestModel.Result;
using Common.WorkModel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace workOther.IHCHandle
{

    public partial class FrmResultInfo : DevExpress.XtraEditors.XtraForm
    {


        //Func<int, AutographInfo, string> func;//接收结果方法
        //Action<string, string, string> actionSampleInfo;//发送信息方法
        DataTable DTTestInfo;
        Form FrmTest;
        string GetIHCInfo = "";
        public static string FileImgPath = Environment.CurrentDirectory + "\\SaveTestDelImg";
        //string TestReceiveReturn = "";
        public FrmResultInfo()
        {
            InitializeComponent();
            DEStarTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GetIHCInfo = ConfigInfos.ReadConfigInfo("GetIHCInfo");
            //OtherTestInfoSelect = ConfigInfos.ReadConfigInfo("OtherTestInfoSelect");
            //TestReceiveReturn = ConfigInfos.ReadConfigInfo("TestReceiveReturn");

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
            Formart("12");//格式化信息列表
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
        //PanelTestResult内部切换窗体方法
        private void formReport(Form form)
        {
            foreach (Control item in this.PanelReportView.Controls)
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
            form.Parent = this.PanelReportView;
            form.Dock = DockStyle.Fill;
            form.Show();
        }



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



        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            try
            {


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
                    delid = SampleInfoRow["subid"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["subid"]) : 0;
                    barcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString() : "";
                    //barcode = SampleInfoRow["barcode"].ToString();
                    //TEsampleID
                    //PathologyNo = SampleInfoRow["pathologyNo"].ToString();
                    //groupNO = SampleInfoRow["groupNO"].ToString();
                    DEsampleTime.EditValue = SampleInfoRow["sampleTime"];
                    TEageDay.EditValue = SampleInfoRow["ageDay"];
                    TEageMoth.EditValue = SampleInfoRow["ageMoth"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    GEagentNO.EditValue = SampleInfoRow["agentNO"];
                    TEageYear.EditValue = SampleInfoRow["ageYear"];
                    MEapplyItemNames.EditValue = SampleInfoRow["submitItemNames"];
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
                    //if(!Convert.IsDBNull(SampleInfoRow["testTime"]))
                    //    DEatestTime.EditValue = Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    DEatestTime.EditValue = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                    TEachecker.EditValue = SampleInfoRow["checker"];
                    //if (!Convert.IsDBNull(SampleInfoRow["checkTime"])) 
                    //    DEacheckTime.EditValue = Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    DEacheckTime.EditValue = SampleInfoRow["checkTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;

                    //if(testid!=0)
                    //{
                    //    sInfo sInfo = new sInfo();
                    //    sInfo.TableName = "WorkTest.ResultPathology";
                    //    sInfo.wheres = $"testid='{testid}'";
                    //    DataTable DTResult = SqlConnServer.getselects(sInfo);
                    //    if(DTResult!=null)
                    //    {
                    //        MEEyeVisible.EditValue = DTResult.Rows[0]["eyeVisible"];
                    //        MEDescriptionLesions.EditValue = DTResult.Rows[0]["descriptionLesions"];
                    //        MEpathologicDiagnosis.EditValue = DTResult.Rows[0]["diagnosis"];
                    //        MEihcResult.EditValue = DTResult.Rows[0]["ihcResult"];
                    //        MEDiagnosisRemark.EditValue = DTResult.Rows[0]["diagnosisRemark"];
                    //    }
                    //}

                    //TEatester.EditValue = SampleInfoRow["tester"];
                    ////if(!Convert.IsDBNull(SampleInfoRow["testTime"]))
                    ////    DEatestTime.EditValue = Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    //DEatestTime.EditValue = SampleInfoRow["testTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                    //TEachecker.EditValue = SampleInfoRow["checker"];
                    ////if (!Convert.IsDBNull(SampleInfoRow["checkTime"])) 
                    ////    DEacheckTime.EditValue = Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    //DEacheckTime.EditValue = SampleInfoRow["checkTime"] != DBNull.Value ? Convert.ToDateTime(SampleInfoRow["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;


                    string groupFlowNOs = SampleInfoRow["groupFlowNO"] != DBNull.Value && SampleInfoRow["groupFlowNO"].ToString() != "" ? SampleInfoRow["groupFlowNO"].ToString() : "1";


                    #region 反射调用检验窗体

                    //if (WorkCommData.DTItemFlow != null)
                    //{
                    //    if (groupFlowNOs != groupFlowNO)
                    //    {
                    //        groupFlowNO = groupFlowNOs;
                    //        if (WorkCommData.DTItemFlow.Select($"no='{groupFlowNO}'").Count() > 0)
                    //        {
                    //            DataRow dataRow = WorkCommData.DTItemFlow.Select($"no='{groupFlowNO}'")[0];

                    //            if (!Convert.IsDBNull(dataRow["reflectionFile"]) && !Convert.IsDBNull(dataRow["reflectionFrm"]))
                    //            {
                    //                reflectionFile = dataRow["reflectionFile"].ToString();
                    //                reflectionFrm = dataRow["reflectionFrm"].ToString();

                    //                //form(ReflectionHelper.CreateForm(reflectionFrm, reflectionFile, this));

                    //                try
                    //                {
                    //                    if (!ReflectionHelper.ShowChildForm(reflectionFrm, this))
                    //                    {


                    //                        string name = reflectionFile + "." + reflectionFrm; //类的名字
                    //                        Assembly ass = Assembly.Load(reflectionFile);
                    //                        //Form doc = (Form)ass.CreateInstance(name);
                    //                        //form(doc);

                    //                        frmtype = ass.GetType(name);//类名
                    //                        objpostResultInfo = Activator.CreateInstance(frmtype);
                    //                        FrmTest = (Form)objpostResultInfo;
                    //                        form(FrmTest);
                    //                        //FrmTestClose = frmtype.GetMethod("formClose");
                    //                        postResultInfos = frmtype.GetMethod("postResultInfo");
                    //                        setResultInfos = frmtype.GetMethod("setResultInfo");
                    //                        FrmOtherSet = frmtype.GetMethod("setOtherInfo");

                    //                    }
                    //                }
                    //                catch (Exception ex)
                    //                {
                    //                    //MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                    MessageBox.Show("文件加载错误" + ex.ToString(), "系统提示");
                    //                }
                    //            }
                    //            else
                    //            {
                    //                reflectionFile = "WorkTest.Test";
                    //                reflectionFrm = "FrmTest";
                    //                try
                    //                {
                    //                    if (!ReflectionHelper.ShowChildForm(reflectionFrm, this))
                    //                    {

                    //                        string name = reflectionFile + "." + reflectionFrm; //类的名字
                    //                        Assembly ass = Assembly.Load(reflectionFile);
                    //                        frmtype = ass.GetType(name);//类名
                    //                        objpostResultInfo = Activator.CreateInstance(frmtype);

                    //                        //objpostResultInfo = Assembly.Load(reflectionFile).GetType(name);
                    //                        FrmTest = (Form)objpostResultInfo;
                    //                        form(FrmTest);
                    //                        //FrmTestClose = frmtype.GetMethod("formClose");
                    //                        postResultInfos = frmtype.GetMethod("postResultInfo");
                    //                        setResultInfos = frmtype.GetMethod("setResultInfo");
                    //                        FrmOtherSet = frmtype.GetMethod("setOtherInfo");

                    //                    }
                    //                }
                    //                catch (Exception ex)
                    //                {
                    //                    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("未匹配到流程文件信息", "系统提示");
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    if (reflectionFile == "")
                    {
                        reflectionFile = "WorkTest.TestPathology";
                        reflectionFrm = "FrmTestPathologyIHC";

                        //form(ReflectionHelper.CreateForm(reflectionFrm, reflectionFile, this));

                        //try
                        //{
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
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //}
                        //}
                    }

                    //object[] paras = new object[] { testid, barcode, groupNO, groupFlowNO };
                    object[] paras = new object[] { testid, SampleInfoRow, 0 };

                    setResultInfos.Invoke(objpostResultInfo, paras);
                    #endregion
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
                    if (Convert.ToInt32(SampleInfoRow["ihcStateNO"]) < 3)
                    {
                        if (Convert.ToInt32(SampleInfoRow["testStateNO"]) >= 2)
                        {
                            if (SaveResult(3))
                            {
                                TEachecker.EditValue = CommonData.UserInfo.names;
                                DEacheckTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                uInfo uInfo2 = new uInfo();
                                uInfo2.TableName = "WorkOther.IHCRecord";
                                uInfo2.value = "ihcStateNO='2'";
                                uInfo2.wheres = $"testid={testid}";
                                uInfo2.MessageShow = 1;
                                ApiHelpers.postInfo(uInfo2);
                                SampleInfoRow["ihcStateNO"] = 2;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("不能再次进行保存，样本信息已经处理完成。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// <param name="testStateNO">1为保存，2为初审，3为审核，4为反审</param>
        /// <returns></returns>
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
                    object[] paras = new object[] { testStateNO, testid, barcode, groupNO, groupFlowNO, autographInfo };
                    string ReturnState = postResultInfos.Invoke(objpostResultInfo, paras).ToString();
                    if (ReturnState != "")
                    //if (postResultInfos.Invoke(objpostResultInfo, paras).ToString() != "0")
                    {
                        try
                        {


                            commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(ReturnState);
                            if (commReInfo.code == 1)
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


            //if (GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent") != DBNull.Value)
            //{
            //    if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent")))
            //    {
            //        e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;//改变背景色
            //                                                                                                                                         //e.Appearance.ForeColor = Color.Red;//改变字体颜色
            //    }
            //}
        }

        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ManageInfoModel selectDelInfo = new ManageInfoModel();
            selectDelInfo.StartTime = Convert.ToDateTime(Convert.ToDateTime(DEStarTime.EditValue).ToString("yyyy-MM-dd"));
            selectDelInfo.EndTime = Convert.ToDateTime(Convert.ToDateTime(DEEndTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd"));
            selectDelInfo.patientName = TEPatientNames.EditValue != null ? TEPatientNames.EditValue.ToString() : "";
            //selectDelInfo.c = TEPatientNames.EditValue!=null? TEPatientNames.EditValue.ToString():"";
            selectDelInfo.barcode = TEBarcodes.EditValue != null ? TEBarcodes.EditValue.ToString() : "";
            selectDelInfo.sState = 1;
            string sr = JsonHelper.SerializeObjct(selectDelInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(GetIHCInfo, sr);
            DataTable dataTable = DTTestInfo =JsonHelper.StringToDT(jm);
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
                    LCTest.Text = $"等待结果({DTTestInfo.Select("ihcStateNO='1'").Count()})";
                    LCResult.Text = $"检验完成({DTTestInfo.Select("ihcStateNO='2'").Count()})";
                    LCFinish.Text = $"检验完成({DTTestInfo.Select("ihcStateNO='3'").Count()})";
                }
                else
                {
                    LCTest.Text = $"等待结果(0)";
                    LCResult.Text = $"结果保存(0)";
                    LCFinish.Text = $"处理完成(0)";
                }
            }
            catch
            {

            }

        }

        //private void BTUp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string FilePath = OpenFileHelpers.GetFilePath(FileExtensionName.img);
        //        if (FilePath.Length != 0)
        //        {
        //            Bitmap bitmap = new Bitmap(FilePath);
        //            Bitmap bitmaps = new Bitmap(bitmap);
        //            NewPictureEdit(bitmaps);
        //            bitmap.Dispose();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


#pragma warning disable CS0414 // 字段“FrmResultInfo.pictureEditLocationxs”已被赋值，但从未使用过它的值
        int pictureEditLocationxs = 0;
#pragma warning restore CS0414 // 字段“FrmResultInfo.pictureEditLocationxs”已被赋值，但从未使用过它的值


        ///// <summary>
        ///// PictureEdit
        ///// </summary>
        ///// <param name="PictureName">图片名称</param>
        ///// <param name="pictureDye">染色倍数</param>
        ///// <param name="bitmap">图像</param>
        //private void NewPictureEdit(Bitmap bitmap)
        //{
        //    try
        //    {

        //        if (bitmap != null)
        //        {
        //            int a = PCImg.Controls.Count + 1;

        //            PictureEdit Pedit = new PictureEdit();
        //            Pedit.Location = new System.Drawing.Point(pictureEditLocationxs, 0);
        //            Pedit.Size = new Size(200, PCImg.Size.Height);
        //            Pedit.Image = bitmap;
        //            Pedit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
        //            Pedit.Click += Pedit_Click;
        //            Pedit.DoubleClick += Pedit_DoubleClick; ;
        //            PCImg.Controls.Add(Pedit);
        //            pictureEditLocationxs += 200;


        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
        //private void BTDown_Click(object sender, EventArgs e)
        //{
        //    DialogResult dialogResult = MessageBox.Show("是否确定删除此照片？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        PCImg.Controls.Remove(pictureEdit);
        //        int xx = 0;
        //        foreach (Control control in PCImg.Controls)
        //        {
        //            control.Location = new System.Drawing.Point(xx, 0);
        //            xx += 200;
        //        }
        //        if (pictureEditLocationxs > 0)
        //        {
        //            pictureEditLocationxs -= 200;
        //        }
        //    }
        //}

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
                if (testid != 0)
                {
                    if (Convert.ToInt32(SampleInfoRow["ihcStateNO"]) == 2)
                    {
                        uInfo uInfo = new uInfo();
                        uInfo.TableName = "WorkTest.SampleInfo";
                        uInfo.value = "reportState=0";
                        uInfo.wheres = $"id={testid}";
                        uInfo.MessageShow = 1;
                        ApiHelpers.postInfo(uInfo);
                        uInfo uInfo2 = new uInfo();
                        uInfo2.TableName = "WorkOther.IHCRecord";
                        uInfo2.value = "ihcStateNO='3'";
                        uInfo2.wheres = $"testid={testid}";
                        uInfo2.MessageShow = 1;
                        ApiHelpers.postInfo(uInfo2);
                        //ApiHelpers.postInfo(uInfo);

                        //dataRow["ihcStateNO"] = '1';
                        dataRow["ihcStateNO"] = 3;
                        GVSampleInfo.RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("结果没有保存，请先保存样本结果", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (Convert.ToInt32(SampleInfoRow["ihcStateNO"]) == 3)
            {
                DialogResult dialogResult = MessageBox.Show("确定返回检验吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
                    if (dataRow != null)
                    {
                        if (testid != 0)
                        {

                            uInfo uInfo = new uInfo();
                            uInfo.TableName = "WorkTest.SampleInfo";
                            uInfo.value = "reportState=null";
                            uInfo.wheres = $"id={testid}";
                            uInfo.MessageShow = 1;
                            ApiHelpers.postInfo(uInfo);
                            uInfo uInfo2 = new uInfo();
                            uInfo2.TableName = "WorkOther.IHCRecord";
                            uInfo2.value = "ihcStateNO='1'";
                            uInfo2.wheres = $"testid={testid}";
                            uInfo2.MessageShow = 1;
                            ApiHelpers.postInfo(uInfo2);
                            //ApiHelpers.postInfo(uInfo);

                            //dataRow["ihcStateNO"] = '1';
                            dataRow["testStateNO"] = 3;
                            dataRow["ihcStateNO"] = 1;
                            GVSampleInfo.RefreshData();

                        }
                        else
                        {
                            MessageBox.Show("没有获取到可用的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("只能退回处理完成样本。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}

