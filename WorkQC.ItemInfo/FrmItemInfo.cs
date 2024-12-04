using Common.ControlHandle;
using Common.Data;
using System;
using System.Data;
using System.Linq;

namespace WorkQC.ItemInfo
{
    public partial class FrmItemInfo : DevExpress.XtraEditors.XtraForm
    {
        string instrumentCode = "";//组套项目列表
        string groupNOs = "";//专业组
        string planids = "";//项目信息列表
        public FrmItemInfo(string planid, string groupNO, string instrumentNO, string ItemCodes = "")
        {
            InitializeComponent();
            instrumentCode = instrumentNO;
            groupNOs = groupNO;
            planids = planid;
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridControls.formartGridView(GVTestInfo);
            GridControls.showEmbeddedNavigator(GCTestInfo);
            aaa();
        }
        DataTable DTinfo = new DataTable();
        private void aaa()
        {

            DataColumn column1 = new DataColumn { ColumnName = "id", DataType = typeof(int) };
            DataColumn column2 = new DataColumn { ColumnName = "planid", DataType = typeof(string) };
            DataColumn column3 = new DataColumn { ColumnName = "itemNO", DataType = typeof(string) };
            DataColumn column4 = new DataColumn { ColumnName = "itemName", DataType = typeof(string) };
            DataColumn column5 = new DataColumn { ColumnName = "unit", DataType = typeof(string) };
            DataColumn column6 = new DataColumn { ColumnName = "resultTypeNO", DataType = typeof(string) };
            DataColumn column7 = new DataColumn { ColumnName = "precision", DataType = typeof(string) };
            DataColumn column8 = new DataColumn { ColumnName = "methodName", DataType = typeof(string) };
            DataColumn column9 = new DataColumn { ColumnName = "adjust", DataType = typeof(string) };
            DataColumn column10 = new DataColumn { ColumnName = "reagent", DataType = typeof(string) };
            DataColumn column11 = new DataColumn { ColumnName = "state", DataType = typeof(bool) };
            DataColumn column12 = new DataColumn { ColumnName = "dstate", DataType = typeof(bool) };
            //DataColumn column13 = new DataColumn{ ColumnName = "planid", DataType=typeof(bool)};

            DTinfo.Columns.AddRange(new DataColumn[] {
            column1,
            column2,
            column3,
            column4,
            column5,
            column6,
            column7,
            column8,
            column9,
            column10,
            column11,
            column12,
            //column13
            });
        }


        private void FrmItemInfo_Load(object sender, EventArgs e)
        {



            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;


            if (WorkCommData.DTItemTest != null)
            {
                if (WorkCommData.DTItemTest.Select($"groupNO='{groupNOs}' and instrumentNO ='{instrumentCode}'").Count() > 0)
                {
                    DataTable DTitem = WorkCommData.DTItemTest.Select($"groupNO='{groupNOs}' and instrumentNO ='{instrumentCode}'").CopyToDataTable();
                    DTitem.TableName = "itemInfo";
                    DTitem.Columns.Add("check", typeof(bool));
                    GCTestInfo.DataSource = DTitem;
                    GVTestInfo.BestFitColumns();
                }
            }

        }
        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVTestInfo.FocusedRowHandle = -1;
            for (int a = 0; a < GVTestInfo.RowCount; a++)
            {
                DataRow dataRow = GVTestInfo.GetDataRow(a);
                if (dataRow["check"] != DBNull.Value && Convert.ToBoolean(dataRow["check"]))
                {

                    DataRow itemDr = DTinfo.NewRow();
                    itemDr["itemNO"] = dataRow["no"];
                    itemDr["itemName"] = dataRow["names"];
                    itemDr["unit"] = dataRow["unit"];
                    itemDr["resultTypeNO"] = dataRow["resultTypeNO"];
                    itemDr["precision"] = dataRow["precision"];
                    itemDr["methodName"] = dataRow["methodName"];
                    itemDr["state"] = true;
                    itemDr["dstate"] = false;
                    itemDr["planid"] = planids;

                    DTinfo.Rows.Add(itemDr);
                }

            }
            this.Close();
        }
        private void BTClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        public DataTable ReturnCheckInfo()
        {
            //DataTable = new DataTable();
            return DTinfo;
        }

        private void CEAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEAll.Checked)
            {
                for (int a = 0; a < GVTestInfo.RowCount; a++)
                {
                    GVTestInfo.SetRowCellValue(a, "check", true);

                }
            }
            else
            {
                for (int a = 0; a < GVTestInfo.RowCount; a++)
                {
                    GVTestInfo.SetRowCellValue(a, "check", false);

                }
            }

        }
    }
}
