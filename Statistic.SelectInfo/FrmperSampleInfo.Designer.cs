
namespace Statistic.optInfo
{
    partial class FrmperSampleInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfos = new DevExpress.XtraGrid.GridControl();
            this.GVInfos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientSexNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perStateNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEperStateNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.creater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RDEcheckTime = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.urgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.applyItemCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.applyItemNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEperStateNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEcheckTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEcheckTime.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
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
            this.BTSelect});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTSelect
            // 
            this.BTSelect.Caption = "查询";
            this.BTSelect.Id = 0;
            this.BTSelect.ImageOptions.Image = global::Statistic.optInfo.Properties.Resources.zoom_16x16;
            this.BTSelect.ImageOptions.LargeImage = global::Statistic.optInfo.Properties.Resources.zoom_32x32;
            this.BTSelect.Name = "BTSelect";
            this.BTSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSelect_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1171, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 720);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1171, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 696);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1171, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 696);
            // 
            // GCInfos
            // 
            this.GCInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfos.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfos.Location = new System.Drawing.Point(0, 24);
            this.GCInfos.MainView = this.GVInfos;
            this.GCInfos.Name = "GCInfos";
            this.GCInfos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.RGEperStateNO,
            this.RDEcheckTime});
            this.GCInfos.Size = new System.Drawing.Size(1171, 696);
            this.GCInfos.TabIndex = 9;
            this.GCInfos.Tag = "perSampleInfo";
            this.GCInfos.UseEmbeddedNavigator = true;
            this.GCInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfos});
            // 
            // GVInfos
            // 
            this.GVInfos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.barcode,
            this.hospitalNO,
            this.hospitalNames,
            this.patientName,
            this.patientSexNames,
            this.ageYear,
            this.perStateNO,
            this.creater,
            this.createTime,
            this.checker,
            this.checkTime,
            this.urgent,
            this.applyItemCodes,
            this.applyItemNames});
            this.GVInfos.DetailHeight = 408;
            this.GVInfos.GridControl = this.GCInfos;
            this.GVInfos.Name = "GVInfos";
            this.GVInfos.OptionsFind.AlwaysVisible = true;
            this.GVInfos.OptionsFind.ShowCloseButton = false;
            this.GVInfos.OptionsSelection.MultiSelect = true;
            this.GVInfos.OptionsView.ColumnAutoWidth = false;
            this.GVInfos.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "样本编号";
            this.id.FieldName = "id";
            this.id.MaxWidth = 100;
            this.id.MinWidth = 60;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            this.id.Width = 60;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.MinWidth = 60;
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.AllowFocus = false;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 1;
            // 
            // hospitalNO
            // 
            this.hospitalNO.Caption = "客户编号";
            this.hospitalNO.FieldName = "hospitalNO";
            this.hospitalNO.MaxWidth = 70;
            this.hospitalNO.MinWidth = 70;
            this.hospitalNO.Name = "hospitalNO";
            this.hospitalNO.OptionsColumn.AllowFocus = false;
            this.hospitalNO.Visible = true;
            this.hospitalNO.VisibleIndex = 2;
            this.hospitalNO.Width = 70;
            // 
            // hospitalNames
            // 
            this.hospitalNames.Caption = "客户名称";
            this.hospitalNames.FieldName = "hospitalNames";
            this.hospitalNames.MinWidth = 60;
            this.hospitalNames.Name = "hospitalNames";
            this.hospitalNames.OptionsColumn.AllowFocus = false;
            this.hospitalNames.Visible = true;
            this.hospitalNames.VisibleIndex = 3;
            // 
            // patientName
            // 
            this.patientName.Caption = "姓名";
            this.patientName.FieldName = "patientName";
            this.patientName.MinWidth = 40;
            this.patientName.Name = "patientName";
            this.patientName.OptionsColumn.AllowFocus = false;
            this.patientName.Visible = true;
            this.patientName.VisibleIndex = 4;
            this.patientName.Width = 66;
            // 
            // patientSexNames
            // 
            this.patientSexNames.Caption = "性别";
            this.patientSexNames.FieldName = "patientSexNames";
            this.patientSexNames.MaxWidth = 39;
            this.patientSexNames.MinWidth = 39;
            this.patientSexNames.Name = "patientSexNames";
            this.patientSexNames.OptionsColumn.AllowFocus = false;
            this.patientSexNames.Visible = true;
            this.patientSexNames.VisibleIndex = 5;
            this.patientSexNames.Width = 39;
            // 
            // ageYear
            // 
            this.ageYear.Caption = "年龄";
            this.ageYear.FieldName = "ageYear";
            this.ageYear.MaxWidth = 39;
            this.ageYear.MinWidth = 39;
            this.ageYear.Name = "ageYear";
            this.ageYear.OptionsColumn.AllowFocus = false;
            this.ageYear.Visible = true;
            this.ageYear.VisibleIndex = 6;
            this.ageYear.Width = 39;
            // 
            // perStateNO
            // 
            this.perStateNO.Caption = "样本状态";
            this.perStateNO.ColumnEdit = this.RGEperStateNO;
            this.perStateNO.FieldName = "perStateNO";
            this.perStateNO.MaxWidth = 66;
            this.perStateNO.MinWidth = 66;
            this.perStateNO.Name = "perStateNO";
            this.perStateNO.OptionsColumn.AllowFocus = false;
            this.perStateNO.Visible = true;
            this.perStateNO.VisibleIndex = 7;
            this.perStateNO.Width = 66;
            // 
            // RGEperStateNO
            // 
            this.RGEperStateNO.AutoHeight = false;
            this.RGEperStateNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEperStateNO.Name = "RGEperStateNO";
            this.RGEperStateNO.NullText = "0";
            this.RGEperStateNO.PopupView = this.gridView7;
            // 
            // gridView7
            // 
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // creater
            // 
            this.creater.Caption = "录入者";
            this.creater.FieldName = "creater";
            this.creater.MinWidth = 60;
            this.creater.Name = "creater";
            this.creater.OptionsColumn.AllowFocus = false;
            this.creater.Visible = true;
            this.creater.VisibleIndex = 8;
            this.creater.Width = 60;
            // 
            // createTime
            // 
            this.createTime.Caption = "录入时间";
            this.createTime.FieldName = "createTime";
            this.createTime.MinWidth = 60;
            this.createTime.Name = "createTime";
            this.createTime.OptionsColumn.AllowFocus = false;
            this.createTime.Visible = true;
            this.createTime.VisibleIndex = 9;
            this.createTime.Width = 81;
            // 
            // checker
            // 
            this.checker.Caption = "审核者";
            this.checker.FieldName = "checker";
            this.checker.MinWidth = 60;
            this.checker.Name = "checker";
            this.checker.OptionsColumn.AllowFocus = false;
            this.checker.Visible = true;
            this.checker.VisibleIndex = 10;
            this.checker.Width = 60;
            // 
            // checkTime
            // 
            this.checkTime.Caption = "审核时间";
            this.checkTime.ColumnEdit = this.RDEcheckTime;
            this.checkTime.FieldName = "checkTime";
            this.checkTime.MaxWidth = 140;
            this.checkTime.MinWidth = 60;
            this.checkTime.Name = "checkTime";
            this.checkTime.OptionsColumn.AllowFocus = false;
            this.checkTime.Visible = true;
            this.checkTime.VisibleIndex = 11;
            this.checkTime.Width = 70;
            // 
            // RDEcheckTime
            // 
            this.RDEcheckTime.AutoHeight = false;
            this.RDEcheckTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RDEcheckTime.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RDEcheckTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.RDEcheckTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RDEcheckTime.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.RDEcheckTime.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.RDEcheckTime.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.RDEcheckTime.Mask.UseMaskAsDisplayFormat = true;
            this.RDEcheckTime.Name = "RDEcheckTime";
            // 
            // urgent
            // 
            this.urgent.Caption = "急";
            this.urgent.FieldName = "urgent";
            this.urgent.MaxWidth = 31;
            this.urgent.MinWidth = 31;
            this.urgent.Name = "urgent";
            this.urgent.OptionsColumn.AllowFocus = false;
            this.urgent.Visible = true;
            this.urgent.VisibleIndex = 12;
            this.urgent.Width = 31;
            // 
            // applyItemCodes
            // 
            this.applyItemCodes.Caption = "项目编号";
            this.applyItemCodes.FieldName = "applyItemCodes";
            this.applyItemCodes.Name = "applyItemCodes";
            this.applyItemCodes.OptionsColumn.AllowFocus = false;
            this.applyItemCodes.OptionsFilter.AllowFilter = false;
            this.applyItemCodes.Visible = true;
            this.applyItemCodes.VisibleIndex = 13;
            // 
            // applyItemNames
            // 
            this.applyItemNames.Caption = "项目名称";
            this.applyItemNames.FieldName = "applyItemNames";
            this.applyItemNames.Name = "applyItemNames";
            this.applyItemNames.OptionsColumn.AllowFocus = false;
            this.applyItemNames.OptionsFilter.AllowFilter = false;
            this.applyItemNames.Visible = true;
            this.applyItemNames.VisibleIndex = 14;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // FrmperSampleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 720);
            this.Controls.Add(this.GCInfos);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmperSampleInfo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEperStateNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEcheckTime.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDEcheckTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTSelect;
        private DevExpress.XtraGrid.GridControl GCInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfos;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNO;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNames;
        private DevExpress.XtraGrid.Columns.GridColumn patientName;
        private DevExpress.XtraGrid.Columns.GridColumn patientSexNames;
        private DevExpress.XtraGrid.Columns.GridColumn ageYear;
        private DevExpress.XtraGrid.Columns.GridColumn perStateNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEperStateNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn creater;
        private DevExpress.XtraGrid.Columns.GridColumn createTime;
        private DevExpress.XtraGrid.Columns.GridColumn checker;
        private DevExpress.XtraGrid.Columns.GridColumn checkTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RDEcheckTime;
        private DevExpress.XtraGrid.Columns.GridColumn urgent;
        private DevExpress.XtraGrid.Columns.GridColumn applyItemCodes;
        private DevExpress.XtraGrid.Columns.GridColumn applyItemNames;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    }
}

