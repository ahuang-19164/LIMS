using DevExpress.XtraEditors;

namespace workOther.ItemChange
{
    public partial class FrmItemRemoveInfo : XtraForm
    {
        public FrmItemRemoveInfo()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmRemove frmAdd = new FrmRemove();
            frmAdd.ShowDialog();
        }
    }
}
