using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.QCModel;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;

using QC.QCHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCResult : XtraForm
    {
        string QCReultSelect = "";
        public FrmQCResult()
        {
            QCReultSelect = ConfigInfos.ReadConfigInfo("QCReultSelect");
            InitializeComponent();
            DEStartTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            DEEndTime.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
        }

        private void FrmQCResult_Load(object sender, EventArgs e)
        {
            GridLookUpEdites.Formats(RGEPlanGroupNO, WorkCommData.DTGroupTest);
            GridLookUpEdites.Formats(RGEPlanWorkNO, WorkCommData.DTGroupWork);
            GridLookUpEdites.Formats(RGEgradelevelNO, QCInfoData.DTQCLevel);
            GridLookUpEdites.Formats(RGEinstrumentNO, WorkCommData.DTInstrumentInfo);
            GridLookUpEdites.Formats(RGEruleNO, QCInfoData.DTRuleGroup);


            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.PlanItemView";
            GCPlanItemInfo.DataSource = ApiHelpers.postInfo(sInfo);
            GVPlanItemInfo.BestFitColumns();
        }
        private void BTRef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVPlanItemInfo_RowClick(null, null);
        }
        private void BTAddQCResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVPlanItemInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                string planID = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                string planItemID = dataRow["planItemid"] != DBNull.Value ? dataRow["planItemid"].ToString() : "";
                string itemNO = dataRow["itemNO"] != DBNull.Value ? dataRow["itemNO"].ToString() : "";
                if (planID != "" && planItemID != "" && itemNO != "")
                {
                    FrmAddResult frmAddResult = new FrmAddResult(planID, planItemID, itemNO);
                    frmAddResult.ShowDialog();
                }
                else
                {
                    MessageBox.Show("选择信息有误", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("请选择项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BTEditQCResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

                if (bandedGridView != null)
                {
                    DataRow dataRow = bandedGridView.GetFocusedDataRow();
                    if (dataRow != null)
                    {
                        string qcTime = dataRow["qcTime"] != DBNull.Value ? dataRow["qcTime"].ToString() : "";
                        string itemResultsort = dataRow["itemResultsort"] != DBNull.Value ? dataRow["itemResultsort"].ToString() : "";
                        if (itemNO != "" && qcTime != "" && itemResultsort != "")
                        {

                            FrmEditResults frmEditResult = new FrmEditResults(itemNO, qcTime, itemResultsort);
                            frmEditResult.ShowDialog();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        }

        private void BTDelQCResult_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

                if (bandedGridView != null)
                {
                    DataRow dataRow = bandedGridView.GetFocusedDataRow();
                    if (dataRow != null)
                    {
                        string qcTime = dataRow["qcTime"] != DBNull.Value ? dataRow["qcTime"].ToString() : "";
                        string itemResultsort = dataRow["itemResultsort"] != DBNull.Value ? dataRow["itemResultsort"].ToString() : "";
                        if (itemNO != "" && qcTime != "" && itemResultsort != "")
                        {

                            FrmDeleteResult frmEditResult = new FrmDeleteResult(itemNO, qcTime, itemResultsort);
                            frmEditResult.ShowDialog();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        }
        GridControl gridControl;
        BandedGridView bandedGridView;


        string itemNO = "";
        string itemName = "";
        string planid = "";
        string planItemid = "";
#pragma warning disable CS0414 // 字段“FrmQCResult.plangradeids”已被赋值，但从未使用过它的值
        string plangradeids = "";
#pragma warning restore CS0414 // 字段“FrmQCResult.plangradeids”已被赋值，但从未使用过它的值

        DataSet DSQCInfo;
        private void GVPlanItemInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {







            DataRow dataRow = GVPlanItemInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                planid = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                planItemid = dataRow["planItemid"] != DBNull.Value ? dataRow["planItemid"].ToString() : "";
                itemNO = dataRow["itemNO"] != DBNull.Value ? dataRow["itemNO"].ToString() : "";
                itemName = dataRow["itemName"] != DBNull.Value ? dataRow["itemName"].ToString() : "";
                if (planid != "" && itemNO != "")
                {
                    panelControl1.Controls.Clear();
                    gridControl = new GridControl();
                    GridControls.showEmbeddedNavigator(gridControl);
                    gridControl.Name = "GCQCResult";

                    commInfoModel<QCSelectValueModel> infos = new commInfoModel<QCSelectValueModel>();
                    infos.UserName = CommonData.UserInfo.names;
                    List<QCSelectValueModel> listinfos = new List<QCSelectValueModel>();

                    QCSelectValueModel selValue = new QCSelectValueModel();
                    selValue.planid = planid;
                    selValue.planItemid = planItemid;
                    selValue.itemNO = itemNO;
                    selValue.startTime = DEStartTime.EditValue.ToString(); ;
                    selValue.endTime = DEEndTime.EditValue.ToString();
                    listinfos.Add(selValue);
                    infos.infos = listinfos;
                    string Sr = JsonHelper.SerializeObjct(infos);
                    WebApiCallBack jm = ApiHelpers.postInfo(QCReultSelect, Sr);
                    DSQCInfo = JsonHelper.JsonConvertObject<DataSet>(jm); ;

                    if (DSQCInfo.Tables.Count == 3)
                    {
                        bandedGridView = new BandedGridView();
                        bandedGridView = QCItemResult.createQCResultInfoDT(DSQCInfo.Tables[0], out DataTable DTResult);
                        GCInfo.DataSource = DSQCInfo.Tables[1];
                        GCHandle.DataSource = DSQCInfo.Tables[2];

                        GVHandle.BestFitColumns();
                        bGVInfo.BestFitColumns();


                        if (DTResult != null)
                        {
                            gridControl.MainView = bandedGridView;
                            gridControl.ViewCollection.Add(bandedGridView);
                            bandedGridView.GridControl = gridControl;
                            panelControl1.Controls.Add(gridControl);
                            gridControl.DataSource = DTResult;
                            gridControl.Dock = DockStyle.Fill;
                            bandedGridView.OptionsView.ColumnAutoWidth = false;
                            bandedGridView.BestFitColumns();
                        }
                        else
                        {
                            panelControl1.Controls.Add(gridControl);
                            gridControl.DataSource = null;
                            gridControl.Dock = DockStyle.Fill;
                        }
                    }
                    else
                    {
                        panelControl1.Controls.Add(gridControl);
                        gridControl.DataSource = null;
                        GCInfo.DataSource = null;
                        gridControl.Dock = DockStyle.Fill;
                    }

                }
                else
                {
                    panelControl1.Controls.Add(gridControl);
                    gridControl.DataSource = null;
                    GCInfo.DataSource = null;
                    gridControl.Dock = DockStyle.Fill;
                }

            }
            else
            {
                panelControl1.Controls.Add(gridControl);
                gridControl.DataSource = null;
                GCInfo.DataSource = null;
                gridControl.Dock = DockStyle.Fill;
            }
        }

        private void GCResult_Click(object sender, EventArgs e)
        {

        }

        private void BTAppraise_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (planid != "" && planItemid != "")
            {

                FrmAppraiseInfos frmEditResult = new FrmAppraiseInfos(planid, planItemid, "", DEStartTime.EditValue, DEEndTime.EditValue);
                frmEditResult.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择评价的质控项目", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BTHandle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

                if (bandedGridView != null)
                {
                    DataRow dataRow = bandedGridView.GetFocusedDataRow();
                    if (dataRow != null)
                    {
                        string qcTime = dataRow["qcTime"] != DBNull.Value ? dataRow["qcTime"].ToString() : "";
                        string itemResultsort = dataRow["itemResultsort"] != DBNull.Value ? dataRow["itemResultsort"].ToString() : "";

                        if (planItemid != "" && qcTime != "" && itemResultsort != "")
                        {

                            FrmQCHandle frmEditResult = new FrmQCHandle(planItemid, qcTime, itemResultsort);
                            frmEditResult.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择项目信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        }

        private void GCInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
