
namespace workOther.SendEmail
{
    partial class FrmSendEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSendEmail));
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.TEbarcode = new DevExpress.XtraBars.BarEditItem();
            this.TEpatientName = new DevExpress.XtraBars.BarEditItem();
            this.GESendState = new DevExpress.XtraBars.BarEditItem();
            this.RGESendState = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.DEstartTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.DEendTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.BTSelect = new DevExpress.XtraBars.BarButtonItem();
            this.CEAll = new DevExpress.XtraBars.BarCheckItem();
            this.BTEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BTSend = new DevExpress.XtraBars.BarButtonItem();
            this.BTReport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientSexNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testStateNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEtestStateNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEeState = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.checker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGESendState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEtestStateNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEeState)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            this.TEbarcode,
            this.TEpatientName,
            this.DEstartTime,
            this.DEendTime,
            this.GESendState,
            this.BTSelect,
            this.BTSend,
            this.BTReport,
            this.barButtonItem1,
            this.CEAll,
            this.barEditItem1,
            this.BTEdit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 14;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.RGESendState});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(421, 135);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEbarcode, "", false, true, true, 196, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEpatientName, "", false, true, true, 196, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.GESendState, "", true, false, true, 142, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.DEstartTime, "", false, true, true, 150, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.DEendTime, "", false, true, true, 135, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.CEAll),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTEdit, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSend, "", false, false, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTReport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // TEbarcode
            // 
            this.TEbarcode.Caption = "条码号:";
            this.TEbarcode.Edit = this.repositoryItemTextEdit1;
            this.TEbarcode.Id = 0;
            this.TEbarcode.Name = "TEbarcode";
            // 
            // TEpatientName
            // 
            this.TEpatientName.Caption = "姓名:";
            this.TEpatientName.Edit = this.repositoryItemTextEdit2;
            this.TEpatientName.Id = 5;
            this.TEpatientName.Name = "TEpatientName";
            // 
            // GESendState
            // 
            this.GESendState.Caption = "发送状态:";
            this.GESendState.Edit = this.RGESendState;
            this.GESendState.Id = 6;
            this.GESendState.Name = "GESendState";
            // 
            // RGESendState
            // 
            this.RGESendState.AutoHeight = false;
            this.RGESendState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGESendState.Name = "RGESendState";
            // 
            // DEstartTime
            // 
            this.DEstartTime.Caption = "起始时间:";
            this.DEstartTime.Edit = this.repositoryItemDateEdit1;
            this.DEstartTime.Id = 1;
            this.DEstartTime.Name = "DEstartTime";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // DEendTime
            // 
            this.DEendTime.Caption = "结束时间:";
            this.DEendTime.Edit = this.repositoryItemDateEdit2;
            this.DEendTime.Id = 2;
            this.DEendTime.Name = "DEendTime";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // BTSelect
            // 
            this.BTSelect.Caption = "信息查询";
            this.BTSelect.Id = 3;
            this.BTSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSelect.ImageOptions.Image")));
            this.BTSelect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSelect.ImageOptions.LargeImage")));
            this.BTSelect.Name = "BTSelect";
            this.BTSelect.Tag = "18040101";
            this.BTSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSelect_ItemClick);
            // 
            // CEAll
            // 
            this.CEAll.Caption = "全选";
            this.CEAll.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.CEAll.Id = 10;
            this.CEAll.Name = "CEAll";
            this.CEAll.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.CEAll_CheckedChanged);
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑信息";
            this.BTEdit.Id = 13;
            this.BTEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.Image")));
            this.BTEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.LargeImage")));
            this.BTEdit.Name = "BTEdit";
            this.BTEdit.Tag = "18040104";
            this.BTEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEdit_ItemClick);
            // 
            // BTSend
            // 
            this.BTSend.Caption = "发送邮件";
            this.BTSend.Id = 4;
            this.BTSend.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSend.ImageOptions.Image")));
            this.BTSend.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSend.ImageOptions.LargeImage")));
            this.BTSend.Name = "BTSend";
            this.BTSend.Tag = "18040102";
            this.BTSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSend_ItemClick);
            // 
            // BTReport
            // 
            this.BTReport.Caption = "查看报告";
            this.BTReport.Id = 7;
            this.BTReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTReport.ImageOptions.Image")));
            this.BTReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTReport.ImageOptions.LargeImage")));
            this.BTReport.Name = "BTReport";
            this.BTReport.Tag = "18040103";
            this.BTReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTReport_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1911, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 694);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1911, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 670);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1911, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 670);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 12;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(0, 24);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEeState,
            this.RGEtestStateNO});
            this.GCInfo.Size = new System.Drawing.Size(1911, 670);
            this.GCInfo.TabIndex = 4;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.id,
            this.barcode,
            this.hospitalBarcode,
            this.hospitalNO,
            this.hospitalNames,
            this.patientName,
            this.ageYear,
            this.patientSexNames,
            this.patientAddress,
            this.testStateNO,
            this.groupCodes,
            this.groupNames,
            this.eState,
            this.checker,
            this.checkTime,
            this.testRemark});
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GVInfo_CustomDrawCell);
            // 
            // check
            // 
            this.check.Caption = "选择";
            this.check.FieldName = "check";
            this.check.MaxWidth = 35;
            this.check.MinWidth = 35;
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 35;
            // 
            // id
            // 
            this.id.Caption = "编号";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Visible = true;
            this.id.VisibleIndex = 1;
            this.id.Width = 107;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.ReadOnly = true;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 2;
            this.barcode.Width = 105;
            // 
            // hospitalBarcode
            // 
            this.hospitalBarcode.Caption = "外部条码号";
            this.hospitalBarcode.FieldName = "hospitalBarcode";
            this.hospitalBarcode.Name = "hospitalBarcode";
            this.hospitalBarcode.OptionsColumn.ReadOnly = true;
            this.hospitalBarcode.Visible = true;
            this.hospitalBarcode.VisibleIndex = 3;
            this.hospitalBarcode.Width = 107;
            // 
            // hospitalNO
            // 
            this.hospitalNO.Caption = "客户编号";
            this.hospitalNO.FieldName = "hospitalNO";
            this.hospitalNO.Name = "hospitalNO";
            this.hospitalNO.OptionsColumn.AllowFocus = false;
            this.hospitalNO.Visible = true;
            this.hospitalNO.VisibleIndex = 4;
            this.hospitalNO.Width = 99;
            // 
            // hospitalNames
            // 
            this.hospitalNames.Caption = "客户名称";
            this.hospitalNames.FieldName = "hospitalNames";
            this.hospitalNames.Name = "hospitalNames";
            this.hospitalNames.OptionsColumn.AllowFocus = false;
            this.hospitalNames.Visible = true;
            this.hospitalNames.VisibleIndex = 5;
            this.hospitalNames.Width = 95;
            // 
            // patientName
            // 
            this.patientName.Caption = "姓名";
            this.patientName.FieldName = "patientName";
            this.patientName.Name = "patientName";
            this.patientName.OptionsColumn.AllowFocus = false;
            this.patientName.Visible = true;
            this.patientName.VisibleIndex = 6;
            this.patientName.Width = 42;
            // 
            // ageYear
            // 
            this.ageYear.Caption = "年龄";
            this.ageYear.FieldName = "ageYear";
            this.ageYear.Name = "ageYear";
            this.ageYear.OptionsColumn.AllowFocus = false;
            this.ageYear.Visible = true;
            this.ageYear.VisibleIndex = 7;
            this.ageYear.Width = 42;
            // 
            // patientSexNames
            // 
            this.patientSexNames.Caption = "性别";
            this.patientSexNames.FieldName = "patientSexNames";
            this.patientSexNames.Name = "patientSexNames";
            this.patientSexNames.OptionsColumn.AllowFocus = false;
            this.patientSexNames.Visible = true;
            this.patientSexNames.VisibleIndex = 8;
            this.patientSexNames.Width = 42;
            // 
            // patientAddress
            // 
            this.patientAddress.Caption = "电子邮箱";
            this.patientAddress.FieldName = "patientAddress";
            this.patientAddress.Name = "patientAddress";
            this.patientAddress.OptionsColumn.AllowEdit = false;
            this.patientAddress.OptionsColumn.AllowFocus = false;
            this.patientAddress.Visible = true;
            this.patientAddress.VisibleIndex = 9;
            // 
            // testStateNO
            // 
            this.testStateNO.Caption = "检验状态";
            this.testStateNO.ColumnEdit = this.RGEtestStateNO;
            this.testStateNO.FieldName = "testStateNO";
            this.testStateNO.Name = "testStateNO";
            this.testStateNO.OptionsColumn.AllowFocus = false;
            this.testStateNO.Visible = true;
            this.testStateNO.VisibleIndex = 10;
            this.testStateNO.Width = 102;
            // 
            // RGEtestStateNO
            // 
            this.RGEtestStateNO.AutoHeight = false;
            this.RGEtestStateNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEtestStateNO.Name = "RGEtestStateNO";
            this.RGEtestStateNO.PopupView = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // groupCodes
            // 
            this.groupCodes.Caption = "项目编号";
            this.groupCodes.FieldName = "groupCodes";
            this.groupCodes.Name = "groupCodes";
            this.groupCodes.OptionsColumn.AllowFocus = false;
            this.groupCodes.Visible = true;
            this.groupCodes.VisibleIndex = 11;
            this.groupCodes.Width = 45;
            // 
            // groupNames
            // 
            this.groupNames.Caption = "项目名称";
            this.groupNames.FieldName = "groupNames";
            this.groupNames.Name = "groupNames";
            this.groupNames.OptionsColumn.AllowFocus = false;
            this.groupNames.Visible = true;
            this.groupNames.VisibleIndex = 12;
            this.groupNames.Width = 63;
            // 
            // eState
            // 
            this.eState.Caption = "发送状态";
            this.eState.ColumnEdit = this.RGEeState;
            this.eState.FieldName = "eState";
            this.eState.Name = "eState";
            this.eState.OptionsColumn.AllowFocus = false;
            this.eState.Visible = true;
            this.eState.VisibleIndex = 13;
            this.eState.Width = 133;
            // 
            // RGEeState
            // 
            this.RGEeState.AutoHeight = false;
            this.RGEeState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEeState.Name = "RGEeState";
            // 
            // checker
            // 
            this.checker.Caption = "审核者";
            this.checker.FieldName = "checker";
            this.checker.Name = "checker";
            this.checker.OptionsColumn.AllowFocus = false;
            this.checker.Visible = true;
            this.checker.VisibleIndex = 14;
            this.checker.Width = 99;
            // 
            // checkTime
            // 
            this.checkTime.Caption = "审核时间";
            this.checkTime.FieldName = "checkTime";
            this.checkTime.Name = "checkTime";
            this.checkTime.OptionsColumn.AllowFocus = false;
            this.checkTime.Visible = true;
            this.checkTime.VisibleIndex = 15;
            this.checkTime.Width = 159;
            // 
            // testRemark
            // 
            this.testRemark.Caption = "备注";
            this.testRemark.FieldName = "testRemark";
            this.testRemark.MaxWidth = 300;
            this.testRemark.Name = "testRemark";
            this.testRemark.OptionsColumn.AllowFocus = false;
            this.testRemark.Visible = true;
            this.testRemark.VisibleIndex = 16;
            this.testRemark.Width = 174;
            // 
            // FrmSendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1911, 694);
            this.Controls.Add(this.GCInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmSendEmail.IconOptions.Image")));
            this.Name = "FrmSendEmail";
            this.Text = "发送邮件";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGESendState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEtestStateNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEeState)).EndInit();
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
        private DevExpress.XtraBars.BarEditItem DEstartTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem DEendTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem BTSelect;
        private DevExpress.XtraBars.BarButtonItem BTSend;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNO;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNames;
        private DevExpress.XtraGrid.Columns.GridColumn patientName;
        private DevExpress.XtraGrid.Columns.GridColumn ageYear;
        private DevExpress.XtraGrid.Columns.GridColumn patientSexNames;
        private DevExpress.XtraGrid.Columns.GridColumn testRemark;
        private DevExpress.XtraGrid.Columns.GridColumn groupCodes;
        private DevExpress.XtraGrid.Columns.GridColumn groupNames;
        private DevExpress.XtraGrid.Columns.GridColumn eState;
        private DevExpress.XtraBars.BarEditItem TEpatientName;
        private DevExpress.XtraBars.BarEditItem GESendState;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGESendState;
        private DevExpress.XtraGrid.Columns.GridColumn checker;
        private DevExpress.XtraGrid.Columns.GridColumn checkTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEeState;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn testStateNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEtestStateNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraBars.BarButtonItem BTReport;
        private DevExpress.XtraBars.BarEditItem TEbarcode;
        private DevExpress.XtraBars.BarCheckItem CEAll;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarButtonItem BTEdit;
        private DevExpress.XtraGrid.Columns.GridColumn patientAddress;
    }
}

