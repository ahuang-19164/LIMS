using Common.ControlHandle;
using Common.FinanceModel;
using Common.StatisticModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace Common.SelectTool
{
    public partial class FrmSelectOtherInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmSelectOtherInfo(DataTable DT)
        {
            InitializeComponent();
            List<sourceInfo> sourceInfos = new List<sourceInfo>();
            if (DT != null)
            {
                foreach (DataRow row in DT.Rows)
                {
                    sourceInfo sourceInfoItem = new sourceInfo();
                    sourceInfoItem.no = row["no"];
                    sourceInfoItem.names = row["names"];
                    sourceInfoItem.shortNames = row["shortNames"];
                    sourceInfoItem.customCode = row["customCode"];
                    sourceInfos.Add(sourceInfoItem);
                }
                GCInfo.DataSource = sourceInfos;
                GVInfo.BestFitColumns();
            }
        }

        private void FrmSelectInfo_Load(object sender, EventArgs e)
        {
            GridControls.formartGridView(GVInfo);

            GridControls.showEmbeddedNavigator(GCInfo);
        }

        private void CEcheckAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEcheckAll.Checked)
            {
                for (int a = 0; a < GVInfo.RowCount; a++)
                {
                    GVInfo.SetRowCellValue(a, "check", true);
                }
            }
            else
            {
                for (int a = 0; a < GVInfo.RowCount; a++)
                {
                    GVInfo.SetRowCellValue(a, "check", false);
                }
            }
        }

        private void GVInfo_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(GVInfo.GetFocusedRowCellValue("check")))
            {
                GVInfo.SetFocusedRowCellValue("check", true);
            }
            else
            {
                GVInfo.SetFocusedRowCellValue("check", false);
            }
        }



        private PairsSelectModel pairsInfo;
        private void BTok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pairsInfo = new PairsSelectModel();
            GVInfo.FocusedRowHandle = -1;
            string noList = "";
            string valueList = "";

            for (int a = 0; a < GVInfo.RowCount; a++)
            {
                if (GVInfo.GetRowCellValue(a, "check") != null)
                {
                    if (Convert.ToBoolean(GVInfo.GetRowCellValue(a, "check")))
                    {
                        noList += GVInfo.GetRowCellValue(a, "no").ToString() + ",";
                        valueList += GVInfo.GetRowCellValue(a, "names").ToString() + ",";

                    }
                }
            }
            pairsInfo.type = "1";
            pairsInfo.keyNO = noList.Substring(0, noList.Length - 1);
            pairsInfo.keyValue = valueList.Substring(0, valueList.Length - 1);
            this.Close();
        }


        public PairsSelectModel ReturnListString()
        {
            return pairsInfo;
        }

        private void BTclose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        public class sourceInfo
        {
            public bool check { get; set; }
            public object no { get; set; }
            public object names { get; set; }
            public object shortNames { get; set; }
            public object customCode { get; set; }
        }
    }
}
