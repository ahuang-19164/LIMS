using DevExpress.XtraEditors;

namespace workOther.ItemChange
{
    public partial class FrmItemAddInfo : XtraForm
    {
        public FrmItemAddInfo()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmAdd frmAdd = new FrmAdd();
            frmAdd.ShowDialog();
        }
    }
}
