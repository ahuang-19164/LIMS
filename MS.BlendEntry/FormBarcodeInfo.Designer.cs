
namespace MS.BlendEntry
{
    partial class FormBarcodeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBarcodeInfo));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.TEbarcodeInfo = new DevExpress.XtraEditors.MemoEdit();
            this.BTClose = new DevExpress.XtraEditors.SimpleButton();
            this.BTSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcodeInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.TEbarcodeInfo);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.BTClose);
            this.splitContainerControl1.Panel2.Controls.Add(this.BTSave);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(717, 633);
            this.splitContainerControl1.SplitterPosition = 579;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // TEbarcodeInfo
            // 
            this.TEbarcodeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TEbarcodeInfo.Location = new System.Drawing.Point(0, 0);
            this.TEbarcodeInfo.Name = "TEbarcodeInfo";
            this.TEbarcodeInfo.Size = new System.Drawing.Size(717, 579);
            this.TEbarcodeInfo.TabIndex = 0;
            // 
            // BTClose
            // 
            this.BTClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTClose.ImageOptions.Image")));
            this.BTClose.Location = new System.Drawing.Point(598, 4);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(87, 27);
            this.BTClose.TabIndex = 1;
            this.BTClose.Text = "关    闭";
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // BTSave
            // 
            this.BTSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.Image")));
            this.BTSave.Location = new System.Drawing.Point(459, 4);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(87, 27);
            this.BTSave.TabIndex = 0;
            this.BTSave.Text = "提    交";
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // FormBarcodeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 633);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FormBarcodeInfo.IconOptions.Icon")));
            this.Name = "FormBarcodeInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入条码信息列表";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcodeInfo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.MemoEdit TEbarcodeInfo;
        private DevExpress.XtraEditors.SimpleButton BTClose;
        private DevExpress.XtraEditors.SimpleButton BTSave;
    }
}