
namespace WorkQC.ItemInfo
{
    partial class FrmEditResult
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
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTClear = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.itemNOs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEitemNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.itemResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultRule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zVlaue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gradeid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEgradeid = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.createTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEitemNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgradeid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
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
            // 
            // BTSave
            // 
            this.BTSave.Caption = "确定";
            this.BTSave.Id = 0;
            this.BTSave.ImageOptions.Image = global::WorkQC.ItemInfo.Properties.Resources.apply_16x167;
            this.BTSave.ImageOptions.LargeImage = global::WorkQC.ItemInfo.Properties.Resources.apply_32x324;
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTClear
            // 
            this.BTClear.Caption = "取消";
            this.BTClear.Id = 1;
            this.BTClear.ImageOptions.Image = global::WorkQC.ItemInfo.Properties.Resources.cancel_16x169;
            this.BTClear.ImageOptions.LargeImage = global::WorkQC.ItemInfo.Properties.Resources.cancel_32x325;
            this.BTClear.Name = "BTClear";
            this.BTClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTClear_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1151, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 542);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1151, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 518);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1151, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 518);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEgradeid,
            this.RGEitemNO,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1151, 518);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.itemNOs,
            this.itemResult,
            this.resultType,
            this.sort,
            this.resultRule,
            this.zVlaue,
            this.state,
            this.gradeid,
            this.createTime,
            this.gridColumn1});
            this.gridView1.DetailHeight = 408;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // itemNOs
            // 
            this.itemNOs.Caption = "项目名称";
            this.itemNOs.ColumnEdit = this.RGEitemNO;
            this.itemNOs.FieldName = "itemNO";
            this.itemNOs.MinWidth = 23;
            this.itemNOs.Name = "itemNOs";
            this.itemNOs.OptionsColumn.AllowFocus = false;
            this.itemNOs.Visible = true;
            this.itemNOs.VisibleIndex = 0;
            this.itemNOs.Width = 87;
            // 
            // RGEitemNO
            // 
            this.RGEitemNO.AutoHeight = false;
            this.RGEitemNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEitemNO.Name = "RGEitemNO";
            this.RGEitemNO.PopupView = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 408;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "项目结果";
            this.itemResult.FieldName = "itemResult";
            this.itemResult.MinWidth = 23;
            this.itemResult.Name = "itemResult";
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 3;
            this.itemResult.Width = 87;
            // 
            // resultType
            // 
            this.resultType.Caption = "结果类型";
            this.resultType.FieldName = "resultType";
            this.resultType.MaxWidth = 60;
            this.resultType.MinWidth = 23;
            this.resultType.Name = "resultType";
            this.resultType.OptionsColumn.AllowFocus = false;
            this.resultType.Visible = true;
            this.resultType.VisibleIndex = 5;
            this.resultType.Width = 60;
            // 
            // sort
            // 
            this.sort.Caption = "次数";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 41;
            this.sort.MinWidth = 23;
            this.sort.Name = "sort";
            this.sort.OptionsColumn.AllowFocus = false;
            this.sort.Visible = true;
            this.sort.VisibleIndex = 2;
            this.sort.Width = 41;
            // 
            // resultRule
            // 
            this.resultRule.Caption = "违反规则";
            this.resultRule.FieldName = "resultRule";
            this.resultRule.MinWidth = 23;
            this.resultRule.Name = "resultRule";
            this.resultRule.OptionsColumn.AllowFocus = false;
            this.resultRule.Visible = true;
            this.resultRule.VisibleIndex = 6;
            this.resultRule.Width = 87;
            // 
            // zVlaue
            // 
            this.zVlaue.Caption = "Z分数值";
            this.zVlaue.FieldName = "zVlaue";
            this.zVlaue.MinWidth = 23;
            this.zVlaue.Name = "zVlaue";
            this.zVlaue.Visible = true;
            this.zVlaue.VisibleIndex = 4;
            this.zVlaue.Width = 87;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 41;
            this.state.MinWidth = 23;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 9;
            this.state.Width = 41;
            // 
            // gradeid
            // 
            this.gradeid.Caption = "质控品类型";
            this.gradeid.ColumnEdit = this.RGEgradeid;
            this.gradeid.FieldName = "planGradeid";
            this.gradeid.MinWidth = 23;
            this.gradeid.Name = "gradeid";
            this.gradeid.OptionsColumn.AllowFocus = false;
            this.gradeid.Visible = true;
            this.gradeid.VisibleIndex = 1;
            this.gradeid.Width = 87;
            // 
            // RGEgradeid
            // 
            this.RGEgradeid.AutoHeight = false;
            this.RGEgradeid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgradeid.Name = "RGEgradeid";
            this.RGEgradeid.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 408;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // createTime
            // 
            this.createTime.Caption = "质控时间";
            this.createTime.ColumnEdit = this.repositoryItemDateEdit1;
            this.createTime.FieldName = "createTime";
            this.createTime.MinWidth = 23;
            this.createTime.Name = "createTime";
            this.createTime.OptionsColumn.AllowFocus = false;
            this.createTime.Visible = true;
            this.createTime.VisibleIndex = 7;
            this.createTime.Width = 87;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "g";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "g";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "g";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "备注";
            this.gridColumn1.FieldName = "remark";
            this.gridColumn1.MaxWidth = 300;
            this.gridColumn1.MinWidth = 200;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 200;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 24);
            this.gridControl2.MainView = this.gridView3;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemDateEdit2});
            this.gridControl2.Size = new System.Drawing.Size(1151, 518);
            this.gridControl2.TabIndex = 13;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.qcTime,
            this.gridColumn11});
            this.gridView3.DetailHeight = 408;
            this.gridView3.GridControl = this.gridControl2;
            this.gridView3.Name = "gridView3";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "项目名称";
            this.gridColumn2.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.gridColumn2.FieldName = "itemNO";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 87;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.gridView5;
            // 
            // gridView5
            // 
            this.gridView5.DetailHeight = 408;
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "项目结果";
            this.gridColumn3.FieldName = "itemResult";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 87;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "结果类型";
            this.gridColumn4.FieldName = "resultType";
            this.gridColumn4.MaxWidth = 60;
            this.gridColumn4.MinWidth = 23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "次数";
            this.gridColumn5.FieldName = "sort";
            this.gridColumn5.MaxWidth = 41;
            this.gridColumn5.MinWidth = 23;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 41;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "违反规则";
            this.gridColumn6.FieldName = "resultRule";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 87;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Z分数值";
            this.gridColumn7.FieldName = "zVlaue";
            this.gridColumn7.MinWidth = 23;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 87;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "状态";
            this.gridColumn8.FieldName = "state";
            this.gridColumn8.MaxWidth = 41;
            this.gridColumn8.MinWidth = 23;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 41;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "质控品类型";
            this.gridColumn9.ColumnEdit = this.repositoryItemGridLookUpEdit2;
            this.gridColumn9.FieldName = "planGradeid";
            this.gridColumn9.MinWidth = 23;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 87;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.PopupView = this.gridView4;
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 408;
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // qcTime
            // 
            this.qcTime.Caption = "质控时间";
            this.qcTime.ColumnEdit = this.repositoryItemDateEdit2;
            this.qcTime.FieldName = "qcTime";
            this.qcTime.MinWidth = 23;
            this.qcTime.Name = "qcTime";
            this.qcTime.OptionsColumn.AllowFocus = false;
            this.qcTime.Visible = true;
            this.qcTime.VisibleIndex = 7;
            this.qcTime.Width = 87;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.DisplayFormat.FormatString = "g";
            this.repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit2.EditFormat.FormatString = "g";
            this.repositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit2.Mask.EditMask = "g";
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "备注";
            this.gridColumn11.FieldName = "remark";
            this.gridColumn11.MaxWidth = 300;
            this.gridColumn11.MinWidth = 200;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 200;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl1.Location = new System.Drawing.Point(0, 24);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(0, 518);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl2.Location = new System.Drawing.Point(1151, 24);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(0, 518);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 542);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(1151, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl4.Location = new System.Drawing.Point(0, 24);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(1151, 0);
            // 
            // FrmEditResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 542);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = global::WorkQC.ItemInfo.Properties.Resources.new3;
            this.Name = "FrmEditResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑质控结果";
            this.Load += new System.EventHandler(this.FrmEditResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEitemNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgradeid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn itemNOs;
        private DevExpress.XtraGrid.Columns.GridColumn itemResult;
        private DevExpress.XtraGrid.Columns.GridColumn resultType;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraGrid.Columns.GridColumn resultRule;
        private DevExpress.XtraGrid.Columns.GridColumn zVlaue;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn gradeid;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEitemNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgradeid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn createTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn qcTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
    }
}