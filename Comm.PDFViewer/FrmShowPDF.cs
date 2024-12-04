using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comm.PDFViewer
{
    public partial class FrmShowPDF : Form
    {
        string FilePaths = "";
        public FrmShowPDF(string FilePath)
        {
            InitializeComponent();
            FilePaths = FilePath;
        }

        private void FrmShowPDF_Load(object sender, EventArgs e)
        {
            byte[] bytes = Convert.FromBase64String(FilePaths);
            using (MemoryStream ms = new MemoryStream(bytes))
            {







                pdfViewer.LoadDocument(ms);
            }

                

        }
    }
}
