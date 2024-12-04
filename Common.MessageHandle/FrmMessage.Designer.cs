
namespace Common.MessageHandle
{
    partial class FrmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessage));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BTOK = new DevExpress.XtraEditors.SimpleButton();
            this.TERecord = new DevExpress.XtraEditors.MemoEdit();
            this.TEBarcode = new DevExpress.XtraEditors.TextEdit();
            this.DEDateTime = new DevExpress.XtraEditors.DateEdit();
            this.TETypeState = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TERecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEDateTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEDateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TETypeState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.BTOK);
            this.layoutControl1.Controls.Add(this.TERecord);
            this.layoutControl1.Controls.Add(this.TEBarcode);
            this.layoutControl1.Controls.Add(this.DEDateTime);
            this.layoutControl1.Controls.Add(this.TETypeState);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(317, 183);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(2, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "消息内容:";
            // 
            // BTOK
            // 
            this.BTOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTOK.ImageOptions.Image")));
            this.BTOK.Location = new System.Drawing.Point(239, 159);
            this.BTOK.Name = "BTOK";
            this.BTOK.Size = new System.Drawing.Size(76, 22);
            this.BTOK.StyleController = this.layoutControl1;
            this.BTOK.TabIndex = 8;
            this.BTOK.Text = "立即处理";
            this.BTOK.Click += new System.EventHandler(this.BTOK_Click);
            // 
            // TERecord
            // 
            this.TERecord.Enabled = false;
            this.TERecord.Location = new System.Drawing.Point(58, 46);
            this.TERecord.Name = "TERecord";
            this.TERecord.Properties.AllowFocused = false;
            this.TERecord.Properties.Appearance.BackColor = System.Drawing.SystemColors.Menu;
            this.TERecord.Properties.Appearance.Options.UseBackColor = true;
            this.TERecord.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TERecord.Properties.ReadOnly = true;
            this.TERecord.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TERecord.Properties.WordWrap = false;
            this.TERecord.Size = new System.Drawing.Size(257, 87);
            this.TERecord.StyleController = this.layoutControl1;
            this.TERecord.TabIndex = 7;
            // 
            // TEBarcode
            // 
            this.TEBarcode.Enabled = false;
            this.TEBarcode.Location = new System.Drawing.Point(57, 2);
            this.TEBarcode.Name = "TEBarcode";
            this.TEBarcode.Properties.Appearance.BackColor = System.Drawing.SystemColors.Menu;
            this.TEBarcode.Properties.Appearance.Options.UseBackColor = true;
            this.TEBarcode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TEBarcode.Properties.ReadOnly = true;
            this.TEBarcode.Size = new System.Drawing.Size(258, 18);
            this.TEBarcode.StyleController = this.layoutControl1;
            this.TEBarcode.TabIndex = 4;
            // 
            // DEDateTime
            // 
            this.DEDateTime.EditValue = null;
            this.DEDateTime.Enabled = false;
            this.DEDateTime.Location = new System.Drawing.Point(57, 137);
            this.DEDateTime.Name = "DEDateTime";
            this.DEDateTime.Properties.AllowFocused = false;
            this.DEDateTime.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.DEDateTime.Properties.Appearance.Options.UseBackColor = true;
            this.DEDateTime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.DEDateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Separator)});
            this.DEDateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEDateTime.Properties.DisplayFormat.FormatString = "";
            this.DEDateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEDateTime.Properties.EditFormat.FormatString = "";
            this.DEDateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEDateTime.Properties.Mask.EditMask = "";
            this.DEDateTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.DEDateTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.DEDateTime.Size = new System.Drawing.Size(258, 18);
            this.DEDateTime.StyleController = this.layoutControl1;
            this.DEDateTime.TabIndex = 6;
            // 
            // TETypeState
            // 
            this.TETypeState.Enabled = false;
            this.TETypeState.Location = new System.Drawing.Point(57, 24);
            this.TETypeState.Name = "TETypeState";
            this.TETypeState.Properties.AllowFocused = false;
            this.TETypeState.Properties.Appearance.BackColor = System.Drawing.SystemColors.Menu;
            this.TETypeState.Properties.Appearance.Options.UseBackColor = true;
            this.TETypeState.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TETypeState.Properties.ReadOnly = true;
            this.TETypeState.Size = new System.Drawing.Size(258, 18);
            this.TETypeState.StyleController = this.layoutControl1;
            this.TETypeState.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(317, 183);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEBarcode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(317, 22);
            this.layoutControlItem1.Text = "条  码 号:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TETypeState;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 22);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(317, 22);
            this.layoutControlItem2.Text = "消息类型:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.DEDateTime;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 135);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(317, 22);
            this.layoutControlItem3.Text = "消息时间:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BTOK;
            this.layoutControlItem5.Location = new System.Drawing.Point(237, 157);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 157);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(237, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.labelControl1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(56, 18);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TERecord;
            this.layoutControlItem4.Location = new System.Drawing.Point(56, 44);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(261, 91);
            this.layoutControlItem4.Text = "消息内容:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 62);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(56, 73);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(321, 187);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseMove);
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 187);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmMessage.IconOptions.Icon")));
            this.Name = "FrmMessage";
            this.Text = "消息提醒:";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMessageBox_FormClosed);
            this.Load += new System.EventHandler(this.FrmMessage_Load);
            this.MouseEnter += new System.EventHandler(this.FrmMessage_MouseEnter);
            this.Move += new System.EventHandler(this.FrmMessage_Move);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TERecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEDateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEDateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TETypeState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton BTOK;
        private DevExpress.XtraEditors.MemoEdit TERecord;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit TEBarcode;
        private DevExpress.XtraEditors.DateEdit DEDateTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit TETypeState;
    }
}