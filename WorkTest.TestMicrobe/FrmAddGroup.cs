using Common.BLL;
using Common.Data;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace WorkTest.TestMicrobe
{
    public partial class FrmAddGroup : XtraForm
    {
        public FrmAddGroup()
        {
            InitializeComponent();
        }

        private void FrmAddGroup_Load(object sender, EventArgs e)
        {
            GCGroupList.DataSource = DTHelper.DTEnable(WorkCommData.DTMicrobeGroupList);
            GVGroupList.BestFitColumns();
        }

        private void GVGroupList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVGroupList.GetFocusedDataRow();
            if (dataRow != null)
            {
                string infolist = dataRow["listinfo"] != DBNull.Value ? dataRow["listinfo"].ToString() : "";
                if (infolist != "")
                {
                    GCInfos.DataSource = DTHelper.DTEnable(WorkCommData.DTMicrobeAntibiotic.Select($"no in ({infolist})").CopyToDataTable());
                    GVInfos.BestFitColumns();
                }
            }
        }

        private void GVGroupList_DoubleClick(object sender, EventArgs e)
        {
            DTinfo = GCInfos.DataSource as DataTable;
            this.Close();
        }
        DataTable DTinfo;
        public DataTable reDT()
        {
            return DTinfo;
        }

        private void BTOK_Click(object sender, EventArgs e)
        {
            DTinfo = GCInfos.DataSource as DataTable;
            this.Close();
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            DTinfo = null;
            this.Close();
        }
    }
}
