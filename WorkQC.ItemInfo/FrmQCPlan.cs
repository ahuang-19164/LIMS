using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCPlan : DevExpress.XtraEditors.XtraForm
    {
        string TableName = "QC.QCPlan";
        DataTable FrmDT = null;
        DataRow DataRow = null;
        DataTable DTQCGrade = null;
        DataTable DTBatch = null;
        public FrmQCPlan()
        {
            InitializeComponent();
            GridControls.formartGridView(GVPlanInfo);
            GridControls.showEmbeddedNavigator(GCPlanInfo);
            GridControls.formartGridView(GVItem);
            GridControls.showEmbeddedNavigator(GCItem);

            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEworkNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEruleNO);
            GridLookUpEdites.Formats(RGElevelNO);
            GridLookUpEdites.Formats(RGEresultTypeNO);

            TextEdits.TextFormat(RTEItemSort);
            TextEdits.TextFormat(RGEgradesort);

            RGEresultTypeNO.DataSource = WorkCommData.DTTypeResult;
            RGEworkNO.DataSource = WorkCommData.DTGroupWork;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEruleNO.DataSource = QCInfoData.DTRuleGroup;
            RGElevelNO.DataSource = QCInfoData.DTQCLevel;

        }

        private void FrmItemQCInfo_Load(object sender, EventArgs e)
        {

            sInfo sInfo = new sInfo();
            sInfo.TableName = TableName;
            FrmDT = ApiHelpers.postInfo(sInfo);
            GCPlanInfo.DataSource = DTHelper.DTVisible(FrmDT);
            GVPlanInfo.BestFitColumns();


            sInfo QCGrade = new sInfo();
            QCGrade.TableName = "QC.QCGrade";
            DTQCGrade = ApiHelpers.postInfo(QCGrade);



            sInfo QCBatch = new sInfo();
            QCBatch.TableName = "QC.QCBatch";
            DTBatch = ApiHelpers.postInfo(QCBatch);
        }
        DataTable DTItem;

        private void GVPlanInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow = GVPlanInfo.GetFocusedDataRow();
            if (DataRow != null)
            {
                string planid = DataRow["id"] != DBNull.Value ? DataRow["id"].ToString() : "";
                if (planid != "")
                {
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "QC.QCPlanItem";
                    sInfo.wheres = $"planid='{planid}' and dstate=0";
                    sInfo.OrderColumns = "sort";
                    GCItem.DataSource = DTItem = ApiHelpers.postInfo(sInfo);
                    GVItem.BestFitColumns();
                }
                else
                {
                    DTItem = null;

                }
            }
            else
            {
                DTItem = null;
            }
            GCGrade.DataSource = null;
        }






        #region   质控计划导航栏方法
        private void BTPlanAdd_Click(object sender, EventArgs e)
        {
            int no = 0;
            if (FrmDT == null)
            {
                no = 1;
            }
            else
            {
                no = Convert.ToInt32(FrmDT.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            FrmPlanInfo frmPlanInfo = new FrmPlanInfo(no, null);
            frmPlanInfo.ShowDialog();
            FrmItemQCInfo_Load(null, null);
        }

        private void BTPlanEdit_Click(object sender, EventArgs e)
        {

            if (DataRow != null)
            {
                FrmPlanInfo frmPlanInfo = new FrmPlanInfo(0, DataRow);
                frmPlanInfo.ShowDialog();
                FrmItemQCInfo_Load(null, null);
            }
            else
            {
                MessageBox.Show("没有可编辑信息", "系统提示");
            }
        }

        private void BTPlanDelete_Click(object sender, EventArgs e)
        {
            hideInfo hideInfo = new hideInfo();
            hideInfo.TableName = TableName;
            hideInfo.DataValueID = Convert.ToInt32(DataRow["id"]);
            int a = ApiHelpers.postInfo(hideInfo);
            if (a == 1)
            {
                GVPlanInfo.DeleteSelectedRows();
            }
        }




        #endregion




        #region 质控项目导航栏方法
        private void BTAddItem_Click(object sender, EventArgs e)
        {
            DataRow dataRow = GVPlanInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                string planid = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                string instrumentNO = dataRow["instrumentNO"] != DBNull.Value ? dataRow["instrumentNO"].ToString() : "";
                string groupNO = dataRow["groupNO"] != DBNull.Value ? dataRow["groupNO"].ToString() : "";
                FrmItemInfo frmgradeShow = new FrmItemInfo(planid, groupNO, instrumentNO);
                Func<DataTable> func = frmgradeShow.ReturnCheckInfo;
                frmgradeShow.ShowDialog();
                DataTable reDT = func();
                if (reDT.Rows.Count > 0)
                {
                    if (DTItem == null)
                        DTItem = reDT.Clone();
                    foreach (DataRow row in reDT.Rows)
                    {
                        DataRow newdata = DTItem.NewRow();
                        newdata.ItemArray = row.ItemArray;
                        DTItem.Rows.InsertAt(newdata, 0);
                        DTItem.AcceptChanges();
                        //DTItem.Rows.Add(row);
                    }

                }
                GCItem.DataSource = DTItem;
            }

        }
        private void BTDeleteItem_Click(object sender, EventArgs e)
        {
            if (GVItem.GetFocusedDataRow() != null)
            {
                DataRow row = GVItem.GetFocusedDataRow();
                DialogResult dialogResult = MessageBox.Show("是否确定删除计划中的项目", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (row["id"] != DBNull.Value)
                    {
                        dInfo dInfo = new dInfo();
                        dInfo.TableName = "QC.QCPlanItem";
                        dInfo.DataValueID = Convert.ToInt32(row["id"]);
                        ApiHelpers.postInfo(dInfo);
                    }
                    GVItem.DeleteSelectedRows();
                }
            }

        }



        #endregion

        private void BTSaveItem_Click(object sender, EventArgs e)
        {
            GVItem.FocusedRowHandle = -1;
            if (GVItem.RowCount > 0)
            {
                DataTable dataTable = GCItem.DataSource as DataTable;
                ApiHelpers.postInfo(dataTable, "QC.QCPlanItem");
                GVPlanInfo_RowClick(null, null);
            }
        }
        DataTable DTGrade;
        private void GVItem_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (GVItem.GetFocusedDataRow() != null)
            {
                DataRow row = GVItem.GetFocusedDataRow();
                string PlanItemID = row["id"] != DBNull.Value ? row["id"].ToString() : "";
                if (PlanItemID != "")
                {
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "QC.QCPlanGrade";
                    sInfo.wheres = $"planItemid='{PlanItemID}' and dstate=0";
                    sInfo.OrderColumns = "sort";
                    GCGrade.DataSource = DTGrade = ApiHelpers.postInfo(sInfo);
                    GVGrade.BestFitColumns();
                }
                else
                {
                    DTGrade = null;
                    GCGrade.DataSource = null;
                }
            }
            else
            {
                DTGrade = null;
                GCGrade.DataSource = null;
            }
        }

        private void BTAddGrade_Click(object sender, EventArgs e)
        {
            if (GVItem.GetFocusedDataRow() != null)
            {
                DataRow dataRow = GVItem.GetFocusedDataRow();
                string planItemid = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                string itemNO = dataRow["itemNO"] != DBNull.Value ? dataRow["itemNO"].ToString() : "";
                if (itemNO == "")
                {
                    MessageBox.Show("请先保存计划中新增项目", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    FrmgradeShow frmgradeShow = new FrmgradeShow(planItemid, itemNO);
                    Func<DataTable> func = frmgradeShow.ReturnCheckInfo;
                    frmgradeShow.ShowDialog();
                    DataTable reDT = func();
                    if (reDT.Rows.Count > 0)
                    {
                        if (DTGrade == null)
                            DTGrade = reDT.Clone();
                        foreach (DataRow row in reDT.Rows)
                        {
                            DataRow newdata = DTGrade.NewRow();
                            newdata.ItemArray = row.ItemArray;
                            DTGrade.Rows.InsertAt(newdata, 0);
                            DTGrade.AcceptChanges();
                            //DTItem.Rows.Add(row);
                        }

                    }
                    GCGrade.DataSource = DTGrade;
                }
            }
        }

        private void BTDeleteGrade_Click(object sender, EventArgs e)
        {
            if (GVGrade.GetFocusedDataRow() != null)
            {
                DataRow row = GVGrade.GetFocusedDataRow();
                DialogResult dialogResult = MessageBox.Show("是否确定删除该质控品信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string infoID = row["id"] != DBNull.Value ? row["id"].ToString() : "";
                    if (infoID != "")
                    {
                        dInfo dInfo = new dInfo();
                        dInfo.TableName = "QC.QCPlanGrade";
                        dInfo.DataValueID = Convert.ToInt32(infoID);
                        ApiHelpers.postInfo(dInfo);
                    }
                    GVGrade.DeleteSelectedRows();
                }
            }

        }

        private void BTSaveGrade_Click(object sender, EventArgs e)
        {
            GVGrade.FocusedRowHandle = -1;
            if (GVGrade.RowCount > 0)
            {
                DataTable dataTable = GCGrade.DataSource as DataTable;
                ApiHelpers.postInfo(dataTable, "QC.QCPlanGrade");
                GVItem_RowClick(null, null);
            }
        }
    }
}
