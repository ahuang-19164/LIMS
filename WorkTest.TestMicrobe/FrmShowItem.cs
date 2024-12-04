using Common.ControlHandle;
using Common.Data;
using System;
using System.Data;
using System.Linq;

namespace WorkTest.TestMicrobe
{
    public partial class FrmShowItem : DevExpress.XtraEditors.XtraForm
    {
        string itemlist = "";
        string infoflowNO = "";
        public FrmShowItem(string itemLists, string flowNO)
        {
            InitializeComponent();
            infoflowNO = flowNO;
            itemlist = itemLists;
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridControls.formartGridView(GVInfo);

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            GVInfo.OptionsFind.AlwaysVisible = false;
            GVInfo.OptionsFind.AlwaysVisible = true;
            GVInfo.ShowFindPanel();
        }

        private void FrmShowItem_Load(object sender, EventArgs e)
        {
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;

            if (WorkCommData.DTItemTest != null)
            {
                if (itemlist != "")
                {
                    if (WorkCommData.DTItemTest.Select($"state=1 and dstate=0 and groupNO='11' and no not in ({itemlist})").Count() > 0)
                    {
                        GCInfo.DataSource = WorkCommData.DTItemTest.Select($"state=1 and dstate=0 and groupNO='11' and no not in ({itemlist})").CopyToDataTable();
                    }
                }
                else
                {
                    if (WorkCommData.DTItemTest.Select($"state=1 and dstate=0 and groupNO='11'").Count() > 0)
                    {
                        GCInfo.DataSource = WorkCommData.DTItemTest.Select($"state=1 and dstate=0 and groupNO='11'").CopyToDataTable();
                    }
                }
            }
            GVInfo.BestFitColumns();
        }

        DataRow focusvlaue;
        private void GVInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVInfo.GetFocusedRowCellValue("no") != null)
            {
                focusvlaue = GVInfo.GetFocusedDataRow();
            }
            this.Close();
        }
        public DataRow ReturnResult()
        {
            return focusvlaue;
        }

        private void BTOK_Click(object sender, EventArgs e)
        {
            if (GVInfo.GetFocusedRowCellValue("no") != null)
            {
                focusvlaue = GVInfo.GetFocusedDataRow();
            }
            this.Close();
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}