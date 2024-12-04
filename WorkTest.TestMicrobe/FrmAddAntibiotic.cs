using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace WorkTest.TestMicrobe
{
    public partial class FrmAddAntibiotic : XtraForm
    {
        public FrmAddAntibiotic()
        {
            InitializeComponent();

            GridControls.formartGridView(GVInfos);
            GridControls.showEmbeddedNavigator(GCInfos);





            DataTable dataTable = new DataTable();
            dataTable = WorkCommData.DTMicrobeAntibiotic.Copy();
            dataTable.Columns.Add("check", typeof(bool));
            DTinfo = dataTable.Clone();
            GCInfos.DataSource = DTHelper.DTEnable(dataTable);
        }



        private void BTOK_Click(object sender, EventArgs e)
        {
            GVInfos.FocusedRowHandle = -1;
            for (int a = 0; a < GVInfos.RowCount; a++)
            {
                if (!Convert.IsDBNull(GVInfos.GetRowCellValue(a, "check")))
                {
                    if (Convert.ToBoolean(GVInfos.GetRowCellValue(a, "check")))
                    {
                        DataRow dataRow = DTinfo.NewRow();
                        dataRow.ItemArray = GVInfos.GetDataRow(a).ItemArray;
                        DTinfo.Rows.Add(dataRow);
                    }
                }
            }
            this.Close();
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            DTinfo = null;
            this.Close();
        }
        DataTable DTinfo;
        public DataTable reDT()
        {
            return DTinfo;
        }


    }
}
