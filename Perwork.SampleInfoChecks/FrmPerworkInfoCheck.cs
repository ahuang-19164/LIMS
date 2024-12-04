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

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraWaitForm;
using Ms.HJInfoHandle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using workOther.SyntheticalInfo;

namespace Perwork.SampleInfoChecks
{
    public partial class FrmPerworkInfoCheck : DevExpress.XtraEditors.XtraForm
    {





        string EntryTableName = "WorkPer.SampleInfo";
        //string entryUser = "全部";
        string GetCheckInfo = "";
        string SampleInfoCheck = "";
        string SampleInfoCheckRe = "";
        string SampleInfoDelete = "";
        string SampleInfoCheckBc = "";
        public FrmPerworkInfoCheck()
        {
            InitializeComponent();
            //getTemplateInfo();
            getPrintInfo();
            GetCheckInfo = ConfigInfos.ReadConfigInfo("GetCheckInfo");
            SampleInfoCheck = ConfigInfos.ReadConfigInfo("SampleInfoCheck");
            SampleInfoCheckRe = ConfigInfos.ReadConfigInfo("SampleInfoCheckRe");
            SampleInfoDelete = ConfigInfos.ReadConfigInfo("SampleInfoDelete");
            SampleInfoCheckBc = ConfigInfos.ReadConfigInfo("SampleInfoCheckBc");

            foreach (var control in layoutControl1.Items)
            {
                PairsInfoModel pairsOther = new PairsInfoModel();
                string controlname = "";
                string controlkey = "";
                string controlvalue = "";
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
            SysPowerHelper.UserPower(layoutManager);
            DEStart.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEnd.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GridLookUpEdites.Formats(GESampleState);
            //GridLookUpEdites.Formats(GESampleStates);
            GridLookUpEdites.Formats(GECreater);




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
            GridControls.showEmbeddedNavigator(GCItemInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);
            GridControls.formartGridView(GVSampleInfo);
            GridControls.ShowViewColor(GVSampleInfo);
            GEagentNo.Properties.DataSource = WorkCommData.DTClientAgent;
            GEhospitalNo.Properties.DataSource = WorkCommData.DTClientInfo;

            ///RGEhospitalNo.DataSource=GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            ///RGEpatientSexNO.DataSource=GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);

            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            //RGEperStateNO.DataSource = DTHelper.DTAddAll(WorkCommData.DTTypeSample);
            //RGESampleState.DataSource = DTHelper.DTAddAll(WorkCommData.DTStatePerWork); 
            //RGECreater.DataSource = DTHelper.DTAddAll(CommonData.DTUserInfoAll);






            RGEperStateNO.DataSource = WorkCommData.DTStatePerWork;



            GESampleState.Properties.DataSource = DTHelper.DTAddAll(WorkCommData.DTStatePerWork);
            //GESampleStates.Properties.DataSource = DTHelper.DTAddAll(WorkCommData.DTStatePerWork);
            GECreater.Properties.DataSource = DTHelper.DTAddAll(CommonData.DTUserInfoAll);
            //RGESampleState.DataSource = WorkCommData.DTStatePerWork;
            //GESampleGroup.DataSource = WorkCommData.DTGroupTest;

            GESampleState.EditValue =1;
            //GESampleStates.EditValue =1;
            GECreater.EditValue = 0;

        }




        /// <summary>
        /// 样本查询方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSelects_Click(object sender, EventArgs e)
        {

            BTSelects.Enabled = false;

            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "查询信息请稍后......");

            if (GESampleState.EditValue != null)
            {

                CheckSelectModel checkModel = new CheckSelectModel();
                checkModel.TableName = EntryTableName;
                checkModel.startTime = Convert.ToDateTime(DEStart.EditValue).ToString("yyyy-MM-dd");
                checkModel.endTime = Convert.ToDateTime(DEEnd.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
                checkModel.UserName = CommonData.UserInfo.names;

                checkModel.sampleState =autoState==true? "1" : GESampleState.EditValue.ToString();
                barcodestring = TEbarcodes.EditValue != null ? TEbarcodes.EditValue.ToString().Replace('，', ',') : "";//记录查询
                if (barcodestring != "")
                {
                    List<string> vs = new List<string>();
                    string[] codes = barcodestring.Split(',');
                    foreach (string code in codes)
                    {
                        vs.Add(code.ToUpper());
                    }
                    checkModel.barcode = vs;
                }
                checkModel.connstate = 1;
                if (GECreater.Text != "全部")
                {
                    checkModel.entryUserName = GECreater.Text;
                }
                else
                {
                    checkModel.entryUserName = "";
                }
                //checkModel.entryUserName = RGECreater.ToString();
                string Sr = JsonHelper.SerializeObjct(checkModel);
                //DataTable a = ApiHelpers.postInfo(SampleInfoCheckSelect, Sr);
                WebApiCallBack jm = ApiHelpers.postInfo(GetCheckInfo, Sr);
                //DataTable a = JsonHelper.JsonConvertObject<DataTable>(jm);
                if (jm.code==0)
                {
                    DataTable a = JsonHelper.StringToDT(jm.data.ToString());
                    if (a != null)
                    {
                        a.Columns.Add("check", typeof(bool));
                        GCSampleInfo.DataSource = a;
                        GVSampleInfo.BestFitColumns();
                    }
                    else
                    {
                        GCSampleInfo.DataSource = a;
                        GVSampleInfo.BestFitColumns();
                    }
                    CECheck.Checked = false;
                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                


            }
            BTSelects.Enabled = true;

            frmWait.HideMe(this);
        }
        /// <summary>
        /// 编辑样本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSampleInfoEdit_Click(object sender, EventArgs e)
        {
            //layoutControl1.Enabled = true;
            int[] samplesDt = GVSampleInfo.GetSelectedRows();
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("perid");
            data.Columns.Add("barcode");
            data.Columns.Add("patientName");

            bool sampleState = true;//判断样本信息是否已经审核
            //int editState = 1;
            for (int a = GVSampleInfo.RowCount - 1; a>=0; a--)
            {
                if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                {
                    if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                    {
                        string perperStateNO = GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value ? GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() : "1";
                        if (perperStateNO=="1")
                        {
                            data.Rows.Add(GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["barcode"], GVSampleInfo.GetDataRow(a)["patientName"]);
                        }
                        else
                        {
                            sampleState = false;
                            //editState = 2;
                            data.Rows.Add(GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["id"], GVSampleInfo.GetDataRow(a)["barcode"], GVSampleInfo.GetDataRow(a)["patientName"]);
                        }
                        
                    }
                }
            }
            if (data.Rows.Count > 0)
            {
                if (sampleState)
                {

                    FrmSampleInfoCheckEdit frmSampleInfoEdit = new FrmSampleInfoCheckEdit(data, 1, 0);
                    frmSampleInfoEdit.ShowDialog();
                }
                else
                {
                    FrmSampleInfoEdit frmSampleInfoEdit = new FrmSampleInfoEdit(data, 0);
                    frmSampleInfoEdit.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("请选择需要编辑的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //BTSelects_Click(null, null);
        }
        /// <summary>
        /// 全选事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CECheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CECheck.Checked)
            {
                for (int a = 0; a < GVSampleInfo.RowCount; a++)
                {
                    GVSampleInfo.SetRowCellValue(a, "check", true);
                }
            }
            else
            {
                for (int a = 0; a < GVSampleInfo.RowCount; a++)
                {
                    GVSampleInfo.SetRowCellValue(a, "check", false);
                }
            }
        }

        /// <summary>
        /// 样本审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTChecks_Click(object sender, EventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "正在审核请稍等......");

            try
            {
                BTChecks.Enabled = false;
                int[] samplesDt = GVSampleInfo.GetSelectedRows();
                string remsg = "";
                bool checkState = true;//判断是否用check字段进行审核

                for (int a = GVSampleInfo.RowCount - 1; a >= 0; a--)
                //for (int a = 0; a < GVSampleInfo.RowCount - 1; a++)
                {
                    if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                        {
                            CheckInfoModel checkInfoModel = new CheckInfoModel();
                            checkInfoModel.UserName = CommonData.UserInfo.names;
                            List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();
                            checkState = false;
                            if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                            {
                                if (GVSampleInfo.GetDataRow(a)["perStateNO"] == DBNull.Value)
                                {
                                    remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
                                }
                                else
                                {

                                    if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() != "1")
                                    {
                                        remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能审核。\r\n";
                                    }
                                    else
                                    {
                                        CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                                        sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                                        //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                                        sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                                        sampleList.Add(sampleInfo);

                                        if (sampleList.Count > 0)
                                        {
                                            checkInfoModel.checkSampleInfos = sampleList;
                                            string Sr = JsonHelper.SerializeObjct(checkInfoModel);
                                            WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheck, Sr);
                                            commReInfo<ReCheckeModel> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<ReCheckeModel>>(jm);
                                            //ReCheckeModel ReCheckeModel = JsonHelper.JsonConvertObject<ReCheckeModel>(jm);

                                            if (ReCheckeModel != null)
                                            {

                                                foreach (ReCheckeModel Info in ReCheckeModel.infos)
                                                {
                                                    if (Info.code == 0)
                                                    {
                                                        for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
                                                        {
                                                            string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();

                                                            if(Info.barcode== barcode)
                                                            {
                                                                GVSampleInfo.SetRowCellValue(r, "perStateNO", 2);
                                                                GVSampleInfo.SetRowCellValue(r, "checker", CommonData.UserInfo.names);
                                                                GVSampleInfo.SetRowCellValue(r, "checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                                if (CEPrintState.Checked)
                                                                {
                                                                    try
                                                                    {
                                                                        foreach (CheckGroupBarcode groupBarcode in Info.groupcodeInfo)
                                                                        {
                                                                            if (groupBarcode.barcode == barcode)
                                                                            {
                                                                                printBarcode(groupBarcode);
                                                                            }
                                                                        }
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        remsg += barcode + ":" + ex.Message + "\r\n";
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        remsg = sampleInfo.barcode + ":" + Info.msg + "\r\n";
                                                    }
                                                }

                                            }
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
                if (remsg != "")
                    MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);







                #region 批量提交信息(问题接口响应时间过长)

                //BTChecks.Enabled = false;
                //int[] samplesDt = GVSampleInfo.GetSelectedRows();
                //string remsg = "";
                //bool checkState = true;//判断是否用check字段进行审核


                //CheckInfoModel checkInfoModel = new CheckInfoModel();
                //checkInfoModel.UserName = CommonData.UserInfo.names;
                //List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();


                //for (int a = GVSampleInfo.RowCount - 1; a>=0; a--)
                //{
                //    if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                //    {
                //        if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                //        {
                //            checkState = false;
                //            if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                //            {
                //                if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
                //                {
                //                    if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "1")
                //                    {


                //                            CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                //                            sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                //                            //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                //                            sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                //                            sampleList.Add(sampleInfo);

                //                    }
                //                    else
                //                    {
                //                        remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能审核。\r\n";
                //                    }
                //                }
                //                else
                //                {
                //                    remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
                //                }
                //            }
                //        }
                //    }
                //}
                ////if (checkState)
                ////{
                ////    foreach (int a in samplesDt)
                ////    {
                ////        if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                ////        {
                ////            if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
                ////            {
                ////                if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "1")
                ////                {

                ////                        CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                ////                        sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                ////                        //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                ////                        sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                ////                        sampleList.Add(sampleInfo);
                ////                }
                ////                else
                ////                {
                ////                    remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能审核。\r\n";
                ////                }
                ////            }
                ////            else
                ////            {
                ////                remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
                ////            }
                ////        }
                ////    }
                ////}
                //if (sampleList.Count > 0)
                //{
                //    checkInfoModel.checkSampleInfos = sampleList;
                //    string Sr = JsonHelper.SerializeObjct(checkInfoModel);
                //    WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheck, Sr);
                //    commReInfo<ReCheckeModel> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<ReCheckeModel>>(jm);
                //    //ReCheckeModel ReCheckeModel = JsonHelper.JsonConvertObject<ReCheckeModel>(jm);

                //    if (ReCheckeModel != null)
                //    {

                //        foreach (ReCheckeModel sampleInfo in ReCheckeModel.infos)
                //        {
                //            if (sampleInfo.code == 0)
                //            {
                //                for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
                //                {
                //                    string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();
                //                    if (sampleInfo.barcode == barcode)
                //                    {
                //                        GVSampleInfo.SetRowCellValue(r, "perStateNO", 2);
                //                        GVSampleInfo.SetRowCellValue(r, "checker", CommonData.UserInfo.names);
                //                        GVSampleInfo.SetRowCellValue(r, "checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //                        if (CEPrintState.Checked)
                //                        {
                //                            try
                //                            {
                //                                foreach (CheckGroupBarcode groupBarcode in sampleInfo.groupcodeInfo)
                //                                {
                //                                    printBarcode(groupBarcode);
                //                                }
                //                            }
                //                            catch (Exception ex)
                //                            {
                //                                remsg += barcode+":" + ex.Message+"\r\n";
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                remsg = sampleInfo.barcode + ":" + sampleInfo.msg + "\r\n";
                //            }
                //        }
                //        if (remsg != "")
                //            MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                BTChecks.Enabled = true;
                MessageBox.Show(ex.Message, "系统提示");
            }
            frmWait.HideMe(this);
            BTChecks.Enabled = true;
        }




        int perSampleState = 1;//1.刚录入信息，其他状态不允许修改
        string selectValueID = "";
        DataRow SampleInfoRow;
        string InfoBarcode = "";

        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow rows= SampleInfoRow = GVSampleInfo.GetFocusedDataRow();
            if (rows != null)
            {

                selectValueID = rows["id"].ToString(); ;
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkPer.SampleInfo";
                selectInfo.wheres = $"id='{selectValueID}' and dstate=0";
                DataTable dataTable = ApiHelpers.postInfo(selectInfo);
                if (dataTable != null)
                {
                    DEreceiveTime.EditValue = dataTable.Rows[0]["receiveTime"];
                    DEsampleTime.EditValue = dataTable.Rows[0]["sampleTime"];
                    TEageDay.EditValue = dataTable.Rows[0]["ageDay"];
                    TEageMoth.EditValue = dataTable.Rows[0]["ageMoth"];
                    TEageYear.EditValue = dataTable.Rows[0]["ageYear"];
                    TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    //TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    GEagentNo.EditValue = dataTable.Rows[0]["agentNo"];
                    TEhospitalBarcode.EditValue = dataTable.Rows[0]["hospitalBarcode"];
                    //TEapplyItemCodes.EditValue = dataTable.Rows[0]["applyItemCodes"];
                    //TEapplyItemNames.EditValue = dataTable.Rows[0]["applyItemNames"];
                    TEbarcode.EditValue = dataTable.Rows[0]["barcode"];
                    InfoBarcode = dataTable.Rows[0]["barcode"] != DBNull.Value ? dataTable.Rows[0]["barcode"].ToString() : "";
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
                    CEurgent.Checked = dataTable.Rows[0]["urgent"]!=DBNull.Value? Convert.ToBoolean(dataTable.Rows[0]["urgent"]):false;


                    if (WorkCommData.DTItemApply != null)
                    {
                        GCItemInfo.DataSource = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
                    }
                    if (CEShowImg.Checked)
                    {
                        BTImg_Click(null, null);
                    }
                }

            }
            else
            {
                clearInfo();
            }
        }



        private void GVSampleInfo_DoubleClick(object sender, EventArgs e)
        {
            //int[] samplesDt = GVSampleInfo.GetSelectedRows();
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("perid");
            data.Columns.Add("barcode");
            data.Columns.Add("patientName");
            bool sampleState = true;//判断样本信息是否已经审核
            //int editState = 1;
            DataRow selectDR = GVSampleInfo.GetFocusedDataRow();

            if (selectDR != null)
            {
                string perperStateNO = selectDR["perStateNO"] != DBNull.Value ? selectDR["perStateNO"].ToString() : "1";
                if (perperStateNO == "1")
                {
                    data.Rows.Add(selectDR["id"], selectDR["id"], selectDR["barcode"], selectDR["patientName"]);
                }
                else
                {
                    sampleState = false;
                    data.Rows.Add(selectDR["id"], selectDR["id"], selectDR["barcode"], selectDR["patientName"]);
                }
            }

            if (data.Rows.Count > 0)
            {
                if (sampleState)
                {

                    FrmSampleInfoCheckEdit frmSampleInfoEdit = new FrmSampleInfoCheckEdit(data, 1, 0);
                    frmSampleInfoEdit.ShowDialog();
                }
                else
                {
                    FrmSampleInfoEdit frmSampleInfoEdit = new FrmSampleInfoEdit(data, 0);
                    frmSampleInfoEdit.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("请选择需要编辑的样本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    //e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;//改变背景色
                    e.Appearance.ForeColor = System.Drawing.Color.Red;
                    //e.Appearance.BackColor = Color.Transparent;//改变背景色
                    //e.Appearance.ForeColor = Color.Red;//改变字体颜色
                }
            }
        }



        /// <summary>
        /// 单条码获取信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RTEbarcodes_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)//这是允许输入退格键
            {
                TextEdit textEdit = sender as TextEdit;
                if (textEdit.EditValue != null)
                {
                    if (textEdit.EditValue.ToString() != "")
                    {
                        CheckSelectModel checkModel = new CheckSelectModel();
                        barcodestring = TEbarcodes.EditValue != null ? TEbarcodes.EditValue.ToString().Replace('，', ',') : "";//记录查询
                        List<string> vs = new List<string>();
                        if (barcodestring != "")
                        {
                            
                            string[] codes = barcodestring.Split(',');
                            foreach (string code in codes)
                            {
                                vs.Add(code.ToUpper());
                            }
                            checkModel.barcode = vs;
                        }

                        //checkModel.barcode = TEbarcodes.EditValue != null && TEbarcodes.EditValue.ToString().Trim().Length > 0 ? TEbarcodes.EditValue.ToString() : null;
                        checkModel.TableName = EntryTableName;
                        checkModel.UserName = CommonData.UserInfo.names;
        
                        checkModel.sampleState = GESampleState.EditValue.ToString();
                        if (GECreater.Text != "全部")
                        {
                            checkModel.entryUserName = GECreater.Text;
                        }
                        else
                        {
                            checkModel.entryUserName = "";
                        }
                        if(vs.Count>0)
                        {
                            //checkModel.entryUserName = RGECreater.ToString();
                            string Sr = JsonHelper.SerializeObjct(checkModel);
                            WebApiCallBack jm = ApiHelpers.postInfo(GetCheckInfo, Sr);
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
                            CECheck.Checked = false;
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
                TEbarcodes.SelectAll();
                //TEbarcodes.DoubleClick += TEbarcodes_DoubleClick;
                //TEbarcodes.Focus();
            }

        }

        /// <summary>
        /// 单医院条码获取信息
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
        
                        checkModel.sampleState = GESampleState.EditValue.ToString();
                        if (GECreater.Text != "全部")
                        {
                            checkModel.entryUserName = GECreater.Text;
                        }
                        else
                        {
                            checkModel.entryUserName = "";
                        }
                        //checkModel.entryUserName = RGECreater.ToString();
                        string Sr = JsonHelper.SerializeObjct(checkModel);
                        WebApiCallBack jm = ApiHelpers.postInfo(GetCheckInfo, Sr);
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
                        CECheck.Checked = false;
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
        /// 录入信息反审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTRecheck_Click(object sender, EventArgs e)
        {

            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示","正在处理，请稍等。。");

            BTRecheck.Enabled = false;
            try
            {
                int[] samplesDt = GVSampleInfo.GetSelectedRows();
                string remsg = "";
                bool checkState = true;//判断是否用check字段进行审核





                for (int a = GVSampleInfo.RowCount - 1; a >= 0; a--)
                {

                    CheckInfoModel checkInfoModel = new CheckInfoModel();
                    checkInfoModel.UserName = CommonData.UserInfo.names;
                    List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();

                    if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                        {
                            checkState = false;
                            if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                            {
                                if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
                                {
                                    if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "2")
                                    {


                                        CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                                        sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                                        //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                                        sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                                        sampleList.Add(sampleInfo);
                                        if (sampleList.Count > 0)
                                        {
                                            checkInfoModel.checkSampleInfos = sampleList;
                                            string Sr = JsonHelper.SerializeObjct(checkInfoModel);
                                            WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheckRe, Sr);
                                            commReInfo<commReSampleInfo> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                                            if (ReCheckeModel != null)
                                            {
                                                foreach (commReSampleInfo reSampleInfo in ReCheckeModel.infos)
                                                {
                                                    if (reSampleInfo.code == 0)
                                                    {
                                                        for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
                                                        {
                                                            string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();
                                                            if (reSampleInfo.barcode == barcode)
                                                            {
                                                                GVSampleInfo.SetRowCellValue(r, "perStateNO", 1);
                                                                GVSampleInfo.SetRowCellValue(r, "checker", "");
                                                                GVSampleInfo.SetRowCellValue(r, "checkTime", null);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        remsg = reSampleInfo.barcode + ":" + reSampleInfo.msg + "\r\n";
                                                    }
                                                }

                                            }
                                        }

                                    }
                                    else
                                    {
                                        remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能反审核。\r\n";
                                    }
                                }
                                else
                                {
                                    remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
                                }
                            }
                        }
                    }
                }
                #region
                //if (checkState)
                //{
                //    foreach (int a in samplesDt)
                //    {
                //        if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                //        {
                //            if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
                //            {
                //                if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "2")
                //                {
                //                    Task<string> task = new Task<string>(() =>
                //                    {


                //                        CheckInfoModel checkInfoModel = new CheckInfoModel();
                //                        checkInfoModel.UserName = CommonData.UserInfo.names;
                //                        
                //                        List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();
                //                        CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                //                        sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                //                        sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                //                        sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                //                        sampleList.Add(sampleInfo);
                //                        checkInfoModel.checkSampleInfos = sampleList;
                //                        string Sr = JsonHelper.SerializeObjct(checkInfoModel);
                //                        return ApiHelpers.postInfo(SampleInfoCheckRe, Sr);
                //                    });
                //                    task.Start();
                //                    task.Wait();
                //                    string s = task.Result;

                //                    commReInfo<commReSampleInfo> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                //                    if (ReCheckeModel.code == 1)
                //                    {
                //                        GVSampleInfo.SetRowCellValue(a, "perStateNO", 1);
                //                        GVSampleInfo.SetRowCellValue(a, "checker", "");
                //                        GVSampleInfo.SetRowCellValue(a, "checkTime", null);
                //                    }
                //                    else
                //                    {
                //                        resultInfo += ReCheckeModel.msg;
                //                    }
                //                }
                //                else
                //                {
                //                    resultInfo += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能反审核。\r\n";
                //                }
                //            }
                //            else
                //            {
                //                resultInfo += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
                //            }
                //        }
                //    }
                //}
                #endregion

                if (remsg != "")
                    MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            frmWait.HideMe(this);
            BTRecheck.Enabled = true;

            #region 批量提交信息


            //FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "正在反审核请稍等......");
            //BTRecheck.Enabled = false;
            //try
            //{
            //    int[] samplesDt = GVSampleInfo.GetSelectedRows();
            //    string remsg = "";
            //    bool checkState = true;//判断是否用check字段进行审核

            //    CheckInfoModel checkInfoModel = new CheckInfoModel();
            //    checkInfoModel.UserName = CommonData.UserInfo.names;
            //    List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();



            //    for (int a = GVSampleInfo.RowCount - 1; a>=0; a--)
            //    {
            //        if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
            //        {
            //            if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
            //            {
            //                checkState = false;
            //                if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
            //                {
            //                    if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
            //                    {
            //                        if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "2")
            //                        {


            //                                CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
            //                                sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
            //                                //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
            //                                sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
            //                                sampleList.Add(sampleInfo);

            //                        }
            //                        else
            //                        {
            //                            remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能反审核。\r\n";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    #region
            //    //if (checkState)
            //    //{
            //    //    foreach (int a in samplesDt)
            //    //    {
            //    //        if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
            //    //        {
            //    //            if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
            //    //            {
            //    //                if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "2")
            //    //                {
            //    //                    Task<string> task = new Task<string>(() =>
            //    //                    {


            //    //                        CheckInfoModel checkInfoModel = new CheckInfoModel();
            //    //                        checkInfoModel.UserName = CommonData.UserInfo.names;
            //    //                        
            //    //                        List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();
            //    //                        CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
            //    //                        sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
            //    //                        sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
            //    //                        sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
            //    //                        sampleList.Add(sampleInfo);
            //    //                        checkInfoModel.checkSampleInfos = sampleList;
            //    //                        string Sr = JsonHelper.SerializeObjct(checkInfoModel);
            //    //                        return ApiHelpers.postInfo(SampleInfoCheckRe, Sr);
            //    //                    });
            //    //                    task.Start();
            //    //                    task.Wait();
            //    //                    string s = task.Result;

            //    //                    commReInfo<commReSampleInfo> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
            //    //                    if (ReCheckeModel.code == 1)
            //    //                    {
            //    //                        GVSampleInfo.SetRowCellValue(a, "perStateNO", 1);
            //    //                        GVSampleInfo.SetRowCellValue(a, "checker", "");
            //    //                        GVSampleInfo.SetRowCellValue(a, "checkTime", null);
            //    //                    }
            //    //                    else
            //    //                    {
            //    //                        resultInfo += ReCheckeModel.msg;
            //    //                    }
            //    //                }
            //    //                else
            //    //                {
            //    //                    resultInfo += GVSampleInfo.GetDataRow(a)["barcode"] + "样本信息不能反审核。\r\n";
            //    //                }
            //    //            }
            //    //            else
            //    //            {
            //    //                resultInfo += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
            //    //            }
            //    //        }
            //    //    }
            //    //}
            //    #endregion
            //    if (sampleList.Count > 0)
            //    {
            //        checkInfoModel.checkSampleInfos = sampleList;
            //        string Sr = JsonHelper.SerializeObjct(checkInfoModel);
            //        WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheckRe, Sr);
            //        commReInfo<commReSampleInfo> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
            //        if (ReCheckeModel != null)
            //        {
            //            foreach (commReSampleInfo sampleInfo in ReCheckeModel.infos)
            //            {
            //                if (sampleInfo.code == 0)
            //                {
            //                    for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
            //                    {
            //                        string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();
            //                        if (sampleInfo.barcode == barcode)
            //                        {
            //                            GVSampleInfo.SetRowCellValue(r, "perStateNO", 1);
            //                            GVSampleInfo.SetRowCellValue(r, "checker", "");
            //                            GVSampleInfo.SetRowCellValue(r, "checkTime", null);
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    remsg = sampleInfo.barcode + ":" + sampleInfo.msg + "\r\n";
            //                }
            //            }
            //            if (remsg != "")
            //                MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //frmWait.HideMe(this);
            //BTRecheck.Enabled = true;
            #endregion
        }
        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTPrints_Click(object sender, EventArgs e)
        {
            //try
            //{
            int[] samplesDt = GVSampleInfo.GetSelectedRows();
            string remsg = "";
            bool checkState = true;//判断是否用check字段进行审核

            CheckInfoModel checkInfoModel = new CheckInfoModel();
            checkInfoModel.UserName = CommonData.UserInfo.names;

            List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();



            for (int a = 0; a < GVSampleInfo.RowCount; a++)
            {

                if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value && Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                {


                    checkState = false;
                    if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                    {

                        if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value && GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "2")
                        {

                            CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                            sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                            //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
                            sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                            sampleList.Add(sampleInfo);

                        }
                        else
                        {
                            remsg += GVSampleInfo.GetDataRow(a)["barcode"].ToString() + ":" + "请先审核样本\r\n";
                        }

                    }


                }

            }
            //if (checkState)
            //{
            //    foreach (int a in samplesDt)
            //    {
            //        if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
            //        {
            //            if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value && GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "2")
            //            {

            //                CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
            //                sampleInfo.perid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
            //                //sampleInfo.testid = !Convert.IsDBNull(GVSampleInfo.GetDataRow(a)["id"]) ? Convert.ToInt32(GVSampleInfo.GetDataRow(a)["id"]) : 0;
            //                sampleInfo.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
            //                sampleList.Add(sampleInfo);

            //            }
            //            else
            //            {
            //                remsg += GVSampleInfo.GetDataRow(a)["barcode"].ToString() + ":" + "请先审核样本\r\n";
            //            }
            //        }
            //    }
            //}

            if (sampleList.Count > 0)
            {
                checkInfoModel.checkSampleInfos = sampleList;
                string Sr = JsonHelper.SerializeObjct(checkInfoModel);
                WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoCheckBc, Sr);
                commReInfo<ReCheckeModel> ReCheckeModel = JsonHelper.JsonConvertObject<commReInfo<ReCheckeModel>>(jm);

                if (ReCheckeModel != null)
                {

                    foreach (ReCheckeModel sampleInfo in ReCheckeModel.infos)
                    {
                        if (sampleInfo.code == 0)
                        {
                            for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
                            {
                                string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();
                                try
                                {
                                    foreach (CheckGroupBarcode groupBarcode in sampleInfo.groupcodeInfo)
                                    {
                                        if (groupBarcode.barcode == barcode)
                                        {
                                            printBarcode(groupBarcode);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    remsg += barcode + ":" + ex.Message + "\r\n";
                                }


                            }
                        }
                        else
                        {
                            remsg = sampleInfo.barcode + ":" + sampleInfo.msg + "\r\n";
                        }
                    }

                }
            }
            if (remsg != "")
                MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 删除录入样本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTDeletes_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {



                bool checkState = true;

                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "正在删除信息请稍等......");
                BTDeletes.Enabled = false;
                DeleteInfoModel deleteInfos = new DeleteInfoModel();
                deleteInfos.UserName = CommonData.UserInfo.names;
                deleteInfos.state = 2;

                List<InfoListModel> infoLists = new List<InfoListModel>();
                try
                {
                    int[] samplesDt = GVSampleInfo.GetSelectedRows();
                    string remsg = "";
                    //bool checkState = true;//判断是否用check字段进行审核
                    for (int a = GVSampleInfo.RowCount-1; a>=0; a--)
                    {
                        if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                        {
                            if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                            {
                                checkState = false;
                                if (GVSampleInfo.GetDataRow(a)["barcode"] != DBNull.Value)
                                {
                                    if (GVSampleInfo.GetDataRow(a)["perStateNO"] != DBNull.Value)
                                    {
                                        if (GVSampleInfo.GetDataRow(a)["perStateNO"].ToString() == "1")
                                        {

                                                InfoListModel info = new InfoListModel();
                                                if (GVSampleInfo.GetDataRow(a)["id"] != DBNull.Value)
                                                {
                                                    info.SampleID = GVSampleInfo.GetDataRow(a)["id"].ToString();
                                                }
                                                info.barcode = GVSampleInfo.GetDataRow(a)["barcode"].ToString();
                                                infoLists.Add(info);
                                        }
                                        else
                                        {
                                            remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本已审核不能删除。\r\n";
                                        }
                                    }
                                    else
                                    {
                                        remsg += GVSampleInfo.GetDataRow(a)["barcode"] + "样本状态错误。\r\n";
                                    }
                                }
                            }
                        }
                    }
                    if (infoLists.Count > 0)
                    {

                        deleteInfos.sampleinfos = infoLists;
                        string Sr = JsonHelper.SerializeObjct(deleteInfos);
                        WebApiCallBack jm = ApiHelpers.postInfo(SampleInfoDelete, Sr);
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
                                            GVSampleInfo.DeleteRow(r);
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

                    if(remsg!="")
                        MessageBox.Show(remsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                BTDeletes.Enabled = true;
                frmWait.HideMe(this);
            }
        }


        #region hotKeys 快捷键


        private void FrmPerworkInfoCheck_Enter(object sender, EventArgs e)
        {
            ////注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            /////////////HotKeys.RegisterHotKey(Handle, 100, HotKeys.KeyModifiers.Shift, Keys.S);
            HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F1);

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
                            BTChecks_Click(null, null);
                            break;
                            //case 103:  //按下的是Ctrl+q
                            //    BTNextPage_ItemClick(null, null);          //此处填写快捷键响应代码
                            //    break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void FrmPerworkInfoCheck_Leave(object sender, EventArgs e)
        {

            HotKeys.UnregisterHotKey(Handle, 100);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
        }

        #endregion hotKeys

        private void BTImg_Click(object sender, EventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkPer.SampleImg";
                selectInfo.values = "top 1 filestring";
                selectInfo.wheres = $"barcode='{dataRow["barcode"]}' and filestring!=''";
                selectInfo.OrderColumns = "createTime desc";
                DataTable data = ApiHelpers.postInfo(selectInfo);
                if (data != null && data.Rows.Count > 0)
                {
                    ShowImgHelper.ViewOrignalImage(FileConverHelpers.StringToBitmap(data.Rows[0][0].ToString()));
                }
                else
                {
                    if (!CEShowImg.Checked)
                        MessageBox.Show("未找到该信息原始单信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void 查看项目清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CVItemInfo.GetFocusedDataRow() != null)
            {
                string applyNO = CVItemInfo.GetFocusedDataRow()["no"].ToString();
                FrmItemInfo frmItemInfo = new FrmItemInfo(applyNO);
                frmItemInfo.ShowDialog();
            }
        }

        private void BTSelectHJ_Click(object sender, EventArgs e)
        {
            if(SampleInfoRow!=null)
            {
                string sampleApplyCode = SampleInfoRow["applyItemCodes"] != DBNull.Value ? SampleInfoRow["applyItemCodes"].ToString() : "";
                string sampleBarcode = SampleInfoRow["barcode"] != DBNull.Value ? SampleInfoRow["barcode"].ToString() : "";


                if (sampleApplyCode != "" && sampleBarcode != "")
                {
                    if (sampleApplyCode == "17" || sampleApplyCode == "19")
                    {
                        if (sampleApplyCode == "17")
                        {
                            if (Convert.ToInt32(SampleInfoRow["perStateNO"]) != 4)
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
                            if (Convert.ToInt32(SampleInfoRow["perStateNO"]) != 4)
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

        }




        string barcodestring = "";
        /// <summary>
        /// 批量输入条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TEbarcodes_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormBarcodeInfo formBarcodeInfo = new FormBarcodeInfo(barcodestring);
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            TEbarcodes.EditValue = func();
        }


        #region 自动审核功能

        bool autoState = false;
        System.DateTime TimeNow = new DateTime();
        TimeSpan TimeCount = new TimeSpan();
        private void BTAutoCheck_Click(object sender, EventArgs e)
        {
            foreach(Control control in layoutManager.Controls)
            {
                if (control.Name != "BTAutoClear")
                    control.Enabled = false;
            }

            BTAutoCheck.Text = "正在自动审核";

            BTAutoCheck.Enabled = false;

            autoState = true;


            CheckTimer.Stop();



            while (autoState)
            {
                BTSelects_Click(null, null);
                CECheck.Checked = true;
                BTChecks_Click(null, null);




                CheckTimer.Start();
                CheckTimer.Interval = 5000;
                TimeNow = DateTime.Now.AddMinutes(1);
                autoState = false;
            }
        }

        private void BTAutoClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in layoutManager.Controls)
            {
                    control.Enabled = true;
            }
            BTAutoCheck.Text = "自动审核";
            autoState = false;
            CheckTimer.Stop();
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            if(TimeNow<DateTime.Now)
            {

                BTAutoCheck_Click(null,null);

            }
        }
        #endregion


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
            GCItemInfo.DataSource = null;
        }


        //private BarTender.Application btApp;            //Bartender 应用实例
        //private BarTender.Format btFormat;              //Bartender 样式

        /// <summary>
        /// 打印二级条码方法
        /// </summary>
        /// <param name="groupBarcode"></param>
        private void printBarcode(CheckGroupBarcode groupBarcode)
        {
            try
            {


                BarTender.Application btApp = new BarTender.Application();
                BarTender.Format btFormat = new BarTender.Format();
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleCheck.btw";
                if (File.Exists(filepath))
                {
                    btFormat = btApp.Formats.Open(AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleCheck.btw", false, "");
                    //选择打印机
                    btFormat.Printer = CBPrintInfo.EditValue.ToString();

                    //设置打印份数
                    int CopiesOfLabel = 1;
                    btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;
                    if (groupBarcode.barcode != null)
                        btFormat.SetNamedSubStringValue("barcode", groupBarcode.barcode);
                    if (groupBarcode.hospitalNames != null)
                        btFormat.SetNamedSubStringValue("hospitalNames", groupBarcode.hospitalNames);
                    if (groupBarcode.patientName != null)
                        btFormat.SetNamedSubStringValue("patientName", groupBarcode.patientName);
                    if (groupBarcode.patientSexNames != null)
                        btFormat.SetNamedSubStringValue("patientSexNames", groupBarcode.patientSexNames);
                    if (groupBarcode.ageYear != null)
                        btFormat.SetNamedSubStringValue("ageYear", groupBarcode.ageYear);
                    //if (groupBarcode.sampleID != null)
                    //    btFormat.SetNamedSubStringValue("sampleID", groupBarcode.sampleID.ToString());
                    if (groupBarcode.groupNO != null)
                    {
                        //btFormat.SetNamedSubStringValue("groupNO", groupBarcode.groupNO);
                        DataRow[] rows = WorkCommData.DTGroupTest.Select($"no='{groupBarcode.groupNO}'");
                        if (rows.Length > 0)
                        {
                            if (rows[0]["names"] != DBNull.Value)
                            {
                                btFormat.SetNamedSubStringValue("groupName", rows[0]["names"].ToString());
                            }
                        }
                    }
                    if (groupBarcode.groupName != null)
                        btFormat.SetNamedSubStringValue("groupName", groupBarcode.groupName);
                    //if (groupBarcode.groupCodes != null)
                    //    btFormat.SetNamedSubStringValue("groupCodes", groupBarcode.groupCodes);
                    if (groupBarcode.groupNames != null)
                        btFormat.SetNamedSubStringValue("groupNames", groupBarcode.groupNames);

                    //设置打印时是否跳出打印属性
                    btFormat.PrintOut(false, false);

                    //设置打印份数
                    //int CopiesOfLabel = shareNumbers;
                    //btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;
                    ////序列化打印时使用的
                    //btFormat.NumberSerializedLabels = Numbers;
                    ////向bartender模板传递变量,SN为条形码数据的一个共享名称
                    //string aaa = TEClientCode.EditValue.ToString() + SerialNo.ToString("0000000");
                    //btFormat.SetNamedSubStringValue("SN", TEClientCode.EditValue.ToString() + SerialNo.ToString("0000000"));
                    //btFormat.SetNamedSubStringValue("SC", TEclientNames.EditValue.ToString());
                    ////设置打印时是否跳出打印属性
                    //btFormat.PrintOut(false, false);

                    //btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
                    //btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);



                    //btFormat.Close();
                    //btApp.Quit();
                    btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
                    btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);

                }
                else
                {
                    MessageBox.Show($"未找到{filepath}文件模板", "系统提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        /// <summary>
        /// 获取打印机信息
        /// </summary>
        public void getPrintInfo()
        {
            try
            {
                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    CBPrintInfo.Properties.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CBPrintInfo.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CBPrintInfo.EditValue = null;
            }
        }

        private void BTSampleRecord_Click(object sender, EventArgs e)
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


    }
}
