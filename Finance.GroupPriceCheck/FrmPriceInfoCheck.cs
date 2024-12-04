using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.FinanceModel;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Finance.GroupPriceCheck
{
    public partial class FrmPriceInfoCheck : DevExpress.XtraEditors.XtraForm
    {
        string FinanceCheckGetSerial = "";
        string FinanceCheckSelect = "";
        string FinanceCheckInfo = "";
        public FrmPriceInfoCheck()
        {
            InitializeComponent();

            SysPowerHelper.UserPower(barManager1);

            FinanceCheckGetSerial = ConfigInfos.ReadConfigInfo("FinanceCheckGetSerial");
            FinanceCheckSelect = ConfigInfos.ReadConfigInfo("FinanceCheckSelect");
            FinanceCheckInfo = ConfigInfos.ReadConfigInfo("FinanceCheckInfo");
            DEStartTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            DEEndTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
        }

        private void FrmPriceInfoCheck_Load(object sender, EventArgs e)
        {
            GridControls.formartGridView(GVClientInfo);
            GridControls.showEmbeddedNavigator(GCClientnfo);

            GridControls.ShowViewColor(GVClientInfo);

            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);

            GridControls.ShowViewColor(GVInfo);










            //GridLookUpEdites.Formats(RGEchargeLevelNO);
            GridLookUpEdites.Formats(RGEchargeTypeNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEtabTypeNO);
            //GridLookUpEdites.Formats(RGEpersonNO);




            GridLookUpEdites.Formats(RGEChargeLevelNO);
            GridLookUpEdites.Formats(RGEPersonNO);
            GridLookUpEdites.Formats(RGEagentNO);


            RGEtabTypeNO.DataSource = FinanceInfoData.DTTabType;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEchargeTypeNO.DataSource = FinanceInfoData.DTChargeType;
            RGEagentNO.DataSource = WorkCommData.DTClientAgent;
            RGEChargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEPersonNO.DataSource = CommonData.DTUserInfoAll;

            GCClientnfo.DataSource = DTHelper.DTVisible(WorkCommData.DTClientInfo);





            GVClientInfo.BestFitColumns();

            BTserial_ItemClick(null, null);
        }
        string clientNO = "";
        private void GVClientInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {


            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "读取信息请稍后......");

            if (GVClientInfo.GetFocusedDataRow() != null)
            {

                //commInfoModel<SelectFinanceCheckModel> commInfo = new commInfoModel<SelectFinanceCheckModel>();
                //List<SelectFinanceCheckModel> selectFinanceChecks = new List<SelectFinanceCheckModel>();
                //SelectFinanceCheckModel selectFinanceCheck = new SelectFinanceCheckModel();
                //selectFinanceCheck.checkNo = TECheckNO.EditValue != null ? TECheckNO.EditValue.ToString() : "";
                //selectFinanceCheck.operatTimeStart = DEStartTime.EditValue.ToString();
                //selectFinanceCheck.operatTimeEnd = DEEndTime.EditValue.ToString();
                //selectFinanceChecks.Add(selectFinanceCheck);
                //commInfo.infos = selectFinanceChecks;
                //string sr = JsonHelper.SerializeObjct(commInfo);

                commInfoModel<SelectFinanceCheckModel> commInfo = new commInfoModel<SelectFinanceCheckModel>();
                List<SelectFinanceCheckModel> selectFinanceChecks = new List<SelectFinanceCheckModel>();
                SelectFinanceCheckModel selectFinanceCheck = new SelectFinanceCheckModel();
                //selectFinanceCheck.checkNo = TECheckNO.EditValue != null ? TECheckNO.EditValue.ToString() : "";
                selectFinanceCheck.operatTimeStart = DEStartTime.EditValue.ToString();
                selectFinanceCheck.operatTimeEnd = DEEndTime.EditValue.ToString();
                selectFinanceChecks.Add(selectFinanceCheck);

    
                List<string> listClient = new List<string>();
                if (GVClientInfo.GetFocusedRowCellValue("no") != DBNull.Value)
                {
                    clientNO = GVClientInfo.GetFocusedRowCellValue("no").ToString();
                    listClient.Add(GVClientInfo.GetFocusedRowCellValue("no").ToString());
                }

                selectFinanceCheck.ListClientCodes = listClient;
                selectFinanceChecks.Add(selectFinanceCheck);
                commInfo.infos = selectFinanceChecks;
                commInfo.UserName = CommonData.UserInfo.names;
                string sr = JsonHelper.SerializeObjct(commInfo);
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
            frmWait.HideMe(this);
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
        private void BTserial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WebApiCallBack jm = ApiHelpers.postInfo(FinanceCheckGetSerial);
            //ReInfo<string> commReInfo = JsonHelper.JsonConvertObject<ReInfo<string>>(jm);
            if (jm.code == 0)
            {
                if (jm.data != null)
                {
                    TECheckNO.EditValue = jm.data.ToString(); ;

                }
            }
            else
            {
                MessageBox.Show("获取流水号失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void BTCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVInfo.FocusedRowHandle = -1;
            try
            {
                if (clientNO != null)
                {
                    commInfoModel<FinanceCheckInfoModel> commInfo = new commInfoModel<FinanceCheckInfoModel>();
                    commInfo.UserName = CommonData.UserInfo.names;
                    List<FinanceCheckInfoModel> financeCheckInfos = new List<FinanceCheckInfoModel>();



                    FinanceCheckInfoModel financeCheckInfo = new FinanceCheckInfoModel();
                    financeCheckInfo.checkNo = TECheckNO.EditValue.ToString();
                    financeCheckInfo.operatTimeStart = DEStartTime.EditValue.ToString();
                    financeCheckInfo.operatTimeEnd = DEEndTime.EditValue.ToString();
                    //financeCheckInfo.UserName = CommonData.UserInfo.names;

                    financeCheckInfo.clientNO = clientNO;
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
                    financeCheckInfo.ListFinanceID = listSampleID;
                    financeCheckInfos.Add(financeCheckInfo);
                    commInfo.infos = financeCheckInfos;
                    string sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(FinanceCheckInfo, sr);
                    //ReInfo<SampleInfo> commReInfo = JsonHelper.JsonConvertObject<ReInfo<SampleInfo>>(jm);
                    if (jm.code == 0)
                    {
                        GCInfo.DataSource = null;
                        BTserial_ItemClick(null, null);
                    }
                    else
                    {
                        MessageBox.Show("审核失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("未能获取到医院编号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
    }
}
