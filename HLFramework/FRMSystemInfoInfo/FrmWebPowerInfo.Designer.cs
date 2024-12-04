namespace HLFramework
{
    partial class FrmWebPowerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWebPowerInfo));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.TEText = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LEcompanyNO = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.departmentNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LEdepartmentNO = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.roleNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GroupList = new DevExpress.XtraEditors.GroupControl();
            this.GroupInfo = new DevExpress.XtraEditors.GroupControl();
            this.PCPowerView = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEcompanyNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEdepartmentNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupList)).BeginInit();
            this.GroupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupInfo)).BeginInit();
            this.GroupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCPowerView)).BeginInit();
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
            this.BTEdit,
            this.BTSave,
            this.TEText});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.TEText, "", false, true, true, 525)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑";
            this.BTEdit.Id = 1;
            this.BTEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.Image")));
            this.BTEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.LargeImage")));
            this.BTEdit.Name = "BTEdit";
            this.BTEdit.Tag = "10010601";
            this.BTEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEdit_ItemClick);
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 2;
            this.BTSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.Image")));
            this.BTSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.LargeImage")));
            this.BTSave.Name = "BTSave";
            this.BTSave.Tag = "10010602";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSaveCompany_ItemClick);
            // 
            // TEText
            // 
            this.TEText.Caption = "barEditItem1";
            this.TEText.Edit = this.repositoryItemTextEdit1;
            this.TEText.Id = 4;
            this.TEText.Name = "TEText";
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(1134, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 670);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(1134, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 646);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1134, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 646);
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gridLevelNode1.RelationName = "Level1";
            this.GCInfo.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GCInfo.Location = new System.Drawing.Point(2, 23);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LEdepartmentNO,
            this.LEcompanyNO});
            this.GCInfo.Size = new System.Drawing.Size(231, 621);
            this.GCInfo.TabIndex = 1;
            this.GCInfo.UseEmbeddedNavigator = true;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            this.GCInfo.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.CompanyNO,
            this.departmentNO,
            this.roleNames});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.GroupCount = 2;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.OptionsView.ShowGroupPanel = false;
            this.GVInfo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.CompanyNO, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.departmentNO, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 24;
            this.id.Name = "id";
            this.id.Width = 87;
            // 
            // CompanyNO
            // 
            this.CompanyNO.Caption = "公司名称";
            this.CompanyNO.ColumnEdit = this.LEcompanyNO;
            this.CompanyNO.FieldName = "companyNO";
            this.CompanyNO.MinWidth = 24;
            this.CompanyNO.Name = "CompanyNO";
            this.CompanyNO.Visible = true;
            this.CompanyNO.VisibleIndex = 1;
            this.CompanyNO.Width = 87;
            // 
            // LEcompanyNO
            // 
            this.LEcompanyNO.AutoHeight = false;
            this.LEcompanyNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LEcompanyNO.Name = "LEcompanyNO";
            // 
            // departmentNO
            // 
            this.departmentNO.Caption = "部门";
            this.departmentNO.ColumnEdit = this.LEdepartmentNO;
            this.departmentNO.FieldName = "departmentNO";
            this.departmentNO.MinWidth = 24;
            this.departmentNO.Name = "departmentNO";
            this.departmentNO.OptionsColumn.AllowFocus = false;
            this.departmentNO.Visible = true;
            this.departmentNO.VisibleIndex = 0;
            this.departmentNO.Width = 87;
            // 
            // LEdepartmentNO
            // 
            this.LEdepartmentNO.AutoHeight = false;
            this.LEdepartmentNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LEdepartmentNO.Name = "LEdepartmentNO";
            // 
            // roleNames
            // 
            this.roleNames.Caption = "名称";
            this.roleNames.FieldName = "names";
            this.roleNames.MinWidth = 24;
            this.roleNames.Name = "roleNames";
            this.roleNames.OptionsColumn.AllowFocus = false;
            this.roleNames.Visible = true;
            this.roleNames.VisibleIndex = 0;
            this.roleNames.Width = 87;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(80, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(105, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(-45, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.GroupList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GroupInfo);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1134, 646);
            this.splitContainerControl1.SplitterPosition = 235;
            this.splitContainerControl1.TabIndex = 14;
            // 
            // GroupList
            // 
            this.GroupList.Controls.Add(this.GCInfo);
            this.GroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupList.Location = new System.Drawing.Point(0, 0);
            this.GroupList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupList.Name = "GroupList";
            this.GroupList.Size = new System.Drawing.Size(235, 646);
            this.GroupList.TabIndex = 0;
            this.GroupList.Text = "角色列表";
            // 
            // GroupInfo
            // 
            this.GroupInfo.Controls.Add(this.PCPowerView);
            this.GroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupInfo.Location = new System.Drawing.Point(0, 0);
            this.GroupInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupInfo.Name = "GroupInfo";
            this.GroupInfo.Size = new System.Drawing.Size(889, 646);
            this.GroupInfo.TabIndex = 0;
            this.GroupInfo.Text = "详细信息";
            // 
            // PCPowerView
            // 
            this.PCPowerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCPowerView.Location = new System.Drawing.Point(2, 23);
            this.PCPowerView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PCPowerView.Name = "PCPowerView";
            this.PCPowerView.Size = new System.Drawing.Size(885, 621);
            this.PCPowerView.TabIndex = 0;
            // 
            // FrmWebPowerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 670);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmWebPowerInfo";
            this.Text = "FrmPowerInfo";
            this.Load += new System.EventHandler(this.FrmPowerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEcompanyNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEdepartmentNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupList)).EndInit();
            this.GroupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupInfo)).EndInit();
            this.GroupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCPowerView)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTEdit;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        //private DevExpress.XtraTreeList.Columns.TreeListColumn Names;
        private DevExpress.XtraBars.BarEditItem TEText;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LEcompanyNO;
        private DevExpress.XtraGrid.Columns.GridColumn departmentNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LEdepartmentNO;
        private DevExpress.XtraGrid.Columns.GridColumn roleNames;
#pragma warning disable CS0169 // 从不使用字段“FrmWebPowerInfo.ID”
        private DevExpress.XtraGrid.Columns.GridColumn ID;
#pragma warning restore CS0169 // 从不使用字段“FrmWebPowerInfo.ID”
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl GroupList;
        private DevExpress.XtraEditors.GroupControl GroupInfo;
        private DevExpress.XtraEditors.PanelControl PCPowerView;
    }
}