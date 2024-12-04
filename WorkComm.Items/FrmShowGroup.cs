using Common.ControlHandle;
using Common.Data;
using System;
using System.Data;
using System.Linq;

namespace WorkComm.Items
{
    public partial class FrmShowGroup : DevExpress.XtraEditors.XtraForm
    {
        string itemlist = "";
        public FrmShowGroup(string itemLists)
        {
            InitializeComponent();
            itemlist = itemLists;
            GridLookUpEdites.Formats(RGEGsampleTypeNO);
            GridLookUpEdites.Formats(RGEworkNO);
            GridControls.formartGridView(GVGroupInfo);

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
            RGEGsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEworkNO.DataSource = WorkCommData.DTGroupWork;

            if (WorkCommData.DTItemGroup != null)
            {
                if (itemlist != "")
                {
                    if (WorkCommData.DTItemGroup.Select($"ihcState=0 and state=1 and dstate=0 and no not in ({itemlist})").Count() > 0)
                    {
                        GCGroupInfo.DataSource = WorkCommData.DTItemGroup.Select($"ihcState=0 and state=1 and dstate=0 and no not in ({itemlist})").CopyToDataTable();
                    }

                }
                else
                {
                    if (WorkCommData.DTItemGroup.Select($"ihcState=0 and state=1 and dstate=0").Count() > 0)
                    {
                        GCGroupInfo.DataSource = WorkCommData.DTItemGroup.Select($"ihcState=0 and state=1 and dstate=0").CopyToDataTable();
                    }
                }
            }
            GVGroupInfo.BestFitColumns();

        }

        DataRow focusvlaue;
        private void GVInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVGroupInfo.GetFocusedRowCellValue("no") != null)
            {
                focusvlaue = GVGroupInfo.GetFocusedDataRow();
            }
            this.Close();
        }
        public DataRow ReturnResult()
        {
            return focusvlaue;
        }
    }
}