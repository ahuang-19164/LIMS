namespace WorkComm.Clients
{
    partial class FrmClientShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientShow));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTClose = new DevExpress.XtraBars.BarButtonItem();
            this.TEList = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCClientnfo = new DevExpress.XtraGrid.GridControl();
            this.GVClientInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CBCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ClientNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clientNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clientPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GEPersonNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clientShortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clientChargeLevelNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GEChargeLevelNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClientProvince = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientState = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCClientnfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVClientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEPersonNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEChargeLevelNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
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
            this.BTClose,
            this.TEList});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.TEList, "", false, true, true, 499)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 0;
            this.BTSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTSave.ImageOptions.SvgImage")));
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTClose
            // 
            this.BTClose.Caption = "取消";
            this.BTClose.Id = 1;
            this.BTClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTClose.ImageOptions.SvgImage")));
            this.BTClose.Name = "BTClose";
            this.BTClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTClose_ItemClick);
            // 
            // TEList
            // 
            this.TEList.Caption = "barEditItem1";
            this.TEList.Edit = this.repositoryItemTextEdit1;
            this.TEList.Id = 2;
            this.TEList.Name = "TEList";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(883, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 490);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(883, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 466);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(883, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 466);
            // 
            // GCClientnfo
            // 
            this.GCClientnfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCClientnfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCClientnfo.Location = new System.Drawing.Point(0, 24);
            this.GCClientnfo.MainView = this.GVClientInfo;
            this.GCClientnfo.MenuManager = this.barManager1;
            this.GCClientnfo.Name = "GCClientnfo";
            this.GCClientnfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.GEPersonNO,
            this.GEChargeLevelNO,
            this.CBCheck});
            this.GCClientnfo.Size = new System.Drawing.Size(883, 466);
            this.GCClientnfo.TabIndex = 4;
            this.GCClientnfo.UseEmbeddedNavigator = true;
            this.GCClientnfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVClientInfo});
            // 
            // GVClientInfo
            // 
            this.GVClientInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.check,
            this.ClientNO,
            this.clientNames,
            this.clientPerson,
            this.clientShortNames,
            this.clientChargeLevelNO,
            this.ClientProvince,
            this.ClientCity,
            this.ClientArea,
            this.ClientState});
            this.GVClientInfo.GridControl = this.GCClientnfo;
            this.GVClientInfo.Name = "GVClientInfo";
            this.GVClientInfo.OptionsFind.AlwaysVisible = true;
            this.GVClientInfo.OptionsFind.ShowCloseButton = false;
            this.GVClientInfo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.GVClientInfo.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // check
            // 
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.CBCheck;
            this.check.FieldName = "check";
            this.check.MaxWidth = 30;
            this.check.MinWidth = 30;
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 30;
            // 
            // CBCheck
            // 
            this.CBCheck.AutoHeight = false;
            this.CBCheck.Name = "CBCheck";
            // 
            // ClientNO
            // 
            this.ClientNO.Caption = "编号";
            this.ClientNO.FieldName = "no";
            this.ClientNO.MaxWidth = 50;
            this.ClientNO.MinWidth = 50;
            this.ClientNO.Name = "ClientNO";
            this.ClientNO.OptionsColumn.AllowFocus = false;
            this.ClientNO.Visible = true;
            this.ClientNO.VisibleIndex = 1;
            this.ClientNO.Width = 50;
            // 
            // clientNames
            // 
            this.clientNames.Caption = "客户名称";
            this.clientNames.FieldName = "names";
            this.clientNames.Name = "clientNames";
            this.clientNames.OptionsColumn.AllowFocus = false;
            this.clientNames.Visible = true;
            this.clientNames.VisibleIndex = 2;
            this.clientNames.Width = 144;
            // 
            // clientPerson
            // 
            this.clientPerson.Caption = "负责人";
            this.clientPerson.ColumnEdit = this.GEPersonNO;
            this.clientPerson.FieldName = "personNO";
            this.clientPerson.Name = "clientPerson";
            this.clientPerson.OptionsColumn.AllowFocus = false;
            this.clientPerson.Visible = true;
            this.clientPerson.VisibleIndex = 4;
            // 
            // GEPersonNO
            // 
            this.GEPersonNO.AutoHeight = false;
            this.GEPersonNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEPersonNO.Name = "GEPersonNO";
            this.GEPersonNO.NullText = "";
            this.GEPersonNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // clientShortNames
            // 
            this.clientShortNames.Caption = "名称简拼";
            this.clientShortNames.FieldName = "chortNames";
            this.clientShortNames.Name = "clientShortNames";
            this.clientShortNames.OptionsColumn.AllowFocus = false;
            this.clientShortNames.Visible = true;
            this.clientShortNames.VisibleIndex = 3;
            this.clientShortNames.Width = 152;
            // 
            // clientChargeLevelNO
            // 
            this.clientChargeLevelNO.Caption = "收费级别";
            this.clientChargeLevelNO.ColumnEdit = this.GEChargeLevelNO;
            this.clientChargeLevelNO.FieldName = "chargeLevelNO";
            this.clientChargeLevelNO.Name = "clientChargeLevelNO";
            this.clientChargeLevelNO.OptionsColumn.AllowFocus = false;
            this.clientChargeLevelNO.Visible = true;
            this.clientChargeLevelNO.VisibleIndex = 5;
            this.clientChargeLevelNO.Width = 82;
            // 
            // GEChargeLevelNO
            // 
            this.GEChargeLevelNO.AutoHeight = false;
            this.GEChargeLevelNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEChargeLevelNO.Name = "GEChargeLevelNO";
            this.GEChargeLevelNO.NullText = "";
            this.GEChargeLevelNO.PopupView = this.gridView5;
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // ClientProvince
            // 
            this.ClientProvince.Caption = "所属省";
            this.ClientProvince.FieldName = "province";
            this.ClientProvince.Name = "ClientProvince";
            this.ClientProvince.OptionsColumn.AllowFocus = false;
            this.ClientProvince.Visible = true;
            this.ClientProvince.VisibleIndex = 6;
            this.ClientProvince.Width = 51;
            // 
            // ClientCity
            // 
            this.ClientCity.Caption = "所属市";
            this.ClientCity.FieldName = "city";
            this.ClientCity.Name = "ClientCity";
            this.ClientCity.OptionsColumn.AllowFocus = false;
            this.ClientCity.Visible = true;
            this.ClientCity.VisibleIndex = 7;
            this.ClientCity.Width = 47;
            // 
            // ClientArea
            // 
            this.ClientArea.Caption = "区域";
            this.ClientArea.FieldName = "area";
            this.ClientArea.Name = "ClientArea";
            this.ClientArea.OptionsColumn.AllowFocus = false;
            this.ClientArea.Visible = true;
            this.ClientArea.VisibleIndex = 8;
            this.ClientArea.Width = 77;
            // 
            // ClientState
            // 
            this.ClientState.Caption = "状态";
            this.ClientState.FieldName = "state";
            this.ClientState.MaxWidth = 50;
            this.ClientState.MinWidth = 50;
            this.ClientState.Name = "ClientState";
            this.ClientState.OptionsColumn.AllowFocus = false;
            this.ClientState.Visible = true;
            this.ClientState.VisibleIndex = 9;
            this.ClientState.Width = 50;
            // 
            // FrmClientShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 490);
            this.Controls.Add(this.GCClientnfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmClientShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户信息列表";
            this.Load += new System.EventHandler(this.FrmClientShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCClientnfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVClientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEPersonNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEChargeLevelNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTClose;
        private DevExpress.XtraGrid.GridControl GCClientnfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVClientInfo;
#pragma warning disable CS0169 // 从不使用字段“FrmClientShow.ID”
        private DevExpress.XtraGrid.Columns.GridColumn ID;
#pragma warning restore CS0169 // 从不使用字段“FrmClientShow.ID”
#pragma warning disable CS0169 // 从不使用字段“FrmClientShow.Check”
        private DevExpress.XtraGrid.Columns.GridColumn Check;
#pragma warning restore CS0169 // 从不使用字段“FrmClientShow.Check”
        private DevExpress.XtraGrid.Columns.GridColumn ClientNO;
        private DevExpress.XtraGrid.Columns.GridColumn clientNames;
        private DevExpress.XtraGrid.Columns.GridColumn clientPerson;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit GEPersonNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn clientShortNames;
        private DevExpress.XtraGrid.Columns.GridColumn clientChargeLevelNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit GEChargeLevelNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn ClientProvince;
        private DevExpress.XtraGrid.Columns.GridColumn ClientCity;
        private DevExpress.XtraGrid.Columns.GridColumn ClientArea;
        private DevExpress.XtraGrid.Columns.GridColumn ClientState;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CBCheck;
        private DevExpress.XtraBars.BarEditItem TEList;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn check;
    }
}