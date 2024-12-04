using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.FinanceModel;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.SqlModel;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Finance.ClientFundInfo
{
    public partial class FrmFundInfo : XtraForm
    {
        string FinanceCheckSelect = "";
        string FinanceFundHandle = "";
        DataRow CheckInfoDataRow = null;
        decimal BillCharge = 0;
        public FrmFundInfo()
        {
            InitializeComponent();
            DEStartTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            DEEndTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
        }

        private void FrmFundInfo_Load(object sender, EventArgs e)
        {
            FinanceCheckSelect = ConfigInfos.ReadConfigInfo("FinanceCheckSelect");
            FinanceFundHandle = ConfigInfos.ReadConfigInfo("FinanceFundHandle");
            GridLookUpEdites.Formats(RGEClientNO);
            RGEClientNO.DataSource = DTHelper.DTAddAll(WorkCommData.DTClientInfo);
            GridLookUpEdites.Formats(RGEcclientNO, WorkCommData.DTClientInfo);

            GridControls.formartGridView(GVCheckInfo);
            GridControls.showEmbeddedNavigator(GCCheckInfo);
            GridControls.formartGridView(GVFundInfo);
            GridControls.showEmbeddedNavigator(GCFundInfo);


            //RGEcclientNO.DataSource =WorkCommData.DTClientInfo;
            GEClientNO.EditValue = "0";
        }

        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            BTSelect.Enabled = false;
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "查询信息请稍后......");


            commInfoModel<SelectFinanceCheckModel> commInfo = new commInfoModel<SelectFinanceCheckModel>();
            List<SelectFinanceCheckModel> selectFinanceChecks = new List<SelectFinanceCheckModel>();
            SelectFinanceCheckModel selectFinanceCheck = new SelectFinanceCheckModel();
            selectFinanceCheck.checkNo = TECheckNO.EditValue != null ? TECheckNO.EditValue.ToString() : "";
            selectFinanceCheck.operatTimeStart = DEStartTime.EditValue.ToString();
            selectFinanceCheck.operatTimeEnd = DEEndTime.EditValue.ToString();
            selectFinanceChecks.Add(selectFinanceCheck);
            commInfo.infos = selectFinanceChecks;
            string sr = JsonHelper.SerializeObjct(commInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(FinanceCheckSelect, sr);
            DataTable dataTable = JsonHelper.StringToDT(jm);
            GCCheckInfo.DataSource = dataTable;
            GVCheckInfo.BestFitColumns();
            BTSelect.Enabled = true;
            frmWait.HideMe(this);
        }

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVCheckInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                FrmFundEdit frmFundEdit = new FrmFundEdit(dataRow);
                Func<decimal> func = frmFundEdit.reCharge;
                frmFundEdit.ShowDialog();
                decimal oldCharge = dataRow["remain"] != DBNull.Value ? Convert.ToDecimal(dataRow["remain"]) : 0;
                decimal NewCharge = oldCharge - func();
                GVCheckInfo.SetFocusedRowCellValue("remain", NewCharge);
            }
            else
            {
                MessageBox.Show("请选择需要编辑的账单信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            GVCheckInfo_RowClick(null, null);
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVFundInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                //decimal oldCharge = dataRow["fundCharge"] != DBNull.Value ? Convert.ToDecimal(dataRow["fundCharge"]) : 0;
                FrmFundEdit frmFundEdit = new FrmFundEdit(dataRow, 2);
                Func<decimal> func = frmFundEdit.reCharge;
                frmFundEdit.ShowDialog();
                //decimal NewCharge = 0;
                decimal reCharge =func();
                if (reCharge>=0)
                {
                    CheckInfoDataRow["remain"] = BillCharge + reCharge;
                }
                else
                {
                    reCharge = Math.Abs(reCharge);
                    CheckInfoDataRow["remain"] = BillCharge - reCharge;
                }
                
            }
            else
            {
                MessageBox.Show("请选择需要编辑的回款记录信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            GVCheckInfo_RowClick(null, null);

        }

        private void BTDelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVFundInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                commInfoModel<FundInfoModel> commInfo = new commInfoModel<FundInfoModel>();
                commInfo.UserName = CommonData.UserInfo.names;
                
                List<FundInfoModel> fundInfos = new List<FundInfoModel>();
                FundInfoModel fundInfo = new FundInfoModel();
                fundInfo.fundState = 1;
                fundInfo.no = dataRow["no"] != DBNull.Value ? Convert.ToInt32(dataRow["no"]) : 0;
                fundInfo.id = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                if (fundInfo.no != 0 && fundInfo.id != 0)
                {
                    fundInfo.fundState = 3;
                    DialogResult dialogResult = MessageBox.Show("确定要删除选中记录？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult.Yes == dialogResult)
                    {


                        fundInfos.Add(fundInfo);
                        commInfo.infos = fundInfos;
                        string sr = JsonHelper.SerializeObjct(commInfo);
                        WebApiCallBack jm = ApiHelpers.postInfo(FinanceFundHandle, sr);
                        commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                        if (commReInfo.code == 0)
                        {
                            MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("请求数据信息有误。", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的记录信息。", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        private void GVCheckInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CheckInfoDataRow = GVCheckInfo.GetFocusedDataRow();
            if (CheckInfoDataRow != null)
            {
                BillCharge = CheckInfoDataRow["remain"] != DBNull.Value ? Convert.ToDecimal(CheckInfoDataRow["remain"]) : 0;
                int checkId = CheckInfoDataRow["id"] != DBNull.Value ? Convert.ToInt32(CheckInfoDataRow["id"]) : 0;
                sInfo sInfo = new sInfo();
                sInfo.TableName = "Finance.FundInfo";
                sInfo.wheres = $"no='{checkId}' and dstate=0";
                GCFundInfo.DataSource = ApiHelpers.postInfo(sInfo);

            }
            else
            {
                GCFundInfo.DataSource = null;
            }
            GVFundInfo.BestFitColumns();
        }

        private void GVCheckInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow dataRow = GVCheckInfo.GetDataRow(e.RowHandle);
            if (dataRow != null)
            {
                decimal priceCount = dataRow["priceCount"] != DBNull.Value ? Convert.ToDecimal(dataRow["priceCount"]) : 0;
                decimal remain = dataRow["remain"] != DBNull.Value ? Convert.ToDecimal(dataRow["remain"]) : 0;
                if (priceCount == 0 && remain == 0)
                {
                    e.Appearance.BackColor = System.Drawing.Color.YellowGreen; ;//改变背景色//改变背景色
                }
                else
                {
                    if (remain == 0)
                        e.Appearance.BackColor = System.Drawing.Color.SpringGreen; ;//改变背景色//改变背景色
                }

            }






            //if (GVCheckInfo.GetRowCellValue(e.RowHandle, "urgent") != DBNull.Value)
            //{
            //    if (Convert.ToBoolean(GVCheckInfo.GetRowCellValue(e.RowHandle, "urgent")))
            //    {
            //        //e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;//改变背景色
            //        //e.Appearance.BackColor = Color.Transparent;//改变背景色
            //        //e.Appearance.BackColor = Color.Aquamarine;//改变背景色
            //        e.Appearance.ForeColor = System.Drawing.Color.Red;//改变字体颜色
            //    }
            //}
            //if (GVSampleInfo.GetRowCellValue(e.RowHandle, "state") != DBNull.Value)
            //{
            //    if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "state")))
            //    {
            //        e.Appearance.BackColor = System.Drawing.Color.SpringGreen; ;//改变背景色
            //        //e.Appearance.ForeColor = Color.Red;//改变字体颜色
            //    }
            //}
        }

        private void GVFundInfo_DoubleClick(object sender, EventArgs e)
        {
            BTEdit_ItemClick(null, null);
        }
    }
}
