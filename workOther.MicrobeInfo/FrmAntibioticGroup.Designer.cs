
namespace workOther.MicrobeInfo
{
    partial class FrmAntibioticGroup
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BTEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GGroup = new DevExpress.XtraEditors.GroupControl();
            this.GCGroupList = new DevExpress.XtraGrid.GridControl();
            this.GVGroupList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.listInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.GCInfos = new DevExpress.XtraGrid.GridControl();
            this.GVInfos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.namesEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.micValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kbValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.methodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.aqualitative = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.RGEgroupCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GGroup)).BeginInit();
            this.GGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVGroupList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
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
            this.BTDelete});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "新增";
            this.BTAdd.Id = 0;
            this.BTAdd.ImageOptions.Image = global::workOther.MicrobeInfo.Properties.Resources.add_16x16;
            this.BTAdd.ImageOptions.LargeImage = global::workOther.MicrobeInfo.Properties.Resources.add_32x32;
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑";
            this.BTEdit.Id = 1;
            this.BTEdit.ImageOptions.Image = global::workOther.MicrobeInfo.Properties.Resources.addfile_16x16;
            this.BTEdit.ImageOptions.LargeImage = global::workOther.MicrobeInfo.Properties.Resources.addfile_32x32;
            this.BTEdit.Name = "BTEdit";
            this.BTEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEdit_ItemClick);
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 2;
            this.BTSave.ImageOptions.Image = global::workOther.MicrobeInfo.Properties.Resources.apply_16x16;
            this.BTSave.ImageOptions.LargeImage = global::workOther.MicrobeInfo.Properties.Resources.apply_32x32;
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTDelete
            // 
            this.BTDelete.Caption = "删除";
            this.BTDelete.Id = 3;
            this.BTDelete.ImageOptions.Image = global::workOther.MicrobeInfo.Properties.Resources.cancel_16x16;
            this.BTDelete.ImageOptions.LargeImage = global::workOther.MicrobeInfo.Properties.Resources.cancel_32x32;
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1450, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 935);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1450, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 905);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1450, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 905);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.GGroup);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1450, 905);
            this.splitContainerControl1.SplitterPosition = 666;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // GGroup
            // 
            this.GGroup.Controls.Add(this.GCGroupList);
            this.GGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GGroup.Location = new System.Drawing.Point(0, 0);
            this.GGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GGroup.Name = "GGroup";
            this.GGroup.Size = new System.Drawing.Size(666, 905);
            this.GGroup.TabIndex = 0;
            this.GGroup.Text = "组合名称";
            // 
            // GCGroupList
            // 
            this.GCGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCGroupList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCGroupList.Location = new System.Drawing.Point(2, 28);
            this.GCGroupList.MainView = this.GVGroupList;
            this.GCGroupList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCGroupList.MenuManager = this.barManager1;
            this.GCGroupList.Name = "GCGroupList";
            this.GCGroupList.Size = new System.Drawing.Size(662, 875);
            this.GCGroupList.TabIndex = 0;
            this.GCGroupList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVGroupList});
            // 
            // GVGroupList
            // 
            this.GVGroupList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.names,
            this.shortNames,
            this.customCode,
            this.sort,
            this.state,
            this.listInfo});
            this.GVGroupList.DetailHeight = 525;
            this.GVGroupList.FixedLineWidth = 3;
            this.GVGroupList.GridControl = this.GCGroupList;
            this.GVGroupList.Name = "GVGroupList";
            this.GVGroupList.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GVGroupList_RowClick);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 26;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Width = 99;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MinWidth = 26;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.OptionsColumn.ReadOnly = true;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 99;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 26;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            this.names.Width = 99;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "简称";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.MinWidth = 26;
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 2;
            this.shortNames.Width = 99;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定名称";
            this.customCode.FieldName = "customCode";
            this.customCode.MinWidth = 26;
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Visible = true;
            this.customCode.VisibleIndex = 3;
            this.customCode.Width = 99;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 45;
            this.sort.MinWidth = 26;
            this.sort.Name = "sort";
            this.sort.OptionsColumn.AllowFocus = false;
            this.sort.Visible = true;
            this.sort.VisibleIndex = 4;
            this.sort.Width = 45;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 45;
            this.state.MinWidth = 26;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 5;
            this.state.Width = 45;
            // 
            // listInfo
            // 
            this.listInfo.Caption = "列表";
            this.listInfo.FieldName = "listInfo";
            this.listInfo.MinWidth = 26;
            this.listInfo.Name = "listInfo";
            this.listInfo.OptionsColumn.AllowFocus = false;
            this.listInfo.Width = 99;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.GCInfos);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(772, 905);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "抗生素列表";
            // 
            // GCInfos
            // 
            this.GCInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfos.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfos.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCInfos.Location = new System.Drawing.Point(2, 28);
            this.GCInfos.MainView = this.GVInfos;
            this.GCInfos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCInfos.MenuManager = this.barManager1;
            this.GCInfos.Name = "GCInfos";
            this.GCInfos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1,
            this.repositoryItemCheckEdit1,
            this.RGEgroupCode});
            this.GCInfos.Size = new System.Drawing.Size(768, 875);
            this.GCInfos.TabIndex = 1;
            this.GCInfos.UseEmbeddedNavigator = true;
            this.GCInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfos});
            // 
            // GVInfos
            // 
            this.GVInfos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.check,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.namesEn,
            this.channel,
            this.value,
            this.remark,
            this.gridColumn6,
            this.gridColumn7,
            this.micValue,
            this.kbValue,
            this.itemResult,
            this.methodName,
            this.aqualitative});
            this.GVInfos.DetailHeight = 525;
            this.GVInfos.FixedLineWidth = 3;
            this.GVInfos.GridControl = this.GCInfos;
            this.GVInfos.Name = "GVInfos";
            this.GVInfos.OptionsFind.ShowCloseButton = false;
            this.GVInfos.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "id";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.MinWidth = 26;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 99;
            // 
            // check
            // 
            this.check.Caption = "选择";
            this.check.FieldName = "check";
            this.check.MaxWidth = 40;
            this.check.MinWidth = 40;
            this.check.Name = "check";
            this.check.OptionsColumn.AllowFocus = false;
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 40;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "编号";
            this.gridColumn2.FieldName = "no";
            this.gridColumn2.MinWidth = 26;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 74;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "名称";
            this.gridColumn3.FieldName = "names";
            this.gridColumn3.MinWidth = 26;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 103;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "拼音简拼";
            this.gridColumn4.FieldName = "shortNames";
            this.gridColumn4.MinWidth = 26;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 143;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "自定编码";
            this.gridColumn5.FieldName = "customCode";
            this.gridColumn5.MinWidth = 23;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 86;
            // 
            // namesEn
            // 
            this.namesEn.Caption = "英文名称";
            this.namesEn.FieldName = "namesEn";
            this.namesEn.MinWidth = 23;
            this.namesEn.Name = "namesEn";
            this.namesEn.OptionsColumn.AllowFocus = false;
            this.namesEn.Visible = true;
            this.namesEn.VisibleIndex = 5;
            this.namesEn.Width = 86;
            // 
            // channel
            // 
            this.channel.Caption = "通道号";
            this.channel.FieldName = "channel";
            this.channel.MinWidth = 23;
            this.channel.Name = "channel";
            this.channel.OptionsColumn.AllowFocus = false;
            this.channel.Visible = true;
            this.channel.VisibleIndex = 6;
            this.channel.Width = 86;
            // 
            // value
            // 
            this.value.Caption = "说明信息";
            this.value.FieldName = "value";
            this.value.MinWidth = 23;
            this.value.Name = "value";
            this.value.OptionsColumn.AllowFocus = false;
            this.value.Visible = true;
            this.value.VisibleIndex = 12;
            this.value.Width = 86;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.MinWidth = 23;
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowFocus = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 13;
            this.remark.Width = 86;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "排序";
            this.gridColumn6.FieldName = "sort";
            this.gridColumn6.MaxWidth = 40;
            this.gridColumn6.MinWidth = 26;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 14;
            this.gridColumn6.Width = 40;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "状态";
            this.gridColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn7.FieldName = "state";
            this.gridColumn7.MaxWidth = 40;
            this.gridColumn7.MinWidth = 26;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 15;
            this.gridColumn7.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // micValue
            // 
            this.micValue.Caption = "MIC";
            this.micValue.FieldName = "micValue";
            this.micValue.MinWidth = 23;
            this.micValue.Name = "micValue";
            this.micValue.OptionsColumn.AllowFocus = false;
            this.micValue.Visible = true;
            this.micValue.VisibleIndex = 7;
            this.micValue.Width = 86;
            // 
            // kbValue
            // 
            this.kbValue.Caption = "K-B";
            this.kbValue.FieldName = "kbValue";
            this.kbValue.MinWidth = 23;
            this.kbValue.Name = "kbValue";
            this.kbValue.OptionsColumn.AllowFocus = false;
            this.kbValue.Visible = true;
            this.kbValue.VisibleIndex = 8;
            this.kbValue.Width = 86;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "结果";
            this.itemResult.FieldName = "itemResult";
            this.itemResult.MinWidth = 23;
            this.itemResult.Name = "itemResult";
            this.itemResult.OptionsColumn.AllowFocus = false;
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 9;
            this.itemResult.Width = 86;
            // 
            // methodName
            // 
            this.methodName.Caption = "方法";
            this.methodName.FieldName = "methodName";
            this.methodName.MinWidth = 23;
            this.methodName.Name = "methodName";
            this.methodName.OptionsColumn.AllowFocus = false;
            this.methodName.Visible = true;
            this.methodName.VisibleIndex = 10;
            this.methodName.Width = 86;
            // 
            // aqualitative
            // 
            this.aqualitative.Caption = "定性";
            this.aqualitative.FieldName = "aqualitative";
            this.aqualitative.MinWidth = 23;
            this.aqualitative.Name = "aqualitative";
            this.aqualitative.OptionsColumn.AllowFocus = false;
            this.aqualitative.Visible = true;
            this.aqualitative.VisibleIndex = 11;
            this.aqualitative.Width = 86;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.StoreColorAsInteger = true;
            // 
            // RGEgroupCode
            // 
            this.RGEgroupCode.AutoHeight = false;
            this.RGEgroupCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgroupCode.Name = "RGEgroupCode";
            this.RGEgroupCode.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 450;
            this.repositoryItemGridLookUpEdit1View.FixedLineWidth = 3;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // FrmAntibioticGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 935);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAntibioticGroup";
            this.Text = "FormAntibioticGroup";
            this.Load += new System.EventHandler(this.FrmAntibioticGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GGroup)).EndInit();
            this.GGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVGroupList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTDelete;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl GGroup;
        private DevExpress.XtraGrid.GridControl GCGroupList;
        private DevExpress.XtraGrid.Views.Grid.GridView GVGroupList;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn listInfo;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl GCInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn namesEn;
        private DevExpress.XtraGrid.Columns.GridColumn channel;
#pragma warning disable CS0169 // 从不使用字段“FrmAntibioticGroup.smearValue”
        private DevExpress.XtraGrid.Columns.GridColumn smearValue;
#pragma warning restore CS0169 // 从不使用字段“FrmAntibioticGroup.smearValue”
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn micValue;
        private DevExpress.XtraGrid.Columns.GridColumn kbValue;
        private DevExpress.XtraGrid.Columns.GridColumn itemResult;
        private DevExpress.XtraGrid.Columns.GridColumn methodName;
        private DevExpress.XtraGrid.Columns.GridColumn aqualitative;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgroupCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraGrid.Columns.GridColumn value;
    }
}