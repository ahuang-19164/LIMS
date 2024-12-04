using Common.BLL;
using Common.Data;
using Common.SqlHandle;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace workOther.ItemChange
{
    public partial class FrmCancel : XtraForm
    {
        public FrmCancel()
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
                    GCcheckInfo.DataSource = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
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
                            GCcheckInfo.DataSource = WorkCommData.DTItemApply.Select($"no in ({dataTable.Rows[0]["applyItemCodes"]})").CopyToDataTable();
                        }
                    }
                }
            }
        }
        //DataTable FrmDT;

        //private void BTAdd_Click(object sender, EventArgs e)
        //{
        //    FrmShowGroup frmShowGroup = new FrmShowGroup(ApplyList);

        //    Func<DataRow> Func = frmShowGroup.ReturnResult;
        //    frmShowGroup.ShowDialog();
        //    if (Func() != null)
        //    {
        //        DataRow dataRow = FrmDT.NewRow();
        //        dataRow.ItemArray = Func().ItemArray;
        //        FrmDT.Rows.Add(dataRow);
        //        GVcheckInfo.BestFitColumns();
        //    }

        //}

        //private void BTCancel_Click(object sender, EventArgs e)
        //{
        //    GVcheckInfo.DeleteSelectedRows();
        //}
    }
}
