using DevExpress.XtraEditors.Repository;

namespace WorkComm.Groups
{
    partial class FrmTestGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestGroup));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BTEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelect = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.workNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEworkNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.基础信息配置 = new DevExpress.XtraTab.XtraTabPage();
            this.groupInfo = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CBRCEqual = new DevExpress.XtraEditors.CheckEdit();
            this.CBTCEqual = new DevExpress.XtraEditors.CheckEdit();
            this.CBTREqual = new DevExpress.XtraEditors.CheckEdit();
            this.CBReviewState = new DevExpress.XtraEditors.CheckEdit();
            this.BTUpLoadFile = new System.Windows.Forms.Button();
            this.TEno = new DevExpress.XtraEditors.TextEdit();
            this.TEnames = new DevExpress.XtraEditors.TextEdit();
            this.TEPhone = new DevExpress.XtraEditors.TextEdit();
            this.TERemark = new DevExpress.XtraEditors.MemoEdit();
            this.TEFunctions = new DevExpress.XtraEditors.MemoEdit();
            this.TESort = new DevExpress.XtraEditors.TextEdit();
            this.CBState = new DevExpress.XtraEditors.CheckEdit();
            this.PEItemImg = new DevExpress.XtraEditors.PictureEdit();
            this.GEtestPreson = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEratifier = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEworkNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.TEDepartment = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.BTAddGroup = new System.Windows.Forms.ToolStripButton();
            this.BTEditGroup = new System.Windows.Forms.ToolStripButton();
            this.BTSaveGroup = new System.Windows.Forms.ToolStripButton();
            this.BTDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.列表信息配置 = new DevExpress.XtraTab.XtraTabPage();
            this.GCGroupGrid = new DevExpress.XtraGrid.GridControl();
            this.GVGroupGird = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WorkNOs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ControlType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEcontrolType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ControlNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FieldNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Captions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ControlVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ControlEnabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AllFocus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AllowEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReadOnly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Width = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BandTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BandType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.states = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTAddColumns = new System.Windows.Forms.ToolStripButton();
            this.BTEditColumns = new System.Windows.Forms.ToolStripButton();
            this.BTASaveColumns = new System.Windows.Forms.ToolStripButton();
            this.BTDeleteColumns = new System.Windows.Forms.ToolStripButton();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEworkNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.基础信息配置.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBRCEqual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBTCEqual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBTREqual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBReviewState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEnames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TERemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFunctions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PEItemImg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEtestPreson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEratifier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEworkNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.列表信息配置.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVGroupGird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEcontrolType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
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
            this.BTAdd,
            this.BTEdit,
            this.BTSave,
            this.BTDelect});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "新增";
            this.BTAdd.Id = 0;
            this.BTAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.Image")));
            this.BTAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.LargeImage")));
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.Tag = "11020201";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑";
            this.BTEdit.Id = 1;
            this.BTEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.Image")));
            this.BTEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.LargeImage")));
            this.BTEdit.Name = "BTEdit";
            this.BTEdit.Tag = "11020202";
            this.BTEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEdit_ItemClick);
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 2;
            this.BTSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.Image")));
            this.BTSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.LargeImage")));
            this.BTSave.Name = "BTSave";
            this.BTSave.Tag = "11020203";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSaveCompany_ItemClick);
            // 
            // BTDelect
            // 
            this.BTDelect.Caption = "删除";
            this.BTDelect.Id = 3;
            this.BTDelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTDelect.ImageOptions.Image")));
            this.BTDelect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTDelect.ImageOptions.LargeImage")));
            this.BTDelect.Name = "BTDelect";
            this.BTDelect.Tag = "11020204";
            this.BTDelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelect_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1331, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 780);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1331, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 756);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1331, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 756);
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfo.Location = new System.Drawing.Point(2, 23);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.RGEworkNO,
            this.repositoryItemCheckEdit1});
            this.GCInfo.Size = new System.Drawing.Size(346, 731);
            this.GCInfo.TabIndex = 0;
            this.GCInfo.UseEmbeddedNavigator = true;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.names,
            this.workNO,
            this.gridColumn1,
            this.state});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.GroupCount = 1;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.OptionsView.ShowGroupPanel = false;
            this.GVInfo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.workNO, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.GVInfo.Click += new System.EventHandler(this.gridControl1_Click);
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
            this.no.MaxWidth = 58;
            this.no.MinWidth = 58;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 58;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 23;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            this.names.Width = 219;
            // 
            // workNO
            // 
            this.workNO.Caption = "工作组名称";
            this.workNO.ColumnEdit = this.RGEworkNO;
            this.workNO.FieldName = "workNO";
            this.workNO.MinWidth = 23;
            this.workNO.Name = "workNO";
            this.workNO.OptionsColumn.AllowFocus = false;
            this.workNO.Visible = true;
            this.workNO.VisibleIndex = 2;
            this.workNO.Width = 87;
            // 
            // RGEworkNO
            // 
            this.RGEworkNO.AutoHeight = false;
            this.RGEworkNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEworkNO.Name = "RGEworkNO";
            this.RGEworkNO.NullText = "";
            this.RGEworkNO.PopupView = this.gridView4;
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 408;
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "排序";
            this.gridColumn1.FieldName = "sort";
            this.gridColumn1.MaxWidth = 70;
            this.gridColumn1.MinWidth = 39;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 39;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.ColumnEdit = this.repositoryItemCheckEdit1;
            this.state.FieldName = "State";
            this.state.MaxWidth = 70;
            this.state.MinWidth = 39;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 3;
            this.state.Width = 39;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.基础信息配置;
            this.xtraTabControl1.Size = new System.Drawing.Size(971, 756);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.基础信息配置,
            this.列表信息配置});
            // 
            // 基础信息配置
            // 
            this.基础信息配置.Controls.Add(this.groupInfo);
            this.基础信息配置.Controls.Add(this.toolStrip2);
            this.基础信息配置.Name = "基础信息配置";
            this.基础信息配置.Size = new System.Drawing.Size(969, 730);
            this.基础信息配置.Text = "基础信息配置";
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.layoutControl1);
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInfo.Location = new System.Drawing.Point(0, 27);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(969, 703);
            this.groupInfo.TabIndex = 3;
            this.groupInfo.Text = "详细信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CBRCEqual);
            this.layoutControl1.Controls.Add(this.CBTCEqual);
            this.layoutControl1.Controls.Add(this.CBTREqual);
            this.layoutControl1.Controls.Add(this.CBReviewState);
            this.layoutControl1.Controls.Add(this.BTUpLoadFile);
            this.layoutControl1.Controls.Add(this.TEno);
            this.layoutControl1.Controls.Add(this.TEnames);
            this.layoutControl1.Controls.Add(this.TEPhone);
            this.layoutControl1.Controls.Add(this.TERemark);
            this.layoutControl1.Controls.Add(this.TEFunctions);
            this.layoutControl1.Controls.Add(this.TESort);
            this.layoutControl1.Controls.Add(this.CBState);
            this.layoutControl1.Controls.Add(this.PEItemImg);
            this.layoutControl1.Controls.Add(this.GEtestPreson);
            this.layoutControl1.Controls.Add(this.GEratifier);
            this.layoutControl1.Controls.Add(this.GEworkNO);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 23);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(877, 294, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(965, 678);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CBRCEqual
            // 
            this.CBRCEqual.Location = new System.Drawing.Point(206, 596);
            this.CBRCEqual.Name = "CBRCEqual";
            this.CBRCEqual.Properties.Caption = "允许复审者/审核者相同";
            this.CBRCEqual.Size = new System.Drawing.Size(192, 20);
            this.CBRCEqual.StyleController = this.layoutControl1;
            this.CBRCEqual.TabIndex = 25;
            // 
            // CBTCEqual
            // 
            this.CBTCEqual.Location = new System.Drawing.Point(12, 596);
            this.CBTCEqual.Name = "CBTCEqual";
            this.CBTCEqual.Properties.Caption = "允许检验者/审核者相同";
            this.CBTCEqual.Size = new System.Drawing.Size(190, 20);
            this.CBTCEqual.StyleController = this.layoutControl1;
            this.CBTCEqual.TabIndex = 24;
            // 
            // CBTREqual
            // 
            this.CBTREqual.Location = new System.Drawing.Point(206, 572);
            this.CBTREqual.Name = "CBTREqual";
            this.CBTREqual.Properties.Caption = "允许检验者/复审者相同";
            this.CBTREqual.Size = new System.Drawing.Size(192, 20);
            this.CBTREqual.StyleController = this.layoutControl1;
            this.CBTREqual.TabIndex = 23;
            // 
            // CBReviewState
            // 
            this.CBReviewState.Location = new System.Drawing.Point(12, 572);
            this.CBReviewState.Name = "CBReviewState";
            this.CBReviewState.Properties.Caption = "开启复审";
            this.CBReviewState.Size = new System.Drawing.Size(190, 20);
            this.CBReviewState.StyleController = this.layoutControl1;
            this.CBReviewState.TabIndex = 22;
            // 
            // BTUpLoadFile
            // 
            this.BTUpLoadFile.Location = new System.Drawing.Point(266, 187);
            this.BTUpLoadFile.Name = "BTUpLoadFile";
            this.BTUpLoadFile.Size = new System.Drawing.Size(132, 29);
            this.BTUpLoadFile.TabIndex = 20;
            this.BTUpLoadFile.Text = "上传图片";
            this.BTUpLoadFile.UseVisualStyleBackColor = true;
            this.BTUpLoadFile.Click += new System.EventHandler(this.BTUpLoadFile_Click);
            // 
            // TEno
            // 
            this.TEno.EditValue = "";
            this.TEno.Enabled = false;
            this.TEno.Location = new System.Drawing.Point(79, 12);
            this.TEno.Name = "TEno";
            this.TEno.Size = new System.Drawing.Size(319, 20);
            this.TEno.StyleController = this.layoutControl1;
            this.TEno.TabIndex = 4;
            // 
            // TEnames
            // 
            this.TEnames.EditValue = "";
            this.TEnames.Location = new System.Drawing.Point(79, 36);
            this.TEnames.Name = "TEnames";
            this.TEnames.Size = new System.Drawing.Size(319, 20);
            this.TEnames.StyleController = this.layoutControl1;
            this.TEnames.TabIndex = 5;
            // 
            // TEPhone
            // 
            this.TEPhone.EditValue = "";
            this.TEPhone.Location = new System.Drawing.Point(79, 268);
            this.TEPhone.Name = "TEPhone";
            this.TEPhone.Size = new System.Drawing.Size(319, 20);
            this.TEPhone.StyleController = this.layoutControl1;
            this.TEPhone.TabIndex = 11;
            // 
            // TERemark
            // 
            this.TERemark.EditValue = "";
            this.TERemark.Location = new System.Drawing.Point(79, 441);
            this.TERemark.Name = "TERemark";
            this.TERemark.Size = new System.Drawing.Size(319, 127);
            this.TERemark.StyleController = this.layoutControl1;
            this.TERemark.TabIndex = 13;
            // 
            // TEFunctions
            // 
            this.TEFunctions.EditValue = "";
            this.TEFunctions.Location = new System.Drawing.Point(79, 316);
            this.TEFunctions.Name = "TEFunctions";
            this.TEFunctions.Size = new System.Drawing.Size(319, 121);
            this.TEFunctions.StyleController = this.layoutControl1;
            this.TEFunctions.TabIndex = 15;
            // 
            // TESort
            // 
            this.TESort.EditValue = "";
            this.TESort.Location = new System.Drawing.Point(79, 292);
            this.TESort.Name = "TESort";
            this.TESort.Size = new System.Drawing.Size(319, 20);
            this.TESort.StyleController = this.layoutControl1;
            this.TESort.TabIndex = 16;
            // 
            // CBState
            // 
            this.CBState.Location = new System.Drawing.Point(79, 620);
            this.CBState.Name = "CBState";
            this.CBState.Properties.Caption = "启用";
            this.CBState.Size = new System.Drawing.Size(319, 20);
            this.CBState.StyleController = this.layoutControl1;
            this.CBState.TabIndex = 18;
            // 
            // PEItemImg
            // 
            this.PEItemImg.Cursor = System.Windows.Forms.Cursors.Default;
            this.PEItemImg.Location = new System.Drawing.Point(79, 84);
            this.PEItemImg.Name = "PEItemImg";
            this.PEItemImg.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.PEItemImg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.PEItemImg.Size = new System.Drawing.Size(183, 132);
            this.PEItemImg.StyleController = this.layoutControl1;
            this.PEItemImg.TabIndex = 19;
            // 
            // GEtestPreson
            // 
            this.GEtestPreson.EditValue = "";
            this.GEtestPreson.Location = new System.Drawing.Point(79, 220);
            this.GEtestPreson.Name = "GEtestPreson";
            this.GEtestPreson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEtestPreson.Properties.NullText = "";
            this.GEtestPreson.Properties.PopupView = this.gridLookUpEdit1View;
            this.GEtestPreson.Size = new System.Drawing.Size(319, 20);
            this.GEtestPreson.StyleController = this.layoutControl1;
            this.GEtestPreson.TabIndex = 7;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.DetailHeight = 408;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // GEratifier
            // 
            this.GEratifier.Location = new System.Drawing.Point(79, 244);
            this.GEratifier.Name = "GEratifier";
            this.GEratifier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEratifier.Properties.NullText = "";
            this.GEratifier.Properties.PopupView = this.gridView3;
            this.GEratifier.Size = new System.Drawing.Size(319, 20);
            this.GEratifier.StyleController = this.layoutControl1;
            this.GEratifier.TabIndex = 21;
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 408;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // GEworkNO
            // 
            this.GEworkNO.EditValue = "";
            this.GEworkNO.Location = new System.Drawing.Point(79, 60);
            this.GEworkNO.Name = "GEworkNO";
            this.GEworkNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEworkNO.Properties.NullText = "";
            this.GEworkNO.Properties.PopupView = this.gridView5;
            this.GEworkNO.Size = new System.Drawing.Size(319, 20);
            this.GEworkNO.StyleController = this.layoutControl1;
            this.GEworkNO.TabIndex = 17;
            // 
            // gridView5
            // 
            this.gridView5.DetailHeight = 408;
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.layoutControlItem12,
            this.emptySpaceItem1,
            this.TEDepartment,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem16,
            this.layoutControlItem10});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ShowInCustomizationForm = false;
            this.layoutControlGroup1.Size = new System.Drawing.Size(965, 678);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEno;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem1.Text = "编         号:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TEnames;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem2.Text = "检验组名称:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.TEPhone;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 256);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem8.Text = "电         话:";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.TEFunctions;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 304);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(0, 125);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(104, 125);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(390, 125);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "部 门 职 能:";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(64, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 632);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(390, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // TEDepartment
            // 
            this.TEDepartment.AllowHotTrack = false;
            this.TEDepartment.Location = new System.Drawing.Point(390, 0);
            this.TEDepartment.Name = "emptySpaceItem2";
            this.TEDepartment.Size = new System.Drawing.Size(555, 658);
            this.TEDepartment.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.TESort;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 280);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem13.Text = "排         序:";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.GEworkNO;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem14.Text = "所属工作组:";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.CBState;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 608);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem15.Text = "启用状态:";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.GEtestPreson;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 208);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem4.Text = "负   责   人:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.PEItemImg;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(254, 136);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(254, 136);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(254, 136);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "检验组图片:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 14);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(254, 72);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(136, 103);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BTUpLoadFile;
            this.layoutControlItem3.Location = new System.Drawing.Point(254, 175);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(136, 33);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(136, 33);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.GEratifier;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 232);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(390, 24);
            this.layoutControlItem6.Text = "批   准   人:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.CBReviewState;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 560);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(194, 24);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.CBTREqual;
            this.layoutControlItem9.Location = new System.Drawing.Point(194, 560);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(196, 24);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.CBTCEqual;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 584);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(194, 24);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.CBRCEqual;
            this.layoutControlItem16.Location = new System.Drawing.Point(194, 584);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(196, 24);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.TERemark;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 429);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(0, 131);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(104, 131);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(390, 131);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "备         注:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(64, 14);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTAddGroup,
            this.BTEditGroup,
            this.BTSaveGroup,
            this.BTDeleteGroup});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(969, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // BTAddGroup
            // 
            this.BTAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("BTAddGroup.Image")));
            this.BTAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTAddGroup.Name = "BTAddGroup";
            this.BTAddGroup.Size = new System.Drawing.Size(56, 24);
            this.BTAddGroup.Text = "新增";
            this.BTAddGroup.Click += new System.EventHandler(this.BTAddGroup_Click);
            // 
            // BTEditGroup
            // 
            this.BTEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("BTEditGroup.Image")));
            this.BTEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTEditGroup.Name = "BTEditGroup";
            this.BTEditGroup.Size = new System.Drawing.Size(56, 24);
            this.BTEditGroup.Text = "编辑";
            this.BTEditGroup.Click += new System.EventHandler(this.BTEditGroup_Click);
            // 
            // BTSaveGroup
            // 
            this.BTSaveGroup.Image = ((System.Drawing.Image)(resources.GetObject("BTSaveGroup.Image")));
            this.BTSaveGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTSaveGroup.Name = "BTSaveGroup";
            this.BTSaveGroup.Size = new System.Drawing.Size(56, 24);
            this.BTSaveGroup.Text = "保存";
            this.BTSaveGroup.Click += new System.EventHandler(this.BTSaveGroup_Click);
            // 
            // BTDeleteGroup
            // 
            this.BTDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("BTDeleteGroup.Image")));
            this.BTDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTDeleteGroup.Name = "BTDeleteGroup";
            this.BTDeleteGroup.Size = new System.Drawing.Size(56, 24);
            this.BTDeleteGroup.Text = "删除";
            this.BTDeleteGroup.Click += new System.EventHandler(this.BTDeleteGroup_Click);
            // 
            // 列表信息配置
            // 
            this.列表信息配置.Controls.Add(this.GCGroupGrid);
            this.列表信息配置.Controls.Add(this.toolStrip1);
            this.列表信息配置.Name = "列表信息配置";
            this.列表信息配置.Size = new System.Drawing.Size(969, 730);
            this.列表信息配置.Text = "列表信息配置";
            // 
            // GCGroupGrid
            // 
            this.GCGroupGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCGroupGrid.Location = new System.Drawing.Point(0, 27);
            this.GCGroupGrid.MainView = this.GVGroupGird;
            this.GCGroupGrid.Name = "GCGroupGrid";
            this.GCGroupGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit3,
            this.RGEcontrolType});
            this.GCGroupGrid.Size = new System.Drawing.Size(969, 703);
            this.GCGroupGrid.TabIndex = 3;
            this.GCGroupGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVGroupGird});
            // 
            // GVGroupGird
            // 
            this.GVGroupGird.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDs,
            this.WorkNOs,
            this.testNO,
            this.ControlType,
            this.ControlNames,
            this.FieldNames,
            this.Captions,
            this.ControlVisible,
            this.ControlEnabled,
            this.AllFocus,
            this.AllowEdit,
            this.ReadOnly,
            this.Width,
            this.BandTable,
            this.BandType,
            this.sort,
            this.states});
            this.GVGroupGird.DetailHeight = 408;
            this.GVGroupGird.GridControl = this.GCGroupGrid;
            this.GVGroupGird.Name = "GVGroupGird";
            this.GVGroupGird.OptionsView.ShowGroupPanel = false;
            this.GVGroupGird.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.GVGroupGird_InitNewRow);
            // 
            // IDs
            // 
            this.IDs.Caption = "id";
            this.IDs.FieldName = "id";
            this.IDs.MinWidth = 23;
            this.IDs.Name = "IDs";
            this.IDs.Width = 87;
            // 
            // WorkNOs
            // 
            this.WorkNOs.Caption = "工作组";
            this.WorkNOs.FieldName = "workNO";
            this.WorkNOs.MinWidth = 23;
            this.WorkNOs.Name = "WorkNOs";
            this.WorkNOs.Width = 87;
            // 
            // testNO
            // 
            this.testNO.Caption = "检验组";
            this.testNO.FieldName = "testNO";
            this.testNO.MinWidth = 23;
            this.testNO.Name = "testNO";
            this.testNO.Width = 87;
            // 
            // ControlType
            // 
            this.ControlType.Caption = "控件类型";
            this.ControlType.ColumnEdit = this.RGEcontrolType;
            this.ControlType.FieldName = "controlType";
            this.ControlType.MinWidth = 23;
            this.ControlType.Name = "ControlType";
            this.ControlType.Visible = true;
            this.ControlType.VisibleIndex = 0;
            this.ControlType.Width = 87;
            // 
            // RGEcontrolType
            // 
            this.RGEcontrolType.AutoHeight = false;
            this.RGEcontrolType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEcontrolType.Name = "RGEcontrolType";
            this.RGEcontrolType.NullText = "";
            this.RGEcontrolType.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 408;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ControlNames
            // 
            this.ControlNames.Caption = "控件名称";
            this.ControlNames.FieldName = "controlNames";
            this.ControlNames.MinWidth = 23;
            this.ControlNames.Name = "ControlNames";
            this.ControlNames.Visible = true;
            this.ControlNames.VisibleIndex = 1;
            this.ControlNames.Width = 87;
            // 
            // FieldNames
            // 
            this.FieldNames.Caption = "对应字段";
            this.FieldNames.FieldName = "fieldNames";
            this.FieldNames.MinWidth = 23;
            this.FieldNames.Name = "FieldNames";
            this.FieldNames.Visible = true;
            this.FieldNames.VisibleIndex = 2;
            this.FieldNames.Width = 87;
            // 
            // Captions
            // 
            this.Captions.Caption = "显示名称";
            this.Captions.FieldName = "captions";
            this.Captions.MinWidth = 23;
            this.Captions.Name = "Captions";
            this.Captions.Visible = true;
            this.Captions.VisibleIndex = 3;
            this.Captions.Width = 87;
            // 
            // ControlVisible
            // 
            this.ControlVisible.Caption = "显示";
            this.ControlVisible.FieldName = "controlVisible";
            this.ControlVisible.MinWidth = 23;
            this.ControlVisible.Name = "ControlVisible";
            this.ControlVisible.Visible = true;
            this.ControlVisible.VisibleIndex = 4;
            this.ControlVisible.Width = 87;
            // 
            // ControlEnabled
            // 
            this.ControlEnabled.Caption = "编辑";
            this.ControlEnabled.FieldName = "controlEnabled";
            this.ControlEnabled.MinWidth = 23;
            this.ControlEnabled.Name = "ControlEnabled";
            this.ControlEnabled.Visible = true;
            this.ControlEnabled.VisibleIndex = 5;
            this.ControlEnabled.Width = 87;
            // 
            // AllFocus
            // 
            this.AllFocus.Caption = "可选";
            this.AllFocus.FieldName = "allFocus";
            this.AllFocus.MinWidth = 23;
            this.AllFocus.Name = "AllFocus";
            this.AllFocus.Visible = true;
            this.AllFocus.VisibleIndex = 6;
            this.AllFocus.Width = 87;
            // 
            // AllowEdit
            // 
            this.AllowEdit.Caption = "可编辑";
            this.AllowEdit.FieldName = "allowEdit";
            this.AllowEdit.MinWidth = 23;
            this.AllowEdit.Name = "AllowEdit";
            this.AllowEdit.Visible = true;
            this.AllowEdit.VisibleIndex = 7;
            this.AllowEdit.Width = 87;
            // 
            // ReadOnly
            // 
            this.ReadOnly.Caption = "只读";
            this.ReadOnly.FieldName = "readOnly";
            this.ReadOnly.MinWidth = 23;
            this.ReadOnly.Name = "ReadOnly";
            this.ReadOnly.Visible = true;
            this.ReadOnly.VisibleIndex = 8;
            this.ReadOnly.Width = 87;
            // 
            // Width
            // 
            this.Width.Caption = "列宽";
            this.Width.FieldName = "width";
            this.Width.MinWidth = 23;
            this.Width.Name = "Width";
            this.Width.Visible = true;
            this.Width.VisibleIndex = 9;
            this.Width.Width = 87;
            // 
            // BandTable
            // 
            this.BandTable.Caption = "绑定表";
            this.BandTable.FieldName = "bandTable";
            this.BandTable.MinWidth = 23;
            this.BandTable.Name = "BandTable";
            this.BandTable.Visible = true;
            this.BandTable.VisibleIndex = 10;
            this.BandTable.Width = 87;
            // 
            // BandType
            // 
            this.BandType.Caption = "绑定标识";
            this.BandType.FieldName = "bandType";
            this.BandType.MinWidth = 23;
            this.BandType.Name = "BandType";
            this.BandType.Visible = true;
            this.BandType.VisibleIndex = 11;
            this.BandType.Width = 87;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 70;
            this.sort.MinWidth = 39;
            this.sort.Name = "sort";
            this.sort.Visible = true;
            this.sort.VisibleIndex = 12;
            this.sort.Width = 39;
            // 
            // states
            // 
            this.states.Caption = "启用";
            this.states.FieldName = "state";
            this.states.MaxWidth = 70;
            this.states.MinWidth = 39;
            this.states.Name = "states";
            this.states.Visible = true;
            this.states.VisibleIndex = 13;
            this.states.Width = 39;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTAddColumns,
            this.BTEditColumns,
            this.BTASaveColumns,
            this.BTDeleteColumns});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(969, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTAddColumns
            // 
            this.BTAddColumns.Image = ((System.Drawing.Image)(resources.GetObject("BTAddColumns.Image")));
            this.BTAddColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTAddColumns.Name = "BTAddColumns";
            this.BTAddColumns.Size = new System.Drawing.Size(56, 24);
            this.BTAddColumns.Text = "新增";
            this.BTAddColumns.Click += new System.EventHandler(this.BTAddColumns_Click);
            // 
            // BTEditColumns
            // 
            this.BTEditColumns.Image = ((System.Drawing.Image)(resources.GetObject("BTEditColumns.Image")));
            this.BTEditColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTEditColumns.Name = "BTEditColumns";
            this.BTEditColumns.Size = new System.Drawing.Size(56, 24);
            this.BTEditColumns.Text = "编辑";
            this.BTEditColumns.Click += new System.EventHandler(this.BTEditColumns_Click);
            // 
            // BTASaveColumns
            // 
            this.BTASaveColumns.Image = ((System.Drawing.Image)(resources.GetObject("BTASaveColumns.Image")));
            this.BTASaveColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTASaveColumns.Name = "BTASaveColumns";
            this.BTASaveColumns.Size = new System.Drawing.Size(56, 24);
            this.BTASaveColumns.Text = "保存";
            this.BTASaveColumns.Click += new System.EventHandler(this.BTASaveColumns_Click);
            // 
            // BTDeleteColumns
            // 
            this.BTDeleteColumns.Image = ((System.Drawing.Image)(resources.GetObject("BTDeleteColumns.Image")));
            this.BTDeleteColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTDeleteColumns.Name = "BTDeleteColumns";
            this.BTDeleteColumns.Size = new System.Drawing.Size(56, 24);
            this.BTDeleteColumns.Text = "删除";
            this.BTDeleteColumns.Click += new System.EventHandler(this.BTDeleteColumns_Click);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(323, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(292, 476);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1331, 756);
            this.splitContainerControl1.SplitterPosition = 350;
            this.splitContainerControl1.TabIndex = 14;
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.GCInfo);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(350, 756);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "列表信息";
            // 
            // FrmTestGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 780);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTestGroup";
            this.Text = "FrmTestGroup";
            this.Load += new System.EventHandler(this.FrmTestGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEworkNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.基础信息配置.ResumeLayout(false);
            this.基础信息配置.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CBRCEqual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBTCEqual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBTREqual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBReviewState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEnames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TERemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFunctions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TESort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PEItemImg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEtestPreson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEratifier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEworkNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.列表信息配置.ResumeLayout(false);
            this.列表信息配置.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVGroupGird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEcontrolType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
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
        private DevExpress.XtraBars.BarButtonItem BTEdit;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTDelect;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
#pragma warning disable CS0169 // 从不使用字段“FrmTestGroup.ID”
        private DevExpress.XtraGrid.Columns.GridColumn ID;
#pragma warning restore CS0169 // 从不使用字段“FrmTestGroup.ID”
#pragma warning disable CS0169 // 从不使用字段“FrmTestGroup.NO”
        private DevExpress.XtraGrid.Columns.GridColumn NO;
#pragma warning restore CS0169 // 从不使用字段“FrmTestGroup.NO”
#pragma warning disable CS0169 // 从不使用字段“FrmTestGroup.Names”
        private DevExpress.XtraGrid.Columns.GridColumn Names;
#pragma warning restore CS0169 // 从不使用字段“FrmTestGroup.Names”
        private DevExpress.XtraGrid.Columns.GridColumn workNO;
#pragma warning disable CS0169 // 从不使用字段“FrmTestGroup.State”
        private DevExpress.XtraGrid.Columns.GridColumn State;
#pragma warning restore CS0169 // 从不使用字段“FrmTestGroup.State”
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage 基础信息配置;
        private DevExpress.XtraTab.XtraTabPage 列表信息配置;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEworkNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTAddColumns;
        private System.Windows.Forms.ToolStripButton BTEditColumns;
        private System.Windows.Forms.ToolStripButton BTASaveColumns;
        private System.Windows.Forms.ToolStripButton BTDeleteColumns;
        private DevExpress.XtraGrid.GridControl GCGroupGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView GVGroupGird;
        private DevExpress.XtraGrid.Columns.GridColumn IDs;
        private DevExpress.XtraGrid.Columns.GridColumn WorkNOs;
#pragma warning disable CS0169 // 从不使用字段“FrmTestGroup.TestNO”
        private DevExpress.XtraGrid.Columns.GridColumn TestNO;
#pragma warning restore CS0169 // 从不使用字段“FrmTestGroup.TestNO”
        private DevExpress.XtraGrid.Columns.GridColumn ControlType;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEcontrolType;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ControlNames;
        private DevExpress.XtraGrid.Columns.GridColumn FieldNames;
        private DevExpress.XtraGrid.Columns.GridColumn Captions;
        private DevExpress.XtraGrid.Columns.GridColumn ControlVisible;
        private DevExpress.XtraGrid.Columns.GridColumn ControlEnabled;
        private DevExpress.XtraGrid.Columns.GridColumn AllFocus;
        private DevExpress.XtraGrid.Columns.GridColumn AllowEdit;
        private DevExpress.XtraGrid.Columns.GridColumn ReadOnly;
#pragma warning disable CS0108 // “FrmTestGroup.Width”隐藏继承的成员“Control.Width”。如果是有意隐藏，请使用关键字 new。
        private DevExpress.XtraGrid.Columns.GridColumn Width;
#pragma warning restore CS0108 // “FrmTestGroup.Width”隐藏继承的成员“Control.Width”。如果是有意隐藏，请使用关键字 new。
        private DevExpress.XtraGrid.Columns.GridColumn BandTable;
        private DevExpress.XtraGrid.Columns.GridColumn BandType;
#pragma warning disable CS0169 // 从不使用字段“FrmTestGroup.Sort”
        private DevExpress.XtraGrid.Columns.GridColumn Sort;
#pragma warning restore CS0169 // 从不使用字段“FrmTestGroup.Sort”
        private DevExpress.XtraGrid.Columns.GridColumn states;
        private RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton BTAddGroup;
        private System.Windows.Forms.ToolStripButton BTEditGroup;
        private System.Windows.Forms.ToolStripButton BTSaveGroup;
        private System.Windows.Forms.ToolStripButton BTDeleteGroup;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.CheckEdit CBRCEqual;
        private DevExpress.XtraEditors.CheckEdit CBTCEqual;
        private DevExpress.XtraEditors.CheckEdit CBTREqual;
        private DevExpress.XtraEditors.CheckEdit CBReviewState;
        private System.Windows.Forms.Button BTUpLoadFile;
        private DevExpress.XtraEditors.TextEdit TEno;
        private DevExpress.XtraEditors.TextEdit TEnames;
        private DevExpress.XtraEditors.TextEdit TEPhone;
        private DevExpress.XtraEditors.MemoEdit TERemark;
        private DevExpress.XtraEditors.MemoEdit TEFunctions;
        private DevExpress.XtraEditors.TextEdit TESort;
        private DevExpress.XtraEditors.CheckEdit CBState;
        private DevExpress.XtraEditors.PictureEdit PEItemImg;
        private DevExpress.XtraEditors.GridLookUpEdit GEtestPreson;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.GridLookUpEdit GEratifier;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GridLookUpEdit GEworkNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem TEDepartment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn testNO;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraEditors.GroupControl groupInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}