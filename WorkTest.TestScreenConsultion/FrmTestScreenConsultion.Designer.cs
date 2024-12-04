namespace WorkTest.TestScreenConsultion
{
    partial class FrmTestScreenConsultion
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.MEDiagnosis = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.MEDiagnosisRemark = new DevExpress.XtraEditors.MemoEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.MEprimaryDiagnosis = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEDiagnosis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEDiagnosisRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEprimaryDiagnosis.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(933, 397);
            this.splitContainerControl1.SplitterPosition = 261;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.MEDiagnosis);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(933, 261);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "病理诊断";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // MEDiagnosis
            // 
            this.MEDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MEDiagnosis.Location = new System.Drawing.Point(2, 23);
            this.MEDiagnosis.Name = "MEDiagnosis";
            this.MEDiagnosis.Size = new System.Drawing.Size(929, 236);
            this.MEDiagnosis.TabIndex = 0;
            this.MEDiagnosis.Tag = "查体会诊阅片,病理诊断";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.MEDiagnosisRemark);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(933, 126);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "诊断备注";
            // 
            // MEDiagnosisRemark
            // 
            this.MEDiagnosisRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MEDiagnosisRemark.Location = new System.Drawing.Point(2, 23);
            this.MEDiagnosisRemark.Name = "MEDiagnosisRemark";
            this.MEDiagnosisRemark.Size = new System.Drawing.Size(929, 101);
            this.MEDiagnosisRemark.TabIndex = 0;
            this.MEDiagnosisRemark.Tag = "查体会诊阅片,诊断备注";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl3);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(933, 525);
            this.splitContainerControl2.SplitterPosition = 118;
            this.splitContainerControl2.TabIndex = 1;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.MEprimaryDiagnosis);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(933, 118);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "原单位诊断";
            // 
            // MEprimaryDiagnosis
            // 
            this.MEprimaryDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MEprimaryDiagnosis.Location = new System.Drawing.Point(2, 23);
            this.MEprimaryDiagnosis.Name = "MEprimaryDiagnosis";
            this.MEprimaryDiagnosis.Size = new System.Drawing.Size(929, 93);
            this.MEprimaryDiagnosis.TabIndex = 0;
            // 
            // FrmTestScreenConsultion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.splitContainerControl2);
            this.Name = "FrmTestScreenConsultion";
            this.Text = "细胞查体";
            this.Load += new System.EventHandler(this.FrmTestScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEDiagnosis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEDiagnosisRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEprimaryDiagnosis.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.MemoEdit MEDiagnosis;
        private DevExpress.XtraEditors.MemoEdit MEDiagnosisRemark;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.MemoEdit MEprimaryDiagnosis;
    }
}