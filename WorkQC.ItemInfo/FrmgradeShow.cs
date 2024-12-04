using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace WorkQC.ItemInfo
{
    public partial class FrmgradeShow : XtraForm
    {
        string itemNOs = "";
        string planItemids = "";
        public FrmgradeShow(string planItemid, string ItemNO, string lgrade = "")
        {
            planItemids = planItemid;
            itemNOs = ItemNO;
            InitializeComponent();
            GridLookUpEdites.Formats(RGElevelNO);
            RGElevelNO.DataSource = QCInfoData.DTQCLevel;
            GridControls.formartGridView(GVgradeInfo);
            GridControls.showEmbeddedNavigator(GCgradeInfo);

            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.QCGrade";
            if (lgrade == "")
            {
                sInfo.wheres = $"dstate=0 and state=1";
            }
            else
            {
                sInfo.wheres = $" dstate=0 and state=1";
            }
            DataTable dataTable = ApiHelpers.postInfo(sInfo);
            dataTable.Columns.Add("check", typeof(bool));
            GCgradeInfo.DataSource = dataTable;
            GVgradeInfo.BestFitColumns();
            CreatDT();
        }
        DataTable DTinfo = new DataTable();
        private void CreatDT()
        {
            DataColumn column1 = new DataColumn { ColumnName = "id", DataType = typeof(int) };
            DataColumn column2 = new DataColumn { ColumnName = "gradeid", DataType = typeof(string) };
            DataColumn column3 = new DataColumn { ColumnName = "gradeCode", DataType = typeof(string) };
            DataColumn column4 = new DataColumn { ColumnName = "gradeName", DataType = typeof(string) };
            DataColumn column5 = new DataColumn { ColumnName = "planItemid", DataType = typeof(string) };
            DataColumn column6 = new DataColumn { ColumnName = "itemNO", DataType = typeof(string) };
            DataColumn column7 = new DataColumn { ColumnName = "levelNO", DataType = typeof(int) };
            DataColumn column8 = new DataColumn { ColumnName = "producer", DataType = typeof(string) };
            DataColumn column9 = new DataColumn { ColumnName = "produceTime", DataType = typeof(string) };
            DataColumn column10 = new DataColumn { ColumnName = "validityTime", DataType = typeof(string) };

            DataColumn column11 = new DataColumn { ColumnName = "avgValue", DataType = typeof(string) };
            DataColumn column12 = new DataColumn { ColumnName = "sdValue", DataType = typeof(string) };
            DataColumn column13 = new DataColumn { ColumnName = "cvValue", DataType = typeof(string) };
            DataColumn column14 = new DataColumn { ColumnName = "error", DataType = typeof(string) };
            DataColumn column15 = new DataColumn { ColumnName = "errorTEa", DataType = typeof(string) };
            DataColumn column16 = new DataColumn { ColumnName = "factoryX", DataType = typeof(string) };
            DataColumn column17 = new DataColumn { ColumnName = "factoryRange", DataType = typeof(string) };
            DataColumn column18 = new DataColumn { ColumnName = "remark", DataType = typeof(string) };
            DataColumn column19 = new DataColumn { ColumnName = "sort", DataType = typeof(int) };
            DataColumn column20 = new DataColumn { ColumnName = "state", DataType = typeof(bool) };
            DataColumn column21 = new DataColumn { ColumnName = "dstate", DataType = typeof(bool) };

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
            column13,
            column14,
            column15,
            column16,
            column17,
            column18,
            column19,
            column20,
            column21
            });
        }



        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVgradeInfo.FocusedRowHandle = -1;
            for (int a = 0; a < GVgradeInfo.RowCount; a++)
            {
                DataRow dataRow = GVgradeInfo.GetDataRow(a);
                if (dataRow["check"] != DBNull.Value && Convert.ToBoolean(dataRow["check"]))
                {

                    DataRow itemDr = DTinfo.NewRow();
                    itemDr["gradeid"] = dataRow["no"];
                    itemDr["gradeCode"] = dataRow["names"];
                    itemDr["gradeName"] = dataRow["shortNames"];
                    itemDr["producer"] = dataRow["producer"];
                    itemDr["produceTime"] = dataRow["produceTime"];
                    itemDr["validityTime"] = dataRow["validityTime"];
                    itemDr["levelNO"] = dataRow["levelNO"];
                    itemDr["state"] = true;
                    itemDr["dstate"] = false;
                    itemDr["itemNO"] = itemNOs;
                    itemDr["planItemid"] = planItemids;
                    itemDr["sort"] = dataRow["sort"];

                    DTinfo.Rows.Add(itemDr);
                }

            }
            this.Close();
        }

        private void BTClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        public DataTable ReturnCheckInfo()
        {
            //DataTable = new DataTable();
            return DTinfo;
        }
    }
}
