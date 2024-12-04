namespace WorkComm.Clients
{
    partial class FrmAgentPower
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgentPower));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GCAgentInfo = new DevExpress.XtraGrid.GridControl();
            this.GVAgentInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.agentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AgentNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AgentNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AgentPersonNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEAgentPersonNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AgentShortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AgentState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GCClientnfo = new DevExpress.XtraGrid.GridControl();
            this.GVClientInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEClientPersonNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClientShortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientChargeLevelNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEClientLevelNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClientProvince = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClientState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Agentsort = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCAgentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVAgentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEAgentPersonNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCClientnfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVClientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEClientPersonNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEClientLevelNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
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
            this.BTAdd});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "编辑";
            this.BTAdd.Id = 0;
            this.BTAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.Image")));
            this.BTAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.LargeImage")));
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.Tag = "10010101";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1789, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 862);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1789, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 832);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1789, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 832);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1789, 832);
            this.splitContainer1.SplitterDistance = 729;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GCAgentInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(729, 832);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
            // 
            // GCAgentInfo
            // 
            this.GCAgentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCAgentInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCAgentInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCAgentInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCAgentInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCAgentInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCAgentInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GCAgentInfo.Location = new System.Drawing.Point(4, 23);
            this.GCAgentInfo.MainView = this.GVAgentInfo;
            this.GCAgentInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GCAgentInfo.MenuManager = this.barManager1;
            this.GCAgentInfo.Name = "GCAgentInfo";
            this.GCAgentInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEAgentPersonNO});
            this.GCAgentInfo.Size = new System.Drawing.Size(721, 805);
            this.GCAgentInfo.TabIndex = 2;
            this.GCAgentInfo.UseEmbeddedNavigator = true;
            this.GCAgentInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVAgentInfo});
            // 
            // GVAgentInfo
            // 
            this.GVAgentInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.agentID,
            this.AgentNO,
            this.AgentNames,
            this.AgentPersonNO,
            this.AgentShortNames,
            this.AgentState,
            this.Agentsort});
            this.GVAgentInfo.DetailHeight = 525;
            this.GVAgentInfo.FixedLineWidth = 3;
            this.GVAgentInfo.GridControl = this.GCAgentInfo;
            this.GVAgentInfo.Name = "GVAgentInfo";
            this.GVAgentInfo.OptionsFind.AlwaysVisible = true;
            this.GVAgentInfo.OptionsFind.ShowCloseButton = false;
            this.GVAgentInfo.OptionsView.ShowGroupPanel = false;
            // 
            // agentID
            // 
            this.agentID.Caption = "id";
            this.agentID.FieldName = "id";
            this.agentID.MinWidth = 27;
            this.agentID.Name = "agentID";
            this.agentID.OptionsColumn.AllowFocus = false;
            this.agentID.Width = 100;
            // 
            // AgentNO
            // 
            this.AgentNO.Caption = "编号";
            this.AgentNO.FieldName = "no";
            this.AgentNO.MinWidth = 27;
            this.AgentNO.Name = "AgentNO";
            this.AgentNO.OptionsColumn.AllowFocus = false;
            this.AgentNO.Visible = true;
            this.AgentNO.VisibleIndex = 0;
            this.AgentNO.Width = 104;
            // 
            // AgentNames
            // 
            this.AgentNames.Caption = "代理商名称";
            this.AgentNames.FieldName = "names";
            this.AgentNames.MinWidth = 27;
            this.AgentNames.Name = "AgentNames";
            this.AgentNames.OptionsColumn.AllowFocus = false;
            this.AgentNames.Visible = true;
            this.AgentNames.VisibleIndex = 1;
            this.AgentNames.Width = 200;
            // 
            // AgentPersonNO
            // 
            this.AgentPersonNO.Caption = "负责人";
            this.AgentPersonNO.ColumnEdit = this.RGEAgentPersonNO;
            this.AgentPersonNO.FieldName = "personNO";
            this.AgentPersonNO.MinWidth = 27;
            this.AgentPersonNO.Name = "AgentPersonNO";
            this.AgentPersonNO.OptionsColumn.AllowFocus = false;
            this.AgentPersonNO.Visible = true;
            this.AgentPersonNO.VisibleIndex = 3;
            this.AgentPersonNO.Width = 107;
            // 
            // RGEAgentPersonNO
            // 
            this.RGEAgentPersonNO.AutoHeight = false;
            this.RGEAgentPersonNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEAgentPersonNO.Name = "RGEAgentPersonNO";
            this.RGEAgentPersonNO.PopupView = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 525;
            this.gridView3.FixedLineWidth = 3;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // AgentShortNames
            // 
            this.AgentShortNames.Caption = "名称简拼";
            this.AgentShortNames.FieldName = "shortNames";
            this.AgentShortNames.MinWidth = 27;
            this.AgentShortNames.Name = "AgentShortNames";
            this.AgentShortNames.OptionsColumn.AllowFocus = false;
            this.AgentShortNames.Visible = true;
            this.AgentShortNames.VisibleIndex = 2;
            this.AgentShortNames.Width = 212;
            // 
            // AgentState
            // 
            this.AgentState.Caption = "状态";
            this.AgentState.FieldName = "state";
            this.AgentState.MaxWidth = 80;
            this.AgentState.MinWidth = 45;
            this.AgentState.Name = "AgentState";
            this.AgentState.OptionsColumn.AllowFocus = false;
            this.AgentState.Visible = true;
            this.AgentState.VisibleIndex = 4;
            this.AgentState.Width = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GCClientnfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1055, 832);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户列表";
            // 
            // GCClientnfo
            // 
            this.GCClientnfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCClientnfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCClientnfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GCClientnfo.Location = new System.Drawing.Point(4, 23);
            this.GCClientnfo.MainView = this.GVClientInfo;
            this.GCClientnfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GCClientnfo.MenuManager = this.barManager1;
            this.GCClientnfo.Name = "GCClientnfo";
            this.GCClientnfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEClientPersonNO,
            this.RGEClientLevelNO});
            this.GCClientnfo.Size = new System.Drawing.Size(1047, 805);
            this.GCClientnfo.TabIndex = 1;
            this.GCClientnfo.UseEmbeddedNavigator = true;
            this.GCClientnfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVClientInfo});
            // 
            // GVClientInfo
            // 
            this.GVClientInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.ClientNO,
            this.ClientNames,
            this.ClientPerson,
            this.ClientShortNames,
            this.ClientChargeLevelNO,
            this.ClientProvince,
            this.ClientCity,
            this.ClientArea,
            this.ClientState});
            this.GVClientInfo.DetailHeight = 525;
            this.GVClientInfo.FixedLineWidth = 3;
            this.GVClientInfo.GridControl = this.GCClientnfo;
            this.GVClientInfo.Name = "GVClientInfo";
            this.GVClientInfo.OptionsFind.AlwaysVisible = true;
            this.GVClientInfo.OptionsFind.ShowCloseButton = false;
            this.GVClientInfo.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 27;
            this.id.Name = "id";
            this.id.Width = 100;
            // 
            // ClientNO
            // 
            this.ClientNO.Caption = "编号";
            this.ClientNO.FieldName = "no";
            this.ClientNO.MinWidth = 27;
            this.ClientNO.Name = "ClientNO";
            this.ClientNO.OptionsColumn.AllowFocus = false;
            this.ClientNO.Visible = true;
            this.ClientNO.VisibleIndex = 0;
            this.ClientNO.Width = 39;
            // 
            // ClientNames
            // 
            this.ClientNames.Caption = "客户名称";
            this.ClientNames.FieldName = "names";
            this.ClientNames.MinWidth = 27;
            this.ClientNames.Name = "ClientNames";
            this.ClientNames.OptionsColumn.AllowFocus = false;
            this.ClientNames.Visible = true;
            this.ClientNames.VisibleIndex = 1;
            this.ClientNames.Width = 139;
            // 
            // ClientPerson
            // 
            this.ClientPerson.Caption = "负责人";
            this.ClientPerson.ColumnEdit = this.RGEClientPersonNO;
            this.ClientPerson.FieldName = "personNO";
            this.ClientPerson.MinWidth = 27;
            this.ClientPerson.Name = "ClientPerson";
            this.ClientPerson.OptionsColumn.AllowFocus = false;
            this.ClientPerson.Visible = true;
            this.ClientPerson.VisibleIndex = 3;
            this.ClientPerson.Width = 73;
            // 
            // RGEClientPersonNO
            // 
            this.RGEClientPersonNO.AutoHeight = false;
            this.RGEClientPersonNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEClientPersonNO.Name = "RGEClientPersonNO";
            this.RGEClientPersonNO.PopupView = this.gridView4;
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 525;
            this.gridView4.FixedLineWidth = 3;
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // ClientShortNames
            // 
            this.ClientShortNames.Caption = "名称简拼";
            this.ClientShortNames.FieldName = "shortNames";
            this.ClientShortNames.MinWidth = 27;
            this.ClientShortNames.Name = "ClientShortNames";
            this.ClientShortNames.OptionsColumn.AllowFocus = false;
            this.ClientShortNames.Visible = true;
            this.ClientShortNames.VisibleIndex = 2;
            this.ClientShortNames.Width = 147;
            // 
            // ClientChargeLevelNO
            // 
            this.ClientChargeLevelNO.Caption = "收费级别";
            this.ClientChargeLevelNO.ColumnEdit = this.RGEClientLevelNO;
            this.ClientChargeLevelNO.FieldName = "chargeLevelNO";
            this.ClientChargeLevelNO.MinWidth = 27;
            this.ClientChargeLevelNO.Name = "ClientChargeLevelNO";
            this.ClientChargeLevelNO.OptionsColumn.AllowFocus = false;
            this.ClientChargeLevelNO.Visible = true;
            this.ClientChargeLevelNO.VisibleIndex = 4;
            this.ClientChargeLevelNO.Width = 79;
            // 
            // RGEClientLevelNO
            // 
            this.RGEClientLevelNO.AutoHeight = false;
            this.RGEClientLevelNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEClientLevelNO.Name = "RGEClientLevelNO";
            this.RGEClientLevelNO.PopupView = this.repositoryItemGridLookUpEdit2View;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.DetailHeight = 525;
            this.repositoryItemGridLookUpEdit2View.FixedLineWidth = 3;
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // ClientProvince
            // 
            this.ClientProvince.Caption = "所属省";
            this.ClientProvince.FieldName = "province";
            this.ClientProvince.MinWidth = 27;
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
            this.ClientCity.MinWidth = 27;
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
            this.ClientArea.MinWidth = 27;
            this.ClientArea.Name = "ClientArea";
            this.ClientArea.OptionsColumn.AllowFocus = false;
            this.ClientArea.Visible = true;
            this.ClientArea.VisibleIndex = 8;
            this.ClientArea.Width = 60;
            // 
            // ClientState
            // 
            this.ClientState.Caption = "状态";
            this.ClientState.FieldName = "state";
            this.ClientState.MinWidth = 27;
            this.ClientState.Name = "ClientState";
            this.ClientState.OptionsColumn.AllowFocus = false;
            this.ClientState.Visible = true;
            this.ClientState.VisibleIndex = 5;
            this.ClientState.Width = 64;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "区域";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "区域";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 50;
            // 
            // Agentsort
            // 
            this.Agentsort.Caption = "排序";
            this.Agentsort.FieldName = "sort";
            this.Agentsort.MaxWidth = 80;
            this.Agentsort.MinWidth = 45;
            this.Agentsort.Name = "Agentsort";
            this.Agentsort.OptionsColumn.AllowFocus = false;
            this.Agentsort.Visible = true;
            this.Agentsort.VisibleIndex = 5;
            this.Agentsort.Width = 45;
            // 
            // FrmAgentPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 862);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAgentPower";
            this.Text = "FrmAgentPower";
            this.Load += new System.EventHandler(this.Frminfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCAgentInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVAgentInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEAgentPersonNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCClientnfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVClientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEClientPersonNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEClientLevelNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTAdd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl GCClientnfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVClientInfo;
#pragma warning disable CS0169 // 从不使用字段“FrmAgentPower.ID”
        private DevExpress.XtraGrid.Columns.GridColumn ID;
#pragma warning restore CS0169 // 从不使用字段“FrmAgentPower.ID”
        private DevExpress.XtraGrid.Columns.GridColumn ClientNO;
        private DevExpress.XtraGrid.Columns.GridColumn ClientNames;
        private DevExpress.XtraGrid.Columns.GridColumn ClientPerson;
        private DevExpress.XtraGrid.Columns.GridColumn ClientState;
        private DevExpress.XtraGrid.Columns.GridColumn ClientShortNames;
        private DevExpress.XtraGrid.Columns.GridColumn ClientArea;
        private DevExpress.XtraGrid.Columns.GridColumn ClientProvince;
        private DevExpress.XtraGrid.Columns.GridColumn ClientCity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn ClientChargeLevelNO;
        private DevExpress.XtraGrid.GridControl GCAgentInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVAgentInfo;
        private DevExpress.XtraGrid.Columns.GridColumn agentID;
        private DevExpress.XtraGrid.Columns.GridColumn AgentNO;
        private DevExpress.XtraGrid.Columns.GridColumn AgentNames;
        private DevExpress.XtraGrid.Columns.GridColumn AgentPersonNO;
        private DevExpress.XtraGrid.Columns.GridColumn AgentShortNames;
        private DevExpress.XtraGrid.Columns.GridColumn AgentState;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEAgentPersonNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEClientPersonNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEClientLevelNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private DevExpress.XtraGrid.Columns.GridColumn Agentsort;
    }
}