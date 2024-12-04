
namespace WorkTest.TestComm
{
    partial class FormTestComm
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
            this.LCForm = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.LCForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            this.SuspendLayout();
            // 
            // LCForm
            // 
            this.LCForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LCForm.Location = new System.Drawing.Point(0, 0);
            this.LCForm.Name = "LCForm";
            this.LCForm.Root = this.Root;
            this.LCForm.Size = new System.Drawing.Size(885, 551);
            this.LCForm.TabIndex = 0;
            this.LCForm.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(885, 551);
            this.Root.TextVisible = false;
            // 
            // FormTestComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 551);
            this.Controls.Add(this.LCForm);
            this.Name = "FormTestComm";
            this.Text = "FormTestComm";
            ((System.ComponentModel.ISupportInitialize)(this.LCForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl LCForm;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
    }
}