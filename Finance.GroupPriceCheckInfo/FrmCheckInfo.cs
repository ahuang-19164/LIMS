using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.FinanceModel;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Finance.GroupPriceCheckInfo
{
    public partial class FrmCheckInfo : DevExpress.XtraEditors.XtraForm
    {
        //string FinanceCheckGetSerial = "";
        string FinanceCheckSelect = "";
        string FinanceCheckInfo = "";
        string FinanceCheckInfoRe = "";
        public FrmCheckInfo()
        {
            InitializeComponent();

            SysPowerHelper.UserPower(barManager1);

            //FinanceCheckGetSerial = ConfigInfos.ReadConfigInfo("FinanceCheckGetSerial");
            FinanceCheckSelect = ConfigInfos.ReadConfigInfo("FinanceCheckSelect");
            FinanceCheckInfo = ConfigInfos.ReadConfigInfo("FinanceCheckInfo");
            FinanceCheckInfoRe = ConfigInfos.ReadConfigInfo("FinanceCheckInfoRe");
            BEStartTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            BEEndTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
            getPrintInfo();
        }

        private void FrmPriceInfoCheck_Load(object sender, EventArgs e)
        {
            GridControls.formartGridView(GVCheckInfo);
            GridControls.showEmbeddedNavigator(GCCheckInfo);

            GridControls.ShowViewColor(GVCheckInfo);

            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);

            GridControls.ShowViewColor(GVInfo);




            GridLookUpEdites.Formats(RGEtabTypeNO, FinanceInfoData.DTTabType);





            GridLookUpEdites.Formats(RGEchargeLevelNO);
            GridLookUpEdites.Formats(RGEchargeTypeNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEclientNO);
            //GridLookUpEdites.Formats(RGEpersonNO);




            //GridLookUpEdites.Formats(RGEChargeLevelNO);
            //GridLookUpEdites.Formats(RGEPersonNO);
            //GridLookUpEdites.Formats(RGEagentNO);


            RGEclientNO.DataSource = WorkCommData.DTClientInfo;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEchargeTypeNO.DataSource = FinanceInfoData.DTChargeType;
            //RGEagentNO.DataSource = WorkCommData.DTClientAgent;
            RGEchargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            //RGEPersonNO.DataSource = CommonData.DTUserInfoAll;

            //GCClientnfo.DataSource = DTHelper.DTVisible(WorkCommData.DTClientInfo);
            //GVClientInfo.BestFitColumns();

        }
        public void getPrintInfo()
        {
            try
            {


                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    RCBPrintInfo.Items.Add(printer);
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

        string CheckNO = "";
        private void GVCheckInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (GVCheckInfo.GetFocusedDataRow() != null)
            {

                commInfoModel<SelectFinanceCheckModel> commInfo = new commInfoModel<SelectFinanceCheckModel>();
                List<SelectFinanceCheckModel> selectFinanceChecks = new List<SelectFinanceCheckModel>();
                SelectFinanceCheckModel selectFinanceCheck = new SelectFinanceCheckModel();

                List<string> listClient = new List<string>();
                if (GVCheckInfo.GetFocusedRowCellValue("clientNO") != DBNull.Value)
                    listClient.Add(GVCheckInfo.GetFocusedRowCellValue("clientNO").ToString());
                CheckNO = GVCheckInfo.GetFocusedRowCellValue("checkNo") != DBNull.Value ? GVCheckInfo.GetFocusedRowCellValue("checkNo").ToString() : "";
                selectFinanceCheck.checkNo = CheckNO;
                selectFinanceCheck.ListClientCodes = listClient;

                selectFinanceChecks.Add(selectFinanceCheck);
                commInfo.infos = selectFinanceChecks;
                commInfo.UserName = CommonData.UserInfo.names;
                string sr = JsonHelper.SerializeObjct(commInfo);



                //string sr = JsonHelper.SerializeObjct(sCheckInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(FinanceCheckSelect, sr);
                //DataTable DTsampleInfo = JsonHelper.JsonConvertObject<DataTable>(jm);
                DataTable dataTable = JsonHelper.StringToDT(jm);
                if (dataTable != null)
                {
                    dataTable.Columns.Add("check", typeof(bool));
                    GCInfo.DataSource = dataTable;
                    GVInfo.BestFitColumns();
                }
                else
                {
                    GCInfo.DataSource = null;
                }
            }
            else
            {
                GCInfo.DataSource = null;
            }
        }


        private void checkAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkAll.Checked)
            {
                for (int a = 0; a < GVInfo.RowCount; a++)
                {
                    GVInfo.SetRowCellValue(a, "check", true);
                }
            }
            else
            {
                for (int a = 0; a < GVInfo.RowCount; a++)
                {
                    GVInfo.SetRowCellValue(a, "check", false);
                }
            }
        }

        private void BTCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVInfo.FocusedRowHandle = -1;
            try
            {



                commInfoModel<FinanceCheckInfoModel> commInfo = new commInfoModel<FinanceCheckInfoModel>();
                commInfo.UserName= CommonData.UserInfo.names;
                List<FinanceCheckInfoModel> financeCheckInfos = new List<FinanceCheckInfoModel>();
                FinanceCheckInfoModel CheckInfo = new FinanceCheckInfoModel();

                //CheckInfo.checkNo = TECheckNO.EditValue.ToString();
                CheckInfo.checkNo = CheckNO;
                CheckInfo.operatTimeStart = BEStartTime.EditValue.ToString();
                CheckInfo.operatTimeEnd = BEEndTime.EditValue.ToString();



                List<string> listSampleID = new List<string>();
                for (int a = 0; a < GVInfo.RowCount; a++)
                {
                    //DataRow aaa = GVInfo.GetDataRow(a);
                    //DataTable dataTable = aaa.Table;
                    if (GVInfo.GetDataRow(a)["check"] != DBNull.Value && Convert.ToBoolean(GVInfo.GetDataRow(a)["check"]) != false)
                    {

                        if (GVInfo.GetDataRow(a)["financeID"] != DBNull.Value)
                            listSampleID.Add(GVInfo.GetDataRow(a)["financeID"].ToString());
                    }
                }
                CheckInfo.ListFinanceID = listSampleID;

                financeCheckInfos.Add(CheckInfo);

                commInfo.infos = financeCheckInfos;
                string sr = JsonHelper.SerializeObjct(commInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(FinanceCheckInfoRe, sr);
                //ReInfo<SampleInfo> commReInfo = JsonHelper.JsonConvertObject<ReInfo<SampleInfo>>(jm);
                if (jm.code == 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BTSelect.Enabled = false;
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "查询信息请稍后......");


            commInfoModel<SelectFinanceCheckModel> commInfo = new commInfoModel<SelectFinanceCheckModel>();


            commInfo.UserName = CommonData.UserInfo.names;
            List<SelectFinanceCheckModel> selectFinances = new List<SelectFinanceCheckModel>();


            SelectFinanceCheckModel sCheckInfo = new SelectFinanceCheckModel();
            

            sCheckInfo.checkNo = TECheckNO.EditValue != null ? TECheckNO.EditValue.ToString() : "";
            sCheckInfo.operatTimeStart = BEStartTime.EditValue.ToString();
            sCheckInfo.operatTimeEnd = BEEndTime.EditValue.ToString();

            selectFinances.Add(sCheckInfo);
            commInfo.infos = selectFinances;

            string sr = JsonHelper.SerializeObjct(commInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(FinanceCheckSelect, sr);
            DataTable dataTable = JsonHelper.StringToDT(jm);
            //DataTable checkDT = JsonHelper.JsonConvertObject<DataTable>(jm);

            //if (dataTable != null)
            //{
            //    dataTable.Columns.Add("check", typeof(bool));
            //    GCInfo.DataSource = dataTable;
            //    GVInfo.BestFitColumns();
            //}
            //else
            //{
            //    GCInfo.DataSource = null;
            //}




            GCCheckInfo.DataSource = dataTable;
            GVCheckInfo.BestFitColumns();
            BTSelect.Enabled = true;
            frmWait.HideMe(this);
        }
        private void RTECheckNO_KeyDown(object sender, KeyEventArgs e)
        {
            //RTECheckNO
        }

        private void BTPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(GVCheckInfo.DataSource!=null&& GVCheckInfo.RowCount>0)
            {
                string hosName = "迈尚生物客户收费清单";
                string hosNo = GVCheckInfo.GetFocusedRowCellValue("clientNO").ToString();
                DataRow[] hosInfos = WorkCommData.DTClientInfo.Select($"no='{hosNo}'");
                if (hosInfos != null && hosInfos.Length > 0)
                    hosName = hosInfos[0]["names"].ToString();


                if (CBPrintInfo.EditValue != null)
                {
                    //DataRowView drv = (DataRowView)BS_Roads.Current;
                    PrintingSystem ps = new PrintingSystem();
                    PrintableComponentLink link = new PrintableComponentLink(ps);
                    link.Component = GCInfo;
                    link.Landscape = true;
                    link.PaperKind = PaperKind.A4Extra;
                    link.Margins = new Margins(20, 20, 80, 50);
                    PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                    phf.Header.Content.Clear();
                    //phf.Header.Content.AddRange(new string[] { "", drv["线路名"].ToString() + "站点信息表", "" });
                    phf.Header.Content.AddRange(new string[] { "", $"{hosName}收费账单", "" });
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
            else
            {
                MessageBox.Show("未找到需要打印的信息...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
