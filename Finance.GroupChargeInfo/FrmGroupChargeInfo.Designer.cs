using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace Finance.GroupChargeInfo
{
    partial class FrmGroupChargeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupChargeInfo));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAddCompany = new DevExpress.XtraBars.BarButtonItem();
            this.BTEditCompany = new DevExpress.XtraBars.BarButtonItem();
            this.BTSaveCompany = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelectCompany = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.agentNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEagentNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hospitalNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEhospitalNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.patientTypeNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEpatientTypeNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.department = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEgroupCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit4View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chargeLevelNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEchargeLevelNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit5View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.standardCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.settlementCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RTEsettlementCharge = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.discountState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.startTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.endTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.creater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.TEdepartment = new DevExpress.XtraEditors.TextEdit();
            this.CEdiscountState = new DevExpress.XtraEditors.CheckEdit();
            this.DEendTime = new DevExpress.XtraEditors.DateEdit();
            this.DEstartTime = new DevExpress.XtraEditors.DateEdit();
            this.TEsettlementCharge = new DevExpress.XtraEditors.TextEdit();
            this.TEstandardCharge = new DevExpress.XtraEditors.TextEdit();
            this.GEchargeLevelNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEgroupCode = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEpatientTypeNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEhospitalNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEagentNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CEState = new DevExpress.XtraEditors.CheckEdit();
            this.DEstartTimes = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GroupInfo = new DevExpress.XtraEditors.GroupControl();
            this.GroupList = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEagentNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEhospitalNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEpatientTypeNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEchargeLevelNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit5View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEsettlementCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEdepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEdiscountState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEendTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEendTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEstartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEstartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsettlementCharge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEstandardCharge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEchargeLevelNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEgroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEpatientTypeNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEhospitalNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEagentNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEstartTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupInfo)).BeginInit();
            this.GroupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupList)).BeginInit();
            this.GroupList.SuspendLayout();
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
            this.BTAddCompany,
            this.BTEditCompany,
            this.BTSaveCompany,
            this.BTDelectCompany});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAddCompany, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTEditCompany, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSaveCompany, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelectCompany, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTAddCompany
            // 
            this.BTAddCompany.Caption = "新增";
            this.BTAddCompany.Id = 0;
            this.BTAddCompany.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTAddCompany.ImageOptions.Image")));
            this.BTAddCompany.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTAddCompany.ImageOptions.LargeImage")));
            this.BTAddCompany.Name = "BTAddCompany";
            this.BTAddCompany.Tag = "16010101";
            this.BTAddCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAddCompany_ItemClick);
            // 
            // BTEditCompany
            // 
            this.BTEditCompany.Caption = "编辑";
            this.BTEditCompany.Id = 1;
            this.BTEditCompany.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTEditCompany.ImageOptions.Image")));
            this.BTEditCompany.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTEditCompany.ImageOptions.LargeImage")));
            this.BTEditCompany.Name = "BTEditCompany";
            this.BTEditCompany.Tag = "16010102";
            this.BTEditCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEditCompany_ItemClick);
            // 
            // BTSaveCompany
            // 
            this.BTSaveCompany.Caption = "保存";
            this.BTSaveCompany.Id = 2;
            this.BTSaveCompany.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSaveCompany.ImageOptions.Image")));
            this.BTSaveCompany.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSaveCompany.ImageOptions.LargeImage")));
            this.BTSaveCompany.Name = "BTSaveCompany";
            this.BTSaveCompany.Tag = "16010103";
            this.BTSaveCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSaveCompany_ItemClick);
            // 
            // BTDelectCompany
            // 
            this.BTDelectCompany.Caption = "删除";
            this.BTDelectCompany.Id = 3;
            this.BTDelectCompany.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTDelectCompany.ImageOptions.Image")));
            this.BTDelectCompany.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTDelectCompany.ImageOptions.LargeImage")));
            this.BTDelectCompany.Name = "BTDelectCompany";
            this.BTDelectCompany.Tag = "16010104";
            this.BTDelectCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelectCompany_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 630);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1128, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 606);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1128, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 606);
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(2, 23);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEagentNO,
            this.RGEhospitalNO,
            this.RGEpatientTypeNO,
            this.RGEgroupCode,
            this.RGEchargeLevelNO,
            this.RTEsettlementCharge});
            this.GCInfo.Size = new System.Drawing.Size(780, 581);
            this.GCInfo.TabIndex = 0;
            this.GCInfo.UseEmbeddedNavigator = true;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            this.GCInfo.Click += new System.EventHandler(this.GCInfo_Click);
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.agentNO,
            this.hospitalNO,
            this.patientTypeNO,
            this.department,
            this.groupCode,
            this.chargeLevelNO,
            this.standardCharge,
            this.settlementCharge,
            this.discountState,
            this.startTime,
            this.endTime,
            this.creater,
            this.createTime,
            this.state});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.OptionsView.ShowGroupPanel = false;
            this.GVInfo.Click += new System.EventHandler(this.gridView1_Click);
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
            // agentNO
            // 
            this.agentNO.Caption = "代理商";
            this.agentNO.ColumnEdit = this.RGEagentNO;
            this.agentNO.FieldName = "agentNO";
            this.agentNO.MinWidth = 10;
            this.agentNO.Name = "agentNO";
            this.agentNO.OptionsColumn.AllowFocus = false;
            this.agentNO.Visible = true;
            this.agentNO.VisibleIndex = 0;
            this.agentNO.Width = 71;
            // 
            // RGEagentNO
            // 
            this.RGEagentNO.AutoHeight = false;
            this.RGEagentNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEagentNO.Name = "RGEagentNO";
            this.RGEagentNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // hospitalNO
            // 
            this.hospitalNO.Caption = "医院名称";
            this.hospitalNO.ColumnEdit = this.RGEhospitalNO;
            this.hospitalNO.FieldName = "hospitalNO";
            this.hospitalNO.MinWidth = 23;
            this.hospitalNO.Name = "hospitalNO";
            this.hospitalNO.OptionsColumn.AllowFocus = false;
            this.hospitalNO.Visible = true;
            this.hospitalNO.VisibleIndex = 1;
            this.hospitalNO.Width = 79;
            // 
            // RGEhospitalNO
            // 
            this.RGEhospitalNO.AutoHeight = false;
            this.RGEhospitalNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEhospitalNO.Name = "RGEhospitalNO";
            this.RGEhospitalNO.PopupView = this.repositoryItemGridLookUpEdit2View;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // patientTypeNO
            // 
            this.patientTypeNO.Caption = "就诊类型";
            this.patientTypeNO.ColumnEdit = this.RGEpatientTypeNO;
            this.patientTypeNO.FieldName = "patientTypeNO";
            this.patientTypeNO.MaxWidth = 100;
            this.patientTypeNO.MinWidth = 50;
            this.patientTypeNO.Name = "patientTypeNO";
            this.patientTypeNO.OptionsColumn.AllowFocus = false;
            this.patientTypeNO.Visible = true;
            this.patientTypeNO.VisibleIndex = 2;
            this.patientTypeNO.Width = 50;
            // 
            // RGEpatientTypeNO
            // 
            this.RGEpatientTypeNO.AutoHeight = false;
            this.RGEpatientTypeNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEpatientTypeNO.Name = "RGEpatientTypeNO";
            this.RGEpatientTypeNO.PopupView = this.repositoryItemGridLookUpEdit3View;
            // 
            // repositoryItemGridLookUpEdit3View
            // 
            this.repositoryItemGridLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit3View.Name = "repositoryItemGridLookUpEdit3View";
            this.repositoryItemGridLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // department
            // 
            this.department.Caption = "送检科室";
            this.department.FieldName = "department";
            this.department.Name = "department";
            this.department.OptionsColumn.AllowFocus = false;
            this.department.Visible = true;
            this.department.VisibleIndex = 3;
            this.department.Width = 31;
            // 
            // groupCode
            // 
            this.groupCode.Caption = "项目名称";
            this.groupCode.ColumnEdit = this.RGEgroupCode;
            this.groupCode.FieldName = "groupCode";
            this.groupCode.Name = "groupCode";
            this.groupCode.OptionsColumn.AllowFocus = false;
            this.groupCode.Visible = true;
            this.groupCode.VisibleIndex = 4;
            this.groupCode.Width = 48;
            // 
            // RGEgroupCode
            // 
            this.RGEgroupCode.AutoHeight = false;
            this.RGEgroupCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgroupCode.Name = "RGEgroupCode";
            this.RGEgroupCode.PopupView = this.repositoryItemGridLookUpEdit4View;
            // 
            // repositoryItemGridLookUpEdit4View
            // 
            this.repositoryItemGridLookUpEdit4View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit4View.Name = "repositoryItemGridLookUpEdit4View";
            this.repositoryItemGridLookUpEdit4View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit4View.OptionsView.ShowGroupPanel = false;
            // 
            // chargeLevelNO
            // 
            this.chargeLevelNO.Caption = "收费等级";
            this.chargeLevelNO.ColumnEdit = this.RGEchargeLevelNO;
            this.chargeLevelNO.FieldName = "chargeLevelNO";
            this.chargeLevelNO.MaxWidth = 80;
            this.chargeLevelNO.MinWidth = 80;
            this.chargeLevelNO.Name = "chargeLevelNO";
            this.chargeLevelNO.OptionsColumn.AllowFocus = false;
            this.chargeLevelNO.Visible = true;
            this.chargeLevelNO.VisibleIndex = 5;
            this.chargeLevelNO.Width = 80;
            // 
            // RGEchargeLevelNO
            // 
            this.RGEchargeLevelNO.AutoHeight = false;
            this.RGEchargeLevelNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEchargeLevelNO.Name = "RGEchargeLevelNO";
            this.RGEchargeLevelNO.PopupView = this.repositoryItemGridLookUpEdit5View;
            // 
            // repositoryItemGridLookUpEdit5View
            // 
            this.repositoryItemGridLookUpEdit5View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit5View.Name = "repositoryItemGridLookUpEdit5View";
            this.repositoryItemGridLookUpEdit5View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit5View.OptionsView.ShowGroupPanel = false;
            // 
            // standardCharge
            // 
            this.standardCharge.Caption = "标准价格";
            this.standardCharge.FieldName = "standardCharge";
            this.standardCharge.MaxWidth = 90;
            this.standardCharge.MinWidth = 90;
            this.standardCharge.Name = "standardCharge";
            this.standardCharge.OptionsColumn.AllowFocus = false;
            this.standardCharge.Visible = true;
            this.standardCharge.VisibleIndex = 6;
            this.standardCharge.Width = 90;
            // 
            // settlementCharge
            // 
            this.settlementCharge.Caption = "结算价格";
            this.settlementCharge.ColumnEdit = this.RTEsettlementCharge;
            this.settlementCharge.FieldName = "settlementCharge";
            this.settlementCharge.MaxWidth = 90;
            this.settlementCharge.MinWidth = 90;
            this.settlementCharge.Name = "settlementCharge";
            this.settlementCharge.OptionsColumn.AllowFocus = false;
            this.settlementCharge.Visible = true;
            this.settlementCharge.VisibleIndex = 7;
            this.settlementCharge.Width = 90;
            // 
            // RTEsettlementCharge
            // 
            this.RTEsettlementCharge.AutoHeight = false;
            this.RTEsettlementCharge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RTEsettlementCharge.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.RTEsettlementCharge.Name = "RTEsettlementCharge";
            // 
            // discountState
            // 
            this.discountState.Caption = "折扣";
            this.discountState.FieldName = "discountState";
            this.discountState.MaxWidth = 35;
            this.discountState.MinWidth = 35;
            this.discountState.Name = "discountState";
            this.discountState.OptionsColumn.AllowFocus = false;
            this.discountState.Visible = true;
            this.discountState.VisibleIndex = 8;
            this.discountState.Width = 35;
            // 
            // startTime
            // 
            this.startTime.Caption = "起始时间";
            this.startTime.FieldName = "startTime";
            this.startTime.MaxWidth = 80;
            this.startTime.MinWidth = 80;
            this.startTime.Name = "startTime";
            this.startTime.OptionsColumn.AllowFocus = false;
            this.startTime.Width = 80;
            // 
            // endTime
            // 
            this.endTime.Caption = "终止时间";
            this.endTime.FieldName = "endTime";
            this.endTime.MaxWidth = 80;
            this.endTime.MinWidth = 80;
            this.endTime.Name = "endTime";
            this.endTime.OptionsColumn.AllowFocus = false;
            this.endTime.Width = 80;
            // 
            // creater
            // 
            this.creater.Caption = "创建者";
            this.creater.FieldName = "creater";
            this.creater.MaxWidth = 80;
            this.creater.MinWidth = 80;
            this.creater.Name = "creater";
            this.creater.OptionsColumn.AllowFocus = false;
            this.creater.Visible = true;
            this.creater.VisibleIndex = 9;
            this.creater.Width = 80;
            // 
            // createTime
            // 
            this.createTime.Caption = "创建时间";
            this.createTime.FieldName = "createTime";
            this.createTime.MaxWidth = 80;
            this.createTime.MinWidth = 80;
            this.createTime.Name = "createTime";
            this.createTime.OptionsColumn.AllowFocus = false;
            this.createTime.Visible = true;
            this.createTime.VisibleIndex = 10;
            this.createTime.Width = 80;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 35;
            this.state.MinWidth = 35;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 11;
            this.state.Width = 35;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.TEdepartment);
            this.layoutControl1.Controls.Add(this.CEdiscountState);
            this.layoutControl1.Controls.Add(this.DEendTime);
            this.layoutControl1.Controls.Add(this.DEstartTime);
            this.layoutControl1.Controls.Add(this.TEsettlementCharge);
            this.layoutControl1.Controls.Add(this.TEstandardCharge);
            this.layoutControl1.Controls.Add(this.GEchargeLevelNO);
            this.layoutControl1.Controls.Add(this.GEgroupCode);
            this.layoutControl1.Controls.Add(this.GEpatientTypeNO);
            this.layoutControl1.Controls.Add(this.GEhospitalNO);
            this.layoutControl1.Controls.Add(this.GEagentNO);
            this.layoutControl1.Controls.Add(this.CEState);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.DEstartTimes,
            this.layoutControlItem9});
            this.layoutControl1.Location = new System.Drawing.Point(2, 23);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(886, 294, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(330, 581);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // TEdepartment
            // 
            this.TEdepartment.Location = new System.Drawing.Point(75, 84);
            this.TEdepartment.MenuManager = this.barManager1;
            this.TEdepartment.Name = "TEdepartment";
            this.TEdepartment.Size = new System.Drawing.Size(243, 20);
            this.TEdepartment.StyleController = this.layoutControl1;
            this.TEdepartment.TabIndex = 25;
            // 
            // CEdiscountState
            // 
            this.CEdiscountState.Location = new System.Drawing.Point(75, 204);
            this.CEdiscountState.MenuManager = this.barManager1;
            this.CEdiscountState.Name = "CEdiscountState";
            this.CEdiscountState.Properties.Caption = "启用";
            this.CEdiscountState.Size = new System.Drawing.Size(243, 20);
            this.CEdiscountState.StyleController = this.layoutControl1;
            this.CEdiscountState.TabIndex = 24;
            // 
            // DEendTime
            // 
            this.DEendTime.EditValue = null;
            this.DEendTime.Location = new System.Drawing.Point(75, 204);
            this.DEendTime.MenuManager = this.barManager1;
            this.DEendTime.Name = "DEendTime";
            this.DEendTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEendTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEendTime.Properties.DisplayFormat.FormatString = "g";
            this.DEendTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEendTime.Properties.EditFormat.FormatString = "g";
            this.DEendTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEendTime.Properties.Mask.EditMask = "g";
            this.DEendTime.Size = new System.Drawing.Size(243, 20);
            this.DEendTime.StyleController = this.layoutControl1;
            this.DEendTime.TabIndex = 23;
            // 
            // DEstartTime
            // 
            this.DEstartTime.EditValue = null;
            this.DEstartTime.Location = new System.Drawing.Point(75, 204);
            this.DEstartTime.MenuManager = this.barManager1;
            this.DEstartTime.Name = "DEstartTime";
            this.DEstartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEstartTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEstartTime.Properties.DisplayFormat.FormatString = "g";
            this.DEstartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEstartTime.Properties.EditFormat.FormatString = "g";
            this.DEstartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEstartTime.Properties.Mask.EditMask = "g";
            this.DEstartTime.Size = new System.Drawing.Size(243, 20);
            this.DEstartTime.StyleController = this.layoutControl1;
            this.DEstartTime.TabIndex = 22;
            // 
            // TEsettlementCharge
            // 
            this.TEsettlementCharge.Location = new System.Drawing.Point(75, 180);
            this.TEsettlementCharge.MenuManager = this.barManager1;
            this.TEsettlementCharge.Name = "TEsettlementCharge";
            this.TEsettlementCharge.Size = new System.Drawing.Size(243, 20);
            this.TEsettlementCharge.StyleController = this.layoutControl1;
            this.TEsettlementCharge.TabIndex = 21;
            // 
            // TEstandardCharge
            // 
            this.TEstandardCharge.Location = new System.Drawing.Point(75, 156);
            this.TEstandardCharge.MenuManager = this.barManager1;
            this.TEstandardCharge.Name = "TEstandardCharge";
            this.TEstandardCharge.Size = new System.Drawing.Size(243, 20);
            this.TEstandardCharge.StyleController = this.layoutControl1;
            this.TEstandardCharge.TabIndex = 20;
            // 
            // GEchargeLevelNO
            // 
            this.GEchargeLevelNO.Location = new System.Drawing.Point(75, 132);
            this.GEchargeLevelNO.MenuManager = this.barManager1;
            this.GEchargeLevelNO.Name = "GEchargeLevelNO";
            this.GEchargeLevelNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEchargeLevelNO.Properties.PopupView = this.gridView4;
            this.GEchargeLevelNO.Size = new System.Drawing.Size(243, 20);
            this.GEchargeLevelNO.StyleController = this.layoutControl1;
            this.GEchargeLevelNO.TabIndex = 19;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // GEgroupCode
            // 
            this.GEgroupCode.Location = new System.Drawing.Point(75, 108);
            this.GEgroupCode.MenuManager = this.barManager1;
            this.GEgroupCode.Name = "GEgroupCode";
            this.GEgroupCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEgroupCode.Properties.PopupView = this.gridView3;
            this.GEgroupCode.Size = new System.Drawing.Size(243, 20);
            this.GEgroupCode.StyleController = this.layoutControl1;
            this.GEgroupCode.TabIndex = 18;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // GEpatientTypeNO
            // 
            this.GEpatientTypeNO.Location = new System.Drawing.Point(75, 60);
            this.GEpatientTypeNO.MenuManager = this.barManager1;
            this.GEpatientTypeNO.Name = "GEpatientTypeNO";
            this.GEpatientTypeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEpatientTypeNO.Properties.PopupView = this.gridView2;
            this.GEpatientTypeNO.Size = new System.Drawing.Size(243, 20);
            this.GEpatientTypeNO.StyleController = this.layoutControl1;
            this.GEpatientTypeNO.TabIndex = 17;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // GEhospitalNO
            // 
            this.GEhospitalNO.Location = new System.Drawing.Point(75, 36);
            this.GEhospitalNO.MenuManager = this.barManager1;
            this.GEhospitalNO.Name = "GEhospitalNO";
            this.GEhospitalNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEhospitalNO.Properties.PopupView = this.gridView1;
            this.GEhospitalNO.Size = new System.Drawing.Size(243, 20);
            this.GEhospitalNO.StyleController = this.layoutControl1;
            this.GEhospitalNO.TabIndex = 16;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // GEagentNO
            // 
            this.GEagentNO.Location = new System.Drawing.Point(75, 12);
            this.GEagentNO.MenuManager = this.barManager1;
            this.GEagentNO.Name = "GEagentNO";
            this.GEagentNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEagentNO.Properties.PopupView = this.gridLookUpEdit1View;
            this.GEagentNO.Size = new System.Drawing.Size(243, 20);
            this.GEagentNO.StyleController = this.layoutControl1;
            this.GEagentNO.TabIndex = 15;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // CEState
            // 
            this.CEState.Location = new System.Drawing.Point(75, 228);
            this.CEState.MenuManager = this.barManager1;
            this.CEState.Name = "CEState";
            this.CEState.Properties.Caption = "启用";
            this.CEState.Size = new System.Drawing.Size(243, 20);
            this.CEState.StyleController = this.layoutControl1;
            this.CEState.TabIndex = 14;
            // 
            // DEstartTimes
            // 
            this.DEstartTimes.Control = this.DEstartTime;
            this.DEstartTimes.Location = new System.Drawing.Point(0, 192);
            this.DEstartTimes.Name = "DEstartTimes";
            this.DEstartTimes.Size = new System.Drawing.Size(310, 24);
            this.DEstartTimes.Text = "起始时间:";
            this.DEstartTimes.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.DEendTime;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem9.Text = "终止时间:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem11,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem10,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(330, 581);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 240);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(310, 321);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.CEState;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 216);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem11.Text = "是否启用:";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GEagentNO;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem1.Text = "代  理 商:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.GEhospitalNO;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem2.Text = "医院名称:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.GEpatientTypeNO;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem3.Text = "就诊类型:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.GEgroupCode;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem4.Text = "项目编码:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.GEchargeLevelNO;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem5.Text = "收费等级:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.TEstandardCharge;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem6.Text = "标准价格:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem7.Control = this.TEsettlementCharge;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem7.Text = "结算价格:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.CEdiscountState;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem10.Text = "参与折扣:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.TEdepartment;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem8.Text = "送检科室:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(60, 14);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.GroupInfo);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GroupList);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1128, 606);
            this.splitContainerControl1.SplitterPosition = 334;
            this.splitContainerControl1.TabIndex = 14;
            // 
            // GroupInfo
            // 
            this.GroupInfo.Controls.Add(this.layoutControl1);
            this.GroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupInfo.Location = new System.Drawing.Point(0, 0);
            this.GroupInfo.Name = "GroupInfo";
            this.GroupInfo.Size = new System.Drawing.Size(334, 606);
            this.GroupInfo.TabIndex = 0;
            this.GroupInfo.Text = "详细信息";
            // 
            // GroupList
            // 
            this.GroupList.Controls.Add(this.GCInfo);
            this.GroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupList.Location = new System.Drawing.Point(0, 0);
            this.GroupList.Name = "GroupList";
            this.GroupList.Size = new System.Drawing.Size(784, 606);
            this.GroupList.TabIndex = 0;
            this.GroupList.Text = "信息列表";
            // 
            // FrmGroupChargeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 630);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmGroupChargeInfo";
            this.Text = "价格管理";
            this.Load += new System.EventHandler(this.FrmCompanyinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEagentNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEhospitalNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEpatientTypeNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEchargeLevelNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit5View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEsettlementCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TEdepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEdiscountState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEendTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEendTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEstartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEstartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsettlementCharge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEstandardCharge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEchargeLevelNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEgroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEpatientTypeNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEhospitalNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEagentNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEstartTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupInfo)).EndInit();
            this.GroupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupList)).EndInit();
            this.GroupList.ResumeLayout(false);
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
        private DevExpress.XtraBars.BarButtonItem BTAddCompany;
        private DevExpress.XtraBars.BarButtonItem BTEditCompany;
        private DevExpress.XtraBars.BarButtonItem BTSaveCompany;
        private DevExpress.XtraBars.BarButtonItem BTDelectCompany;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.CheckEdit CEState;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn agentNO;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNO;
        private DevExpress.XtraGrid.Columns.GridColumn patientTypeNO;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl GroupList;
        private DevExpress.XtraEditors.GroupControl GroupInfo;
        private CheckEdit CEdiscountState;
        private DateEdit DEendTime;
        private DateEdit DEstartTime;
        private TextEdit TEsettlementCharge;
        private TextEdit TEstandardCharge;
        private GridLookUpEdit GEchargeLevelNO;
        private GridView gridView4;
        private GridLookUpEdit GEgroupCode;
        private GridView gridView3;
        private GridLookUpEdit GEpatientTypeNO;
        private GridView gridView2;
        private GridLookUpEdit GEhospitalNO;
        private GridView gridView1;
        private GridLookUpEdit GEagentNO;
        private GridView gridLookUpEdit1View;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem6;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem DEstartTimes;
        private LayoutControlItem layoutControlItem9;
        private LayoutControlItem layoutControlItem10;
        private GridColumn groupCode;
        private GridColumn chargeLevelNO;
        private GridColumn standardCharge;
        private GridColumn settlementCharge;
        private GridColumn discountState;
        private GridColumn startTime;
        private GridColumn state;
        private TextEdit TEdepartment;
        private LayoutControlItem layoutControlItem8;
        private GridColumn department;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEagentNO;
        private GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEhospitalNO;
        private GridView repositoryItemGridLookUpEdit2View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEpatientTypeNO;
        private GridView repositoryItemGridLookUpEdit3View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgroupCode;
        private GridView repositoryItemGridLookUpEdit4View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEchargeLevelNO;
        private GridView repositoryItemGridLookUpEdit5View;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RTEsettlementCharge;
        private GridColumn endTime;
        private GridColumn creater;
        private GridColumn createTime;
    }
}