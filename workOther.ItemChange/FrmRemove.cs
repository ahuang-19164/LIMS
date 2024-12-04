using Common.BLL;
using Common.Data;
using Common.SqlHandle;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;

namespace workOther.ItemChange
{
    public partial class FrmRemove : XtraForm
    {
        public FrmRemove()
        {
            InitializeComponent();
        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string ApplyList = "";
        private void BTSelect_Click(object sender, EventArgs e)
        {

            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkPer.SampleInfo";
            if (TEbarcode.EditValue != null)
            {
                selectInfo.wheres = $"barcode='{TEbarcode.EditValue}' and dstate=0";
                DataTable dataTable = SqlConnServer.postselects(selectInfo);
                TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                //TEapplyItemCodes.EditValue = dataTable.Rows[0]["applyItemCodes"];
                //TEapplyItemNames.EditValue = dataTable.Rows[0]["applyItemNames"];
                TEbarcode.EditValue = dataTable.Rows[0]["barcode"];
                TEhosBarcode.EditValue = dataTable.Rows[0]["hospitalBarcode"];
                TEclientName.EditValue = dataTable.Rows[0]["clinicalDiagnosis"];
                TEclientNO.EditValue = dataTable.Rows[0]["hospitalNames"];
                TEpatientSexName.EditValue = dataTable.Rows[0]["patientSexNames"];
                TEpatientAge.EditValue = dataTable.Rows[0]["ageYear"];
                if (WorkCommData.DTItemApply != null)
                {
                    GCapplyInfo.DataSource = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
                }
            }
            else
            {
                if (TEhosBarcode.EditValue != null)
                {
                    selectInfo.wheres = $"hospitalBarcode='{TEbarcode.EditValue}' and dstate=0";
                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                    TEpatientName.EditValue = dataTable.Rows[0]["patientName"];
                    //TEapplyItemCodes.EditValue = dataTable.Rows[0]["applyItemCodes"];
                    //TEapplyItemNames.EditValue = dataTable.Rows[0]["applyItemNames"];
                    TEbarcode.EditValue = dataTable.Rows[0]["barcode"];
                    TEhosBarcode.EditValue = dataTable.Rows[0]["hospitalBarcode"];
                    TEclientName.EditValue = dataTable.Rows[0]["clinicalDiagnosis"];
                    TEclientNO.EditValue = dataTable.Rows[0]["hospitalNames"];
                    TEpatientSexName.EditValue = dataTable.Rows[0]["patientSexNames"];
                    TEpatientAge.EditValue = dataTable.Rows[0]["ageYear"];
                    if (WorkCommData.DTItemApply != null)
                    {
                        if (dataTable.Rows[0]["applyItemCodes"] != DBNull.Value)
                        {
                            ApplyList = dataTable.Rows[0]["applyItemCodes"].ToString();
                            GCapplyInfo.DataSource = DTcheckInfo = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
                        }
                    }
                }
            }
        }
        DataTable DTcheckInfo;

        /// <summary>
        /// 双击选择项目事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVapplyInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVapplyInfo.GetFocusedDataRow() != null)
            {
                if (DTcheckInfo.Select($"no='{GVapplyInfo.GetFocusedDataRow()["no"].ToString()}'").Count() == 0)
                {
                    DataRow newdata = DTcheckInfo.NewRow();
                    newdata.ItemArray = GVapplyInfo.GetFocusedDataRow().ItemArray;
                    DTcheckInfo.Rows.InsertAt(newdata, 0);
                    DTcheckInfo.AcceptChanges();

                }
                GVapplyInfo.OptionsFind.AlwaysVisible = false;
                //GVapplyInfo.ShowFindPanel();
                GVapplyInfo.OptionsFind.AlwaysVisible = true;
            }
        }

        private void GVcheckInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVapplyInfo.GetFocusedDataRow() != null)
            {
                DataRow row = GVapplyInfo.GetFocusedDataRow();
                DTcheckInfo.Rows.Remove(GVapplyInfo.GetFocusedDataRow());
                //GVcheckInfo.DeleteRow(GVcheckInfo.FocusedRowHandle);
            }

        }

    }
}
