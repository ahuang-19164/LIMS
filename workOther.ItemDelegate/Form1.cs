﻿namespace workOther.ItemDelegate
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {
            FrmDelegateResultInfo frmDelegateTest = new FrmDelegateResultInfo();
            frmDelegateTest.ShowDialog();
        }
    }
}