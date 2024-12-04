using Common.GridHandle;
using System.Data;

namespace HLFramework
{
    public partial class FRMMoudelDesign : DevExpress.XtraEditors.XtraForm
    {
        GridColumnDispose gridColumn = new GridColumnDispose();
        public FRMMoudelDesign()
        {
            InitializeComponent();

            //gridView1.BestFitColumns();
            ssss();

        }
        public void ssss()
        {
            DataTable data = new DataTable();
            data.Columns.Add("no", typeof(string));
            data.Columns.Add("names", typeof(string));
            data.Columns.Add("FieldName", typeof(string));
            data.Columns.Add("Caption", typeof(string));
            data.Columns.Add("Visible", typeof(bool));
            data.Columns.Add("ColumnEdit", typeof(string));
            data.Columns.Add("AllowFocus", typeof(bool));
            data.Columns.Add("AllowEdit", typeof(bool));




            data.Rows.Add("GridControl", "列表菜单", "列表菜单", "列表菜单", true, "textedit", false, true);
            data.Rows.Add("GridControl", "列表菜单2", "列表菜单2", "列表菜单2", true, "checkedit", false, true);





            //string path = @"C:\Users\huang\Desktop\aaa.xml";
            //GCColumnsInfo.MainView.RestoreLayoutFromXml(path);
            //GVMoudelInfo = gridColumn.SetGridColumns(data);


            //GCColumnsInfo.MainView.OptionsLayout;
        }


    }
}
