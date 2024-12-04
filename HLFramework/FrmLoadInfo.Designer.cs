namespace HLFramework
{
    partial class FrmLoadInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoadInfo));
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.BTClose = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Appearance.Options.UseFont = true;
            this.progressPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.progressPanel1.Caption = "正在读取数据请稍等";
            this.progressPanel1.Location = new System.Drawing.Point(75, -3);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(196, 69);
            this.progressPanel1.TabIndex = 0;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // BTClose
            // 
            this.BTClose.Location = new System.Drawing.Point(277, 39);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(46, 27);
            this.BTClose.TabIndex = 2;
            this.BTClose.Text = "关闭";
            this.BTClose.UseVisualStyleBackColor = true;
            this.BTClose.Visible = false;
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FrmLoadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 78);
            this.Controls.Add(this.BTClose);
            this.Controls.Add(this.progressPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmLoadInfo.IconOptions.Icon")));
            this.Name = "FrmLoadInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "读取基础数据";
            this.Shown += new System.EventHandler(this.FrmLoadInfo_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.Button BTClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}