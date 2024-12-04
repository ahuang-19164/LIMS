using Common.BLL;
using Common.ControlHandle;
using Common.Log;
using Common.SqlModel;
using System;
using System.Data;

namespace Ms.UpInfoHandle
{
    public partial class FrmImportConfigInfo : DevExpress.XtraEditors.XtraForm
    {
        //
        public FrmImportConfigInfo(DataTable tname)
        {
            InitializeComponent();


            GridControls.formartGridView(gridView1);
            GridControls.showEmbeddedNavigator(gridControl1);
            gridControl1.DataSource = tname;
            gridView1.BestFitColumns();
        }

        private void FrmImportConfigInfo_Load(object sender, EventArgs e)
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.wheres = $"TableNames='{aaaa}'";
            //selectInfo.TableName = "dbo.ImportConfigInfo";
            //selectInfo.OrderColumns = "sort";
            ////gridControl1.DataSource = ApiHelpers.postInfo(selectInfo);

        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle = -1;
                DataTable dt = gridControl1.DataSource as DataTable;
                ApiHelpers.postInfo(dt, "dbo.ImportConfigInfo");
            }
            catch (Exception ex)
            {
                CommonLogText.WriteLog(this.Text, ex.ToString());
            }
        }


    }
}
