namespace WorkComm.Items
{
    partial class FrmShowGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowGroup));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTClear = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCGroupInfo = new DevExpress.XtraGrid.GridControl();
            this.GVGroupInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleTypeNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEGsampleTypeNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.workNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEworkNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEGsampleTypeNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEworkNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BTSave,
            this.BTClear});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTClear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
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
            this.barDockControlTop.Size = new System.Drawing.Size(998, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 568);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(998, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 544);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(998, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 544);
            // 
            // GCGroupInfo
            // 
            this.GCGroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCGroupInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCGroupInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCGroupInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCGroupInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCGroupInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCGroupInfo.Location = new System.Drawing.Point(0, 24);
            this.GCGroupInfo.MainView = this.GVGroupInfo;
            this.GCGroupInfo.MenuManager = this.barManager1;
            this.GCGroupInfo.Name = "GCGroupInfo";
            this.GCGroupInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEworkNO,
            this.RGEGsampleTypeNO});
            this.GCGroupInfo.Size = new System.Drawing.Size(998, 544);
            this.GCGroupInfo.TabIndex = 14;
            this.GCGroupInfo.UseEmbeddedNavigator = true;
            this.GCGroupInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVGroupInfo});
            // 
            // GVGroupInfo
            // 
            this.GVGroupInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.names,
            this.shortNames,
            this.customCode,
            this.sampleTypeNO,
            this.sort,
            this.workNO,
            this.state});
            this.GVGroupInfo.DetailHeight = 408;
            this.GVGroupInfo.GridControl = this.GCGroupInfo;
            this.GVGroupInfo.Name = "GVGroupInfo";
            this.GVGroupInfo.OptionsFind.AlwaysVisible = true;
            this.GVGroupInfo.OptionsFind.ShowCloseButton = false;
            this.GVGroupInfo.OptionsView.ShowGroupPanel = false;
            this.GVGroupInfo.DoubleClick += new System.EventHandler(this.GVInfo_DoubleClick);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 23;
            this.id.Name = "id";
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
            // names
            // 
            this.names.Caption = "组合名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 23;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 2;
            this.names.Width = 76;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "组合别名";
            this.shortNames.FieldName = "disNames";
            this.shortNames.MinWidth = 23;
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 3;
            this.shortNames.Width = 56;
            // 
            // customCode
            // 
            this.customCode.Caption = "名称简拼";
            this.customCode.FieldName = "shortNames";
            this.customCode.MinWidth = 23;
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Visible = true;
            this.customCode.VisibleIndex = 4;
            this.customCode.Width = 56;
            // 
            // sampleTypeNO
            // 
            this.sampleTypeNO.Caption = "样本类型";
            this.sampleTypeNO.ColumnEdit = this.RGEGsampleTypeNO;
            this.sampleTypeNO.FieldName = "sampleTypeNO";
            this.sampleTypeNO.MinWidth = 23;
            this.sampleTypeNO.Name = "sampleTypeNO";
            this.sampleTypeNO.OptionsColumn.AllowFocus = false;
            this.sampleTypeNO.Visible = true;
            this.sampleTypeNO.VisibleIndex = 5;
            this.sampleTypeNO.Width = 72;
            // 
            // RGEGsampleTypeNO
            // 
            this.RGEGsampleTypeNO.AutoHeight = false;
            this.RGEGsampleTypeNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEGsampleTypeNO.Name = "RGEGsampleTypeNO";
            this.RGEGsampleTypeNO.PopupView = this.gridView9;
            // 
            // gridView9
            // 
            this.gridView9.DetailHeight = 408;
            this.gridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView9.Name = "gridView9";
            this.gridView9.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView9.OptionsView.ShowGroupPanel = false;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 50;
            this.sort.MinWidth = 50;
            this.sort.Name = "sort";
            this.sort.OptionsColumn.AllowFocus = false;
            this.sort.Width = 50;
            // 
            // workNO
            // 
            this.workNO.Caption = "工作组";
            this.workNO.ColumnEdit = this.RGEworkNO;
            this.workNO.FieldName = "workNO";
            this.workNO.MinWidth = 23;
            this.workNO.Name = "workNO";
            this.workNO.OptionsColumn.AllowFocus = false;
            this.workNO.Visible = true;
            this.workNO.VisibleIndex = 1;
            this.workNO.Width = 65;
            // 
            // RGEworkNO
            // 
            this.RGEworkNO.AutoHeight = false;
            this.RGEworkNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEworkNO.Name = "RGEworkNO";
            this.RGEworkNO.PopupView = this.gridView8;
            // 
            // gridView8
            // 
            this.gridView8.DetailHeight = 408;
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
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
            this.state.VisibleIndex = 6;
            this.state.Width = 50;
            // 
            // FrmShowGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 568);
            this.Controls.Add(this.GCGroupInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmShowGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验项目";
            this.Load += new System.EventHandler(this.FrmShowItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEGsampleTypeNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEworkNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTClear;
        private DevExpress.XtraGrid.GridControl GCGroupInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVGroupInfo;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private DevExpress.XtraGrid.Columns.GridColumn sampleTypeNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEGsampleTypeNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraGrid.Columns.GridColumn workNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEworkNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn state;
    }
}