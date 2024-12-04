using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.PerModel;
using Common.SqlModel;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Common.SampleInfoEdit
{
    public partial class FrmSampleInfoEdit : DevExpress.XtraEditors.XtraForm
    {
        string SampleInfoEdit = "";
        DataTable DTSample;
        int connState = 0;
        bool testState = false;
        public FrmSampleInfoEdit(DataTable sampleDT)
        {
            InitializeComponent();
            SampleInfoEdit = ConfigInfos.ReadConfigInfo("SampleInfoEdit");
            TEbarcode.Enabled = false;
            GEhospitalNo.Enabled = false;
            GEagentNo.Enabled = false;
            GCSampleInfo.DataSource = DTSample= sampleDT;
            GVSampleInfo.BestFitColumns();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sampleDT"></param>
        /// <param name="sampleState">信息来源，0 ，系统，1.微信,2检验中</param>

        public FrmSampleInfoEdit(DataTable sampleDT,int sampleConn =0)
        {
            connState = sampleConn;
            InitializeComponent();
            TEbarcode.Enabled = false;
            GEhospitalNo.Enabled = false;
            GEagentNo.Enabled = false;
            if (sampleConn == 2)
                testState = true;
            //if (sampleDT.Rows.Count == 1)
            //{
            //    if (sampleState == 1)
            //    {
            //        TEbarcode.Enabled = true;
            //        GEhospitalNo.Enabled = true;
            //        GEagentNo.Enabled = true;
            //    }
            //    else
            //    {
            //        GEhospitalNo.Enabled = true;
            //        GEagentNo.Enabled = true;
            //    }
            //}
            //else
            //{
            //    GEhospitalNo.Enabled = true;
            //    GEagentNo.Enabled = true;
            //}
            SampleInfoEdit = ConfigInfos.ReadConfigInfo("SampleInfoEdit");
            GCSampleInfo.DataSource = DTSample = sampleDT;
            GVSampleInfo.BestFitColumns();
        }







        string selectValueID = "";
        //string perConnState = "0"; //0,本地，1.微信库，2，其他库
        string perStateNO = "0"; //样本状态

        private void FrmSampleInfoEdit_Load(object sender, EventArgs e)
        {
            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);
            TextEdits.TextFormat(TEageDay);
            TextEdits.TextFormat(TEageMoth);
            TextEdits.TextFormat(TEageYear);
            GridLookUpEdites.Formats(GEagentNo);
            GridLookUpEdites.Formats(GEhospitalNo);
            GridLookUpEdites.Formats(GEpatientSexNO);
            GridLookUpEdites.Formats(GEpatientTypeNO);
            GridLookUpEdites.Formats(GEsampleShapeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);

            TEbarcode.Enabled = false;
            GEhospitalNo.Enabled = false;
            GEagentNo.Enabled = false;



            GEagentNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);
            GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);


            if (GVSampleInfo.RowCount == 1)
            {

                DocksampleList.Visibility = DockVisibility.Hidden;
                sInfo selectInfo = new sInfo();
                if (testState)
                {
                    DataRow rows = GVSampleInfo.GetDataRow(0);
                    selectValueID = rows["id"].ToString();
                    if (connState == 1)
                        selectInfo.ConnType = 1;
                    selectInfo.TableName = "WorkTest.SampleInfo";
                    selectInfo.wheres = $"id='{selectValueID}' and dstate=0";

                }
                else
                {
                    DataRow rows = GVSampleInfo.GetDataRow(0);
                    selectValueID = rows["barcode"].ToString();
                    int valueid = Convert.ToInt32(rows["perid"]);
                    selectInfo.TableName = "WorkPer.SampleInfo";
                    if (connState == 1)
                        selectInfo.ConnType = 1;
                    selectInfo.wheres = $"id='{valueid}' and dstate=0";

                }
                DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                if (dataTable != null)
                {
                    DEreceiveTime.EditValue = dataTable.Rows[0]["receiveTime"];
                    DEsampleTime.EditValue = dataTable.Rows[0]["sampleTime"];
                    TEageDay.EditValue = dataTable.Rows[0]["ageDay"];
                    TEageMoth.EditValue = dataTable.Rows[0]["ageMoth"];
                    TEageYear.EditValue = dataTable.Rows[0]["ageYear"];
                    //TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    GEagentNo.EditValue = dataTable.Rows[0]["agentNO"];
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
                    GEhospitalNo.EditValue = dataTable.Rows[0]["hospitalNO"];
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
                    TEpassportNo.EditValue = dataTable.Rows[0]["passportNo"];
                    TEpatientAddress.EditValue = dataTable.Rows[0]["patientAddress"];
                    TEnumber.EditValue = dataTable.Rows[0]["number"];
                    //perStateNO = dataTable.Rows[0]["perStateNO"]!=DBNull.Value? dataTable.Rows[0]["perStateNO"].ToString():"1";
                    //perSampleState = Convert.ToInt32(dataTable.Rows[0]["perStateNO"]);
                    CEurgent.Checked = dataTable.Rows[0]["urgent"] != DBNull.Value ? Convert.ToBoolean(dataTable.Rows[0]["urgent"]) : false;
                }
                else
                {
                    MessageBox.Show("没有读取到可修改的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            else
            {
                TEhospitalBarcode.Enabled = false;
                DocksampleList.Visibility = DockVisibility.Visible;
                DEreceiveTime.EditValue = null;
                DEsampleTime.EditValue = null;
                TEageDay.EditValue = null;
                TEageMoth.EditValue = null;
                TEageYear.EditValue = null;
                TEpatientName.EditValue = null;
                TEpatientName.EditValue = null;
                GEagentNo.EditValue = null;
                TEhospitalBarcode.EditValue = null;
                //TEapplyItemCodes.EditValue = dataTable.Rows[0]["applyItemCodes"];
                //TEapplyItemNames.EditValue = dataTable.Rows[0]["applyItemNames"];
                TEbarcode.EditValue = null;
                TEbedNo.EditValue = null;
                TEclinicalDiagnosis.EditValue = null;
                TEcutPart.EditValue = null;
                TEdepartment.EditValue = null;
                TEdoctorPhone.EditValue = null;
                GEhospitalNo.EditValue = null;
                TEmedicalNo.EditValue = null;
                DEmenstrualTime.EditValue = null;
                TEpathologyNo.EditValue = null;
                TEpatientCardNo.EditValue = null;
                TEpatientPhone.EditValue = null;
                GEpatientSexNO.EditValue = null;
                GEpatientTypeNO.EditValue = null;
                TEperRemark.EditValue = null;
                GEsampleShapeNO.EditValue = null;
                GEsampleTypeNO.EditValue = null;
                TEsendDoctor.EditValue = null;
                //perSampleState = Convert.ToInt32(dataTable.Rows[0]["perStateNO"]);
                TEpassportNo.EditValue = null;
                TEnumber.EditValue = null;
                TEpatientAddress.EditValue = null;
                CEurgent.Checked = false;


            }
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            FrmWait frmWait = new FrmWait();frmWait.ShowMe(this, "系统提示", "正在修改稍等......");
            string msg = "";
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
                    controlname = tmp.Text.Trim().Replace(" ", "");//ID,Name,Age,Adress

                    if (tmp.Control is TextEdit)
                    {
                        var aaaa = tmp.Control as TextEdit;
                        if (aaaa.Name != "TEbarcode" && aaaa.Name != "GEhospitalNo")
                        {
                            if (aaaa.EditValue != null)
                            {
                                controlkey = aaaa.Name;
                                controlcolumn = aaaa.Tag != null ? aaaa.Tag.ToString() : "";
                                if (aaaa.EditValue != null && controlcolumn != "")
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
                    }
                    else
                    {
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
                string controlname = "";
                string controlkey = "";
                string controlvalue = "";
                string controlcolumn = "";
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
                            controlkey = aaaa.Name;
                            controlcolumn = aaaa.Tag != null ? aaaa.Tag.ToString() : "";
                            if (aaaa.EditValue != null && controlcolumn != "")
                            {
                                if (controlkey.Contains("GE"))
                                {
                                    controlvalue = aaaa.Text.ToString();//ID,Name,Age,Adress
                                    if (controlvalue.Length > 0)
                                    {
                                        PairsInfoModel pairs = new PairsInfoModel();
                                        pairs.caption = controlname;
                                        pairs.keyName = controlkey;
                                        pairs.valueString = controlvalue;
                                        pairs.columnName = controlcolumn.Substring(0, controlcolumn.Length - 2) + "Names";
                                        pairsOtherInfos.Add(pairs);
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
                                    pairsOtherInfos.Add(pairs);
                                }

                            }

                        }


                    }
                    else
                    {
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
                            pairsOtherInfos.Add(pairs);

                        }
                    }
                }
            }


            //DataTable dataTable = GCSampleInfo.DataSource as DataTable;
            foreach (DataRow dataRow in DTSample.Rows)
            {
                EntryInfoModel Infos = new EntryInfoModel();
                Infos.UserName = CommonData.UserInfo.names;
                if (connState == 1)
                    Infos.connType = 1;
                List<SampleInfoModel> sampleInfos = new List<SampleInfoModel>();
                if (dataRow["barcode"] != DBNull.Value)
                {

                    
                    SampleInfoModel sampleInfo = new SampleInfoModel();
                    sampleInfo.perid = dataRow["perid"].ToString();
                    sampleInfo.testid = dataRow["id"].ToString();
                    if (connState==1&& perStateNO=="1")
                        sampleInfo.code = 1;
                    sampleInfo.barcode = dataRow["barcode"].ToString();

                    sampleInfo.pairsInfo = pairsInfos;
                    sampleInfo.pairsOhterInfo = pairsOtherInfos;
                    sampleInfos.Add(sampleInfo);

                    #region


                    //                Dictionary<string, object> pairs = new Dictionary<string, object>();
                    //                pairs.Add("dstate",0);
                    //                pairs.Add("state", 1);
                    //                pairs.Add("connectTime", DEconnectTime.EditValue);
                    //                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //                pairs.Add("sampleTime", DEsampleTime.EditValue);
                    //                pairs.Add("ageDay", TEageDay.EditValue);
                    //                pairs.Add("ageMoth", TEageMoth.EditValue);
                    //                pairs.Add("ageYear", TEageYear.EditValue);
                    //                pairs.Add("perStateNO", 1);
                    //                pairs.Add("patientName", TEpatientName.EditValue);
                    //                pairs.Add("hospitalBarcode", TEhospitalBarcode.EditValue);
                    //                pairs.Add("agentName", GEagentNo.Text);
                    //                pairs.Add("agentNO", GEagentNo.EditValue);
                    //                pairs.Add("applyItemCodes", applycodes);
                    //                pairs.Add("applyItemNames", applyNames);
                    //                pairs.Add("barcode", TEbarcode.EditValue);
                    //                pairs.Add("bedNo", TEbedNo.EditValue);
                    //                pairs.Add("clinicalDiagnosis", TEclinicalDiagnosis.EditValue);
                    //                pairs.Add("creator", CommonData.UserInfo.names);
                    //                pairs.Add("cutPart", TEcutPart.EditValue);
                    //                pairs.Add("department", TEdepartment.EditValue);
                    //                pairs.Add("doctorPhone", TEdoctorPhone.EditValue);
                    //                pairs.Add("hospitalName", GEhospitalNO.Text);
                    //                pairs.Add("hospitalNO", GEhospitalNO.EditValue);
                    //                pairs.Add("medicalNo", TEmedicalNo.EditValue);
                    //                pairs.Add("menstrualTime", DEmenstrualTime.EditValue);
                    //                pairs.Add("pathologyNo", TEpathologyNo.EditValue);
                    //                pairs.Add("patientCardNo", TEpatientCardNo.EditValue);
                    //                pairs.Add("patientPhone", TEpatientPhone.EditValue);
                    //                pairs.Add("patientSexNames", GEpatientSexNO.Text);
                    //                pairs.Add("patientSexNO", GEpatientSexNO.EditValue);
                    //                pairs.Add("patientTypeNames", GEpatientTypeNO.Text);
                    //                pairs.Add("patientTypeNO", GEpatientTypeNO.EditValue);
                    //                pairs.Add("perRemark", TEperRemark.EditValue);
                    //                pairs.Add("sampleShapeNames", GEsampleShapeNO.Text);
                    //                pairs.Add("sampleShapeNO", GEsampleShapeNO.EditValue);
                    //                pairs.Add("sampleTypeNames", GEsampleTypeNO.Text);
                    //                pairs.Add("sampleTypeNO", GEsampleTypeNO.EditValue);
                    //                pairs.Add("sendDoctor", TEsendDoctor.EditValue);
                    //                pairs.Add("urgent", CEurgent.Checked);

                    //                InsertInfo insertInfo = new InsertInfo();
                    //                insertInfo.TableName = "WorkPer.SampleInfo";
                    //                insertInfo.values = pairs;
                    //                int a = ApiHelpers.postInfo(insertInfo);

                    //                if(a==1)
                    //                {
                    //                    GVSampleInfo.AddNewRow();
                    //                    CameraImage = PEsampleImg.Image as Bitmap;
                    //                    //if (CameraImage != null)
                    //                    //{


                    //                        string ssss = "";
                    //                        //保存图片方法
                    //                        if (CameraImage != null)
                    //                        {

                    //                            ///保存物理图片
                    //                            string FileSampleImgPath = FileImgPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                    //                            if (!Directory.Exists(FileSampleImgPath))
                    //                            {
                    //                                Directory.CreateDirectory(FileSampleImgPath);
                    //                            }
                    //                            string FileSavePath = FileSampleImgPath + "\\" + TEbarcode.EditValue + ".png";
                    //                            if (File.Exists(FileSavePath))
                    //                            {
                    //                                File.Delete(FileSavePath);
                    //                            }
                    //                            Bitmap bitmaps = ImageCompressHelper.SizeImage(CameraImage, 800, 800);
                    //                            bitmaps.Save(FileSavePath, ImageFormat.Png);
                    //                            ssss = FileConverHelpers.BitmapTostring(bitmaps);
                    //                        }
                    //                        ///保存字符串图片方法
                    //                        Dictionary<string, object> pairsImg = new Dictionary<string, object>();
                    //                        pairsImg.Add("dstate",0);
                    //                        pairsImg.Add("state", 1);
                    //                        pairsImg.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //                        pairsImg.Add("sort", 0);
                    //                        pairsImg.Add("barcode", TEbarcode.EditValue);
                    //                        pairsImg.Add("class", "原始单");
                    //                        pairsImg.Add("pictureNames", TEbarcode.EditValue + ".png");
                    //                        pairsImg.Add("filestring", ssss);
                    //                        pairsImg.Add("sampleID", TEhospitalBarcode.EditValue);
                    //                        InsertInfo insertInfoImg = new InsertInfo();
                    //                        insertInfoImg.TableName = "WorkPer.SampleImg";
                    //                        insertInfoImg.InsertValue = pairsImg;
                    //                        insertInfoImg.MessageShow = 1;
                    //                        a = ApiHelpers.postInfo(insertInfoImg);
                    //                        if (a == 1)
                    //                        {
                    //                            BTAdd_ItemClick(null, null);

                    //                        }
                    //                        else
                    //                        {
                    //                            MessageBox.Show("原单保存失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                        }
                    //                    //}
                    //                    //else
                    //                    //{
                    //                    //    MessageBox.Show("没有原单是否继续保存", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                    //}
                    //                }
                    //                else
                    //                {
                    //                    MessageBox.Show("信息保存失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("项目信息不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("条码号和医院信息不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("条码号和医院信息不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //}
                    //else
                    //{
                    //    GVcheckInfo.FocusedRowHandle = -1;
                    //    if(perSampleState==1)
                    //    {
                    //        if (TEbarcode.EditValue != null && GEhospitalNO.EditValue != null)
                    //        {
                    //            if (TEbarcode.EditValue != "" && GEhospitalNO.EditValue != "")
                    //            {


                    //                if (DTcheckInfo.Rows.Count > 0)
                    //                {
                    //                    string applycodes = "";
                    //                    string applyNames = "";
                    //                    foreach (DataRow row in DTcheckInfo.Rows)
                    //                    {
                    //                        applycodes += row["no"].ToString() + ",";
                    //                        applyNames += row["names"].ToString() + ",";
                    //                    }
                    //                    applycodes = applycodes.Substring(0, applycodes.Length - 1);
                    //                    applyNames = applyNames.Substring(0, applyNames.Length - 1);

                    //                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    //                    pairs.Add("dstate",0);
                    //                    pairs.Add("state", 1);
                    //                    pairs.Add("connectTime", DEconnectTime.EditValue);
                    //                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //                    pairs.Add("sampleTime", DEsampleTime.EditValue);
                    //                    pairs.Add("ageDay", TEageDay.EditValue);
                    //                    pairs.Add("ageMoth", TEageMoth.EditValue);
                    //                    pairs.Add("ageYear", TEageYear.EditValue);
                    //                    pairs.Add("perStateNO", 1);
                    //                    pairs.Add("patientName", TEpatientName.EditValue);
                    //                    pairs.Add("hospitalBarcode", TEhospitalBarcode.EditValue);

                    //                    pairs.Add("agentName", GEagentNo.Text);
                    //                    pairs.Add("agentNO", GEagentNo.EditValue);
                    //                    pairs.Add("applyItemCodes", applycodes);
                    //                    pairs.Add("applyItemNames", applyNames);
                    //                    pairs.Add("barcode", TEbarcode.EditValue);
                    //                    pairs.Add("bedNo", TEbedNo.EditValue);
                    //                    pairs.Add("clinicalDiagnosis", TEclinicalDiagnosis.EditValue);
                    //                    pairs.Add("creator", CommonData.UserInfo.names);
                    //                    pairs.Add("cutPart", TEcutPart.EditValue);
                    //                    pairs.Add("department", TEdepartment.EditValue);
                    //                    pairs.Add("doctorPhone", TEdoctorPhone.EditValue);
                    //                    pairs.Add("hospitalName", GEhospitalNO.Text);
                    //                    pairs.Add("hospitalNO", GEhospitalNO.EditValue);
                    //                    pairs.Add("medicalNo", TEmedicalNo.EditValue);
                    //                    pairs.Add("menstrualTime", DEmenstrualTime.EditValue);
                    //                    pairs.Add("pathologyNo", TEpathologyNo.EditValue);
                    //                    pairs.Add("patientCardNo", TEpatientCardNo.EditValue);
                    //                    pairs.Add("patientPhone", TEpatientPhone.EditValue);
                    //                    pairs.Add("patientSexNames", GEpatientSexNO.Text);
                    //                    pairs.Add("patientSexNO", GEpatientSexNO.EditValue);
                    //                    pairs.Add("patientTypeNames", GEpatientTypeNO.Text);
                    //                    pairs.Add("patientTypeNO", GEpatientTypeNO.EditValue);
                    //                    pairs.Add("perRemark", TEperRemark.EditValue);
                    //                    pairs.Add("sampleShapeNames", GEsampleShapeNO.Text);
                    //                    pairs.Add("sampleShapeNO", GEsampleShapeNO.EditValue);
                    //                    pairs.Add("sampleTypeNames", GEsampleTypeNO.Text);
                    //                    pairs.Add("sampleTypeNO", GEsampleTypeNO.EditValue);
                    //                    pairs.Add("sendDoctor", TEsendDoctor.EditValue);


                    //                    pairs.Add("urgent", CEurgent.Checked);


                    //                    UpdateInfo updateInfo = new UpdateInfo();
                    //                    updateInfo.TableName = "WorkPer.SampleInfo";
                    //                    updateInfo.values = pairs;
                    //                    updateinfo.values = $"barcode='{selectValueID}'";
                    //                    int a = ApiHelpers.postInfo(updateInfo);
                    //                    //CameraImage = PEsampleImg.Image as Bitmap;
                    //                    //保存图片方法
                    //                    if (CameraImage != PEsampleImg.Image as Bitmap)
                    //                    {
                    //                        CameraImage = PEsampleImg.Image as Bitmap;
                    //                        //if(CameraImage!=null)
                    //                        //{
                    //                            ///保存物理图片
                    //                            string FileSampleImgPath = FileImgPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                    //                            if (!Directory.Exists(FileSampleImgPath))
                    //                            {
                    //                                Directory.CreateDirectory(FileSampleImgPath);
                    //                            }
                    //                            string FileSavePath = FileSampleImgPath + "\\" + TEbarcode.EditValue + ".png";
                    //                            if (File.Exists(FileSavePath))
                    //                            {
                    //                                File.Delete(FileSavePath);
                    //                            }
                    //                            Bitmap bitmaps = ImageCompressHelper.SizeImage(CameraImage, 800, 800);
                    //                            bitmaps.Save(FileSavePath, ImageFormat.Png);
                    //                            string ssss = FileConverHelpers.BitmapTostring(bitmaps);


                    //                            ///保存字符串图片方法
                    //                            Dictionary<string, object> pairsImg = new Dictionary<string, object>();
                    //                            pairsImg.Add("dstate",0);
                    //                            pairsImg.Add("state", 1);
                    //                            pairsImg.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //                            pairsImg.Add("sort", 0);
                    //                            pairsImg.Add("barcode", TEbarcode.EditValue);
                    //                            pairsImg.Add("class", "原始单");
                    //                            pairsImg.Add("pictureNames", TEbarcode.EditValue + ".png");
                    //                            pairsImg.Add("filestring", ssss);
                    //                            pairsImg.Add("sampleID", TEhospitalBarcode.EditValue);
                    //                            UpdateInfo updateInfoImg = new UpdateInfo();
                    //                            updateInfoImg.TableName = "WorkPer.SampleImg";
                    //                            updateInfoImg.values = pairsImg;
                    //                            updateInfoImg.wheres = $"barcode='{selectValueID}'";
                    //                            updateInfoImg.MessageShow = 1;
                    //                            a = ApiHelpers.postInfo(updateInfoImg);
                    //                        //}

                    //                    }
                    #endregion
                }
                Infos.sampleInfos = sampleInfos;
                Infos.operatType = 2;
                string s = Common.JsonHelper.JsonHelper.SerializeObjct(Infos);
                WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoEdit, s);

                commReInfo<commReSampleInfo> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                if (commReInfo!=null)
                {
                    foreach (commReSampleInfo reSampleInfo in commReInfo.infos)
                    {
                        if (reSampleInfo.code != 0)
                            msg += reSampleInfo.barcode + ":" + reSampleInfo.msg + "\r\n";
                    }
                }
            }
            if (msg != "")
                MessageBox.Show(msg, "信息修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
            frmWait.HideMe(this);
            this.Close();


        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool sampleTimeState = false;//监控采样时间是否修改
        private void DEsampleTime_EditValueChanged(object sender, EventArgs e)
        {
            sampleTimeState = true;
        }
        bool receiveTimeState = false;//监控接收时间是否修改
        private void DEreceiveTime_EditValueChanged(object sender, EventArgs e)
        {
            receiveTimeState = true;
        }
    }
}
