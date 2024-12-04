using Common.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Data;
using System.Linq;

namespace Common.ControlHandle
{
    public class LookUpEdits
    {
        public static LookUpEdit ProduceLookUpEdit(string TableNames)
        {
            LookUpEdit lookUpEdit = new LookUpEdit();
            lookUpEdit.Properties.ValueMember = "no";
            lookUpEdit.Properties.DisplayMember = "names";
            if (WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").Count() > 0)
            {
                lookUpEdit.Properties.DataSource = WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").CopyToDataTable();
            }
            lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("no", "编号", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("names", "名称",200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lookUpEdit.Properties.NullText = "";
            return lookUpEdit;

        }
        public static RepositoryItemLookUpEdit ProduceRepositonLookUpEdit(string TableNames)
        {
            RepositoryItemLookUpEdit lookUpEdit = new RepositoryItemLookUpEdit();
            lookUpEdit.ValueMember = "no";
            lookUpEdit.DisplayMember = "names";
            if (WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").Count() > 0)
            {
                lookUpEdit.DataSource = WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").CopyToDataTable();
            }
            lookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("no", "编号", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("names", "名称",200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            lookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lookUpEdit.NullText = "";
            return lookUpEdit;

        }
        public static void Formats(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.ValueMember = "no";
            lookUpEdit.Properties.DisplayMember = "names";
            lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("no", "编号", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("names", "名称",200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            lookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lookUpEdit.Properties.NullText = "";
        }
        public static void Formats(RepositoryItemLookUpEdit lookUpEdit)
        {
            lookUpEdit.ValueMember = "no";
            lookUpEdit.DisplayMember = "names";
            lookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            lookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("no", "编号", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("names", "名称", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            lookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lookUpEdit.NullText = "";
        }
    }
}
