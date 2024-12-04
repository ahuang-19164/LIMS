using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.SqlModel;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using jk.UpResultInfoModel;
using Ms.jikongHandle;
using Ms.jikongModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace MS.UpResultHandle
{
    public partial class FrmXGHCResult : XtraForm
    {
        string GetAllReportInfo = "";
        public FrmXGHCResult()
        {
            InitializeComponent();
            xianjikong.GetToken();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

            SysPowerHelper.UserPower(layoutControl1);
            GetAllReportInfo = ConfigInfos.ReadConfigInfo("GetAllReportInfo");
            //CommonHandle.showFindPanel(GVSampleInfo);
            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("no", typeof(int));
            dataTable.Columns.Add("names", typeof(string));
            dataTable.Rows.Add(1, "未上传");
            dataTable.Rows.Add(2, "已上传");
            dataTable.Rows.Add(3, "上传待查");
            dataTable.Rows.Add(0, "全部");

            GridLookUpEdites.Formats(GEState);
            GridLookUpEdites.Formats(GExgState, dataTable);
            GridLookUpEdites.Formats(GEtestStateNO, WorkCommData.DTStateTest);
            GExgState.EditValue = "0";
            GEState.DataSource = dataTable;
            GEState.ValueMember = "no";
            GEState.DisplayMember = "names";

            //GEState.EditValue = 1;

            //GetReport = ConfigInfos.ReadConfigInfo("GetReport");
            DEStartTime.EditValue = DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd"); getPrintInfo();
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
                    CBPrint.Properties.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CBPrint.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CBPrint.EditValue = null;
            }

        }

        private void BTselect_Click(object sender, EventArgs e)
        {
            /////查询所有报告信息
            ///
            BTselect.Enabled = false;

            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "查询信息请稍后......");



            UpResultModel upResult = new UpResultModel();
            upResult.UserName = CommonData.UserInfo.names;
            
            GetInfo getInfo = new GetInfo();
            getInfo.barcode = TEBarcode.EditValue != null ? TEBarcode.EditValue.ToString() : "";
            getInfo.hosbarcode = TEHosBarcode.EditValue != null ? TEHosBarcode.EditValue.ToString() : "";
            getInfo.hosbarcode = TEHosBarcode.EditValue != null ? TEHosBarcode.EditValue.ToString() : "";
            getInfo.xgState = GExgState.EditValue != null ? GExgState.EditValue.ToString() : "";
            getInfo.patientName = TEPatientNamre.EditValue != null ? TEPatientNamre.EditValue.ToString() : "";
            getInfo.receiveStartTime = DEStartTime.EditValue != null ? DEStartTime.EditValue.ToString() : "";
            getInfo.receiveEndTime = DEEndTime.EditValue != null ? DEEndTime.EditValue.ToString() : "";
            upResult.GetValueInfo = getInfo;
            string Sr = JsonHelper.SerializeObjct(upResult);
            WebApiCallBack jm = ApiHelpers.postInfo(GetAllReportInfo, Sr);
            DataTable dataTable = JsonHelper.StringToDT(jm);
            if (dataTable != null)
            {
                dataTable.Columns.Add("check", typeof(bool));
            }
            GCSampleInfo.DataSource = dataTable;
            GVSampleInfo.BestFitColumns();

            BTselect.Enabled = true;
            frmWait.HideMe(this);


        }

        private void CECheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CECheckAll.Checked)
            {
                for (int i = 0; i < GVSampleInfo.RowCount; i++)
                {
                    GVSampleInfo.SetRowCellValue(i, "check", true);
                }
            }
            else
            {
                for (int i = 0; i < GVSampleInfo.RowCount; i++)
                {
                    GVSampleInfo.SetRowCellValue(i, "check", false);
                }
            }
        }


        bool downReporState = false;


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //string sampleCode = "";

            ////string nowSampleCode = "";
            //for (int a = DTSampleInfo.Rows.Count-1; a >=0; a--)
            //{

            //    List<batchInsertNucResult> batchInsertNucResults = new List<batchInsertNucResult>();
            //    DataRow DRSampleInfo =DTSampleInfo.Rows[a];
            //    string upinfostring = "";
            //    bool sampleState = DRSampleInfo["check"] != DBNull.Value ? Convert.ToBoolean(DRSampleInfo["check"]) : false;
            //    if (sampleState)
            //    {

            //        batchInsertNucResult batchSampleInfo = new batchInsertNucResult();
            //        string barcode = DRSampleInfo["barcode"] != DBNull.Value ? DRSampleInfo["barcode"].ToString().Trim() : "";
            //        batchSampleInfo.userName = DRSampleInfo["patientName"] != DBNull.Value ? DRSampleInfo["patientName"].ToString().Trim() : "";
            //        batchSampleInfo.sex = DRSampleInfo["patientSexNames"] != DBNull.Value ? DRSampleInfo["patientSexNames"].ToString().Trim() : "";
            //        //batchSampleInfo.cardType = DRSampleInfo["patientName"] != DBNull.Value ? DRSampleInfo["patientName"].ToString().Trim() : "";
            //        batchSampleInfo.cardNum = DRSampleInfo["patientCardNo"] != DBNull.Value ? DRSampleInfo["patientCardNo"].ToString().Trim() : "";
            //        if (batchSampleInfo.cardNum.Length == 18 || batchSampleInfo.cardNum.Length == 15)
            //        {
            //            batchSampleInfo.cardType = "1";
            //        }
            //        else
            //        {
            //            batchSampleInfo.cardType = "2";
            //        }
            //        if (batchSampleInfo.cardType == "2")
            //        {
            //            string passportNo = DRSampleInfo["passportNo"] != DBNull.Value ? DRSampleInfo["passportNo"].ToString().Trim() : "";
            //            if (passportNo != "")
            //            {
            //                batchSampleInfo.cardNum = passportNo;
            //                batchSampleInfo.cardType = "2";
            //            }

            //        }

            //        batchSampleInfo.phone = DRSampleInfo["patientPhone"] != DBNull.Value ? DRSampleInfo["patientPhone"].ToString().Trim() : "";
            //        batchSampleInfo.fromOrg = DRSampleInfo["hospitalNames"] != DBNull.Value ? DRSampleInfo["hospitalNames"].ToString().Trim() : "";
            //        batchSampleInfo.collectTime = DRSampleInfo["sampleTime"] != DBNull.Value ? DRSampleInfo["sampleTime"].ToString().Trim() : "";
            //        //batchSampleInfo.collectPart = DRSampleInfo["sampleTypeNames"] != DBNull.Value ? DRSampleInfo["sampleTypeNames"].ToString().Trim() : "";
            //        batchSampleInfo.collectPart = DRSampleInfo["sampleTypeNames"] != DBNull.Value ? DRSampleInfo["sampleTypeNames"].ToString().Trim() : "";
            //        batchSampleInfo.detOrg = "西安迈尚医学检验实验室";
            //        batchSampleInfo.recieveTime = DRSampleInfo["receiveTime"] != DBNull.Value ? DRSampleInfo["receiveTime"].ToString().Trim() : "";



            //        string geneA = DRSampleInfo["geneA"] != DBNull.Value ? DRSampleInfo["geneA"].ToString().Trim() : "";
            //        string geneB = DRSampleInfo["geneB"] != DBNull.Value ? DRSampleInfo["geneB"].ToString().Trim() : "";


            //        insertResultByCode insertResultByCode = new insertResultByCode();
            //        insertResultByCode.code = barcode;
            //        if (geneA != "" && geneB != "")
            //        {
            //            if (geneA.Contains("阳") || geneB.Contains("阳"))
            //            {


            //                upinfostring = barcode+ $"检验结果为阳性，结果无法上传！";


            //            }
            //            else
            //            {

            //                batchSampleInfo.detResult = "阴性";
            //                batchSampleInfo.detTime = DRSampleInfo["checkTime"] != DBNull.Value ? DRSampleInfo["checkTime"].ToString() : "";
            //                batchInsertNucResults.Add(batchSampleInfo);
            //                string sr = JsonHelper.SerializeObjct(batchInsertNucResults);
            //                string reMsg = xianjkApi.batchInsertNucResult(sr);
            //                try
            //                {
            //                    jkresult x = JsonConvert.DeserializeObject<jkresult>(reMsg);
            //                    if (x.code != "200" || !x.msg.Contains("信息录入成功"))
            //                    {
            //                        upinfostring = barcode+ $"上传数据错误！\r\n{x.msg}";
            //                    }
            //                    else
            //                    {
            //                        if (x.msg == ("信息录入成功"))
            //                        {
            //                            uInfo uInfo = new uInfo();
            //                            uInfo.TableName = "WorkTest.SampleInfo";
            //                            uInfo.value = "xgState=2";
            //                            uInfo.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}'";
            //                            uInfo.MessageShow = 1;
            //                            uInfo uInfo2 = new uInfo();
            //                            uInfo2.TableName = "WorkPer.SampleBlendInfo";
            //                            uInfo2.value = "xgState=2";
            //                            uInfo2.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}'";
            //                            uInfo2.MessageShow = 1;
            //                            ApiHelpers.postInfo(uInfo);
            //                            ApiHelpers.postInfo(uInfo2);
            //                            //DRSampleInfo["xgState"] = 2;
            //                            upinfostring = barcode + $"{x.msg}";
            //                        }
            //                        else
            //                        {
            //                            uInfo uInfo = new uInfo();
            //                            uInfo.TableName = "WorkTest.SampleInfo";
            //                            uInfo.value = "xgState=3";
            //                            uInfo.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}'";
            //                            uInfo.MessageShow = 1;
            //                            uInfo uInfo2 = new uInfo();
            //                            uInfo2.TableName = "WorkPer.SampleBlendInfo";
            //                            uInfo2.value = "xgState=3";
            //                            uInfo2.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}'";
            //                            uInfo2.MessageShow = 1;
            //                            ApiHelpers.postInfo(uInfo);
            //                            ApiHelpers.postInfo(uInfo2);
            //                            upinfostring = barcode+$"{x.msg}";
            //                        }

            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    upinfostring = barcode+ex.Message;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            upinfostring = barcode + "检验结果为空，结果无法上传！";
            //        }
            //        backgroundWorker.ReportProgress(0, upinfostring);

            //    }
            //}
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            string upinfostring = e.UserState.ToString();
            TEupInfo.EditValue = upinfostring + "\r\n" + TEupInfo.EditValue;
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sdf.HideMe(this);
            BTselect_Click(null, null);
        }

        private void BTPrint_Click(object sender, EventArgs e)
        {

        }
        //xianjikong.GetToken();
        //xianjikong.getDataByCode();
        private void UpResult_Click(object sender, EventArgs e)
        {
            //FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "正在上传信息，请稍等......");
            //GVSampleInfo.FocusedRowHandle = -1;
            ////string sampleCode = "";
            //List<insertResultByCode> insertResultByCodes = new List<insertResultByCode>();
            //for (int a = 0; a < GVSampleInfo.RowCount; a++)
            //{
            //    DataRow DRSampleInfo = GVSampleInfo.GetDataRow(a);
            //    string upinfostring = "";
            //    bool sampleState = DRSampleInfo["check"] != DBNull.Value ? Convert.ToBoolean(DRSampleInfo["check"]) : false;
            //    if (sampleState)
            //    {
            //        if (DRSampleInfo["hospitalBarcode"] != DBNull.Value || DRSampleInfo["hospitalBarcode"].ToString().Trim() != "")
            //        {
            //            string sampleCodes = DRSampleInfo["hospitalBarcode"].ToString().Trim();


            //            string geneA = DRSampleInfo["geneA"] != DBNull.Value ? DRSampleInfo["geneA"].ToString().Trim() : "";
            //            string geneB = DRSampleInfo["geneB"] != DBNull.Value ? DRSampleInfo["geneB"].ToString().Trim() : "";

            //            insertResultByCode insertResultByCode = new insertResultByCode();
            //            insertResultByCode.code = sampleCodes;
            //            if (geneA != "" && geneB != "")
            //            {
            //                if (geneA.Contains("阳") || geneB.Contains("阳"))
            //                {
            //                    upinfostring = "检验结果为阳性，结果无法上传！";

            //                }
            //                else
            //                {
            //                    insertResultByCode.status = "1";//返回值结果
            //                    insertResultByCodes.Add(insertResultByCode);
            //                    string sr = JsonHelper.SerializeObjct(insertResultByCodes);
            //                    string upstate = xianjkApi.insertResultByCode(sr);


            //                    var x = JsonConvert.DeserializeObject<JObject>(upstate);
            //                    if (x["code"].ToString() != "200" || x["msg"].ToString() != "结果录入成功")
            //                    {
            //                        upinfostring = $"上传数据错误！\r\n{x["msg"].ToString()}";
            //                    }
            //                    else
            //                    {
            //                        uInfo uInfo = new uInfo();
            //                        uInfo.TableName = "WorkTest.SampleInfo";
            //                        uInfo.value = "xgState=2";
            //                        uInfo.wheres = $"id = {DRSampleInfo["id"].ToString()}";
            //                        uInfo.MessageShow = 1;
            //                        uInfo uInfo2 = new uInfo();
            //                        uInfo2.TableName = "WorkPer.SampleBlendInfo";
            //                        uInfo2.value = "xgState=2";
            //                        uInfo.wheres = $"id = {DRSampleInfo["id"].ToString()}";
            //                        uInfo2.MessageShow = 1;
            //                        ApiHelpers.postInfo(uInfo);
            //                        ApiHelpers.postInfo(uInfo2);
            //                        DRSampleInfo["xgState"] = 2;
            //                        upinfostring = $"{x["msg"].ToString()}";
            //                    }

            //                }
            //            }
            //            else
            //            {
            //                upinfostring = $"条码号：{DRSampleInfo["barcode"]}，检验结果为空，结果无法上传！";
            //            }
            //        }
            //        else
            //        {
            //            upinfostring = $"外部条码号不能为空！";
            //        }
            //    }
            //    TEupInfo.EditValue = DRSampleInfo["barcode"]+":" + upinfostring+"\r\n" + TEupInfo.EditValue;
            //}
            //frmWait.HideMe(this);
        }



        FrmWait sdf;

        /// <summary>
        /// 同步自检结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SampleUpResult_Click(object sender, EventArgs e)
        {
            GVSampleInfo.FocusedRowHandle = -1;
            DataTable DTSampleInfo = GCSampleInfo.DataSource as DataTable;
            SampleUpResult.Enabled = false;
            sdf = new FrmWait();
            sdf.ShowMe( this,"系统提示", "正在上传信息，请稍等......");

            for (int a = DTSampleInfo.Rows.Count - 1; a >= 0; a--)
            {

                List<batchInsertNucResult> batchInsertNucResults = new List<batchInsertNucResult>();
                DataRow DRSampleInfo = DTSampleInfo.Rows[a];
                string upinfostring = "";
                bool sampleState = DRSampleInfo["check"] != DBNull.Value ? Convert.ToBoolean(DRSampleInfo["check"]) : false;
                if (sampleState)
                {

                    batchInsertNucResult batchSampleInfo = new batchInsertNucResult();
                    string barcode = DRSampleInfo["barcode"] != DBNull.Value ? DRSampleInfo["barcode"].ToString().Trim() : "";
                    batchSampleInfo.userName = DRSampleInfo["patientName"] != DBNull.Value ? DRSampleInfo["patientName"].ToString().Trim() : "";
                    batchSampleInfo.sex = DRSampleInfo["patientSexNames"] != DBNull.Value ? DRSampleInfo["patientSexNames"].ToString().Trim() : "";
                    //batchSampleInfo.cardType = DRSampleInfo["patientName"] != DBNull.Value ? DRSampleInfo["patientName"].ToString().Trim() : "";
                    batchSampleInfo.cardNum = DRSampleInfo["patientCardNo"] != DBNull.Value ? DRSampleInfo["patientCardNo"].ToString().Trim() : "";
                    if (batchSampleInfo.cardNum.Length == 18 || batchSampleInfo.cardNum.Length == 15)
                    {
                        batchSampleInfo.cardType = "1";
                    }
                    else
                    {
                        batchSampleInfo.cardType = "2";
                    }
                    if (batchSampleInfo.cardType == "2")
                    {
                        string passportNo = DRSampleInfo["passportNo"] != DBNull.Value ? DRSampleInfo["passportNo"].ToString().Trim() : "";
                        if (passportNo != "")
                        {
                            batchSampleInfo.cardNum = passportNo;
                            batchSampleInfo.cardType = "2";
                        }

                    }

                    batchSampleInfo.phone = DRSampleInfo["patientPhone"] != DBNull.Value ? DRSampleInfo["patientPhone"].ToString().Trim() : "";
                    batchSampleInfo.fromOrg = DRSampleInfo["hospitalNames"] != DBNull.Value ? DRSampleInfo["hospitalNames"].ToString().Trim() : "";
                    batchSampleInfo.collectTime = DRSampleInfo["sampleTime"] != DBNull.Value ? DRSampleInfo["sampleTime"].ToString().Trim() : "";
                    //batchSampleInfo.collectPart = DRSampleInfo["sampleTypeNames"] != DBNull.Value ? DRSampleInfo["sampleTypeNames"].ToString().Trim() : "";
                    batchSampleInfo.collectPart = DRSampleInfo["sampleTypeNames"] != DBNull.Value ? DRSampleInfo["sampleTypeNames"].ToString().Trim() : "";
                    batchSampleInfo.detOrg = "西安迈尚医学检验实验室";
                    batchSampleInfo.recieveTime = DRSampleInfo["receiveTime"] != DBNull.Value ? DRSampleInfo["receiveTime"].ToString().Trim() : "";



                    string geneA = DRSampleInfo["geneA"] != DBNull.Value ? DRSampleInfo["geneA"].ToString().Trim() : "";
                    string geneB = DRSampleInfo["geneB"] != DBNull.Value ? DRSampleInfo["geneB"].ToString().Trim() : "";


                    insertResultByCode insertResultByCode = new insertResultByCode();
                    insertResultByCode.code = barcode;
                    if (geneA != "" && geneB != "")
                    {

                        if (geneA.Contains("阳") || geneB.Contains("阳"))
                        {
                            upinfostring = "检验结果为阳性，结果无法上传！";
                        }
                        else
                        {
                            batchSampleInfo.detResult = "阴性";


                            //batchSampleInfo.detResult = "阴性";
                            batchSampleInfo.detTime = DRSampleInfo["checkTime"] != DBNull.Value ? DRSampleInfo["checkTime"].ToString() : "";
                            batchInsertNucResults.Add(batchSampleInfo);
                            string sr = JsonHelper.SerializeObjct(batchInsertNucResults);
                            string reMsg = xianjkApi.batchInsertNucResult(sr);
                            try
                            {
                                jkresult x = JsonConvert.DeserializeObject<jkresult>(reMsg);
                                if (x.code != "200" || !x.msg.Contains("信息录入成功"))
                                {
                                    upinfostring = barcode + $"上传数据错误！\r\n{x.msg}";
                                }
                                else
                                {
                                    if (x.msg == ("信息录入成功"))
                                    {
                                        uInfo uInfo = new uInfo();
                                        uInfo.TableName = "WorkTest.SampleInfo";
                                        uInfo.value = "xgState=2";
                                        uInfo.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                                        uInfo.MessageShow = 1;
                                        uInfo uInfo2 = new uInfo();
                                        uInfo2.TableName = "WorkPer.SampleBlendInfo";
                                        uInfo2.value = "xgState=2";
                                        uInfo2.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                                        uInfo2.MessageShow = 1;
                                        int aaa = ApiHelpers.postInfo(uInfo);
                                        int bbb = ApiHelpers.postInfo(uInfo2);
                                        if (aaa > 0 || bbb > 0)
                                            DRSampleInfo["xgState"] = 2;
                                        upinfostring = barcode + $"{x.msg}";
                                    }
                                    else
                                    {
                                        uInfo uInfo = new uInfo();
                                        uInfo.TableName = "WorkTest.SampleInfo";
                                        uInfo.value = "xgState=3";
                                        uInfo.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                                        uInfo.MessageShow = 1;
                                        uInfo uInfo2 = new uInfo();
                                        uInfo2.TableName = "WorkPer.SampleBlendInfo";
                                        uInfo2.value = "xgState=3";
                                        uInfo2.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                                        uInfo2.MessageShow = 1;
                                        int aaa = ApiHelpers.postInfo(uInfo);
                                        int bbb = ApiHelpers.postInfo(uInfo2);
                                        if (aaa > 0 || bbb > 0)
                                            DRSampleInfo["xgState"] = 3;
                                        upinfostring = barcode + $"{x.msg}";
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                upinfostring = barcode + ex.Message;
                            }
                        }


                        //if (geneA.Contains("阳") || geneB.Contains("阳"))
                        //{
                        //    batchSampleInfo.detResult = "阳性";
                        //}
                        //else
                        //{
                        //    batchSampleInfo.detResult = "阴性";
                        //}

                        ////batchSampleInfo.detResult = "阴性";
                        //batchSampleInfo.detTime = DRSampleInfo["checkTime"] != DBNull.Value ? DRSampleInfo["checkTime"].ToString() : "";
                        //batchInsertNucResults.Add(batchSampleInfo);
                        //string sr = JsonHelper.SerializeObjct(batchInsertNucResults);
                        //string reMsg = xianjkApi.batchInsertNucResult(sr);
                        //try
                        //{
                        //    jkresult x = JsonConvert.DeserializeObject<jkresult>(reMsg);
                        //    if (x.code != "200" || !x.msg.Contains("信息录入成功"))
                        //    {
                        //        upinfostring = barcode + $"上传数据错误！\r\n{x.msg}";
                        //    }
                        //    else
                        //    {
                        //        if (x.msg == ("信息录入成功"))
                        //        {
                        //            uInfo uInfo = new uInfo();
                        //            uInfo.TableName = "WorkTest.SampleInfo";
                        //            uInfo.value = "xgState=2";
                        //            uInfo.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                        //            uInfo.MessageShow = 1;
                        //            uInfo uInfo2 = new uInfo();
                        //            uInfo2.TableName = "WorkPer.SampleBlendInfo";
                        //            uInfo2.value = "xgState=2";
                        //            uInfo2.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                        //            uInfo2.MessageShow = 1;
                        //            int aaa = ApiHelpers.postInfo(uInfo);
                        //            int bbb = ApiHelpers.postInfo(uInfo2);
                        //            if (aaa > 0 || bbb > 0)
                        //                DRSampleInfo["xgState"] = 2;
                        //            upinfostring = barcode + $"{x.msg}";
                        //        }
                        //        else
                        //        {
                        //            uInfo uInfo = new uInfo();
                        //            uInfo.TableName = "WorkTest.SampleInfo";
                        //            uInfo.value = "xgState=3";
                        //            uInfo.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                        //            uInfo.MessageShow = 1;
                        //            uInfo uInfo2 = new uInfo();
                        //            uInfo2.TableName = "WorkPer.SampleBlendInfo";
                        //            uInfo2.value = "xgState=3";
                        //            uInfo2.wheres = $"patientCardNo = '{batchSampleInfo.cardNum}' or passportNo= '{batchSampleInfo.cardNum}' and xgState!=2";
                        //            uInfo2.MessageShow = 1;
                        //            int aaa = ApiHelpers.postInfo(uInfo);
                        //            int bbb = ApiHelpers.postInfo(uInfo2);
                        //            if (aaa > 0 || bbb > 0)
                        //                DRSampleInfo["xgState"] = 3;
                        //            upinfostring = barcode + $"{x.msg}";
                        //        }

                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    upinfostring = barcode + ex.Message;
                        //}

                    }
                    else
                    {
                        upinfostring = barcode + "检验结果为空，结果无法上传！";
                    }
                    //backgroundWorker.ReportProgress(0, upinfostring);
                    TEupInfo.EditValue = upinfostring + "\r\n" + TEupInfo.EditValue;

                }



            }

            SampleUpResult.Enabled = true;
            sdf.HideMe(this);

            for (int i = 0; i < GVSampleInfo.RowCount; i++)
            {
                GVSampleInfo.SetRowCellValue(i, "check", false);
            }
            string logPath = Application.StartupPath + "\\疾控上传记录";
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            string savePath = logPath + $"\\{DateTime.Now.ToString("yyyyMMddHHmmss") + CommonData.UserInfo.names}.txt";
            System.IO.FileStream fs = new System.IO.FileStream(savePath, System.IO.FileMode.Append);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
            sw.Write(TEupInfo.EditValue.ToString() + "\r\n");
            sw.Dispose();
            sw.Close();
            fs.Dispose();

        }
        public class jkresult
        {
            public string code { get; set; } = "";
            public string msg { get; set; } = "";
        }

        /// <summary>
        /// 修改上传状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTUpHandle_Click(object sender, EventArgs e)
        {
            GVSampleInfo.FocusedRowHandle = -1;
            string sampleCode = "";
            string upinfostring = "";
            //string nowSampleCode = "";
            for (int a = GVSampleInfo.RowCount-1; a >=0; a--)
            {

                List<batchInsertNucResult> batchInsertNucResults = new List<batchInsertNucResult>();
                DataRow DRSampleInfo = GVSampleInfo.GetDataRow(a);
                
                bool sampleState = DRSampleInfo["check"] != DBNull.Value ? Convert.ToBoolean(DRSampleInfo["check"]) : false;
                if (sampleState)
                {
                    string xgstate= DRSampleInfo["xgstate"] != DBNull.Value ? DRSampleInfo["xgstate"].ToString() : "0";
                    //if (xgstate == "3")
                    //{


                        string cardid = DRSampleInfo["patientCardNo"] != DBNull.Value ? DRSampleInfo["patientCardNo"].ToString() : "";
                        string barcode = DRSampleInfo["barcode"] != DBNull.Value ? DRSampleInfo["barcode"].ToString() : "";
                        if (cardid != "")
                        {
                            uInfo uInfo = new uInfo();
                            uInfo.TableName = "WorkTest.SampleInfo";
                            uInfo.value = "xgState=2";
                            uInfo.wheres = $"patientCardNo = '{cardid}' or passportNo= '{cardid}'";
                            uInfo.MessageShow = 1;
                            uInfo uInfo2 = new uInfo();
                            uInfo2.TableName = "WorkPer.SampleBlendInfo";
                            uInfo2.value = "xgState=2";
                            uInfo2.wheres = $"patientCardNo = '{cardid}' or passportNo= '{cardid}'";
                            uInfo2.MessageShow = 1;
                            ApiHelpers.postInfo(uInfo);
                            ApiHelpers.postInfo(uInfo2);
                            DRSampleInfo["xgState"] = 2;
                            //upinfostring = $"{x["msg"].ToString()}";
                        }
                        else
                        {
                            upinfostring += "条码号:" + barcode + "无人员身份证信息，无法修改;\r\n";
                        }
                    //}
                    //else
                    //{
                    //    upinfostring += "条码号:" + barcode + "信息未上传/已经上传成功;\r\n";
                    //}
                }
            }
            if(upinfostring!="")
            {
                MessageBox.Show(upinfostring, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void GVSampleInfo_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "geneA")
            {
                if (e.CellValue != null)
                {
                    if (e.CellValue.ToString().Contains("阳性"))
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else
                    {
                        if (e.CellValue.ToString().Contains("阴性"))
                        {
                            e.Appearance.BackColor = Color.Green;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.YellowGreen;
                        }
                    }
                }

            }
            if (e.Column.FieldName == "xgState")
            {
                if (e.CellValue != null)
                {
                    if (e.CellValue.ToString().Contains("1"))
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else
                    {
                        if (e.CellValue.ToString().Contains("2"))
                        {
                            e.Appearance.BackColor = Color.Green;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.YellowGreen;
                        }
                    }
                }

            }
        }

        private void GCSampleInfo_Click(object sender, EventArgs e)
        {

        }


    }
}
