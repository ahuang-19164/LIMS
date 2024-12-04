using Common.Data;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;

namespace Common.ControlHandle
{
    public partial class FrmShowDictionary : XtraForm
    {



        string Tagvalue = "";
        string frmname = "";
        /// <summary>
        /// 类别编号
        /// </summary>
        /// <param name="ControlTag">控件的tag属性。字典类别</param>
        /// 
        public FrmShowDictionary(string frmNames, string ControlTag)
        {
            InitializeComponent();
            Tagvalue = ControlTag;
            frmname = frmNames;
        }

        private void FrmShowDictionary_Load(object sender, EventArgs e)
        {
            if (Tagvalue.Length != 0)
            {
                if (WorkCommData.DTWorkDictionary.Select($"class='{frmname}' and Type='{Tagvalue}' and state=1").Count() > 0)
                {
                    DataTable dataInfo = WorkCommData.DTWorkDictionary.Select($"class='{frmname}' and Type='{Tagvalue}' and state=1").CopyToDataTable();
                    dataInfo.Columns.Add("check", typeof(bool));
                    GCInfo.DataSource = dataInfo;
                }
            }
        }
        string focusvlaue = "";
        private void GVInfo_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = GVInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                focusvlaue = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                this.Close();
            }

        }
        public string ReturnResult()
        {
            return focusvlaue;
        }

        private void BTOK_Click(object sender, EventArgs e)
        {
            GVInfo.FocusedRowHandle = -1;
            DataTable dataTable = GCInfo.DataSource as DataTable;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                bool checkState = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                if (checkState)
                {
                    string valueInfo = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                    focusvlaue += valueInfo + ";\r\n";
                }
            }
            this.Close();
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
