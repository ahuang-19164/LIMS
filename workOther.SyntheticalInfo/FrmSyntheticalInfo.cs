using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.PerModel;
using Common.SampleInfoEdit;

using Common.SqlModel;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace workOther.SyntheticalInfo
{
    public partial class FrmSyntheticalInfo : DevExpress.XtraEditors.XtraForm
    {
        string EntryTableName = "WorkPer.SampleInfo";
        //string entryUser = "全部";
        string SampleInfoCheckSelect = "";
        string SampleInfoCheck = "";
        string SampleInfoCheckRe = "";
        string SampleInfoDelete = "";
        string SampleInfoCheckBc = "";
        public FrmSyntheticalInfo()
        {
            InitializeComponent();
            SampleInfoCheckSelect = ConfigInfos.ReadConfigInfo("SampleInfoCheckSelect");
            SampleInfoCheck = ConfigInfos.ReadConfigInfo("SampleInfoCheck");
            SampleInfoCheckRe = ConfigInfos.ReadConfigInfo("SampleInfoCheckRe");
            SampleInfoDelete = ConfigInfos.ReadConfigInfo("SampleInfoDelete");
            SampleInfoCheckBc = ConfigInfos.ReadConfigInfo("SampleInfoCheckBc");

            foreach (var control in layoutControl1.Items)
            {
                PairsInfoModel pairsOther = new PairsInfoModel();
                //string controlname = "";
                //string controlkey = "";
                //string controlvalue = "";
                if (control is LayoutControlItem)
                {
                    LayoutControlItem tmp = control as LayoutControlItem;
                    //var first = tmp.Text;//ID,Name,Age,Adress
                    //controlname = tmp.Text.Trim();//ID,Name,Age,Adress
                    if (tmp.Control is TextEdit)
                    {
                        var aaaa = tmp.Control as TextEdit;
                        aaaa.ReadOnly = true;
                    }
                }
            }
        }

        private void FrmPerworkInfoCheck_Load(object sender, EventArgs e)
        {

            PanelTestResult.AutoScroll = true;
            PanelTestResult.VerticalScroll.Value = PanelTestResult.VerticalScroll.Maximum;




            SysPowerHelper.UserPower(layoutManager);
            DEStart.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEnd.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GridLookUpEdites.Formats(GEApplyItems);
            GridLookUpEdites.Formats(GEClients);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEtestStateNO);
            GridLookUpEdites.Formats(RGEgroupFlowNO);
            //GridLookUpEdites.Formats(GESampleGroup);

            GridLookUpEdites.Formats(RGEperStateNO);
            //GridLookUpEdites.Formats(RGEpatientSexNO);
            //GridLookUpEdites.Formats(RGEhospitalNo);
            GridLookUpEdites.Formats(GEagentNo);
            GridLookUpEdites.Formats(GEhospitalNo);
            GridLookUpEdites.Formats(GEpatientSexNO);
            GridLookUpEdites.Formats(GEpatientTypeNO);
            GridLookUpEdites.Formats(GEsampleShapeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);
            //GridControls.formartGridView(GVItemInfo);
            //GridControls.showEmbeddedNavigator(GCItemInfo);
            GridControls.formartGridView(GVSampleInfo);
            GridControls.ShowViewColor(GVSampleInfo);
            GridControls.formartGridView(GVGroupInfo, false);
            GridControls.ShowViewColor(GVGroupInfo);
            GridControls.formartGridView(GVrecord, false);
            GridControls.ShowViewColor(GVrecord);
            GEagentNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);


            ///RGEhospitalNo.DataSource=GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            ///RGEpatientSexNO.DataSource=GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEhospitalNo.Properties.DataSource = WorkCommData.DTClientInfo;
            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEtestStateNO.DataSource = WorkCommData.DTStateTest;
            RGEgroupFlowNO.DataSource = WorkCommData.DTItemFlow;
            //RGEperStateNO.DataSource = DTHelper.DTAddAll(WorkCommData.DTTypeSample);
            //RGESampleState.DataSource = DTHelper.DTAddAll(WorkCommData.DTStatePerWork); 
            //RGECreater.DataSource = DTHelper.DTAddAll(CommonData.DTUserInfoAll);






            RGEperStateNO.DataSource = WorkCommData.DTStatePerWork;
            GEClients.Properties.DataSource = DTHelper.DTAddAll(WorkCommData.DTClientInfo);

            GEApplyItems.Properties.DataSource = DTHelper.DTAddAll(WorkCommData.DTItemApply);
            //RGESampleState.DataSource = WorkCommData.DTStatePerWork;
            //GESampleGroup.DataSource = WorkCommData.DTGroupTest;
            GEClients.EditValue = 0;
            GEApplyItems.EditValue = 0;
        }

        private void BTSelects_Click(object sender, EventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkPer.SampleInfo";
            sInfo.UserName = CommonData.UserInfo.names;
            
            sInfo.MessageShow = 1;
            string whereValue = " dstate=0 ";
            if (TEbarcodes.EditValue != null || TEhosBarcode.EditValue != null || TEPatientNames.EditValue != null)
            {
                if (TEbarcodes.EditValue != null && TEbarcodes.EditValue.ToString() != "")
                    whereValue += $" and barcode like '%{TEbarcodes.EditValue.ToString()}%'";
                if (TEhosBarcode.EditValue != null && TEhosBarcode.EditValue.ToString() != "")
                    whereValue += $" and hospitalBarcode like '%{TEhosBarcode.EditValue.ToString()}%'";
                if (TEPatientNames.EditValue != null && TEPatientNames.EditValue.ToString() != "")
                    whereValue += $" and patientName like '%{TEPatientNames.EditValue.ToString()}%'";
            }
            if (whereValue == " dstate=0 ")
            {
                if (GEClients.EditValue.ToString() != "0")
                    whereValue += $" and hospitalNO='{GEClients.EditValue}'";
                if (GEApplyItems.EditValue.ToString() != "0")
                    whereValue += $" and hospitalNO like '%,{GEApplyItems.EditValue},%'";
                whereValue += $" and createTime >= '{Convert.ToDateTime(DEStart.EditValue).ToString()}'";
                whereValue += $" and createTime <= '{Convert.ToDateTime(DEEnd.EditValue).AddDays(+1).ToString()}'";
            }
            sInfo.wheres = whereValue;
            DataTable dataTable = ApiHelpers.postInfo(sInfo);

            if(dataTable==null||dataTable.Rows.Count==0)
            {
                sInfo sInfoWx = new sInfo();
                sInfoWx.TableName = "WorkPer.SampleInfo";
                sInfoWx.ConnType =1;

                sInfoWx.UserName = CommonData.UserInfo.names;
                
                sInfoWx.MessageShow = 1;
                string whereValueWx = " dstate=0 ";
                if (TEbarcodes.EditValue != null || TEhosBarcode.EditValue != null || TEPatientNames.EditValue != null)
                {
                    if (TEbarcodes.EditValue != null && TEbarcodes.EditValue.ToString() != "")
                        whereValueWx += $" and barcode like '%{TEbarcodes.EditValue.ToString()}%'";
                    if (TEhosBarcode.EditValue != null && TEhosBarcode.EditValue.ToString() != "")
                        whereValueWx += $" and hospitalBarcode like '%{TEhosBarcode.EditValue.ToString()}%'";
                    if (TEPatientNames.EditValue != null && TEPatientNames.EditValue.ToString() != "")
                        whereValueWx += $" and patientName like '%{TEPatientNames.EditValue.ToString()}%'";
                }
                if (whereValueWx == " dstate=0 ")
                {
                    if (GEClients.EditValue.ToString() != "0")
                        whereValueWx += $" and hospitalNO='{GEClients.EditValue}'";
                    if (GEApplyItems.EditValue.ToString() != "0")
                        whereValueWx += $" and hospitalNO like '%,{GEApplyItems.EditValue},%'";
                    whereValueWx += $" and createTime >= '{Convert.ToDateTime(DEStart.EditValue).ToString()}'";
                    whereValueWx += $" and createTime <= '{Convert.ToDateTime(DEEnd.EditValue).AddDays(+1).ToString()}'";
                }
                sInfoWx.wheres = whereValueWx;
                DataTable dataTables = ApiHelpers.postInfo(sInfoWx);


                //DataTable WxdataTable = ApiHelpers.postInfo(sInfo);
                GCSampleInfo.DataSource = dataTables;
            }
            else
            {
                GCSampleInfo.DataSource = dataTable;
            }

            GVSampleInfo.BestFitColumns();

            ////if (GESampleState.EditValue != null)
            ////{
            //    CheckSelectModel checkModel = new CheckSelectModel();
            //    checkModel.TableName = EntryTableName;
            //    checkModel.startTime = Convert.ToDateTime(DEStart.EditValue).ToString("yyyy-MM-dd");
            //    checkModel.endTime = Convert.ToDateTime(DEEnd.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
            //    checkModel.UserName = CommonData.UserInfo.names;
            //    checkModel.UserToken = CommonData.UserInfo.UserToken;
            //    //checkModel.sampleState = GESampleState.EditValue.ToString();
            //    //checkModel.entryUserName = RGECreater.ToString();
            //    string Sr = JsonHelper.SerializeObjct(checkModel);
            //    DataTable a = ApiHelpers.postInfo(SampleInfoCheckSelect, Sr);
            //    GCSampleInfo.DataSource = a;
            //    GVSampleInfo.BestFitColumns();

            ////}
        }

        private void BTSampleInfoEdit_Click(object sender, EventArgs e)
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
                    if (Convert.ToInt32(SampleInfoRow["perStateNO"]) != 4)
                    {
                        data.Rows.Add(GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["barcode"], GVSampleInfo.GetDataRow(a)["patientName"]);
                    }
                }

            }
            FrmSampleInfoEdit frmSampleInfoEdit = new FrmSampleInfoEdit(data);
            frmSampleInfoEdit.ShowDialog();
            BTSelects_Click(null, null);
        }



        string reflectionFile = "";
        string reflectionFrm = "";
        MethodInfo postResultInfos;
        MethodInfo setResultInfos;
        MethodInfo FrmOtherSet;
        Type frmtype;
        object objpostResultInfo;
        DataRow SampleInfoRow;//样本信息
        //string SampleID = "";
        string Barcode = "";
        string groupNO = "";
        Form FrmTest;

        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载标本信息......");
            try
            {


                SampleInfoRow = GVSampleInfo.GetFocusedDataRow();
                if (SampleInfoRow != null)
                {
                    //SampleID = SampleInfoRow["sampleID"].ToString();
                    Barcode = SampleInfoRow["barcode"].ToString();
                    //PathologyNo = SampleInfoRow["pathologyNo"].ToString();
                    //groupNO = SampleInfoRow["groupNO"].ToString();
                    DEreceiveTime.EditValue = SampleInfoRow["receiveTime"];
                    DEsampleTime.EditValue = SampleInfoRow["sampleTime"];
                    TEageDay.EditValue = SampleInfoRow["ageDay"];
                    TEageMoth.EditValue = SampleInfoRow["ageMoth"];
                    TEageYear.EditValue = SampleInfoRow["ageYear"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    GEagentNo.EditValue = SampleInfoRow["agentNo"];
                    TEhospitalBarcode.EditValue = SampleInfoRow["hospitalBarcode"];
                    //TEapplyItemCodes.EditValue = SampleInfoRow["applyItemCodes"];
                    //TEapplyItemNames.EditValue = SampleInfoRow["applyItemNames"];
                    TEbarcode.EditValue = SampleInfoRow["barcode"];
                    TEbedNo.EditValue = SampleInfoRow["bedNo"];
                    TEclinicalDiagnosis.EditValue = SampleInfoRow["clinicalDiagnosis"];
                    TEsampleLocation.EditValue = SampleInfoRow["sampleLocation"];
                    TEcutPart.EditValue = SampleInfoRow["cutPart"];
                    TEdepartment.EditValue = SampleInfoRow["department"];
                    TEdoctorPhone.EditValue = SampleInfoRow["doctorPhone"];
                    GEhospitalNo.EditValue = SampleInfoRow["hospitalNo"];
                    TEmedicalNo.EditValue = SampleInfoRow["medicalNo"];
                    DEmenstrualTime.EditValue = SampleInfoRow["menstrualTime"];
                    TEpathologyNo.EditValue = SampleInfoRow["pathologyNo"];
                    TEpatientCardNo.EditValue = SampleInfoRow["patientCardNo"];
                    TEpatientPhone.EditValue = SampleInfoRow["patientPhone"];
                    GEpatientSexNO.EditValue = SampleInfoRow["patientSexNO"];
                    GEpatientTypeNO.EditValue = SampleInfoRow["patientTypeNO"];
                    TEperRemark.EditValue = SampleInfoRow["perRemark"];
                    GEsampleShapeNO.EditValue = SampleInfoRow["sampleShapeNO"];
                    GEsampleTypeNO.EditValue = SampleInfoRow["sampleTypeNO"];
                    TEsendDoctor.EditValue = SampleInfoRow["sendDoctor"];
                    TEpatientAddress.EditValue = SampleInfoRow["patientAddress"];
                    TEpassportNo.EditValue = SampleInfoRow["passportNo"];
                    CEurgent.Checked = SampleInfoRow["urgent"]!=DBNull.Value? Convert.ToBoolean(SampleInfoRow["urgent"]):false;

                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "WorkTest.SampleInfo";
                    sInfo.UserName = CommonData.UserInfo.names;
                    
                    sInfo.MessageShow = 1;
                    string whereValue1 = $"barcode='{Barcode}' and dstate=0";
                    //string whereValue1 = $"barcode='{Barcode}' and dstate=0";
                    sInfo.wheres = whereValue1;
                    DataTable dataTable = ApiHelpers.postInfo(sInfo);
                    GCGroupInfo.DataSource = dataTable;
                    GVGroupInfo.BestFitColumns();


                    sInfo selectInfor = new sInfo();
                    selectInfor.TableName = "WorkComm.SampleRecord";
                    selectInfor.UserName = CommonData.UserInfo.names;
                    
                    selectInfor.MessageShow = 1;
                    string whereValue2 = $"barcode='{Barcode}'";
                    selectInfor.wheres = whereValue2;
                    DataTable datar = ApiHelpers.postInfo(selectInfor);
                    GCrecord.DataSource = datar;
                    GVrecord.BestFitColumns();



                    sInfo selectInfoImg = new sInfo();
                    selectInfoImg.TableName = "WorkPer.SampleImg";
                    selectInfoImg.values = "top 1 filestring";
                    //selectInfoImg.wheres = $"sampleID='{SampleID}' and barcode='{Barcode}'";
                    selectInfoImg.wheres = $"barcode='{Barcode}'";
                    selectInfoImg.OrderColumns = "createTime";
                    DataTable dataImg = ApiHelpers.postInfo(selectInfoImg);
                    if (dataImg != null)
                    {
                        Bitmap imgs= FileConverHelpers.StringToBitmap(dataImg.Rows[0][0].ToString());
                        PEsampleImg.Image = imgs != null ? imgs : null;
                    }
                    else
                    {
                        PEsampleImg.Image = null;
                    }
                        
                    frmWait.HideMe(this);
                }
                else
                {
                    testid = 0;
                    Barcode = "";
                    groupNO = "";
                    //PathologyNo = "";
                    //MessageBox.Show("请先选择样本信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //frmWait.HideMe(this);
                }
            }
            catch
            {
                testid = 0;
                Barcode = "";
                //PathologyNo = "";
            }
            frmWait.HideMe(this);
        }

        int testid = 0;
        string groupFlowNO = "";
        private void GVGroupInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {


                SampleInfoRow = GVGroupInfo.GetFocusedDataRow();
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
                    testid = SampleInfoRow["id"] != DBNull.Value ? Convert.ToInt32(SampleInfoRow["id"]) : 0;
                    //Barcode = SampleInfoRow["barcode"].ToString();
                    //TEsampleID
                    //PathologyNo = SampleInfoRow["pathologyNo"].ToString();
                    groupNO = SampleInfoRow["groupNO"].ToString();

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
                    Barcode = "";
                    groupNO = "";
                    //PathologyNo = "";
                    MessageBox.Show("没有获取到可用的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //frmWait.HideMe(this);
                }
            }
            catch
            {
                testid = 0;
                Barcode = "";
                //PathologyNo = "";
            }
        }
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
        /// 行变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVSampleInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void RTEbarcodes_KeyDown(object sender, KeyEventArgs e)
        {


            //if (e.KeyCode == Keys.Enter)//这是允许输入退格键
            //{
            //    TextEdit textEdit = sender as TextEdit;
            //    if (textEdit.EditValue != null)
            //    {
            //        if (textEdit.EditValue.ToString() != "")
            //        {
            //            CheckSelectModel checkModel = new CheckSelectModel();
            //            List<string> vs = new List<string>();
            //            vs.Add(textEdit.EditValue.ToString());

            //            checkModel.barcode = vs;
            //            checkModel.TableName = EntryTableName;
            //            checkModel.UserName = CommonData.UserInfo.names;
        

            //            //checkModel.entryUserName = RGECreater.ToString();
            //            string Sr = JsonHelper.SerializeObjct(checkModel);
            //            WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheckSelect, Sr);
            //            DataTable dataTable = JsonHelper.StringToDT(jm);
            //            if (dataTable != null)
            //            {
            //                dataTable.Columns.Add("check", typeof(bool));
            //                GCSampleInfo.DataSource = dataTable;
            //                GVSampleInfo.BestFitColumns();
            //                GVSampleInfo.ClearSelection();
            //                GVSampleInfo.SelectRow(0);
            //                GVSampleInfo.FocusedRowHandle = 0;
            //                GVSampleInfo_RowClick(null, null);

            //            }
            //            else
            //            {
            //                clearInfo();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("请输入条码信息", "系统提示");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("请输入条码信息", "系统提示");
            //    }
            //    TEbarcodes.SelectAll();
            //    //TEbarcodes.DoubleClick += TEbarcodes_DoubleClick;
            //    //TEbarcodes.Focus();
            //}

        }
        /// <summary>
        /// 111111333343
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RTEhosBarcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)//这是允许输入退格键
            {
                TextEdit textEdit = sender as TextEdit;
                if (textEdit.EditValue != null)
                {
                    if (textEdit.EditValue.ToString() != "")
                    {
                        CheckSelectModel checkModel = new CheckSelectModel();
                        checkModel.hosbarcode = textEdit.EditValue.ToString();
                        checkModel.TableName = EntryTableName;
                        checkModel.UserName = CommonData.UserInfo.names;
        
                        //checkModel.entryUserName = RGECreater.ToString();
                        string Sr = JsonHelper.SerializeObjct(checkModel);
                        WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheckSelect, Sr);
                        DataTable dataTable = JsonHelper.StringToDT(jm);
                        if (dataTable != null)
                        {
                            dataTable.Columns.Add("check", typeof(bool));
                            GCSampleInfo.DataSource = dataTable;
                            GVSampleInfo.BestFitColumns();
                            GVSampleInfo.ClearSelection();
                            GVSampleInfo.SelectRow(0);
                            GVSampleInfo.FocusedRowHandle = 0;
                            GVSampleInfo_RowClick(null, null);

                        }
                        else
                        {
                            clearInfo();

                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入条码信息", "系统提示");

                    }
                }
                else
                {
                    MessageBox.Show("请输入条码信息", "系统提示");
                }
                TEhosBarcode.SelectAll();
                //TEhosBarcode.Focus();
            }
        }


        /// <summary>
        /// 清空选择展示信息
        /// </summary>
        private void clearInfo()
        {
            DEreceiveTime.EditValue = null;
            DEsampleTime.EditValue = null;
            TEageDay.EditValue = null;
            TEageMoth.EditValue = null;
            TEageYear.EditValue = null;
            TEpatientName.EditValue = null;
            TEpatientName.EditValue = null;
            GEagentNo.EditValue = null;
            TEhospitalBarcode.EditValue = null;
            TEbarcode.EditValue = null;
            TEbedNo.EditValue = null;
            TEclinicalDiagnosis.EditValue = null;
            TEsampleLocation.EditValue = null;
            TEcutPart.EditValue = null;
            TEdepartment.EditValue = null;
            TEdoctorPhone.EditValue = null;
            GEhospitalNo.EditValue = null;
            TEmedicalNo.EditValue = null;
            DEmenstrualTime.EditValue = null;
            TEpathologyNo.EditValue = null; ;
            TEpatientCardNo.EditValue = null;
            TEpatientPhone.EditValue = null;
            GEpatientSexNO.EditValue = null; ;
            GEpatientTypeNO.EditValue = null;
            TEperRemark.EditValue = null;
            GEsampleShapeNO.EditValue = null;
            GEsampleTypeNO.EditValue = null;
            TEsendDoctor.EditValue = null;
            TEpatientAddress.EditValue = null;
            TEpassportNo.EditValue = null;
            CEurgent.Checked = false;
            GCSampleInfo.DataSource = null;
        }

        private void GCSampleInfo_Click(object sender, EventArgs e)
        {

        }

        private void PEsampleImg_DoubleClick(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)PEsampleImg.Image;
            ShowImgHelper.ViewOrignalImage(bitmap);



            //PEsampleImg.ShowImageEditorDialog();
        }
    }
}
