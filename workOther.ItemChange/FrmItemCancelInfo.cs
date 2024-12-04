using DevExpress.XtraEditors;

namespace workOther.ItemChange
{
    public partial class FrmItemCancelInfo : XtraForm
    {
        public FrmItemCancelInfo()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCancel frmAdd = new FrmCancel();
            frmAdd.ShowDialog();
        }
    }
}
