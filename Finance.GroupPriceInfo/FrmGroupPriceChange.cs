using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.WorkModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Finance.GroupPriceInfo
{
    public partial class FrmGroupPriceChange : DevExpress.XtraEditors.XtraForm
    {
        string FinancePriceChange = "";
        public FrmGroupPriceChange()
        {
            FinancePriceChange = ConfigInfos.ReadConfigInfo("FinancePriceChange");
            InitializeComponent();


            SysPowerHelper.UserPower(barManager1);



            GridControls.formartGridView(GVInfo);

            GridControls.showEmbeddedNavigator(GCInfo);
            GridControls.ShowViewColor(GVInfo);
            GridLookUpEdites.Formats(RGEchargeLevelNO);
            GridLookUpEdites.Formats(RGEchargeTypeNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEpersonNO);
            GridLookUpEdites.Formats(RGEtabTypeNO);
            TextEdits.TextFormatDecimal(TTEItemPrice);
        }
        private void FrmGroupPriceChange_Load(object sender, EventArgs e)
        {
            RGEchargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEchargeTypeNO.DataSource = FinanceInfoData.DTChargeType;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEpersonNO.DataSource = CommonData.DTUserInfoAll;
            RGEtabTypeNO.DataSource = FinanceInfoData.DTTabType;
        }

        private void BTselectInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFinanceSelect financeSelect = new FrmFinanceSelect();
            Func<DataTable> func = financeSelect.ReturnSelectInfo;
            financeSelect.ShowDialog();
            DataTable dataTable = func();
            if (dataTable != null)
            {
                dataTable.Columns.Add("check", typeof(bool));
                GCInfo.DataSource = dataTable;
                GVInfo.BestFitColumns();
            }
        }

        private void CEcheckAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEcheckAll.Checked)
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

        private void BTchangePrice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVInfo.FocusedRowHandle = -1;
            if (TEItemPrice.EditValue != null)
            {
                if (TEItemPrice.EditValue.ToString().Trim().Length > 0)
                {
                    try
                    {
                        decimal ItemPrice = Convert.ToDecimal(TEItemPrice.EditValue);
                        for (int a = 0; a < GVInfo.RowCount; a++)
                        {
                            if (GVInfo.GetRowCellValue(a, "check") != DBNull.Value)
                            {
                                if (Convert.ToBoolean(GVInfo.GetRowCellValue(a, "check")))
                                {
                                    GVInfo.SetRowCellValue(a, "charge", ItemPrice);
                                    //GVInfo.SetRowCellValue(a, "hospitalBarcode", ItemPrice);
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("输入价格格式错误", "系统提示");
                    }

                }
            }
        }

        private void BTenterprice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            commInfoModel<priceChangeModel> commModel = new commInfoModel<priceChangeModel>();
            List<priceChangeModel> infos = new List<priceChangeModel>();
            for (int a = 0; a < GVInfo.RowCount; a++)
            {
                if (GVInfo.GetRowCellValue(a, "check") != DBNull.Value)
                {
                    if (Convert.ToBoolean(GVInfo.GetRowCellValue(a, "check")))
                    {
                        if (GVInfo.GetRowCellValue(a, "financeID") != DBNull.Value && GVInfo.GetRowCellValue(a, "charge") != DBNull.Value && GVInfo.GetRowCellValue(a, "charge").ToString().Trim().Length > 0)
                        {
                            priceChangeModel priceChange = new priceChangeModel();
                            priceChange.financeID = GVInfo.GetRowCellValue(a, "financeID").ToString();
                            priceChange.charge = GVInfo.GetRowCellValue(a, "charge").ToString();
                            infos.Add(priceChange);
                            GVInfo.SetRowCellValue(a, "chargeTypeNO", 8);
                        }
                        //GVInfo.SetRowCellValue(a, "hospitalBarcode", ItemPrice);
                    }
                }
            }
            commModel.infos = infos;
            string Sr = JsonHelper.SerializeObjct(commModel);
            WebApiCallBack jm = ApiHelpers.postInfo(FinancePriceChange, Sr);
            //returnMode<returnSampleState> commReInfo = JsonHelper.JsonConvertObject<returnMode<returnSampleState>>(jm);
            if (jm.code == 0)
            {
                MessageBox.Show(jm.msg, "系统提示");
            }
        }
    }
}
