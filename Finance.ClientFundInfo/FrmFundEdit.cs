using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.FinanceModel;
using Common.JsonHelper;
using Common.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Finance.ClientFundInfo
{
    public partial class FrmFundEdit : XtraForm
    {
        /// <summary>
        /// 0为新增状态，1为编辑状态
        /// </summary>
        int FrmState = 0;
        int infoID = 0;
        string FinanceFundHandle = "";
        decimal oldCharge = 0;
        decimal fundCharge = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DRInfo"></param>
        /// <param name="state">0为新增，1为编辑</param>
        public FrmFundEdit(DataRow DRInfo, int state = 0)
        {
            FinanceFundHandle = ConfigInfos.ReadConfigInfo("FinanceFundHandle");
            InitializeComponent();
            if (DRInfo != null)
            {
                if (state == 0)
                {
                    FrmState = 0;



                    TEno.EditValue = DRInfo["id"];
                    TEcheckNO.EditValue = DRInfo["checkNo"];
                    GEclientNO.EditValue = DRInfo["clientNO"];
                    DEcheckTime.EditValue = Convert.ToDateTime(DRInfo["operatTime"]);
                    //DEfundTime.EditValue = Convert.ToDateTime(DRInfo["fundTime"]);
                    //TEfundCharge.EditValue = DRInfo["fundCharge"];
                    //GEbillNO.EditValue = DRInfo["billNO"];
                    //GEperson.EditValue = DRInfo["person"];
                    //TEremark.EditValue = DRInfo["remark"];
                }
                else
                {
                    //TEcheckNO.EditValue = DRInfo["checkNO"];
                    FrmState = 1;
                    infoID = DRInfo["id"] != DBNull.Value ? Convert.ToInt32(DRInfo["id"]) : 0;
                    TEno.EditValue = DRInfo["no"];
                    TEcheckNO.EditValue = DRInfo["billNO"];
                    GEclientNO.EditValue = DRInfo["clientNO"];
                    DEcheckTime.EditValue = Convert.ToDateTime(DRInfo["checkTime"]);
                    DEfundTime.EditValue = Convert.ToDateTime(DRInfo["fundTime"]);
                    TEfundCharge.EditValue = oldCharge = DRInfo["fundCharge"] != DBNull.Value ? Convert.ToDecimal(DRInfo["fundCharge"]) : 0;
                    //GEperson.Text = DRInfo["person"]!=DBNull.Value? DRInfo["person"].ToString():"";

                    string personName = DRInfo["person"] != DBNull.Value ? DRInfo["person"].ToString() : "";

                    GEperson.EditValue = CommonData.DTUserInfoAll.Select($"names='{personName}'")[0]["no"];


                    TEremark.EditValue = DRInfo["remark"];
                }
            }
        }

        private void FrmFundEdit_Load(object sender, EventArgs e)
        {
            TextEdits.TextFormatDecimal(TEfundCharge);
            DEfundTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GridLookUpEdites.Formats(GEclientNO, WorkCommData.DTClientInfo);
            GridLookUpEdites.Formats(GEperson, CommonData.DTUserInfoAll);
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            if (TEcheckNO.EditValue != null && TEcheckNO.EditValue.ToString() != "")
            {
                if (FrmState == 0)
                {
                    //commInfoModel<FundInfoModel> commInfo = new commInfoModel<FundInfoModel>();
                    commInfoModel<FundInfoModel> commInfo = new commInfoModel<FundInfoModel>();
                    commInfo.UserName = CommonData.UserInfo.names;
                    
                    List<FundInfoModel> fundInfos = new List<FundInfoModel>();
                    //List<FundInfoModel> fundInfos = new List<FundInfoModel>();
                    FundInfoModel fundInfo = new FundInfoModel();
                    fundInfo.fundState = 1;
                    fundInfo.no = TEno.EditValue != null ? Convert.ToInt32(TEno.EditValue) : 0;
                    if (fundInfo.no != 0)
                    {
                        fundInfo.billNo = TEcheckNO.EditValue != null ? TEcheckNO.EditValue.ToString() : "";
                        fundInfo.clientNO = GEclientNO.EditValue != null ? GEclientNO.EditValue.ToString() : "";
                        fundInfo.checkTime = DEcheckTime.EditValue != null ? Convert.ToDateTime(DEcheckTime.EditValue) : DateTime.MinValue;
                        fundInfo.fundCharge = TEfundCharge.EditValue != null && TEfundCharge.EditValue.ToString() != "" ? Convert.ToDecimal(TEfundCharge.EditValue) : 0;
                        fundInfo.person = GEperson.Text != null ? GEperson.Text.ToString() : "";
                        fundInfo.fundTime = DEfundTime.EditValue != null ? Convert.ToDateTime(DEfundTime.EditValue) : DateTime.MinValue;
                        fundInfo.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                        fundInfos.Add(fundInfo);
                        commInfo.infos = fundInfos;
                        string sr = JsonHelper.SerializeObjct(commInfo);
                        WebApiCallBack jm = ApiHelpers.postInfo(FinanceFundHandle, sr);
                        //commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                        if (jm.code == 0)
                        {
                            fundCharge = TEfundCharge.EditValue != null ? Convert.ToDecimal(TEfundCharge.EditValue) : 0;
                            //MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Close();
                    }

                }
                else
                {
                    commInfoModel<FundInfoModel> commInfo = new commInfoModel<FundInfoModel>();
                    commInfo.UserName = CommonData.UserInfo.names;
                    
                    List<FundInfoModel> fundInfos = new List<FundInfoModel>();
                    FundInfoModel fundInfo = new FundInfoModel();
                    fundInfo.fundState = 2;
                    fundInfo.no = TEno.EditValue != null ? Convert.ToInt32(TEno.EditValue) : 0;
                    if (fundInfo.no != 0 && infoID != 0)
                    {
                        fundInfo.id = infoID;
                        //fundInfo.billNo = TEcheckNO.EditValue != null ? TEno.EditValue.ToString() : "";
                        //fundInfo.clientNO = GEclientNO.EditValue != null ? GEclientNO.EditValue.ToString() : "";
                        //fundInfo.checkTime = DEcheckTime.EditValue != null ? DEcheckTime.EditValue.ToString() : "";
                        fundInfo.fundCharge = TEfundCharge.EditValue != null && TEfundCharge.EditValue.ToString() != "" ? Convert.ToDecimal(TEfundCharge.EditValue) : 0;
                        fundInfo.person = GEperson.Text != null ? GEperson.Text.ToString() : "";
                        fundInfo.fundTime = DEfundTime.EditValue != null ? Convert.ToDateTime(DEfundTime.EditValue) : DateTime.MinValue;
                        fundInfo.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                        fundInfos.Add(fundInfo);
                        commInfo.infos = fundInfos;
                        string sr = JsonHelper.SerializeObjct(commInfo);
                        WebApiCallBack jm = ApiHelpers.postInfo(FinanceFundHandle, sr);
                        decimal recharg = jm.data != null ? Convert.ToDecimal(jm.data) : 0;
                        fundCharge = recharg;

                        //commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                        //if (commReInfo.code == 0)
                        //{
                        //    MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("请检查信息是否正确。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                MessageBox.Show("未获取到审核单号，请检查信息是否正确。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public decimal reCharge()
        {
            return fundCharge;
        }


    }
}
