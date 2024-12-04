using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workComm.ResultShow
{
    public partial class FrmReportShow : XtraForm
    {

        static string filePath = Application.StartupPath;
        string fileName = "";
        string fileFullPath = "";
        public FrmReportShow()
        {

            string dirfileName = filePath + "\\TempReport";
            //string fileFullPath = filePath + "\\" + fileName;
            try
            {

                if (Directory.Exists(dirfileName))
                {
                    string[] fileName = Directory.GetFiles(dirfileName);
                    string fileFullPath = fileName[0];
                    InitializeComponent();

                    foreach (Control control in pdfViewer1.Controls)
                    {
                        string a = control.Name;
                    }



                    //pdfViewer1.MenuManager.DisposeManager();

                    pdfViewer1.ShowFindDialog();


                    pdfViewer1.NavigationPaneVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Visible;
                    pdfViewer1.NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Visible;
                    pdfViewer1.LoadDocument(fileFullPath);
                    
                }
                else
                {
                    MessageBox.Show("未找到对应的报告单，请联系系统管理员。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                pdfViewer1.Dispose();
                this.Close();
            }

        }

        private void FrmReportShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            pdfViewer1.Dispose();
            this.Close();
        }

        private void pdfFilePrintBarItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("aaaa");
        }

        private void BTPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //pdfViewer1.ShowPrintStatusDialog=false;//是否显示打印界面


            pdfViewer1.Print();


            //pdfViewer1.Print(new DevExpress.Pdf.PdfPrinterSettings(new PrinterSettings() { Copies=1,Collate=true}));//直接打印

        }

        private void BTSeachs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTSeach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BTSeachs_ItemClick(null, null);
        }
    }
}
