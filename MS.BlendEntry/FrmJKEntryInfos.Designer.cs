
namespace MS.BlendEntry
{
    partial class FrmJKEntryInfos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJKEntryInfos));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.TEBarcode = new DevExpress.XtraBars.BarEditItem();
            this.RTEBarcode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEframeNo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.DEStart = new DevExpress.XtraBars.BarEditItem();
            this.RDEStart = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.DEEnd = new DevExpress.XtraBars.BarEditItem();
            this.RDEEnd = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.GEConnState = new DevExpress.XtraBars.BarEditItem();
            this.RGEConnState = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BTSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfos = new DevExpress.XtraGrid.GridControl();
            this.GVInfos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.frameNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.connstate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEconnstates = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.perRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.creater = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEStart.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEEnd.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEConnState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEconnstates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.TEBarcode,
            this.DEStart,
            this.DEEnd,
            this.GEConnState,
            this.BTSelect,
            this.TEframeNo});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RTEBarcode,
            this.RDEStart,
            this.RDEEnd,
            this.RGEConnState,
            this.repositoryItemTextEdit1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEBarcode, "", false, true, true, 179, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEframeNo, "", false, true, true, 156, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.DEStart, "", false, true, true, 126, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.DEEnd, "", false, true, true, 125, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.GEConnState, "", false, true, true, 112, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // TEBarcode
            // 
            this.TEBarcode.Caption = "条码号:";
            this.TEBarcode.Edit = this.RTEBarcode;
            this.TEBarcode.Id = 1;
            this.TEBarcode.Name = "TEBarcode";
            // 
            // RTEBarcode
            // 
            this.RTEBarcode.AutoHeight = false;
            this.RTEBarcode.Name = "RTEBarcode";
            // 
            // TEframeNo
            // 
            this.TEframeNo.Caption = "架子号:";
            this.TEframeNo.Edit = this.repositoryItemTextEdit1;
            this.TEframeNo.Id = 6;
            this.TEframeNo.Name = "TEframeNo";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // DEStart
            // 
            this.DEStart.Caption = "时间:";
            this.DEStart.Edit = this.RDEStart;
            this.DEStart.Id = 2;
            this.DEStart.Name = "DEStart";
            // 
            // RDEStart
            // 
            this.RDEStart.AutoHeight = false;
            this.RDEStart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RDEStart.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RDEStart.Name = "RDEStart";
            // 
            // DEEnd
            // 
            this.DEEnd.Caption = "---";
            this.DEEnd.Edit = this.RDEEnd;
            this.DEEnd.Id = 3;
            this.DEEnd.Name = "DEEnd";
            // 
            // RDEEnd
            // 
            this.RDEEnd.AutoHeight = false;
            this.RDEEnd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RDEEnd.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RDEEnd.Name = "RDEEnd";
            // 
            // GEConnState
            // 
            this.GEConnState.Caption = "接收状态:";
            this.GEConnState.Edit = this.RGEConnState;
            this.GEConnState.EditWidth = 0;
            this.GEConnState.Id = 4;
            this.GEConnState.Name = "GEConnState";
            // 
            // RGEConnState
            // 
            this.RGEConnState.AutoHeight = false;
            this.RGEConnState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEConnState.Name = "RGEConnState";
            this.RGEConnState.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // BTSelect
            // 
            this.BTSelect.Caption = "查询";
            this.BTSelect.Id = 5;
            this.BTSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSelect.ImageOptions.Image")));
            this.BTSelect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSelect.ImageOptions.LargeImage")));
            this.BTSelect.Name = "BTSelect";
            this.BTSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSelect_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1128, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 625);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1128, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 601);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1128, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 601);
            // 
            // GCInfos
            // 
            this.GCInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfos.Location = new System.Drawing.Point(0, 24);
            this.GCInfos.MainView = this.GVInfos;
            this.GCInfos.MenuManager = this.barManager1;
            this.GCInfos.Name = "GCInfos";
            this.GCInfos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEconnstates});
            this.GCInfos.Size = new System.Drawing.Size(1128, 601);
            this.GCInfos.TabIndex = 4;
            this.GCInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfos});
            // 
            // GVInfos
            // 
            this.GVInfos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.barcode,
            this.hospitalNames,
            this.frameNo,
            this.connstate,
            this.perRemark,
            this.creater});
            this.GVInfos.GridControl = this.GCInfos;
            this.GVInfos.Name = "GVInfos";
            // 
            // id
            // 
            this.id.Caption = "编号";
            this.id.FieldName = "id";
            this.id.MaxWidth = 100;
            this.id.MinWidth = 10;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.OptionsColumn.ReadOnly = true;
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.ReadOnly = true;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 1;
            // 
            // hospitalNames
            // 
            this.hospitalNames.Caption = "客户名称";
            this.hospitalNames.FieldName = "hospitalNames";
            this.hospitalNames.Name = "hospitalNames";
            this.hospitalNames.OptionsColumn.AllowFocus = false;
            this.hospitalNames.OptionsColumn.ReadOnly = true;
            this.hospitalNames.Visible = true;
            this.hospitalNames.VisibleIndex = 2;
            // 
            // frameNo
            // 
            this.frameNo.Caption = "架子号";
            this.frameNo.FieldName = "frameNo";
            this.frameNo.Name = "frameNo";
            this.frameNo.OptionsColumn.ReadOnly = true;
            this.frameNo.Visible = true;
            this.frameNo.VisibleIndex = 3;
            // 
            // connstate
            // 
            this.connstate.Caption = "状态";
            this.connstate.ColumnEdit = this.RGEconnstates;
            this.connstate.FieldName = "connstate";
            this.connstate.MaxWidth = 80;
            this.connstate.MinWidth = 80;
            this.connstate.Name = "connstate";
            this.connstate.OptionsColumn.AllowFocus = false;
            this.connstate.OptionsColumn.ReadOnly = true;
            this.connstate.Visible = true;
            this.connstate.VisibleIndex = 4;
            this.connstate.Width = 80;
            // 
            // RGEconnstates
            // 
            this.RGEconnstates.AutoHeight = false;
            this.RGEconnstates.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEconnstates.Name = "RGEconnstates";
            this.RGEconnstates.PopupView = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // perRemark
            // 
            this.perRemark.Caption = "记录";
            this.perRemark.FieldName = "perRemark";
            this.perRemark.Name = "perRemark";
            this.perRemark.OptionsColumn.AllowFocus = false;
            this.perRemark.OptionsColumn.ReadOnly = true;
            this.perRemark.Visible = true;
            this.perRemark.VisibleIndex = 5;
            // 
            // creater
            // 
            this.creater.Caption = "接收人";
            this.creater.FieldName = "creater";
            this.creater.MaxWidth = 100;
            this.creater.Name = "creater";
            this.creater.OptionsColumn.AllowFocus = false;
            this.creater.OptionsColumn.ReadOnly = true;
            this.creater.Visible = true;
            this.creater.VisibleIndex = 6;
            // 
            // FrmJKEntryInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 625);
            this.Controls.Add(this.GCInfos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmJKEntryInfos";
            this.Text = "FrmJKEntryInfos";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEStart.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEEnd.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEConnState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEconnstates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        private DevExpress.XtraGrid.GridControl GCInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfos;
        private DevExpress.XtraBars.BarEditItem TEBarcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RTEBarcode;
        private DevExpress.XtraBars.BarEditItem DEStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RDEStart;
        private DevExpress.XtraBars.BarEditItem DEEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RDEEnd;
        private DevExpress.XtraBars.BarEditItem GEConnState;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEConnState;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraBars.BarButtonItem BTSelect;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNames;
        private DevExpress.XtraGrid.Columns.GridColumn connstate;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEconnstates;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn perRemark;
        private DevExpress.XtraGrid.Columns.GridColumn creater;
        private DevExpress.XtraBars.BarEditItem TEframeNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn frameNo;
    }
}