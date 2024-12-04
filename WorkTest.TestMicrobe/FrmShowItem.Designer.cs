namespace WorkTest.TestMicrobe
{
    partial class FrmShowItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowItem));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTClear = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEgroupNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DisNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.methodNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEmethodNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.instrumentNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEinstrumentNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BTClose = new DevExpress.XtraEditors.SimpleButton();
            this.BTOK = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEinstrumentNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BTSave,
            this.BTClear});
            this.barManager1.MaxItemId = 2;
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 0;
            this.BTSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.Image")));
            this.BTSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.LargeImage")));
            this.BTSave.Name = "BTSave";
            // 
            // BTClear
            // 
            this.BTClear.Caption = "取消";
            this.BTClear.Id = 1;
            this.BTClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTClear.ImageOptions.Image")));
            this.BTClear.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTClear.ImageOptions.LargeImage")));
            this.BTClear.Name = "BTClear";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(821, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 545);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(821, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 545);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(821, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 545);
            // 
            // GCInfo
            // 
            this.GCInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfo.Location = new System.Drawing.Point(12, 12);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemGridLookUpEdit1,
            this.RGEgroupNO,
            this.RGEmethodNO,
            this.RGEinstrumentNO});
            this.GCInfo.Size = new System.Drawing.Size(797, 495);
            this.GCInfo.TabIndex = 9;
            this.GCInfo.UseEmbeddedNavigator = true;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.groupNO,
            this.names,
            this.DisNames,
            this.simpleNames,
            this.shortNames,
            this.methodNO,
            this.instrumentNO,
            this.state});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.OptionsFind.AlwaysVisible = true;
            this.GVInfo.OptionsFind.ShowCloseButton = false;
            this.GVInfo.OptionsView.ShowGroupPanel = false;
            this.GVInfo.DoubleClick += new System.EventHandler(this.GVInfo_DoubleClick);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 23;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Width = 87;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 50;
            this.no.MinWidth = 50;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 50;
            // 
            // groupNO
            // 
            this.groupNO.Caption = "专业组";
            this.groupNO.ColumnEdit = this.RGEgroupNO;
            this.groupNO.FieldName = "groupNO";
            this.groupNO.MinWidth = 23;
            this.groupNO.Name = "groupNO";
            this.groupNO.OptionsColumn.AllowFocus = false;
            this.groupNO.Visible = true;
            this.groupNO.VisibleIndex = 1;
            this.groupNO.Width = 87;
            // 
            // RGEgroupNO
            // 
            this.RGEgroupNO.AutoHeight = false;
            this.RGEgroupNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgroupNO.Name = "RGEgroupNO";
            this.RGEgroupNO.PopupView = this.repositoryItemGridLookUpEdit3View;
            // 
            // repositoryItemGridLookUpEdit3View
            // 
            this.repositoryItemGridLookUpEdit3View.DetailHeight = 408;
            this.repositoryItemGridLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit3View.Name = "repositoryItemGridLookUpEdit3View";
            this.repositoryItemGridLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // names
            // 
            this.names.Caption = "项目名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 23;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 2;
            this.names.Width = 103;
            // 
            // DisNames
            // 
            this.DisNames.Caption = "项目别名";
            this.DisNames.FieldName = "disNames";
            this.DisNames.MinWidth = 23;
            this.DisNames.Name = "DisNames";
            this.DisNames.OptionsColumn.AllowFocus = false;
            this.DisNames.Visible = true;
            this.DisNames.VisibleIndex = 3;
            this.DisNames.Width = 76;
            // 
            // simpleNames
            // 
            this.simpleNames.Caption = "名称简拼";
            this.simpleNames.FieldName = "simpleNames";
            this.simpleNames.MinWidth = 23;
            this.simpleNames.Name = "simpleNames";
            this.simpleNames.OptionsColumn.AllowFocus = false;
            this.simpleNames.Width = 76;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "拼音简拼";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.MinWidth = 23;
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 4;
            this.shortNames.Width = 87;
            // 
            // methodNO
            // 
            this.methodNO.Caption = "实验方法";
            this.methodNO.ColumnEdit = this.RGEmethodNO;
            this.methodNO.FieldName = "methodNO";
            this.methodNO.MinWidth = 23;
            this.methodNO.Name = "methodNO";
            this.methodNO.OptionsColumn.AllowFocus = false;
            this.methodNO.Visible = true;
            this.methodNO.VisibleIndex = 5;
            this.methodNO.Width = 87;
            // 
            // RGEmethodNO
            // 
            this.RGEmethodNO.AutoHeight = false;
            this.RGEmethodNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEmethodNO.Name = "RGEmethodNO";
            this.RGEmethodNO.PopupView = this.gridView10;
            // 
            // gridView10
            // 
            this.gridView10.DetailHeight = 408;
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.OptionsView.ShowGroupPanel = false;
            // 
            // instrumentNO
            // 
            this.instrumentNO.Caption = "检测仪器";
            this.instrumentNO.ColumnEdit = this.RGEinstrumentNO;
            this.instrumentNO.FieldName = "instrumentNO";
            this.instrumentNO.MinWidth = 23;
            this.instrumentNO.Name = "instrumentNO";
            this.instrumentNO.OptionsColumn.AllowFocus = false;
            this.instrumentNO.Visible = true;
            this.instrumentNO.VisibleIndex = 6;
            this.instrumentNO.Width = 87;
            // 
            // RGEinstrumentNO
            // 
            this.RGEinstrumentNO.AutoHeight = false;
            this.RGEinstrumentNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEinstrumentNO.Name = "RGEinstrumentNO";
            this.RGEinstrumentNO.PopupView = this.gridView11;
            // 
            // gridView11
            // 
            this.gridView11.DetailHeight = 408;
            this.gridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView11.OptionsView.ShowGroupPanel = false;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 50;
            this.state.MinWidth = 50;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 7;
            this.state.Width = 50;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("no", "no"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("names", "名称")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 408;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BTClose);
            this.layoutControl1.Controls.Add(this.BTOK);
            this.layoutControl1.Controls.Add(this.GCInfo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(821, 545);
            this.layoutControl1.TabIndex = 14;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BTClose
            // 
            this.BTClose.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.cancel_16x161;
            this.BTClose.Location = new System.Drawing.Point(730, 511);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(79, 22);
            this.BTClose.StyleController = this.layoutControl1;
            this.BTClose.TabIndex = 11;
            this.BTClose.Text = "取消";
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // BTOK
            // 
            this.BTOK.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.apply_16x161;
            this.BTOK.Location = new System.Drawing.Point(583, 511);
            this.BTOK.Name = "BTOK";
            this.BTOK.Size = new System.Drawing.Size(82, 22);
            this.BTOK.StyleController = this.layoutControl1;
            this.BTOK.TabIndex = 10;
            this.BTOK.Text = "确定";
            this.BTOK.Click += new System.EventHandler(this.BTOK_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(821, 545);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GCInfo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(801, 499);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BTClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(718, 499);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BTOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(571, 499);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(86, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(657, 499);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(61, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 499);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(571, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FrmShowItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 545);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmShowItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验项目";
            this.Load += new System.EventHandler(this.FrmShowItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEinstrumentNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTClear;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn groupNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgroupNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit3View;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn DisNames;
        private DevExpress.XtraGrid.Columns.GridColumn simpleNames;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn methodNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEmethodNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn instrumentNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEinstrumentNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton BTClose;
        private DevExpress.XtraEditors.SimpleButton BTOK;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}