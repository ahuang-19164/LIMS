using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workOther.SampleStores
{
    public partial class FormBarcodeInfo : XtraForm
    {
        public FormBarcodeInfo(string aaaa)
        {
            InitializeComponent();
            if(aaaa!="")
                TEbarcodeInfo.EditValue=Regex.Replace(aaaa,",", "\r\n");
        }
        string reString = "";

        private void BTSave_Click(object sender, EventArgs e)
        {
            string a = TEbarcodeInfo.EditValue.ToString().Trim().Replace(" ", "");
            string msg = Regex.Replace(a, @"\r\n", ",");
            //string msg = Regex.Replace(a, @"[\r\n]", ",");
            reString = msg;
            this.Close();
        }
        private void BTClose_Click(object sender, EventArgs e)
        {
            reString = "";
            this.Close();
        }
        public string reStringinfo()
        {
           return reString;
        }

    }
}
