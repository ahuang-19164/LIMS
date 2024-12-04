
namespace HLFramework
{
    partial class FrmUpFileInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpFileInfo));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BTUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.BTClose = new DevExpress.XtraEditors.SimpleButton();
            this.TEMsg = new DevExpress.XtraEditors.MemoEdit();
            this.GCFileInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEVersion = new DevExpress.XtraEditors.TextEdit();
            this.TEName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEMsg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BTUpdate);
            this.layoutControl1.Controls.Add(this.BTClose);
            this.layoutControl1.Controls.Add(this.TEMsg);
            this.layoutControl1.Controls.Add(this.GCFileInfo);
            this.layoutControl1.Controls.Add(this.TEVersion);
            this.layoutControl1.Controls.Add(this.TEName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(669, 565);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BTUpdate
            // 
            this.BTUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUpdate.ImageOptions.Image")));
            this.BTUpdate.Location = new System.Drawing.Point(416, 531);
            this.BTUpdate.Name = "BTUpdate";
            this.BTUpdate.Size = new System.Drawing.Size(110, 22);
            this.BTUpdate.StyleController = this.layoutControl1;
            this.BTUpdate.TabIndex = 9;
            this.BTUpdate.Text = "立即更新";
            this.BTUpdate.Click += new System.EventHandler(this.BTUpdate_Click);
            // 
            // BTClose
            // 
            this.BTClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTClose.ImageOptions.Image")));
            this.BTClose.Location = new System.Drawing.Point(542, 531);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(115, 22);
            this.BTClose.StyleController = this.layoutControl1;
            this.BTClose.TabIndex = 8;
            this.BTClose.Text = "取      消";
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // TEMsg
            // 
            this.TEMsg.Location = new System.Drawing.Point(67, 60);
            this.TEMsg.Name = "TEMsg";
            this.TEMsg.Properties.ReadOnly = true;
            this.TEMsg.Size = new System.Drawing.Size(590, 169);
            this.TEMsg.StyleController = this.layoutControl1;
            this.TEMsg.TabIndex = 7;
            // 
            // GCFileInfo
            // 
            this.GCFileInfo.Location = new System.Drawing.Point(12, 252);
            this.GCFileInfo.MainView = this.gridView1;
            this.GCFileInfo.Name = "GCFileInfo";
            this.GCFileInfo.Size = new System.Drawing.Size(645, 275);
            this.GCFileInfo.TabIndex = 6;
            this.GCFileInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCFileInfo.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FileName,
            this.FileSize});
            this.gridView1.DetailHeight = 408;
            this.gridView1.GridControl = this.GCFileInfo;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FileName
            // 
            this.FileName.Caption = "文件名称";
            this.FileName.FieldName = "FileName";
            this.FileName.MinWidth = 23;
            this.FileName.Name = "FileName";
            this.FileName.OptionsColumn.AllowFocus = false;
            this.FileName.Visible = true;
            this.FileName.VisibleIndex = 0;
            this.FileName.Width = 364;
            // 
            // FileSize
            // 
            this.FileSize.Caption = "文件大小";
            this.FileSize.FieldName = "FileSize";
            this.FileSize.MinWidth = 23;
            this.FileSize.Name = "FileSize";
            this.FileSize.OptionsColumn.AllowFocus = false;
            this.FileSize.Visible = true;
            this.FileSize.VisibleIndex = 1;
            this.FileSize.Width = 180;
            // 
            // TEVersion
            // 
            this.TEVersion.Location = new System.Drawing.Point(67, 36);
            this.TEVersion.Name = "TEVersion";
            this.TEVersion.Properties.ReadOnly = true;
            this.TEVersion.Size = new System.Drawing.Size(590, 20);
            this.TEVersion.StyleController = this.layoutControl1;
            this.TEVersion.TabIndex = 5;
            // 
            // TEName
            // 
            this.TEName.Location = new System.Drawing.Point(67, 12);
            this.TEName.Name = "TEName";
            this.TEName.Properties.ReadOnly = true;
            this.TEName.Size = new System.Drawing.Size(590, 20);
            this.TEName.StyleController = this.layoutControl1;
            this.TEName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(669, 565);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(649, 24);
            this.layoutControlItem1.Text = "标      题:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 519);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(404, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TEVersion;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(649, 24);
            this.layoutControlItem2.Text = "版  本 号:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.GCFileInfo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 221);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(121, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(649, 298);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "更新文件列表:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(76, 14);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TEMsg;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(649, 173);
            this.layoutControlItem4.Text = "更新说明:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.BTClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(530, 519);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(119, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BTUpdate;
            this.layoutControlItem6.Location = new System.Drawing.Point(404, 519);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(114, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(518, 519);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(12, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(673, 569);
            this.panelControl1.TabIndex = 1;
            // 
            // FrmUpFileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 569);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmUpFileInfo.IconOptions.Icon")));
            this.Name = "FrmUpFileInfo";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HLIMS更新提示";
            this.Load += new System.EventHandler(this.FrmUpFileInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TEMsg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEVersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit TEName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl GCFileInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit TEVersion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton BTUpdate;
        private DevExpress.XtraEditors.SimpleButton BTClose;
        private DevExpress.XtraEditors.MemoEdit TEMsg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn FileName;
        private DevExpress.XtraGrid.Columns.GridColumn FileSize;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}