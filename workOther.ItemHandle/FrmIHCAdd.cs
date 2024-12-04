using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace workOther.ItemHandle
{
    public partial class FrmIHCAdd : DevExpress.XtraEditors.XtraForm
    {
        string FrmState = "";
        int perid = 0;
        int testid = 0;
        int infoID = 0;
        /// <summary>
        /// 提交增项申请
        /// </summary>
        /// <param name="sampleInfo">DR样本信息</param>
        /// <param name="recordTypeNO">1新增2编辑</param>
        public FrmIHCAdd(DataRow DRsampleInfo, string recordTypeNO = "")
        {
            FrmState = recordTypeNO;
            InitializeComponent();
            if (DRsampleInfo != null)
            {
                perid = DRsampleInfo["perid"] != DBNull.Value ? Convert.ToInt32(DRsampleInfo["perid"]) : 0;
                testid = DRsampleInfo["id"] != DBNull.Value ? Convert.ToInt32(DRsampleInfo["id"]) : 0;
                DEsampleTime.EditValue = DRsampleInfo["sampleTime"];
                //TEageDay.EditValue = DRsampleInfo["ageDay"];
                //TEageMoth.EditValue = DRsampleInfo["ageMoth"];
                TEpatientName.EditValue = DRsampleInfo["patientName"];
                GEagentNo.EditValue = DRsampleInfo["agentNO"];
                TEageYear.EditValue = DRsampleInfo["ageYear"] != DBNull.Value ? DRsampleInfo["ageYear"].ToString() + "岁" : "";
                //MEapplyItemNames.EditValue = DRsampleInfo["groupNames"];
                TEbarcode.EditValue = DRsampleInfo["barcode"];
                TEbedNo.EditValue = DRsampleInfo["bedNo"];
                TEclinicalDiagnosis.EditValue = DRsampleInfo["clinicalDiagnosis"];
                TEcutPart.EditValue = DRsampleInfo["cutPart"];
                TEdepartment.EditValue = DRsampleInfo["department"];
                TEdoctorPhone.EditValue = DRsampleInfo["doctorPhone"];
                GEhospitalNo.EditValue = DRsampleInfo["hospitalNO"];
                TEmedicalNo.EditValue = DRsampleInfo["medicalNo"];
                DEmenstrualTime.EditValue = DRsampleInfo["menstrualTime"];
                TEpathologyNo.EditValue = DRsampleInfo["pathologyNo"];
                DEreceiveTime.EditValue = DRsampleInfo["receiveTime"];
                //TEpatientAddress.EditValue = DRsampleInfo["patientAddress"];
                TEpatientCardNo.EditValue = DRsampleInfo["patientCardNo"];
                TEpatientPhone.EditValue = DRsampleInfo["patientPhone"];
                GEpatientSexNO.EditValue = DRsampleInfo["patientSexNO"];
                GEpatientTypeNO.EditValue = DRsampleInfo["patientTypeNO"];
                TEperRemark.EditValue = DRsampleInfo["perRemark"];
                //TEsampleID.EditValue = DRsampleInfo["id"];
                GEsampleShapeNO.EditValue = DRsampleInfo["sampleShapeNO"];
                GEsampleTypeNO.EditValue = DRsampleInfo["sampleTypeNO"];
                TEsendDoctor.EditValue = DRsampleInfo["sendDoctor"];
                TEperRemark.EditValue = DRsampleInfo["testRemark"];
                CEurgent.Checked = Convert.ToBoolean(DRsampleInfo["urgent"]);
                if (recordTypeNO == "2")
                {
                    string submitItemCodes = DRsampleInfo["submitItemCodes"] != DBNull.Value ? DRsampleInfo["submitItemCodes"].ToString() : "";
                    if (submitItemCodes != "")
                    {
                        GCAddInfo.DataSource = WorkCommData.DTItemGroup.Select($"no in ({submitItemCodes})").CopyToDataTable();
                    }
                }


            }
        }
        private void FrmIHC_Load(object sender, EventArgs e)
        {
            getPrintInfo();
            //GridLookUpEdites.Formats(RGEperStateNO);
            GridLookUpEdites.Formats(GEagentNo);
            GridLookUpEdites.Formats(GEhospitalNo);
            GridLookUpEdites.Formats(GEpatientSexNO);
            GridLookUpEdites.Formats(GEpatientTypeNO);
            GridLookUpEdites.Formats(GEsampleShapeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);
            GEagentNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);
            GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            GridLookUpEdites.Formats(GErecordTypeNO);
            GErecordTypeNO.Properties.DataSource = OtherInfoData.DTSubmitState;
            GErecordTypeNO.EditValue = "6";
        }

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
            }
            catch
            {
                CBPrintInfo.EditValue = null;
            }
            //CBPrintList.SelectedIndex = 0;

        }

        private void BTPrint_Click(object sender, EventArgs e)
        {
            //layoutControl1.ShowPrintPreview();
            if (CBPrintInfo.EditValue != null)
            {
                //DataRowView drv = (DataRowView)BS_Roads.Current;
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = layoutControl1;


                //是否为横版
                link.Landscape = false;
                //link.PaperKind = PaperKind.A4Extra;
                link.PaperKind = PaperKind.A4;
                link.Margins = new Margins(20, 20, 80, 50);
                PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                //phf.Header.Content.AddRange(new string[] { "", drv["线路名"].ToString() + "站点信息表", "" });
                phf.Header.Content.AddRange(new string[] { "", "免疫组化申请单", "" });
                phf.Header.Font = new System.Drawing.Font("宋体", 16, System.Drawing.FontStyle.Regular);
                phf.Header.LineAlignment = BrickAlignment.Center;
                phf.Footer.Content.Clear();
                phf.Footer.Content.AddRange(new string[] { "", "", $"打印人:{CommonData.UserInfo.names}       " + String.Format("打印时间: {0:g}", DateTime.Now) });
                phf.Footer.LineAlignment = BrickAlignment.Center;
                link.CreateDocument();
                link.ShowPreview();
            }
            else
            {
                MessageBox.Show("打印机不可用...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        string SaveState = "0";
        public string reSaveState()
        {
            return SaveState;
        }
        private void BTSave_Click(object sender, EventArgs e)
        {
            if (testid != 0)
            {
                if (GErecordTypeNO.EditValue != null)
                {
                    if (TEreason.EditValue != null)
                    {
                        if (TEreason.EditValue.ToString().Trim().Length >= 4)
                        {


                            string CheckGroupCodes = "";
                            string CheckGroupNames = "";
                            for (int a = 0; a < GVAddInfo.RowCount; a++)
                            {

                                string itemcode = GVAddInfo.GetRowCellValue(a, "no") != DBNull.Value ? GVAddInfo.GetRowCellValue(a, "no").ToString() : "";
                                CheckGroupCodes += itemcode + ",";
                                string itemName = GVAddInfo.GetRowCellValue(a, "names") != DBNull.Value ? GVAddInfo.GetRowCellValue(a, "names").ToString() : "";
                                CheckGroupNames += itemName + ",";

                            }
                            if (CheckGroupCodes != "")
                            {
                                CheckGroupCodes = CheckGroupCodes.Length > 0 ? CheckGroupCodes.Substring(0, CheckGroupCodes.Length - 1) : "";
                                CheckGroupNames = CheckGroupNames.Length > 0 ? CheckGroupNames.Substring(0, CheckGroupNames.Length - 1) : "";
                                if (FrmState == "1")
                                {
                                    iInfo iInfo = new iInfo();
                                    iInfo.TableName = "WorkOther.IHCRecord";
                                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                                    //pairs.Add("dstate", CEdstate.EditValue);
                                    //pairs.Add("state", CEstate.EditValue);
                                    //pairs.Add("handleTime", TEhandleTime.EditValue);
                                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //pairs.Add("id", TEid.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);
                                    pairs.Add("creater", CommonData.UserInfo.names);
                                    //pairs.Add("handler", TEhandler.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);

                                    //pairs.Add("contactMode", TEcontactMode.EditValue);
                                    pairs.Add("submitItemCodes", CheckGroupCodes);
                                    pairs.Add("submitItemNames", CheckGroupNames);
                                    //pairs.Add("handleResult", TEhandleResult.EditValue);
                                    //pairs.Add("handleTypeNO", GEhandleTypeNO.EditValue);
                                    pairs.Add("perid", perid);
                                    //pairs.Add("pleasLevel", TEpleasLevel.EditValue);
                                    pairs.Add("recordTypeNO", GErecordTypeNO.EditValue);
                                    pairs.Add("recordValue", TEreason.EditValue);
                                    pairs.Add("testid", testid);
                                    pairs.Add("barcode", TEbarcode.EditValue);
                                    iInfo.values = pairs;
                                    iInfo.MessageShow = 1;
                                    int s = ApiHelpers.postInfo(iInfo);
                                    if (s == 1)
                                    {
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    uInfo uInfo = new uInfo();
                                    uInfo.TableName = "WorkOther.IHCRecord";
                                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                                    //pairs.Add("dstate", CEdstate.EditValue);
                                    //pairs.Add("state", CEstate.EditValue);
                                    //pairs.Add("handleTime", TEhandleTime.EditValue);
                                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //pairs.Add("id", TEid.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);
                                    pairs.Add("creater", CommonData.UserInfo.names);
                                    //pairs.Add("handler", TEhandler.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);

                                    //pairs.Add("contactMode", TEcontactMode.EditValue);
                                    pairs.Add("submitItemCodes", CheckGroupCodes);
                                    pairs.Add("submitItemNames", CheckGroupNames);
                                    //pairs.Add("handleResult", TEhandleResult.EditValue);
                                    //pairs.Add("handleTypeNO", GEhandleTypeNO.EditValue);
                                    //pairs.Add("perid", perid);
                                    //pairs.Add("pleasLevel", TEpleasLevel.EditValue);
                                    pairs.Add("recordTypeNO", GErecordTypeNO.EditValue);
                                    pairs.Add("recordValue", TEreason.EditValue);
                                    //pairs.Add("testid", sampleInfoID);
                                    //pairs.Add("barcode", TEbarcode.EditValue);
                                    uInfo.values = pairs;
                                    uInfo.wheres = $"id={infoID}";
                                    uInfo.MessageShow = 1;
                                    int s = ApiHelpers.postInfo(uInfo);
                                    if (s == 1)
                                    {
                                        this.Close();
                                    }
                                }

                            }

                        }
                        else
                        {
                            SaveState = "0";
                            MessageBox.Show("请填写提交原因,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        SaveState = "0";
                        MessageBox.Show("请填写提交原因,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SaveState = "0";
                    MessageBox.Show("提交类型不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTable FrmDT;
        private void BTAddItem_Click(object sender, EventArgs e)
        {

            string ItemNo = "";
            if (GVAddInfo.RowCount > 0)
            {
                for (int a = 0; a < GVAddInfo.RowCount; a++)
                {
                    ItemNo += GVAddInfo.GetRowCellValue(a, "no") + ",";
                }
            }
            FrmShowIHC frmShowGroup = new FrmShowIHC(ItemNo);

            Func<List<DataRow>> Func = frmShowGroup.ReturnResult;
            frmShowGroup.ShowDialog();
            if (Func() != null)
            {
                List<DataRow> dataRows = Func();
                if (dataRows.Count > 0)
                {
                    if (FrmDT == null)
                        FrmDT = dataRows[0].Table.Clone();
                    foreach (DataRow row in dataRows)
                    {
                        DataRow dataRow = FrmDT.NewRow();
                        dataRow.ItemArray = row.ItemArray;
                        FrmDT.Rows.Add(dataRow);
                    }
                    GCAddInfo.DataSource = FrmDT;
                    GVAddInfo.BestFitColumns();
                }
            }
        }

        private void BTRemove_Click(object sender, EventArgs e)
        {
            if (GVAddInfo.GetFocusedDataRow() != null)
            {
                GVAddInfo.DeleteRow(GVAddInfo.FocusedRowHandle);
            }
        }

        private void BTEditReport_Click(object sender, EventArgs e)
        {

        }
    }
}
