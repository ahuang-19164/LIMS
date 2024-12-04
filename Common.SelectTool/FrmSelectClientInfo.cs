using Common.ControlHandle;
using Common.Data;
using Common.FinanceModel;
using Common.StatisticModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace Common.SelectTool
{
    public partial class FrmSelectClientInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmSelectClientInfo(DataTable DT)
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
                    sourceInfoItem.clientTypeNO = row["clientTypeNO"];
                    sourceInfoItem.personNO = row["personNO"];
                    sourceInfoItem.chargeLevelNO = row["chargeLevelNO"];
                    sourceInfoItem.province = row["province"];
                    sourceInfoItem.city = row["city"];
                    sourceInfoItem.area = row["area"];
                    sourceInfoItem.state = row["state"] != DBNull.Value ? Convert.ToBoolean(row["state"]) : false;
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
            GridLookUpEdites.Formats(RGEpersonNO);
            GridLookUpEdites.Formats(RGEchargeLevelNO);
            GridLookUpEdites.Formats(RGEclientTypeNO);
            RGEchargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEclientTypeNO.DataSource = WorkCommData.DTTypeClient;
            RGEpersonNO.DataSource = CommonData.DTUserInfoAll;

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

        }
        PairsSelectModel pairsInfo;
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





            //GVInfo.FocusedRowHandle = -1;
            //infoList = "";
            //for(int a=0;a<GVInfo.RowCount;a++)
            //{
            //    if(GVInfo.GetRowCellValue(a,"check")!=null)
            //    {
            //        if(Convert.ToBoolean(GVInfo.GetRowCellValue(a, "check")))
            //        {
            //            infoList += GVInfo.GetRowCellValue(a, "names").ToString() + ",";
            //        }
            //    }
            //}
            //infoList = infoList.Substring(0, infoList.Length - 1);
            //this.Close();
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
            public object clientTypeNO { get; set; }
            public object personNO { get; set; }
            public object chargeLevelNO { get; set; }
            public object province { get; set; }
            public object city { get; set; }
            public object area { get; set; }
            public bool state { get; set; }
            //public object customCode { get; set; }
        }
    }
}
