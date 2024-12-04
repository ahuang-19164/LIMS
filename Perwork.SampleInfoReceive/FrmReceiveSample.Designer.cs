using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Perwork.SampleInfoReceive
{
    partial class FrmReceiveSample
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceiveSample));
            this.GCSampleInfo = new DevExpress.XtraGrid.GridControl();
            this.GVSampleInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.frameNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pathologyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hosBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.hospitalNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.medicalNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.agentNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleShapeNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientSexNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cutPart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.receiveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menstrualTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clinicalDiagnosis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientTypeNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageMoth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.department = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bedNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sendDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.doctorPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleTypeNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.urgent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GEHospitalNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEAgentNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEPatientType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GESampleType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GESampleShape = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.groupItem = new DevExpress.XtraEditors.GroupControl();
            this.GCItemInfo = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.disNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BTdelete = new DevExpress.XtraEditors.SimpleButton();
            this.CBPrintInfo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CEScanState = new DevExpress.XtraEditors.CheckEdit();
            this.CESelectState = new DevExpress.XtraEditors.CheckEdit();
            this.CEFrameNO = new DevExpress.XtraEditors.CheckEdit();
            this.TEFrameSerials = new DevExpress.XtraEditors.TextEdit();
            this.CECheckNO = new DevExpress.XtraEditors.CheckEdit();
            this.TEhosBarcode = new DevExpress.XtraEditors.TextEdit();
            this.TEbarcode = new DevExpress.XtraEditors.TextEdit();
            this.BTPrints = new DevExpress.XtraEditors.SimpleButton();
            this.BTReceives = new DevExpress.XtraEditors.SimpleButton();
            this.DEReceiveTimes = new DevExpress.XtraEditors.DateEdit();
            this.CECheckAll = new DevExpress.XtraEditors.CheckEdit();
            this.BTCreateFrameNO = new DevExpress.XtraEditors.SimpleButton();
            this.TEFrameTops = new DevExpress.XtraEditors.TextEdit();
            this.BTCreateTestNO = new DevExpress.XtraEditors.SimpleButton();
            this.TENOSerials = new DevExpress.XtraEditors.TextEdit();
            this.TENOTabs = new DevExpress.XtraEditors.TextEdit();
            this.CECustomNO = new DevExpress.XtraEditors.CheckEdit();
            this.CEDefultNO = new DevExpress.XtraEditors.CheckEdit();
            this.BTSelects = new DevExpress.XtraEditors.SimpleButton();
            this.DEEndTimes = new DevExpress.XtraEditors.DateEdit();
            this.DEStartTimes = new DevExpress.XtraEditors.DateEdit();
            this.GEgroupNOs = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TEFrameSerialss = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEHospitalNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEAgentNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEPatientType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GESampleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GESampleShape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupItem)).BeginInit();
            this.groupItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCItemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBPrintInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEScanState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CESelectState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEFrameNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFrameSerials.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECheckNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEhosBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEReceiveTimes.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEReceiveTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECheckAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFrameTops.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENOSerials.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENOTabs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECustomNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEDefultNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEgroupNOs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFrameSerialss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // GCSampleInfo
            // 
            this.GCSampleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSampleInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCSampleInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCSampleInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCSampleInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCSampleInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode1.RelationName = "Level1";
            this.GCSampleInfo.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GCSampleInfo.Location = new System.Drawing.Point(2, 23);
            this.GCSampleInfo.MainView = this.GVSampleInfo;
            this.GCSampleInfo.Name = "GCSampleInfo";
            this.GCSampleInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.GEHospitalNO,
            this.GEAgentNO,
            this.GEPatientType,
            this.GESampleType,
            this.GESampleShape});
            this.GCSampleInfo.Size = new System.Drawing.Size(1239, 639);
            this.GCSampleInfo.TabIndex = 9;
            this.GCSampleInfo.UseEmbeddedNavigator = true;
            this.GCSampleInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVSampleInfo});
            // 
            // GVSampleInfo
            // 
            this.GVSampleInfo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GVSampleInfo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.GVSampleInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.sampleID,
            this.testNo,
            this.frameNo,
            this.groupNO,
            this.barcode,
            this.pathologyNo,
            this.hosBarcode,
            this.hospitalNames,
            this.medicalNo,
            this.agentNames,
            this.sampleShapeNames,
            this.patientName,
            this.patientSexNames,
            this.ageYear,
            this.ageNames,
            this.cutPart,
            this.sampleTime,
            this.receiveTime,
            this.menstrualTime,
            this.clinicalDiagnosis,
            this.patientTypeNames,
            this.ageMoth,
            this.ageDay,
            this.department,
            this.bedNo,
            this.patientPhone,
            this.patientCardNo,
            this.patientAddress,
            this.sendDoctor,
            this.doctorPhone,
            this.sampleTypeNames,
            this.perRemark,
            this.groupCodes,
            this.groupNames,
            this.state,
            this.urgent});
            this.GVSampleInfo.DetailHeight = 408;
            this.GVSampleInfo.GridControl = this.GCSampleInfo;
            this.GVSampleInfo.Name = "GVSampleInfo";
            this.GVSampleInfo.OptionsFind.AlwaysVisible = true;
            this.GVSampleInfo.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
            this.GVSampleInfo.OptionsFind.HighlightFindResults = false;
            this.GVSampleInfo.OptionsFind.SearchInPreview = true;
            this.GVSampleInfo.OptionsView.ColumnAutoWidth = false;
            this.GVSampleInfo.OptionsView.ShowGroupPanel = false;
            this.GVSampleInfo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.urgent, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.state, DevExpress.Data.ColumnSortOrder.Descending)});
            this.GVSampleInfo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GVSampleInfo_RowClick);
            this.GVSampleInfo.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.GVSampleInfo_CustomDrawCell);
            this.GVSampleInfo.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GVSampleInfo_RowCellStyle);
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
            // sampleID
            // 
            this.sampleID.Caption = "样本ID";
            this.sampleID.FieldName = "id";
            this.sampleID.MinWidth = 23;
            this.sampleID.Name = "sampleID";
            this.sampleID.OptionsColumn.AllowFocus = false;
            this.sampleID.Visible = true;
            this.sampleID.VisibleIndex = 1;
            this.sampleID.Width = 87;
            // 
            // testNo
            // 
            this.testNo.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.testNo.AppearanceCell.Options.UseBackColor = true;
            this.testNo.Caption = "实验号";
            this.testNo.FieldName = "testNo";
            this.testNo.MinWidth = 23;
            this.testNo.Name = "testNo";
            this.testNo.Visible = true;
            this.testNo.VisibleIndex = 2;
            this.testNo.Width = 87;
            // 
            // frameNo
            // 
            this.frameNo.AppearanceCell.BackColor = System.Drawing.Color.SpringGreen;
            this.frameNo.AppearanceCell.Options.UseBackColor = true;
            this.frameNo.Caption = "试管架号";
            this.frameNo.FieldName = "frameNo";
            this.frameNo.Name = "frameNo";
            this.frameNo.Visible = true;
            this.frameNo.VisibleIndex = 3;
            // 
            // groupNO
            // 
            this.groupNO.Caption = "专业组";
            this.groupNO.FieldName = "groupNO";
            this.groupNO.MinWidth = 23;
            this.groupNO.Name = "groupNO";
            this.groupNO.Width = 87;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.MinWidth = 23;
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.ReadOnly = true;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 4;
            this.barcode.Width = 87;
            // 
            // pathologyNo
            // 
            this.pathologyNo.Caption = "病理号";
            this.pathologyNo.FieldName = "pathologyNo";
            this.pathologyNo.MinWidth = 23;
            this.pathologyNo.Name = "pathologyNo";
            this.pathologyNo.OptionsColumn.AllowFocus = false;
            this.pathologyNo.Visible = true;
            this.pathologyNo.VisibleIndex = 12;
            this.pathologyNo.Width = 87;
            // 
            // hosBarcode
            // 
            this.hosBarcode.Caption = "医院条码";
            this.hosBarcode.FieldName = "hosBarcode";
            this.hosBarcode.MinWidth = 23;
            this.hosBarcode.Name = "hosBarcode";
            this.hosBarcode.OptionsColumn.AllowFocus = false;
            this.hosBarcode.Width = 87;
            // 
            // hospitalNames
            // 
            this.hospitalNames.Caption = "医院名称";
            this.hospitalNames.FieldName = "hospitalNames";
            this.hospitalNames.MinWidth = 23;
            this.hospitalNames.Name = "hospitalNames";
            this.hospitalNames.OptionsColumn.AllowFocus = false;
            this.hospitalNames.Visible = true;
            this.hospitalNames.VisibleIndex = 5;
            this.hospitalNames.Width = 87;
            // 
            // medicalNo
            // 
            this.medicalNo.Caption = "病历号";
            this.medicalNo.FieldName = "medicalNo";
            this.medicalNo.MinWidth = 23;
            this.medicalNo.Name = "medicalNo";
            this.medicalNo.OptionsColumn.AllowFocus = false;
            this.medicalNo.Visible = true;
            this.medicalNo.VisibleIndex = 6;
            this.medicalNo.Width = 87;
            // 
            // agentNames
            // 
            this.agentNames.Caption = "代理商名称";
            this.agentNames.FieldName = "agentNames";
            this.agentNames.MinWidth = 23;
            this.agentNames.Name = "agentNames";
            this.agentNames.OptionsColumn.AllowFocus = false;
            this.agentNames.Width = 87;
            // 
            // sampleShapeNames
            // 
            this.sampleShapeNames.Caption = "标本性状";
            this.sampleShapeNames.FieldName = "sampleShapeNames";
            this.sampleShapeNames.MinWidth = 23;
            this.sampleShapeNames.Name = "sampleShapeNames";
            this.sampleShapeNames.OptionsColumn.AllowFocus = false;
            this.sampleShapeNames.Visible = true;
            this.sampleShapeNames.VisibleIndex = 14;
            this.sampleShapeNames.Width = 87;
            // 
            // patientName
            // 
            this.patientName.Caption = "姓名";
            this.patientName.FieldName = "patientName";
            this.patientName.MinWidth = 23;
            this.patientName.Name = "patientName";
            this.patientName.OptionsColumn.AllowFocus = false;
            this.patientName.Visible = true;
            this.patientName.VisibleIndex = 7;
            this.patientName.Width = 87;
            // 
            // patientSexNames
            // 
            this.patientSexNames.Caption = "性别";
            this.patientSexNames.FieldName = "patientSexNames";
            this.patientSexNames.MinWidth = 23;
            this.patientSexNames.Name = "patientSexNames";
            this.patientSexNames.OptionsColumn.AllowFocus = false;
            this.patientSexNames.Visible = true;
            this.patientSexNames.VisibleIndex = 8;
            this.patientSexNames.Width = 87;
            // 
            // ageYear
            // 
            this.ageYear.Caption = "年龄";
            this.ageYear.FieldName = "ageYear";
            this.ageYear.MaxWidth = 35;
            this.ageYear.MinWidth = 35;
            this.ageYear.Name = "ageYear";
            this.ageYear.OptionsColumn.AllowFocus = false;
            this.ageYear.Visible = true;
            this.ageYear.VisibleIndex = 9;
            this.ageYear.Width = 35;
            // 
            // ageNames
            // 
            this.ageNames.Caption = "岁";
            this.ageNames.FieldName = "ageNames";
            this.ageNames.MaxWidth = 35;
            this.ageNames.MinWidth = 35;
            this.ageNames.Name = "ageNames";
            this.ageNames.OptionsColumn.AllowFocus = false;
            this.ageNames.Visible = true;
            this.ageNames.VisibleIndex = 10;
            this.ageNames.Width = 35;
            // 
            // cutPart
            // 
            this.cutPart.Caption = "切取部位";
            this.cutPart.FieldName = "cutPart";
            this.cutPart.MinWidth = 23;
            this.cutPart.Name = "cutPart";
            this.cutPart.OptionsColumn.AllowFocus = false;
            this.cutPart.Visible = true;
            this.cutPart.VisibleIndex = 15;
            this.cutPart.Width = 87;
            // 
            // sampleTime
            // 
            this.sampleTime.Caption = "采样时间";
            this.sampleTime.FieldName = "sampleTime";
            this.sampleTime.MinWidth = 23;
            this.sampleTime.Name = "sampleTime";
            this.sampleTime.OptionsColumn.AllowFocus = false;
            this.sampleTime.Visible = true;
            this.sampleTime.VisibleIndex = 13;
            this.sampleTime.Width = 87;
            // 
            // receiveTime
            // 
            this.receiveTime.Caption = "接收时间";
            this.receiveTime.FieldName = "receiveTime";
            this.receiveTime.MinWidth = 23;
            this.receiveTime.Name = "receiveTime";
            this.receiveTime.OptionsColumn.AllowFocus = false;
            this.receiveTime.Width = 87;
            // 
            // menstrualTime
            // 
            this.menstrualTime.Caption = "末次月经";
            this.menstrualTime.FieldName = "menstrualTime";
            this.menstrualTime.MinWidth = 23;
            this.menstrualTime.Name = "menstrualTime";
            this.menstrualTime.OptionsColumn.AllowFocus = false;
            this.menstrualTime.Visible = true;
            this.menstrualTime.VisibleIndex = 16;
            this.menstrualTime.Width = 87;
            // 
            // clinicalDiagnosis
            // 
            this.clinicalDiagnosis.Caption = "临床诊断";
            this.clinicalDiagnosis.FieldName = "clinicalDiagnosis";
            this.clinicalDiagnosis.MinWidth = 23;
            this.clinicalDiagnosis.Name = "clinicalDiagnosis";
            this.clinicalDiagnosis.OptionsColumn.AllowFocus = false;
            this.clinicalDiagnosis.Visible = true;
            this.clinicalDiagnosis.VisibleIndex = 17;
            this.clinicalDiagnosis.Width = 87;
            // 
            // patientTypeNames
            // 
            this.patientTypeNames.Caption = "病人类型";
            this.patientTypeNames.FieldName = "patientTypeNames";
            this.patientTypeNames.MinWidth = 23;
            this.patientTypeNames.Name = "patientTypeNames";
            this.patientTypeNames.OptionsColumn.AllowFocus = false;
            this.patientTypeNames.Visible = true;
            this.patientTypeNames.VisibleIndex = 18;
            this.patientTypeNames.Width = 87;
            // 
            // ageMoth
            // 
            this.ageMoth.Caption = "月";
            this.ageMoth.FieldName = "ageMoth";
            this.ageMoth.MinWidth = 23;
            this.ageMoth.Name = "ageMoth";
            this.ageMoth.OptionsColumn.AllowFocus = false;
            this.ageMoth.Width = 87;
            // 
            // ageDay
            // 
            this.ageDay.Caption = "天";
            this.ageDay.FieldName = "ageDay";
            this.ageDay.MinWidth = 23;
            this.ageDay.Name = "ageDay";
            this.ageDay.OptionsColumn.AllowFocus = false;
            this.ageDay.Width = 87;
            // 
            // department
            // 
            this.department.Caption = "科室";
            this.department.FieldName = "department";
            this.department.MinWidth = 23;
            this.department.Name = "department";
            this.department.OptionsColumn.AllowFocus = false;
            this.department.Visible = true;
            this.department.VisibleIndex = 21;
            this.department.Width = 87;
            // 
            // bedNo
            // 
            this.bedNo.Caption = "床号";
            this.bedNo.FieldName = "bedNo";
            this.bedNo.MinWidth = 23;
            this.bedNo.Name = "bedNo";
            this.bedNo.OptionsColumn.AllowFocus = false;
            this.bedNo.Visible = true;
            this.bedNo.VisibleIndex = 22;
            this.bedNo.Width = 87;
            // 
            // patientPhone
            // 
            this.patientPhone.Caption = "病人电话";
            this.patientPhone.FieldName = "patientPhone";
            this.patientPhone.MinWidth = 23;
            this.patientPhone.Name = "patientPhone";
            this.patientPhone.OptionsColumn.AllowFocus = false;
            this.patientPhone.Visible = true;
            this.patientPhone.VisibleIndex = 23;
            this.patientPhone.Width = 87;
            // 
            // patientCardNo
            // 
            this.patientCardNo.Caption = "身份证";
            this.patientCardNo.FieldName = "patientCardNo";
            this.patientCardNo.MinWidth = 23;
            this.patientCardNo.Name = "patientCardNo";
            this.patientCardNo.OptionsColumn.AllowFocus = false;
            this.patientCardNo.Visible = true;
            this.patientCardNo.VisibleIndex = 24;
            this.patientCardNo.Width = 87;
            // 
            // patientAddress
            // 
            this.patientAddress.Caption = "邮箱";
            this.patientAddress.FieldName = "patientAddress";
            this.patientAddress.MinWidth = 23;
            this.patientAddress.Name = "patientAddress";
            this.patientAddress.OptionsColumn.AllowFocus = false;
            this.patientAddress.Visible = true;
            this.patientAddress.VisibleIndex = 25;
            this.patientAddress.Width = 87;
            // 
            // sendDoctor
            // 
            this.sendDoctor.Caption = "送检医生";
            this.sendDoctor.FieldName = "sendDoctor";
            this.sendDoctor.MinWidth = 23;
            this.sendDoctor.Name = "sendDoctor";
            this.sendDoctor.OptionsColumn.AllowFocus = false;
            this.sendDoctor.Visible = true;
            this.sendDoctor.VisibleIndex = 26;
            this.sendDoctor.Width = 87;
            // 
            // doctorPhone
            // 
            this.doctorPhone.Caption = "医生电话";
            this.doctorPhone.FieldName = "doctorPhone";
            this.doctorPhone.MinWidth = 23;
            this.doctorPhone.Name = "doctorPhone";
            this.doctorPhone.OptionsColumn.AllowFocus = false;
            this.doctorPhone.Visible = true;
            this.doctorPhone.VisibleIndex = 27;
            this.doctorPhone.Width = 87;
            // 
            // sampleTypeNames
            // 
            this.sampleTypeNames.Caption = "样本类型";
            this.sampleTypeNames.FieldName = "sampleTypeNames";
            this.sampleTypeNames.MaxWidth = 150;
            this.sampleTypeNames.MinWidth = 60;
            this.sampleTypeNames.Name = "sampleTypeNames";
            this.sampleTypeNames.OptionsColumn.AllowFocus = false;
            this.sampleTypeNames.Visible = true;
            this.sampleTypeNames.VisibleIndex = 11;
            this.sampleTypeNames.Width = 60;
            // 
            // perRemark
            // 
            this.perRemark.Caption = "样本备注";
            this.perRemark.FieldName = "perRemark";
            this.perRemark.MinWidth = 23;
            this.perRemark.Name = "perRemark";
            this.perRemark.OptionsColumn.AllowFocus = false;
            this.perRemark.Visible = true;
            this.perRemark.VisibleIndex = 28;
            this.perRemark.Width = 87;
            // 
            // groupCodes
            // 
            this.groupCodes.Caption = "项目编号";
            this.groupCodes.FieldName = "groupCodes";
            this.groupCodes.MinWidth = 23;
            this.groupCodes.Name = "groupCodes";
            this.groupCodes.OptionsColumn.AllowFocus = false;
            this.groupCodes.Visible = true;
            this.groupCodes.VisibleIndex = 19;
            this.groupCodes.Width = 87;
            // 
            // groupNames
            // 
            this.groupNames.Caption = "项目名称";
            this.groupNames.FieldName = "groupNames";
            this.groupNames.MinWidth = 23;
            this.groupNames.Name = "groupNames";
            this.groupNames.OptionsColumn.AllowFocus = false;
            this.groupNames.Visible = true;
            this.groupNames.VisibleIndex = 20;
            this.groupNames.Width = 87;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MinWidth = 23;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 29;
            this.state.Width = 87;
            // 
            // urgent
            // 
            this.urgent.Caption = "急";
            this.urgent.FieldName = "urgent";
            this.urgent.Name = "urgent";
            this.urgent.OptionsColumn.AllowFocus = false;
            this.urgent.Visible = true;
            this.urgent.VisibleIndex = 30;
            // 
            // GEHospitalNO
            // 
            this.GEHospitalNO.AutoHeight = false;
            this.GEHospitalNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEHospitalNO.Name = "GEHospitalNO";
            this.GEHospitalNO.NullText = "";
            this.GEHospitalNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 408;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // GEAgentNO
            // 
            this.GEAgentNO.AutoHeight = false;
            this.GEAgentNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEAgentNO.Name = "GEAgentNO";
            this.GEAgentNO.NullText = "";
            this.GEAgentNO.PopupView = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 408;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // GEPatientType
            // 
            this.GEPatientType.AutoHeight = false;
            this.GEPatientType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEPatientType.Name = "GEPatientType";
            this.GEPatientType.NullText = "";
            this.GEPatientType.PopupView = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 408;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // GESampleType
            // 
            this.GESampleType.AutoHeight = false;
            this.GESampleType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GESampleType.Name = "GESampleType";
            this.GESampleType.NullText = "";
            this.GESampleType.PopupView = this.gridView4;
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 408;
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // GESampleShape
            // 
            this.GESampleShape.AutoHeight = false;
            this.GESampleShape.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GESampleShape.Name = "GESampleShape";
            this.GESampleShape.NullText = "";
            this.GESampleShape.PopupView = this.gridView5;
            // 
            // gridView5
            // 
            this.gridView5.DetailHeight = 408;
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupItem);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1554, 664);
            this.splitContainerControl1.SplitterPosition = 1243;
            this.splitContainerControl1.TabIndex = 14;
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.GCSampleInfo);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(1243, 664);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "信息列表";
            // 
            // groupItem
            // 
            this.groupItem.Controls.Add(this.GCItemInfo);
            this.groupItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupItem.Location = new System.Drawing.Point(0, 0);
            this.groupItem.Name = "groupItem";
            this.groupItem.Size = new System.Drawing.Size(301, 664);
            this.groupItem.TabIndex = 0;
            this.groupItem.Text = "项目信息";
            // 
            // GCItemInfo
            // 
            this.GCItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCItemInfo.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Default;
            this.GCItemInfo.EmbeddedNavigator.ShowToolTips = false;
            this.GCItemInfo.EmbeddedNavigator.TextStringFormat = "记录 {0} of {1}";
            this.GCItemInfo.Location = new System.Drawing.Point(2, 23);
            this.GCItemInfo.MainView = this.cardView1;
            this.GCItemInfo.Name = "GCItemInfo";
            this.GCItemInfo.Size = new System.Drawing.Size(297, 639);
            this.GCItemInfo.TabIndex = 29;
            this.GCItemInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            // 
            // cardView1
            // 
            this.cardView1.CardCaptionFormat = "项目信息 {0}";
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.no,
            this.names,
            this.disNames,
            this.shortNames});
            this.cardView1.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.cardView1.GridControl = this.GCItemInfo;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.AutoHorzWidth = true;
            this.cardView1.OptionsBehavior.ReadOnly = true;
            this.cardView1.OptionsView.ShowQuickCustomizeButton = false;
            // 
            // no
            // 
            this.no.AppearanceCell.Options.UseTextOptions = true;
            this.no.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.Name = "no";
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            // 
            // disNames
            // 
            this.disNames.Caption = "别名";
            this.disNames.FieldName = "disNames";
            this.disNames.Name = "disNames";
            this.disNames.OptionsColumn.AllowFocus = false;
            this.disNames.Visible = true;
            this.disNames.VisibleIndex = 2;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "简拼";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 3;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1554, 755);
            this.splitContainerControl2.SplitterPosition = 81;
            this.splitContainerControl2.TabIndex = 19;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BTdelete);
            this.layoutControl1.Controls.Add(this.CBPrintInfo);
            this.layoutControl1.Controls.Add(this.CEScanState);
            this.layoutControl1.Controls.Add(this.CESelectState);
            this.layoutControl1.Controls.Add(this.CEFrameNO);
            this.layoutControl1.Controls.Add(this.TEFrameSerials);
            this.layoutControl1.Controls.Add(this.CECheckNO);
            this.layoutControl1.Controls.Add(this.TEhosBarcode);
            this.layoutControl1.Controls.Add(this.TEbarcode);
            this.layoutControl1.Controls.Add(this.BTPrints);
            this.layoutControl1.Controls.Add(this.BTReceives);
            this.layoutControl1.Controls.Add(this.DEReceiveTimes);
            this.layoutControl1.Controls.Add(this.CECheckAll);
            this.layoutControl1.Controls.Add(this.BTCreateFrameNO);
            this.layoutControl1.Controls.Add(this.TEFrameTops);
            this.layoutControl1.Controls.Add(this.BTCreateTestNO);
            this.layoutControl1.Controls.Add(this.TENOSerials);
            this.layoutControl1.Controls.Add(this.TENOTabs);
            this.layoutControl1.Controls.Add(this.CECustomNO);
            this.layoutControl1.Controls.Add(this.CEDefultNO);
            this.layoutControl1.Controls.Add(this.BTSelects);
            this.layoutControl1.Controls.Add(this.DEEndTimes);
            this.layoutControl1.Controls.Add(this.DEStartTimes);
            this.layoutControl1.Controls.Add(this.GEgroupNOs);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1554, 81);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BTdelete
            // 
            this.BTdelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTdelete.ImageOptions.Image")));
            this.BTdelete.Location = new System.Drawing.Point(1270, 54);
            this.BTdelete.Name = "BTdelete";
            this.BTdelete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTdelete.Size = new System.Drawing.Size(74, 25);
            this.BTdelete.StyleController = this.layoutControl1;
            this.BTdelete.TabIndex = 36;
            this.BTdelete.Text = "删除质控";
            // 
            // CBPrintInfo
            // 
            this.CBPrintInfo.Location = new System.Drawing.Point(948, 54);
            this.CBPrintInfo.Name = "CBPrintInfo";
            this.CBPrintInfo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CBPrintInfo.Size = new System.Drawing.Size(217, 20);
            this.CBPrintInfo.StyleController = this.layoutControl1;
            this.CBPrintInfo.TabIndex = 35;
            // 
            // CEScanState
            // 
            this.CEScanState.Location = new System.Drawing.Point(108, 2);
            this.CEScanState.Name = "CEScanState";
            this.CEScanState.Properties.Caption = "扫码模式接收";
            this.CEScanState.Size = new System.Drawing.Size(102, 20);
            this.CEScanState.StyleController = this.layoutControl1;
            this.CEScanState.TabIndex = 34;
            this.CEScanState.CheckedChanged += new System.EventHandler(this.CEScanState_CheckedChanged);
            // 
            // CESelectState
            // 
            this.CESelectState.EditValue = true;
            this.CESelectState.Location = new System.Drawing.Point(2, 2);
            this.CESelectState.Name = "CESelectState";
            this.CESelectState.Properties.Caption = "查询模式接收";
            this.CESelectState.Size = new System.Drawing.Size(102, 20);
            this.CESelectState.StyleController = this.layoutControl1;
            this.CESelectState.TabIndex = 33;
            this.CESelectState.CheckedChanged += new System.EventHandler(this.CESelectState_CheckedChanged);
            // 
            // CEFrameNO
            // 
            this.CEFrameNO.Location = new System.Drawing.Point(333, 28);
            this.CEFrameNO.Name = "CEFrameNO";
            this.CEFrameNO.Properties.Caption = "选择定义试管架号";
            this.CEFrameNO.Size = new System.Drawing.Size(128, 20);
            this.CEFrameNO.StyleController = this.layoutControl1;
            this.CEFrameNO.TabIndex = 31;
            // 
            // TEFrameSerials
            // 
            this.TEFrameSerials.EditValue = "0";
            this.TEFrameSerials.Location = new System.Drawing.Point(1131, 28);
            this.TEFrameSerials.Name = "TEFrameSerials";
            this.TEFrameSerials.Size = new System.Drawing.Size(111, 20);
            this.TEFrameSerials.StyleController = this.layoutControl1;
            this.TEFrameSerials.TabIndex = 30;
            // 
            // CECheckNO
            // 
            this.CECheckNO.Location = new System.Drawing.Point(214, 28);
            this.CECheckNO.Name = "CECheckNO";
            this.CECheckNO.Properties.Caption = "选择定义实验号";
            this.CECheckNO.Size = new System.Drawing.Size(115, 20);
            this.CECheckNO.StyleController = this.layoutControl1;
            this.CECheckNO.TabIndex = 29;
            this.CECheckNO.CheckedChanged += new System.EventHandler(this.CECheckNO_CheckedChanged);
            // 
            // TEhosBarcode
            // 
            this.TEhosBarcode.Location = new System.Drawing.Point(522, 54);
            this.TEhosBarcode.Name = "TEhosBarcode";
            this.TEhosBarcode.Size = new System.Drawing.Size(124, 20);
            this.TEhosBarcode.StyleController = this.layoutControl1;
            this.TEhosBarcode.TabIndex = 28;
            this.TEhosBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TEhosBarcode_KeyDown);
            // 
            // TEbarcode
            // 
            this.TEbarcode.Location = new System.Drawing.Point(259, 54);
            this.TEbarcode.Name = "TEbarcode";
            this.TEbarcode.Size = new System.Drawing.Size(202, 20);
            this.TEbarcode.StyleController = this.layoutControl1;
            this.TEbarcode.TabIndex = 27;
            this.TEbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TEbarcode_KeyDown);
            // 
            // BTPrints
            // 
            this.BTPrints.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTPrints.ImageOptions.Image")));
            this.BTPrints.Location = new System.Drawing.Point(1169, 54);
            this.BTPrints.Name = "BTPrints";
            this.BTPrints.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTPrints.Size = new System.Drawing.Size(97, 24);
            this.BTPrints.StyleController = this.layoutControl1;
            this.BTPrints.TabIndex = 26;
            this.BTPrints.Tag = "13030203";
            this.BTPrints.Text = "补打条码(F2)";
            this.BTPrints.Click += new System.EventHandler(this.BTPrints_Click);
            // 
            // BTReceives
            // 
            this.BTReceives.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTReceives.ImageOptions.Image")));
            this.BTReceives.Location = new System.Drawing.Point(756, 54);
            this.BTReceives.Name = "BTReceives";
            this.BTReceives.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTReceives.Size = new System.Drawing.Size(121, 24);
            this.BTReceives.StyleController = this.layoutControl1;
            this.BTReceives.TabIndex = 25;
            this.BTReceives.Tag = "13030202";
            this.BTReceives.Text = "接收到专业组(F1)";
            this.BTReceives.Click += new System.EventHandler(this.BTReceives_Click);
            // 
            // DEReceiveTimes
            // 
            this.DEReceiveTimes.EditValue = null;
            this.DEReceiveTimes.Location = new System.Drawing.Point(71, 54);
            this.DEReceiveTimes.Name = "DEReceiveTimes";
            this.DEReceiveTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEReceiveTimes.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEReceiveTimes.Size = new System.Drawing.Size(139, 20);
            this.DEReceiveTimes.StyleController = this.layoutControl1;
            this.DEReceiveTimes.TabIndex = 24;
            // 
            // CECheckAll
            // 
            this.CECheckAll.Location = new System.Drawing.Point(650, 54);
            this.CECheckAll.Name = "CECheckAll";
            this.CECheckAll.Properties.Caption = "全选";
            this.CECheckAll.Size = new System.Drawing.Size(102, 20);
            this.CECheckAll.StyleController = this.layoutControl1;
            this.CECheckAll.TabIndex = 18;
            this.CECheckAll.CheckedChanged += new System.EventHandler(this.CECheckAll_CheckedChanged);
            // 
            // BTCreateFrameNO
            // 
            this.BTCreateFrameNO.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTCreateFrameNO.ImageOptions.Image")));
            this.BTCreateFrameNO.Location = new System.Drawing.Point(1246, 28);
            this.BTCreateFrameNO.Name = "BTCreateFrameNO";
            this.BTCreateFrameNO.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTCreateFrameNO.Size = new System.Drawing.Size(98, 22);
            this.BTCreateFrameNO.StyleController = this.layoutControl1;
            this.BTCreateFrameNO.TabIndex = 17;
            this.BTCreateFrameNO.Text = "生成试管架号";
            this.BTCreateFrameNO.Click += new System.EventHandler(this.BTCreateFrameNO_Click);
            // 
            // TEFrameTops
            // 
            this.TEFrameTops.Location = new System.Drawing.Point(938, 28);
            this.TEFrameTops.Name = "TEFrameTops";
            this.TEFrameTops.Size = new System.Drawing.Size(122, 20);
            this.TEFrameTops.StyleController = this.layoutControl1;
            this.TEFrameTops.TabIndex = 15;
            // 
            // BTCreateTestNO
            // 
            this.BTCreateTestNO.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTCreateTestNO.ImageOptions.Image")));
            this.BTCreateTestNO.Location = new System.Drawing.Point(791, 28);
            this.BTCreateTestNO.Name = "BTCreateTestNO";
            this.BTCreateTestNO.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTCreateTestNO.Size = new System.Drawing.Size(86, 22);
            this.BTCreateTestNO.StyleController = this.layoutControl1;
            this.BTCreateTestNO.TabIndex = 14;
            this.BTCreateTestNO.Tag = "";
            this.BTCreateTestNO.Text = "生成实验号";
            this.BTCreateTestNO.Click += new System.EventHandler(this.BTCreateTestNO_Click);
            // 
            // TENOSerials
            // 
            this.TENOSerials.EditValue = "0";
            this.TENOSerials.Location = new System.Drawing.Point(719, 28);
            this.TENOSerials.Name = "TENOSerials";
            this.TENOSerials.Size = new System.Drawing.Size(68, 20);
            this.TENOSerials.StyleController = this.layoutControl1;
            this.TENOSerials.TabIndex = 13;
            // 
            // TENOTabs
            // 
            this.TENOTabs.Location = new System.Drawing.Point(534, 28);
            this.TENOTabs.Name = "TENOTabs";
            this.TENOTabs.Size = new System.Drawing.Size(112, 20);
            this.TENOTabs.StyleController = this.layoutControl1;
            this.TENOTabs.TabIndex = 12;
            // 
            // CECustomNO
            // 
            this.CECustomNO.Location = new System.Drawing.Point(108, 28);
            this.CECustomNO.Name = "CECustomNO";
            this.CECustomNO.Properties.Caption = "自定义实验号";
            this.CECustomNO.Size = new System.Drawing.Size(102, 20);
            this.CECustomNO.StyleController = this.layoutControl1;
            this.CECustomNO.TabIndex = 11;
            this.CECustomNO.CheckedChanged += new System.EventHandler(this.CECustomNO_CheckedChanged);
            // 
            // CEDefultNO
            // 
            this.CEDefultNO.Location = new System.Drawing.Point(2, 28);
            this.CEDefultNO.Name = "CEDefultNO";
            this.CEDefultNO.Properties.Caption = "默认实验号";
            this.CEDefultNO.Size = new System.Drawing.Size(102, 20);
            this.CEDefultNO.StyleController = this.layoutControl1;
            this.CEDefultNO.TabIndex = 10;
            this.CEDefultNO.CheckedChanged += new System.EventHandler(this.CEDefultNO_CheckedChanged);
            // 
            // BTSelects
            // 
            this.BTSelects.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSelects.ImageOptions.Image")));
            this.BTSelects.Location = new System.Drawing.Point(917, 2);
            this.BTSelects.Name = "BTSelects";
            this.BTSelects.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTSelects.Size = new System.Drawing.Size(56, 22);
            this.BTSelects.StyleController = this.layoutControl1;
            this.BTSelects.TabIndex = 9;
            this.BTSelects.Tag = "13030201";
            this.BTSelects.Text = "查询";
            this.BTSelects.Click += new System.EventHandler(this.BTSelects_Click);
            // 
            // DEEndTimes
            // 
            this.DEEndTimes.EditValue = null;
            this.DEEndTimes.Location = new System.Drawing.Point(707, 2);
            this.DEEndTimes.Name = "DEEndTimes";
            this.DEEndTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEEndTimes.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEEndTimes.Size = new System.Drawing.Size(206, 20);
            this.DEEndTimes.StyleController = this.layoutControl1;
            this.DEEndTimes.TabIndex = 8;
            // 
            // DEStartTimes
            // 
            this.DEStartTimes.EditValue = null;
            this.DEStartTimes.Location = new System.Drawing.Point(503, 2);
            this.DEStartTimes.Name = "DEStartTimes";
            this.DEStartTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEStartTimes.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEStartTimes.Size = new System.Drawing.Size(143, 20);
            this.DEStartTimes.StyleController = this.layoutControl1;
            this.DEStartTimes.TabIndex = 7;
            // 
            // GEgroupNOs
            // 
            this.GEgroupNOs.Location = new System.Drawing.Point(259, 2);
            this.GEgroupNOs.Name = "GEgroupNOs";
            this.GEgroupNOs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEgroupNOs.Properties.PopupView = this.gridLookUpEdit1View;
            this.GEgroupNOs.Size = new System.Drawing.Size(183, 20);
            this.GEgroupNOs.StyleController = this.layoutControl1;
            this.GEgroupNOs.TabIndex = 6;
            this.GEgroupNOs.EditValueChanged += new System.EventHandler(this.GEgroupNOs_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem7,
            this.layoutControlItem11,
            this.emptySpaceItem3,
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem10,
            this.layoutControlItem8,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem19,
            this.TEFrameSerialss,
            this.layoutControlItem13,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem9,
            this.layoutControlItem16,
            this.layoutControlItem20,
            this.layoutControlItem1,
            this.layoutControlItem17,
            this.layoutControlItem23,
            this.layoutControlItem18,
            this.layoutControlItem15,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(1554, 81);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.GEgroupNOs;
            this.layoutControlItem3.Location = new System.Drawing.Point(212, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(232, 26);
            this.layoutControlItem3.Text = "专业组:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(40, 14);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(975, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(579, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.CEDefultNO;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(106, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.BTCreateTestNO;
            this.layoutControlItem11.Location = new System.Drawing.Point(789, 26);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(1346, 26);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(208, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.TEFrameTops;
            this.layoutControlItem12.Location = new System.Drawing.Point(879, 26);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(183, 26);
            this.layoutControlItem12.Text = "试管架号:";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(52, 14);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.BTCreateFrameNO;
            this.layoutControlItem14.Location = new System.Drawing.Point(1244, 26);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(102, 26);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(102, 26);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(102, 26);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.DEStartTimes;
            this.layoutControlItem4.Location = new System.Drawing.Point(444, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(204, 26);
            this.layoutControlItem4.Text = "起始时间:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BTSelects;
            this.layoutControlItem6.Location = new System.Drawing.Point(915, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(60, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(60, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(60, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.TENOSerials;
            this.layoutControlItem10.Location = new System.Drawing.Point(648, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(141, 26);
            this.layoutControlItem10.Text = "实验起始号:";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(64, 14);
            this.layoutControlItem10.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.CECustomNO;
            this.layoutControlItem8.Location = new System.Drawing.Point(106, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(106, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.DEReceiveTimes;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(212, 29);
            this.layoutControlItem2.Text = "接收到时间:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 14);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1346, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(208, 29);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.CECheckNO;
            this.layoutControlItem19.Location = new System.Drawing.Point(212, 26);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(119, 26);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // TEFrameSerialss
            // 
            this.TEFrameSerialss.Control = this.TEFrameSerials;
            this.TEFrameSerialss.CustomizationFormText = "试管编号:";
            this.TEFrameSerialss.Location = new System.Drawing.Point(1062, 26);
            this.TEFrameSerialss.Name = "TEFrameSerialss";
            this.TEFrameSerialss.Size = new System.Drawing.Size(182, 26);
            this.TEFrameSerialss.Text = "试管编号:";
            this.TEFrameSerialss.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.CEFrameNO;
            this.layoutControlItem13.Location = new System.Drawing.Point(331, 26);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(132, 26);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.CESelectState;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(106, 26);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.CEScanState;
            this.layoutControlItem22.Location = new System.Drawing.Point(106, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(106, 26);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.TENOTabs;
            this.layoutControlItem9.CustomizationFormText = "实验号前缀:";
            this.layoutControlItem9.Location = new System.Drawing.Point(463, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(185, 26);
            this.layoutControlItem9.Text = "实验号前缀:";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(64, 14);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.BTPrints;
            this.layoutControlItem16.Location = new System.Drawing.Point(1167, 52);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(101, 28);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(101, 28);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(101, 29);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.CBPrintInfo;
            this.layoutControlItem20.Location = new System.Drawing.Point(879, 52);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(288, 29);
            this.layoutControlItem20.Text = "选择打印机:";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(64, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CECheckAll;
            this.layoutControlItem1.Location = new System.Drawing.Point(648, 52);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(106, 29);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.TEbarcode;
            this.layoutControlItem17.Location = new System.Drawing.Point(212, 52);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(251, 29);
            this.layoutControlItem17.Text = "条码号:";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(40, 14);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.BTdelete;
            this.layoutControlItem23.Location = new System.Drawing.Point(1268, 52);
            this.layoutControlItem23.MaxSize = new System.Drawing.Size(78, 29);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(78, 29);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(78, 29);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.TEhosBarcode;
            this.layoutControlItem18.Location = new System.Drawing.Point(463, 52);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(185, 29);
            this.layoutControlItem18.Text = "外部条码:";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(52, 14);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.BTReceives;
            this.layoutControlItem15.Location = new System.Drawing.Point(754, 52);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(125, 28);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(125, 28);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(125, 29);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.DEEndTimes;
            this.layoutControlItem5.Location = new System.Drawing.Point(648, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(267, 26);
            this.layoutControlItem5.Text = "结束时间:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(52, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // FrmReceiveSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 755);
            this.Controls.Add(this.splitContainerControl2);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmReceiveSample.IconOptions.Icon")));
            this.Name = "FrmReceiveSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标本接收";
            this.Load += new System.EventHandler(this.FrmReceiveSample_Load);
            this.Enter += new System.EventHandler(this.FrmReceiveSample_Enter);
            this.Leave += new System.EventHandler(this.FrmReceiveSample_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEHospitalNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEAgentNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEPatientType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GESampleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GESampleShape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupItem)).EndInit();
            this.groupItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCItemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CBPrintInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEScanState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CESelectState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEFrameNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFrameSerials.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECheckNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEhosBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEReceiveTimes.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEReceiveTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECheckAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFrameTops.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENOSerials.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TENOTabs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECustomNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEDefultNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEgroupNOs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEFrameSerialss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GridControl GCSampleInfo;
        private GridView GVSampleInfo;
#pragma warning disable CS0169 // 从不使用字段“FrmReceiveSample.Check”
        private DevExpress.XtraGrid.Columns.GridColumn Check;
#pragma warning restore CS0169 // 从不使用字段“FrmReceiveSample.Check”
        private DevExpress.XtraGrid.Columns.GridColumn sampleID;
#pragma warning disable CS0169 // 从不使用字段“FrmReceiveSample.TestID”
        private DevExpress.XtraGrid.Columns.GridColumn TestID;
#pragma warning restore CS0169 // 从不使用字段“FrmReceiveSample.TestID”
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn hosBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNames;
        private DevExpress.XtraGrid.Columns.GridColumn agentNames;
        private DevExpress.XtraGrid.Columns.GridColumn medicalNo;
        private DevExpress.XtraGrid.Columns.GridColumn sampleTime;
        private DevExpress.XtraGrid.Columns.GridColumn receiveTime;
        private DevExpress.XtraGrid.Columns.GridColumn patientTypeNames;
        private DevExpress.XtraGrid.Columns.GridColumn patientName;
        private DevExpress.XtraGrid.Columns.GridColumn patientSexNames;
        private DevExpress.XtraGrid.Columns.GridColumn ageYear;
        private DevExpress.XtraGrid.Columns.GridColumn ageMoth;
        private DevExpress.XtraGrid.Columns.GridColumn ageDay;
        private DevExpress.XtraGrid.Columns.GridColumn department;
        private DevExpress.XtraGrid.Columns.GridColumn bedNo;
        private DevExpress.XtraGrid.Columns.GridColumn patientPhone;
        private DevExpress.XtraGrid.Columns.GridColumn patientCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn patientAddress;
        private DevExpress.XtraGrid.Columns.GridColumn sendDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn doctorPhone;
        private DevExpress.XtraGrid.Columns.GridColumn pathologyNo;
        private DevExpress.XtraGrid.Columns.GridColumn cutPart;
        private DevExpress.XtraGrid.Columns.GridColumn menstrualTime;
        private DevExpress.XtraGrid.Columns.GridColumn sampleTypeNames;
        private DevExpress.XtraGrid.Columns.GridColumn sampleShapeNames;
        private DevExpress.XtraGrid.Columns.GridColumn clinicalDiagnosis;
        private DevExpress.XtraGrid.Columns.GridColumn perRemark;
        private DevExpress.XtraGrid.Columns.GridColumn groupCodes;
        private DevExpress.XtraGrid.Columns.GridColumn groupNames;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private RepositoryItemGridLookUpEdit GEHospitalNO;
        private GridView repositoryItemGridLookUpEdit1View;
        private RepositoryItemGridLookUpEdit GEAgentNO;
        private GridView gridView2;
        private RepositoryItemGridLookUpEdit GEPatientType;
        private GridView gridView3;
        private RepositoryItemGridLookUpEdit GESampleType;
        private GridView gridView4;
        private RepositoryItemGridLookUpEdit GESampleShape;
        private GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn groupNO;
        private DevExpress.XtraGrid.Columns.GridColumn ageNames;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraGrid.Columns.GridColumn testNo;
        private DevExpress.XtraGrid.Columns.GridColumn frameNo;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraEditors.GroupControl groupItem;
        private DevExpress.XtraGrid.Columns.GridColumn urgent;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit DEEndTimes;
        private DevExpress.XtraEditors.DateEdit DEStartTimes;
        private DevExpress.XtraEditors.GridLookUpEdit GEgroupNOs;
        private GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit TEhosBarcode;
        private DevExpress.XtraEditors.TextEdit TEbarcode;
        private DevExpress.XtraEditors.SimpleButton BTPrints;
        private DevExpress.XtraEditors.SimpleButton BTReceives;
        private DevExpress.XtraEditors.DateEdit DEReceiveTimes;
        private DevExpress.XtraEditors.CheckEdit CECheckAll;
        private DevExpress.XtraEditors.SimpleButton BTCreateFrameNO;
        private DevExpress.XtraEditors.TextEdit TEFrameTops;
        private DevExpress.XtraEditors.SimpleButton BTCreateTestNO;
        private DevExpress.XtraEditors.TextEdit TENOSerials;
        private DevExpress.XtraEditors.TextEdit TENOTabs;
        private DevExpress.XtraEditors.CheckEdit CECustomNO;
        private DevExpress.XtraEditors.CheckEdit CEDefultNO;
        private DevExpress.XtraEditors.SimpleButton BTSelects;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraEditors.CheckEdit CECheckNO;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraEditors.TextEdit TEFrameSerials;
        private DevExpress.XtraLayout.LayoutControlItem TEFrameSerialss;
        private DevExpress.XtraEditors.CheckEdit CEFrameNO;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.CheckEdit CEScanState;
        private DevExpress.XtraEditors.CheckEdit CESelectState;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private GridControl GCItemInfo;
        private DevExpress.XtraEditors.ComboBoxEdit CBPrintInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn disNames;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton BTdelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
    }
}