using Common.ControlHandle;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace workOther.ItemHandle
{
    public partial class FrmShowIHC : DevExpress.XtraEditors.XtraForm
    {
        string itemlist = "";
        public FrmShowIHC(string itemLists)
        {
            InitializeComponent();
            if (itemLists.Length > 0)
                itemlist = itemLists.Substring(0, itemLists.Length - 1);
            //GridLookUpEdites.Formats(RGEGsampleTypeNO);
            //GridLookUpEdites.Formats(RGEworkNO);
            //GridControls.formartGridView(GVGroupInfo);
            GridControls.showEmbeddedNavigator(GCGroupInfo);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            GVGroupInfo.OptionsFind.AlwaysVisible = false;
            GVGroupInfo.OptionsFind.AlwaysVisible = true;
            GVGroupInfo.ShowFindPanel();
        }

        private void FrmShowItem_Load(object sender, EventArgs e)
        {

            //GridLookUpEdites.Formats(RGEgroupNO);
            //GridLookUpEdites.Formats(RGEsampleTypeNO);
            //GridLookUpEdites.Formats(RGEmethodNO);
            //GridLookUpEdites.Formats(RGEinstrumentNO);

            //RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            //RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            //RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            //RGEinstrumentNO.DataSource = WorkCommData.DTTypeInstrument;









            if (WorkCommData.DTItemGroup != null)
            {
                if (itemlist != "")
                {
                    if (WorkCommData.DTItemGroup.Select($"ihcState=1 and state=1 and dstate=0 and no not in ({itemlist})").Count() > 0)
                    {
                        DataTable dataTable = WorkCommData.DTItemGroup.Select($"ihcState=1 and state=1 and dstate=0 and no not in ({itemlist})").CopyToDataTable();
                        dataTable.Columns.Add("check", typeof(bool));
                        GCGroupInfo.DataSource = dataTable;
                    }

                }
                else
                {
                    if (WorkCommData.DTItemGroup.Select($"ihcState=1 and state=1 and dstate=0").Count() > 0)
                    {
                        DataTable dataTable = WorkCommData.DTItemGroup.Select($"ihcState=1 and state=1 and dstate=0").CopyToDataTable();
                        dataTable.Columns.Add("check", typeof(bool));
                        GCGroupInfo.DataSource = dataTable;
                    }
                }
            }
            GVGroupInfo.BestFitColumns();

        }

        List<DataRow> focusvlaue;
        private void GVInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVGroupInfo.GetFocusedRowCellValue("no") != null)
            {
                focusvlaue.Add(GVGroupInfo.GetFocusedDataRow());
            }
            this.Close();
        }
        public List<DataRow> ReturnResult()
        {
            return focusvlaue;
        }

        private void BTClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVGroupInfo.FocusedRowHandle = -1;
            focusvlaue = new List<DataRow>();
            for (int a = 0; a < GVGroupInfo.RowCount; a++)
            {
                bool checkState = GVGroupInfo.GetRowCellValue(a, "check") != DBNull.Value ? Convert.ToBoolean(GVGroupInfo.GetRowCellValue(a, "check")) : false;
                if (checkState)
                {
                    focusvlaue.Add(GVGroupInfo.GetDataRow(a));
                }
            }
            this.Close();
        }



        private void BTOK_Click(object sender, EventArgs e)
        {
            GVGroupInfo.FocusedRowHandle = -1;
            focusvlaue = new List<DataRow>();
            for (int a = 0; a < GVGroupInfo.RowCount; a++)
            {
                bool checkState = GVGroupInfo.GetRowCellValue(a, "check") != DBNull.Value ? Convert.ToBoolean(GVGroupInfo.GetRowCellValue(a, "check")) : false;
                if (checkState)
                {
                    focusvlaue.Add(GVGroupInfo.GetDataRow(a));
                }
            }
            this.Close();
        }

        private void BTExcit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}