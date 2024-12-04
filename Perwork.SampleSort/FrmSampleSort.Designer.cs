using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Perwork.SampleSort
{
    partial class FrmSampleSort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSampleSort));
            this.GCSampleInfo = new DevExpress.XtraGrid.GridControl();
            this.GVSampleInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pathologyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.perStateNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEperStateNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.sortState = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.GCGroupInfo = new DevExpress.XtraGrid.GridControl();
            this.CVGroupInfo = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gbarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ggroupNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEGroupNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ggroupCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ggroupNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CBPrintInfo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CEScanState = new DevExpress.XtraEditors.CheckEdit();
            this.CESelectState = new DevExpress.XtraEditors.CheckEdit();
            this.TEbarcode = new DevExpress.XtraEditors.TextEdit();
            this.BTPrints = new DevExpress.XtraEditors.SimpleButton();
            this.BTSort = new DevExpress.XtraEditors.SimpleButton();
            this.CECheckAll = new DevExpress.XtraEditors.CheckEdit();
            this.BTSelects = new DevExpress.XtraEditors.SimpleButton();
            this.DEEndTimes = new DevExpress.XtraEditors.DateEdit();
            this.DEStartTimes = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEperStateNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEGroupNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBPrintInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEScanState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CESelectState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECheckAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.GESampleShape,
            this.RGEperStateNO});
            this.GCSampleInfo.Size = new System.Drawing.Size(1100, 682);
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
            this.groupNO,
            this.barcode,
            this.pathologyNo,
            this.perStateNO,
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
            this.urgent,
            this.sortState});
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.urgent, DevExpress.Data.ColumnSortOrder.Descending)});
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
            // groupNO
            // 
            this.groupNO.Caption = "专业组";
            this.groupNO.FieldName = "groupNO";
            this.groupNO.MinWidth = 23;
            this.groupNO.Name = "groupNO";
            this.groupNO.OptionsColumn.AllowFocus = false;
            this.groupNO.Width = 87;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.MinWidth = 23;
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.AllowEdit = false;
            this.barcode.OptionsColumn.ReadOnly = true;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 2;
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
            this.pathologyNo.VisibleIndex = 10;
            this.pathologyNo.Width = 87;
            // 
            // perStateNO
            // 
            this.perStateNO.Caption = "录入状态";
            this.perStateNO.ColumnEdit = this.RGEperStateNO;
            this.perStateNO.FieldName = "perStateNO";
            this.perStateNO.MinWidth = 23;
            this.perStateNO.Name = "perStateNO";
            this.perStateNO.OptionsColumn.AllowFocus = false;
            this.perStateNO.OptionsFilter.AllowFilter = false;
            this.perStateNO.Visible = true;
            this.perStateNO.VisibleIndex = 11;
            this.perStateNO.Width = 87;
            // 
            // RGEperStateNO
            // 
            this.RGEperStateNO.AutoHeight = false;
            this.RGEperStateNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEperStateNO.Name = "RGEperStateNO";
            this.RGEperStateNO.PopupView = this.gridView6;
            // 
            // gridView6
            // 
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // hospitalNames
            // 
            this.hospitalNames.Caption = "医院名称";
            this.hospitalNames.FieldName = "hospitalNames";
            this.hospitalNames.MinWidth = 23;
            this.hospitalNames.Name = "hospitalNames";
            this.hospitalNames.OptionsColumn.AllowFocus = false;
            this.hospitalNames.Visible = true;
            this.hospitalNames.VisibleIndex = 3;
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
            this.medicalNo.VisibleIndex = 4;
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
            this.sampleShapeNames.VisibleIndex = 13;
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
            this.patientName.VisibleIndex = 5;
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
            this.patientSexNames.VisibleIndex = 6;
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
            this.ageYear.VisibleIndex = 7;
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
            this.ageNames.VisibleIndex = 8;
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
            this.cutPart.VisibleIndex = 14;
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
            this.sampleTime.VisibleIndex = 12;
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
            this.menstrualTime.VisibleIndex = 15;
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
            this.clinicalDiagnosis.VisibleIndex = 16;
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
            this.patientTypeNames.VisibleIndex = 17;
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
            this.department.VisibleIndex = 20;
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
            this.bedNo.VisibleIndex = 21;
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
            this.patientPhone.VisibleIndex = 22;
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
            this.patientCardNo.VisibleIndex = 23;
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
            this.patientAddress.VisibleIndex = 24;
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
            this.sendDoctor.VisibleIndex = 25;
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
            this.doctorPhone.VisibleIndex = 26;
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
            this.sampleTypeNames.VisibleIndex = 9;
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
            this.perRemark.VisibleIndex = 27;
            this.perRemark.Width = 87;
            // 
            // groupCodes
            // 
            this.groupCodes.Caption = "项目编号";
            this.groupCodes.FieldName = "applyItemCodes";
            this.groupCodes.MinWidth = 23;
            this.groupCodes.Name = "groupCodes";
            this.groupCodes.OptionsColumn.AllowFocus = false;
            this.groupCodes.Visible = true;
            this.groupCodes.VisibleIndex = 18;
            this.groupCodes.Width = 87;
            // 
            // groupNames
            // 
            this.groupNames.Caption = "项目名称";
            this.groupNames.FieldName = "applyItemNames";
            this.groupNames.MinWidth = 23;
            this.groupNames.Name = "groupNames";
            this.groupNames.OptionsColumn.AllowFocus = false;
            this.groupNames.Visible = true;
            this.groupNames.VisibleIndex = 19;
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
            this.state.VisibleIndex = 28;
            this.state.Width = 87;
            // 
            // urgent
            // 
            this.urgent.Caption = "急";
            this.urgent.FieldName = "urgent";
            this.urgent.Name = "urgent";
            this.urgent.OptionsColumn.AllowFocus = false;
            this.urgent.Visible = true;
            this.urgent.VisibleIndex = 29;
            // 
            // sortState
            // 
            this.sortState.Caption = "分拣";
            this.sortState.FieldName = "sortState";
            this.sortState.Name = "sortState";
            this.sortState.OptionsColumn.AllowFocus = false;
            this.sortState.Visible = true;
            this.sortState.VisibleIndex = 30;
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
            this.splitContainerControl1.Size = new System.Drawing.Size(1554, 707);
            this.splitContainerControl1.SplitterPosition = 1104;
            this.splitContainerControl1.TabIndex = 14;
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.GCSampleInfo);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(1104, 707);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "信息列表";
            // 
            // groupItem
            // 
            this.groupItem.Controls.Add(this.GCGroupInfo);
            this.groupItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupItem.Location = new System.Drawing.Point(0, 0);
            this.groupItem.Name = "groupItem";
            this.groupItem.Size = new System.Drawing.Size(440, 707);
            this.groupItem.TabIndex = 0;
            this.groupItem.Text = "项目信息";
            // 
            // GCGroupInfo
            // 
            this.GCGroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCGroupInfo.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Default;
            this.GCGroupInfo.EmbeddedNavigator.ShowToolTips = false;
            this.GCGroupInfo.EmbeddedNavigator.TextStringFormat = "记录 {0} of {1}";
            this.GCGroupInfo.Location = new System.Drawing.Point(2, 23);
            this.GCGroupInfo.MainView = this.CVGroupInfo;
            this.GCGroupInfo.Name = "GCGroupInfo";
            this.GCGroupInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEGroupNO});
            this.GCGroupInfo.Size = new System.Drawing.Size(436, 682);
            this.GCGroupInfo.TabIndex = 29;
            this.GCGroupInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CVGroupInfo});
            // 
            // CVGroupInfo
            // 
            this.CVGroupInfo.CardCaptionFormat = "项目信息 {0}";
            this.CVGroupInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gid,
            this.gbarcode,
            this.ggroupNO,
            this.ggroupCodes,
            this.ggroupNames});
            this.CVGroupInfo.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.CVGroupInfo.GridControl = this.GCGroupInfo;
            this.CVGroupInfo.Name = "CVGroupInfo";
            this.CVGroupInfo.OptionsBehavior.AutoHorzWidth = true;
            this.CVGroupInfo.OptionsBehavior.ReadOnly = true;
            this.CVGroupInfo.OptionsView.ShowQuickCustomizeButton = false;
            // 
            // gid
            // 
            this.gid.AppearanceCell.Options.UseTextOptions = true;
            this.gid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gid.Caption = "编      号";
            this.gid.FieldName = "id";
            this.gid.Name = "gid";
            this.gid.Visible = true;
            this.gid.VisibleIndex = 0;
            // 
            // gbarcode
            // 
            this.gbarcode.Caption = "条  码 号";
            this.gbarcode.FieldName = "barcode";
            this.gbarcode.Name = "gbarcode";
            this.gbarcode.OptionsColumn.AllowFocus = false;
            this.gbarcode.Visible = true;
            this.gbarcode.VisibleIndex = 1;
            // 
            // ggroupNO
            // 
            this.ggroupNO.Caption = "专  业 组";
            this.ggroupNO.ColumnEdit = this.RGEGroupNO;
            this.ggroupNO.FieldName = "groupNO";
            this.ggroupNO.Name = "ggroupNO";
            this.ggroupNO.Visible = true;
            this.ggroupNO.VisibleIndex = 2;
            // 
            // RGEGroupNO
            // 
            this.RGEGroupNO.AutoHeight = false;
            this.RGEGroupNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEGroupNO.Name = "RGEGroupNO";
            this.RGEGroupNO.PopupView = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ggroupCodes
            // 
            this.ggroupCodes.Caption = "组合编号";
            this.ggroupCodes.FieldName = "groupCodes";
            this.ggroupCodes.Name = "ggroupCodes";
            this.ggroupCodes.Visible = true;
            this.ggroupCodes.VisibleIndex = 3;
            // 
            // ggroupNames
            // 
            this.ggroupNames.Caption = "组合名称";
            this.ggroupNames.FieldName = "groupNames";
            this.ggroupNames.Name = "ggroupNames";
            this.ggroupNames.Visible = true;
            this.ggroupNames.VisibleIndex = 4;
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
            this.splitContainerControl2.SplitterPosition = 38;
            this.splitContainerControl2.TabIndex = 19;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CBPrintInfo);
            this.layoutControl1.Controls.Add(this.CEScanState);
            this.layoutControl1.Controls.Add(this.CESelectState);
            this.layoutControl1.Controls.Add(this.TEbarcode);
            this.layoutControl1.Controls.Add(this.BTPrints);
            this.layoutControl1.Controls.Add(this.BTSort);
            this.layoutControl1.Controls.Add(this.CECheckAll);
            this.layoutControl1.Controls.Add(this.BTSelects);
            this.layoutControl1.Controls.Add(this.DEEndTimes);
            this.layoutControl1.Controls.Add(this.DEStartTimes);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1554, 38);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CBPrintInfo
            // 
            this.CBPrintInfo.Location = new System.Drawing.Point(1239, 2);
            this.CBPrintInfo.Name = "CBPrintInfo";
            this.CBPrintInfo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CBPrintInfo.Size = new System.Drawing.Size(198, 20);
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
            // TEbarcode
            // 
            this.TEbarcode.Location = new System.Drawing.Point(727, 2);
            this.TEbarcode.Name = "TEbarcode";
            this.TEbarcode.Size = new System.Drawing.Size(205, 20);
            this.TEbarcode.StyleController = this.layoutControl1;
            this.TEbarcode.TabIndex = 27;
            this.TEbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TEbarcode_KeyDown);
            // 
            // BTPrints
            // 
            this.BTPrints.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTPrints.ImageOptions.Image")));
            this.BTPrints.Location = new System.Drawing.Point(1441, 2);
            this.BTPrints.Name = "BTPrints";
            this.BTPrints.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTPrints.Size = new System.Drawing.Size(97, 24);
            this.BTPrints.StyleController = this.layoutControl1;
            this.BTPrints.TabIndex = 26;
            this.BTPrints.Tag = "13030203";
            this.BTPrints.Text = "打印条码(F2)";
            this.BTPrints.Click += new System.EventHandler(this.BTPrints_Click);
            // 
            // BTSort
            // 
            this.BTSort.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSort.ImageOptions.Image")));
            this.BTSort.Location = new System.Drawing.Point(1047, 2);
            this.BTSort.Name = "BTSort";
            this.BTSort.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.BTSort.Size = new System.Drawing.Size(121, 24);
            this.BTSort.StyleController = this.layoutControl1;
            this.BTSort.TabIndex = 25;
            this.BTSort.Tag = "13030202";
            this.BTSort.Text = "确认分拣(F1)";
            this.BTSort.Click += new System.EventHandler(this.BTSort_Click);
            // 
            // CECheckAll
            // 
            this.CECheckAll.Location = new System.Drawing.Point(996, 2);
            this.CECheckAll.Name = "CECheckAll";
            this.CECheckAll.Properties.Caption = "全选";
            this.CECheckAll.Size = new System.Drawing.Size(47, 20);
            this.CECheckAll.StyleController = this.layoutControl1;
            this.CECheckAll.TabIndex = 18;
            this.CECheckAll.CheckedChanged += new System.EventHandler(this.CECheckAll_CheckedChanged);
            // 
            // BTSelects
            // 
            this.BTSelects.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSelects.ImageOptions.Image")));
            this.BTSelects.Location = new System.Drawing.Point(936, 2);
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
            this.DEEndTimes.Location = new System.Drawing.Point(512, 2);
            this.DEEndTimes.Name = "DEEndTimes";
            this.DEEndTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEEndTimes.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEEndTimes.Size = new System.Drawing.Size(166, 20);
            this.DEEndTimes.StyleController = this.layoutControl1;
            this.DEEndTimes.TabIndex = 8;
            // 
            // DEStartTimes
            // 
            this.DEStartTimes.EditValue = null;
            this.DEStartTimes.Location = new System.Drawing.Point(271, 2);
            this.DEStartTimes.Name = "DEStartTimes";
            this.DEStartTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEStartTimes.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEStartTimes.Size = new System.Drawing.Size(180, 20);
            this.DEStartTimes.StyleController = this.layoutControl1;
            this.DEStartTimes.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem5,
            this.layoutControlItem17,
            this.layoutControlItem16,
            this.layoutControlItem15,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(1554, 38);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1540, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(14, 28);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.DEStartTimes;
            this.layoutControlItem4.Location = new System.Drawing.Point(212, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(241, 28);
            this.layoutControlItem4.Text = "起始时间:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.BTSelects;
            this.layoutControlItem6.Location = new System.Drawing.Point(934, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(60, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(60, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(60, 28);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1554, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.CESelectState;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(106, 28);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.CEScanState;
            this.layoutControlItem22.Location = new System.Drawing.Point(106, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(106, 28);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.DEEndTimes;
            this.layoutControlItem5.Location = new System.Drawing.Point(453, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(227, 28);
            this.layoutControlItem5.Text = "结束时间:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(52, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.TEbarcode;
            this.layoutControlItem17.Location = new System.Drawing.Point(680, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(254, 28);
            this.layoutControlItem17.Text = "条码号:";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(40, 14);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.BTPrints;
            this.layoutControlItem16.Location = new System.Drawing.Point(1439, 0);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(101, 28);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(101, 28);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(101, 28);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.BTSort;
            this.layoutControlItem15.Location = new System.Drawing.Point(1045, 0);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(125, 28);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(125, 28);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(125, 28);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CECheckAll;
            this.layoutControlItem1.Location = new System.Drawing.Point(994, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(51, 28);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CBPrintInfo;
            this.layoutControlItem2.Location = new System.Drawing.Point(1170, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(269, 28);
            this.layoutControlItem2.Text = "选择打印机:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 14);
            // 
            // FrmSampleSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 755);
            this.Controls.Add(this.splitContainerControl2);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmSampleSort.IconOptions.Icon")));
            this.Name = "FrmSampleSort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标本分拣";
            this.Load += new System.EventHandler(this.FrmReceiveSample_Load);
            this.Enter += new System.EventHandler(this.FrmReceiveSample_Enter);
            this.Leave += new System.EventHandler(this.FrmReceiveSample_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEperStateNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.GCGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CVGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEGroupNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CBPrintInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEScanState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CESelectState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CECheckAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEndTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEStartTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn perStateNO;
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraEditors.GroupControl groupItem;
        private DevExpress.XtraGrid.Columns.GridColumn urgent;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit DEEndTimes;
        private DevExpress.XtraEditors.DateEdit DEStartTimes;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit TEbarcode;
        private DevExpress.XtraEditors.SimpleButton BTPrints;
        private DevExpress.XtraEditors.SimpleButton BTSort;
        private DevExpress.XtraEditors.CheckEdit CECheckAll;
        private DevExpress.XtraEditors.SimpleButton BTSelects;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraEditors.CheckEdit CEScanState;
        private DevExpress.XtraEditors.CheckEdit CESelectState;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private GridControl GCGroupInfo;
        private DevExpress.XtraGrid.Views.Card.CardView CVGroupInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gid;
        private DevExpress.XtraGrid.Columns.GridColumn gbarcode;
        private DevExpress.XtraEditors.ComboBoxEdit CBPrintInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn ggroupNO;
        private RepositoryItemGridLookUpEdit RGEGroupNO;
        private GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ggroupCodes;
        private DevExpress.XtraGrid.Columns.GridColumn ggroupNames;
        private RepositoryItemGridLookUpEdit RGEperStateNO;
        private GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn sortState;
    }
}