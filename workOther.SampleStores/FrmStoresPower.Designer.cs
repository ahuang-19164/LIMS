namespace workOther.SampleStores
{
    partial class FrmStoresPower
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStoresPower));
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
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.saveday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storesRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storeCell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEsampleType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GUserInfo = new DevExpress.XtraEditors.GroupControl();
            this.GCUserList = new DevExpress.XtraGrid.GridControl();
            this.GVUserList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.storesid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEuserNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createShelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editShelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.entrySample = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editSample = new DevExpress.XtraGrid.Columns.GridColumn();
            this.delsample = new DevExpress.XtraGrid.Columns.GridColumn();
            this.handleSample = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rehandleSample = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchSample = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cancelSample = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEsampleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GUserInfo)).BeginInit();
            this.GUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEuserNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.BTAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTAdd.ImageOptions.SvgImage")));
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑";
            this.BTEdit.Id = 1;
            this.BTEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTEdit.ImageOptions.SvgImage")));
            this.BTEdit.Name = "BTEdit";
            this.BTEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEdit_ItemClick);
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 2;
            this.BTSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTSave.ImageOptions.SvgImage")));
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTDelete
            // 
            this.BTDelete.Caption = "删除";
            this.BTDelete.Id = 3;
            this.BTDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTDelete.ImageOptions.SvgImage")));
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1185, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 595);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1185, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 571);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1185, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 571);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GUserInfo);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1185, 571);
            this.splitContainerControl1.SplitterPosition = 428;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.GCInfo);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(428, 571);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "存储库列表";
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(2, 23);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEsampleType});
            this.GCInfo.Size = new System.Drawing.Size(424, 546);
            this.GCInfo.TabIndex = 0;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.no,
            this.names,
            this.shortNames,
            this.customCode,
            this.address,
            this.saveday,
            this.storesRow,
            this.storeCell,
            this.sampleType,
            this.sort});
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GVInfo_RowClick);
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 47;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowEdit = false;
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 47;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.Name = "names";
            this.names.OptionsColumn.AllowEdit = false;
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            this.names.Width = 90;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "简称";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowEdit = false;
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 2;
            this.shortNames.Width = 90;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定编码";
            this.customCode.FieldName = "customCode";
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowEdit = false;
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Width = 90;
            // 
            // address
            // 
            this.address.Caption = "存储库位置";
            this.address.FieldName = "address";
            this.address.Name = "address";
            this.address.OptionsColumn.AllowEdit = false;
            this.address.OptionsColumn.AllowFocus = false;
            this.address.Visible = true;
            this.address.VisibleIndex = 3;
            this.address.Width = 90;
            // 
            // saveday
            // 
            this.saveday.Caption = "默认存储天数";
            this.saveday.FieldName = "saveday";
            this.saveday.Name = "saveday";
            this.saveday.OptionsColumn.AllowEdit = false;
            this.saveday.OptionsColumn.AllowFocus = false;
            this.saveday.Width = 84;
            // 
            // storesRow
            // 
            this.storesRow.Caption = "行数";
            this.storesRow.FieldName = "storesRow";
            this.storesRow.Name = "storesRow";
            this.storesRow.OptionsColumn.AllowEdit = false;
            this.storesRow.OptionsColumn.AllowFocus = false;
            this.storesRow.Width = 99;
            // 
            // storeCell
            // 
            this.storeCell.Caption = "列数";
            this.storeCell.FieldName = "storeCell";
            this.storeCell.Name = "storeCell";
            this.storeCell.OptionsColumn.AllowEdit = false;
            this.storeCell.OptionsColumn.AllowFocus = false;
            // 
            // sampleType
            // 
            this.sampleType.Caption = "标本类型";
            this.sampleType.ColumnEdit = this.RGEsampleType;
            this.sampleType.FieldName = "sampleType";
            this.sampleType.Name = "sampleType";
            this.sampleType.OptionsColumn.AllowEdit = false;
            this.sampleType.OptionsColumn.AllowFocus = false;
            // 
            // RGEsampleType
            // 
            this.RGEsampleType.AutoHeight = false;
            this.RGEsampleType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEsampleType.Name = "RGEsampleType";
            this.RGEsampleType.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 47;
            this.sort.Name = "sort";
            this.sort.OptionsColumn.AllowEdit = false;
            this.sort.OptionsColumn.AllowFocus = false;
            this.sort.Visible = true;
            this.sort.VisibleIndex = 4;
            this.sort.Width = 47;
            // 
            // GUserInfo
            // 
            this.GUserInfo.Controls.Add(this.GCUserList);
            this.GUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GUserInfo.Location = new System.Drawing.Point(0, 0);
            this.GUserInfo.Name = "GUserInfo";
            this.GUserInfo.Size = new System.Drawing.Size(747, 571);
            this.GUserInfo.TabIndex = 0;
            this.GUserInfo.Text = "权限列表";
            // 
            // GCUserList
            // 
            this.GCUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCUserList.Location = new System.Drawing.Point(2, 23);
            this.GCUserList.MainView = this.GVUserList;
            this.GCUserList.MenuManager = this.barManager1;
            this.GCUserList.Name = "GCUserList";
            this.GCUserList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEuserNO});
            this.GCUserList.Size = new System.Drawing.Size(743, 546);
            this.GCUserList.TabIndex = 0;
            this.GCUserList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVUserList});
            // 
            // GVUserList
            // 
            this.GVUserList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.storesid,
            this.userNo,
            this.state,
            this.createShelf,
            this.editShelf,
            this.entrySample,
            this.editSample,
            this.delsample,
            this.handleSample,
            this.rehandleSample,
            this.searchSample,
            this.cancelSample});
            this.GVUserList.GridControl = this.GCUserList;
            this.GVUserList.Name = "GVUserList";
            this.GVUserList.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.GVUserList_InitNewRow);
            // 
            // storesid
            // 
            this.storesid.Caption = "存储库";
            this.storesid.FieldName = "storesid";
            this.storesid.Name = "storesid";
            this.storesid.OptionsColumn.AllowEdit = false;
            this.storesid.OptionsColumn.AllowFocus = false;
            this.storesid.Visible = true;
            this.storesid.VisibleIndex = 0;
            // 
            // userNo
            // 
            this.userNo.Caption = "用户名称";
            this.userNo.ColumnEdit = this.RGEuserNO;
            this.userNo.FieldName = "userNo";
            this.userNo.Name = "userNo";
            this.userNo.Visible = true;
            this.userNo.VisibleIndex = 1;
            // 
            // RGEuserNO
            // 
            this.RGEuserNO.AutoHeight = false;
            this.RGEuserNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEuserNO.Name = "RGEuserNO";
            this.RGEuserNO.PopupView = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 47;
            this.state.Name = "state";
            this.state.Visible = true;
            this.state.VisibleIndex = 2;
            this.state.Width = 47;
            // 
            // createShelf
            // 
            this.createShelf.Caption = "创建标本架";
            this.createShelf.FieldName = "createShelf";
            this.createShelf.Name = "createShelf";
            this.createShelf.Visible = true;
            this.createShelf.VisibleIndex = 3;
            // 
            // editShelf
            // 
            this.editShelf.Caption = "编辑标本架";
            this.editShelf.FieldName = "editShelf";
            this.editShelf.Name = "editShelf";
            this.editShelf.Visible = true;
            this.editShelf.VisibleIndex = 4;
            // 
            // entrySample
            // 
            this.entrySample.Caption = "记录标本";
            this.entrySample.FieldName = "entrySample";
            this.entrySample.Name = "entrySample";
            this.entrySample.Visible = true;
            this.entrySample.VisibleIndex = 6;
            // 
            // editSample
            // 
            this.editSample.Caption = "修改记录";
            this.editSample.FieldName = "editSample";
            this.editSample.Name = "editSample";
            this.editSample.Visible = true;
            this.editSample.VisibleIndex = 8;
            // 
            // delsample
            // 
            this.delsample.Caption = "删除记录";
            this.delsample.FieldName = "delsample";
            this.delsample.Name = "delsample";
            this.delsample.Visible = true;
            this.delsample.VisibleIndex = 9;
            // 
            // handleSample
            // 
            this.handleSample.Caption = "处理标本";
            this.handleSample.FieldName = "handleSample";
            this.handleSample.Name = "handleSample";
            this.handleSample.Visible = true;
            this.handleSample.VisibleIndex = 10;
            // 
            // rehandleSample
            // 
            this.rehandleSample.Caption = "反处理标本";
            this.rehandleSample.FieldName = "rehandleSample";
            this.rehandleSample.Name = "rehandleSample";
            this.rehandleSample.Visible = true;
            this.rehandleSample.VisibleIndex = 11;
            // 
            // searchSample
            // 
            this.searchSample.Caption = "标本查询";
            this.searchSample.FieldName = "searchSample";
            this.searchSample.Name = "searchSample";
            this.searchSample.Visible = true;
            this.searchSample.VisibleIndex = 5;
            // 
            // cancelSample
            // 
            this.cancelSample.Caption = "取消录入";
            this.cancelSample.FieldName = "cancelSample";
            this.cancelSample.Name = "cancelSample";
            this.cancelSample.Visible = true;
            this.cancelSample.VisibleIndex = 7;
            // 
            // FrmStoresPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 595);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmStoresPower";
            this.Text = "存储库权限管理";
            this.Load += new System.EventHandler(this.FrmStores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEsampleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GUserInfo)).EndInit();
            this.GUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEuserNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl GUserInfo;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraBars.BarButtonItem BTAdd;
        private DevExpress.XtraBars.BarButtonItem BTEdit;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTDelete;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private DevExpress.XtraGrid.Columns.GridColumn address;
        private DevExpress.XtraGrid.Columns.GridColumn saveday;
        private DevExpress.XtraGrid.Columns.GridColumn storesRow;
        private DevExpress.XtraGrid.Columns.GridColumn storeCell;
        private DevExpress.XtraGrid.Columns.GridColumn sampleType;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEsampleType;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.GridControl GCUserList;
        private DevExpress.XtraGrid.Views.Grid.GridView GVUserList;
        private DevExpress.XtraGrid.Columns.GridColumn storesid;
        private DevExpress.XtraGrid.Columns.GridColumn userNo;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn createShelf;
        private DevExpress.XtraGrid.Columns.GridColumn editShelf;
        private DevExpress.XtraGrid.Columns.GridColumn entrySample;
        private DevExpress.XtraGrid.Columns.GridColumn editSample;
        private DevExpress.XtraGrid.Columns.GridColumn delsample;
        private DevExpress.XtraGrid.Columns.GridColumn handleSample;
        private DevExpress.XtraGrid.Columns.GridColumn rehandleSample;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEuserNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn searchSample;
        private DevExpress.XtraGrid.Columns.GridColumn cancelSample;
    }
}