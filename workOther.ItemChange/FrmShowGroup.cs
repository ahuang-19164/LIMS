using Common.ControlHandle;
using Common.Data;
using System;
using System.Data;
using System.Linq;

namespace workOther.ItemChange
{
    public partial class FrmShowGroup : DevExpress.XtraEditors.XtraForm
    {
        string itemlist = "";
        public FrmShowGroup(string itemLists)
        {
            InitializeComponent();
            itemlist = itemLists;
            //GridLookUpEdites.Formats(RGEGsampleTypeNO);
            //GridLookUpEdites.Formats(RGEworkNO);
            GridControls.formartGridView(GVcheckInfo);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            GVcheckInfo.OptionsFind.AlwaysVisible = false;
            GVcheckInfo.OptionsFind.AlwaysVisible = true;
            GVcheckInfo.ShowFindPanel();
        }

        private void FrmShowItem_Load(object sender, EventArgs e)
        {

            if (WorkCommData.DTItemApply != null)
            {
                if (itemlist != "")
                {
                    if (WorkCommData.DTItemApply.Select($"state=1 and dstate=0 and no not in ({itemlist})").Count() > 0)
                    {
                        GCcheckInfo.DataSource = WorkCommData.DTItemApply.Select($"state=1 and dstate=0 and no not in ({itemlist})").CopyToDataTable();
                    }

                }
                else
                {
                    if (WorkCommData.DTItemApply.Select($"state=1 and dstate=0").Count() > 0)
                    {
                        GCcheckInfo.DataSource = WorkCommData.DTItemApply.Select($"state=1 and dstate=0").CopyToDataTable();
                    }
                }
            }
            GVcheckInfo.BestFitColumns();

        }

        DataRow focusvlaue;
        private void GVInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVcheckInfo.GetFocusedRowCellValue("no") != null)
            {
                focusvlaue = GVcheckInfo.GetFocusedDataRow();
            }
            this.Close();
        }
        public DataRow ReturnResult()
        {
            return focusvlaue;
        }
    }
}