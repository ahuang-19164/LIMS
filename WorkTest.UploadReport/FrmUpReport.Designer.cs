
namespace WorkTest.UploadReport
{
    partial class FrmUpReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpReport));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BTClear = new DevExpress.XtraEditors.SimpleButton();
            this.BTUpLoad = new DevExpress.XtraEditors.SimpleButton();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.BTSelectFile = new DevExpress.XtraEditors.SimpleButton();
            this.TEFilePath = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BTClear);
            this.layoutControl1.Controls.Add(this.BTUpLoad);
            this.layoutControl1.Controls.Add(this.pdfViewer1);
            this.layoutControl1.Controls.Add(this.BTSelectFile);
            this.layoutControl1.Controls.Add(this.TEFilePath);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1223, 778);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BTClear
            // 
            this.BTClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTClear.ImageOptions.Image")));
            this.BTClear.Location = new System.Drawing.Point(1128, 12);
            this.BTClear.Name = "BTClear";
            this.BTClear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTClear.Size = new System.Drawing.Size(83, 22);
            this.BTClear.StyleController = this.layoutControl1;
            this.BTClear.TabIndex = 8;
            this.BTClear.Text = "清空报告";
            this.BTClear.Click += new System.EventHandler(this.BTClear_Click);
            // 
            // BTUpLoad
            // 
            this.BTUpLoad.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUpLoad.ImageOptions.Image")));
            this.BTUpLoad.Location = new System.Drawing.Point(1034, 12);
            this.BTUpLoad.Name = "BTUpLoad";
            this.BTUpLoad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTUpLoad.Size = new System.Drawing.Size(90, 22);
            this.BTUpLoad.StyleController = this.layoutControl1;
            this.BTUpLoad.TabIndex = 7;
            this.BTUpLoad.Text = "上传报告";
            this.BTUpLoad.Click += new System.EventHandler(this.BTUpLoad_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Location = new System.Drawing.Point(12, 38);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(1199, 728);
            this.pdfViewer1.TabIndex = 6;
            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth;
            // 
            // BTSelectFile
            // 
            this.BTSelectFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSelectFile.ImageOptions.Image")));
            this.BTSelectFile.Location = new System.Drawing.Point(940, 12);
            this.BTSelectFile.Name = "BTSelectFile";
            this.BTSelectFile.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTSelectFile.Size = new System.Drawing.Size(90, 22);
            this.BTSelectFile.StyleController = this.layoutControl1;
            this.BTSelectFile.TabIndex = 5;
            this.BTSelectFile.Text = "选择文件";
            this.BTSelectFile.Click += new System.EventHandler(this.BTSelectFile_Click);
            // 
            // TEFilePath
            // 
            this.TEFilePath.Enabled = false;
            this.TEFilePath.Location = new System.Drawing.Point(91, 12);
            this.TEFilePath.Name = "TEFilePath";
            this.TEFilePath.Properties.AllowFocused = false;
            this.TEFilePath.Size = new System.Drawing.Size(845, 20);
            this.TEFilePath.StyleController = this.layoutControl1;
            this.TEFilePath.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1223, 778);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEFilePath;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(928, 26);
            this.layoutControlItem1.Text = "上传报告路径:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(76, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BTSelectFile;
            this.layoutControlItem2.Location = new System.Drawing.Point(928, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pdfViewer1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1203, 732);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BTUpLoad;
            this.layoutControlItem4.Location = new System.Drawing.Point(1022, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(94, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BTClear;
            this.layoutControlItem5.Location = new System.Drawing.Point(1116, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(87, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(87, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(87, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // FrmUpReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 778);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmUpReport.IconOptions.Image")));
            this.Name = "FrmUpReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报告预览";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUpReport_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TEFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton BTSelectFile;
        private DevExpress.XtraEditors.TextEdit TEFilePath;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton BTClear;
        private DevExpress.XtraEditors.SimpleButton BTUpLoad;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}