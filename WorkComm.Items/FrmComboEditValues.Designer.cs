
namespace WorkComm.Items
{
    partial class FrmComboEditValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComboEditValues));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.TEValues = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEValues.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.TEValues);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(672, 485);
            this.tablePanel1.TabIndex = 0;
            // 
            // TEValues
            // 
            this.tablePanel1.SetColumn(this.TEValues, 0);
            this.TEValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TEValues.Location = new System.Drawing.Point(3, 29);
            this.TEValues.Name = "TEValues";
            this.tablePanel1.SetRow(this.TEValues, 1);
            this.TEValues.Size = new System.Drawing.Size(666, 453);
            this.TEValues.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(170, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "在集合中输入字符串(每行一个):";
            // 
            // FrmComboEditValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 485);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmComboEditValues.IconOptions.Image")));
            this.Name = "FrmComboEditValues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "下拉框列表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmComboEditValues_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEValues.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.MemoEdit TEValues;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}