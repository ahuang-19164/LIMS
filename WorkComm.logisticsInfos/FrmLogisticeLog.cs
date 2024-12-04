using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using System;
using System.Data;

namespace WorkComm.logisticsInfos
{
    public partial class FrmLogisticeLog : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogisticeLog()
        {
            InitializeComponent();
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);
            GridControls.formartGridView(GVLog);
            GridControls.showEmbeddedNavigator(GCLog);

        }
        private void FrmLogisticeLog_Load(object sender, EventArgs e)
        {
            GCInfo.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GVInfo.BestFitColumns();
        }

        private void GVInfo_Click(object sender, EventArgs e)
        {
            DataRow dataRow = GVInfo.GetFocusedDataRow();
            if (dataRow["no"] != DBNull.Value)
            {
                string clientNO = dataRow["no"].ToString();
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkComm.ClientBarcodeLog";
                selectInfo.wheres = $"hospitalNO='{clientNO}'";
                selectInfo.OrderColumns = "createTime";
                GCLog.DataSource = ApiHelpers.postInfo(selectInfo);
            }
        }
    }
}
