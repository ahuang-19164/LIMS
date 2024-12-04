using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace WorkTest.TestMicrobe
{
    public partial class FrmResultType : XtraForm
    {
        public FrmResultType(DataTable ResultDT)
        {
            InitializeComponent();
            GCInfos.DataSource = ResultDT;
        }
        private void FrmResultType_Load(object sender, EventArgs e)
        {

        }
        private void BTOK_Click(object sender, EventArgs e)
        {
            ReresultValue();
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            GVInfos.FocusedRowHandle = -1;
            this.Close();
        }

        private void GVInfos_DoubleClick(object sender, EventArgs e)
        {
            ReresultValue();
        }
        public string ReresultValue()
        {
            DataRow dataRow = GVInfos.GetFocusedDataRow();
            if (dataRow != null)
            {
                string resultValue = dataRow["value"] != DBNull.Value ? dataRow["value"].ToString() : "";
                this.Close();
                return resultValue;
            }
            else
            {
                MessageBox.Show("未选择结果信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }
    }
}
