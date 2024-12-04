using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using System;
using System.Data;

namespace WorkComm.Clients
{
    public partial class FrmClientShow : DevExpress.XtraEditors.XtraForm
    {
        int clientID = 0;
        string Clist = "";
        public FrmClientShow(int ID, string ClientList)
        {
            InitializeComponent();
            clientID = ID;
            Clist = ClientList;


        }

        private void FrmClientShow_Load(object sender, EventArgs e)
        {
            DataTable data = WorkCommData.DTClientInfo;
            if (!data.Columns.Contains("check"))
            {
                data.Columns.Add("check", System.Type.GetType("System.Boolean"));
            }
            GCClientnfo.DataSource = data;
            GEPersonNO.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
            GridLookUpEdites.Formats(GEPersonNO);
            GEChargeLevelNO.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeLevel);
            GridLookUpEdites.Formats(GEChargeLevelNO);
            //SelectInfo selectInfo = new SelectInfo();
            GridControls.formartGridView(GVClientInfo);

            for (int a = 0; a < GVClientInfo.RowCount; a++)
            {
                string ClientNO = GVClientInfo.GetRowCellValue(a, "id").ToString();
                if (Clist.Contains(ClientNO + ","))
                //if(Clist.Contains(ClientNO))
                {
                    GVClientInfo.SetRowCellValue(a, "check", true);
                }
                else
                {
                    GVClientInfo.SetRowCellValue(a, "check", false);
                }
            }
            GVClientInfo.CustomDrawRowIndicator += gridView_CustomDrawRowIndicator;
            GVClientInfo.IndicatorWidth = 40;

            GVClientInfo.BestFitColumns();

        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            if (e.Info.IsRowIndicator && e.RowHandle >= -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clist = "";
            GVClientInfo.FocusedRowHandle = -1;
            for (int a = 0; a < GVClientInfo.RowCount; a++)
            {
                string ClientNO = GVClientInfo.GetRowCellValue(a, "id").ToString();
                if (Convert.ToBoolean(GVClientInfo.GetRowCellValue(a, "check")))
                {
                    Clist += GVClientInfo.GetRowCellValue(a, "id") + ",";
                }
            }
            TEList.EditValue = Clist;
            uInfo updateInfo = new uInfo();
            updateInfo.TableName = "WorkComm.ClientAgent";
            updateInfo.value = $"PowerList='{Clist}'";
            updateInfo.wheres = $"ID={clientID}";
            ApiHelpers.postInfo(updateInfo);
        }
        private void BTClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


    }
}
