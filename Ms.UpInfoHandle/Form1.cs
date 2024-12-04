using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ms.UpInfoHandle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmSampleInfoExcel frmSampleInfoExcel = new FrmSampleInfoExcel();
            frmSampleInfoExcel.ShowDialog();
        }
    }
}
