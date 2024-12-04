using Common.BLL;
using Common.JsonHelper;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCSort : XtraForm
    {
        public FrmQCSort()
        {
            InitializeComponent();
        }

        private void FrmQCSort_Load(object sender, EventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.RuleClass";
            string sr = JsonHelper.SerializeObjct(sInfo);
            DataTable dataTable = ApiHelpers.postInfo(sInfo);
            GCInfos.DataSource = dataTable;
        }
    }
}
