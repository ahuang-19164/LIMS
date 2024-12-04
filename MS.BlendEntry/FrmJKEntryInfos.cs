using Common.ControlHandle;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.SqlModel;
using Common.BLL;
using Common.Data;

namespace MS.BlendEntry
{
    public partial class FrmJKEntryInfos : XtraForm
    {

        public static DataTable sampleStateDT;
        public FrmJKEntryInfos()
        {
            InitializeComponent();
            reStateDT();
            DEStart.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEnd.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GridLookUpEdites.Formats(RGEConnState, sampleStateDT);
            GridLookUpEdites.Formats(RGEconnstates, sampleStateDT);
            GridControls.showEmbeddedNavigator(GCInfos);
            GridControls.formartGridView(GVInfos);
            ShowViewColor(GVInfos);
            GEConnState.EditValue = 0;

        }
        public void reStateDT()
        {
            sampleStateDT = new DataTable();
            sampleStateDT.Columns.Add("no");
            sampleStateDT.Columns.Add("names");
            //sampleStateDT.Columns.Add("color");

            sampleStateDT.Rows.Add(0, "全部");
            sampleStateDT.Rows.Add(1, "待接收");
            sampleStateDT.Rows.Add(2, "已接收");
            sampleStateDT.Rows.Add(3, "接收失败");
        }

        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkPer.SampleInfoJK";
            sInfo.wheres = $"dstate=0 and createTime>='{Convert.ToDateTime(DEStart.EditValue).ToString("yyyy-MM-dd")}' and createTime<='{Convert.ToDateTime(DEEnd.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}'";
            if (GEConnState.EditValue.ToString()!= "0")
                sInfo.wheres+= $" and connstate = '{GEConnState.EditValue.ToString()}'";
            if (TEBarcode.EditValue!=null&& TEBarcode.EditValue.ToString().Trim()!="")
                sInfo.wheres += $" and barcode like '%{TEBarcode.EditValue.ToString().Trim()}%'";
            if (TEframeNo.EditValue!=null&& TEframeNo.EditValue.ToString().Trim()!="")
                sInfo.wheres += $" and frameNo like '%{TEframeNo.EditValue.ToString().Trim()}%'";

            DataTable DTInfo = ApiHelpers.postInfo(sInfo);
            GCInfos.DataSource = DTInfo;
            GVInfos.BestFitColumns();
        }



















        /// <summary>
        /// 格式化列颜色信息
        /// </summary>
        /// <param name="gridControl"></param>
        public static void ShowViewColor(GridView gv)
        {
            gv.CustomDrawCell += Gv_CustomDrawCell;
        }

        private static void Gv_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "connstate")
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "1")
                        {
                            //if (WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no={e.CellValue}").Count() > 0)
                            //{
                            //    int b = Convert.ToInt32(WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no='{e.CellValue}'").CopyToDataTable().Rows[0]["typeColor"]);
                            e.Appearance.BackColor = Color.Yellow;
                            //}
                        }
                        if (e.CellValue.ToString() == "2")
                        {
                            //if (WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no={e.CellValue}").Count() > 0)
                            //{
                            //    int b = Convert.ToInt32(WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no='{e.CellValue}'").CopyToDataTable().Rows[0]["typeColor"]);
                            e.Appearance.BackColor = Color.GreenYellow;
                            //}
                        }
                        if (e.CellValue.ToString() == "3")
                        {
                            //if (WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no={e.CellValue}").Count() > 0)
                            //{
                            //    int b = Convert.ToInt32(WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no='{e.CellValue}'").CopyToDataTable().Rows[0]["typeColor"]);
                            e.Appearance.BackColor = Color.Red;
                            //}
                        }
                    }
                }
            }
            catch //(Exception ex)
            {

                //throw ex;

            }
        }


    }
}
