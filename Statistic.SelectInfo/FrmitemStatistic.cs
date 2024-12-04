using Common.ControlHandle;
using Common.Data;
using Common.SelectTool;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace Statistic.optInfo
{
    public partial class FrmitemStatistic : XtraForm
    {
        public FrmitemStatistic()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GridControls.showEmbeddedNavigator(GCInfos);
            GridControls.formartGridView(GVInfos);
            GridControls.ShowViewColor(GVInfos);



            GridLookUpEdites.Formats(RGEperStateNO);
            RGEperStateNO.DataSource = WorkCommData.DTStateTest;
        }
        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GCInfos.Tag != null)
            {
                FrmSelectTool frmSelect = new FrmSelectTool(GCInfos.Tag.ToString());
                Func<DataTable> func = frmSelect.ReturnSelectInfo;
                frmSelect.ShowDialog();
                GCInfos.DataSource = func();
                GVInfos.BestFitColumns();
            }
            else
            {
                MessageBox.Show("系统错误", "系统提示");
            }
        }


    }
}
