using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.PerModel;
//using Common.PerModel;
using Common.SqlModel;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Common.SampleInfoEdit
{
    public partial class FrmSampleInfoCheckEdit : DevExpress.XtraEditors.XtraForm
    {
        string SampleInfoEdit = "";
        DataTable DTSample;
        int connState = 0;
        string perStateNO = "1";
        public FrmSampleInfoCheckEdit(DataTable sampleDT)
        {
            InitializeComponent();
            SampleInfoEdit = ConfigInfos.ReadConfigInfo("SampleInfoEdit");
            TEbarcode.Enabled = false;
            GEhospitalNo.Enabled = false;
            GEagentNo.Enabled = false;
            GCSampleInfo.DataSource = DTSample= sampleDT;
            if (sampleDT.Rows.Count == 1)
            {
                TEbarcode.Enabled = true;
                GEhospitalNo.Enabled = true;
                GEagentNo.Enabled = true;
            }
            else
            {
                GEhospitalNo.Enabled = true;
                GEagentNo.Enabled = true;
            }
            GVSampleInfo.BestFitColumns();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sampleDT"></param>
        /// <param name="sampleState">样本状态1，录入未审核，2。录入审核</param>
        /// <param name="sampleConn">信息来源0，系统，1。微信，2.其他</param>
        public FrmSampleInfoCheckEdit(DataTable sampleDT,int sampleState, int sampleConn = 0)
        {

            InitializeComponent();
            connState = sampleConn;
            SampleInfoEdit = ConfigInfos.ReadConfigInfo("SampleInfoEdit");
            TEbarcode.Enabled = false;
            GEhospitalNo.Enabled = false;
            GEagentNo.Enabled = false;
            if (sampleDT.Rows.Count==1)
            {
                if(sampleState==1)
                {
                    TEbarcode.Enabled = true;
                    GEhospitalNo.Enabled = true;
                    GEagentNo.Enabled = true;
                }
                else
                {
                    GEhospitalNo.Enabled = true;
                    GEagentNo.Enabled = true;
                }
            }
            else
            {
                GEhospitalNo.Enabled = true;
                GEagentNo.Enabled = true;
            }
            GCSampleInfo.DataSource = DTSample = sampleDT;
            GVSampleInfo.BestFitColumns();
        }
        string selectValueID = "";
        int perConnState = 0; //0,本地，1.微信库，2，其他库
        DataTable DTcheckInfo = null;

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

            //TEbarcode.Enabled = false;
            //GEhospitalNo.Enabled = false;
            //GEagentNo.Enabled = false;


            //系统项目信息读取
            GCapplyInfo.DataSource = DTHelper.DTEnable(WorkCommData.DTItemApply);
            DTcheckInfo = WorkCommData.DTItemApply.Clone();
            GCcheckInfo.DataSource = DTcheckInfo;
            GVapplyInfo.BestFitColumns();
            ////BTselect_ItemClick(null, null);
            //GVSampleInfo.BestFitColumns();






            GEagentNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);
            GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);


            if (GVSampleInfo.RowCount == 1)
            {

                DocksampleList.Visibility = DockVisibility.Hidden;
                DataRow rows = GVSampleInfo.GetDataRow(0);
                selectValueID = rows["barcode"].ToString();
                int valueid = Convert.ToInt32(rows["id"]);





                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkPer.SampleInfo";
                if (connState == 1)
                    selectInfo.ConnType = 1;
                selectInfo.wheres = $"id='{valueid}' and dstate=0";
                DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                //if (dataTable == null || dataTable.Rows.Count == 0)
                //{
                //    sInfo selectInfo2 = new sInfo();
                //    selectInfo2.TableName = "WorkPer.SampleInfo";
                //    selectInfo2.ConnType = 1;
                //    selectInfo2.wheres = $"id='{valueid}' and dstate=0";
                //    dataTable = ApiHelpers.postInfo(selectInfo2);
                //    if (dataTable == null || dataTable.Rows.Count == 0)
                //    {
                //        perConnState = 1;
                //    }

                //}



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
                    perStateNO = dataTable.Rows[0]["perStateNO"] != DBNull.Value ? dataTable.Rows[0]["perStateNO"].ToString() : "1";
                    //perSampleState = Convert.ToInt32(dataTable.Rows[0]["perStateNO"]);
                    CEurgent.Checked = dataTable.Rows[0]["urgent"]!=DBNull.Value? Convert.ToBoolean(dataTable.Rows[0]["urgent"]):false;
                    if (WorkCommData.DTItemApply != null)
                    {
                        GCcheckInfo.DataSource = DTcheckInfo = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
                    }
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

            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "系统提示", "正在修改稍等......");


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
                    var first = tmp.Text;//ID,Name,Age,Adress
                    controlname = tmp.Text.Trim().Replace(" ", "");//ID,Name,Age,Adress

                    if (tmp.Control is TextEdit)
                    {
                        var aaaa = tmp.Control as TextEdit;

                        //修改条码号客户名称
                        if (DTSample.Rows.Count == 1)
                        {
                            if (aaaa.Name == "TEbarcode")
                            {
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
                        if (aaaa.Name == "GEhospitalNo")
                        {
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


            foreach (DataRow dataRow in DTSample.Rows)
            {

                EntryInfoModel Infos = new EntryInfoModel();
                Infos.UserName = CommonData.UserInfo.names;
                List<SampleInfoModel> sampleInfos = new List<SampleInfoModel>();

                SampleInfoModel sampleInfo = new SampleInfoModel();
                sampleInfo.perid = dataRow["perid"].ToString();
                if (connState == 1)
                    sampleInfo.code = 1;
                sampleInfo.barcode = dataRow["barcode"].ToString(); ;
                //sampleInfo.Hospital = GEhospitalNo.EditValue.ToString();
                //sampleInfo.HospitalName = GEhospitalNo.Text;

                //sampleInfo.FileString = ImgString;




                string applycodes = "";
                string applyNames = "";

                if (DTSample.Rows.Count > 0 && DTcheckInfo.Rows.Count > 0)
                {
                    foreach (DataRow row in DTcheckInfo.Rows)
                    {
                        applycodes += row["no"].ToString() + ",";
                        applyNames += row["names"].ToString() + ",";
                    }
                    applycodes = applycodes.Substring(0, applycodes.Length - 1);
                    applyNames = applyNames.Substring(0, applyNames.Length - 1);

                }

                sampleInfo.applyCodes = applycodes;
                sampleInfo.applyNames = applyNames;
                sampleInfo.pairsInfo = pairsInfos;
                sampleInfo.pairsOhterInfo = pairsOtherInfos;
                sampleInfos.Add(sampleInfo);

                Infos.sampleInfos = sampleInfos;
                Infos.operatType = 2;
                string sa = Common.JsonHelper.JsonHelper.SerializeObjct(Infos);
                WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoEdit, sa);
                commReInfo<commReSampleInfo> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                if (commReInfo!= null)
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

        private void DockCenter_Click(object sender, EventArgs e)
        {

        }

        private void GCSampleInfo_Click(object sender, EventArgs e)
        {

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

    }
}
