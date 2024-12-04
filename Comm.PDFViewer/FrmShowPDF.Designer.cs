namespace Comm.PDFViewer
{
    partial class FrmShowPDF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowPDF));
            this.pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // pdfViewer
            // 
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(625, 606);
            this.pdfViewer.TabIndex = 0;
            this.pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth;
            // 
            // FrmShowPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 606);
            this.Controls.Add(this.pdfViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShowPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF预览";
            this.Load += new System.EventHandler(this.FrmShowPDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer;
    }
}