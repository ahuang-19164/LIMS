using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace Common.SampleInfoEdit
{
    partial class FrmSampleInfoCheckEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSampleInfoCheckEdit));
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GCapplyInfo = new DevExpress.XtraGrid.GridControl();
            this.GVapplyInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AshortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AcustomCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.GCcheckInfo = new DevExpress.XtraGrid.GridControl();
            this.GVcheckInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEnumber = new DevExpress.XtraEditors.TextEdit();
            this.TEpatientAddress = new DevExpress.XtraEditors.TextEdit();
            this.TEpassportNo = new DevExpress.XtraEditors.TextEdit();
            this.CEurgent = new DevExpress.XtraEditors.CheckEdit();
            this.TEsampleLocation = new DevExpress.XtraEditors.TextEdit();
            this.TEdepartment = new DevExpress.XtraEditors.TextEdit();
            this.TEhospitalBarcode = new DevExpress.XtraEditors.TextEdit();
            this.TEsendDoctor = new DevExpress.XtraEditors.TextEdit();
            this.TEdoctorPhone = new DevExpress.XtraEditors.TextEdit();
            this.TEpatientName = new DevExpress.XtraEditors.TextEdit();
            this.TEageYear = new DevExpress.XtraEditors.TextEdit();
            this.TEageMoth = new DevExpress.XtraEditors.TextEdit();
            this.TEageDay = new DevExpress.XtraEditors.TextEdit();
            this.TEbarcode = new DevExpress.XtraEditors.TextEdit();
            this.TEmedicalNo = new DevExpress.XtraEditors.TextEdit();
            this.TEbedNo = new DevExpress.XtraEditors.TextEdit();
            this.TEpatientPhone = new DevExpress.XtraEditors.TextEdit();
            this.TEpatientCardNo = new DevExpress.XtraEditors.TextEdit();
            this.DEsampleTime = new DevExpress.XtraEditors.DateEdit();
            this.DEreceiveTime = new DevExpress.XtraEditors.DateEdit();
            this.TEpathologyNo = new DevExpress.XtraEditors.TextEdit();
            this.TEcutPart = new DevExpress.XtraEditors.TextEdit();
            this.DEmenstrualTime = new DevExpress.XtraEditors.DateEdit();
            this.TEclinicalDiagnosis = new DevExpress.XtraEditors.MemoEdit();
            this.TEperRemark = new DevExpress.XtraEditors.MemoEdit();
            this.GEpatientTypeNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEsampleTypeNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEsampleShapeNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEpatientSexNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEagentNo = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEhospitalNo = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LayGroupInfo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layGroupOther = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layGroupInfos = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem2 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layGroupItem = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.GCSampleInfo = new DevExpress.XtraGrid.GridControl();
            this.GVSampleInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.DocksampleList = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.DockCenter = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.BTClear = new System.Windows.Forms.Button();
            this.BTSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCapplyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVapplyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCcheckInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVcheckInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEnumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpassportNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEurgent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsampleLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEhospitalBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsendDoctor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdoctorPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEageYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEageMoth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEageDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEmedicalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbedNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEsampleTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEsampleTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEreceiveTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEreceiveTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpathologyNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEcutPart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEmenstrualTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEmenstrualTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEclinicalDiagnosis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEperRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEpatientTypeNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEsampleTypeNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEsampleShapeNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEpatientSexNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEagentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEhospitalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.DocksampleList.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.DockCenter.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.splitContainerControl3);
            this.layoutControl2.Controls.Add(this.TEnumber);
            this.layoutControl2.Controls.Add(this.TEpatientAddress);
            this.layoutControl2.Controls.Add(this.TEpassportNo);
            this.layoutControl2.Controls.Add(this.CEurgent);
            this.layoutControl2.Controls.Add(this.TEsampleLocation);
            this.layoutControl2.Controls.Add(this.TEdepartment);
            this.layoutControl2.Controls.Add(this.TEhospitalBarcode);
            this.layoutControl2.Controls.Add(this.TEsendDoctor);
            this.layoutControl2.Controls.Add(this.TEdoctorPhone);
            this.layoutControl2.Controls.Add(this.TEpatientName);
            this.layoutControl2.Controls.Add(this.TEageYear);
            this.layoutControl2.Controls.Add(this.TEageMoth);
            this.layoutControl2.Controls.Add(this.TEageDay);
            this.layoutControl2.Controls.Add(this.TEbarcode);
            this.layoutControl2.Controls.Add(this.TEmedicalNo);
            this.layoutControl2.Controls.Add(this.TEbedNo);
            this.layoutControl2.Controls.Add(this.TEpatientPhone);
            this.layoutControl2.Controls.Add(this.TEpatientCardNo);
            this.layoutControl2.Controls.Add(this.DEsampleTime);
            this.layoutControl2.Controls.Add(this.DEreceiveTime);
            this.layoutControl2.Controls.Add(this.TEpathologyNo);
            this.layoutControl2.Controls.Add(this.TEcutPart);
            this.layoutControl2.Controls.Add(this.DEmenstrualTime);
            this.layoutControl2.Controls.Add(this.TEclinicalDiagnosis);
            this.layoutControl2.Controls.Add(this.TEperRemark);
            this.layoutControl2.Controls.Add(this.GEpatientTypeNO);
            this.layoutControl2.Controls.Add(this.GEsampleTypeNO);
            this.layoutControl2.Controls.Add(this.GEsampleShapeNO);
            this.layoutControl2.Controls.Add(this.GEpatientSexNO);
            this.layoutControl2.Controls.Add(this.GEagentNo);
            this.layoutControl2.Controls.Add(this.GEhospitalNo);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.MinimumSize = new System.Drawing.Size(583, 467);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(121, 106, 1185, 718);
            this.layoutControl2.Root = this.LayGroupInfo;
            this.layoutControl2.Size = new System.Drawing.Size(861, 700);
            this.layoutControl2.TabIndex = 4;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl3.Location = new System.Drawing.Point(6, 404);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(849, 290);
            this.splitContainerControl3.SplitterPosition = 428;
            this.splitContainerControl3.TabIndex = 31;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GCapplyInfo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(428, 290);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "系统项目";
            // 
            // GCapplyInfo
            // 
            this.GCapplyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCapplyInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCapplyInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCapplyInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCapplyInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCapplyInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCapplyInfo.Location = new System.Drawing.Point(2, 23);
            this.GCapplyInfo.MainView = this.GVapplyInfo;
            this.GCapplyInfo.Name = "GCapplyInfo";
            this.GCapplyInfo.Size = new System.Drawing.Size(424, 265);
            this.GCapplyInfo.TabIndex = 1;
            this.GCapplyInfo.UseDisabledStatePainter = false;
            this.GCapplyInfo.UseEmbeddedNavigator = true;
            this.GCapplyInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVapplyInfo});
            // 
            // GVapplyInfo
            // 
            this.GVapplyInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.AshortNames,
            this.AcustomCode});
            this.GVapplyInfo.DetailHeight = 408;
            this.GVapplyInfo.GridControl = this.GCapplyInfo;
            this.GVapplyInfo.Name = "GVapplyInfo";
            this.GVapplyInfo.OptionsFind.AlwaysVisible = true;
            this.GVapplyInfo.OptionsFind.FindDelay = 600;
            this.GVapplyInfo.OptionsFind.HighlightFindResults = false;
            this.GVapplyInfo.OptionsFind.ShowCloseButton = false;
            this.GVapplyInfo.OptionsView.ShowGroupPanel = false;
            this.GVapplyInfo.DoubleClick += new System.EventHandler(this.GVapplyInfo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "编号";
            this.gridColumn1.FieldName = "no";
            this.gridColumn1.MaxWidth = 58;
            this.gridColumn1.MinWidth = 58;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 58;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.FieldName = "names";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 87;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "名称别名";
            this.gridColumn3.FieldName = "disNames";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 87;
            // 
            // AshortNames
            // 
            this.AshortNames.Caption = "拼音简拼";
            this.AshortNames.FieldName = "shortNames";
            this.AshortNames.MinWidth = 23;
            this.AshortNames.Name = "AshortNames";
            this.AshortNames.OptionsColumn.AllowFocus = false;
            this.AshortNames.Visible = true;
            this.AshortNames.VisibleIndex = 3;
            this.AshortNames.Width = 87;
            // 
            // AcustomCode
            // 
            this.AcustomCode.Caption = "自定义码";
            this.AcustomCode.FieldName = "customCode";
            this.AcustomCode.MinWidth = 23;
            this.AcustomCode.Name = "AcustomCode";
            this.AcustomCode.OptionsColumn.AllowFocus = false;
            this.AcustomCode.Visible = true;
            this.AcustomCode.VisibleIndex = 4;
            this.AcustomCode.Width = 87;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.GCcheckInfo);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(411, 290);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "已选项目";
            // 
            // GCcheckInfo
            // 
            this.GCcheckInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCcheckInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCcheckInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCcheckInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCcheckInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCcheckInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCcheckInfo.Location = new System.Drawing.Point(2, 23);
            this.GCcheckInfo.MainView = this.GVcheckInfo;
            this.GCcheckInfo.Name = "GCcheckInfo";
            this.GCcheckInfo.Size = new System.Drawing.Size(407, 265);
            this.GCcheckInfo.TabIndex = 2;
            this.GCcheckInfo.UseDisabledStatePainter = false;
            this.GCcheckInfo.UseEmbeddedNavigator = true;
            this.GCcheckInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVcheckInfo});
            // 
            // GVcheckInfo
            // 
            this.GVcheckInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.GVcheckInfo.DetailHeight = 408;
            this.GVcheckInfo.GridControl = this.GCcheckInfo;
            this.GVcheckInfo.Name = "GVcheckInfo";
            this.GVcheckInfo.OptionsFind.FindDelay = 600;
            this.GVcheckInfo.OptionsFind.HighlightFindResults = false;
            this.GVcheckInfo.OptionsFind.ShowCloseButton = false;
            this.GVcheckInfo.OptionsView.ShowGroupPanel = false;
            this.GVcheckInfo.DoubleClick += new System.EventHandler(this.GVcheckInfo_DoubleClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "编号";
            this.gridColumn4.FieldName = "no";
            this.gridColumn4.MaxWidth = 58;
            this.gridColumn4.MinWidth = 58;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 58;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "名称";
            this.gridColumn5.FieldName = "names";
            this.gridColumn5.MinWidth = 23;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 87;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "名称别名";
            this.gridColumn6.FieldName = "disNames";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 87;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "拼音简拼";
            this.gridColumn7.FieldName = "shortNames";
            this.gridColumn7.MinWidth = 23;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 87;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "自定义码";
            this.gridColumn8.FieldName = "customCode";
            this.gridColumn8.MinWidth = 23;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 87;
            // 
            // TEnumber
            // 
            this.TEnumber.Location = new System.Drawing.Point(163, 219);
            this.TEnumber.Name = "TEnumber";
            this.TEnumber.Size = new System.Drawing.Size(116, 20);
            this.TEnumber.StyleController = this.layoutControl2;
            this.TEnumber.TabIndex = 30;
            this.TEnumber.Tag = "number";
            // 
            // TEpatientAddress
            // 
            this.TEpatientAddress.Location = new System.Drawing.Point(338, 219);
            this.TEpatientAddress.Name = "TEpatientAddress";
            this.TEpatientAddress.Size = new System.Drawing.Size(212, 20);
            this.TEpatientAddress.StyleController = this.layoutControl2;
            this.TEpatientAddress.TabIndex = 29;
            this.TEpatientAddress.Tag = "patientAddress";
            // 
            // TEpassportNo
            // 
            this.TEpassportNo.Location = new System.Drawing.Point(61, 99);
            this.TEpassportNo.Name = "TEpassportNo";
            this.TEpassportNo.Size = new System.Drawing.Size(217, 20);
            this.TEpassportNo.StyleController = this.layoutControl2;
            this.TEpassportNo.TabIndex = 28;
            this.TEpassportNo.Tag = "passportNo";
            // 
            // CEurgent
            // 
            this.CEurgent.Location = new System.Drawing.Point(61, 219);
            this.CEurgent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CEurgent.Name = "CEurgent";
            this.CEurgent.Properties.Caption = "加急";
            this.CEurgent.Size = new System.Drawing.Size(65, 20);
            this.CEurgent.StyleController = this.layoutControl2;
            this.CEurgent.TabIndex = 27;
            this.CEurgent.Tag = "urgent";
            // 
            // TEsampleLocation
            // 
            this.TEsampleLocation.Location = new System.Drawing.Point(337, 99);
            this.TEsampleLocation.Name = "TEsampleLocation";
            this.TEsampleLocation.Size = new System.Drawing.Size(213, 20);
            this.TEsampleLocation.StyleController = this.layoutControl2;
            this.TEsampleLocation.TabIndex = 26;
            this.TEsampleLocation.Tag = "sampleLocation";
            // 
            // TEdepartment
            // 
            this.TEdepartment.Location = new System.Drawing.Point(61, 123);
            this.TEdepartment.Name = "TEdepartment";
            this.TEdepartment.Size = new System.Drawing.Size(217, 20);
            this.TEdepartment.StyleController = this.layoutControl2;
            this.TEdepartment.TabIndex = 5;
            this.TEdepartment.Tag = "department";
            // 
            // TEhospitalBarcode
            // 
            this.TEhospitalBarcode.Location = new System.Drawing.Point(337, 51);
            this.TEhospitalBarcode.Name = "TEhospitalBarcode";
            this.TEhospitalBarcode.Size = new System.Drawing.Size(213, 20);
            this.TEhospitalBarcode.StyleController = this.layoutControl2;
            this.TEhospitalBarcode.TabIndex = 3;
            this.TEhospitalBarcode.Tag = "hospitalBarcode";
            // 
            // TEsendDoctor
            // 
            this.TEsendDoctor.Location = new System.Drawing.Point(61, 195);
            this.TEsendDoctor.Name = "TEsendDoctor";
            this.TEsendDoctor.Size = new System.Drawing.Size(217, 20);
            this.TEsendDoctor.StyleController = this.layoutControl2;
            this.TEsendDoctor.TabIndex = 6;
            this.TEsendDoctor.Tag = "sendDoctor";
            // 
            // TEdoctorPhone
            // 
            this.TEdoctorPhone.Location = new System.Drawing.Point(609, 123);
            this.TEdoctorPhone.Name = "TEdoctorPhone";
            this.TEdoctorPhone.Size = new System.Drawing.Size(246, 20);
            this.TEdoctorPhone.StyleController = this.layoutControl2;
            this.TEdoctorPhone.TabIndex = 7;
            this.TEdoctorPhone.Tag = "doctorPhone";
            // 
            // TEpatientName
            // 
            this.TEpatientName.Location = new System.Drawing.Point(61, 75);
            this.TEpatientName.Name = "TEpatientName";
            this.TEpatientName.Size = new System.Drawing.Size(217, 20);
            this.TEpatientName.StyleController = this.layoutControl2;
            this.TEpatientName.TabIndex = 11;
            this.TEpatientName.Tag = "patientName";
            // 
            // TEageYear
            // 
            this.TEageYear.Location = new System.Drawing.Point(555, 75);
            this.TEageYear.Name = "TEageYear";
            this.TEageYear.Size = new System.Drawing.Size(83, 20);
            this.TEageYear.StyleController = this.layoutControl2;
            this.TEageYear.TabIndex = 13;
            this.TEageYear.Tag = "ageYear";
            // 
            // TEageMoth
            // 
            this.TEageMoth.Location = new System.Drawing.Point(659, 75);
            this.TEageMoth.Name = "TEageMoth";
            this.TEageMoth.Size = new System.Drawing.Size(77, 20);
            this.TEageMoth.StyleController = this.layoutControl2;
            this.TEageMoth.TabIndex = 14;
            this.TEageMoth.Tag = "ageMoth";
            // 
            // TEageDay
            // 
            this.TEageDay.Location = new System.Drawing.Point(757, 75);
            this.TEageDay.Name = "TEageDay";
            this.TEageDay.Size = new System.Drawing.Size(76, 20);
            this.TEageDay.StyleController = this.layoutControl2;
            this.TEageDay.TabIndex = 15;
            this.TEageDay.Tag = "ageDay";
            // 
            // TEbarcode
            // 
            this.TEbarcode.EditValue = "";
            this.TEbarcode.Location = new System.Drawing.Point(61, 27);
            this.TEbarcode.Name = "TEbarcode";
            this.TEbarcode.Size = new System.Drawing.Size(217, 20);
            this.TEbarcode.StyleController = this.layoutControl2;
            this.TEbarcode.TabIndex = 2;
            this.TEbarcode.Tag = "barcode";
            // 
            // TEmedicalNo
            // 
            this.TEmedicalNo.Location = new System.Drawing.Point(337, 147);
            this.TEmedicalNo.Name = "TEmedicalNo";
            this.TEmedicalNo.Size = new System.Drawing.Size(213, 20);
            this.TEmedicalNo.StyleController = this.layoutControl2;
            this.TEmedicalNo.TabIndex = 8;
            this.TEmedicalNo.Tag = "medicalNo";
            // 
            // TEbedNo
            // 
            this.TEbedNo.Location = new System.Drawing.Point(337, 123);
            this.TEbedNo.Name = "TEbedNo";
            this.TEbedNo.Size = new System.Drawing.Size(213, 20);
            this.TEbedNo.StyleController = this.layoutControl2;
            this.TEbedNo.TabIndex = 9;
            this.TEbedNo.Tag = "bedNo";
            // 
            // TEpatientPhone
            // 
            this.TEpatientPhone.Location = new System.Drawing.Point(609, 99);
            this.TEpatientPhone.Name = "TEpatientPhone";
            this.TEpatientPhone.Size = new System.Drawing.Size(246, 20);
            this.TEpatientPhone.StyleController = this.layoutControl2;
            this.TEpatientPhone.TabIndex = 10;
            this.TEpatientPhone.Tag = "patientPhone";
            // 
            // TEpatientCardNo
            // 
            this.TEpatientCardNo.Location = new System.Drawing.Point(609, 51);
            this.TEpatientCardNo.Name = "TEpatientCardNo";
            this.TEpatientCardNo.Size = new System.Drawing.Size(246, 20);
            this.TEpatientCardNo.StyleController = this.layoutControl2;
            this.TEpatientCardNo.TabIndex = 18;
            this.TEpatientCardNo.Tag = "patientCardNo";
            // 
            // DEsampleTime
            // 
            this.DEsampleTime.EditValue = null;
            this.DEsampleTime.Location = new System.Drawing.Point(61, 171);
            this.DEsampleTime.Name = "DEsampleTime";
            this.DEsampleTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEsampleTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEsampleTime.Properties.DisplayFormat.FormatString = "g";
            this.DEsampleTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEsampleTime.Properties.EditFormat.FormatString = "g";
            this.DEsampleTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEsampleTime.Properties.Mask.EditMask = "g";
            this.DEsampleTime.Size = new System.Drawing.Size(217, 20);
            this.DEsampleTime.StyleController = this.layoutControl2;
            this.DEsampleTime.TabIndex = 19;
            this.DEsampleTime.Tag = "sampleTime";
            // 
            // DEreceiveTime
            // 
            this.DEreceiveTime.EditValue = null;
            this.DEreceiveTime.Location = new System.Drawing.Point(337, 171);
            this.DEreceiveTime.Name = "DEreceiveTime";
            this.DEreceiveTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEreceiveTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEreceiveTime.Properties.DisplayFormat.FormatString = "g";
            this.DEreceiveTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEreceiveTime.Properties.EditFormat.FormatString = "g";
            this.DEreceiveTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEreceiveTime.Properties.Mask.EditMask = "g";
            this.DEreceiveTime.Size = new System.Drawing.Size(213, 20);
            this.DEreceiveTime.StyleController = this.layoutControl2;
            this.DEreceiveTime.TabIndex = 20;
            this.DEreceiveTime.Tag = "receiveTime";
            // 
            // TEpathologyNo
            // 
            this.TEpathologyNo.Location = new System.Drawing.Point(609, 171);
            this.TEpathologyNo.Name = "TEpathologyNo";
            this.TEpathologyNo.Size = new System.Drawing.Size(246, 20);
            this.TEpathologyNo.StyleController = this.layoutControl2;
            this.TEpathologyNo.TabIndex = 21;
            this.TEpathologyNo.Tag = "pathologyNo";
            // 
            // TEcutPart
            // 
            this.TEcutPart.Location = new System.Drawing.Point(337, 195);
            this.TEcutPart.Name = "TEcutPart";
            this.TEcutPart.Size = new System.Drawing.Size(213, 20);
            this.TEcutPart.StyleController = this.layoutControl2;
            this.TEcutPart.TabIndex = 22;
            this.TEcutPart.Tag = "cutPart";
            // 
            // DEmenstrualTime
            // 
            this.DEmenstrualTime.EditValue = null;
            this.DEmenstrualTime.Location = new System.Drawing.Point(609, 195);
            this.DEmenstrualTime.Name = "DEmenstrualTime";
            this.DEmenstrualTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEmenstrualTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEmenstrualTime.Size = new System.Drawing.Size(246, 20);
            this.DEmenstrualTime.StyleController = this.layoutControl2;
            this.DEmenstrualTime.TabIndex = 23;
            this.DEmenstrualTime.Tag = "menstrualTime";
            // 
            // TEclinicalDiagnosis
            // 
            this.TEclinicalDiagnosis.Location = new System.Drawing.Point(61, 243);
            this.TEclinicalDiagnosis.Name = "TEclinicalDiagnosis";
            this.TEclinicalDiagnosis.Size = new System.Drawing.Size(353, 100);
            this.TEclinicalDiagnosis.StyleController = this.layoutControl2;
            this.TEclinicalDiagnosis.TabIndex = 24;
            this.TEclinicalDiagnosis.Tag = "clinicalDiagnosis";
            // 
            // TEperRemark
            // 
            this.TEperRemark.Location = new System.Drawing.Point(473, 243);
            this.TEperRemark.Name = "TEperRemark";
            this.TEperRemark.Size = new System.Drawing.Size(382, 100);
            this.TEperRemark.StyleController = this.layoutControl2;
            this.TEperRemark.TabIndex = 25;
            this.TEperRemark.Tag = "perRemark";
            // 
            // GEpatientTypeNO
            // 
            this.GEpatientTypeNO.Location = new System.Drawing.Point(609, 147);
            this.GEpatientTypeNO.Name = "GEpatientTypeNO";
            this.GEpatientTypeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEpatientTypeNO.Properties.NullText = "";
            this.GEpatientTypeNO.Properties.PopupView = this.gridLookUpEdit1View;
            this.GEpatientTypeNO.Size = new System.Drawing.Size(246, 20);
            this.GEpatientTypeNO.StyleController = this.layoutControl2;
            this.GEpatientTypeNO.TabIndex = 4;
            this.GEpatientTypeNO.Tag = "patientTypeNO";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.DetailHeight = 408;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // GEsampleTypeNO
            // 
            this.GEsampleTypeNO.Location = new System.Drawing.Point(61, 147);
            this.GEsampleTypeNO.Name = "GEsampleTypeNO";
            this.GEsampleTypeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEsampleTypeNO.Properties.NullText = "";
            this.GEsampleTypeNO.Properties.PopupView = this.gridView3;
            this.GEsampleTypeNO.Size = new System.Drawing.Size(217, 20);
            this.GEsampleTypeNO.StyleController = this.layoutControl2;
            this.GEsampleTypeNO.TabIndex = 16;
            this.GEsampleTypeNO.Tag = "sampleTypeNO";
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 408;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // GEsampleShapeNO
            // 
            this.GEsampleShapeNO.Location = new System.Drawing.Point(609, 219);
            this.GEsampleShapeNO.Name = "GEsampleShapeNO";
            this.GEsampleShapeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEsampleShapeNO.Properties.NullText = "";
            this.GEsampleShapeNO.Properties.PopupView = this.gridView5;
            this.GEsampleShapeNO.Size = new System.Drawing.Size(246, 20);
            this.GEsampleShapeNO.StyleController = this.layoutControl2;
            this.GEsampleShapeNO.TabIndex = 17;
            this.GEsampleShapeNO.Tag = "sampleShapeNO";
            // 
            // gridView5
            // 
            this.gridView5.DetailHeight = 408;
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // GEpatientSexNO
            // 
            this.GEpatientSexNO.Location = new System.Drawing.Point(337, 75);
            this.GEpatientSexNO.Name = "GEpatientSexNO";
            this.GEpatientSexNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEpatientSexNO.Properties.DisplayFormat.FormatString = "d";
            this.GEpatientSexNO.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GEpatientSexNO.Properties.EditFormat.FormatString = "d";
            this.GEpatientSexNO.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GEpatientSexNO.Properties.NullText = "";
            this.GEpatientSexNO.Properties.PopupView = this.gridView6;
            this.GEpatientSexNO.Size = new System.Drawing.Size(181, 20);
            this.GEpatientSexNO.StyleController = this.layoutControl2;
            this.GEpatientSexNO.TabIndex = 12;
            this.GEpatientSexNO.Tag = "patientSexNO";
            // 
            // gridView6
            // 
            this.gridView6.DetailHeight = 408;
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            // 
            // GEagentNo
            // 
            this.GEagentNo.Location = new System.Drawing.Point(61, 51);
            this.GEagentNo.Name = "GEagentNo";
            this.GEagentNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEagentNo.Properties.NullText = "";
            this.GEagentNo.Properties.PopupView = this.gridView2;
            this.GEagentNo.Size = new System.Drawing.Size(217, 20);
            this.GEagentNo.StyleController = this.layoutControl2;
            this.GEagentNo.TabIndex = 1;
            this.GEagentNo.Tag = "agentNO";
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 408;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // GEhospitalNo
            // 
            this.GEhospitalNo.Location = new System.Drawing.Point(337, 27);
            this.GEhospitalNo.Name = "GEhospitalNo";
            this.GEhospitalNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEhospitalNo.Properties.NullText = "";
            this.GEhospitalNo.Properties.PopupView = this.gridView4;
            this.GEhospitalNo.Size = new System.Drawing.Size(518, 20);
            this.GEhospitalNo.StyleController = this.layoutControl2;
            this.GEhospitalNo.TabIndex = 0;
            this.GEhospitalNo.Tag = "hospitalNO";
            // 
            // gridView4
            // 
            this.gridView4.DetailHeight = 408;
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // LayGroupInfo
            // 
            this.LayGroupInfo.BestFitWeight = 0;
            this.LayGroupInfo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayGroupInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layGroupOther,
            this.layGroupInfos,
            this.layGroupItem});
            this.LayGroupInfo.Name = "Root";
            this.LayGroupInfo.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayGroupInfo.Size = new System.Drawing.Size(861, 700);
            this.LayGroupInfo.TextVisible = false;
            // 
            // layGroupOther
            // 
            this.layGroupOther.CaptionImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.layGroupOther.CustomizationFormText = "layoutControlGroup6";
            this.layGroupOther.ExpandButtonVisible = true;
            this.layGroupOther.Expanded = false;
            this.layGroupOther.Location = new System.Drawing.Point(0, 347);
            this.layGroupOther.Name = "layGroupOther";
            this.layGroupOther.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layGroupOther.Size = new System.Drawing.Size(859, 30);
            this.layGroupOther.Text = "扩展信息";
            // 
            // layGroupInfos
            // 
            this.layGroupInfos.CaptionImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.layGroupInfos.CustomizationFormText = "layoutControlGroup6";
            this.layGroupInfos.ExpandButtonVisible = true;
            this.layGroupInfos.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem40,
            this.layoutControlItem53,
            this.layoutControlItem30,
            this.layoutControlItem31,
            this.layoutControlItem28,
            this.layoutControlItem35,
            this.layoutControlItem36,
            this.layoutControlItem37,
            this.layoutControlItem38,
            this.layoutControlItem39,
            this.simpleLabelItem2,
            this.layoutControlItem29,
            this.layoutControlItem44,
            this.layoutControlItem47,
            this.layoutControlItem48,
            this.layoutControlItem49,
            this.layoutControlItem50,
            this.layoutControlItem51,
            this.layoutControlItem52,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem46,
            this.layoutControlItem43,
            this.layoutControlItem32,
            this.layoutControlItem3,
            this.layoutControlItem41,
            this.layoutControlItem45,
            this.layoutControlItem42,
            this.layoutControlItem34,
            this.layoutControlItem33,
            this.layoutControlItem1});
            this.layGroupInfos.Location = new System.Drawing.Point(0, 0);
            this.layGroupInfos.Name = "layGroupInfos";
            this.layGroupInfos.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layGroupInfos.Size = new System.Drawing.Size(859, 347);
            this.layGroupInfos.Text = "基本信息";
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem40.Control = this.TEbarcode;
            this.layoutControlItem40.CustomizationFormText = "条 码  号:";
            this.layoutControlItem40.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem40.Text = "条 码  号:";
            this.layoutControlItem40.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.TEperRemark;
            this.layoutControlItem53.CustomizationFormText = "申请备注:";
            this.layoutControlItem53.Location = new System.Drawing.Point(412, 216);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(441, 104);
            this.layoutControlItem53.Text = "申请备注:";
            this.layoutControlItem53.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem30.Control = this.GEhospitalNo;
            this.layoutControlItem30.CustomizationFormText = "送检单位:";
            this.layoutControlItem30.Location = new System.Drawing.Point(276, 0);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(577, 24);
            this.layoutControlItem30.Text = "送检客户:";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.TEhospitalBarcode;
            this.layoutControlItem31.CustomizationFormText = "外部条码:";
            this.layoutControlItem31.Location = new System.Drawing.Point(276, 24);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem31.Text = "外部条码:";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.GEagentNo;
            this.layoutControlItem28.CustomizationFormText = "代 理  商:";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem28.Text = "代 理  商:";
            this.layoutControlItem28.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutControlItem35.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem35.Control = this.TEpatientName;
            this.layoutControlItem35.CustomizationFormText = "姓      名:";
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem35.Text = "姓      名:";
            this.layoutControlItem35.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.GEpatientSexNO;
            this.layoutControlItem36.CustomizationFormText = "性      别:";
            this.layoutControlItem36.Location = new System.Drawing.Point(276, 48);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem36.Text = "性      别:";
            this.layoutControlItem36.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.TEageYear;
            this.layoutControlItem37.CustomizationFormText = "年      龄:";
            this.layoutControlItem37.Location = new System.Drawing.Point(516, 48);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(120, 24);
            this.layoutControlItem37.Text = "年龄:";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(28, 14);
            this.layoutControlItem37.TextToControlDistance = 5;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.TEageMoth;
            this.layoutControlItem38.CustomizationFormText = "岁";
            this.layoutControlItem38.Location = new System.Drawing.Point(636, 48);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(98, 24);
            this.layoutControlItem38.Text = "岁";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(12, 14);
            this.layoutControlItem38.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.TEageDay;
            this.layoutControlItem39.CustomizationFormText = "月";
            this.layoutControlItem39.Location = new System.Drawing.Point(734, 48);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(97, 24);
            this.layoutControlItem39.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem39.Text = "月";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(12, 14);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // simpleLabelItem2
            // 
            this.simpleLabelItem2.AllowHotTrack = false;
            this.simpleLabelItem2.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleLabelItem2.CustomizationFormText = "天";
            this.simpleLabelItem2.Location = new System.Drawing.Point(831, 48);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Size = new System.Drawing.Size(22, 24);
            this.simpleLabelItem2.Text = "天";
            this.simpleLabelItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(12, 14);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.TEdepartment;
            this.layoutControlItem29.CustomizationFormText = "送检科室:";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem29.Text = "送检科室:";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Control = this.GEsampleTypeNO;
            this.layoutControlItem44.CustomizationFormText = "标本类型:";
            this.layoutControlItem44.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem44.Text = "标本类型:";
            this.layoutControlItem44.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.DEsampleTime;
            this.layoutControlItem47.CustomizationFormText = "采样时间:";
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem47.Text = "采样时间:";
            this.layoutControlItem47.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.DEreceiveTime;
            this.layoutControlItem48.CustomizationFormText = "接收时间:";
            this.layoutControlItem48.Location = new System.Drawing.Point(276, 144);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem48.Text = "接收时间:";
            this.layoutControlItem48.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.TEpathologyNo;
            this.layoutControlItem49.CustomizationFormText = "病 理  号:";
            this.layoutControlItem49.Location = new System.Drawing.Point(548, 144);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem49.Text = "病 理  号:";
            this.layoutControlItem49.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.TEcutPart;
            this.layoutControlItem50.CustomizationFormText = "切取部位:";
            this.layoutControlItem50.Location = new System.Drawing.Point(276, 168);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem50.Text = "切取部位:";
            this.layoutControlItem50.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.DEmenstrualTime;
            this.layoutControlItem51.CustomizationFormText = "末次月经:";
            this.layoutControlItem51.Location = new System.Drawing.Point(548, 168);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem51.Text = "末次月经:";
            this.layoutControlItem51.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.Control = this.TEclinicalDiagnosis;
            this.layoutControlItem52.CustomizationFormText = "临床诊断:";
            this.layoutControlItem52.Location = new System.Drawing.Point(0, 216);
            this.layoutControlItem52.MaxSize = new System.Drawing.Size(0, 104);
            this.layoutControlItem52.MinSize = new System.Drawing.Size(82, 104);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(412, 104);
            this.layoutControlItem52.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem52.Text = "临床诊断:";
            this.layoutControlItem52.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CEurgent;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(124, 24);
            this.layoutControlItem2.Text = "是否加急:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TEpatientAddress;
            this.layoutControlItem4.CustomizationFormText = "电子邮箱:";
            this.layoutControlItem4.Location = new System.Drawing.Point(277, 192);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(271, 24);
            this.layoutControlItem4.Text = "家庭住址:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.TEnumber;
            this.layoutControlItem5.Location = new System.Drawing.Point(124, 192);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(153, 24);
            this.layoutControlItem5.Text = "数量:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(28, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.TEpatientCardNo;
            this.layoutControlItem46.CustomizationFormText = "身 份  证:";
            this.layoutControlItem46.Location = new System.Drawing.Point(548, 24);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem46.Text = "身 份  证:";
            this.layoutControlItem46.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.TEpatientPhone;
            this.layoutControlItem43.CustomizationFormText = "病人电话:";
            this.layoutControlItem43.Location = new System.Drawing.Point(548, 72);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem43.Text = "联系电话:";
            this.layoutControlItem43.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.GEpatientTypeNO;
            this.layoutControlItem32.CustomizationFormText = "病人类别:";
            this.layoutControlItem32.Location = new System.Drawing.Point(548, 120);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem32.Text = "病人类别:";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.TEpassportNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem3.Text = "护  照 号:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.TEmedicalNo;
            this.layoutControlItem41.CustomizationFormText = "病 历  号:";
            this.layoutControlItem41.Location = new System.Drawing.Point(276, 120);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem41.Text = "病 历  号:";
            this.layoutControlItem41.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.Control = this.GEsampleShapeNO;
            this.layoutControlItem45.CustomizationFormText = "标本性状:";
            this.layoutControlItem45.Location = new System.Drawing.Point(548, 192);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem45.Text = "标本性状:";
            this.layoutControlItem45.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.TEbedNo;
            this.layoutControlItem42.CustomizationFormText = "床     号:";
            this.layoutControlItem42.Location = new System.Drawing.Point(276, 96);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem42.Text = "床      号:";
            this.layoutControlItem42.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.TEdoctorPhone;
            this.layoutControlItem34.CustomizationFormText = "医生电话:";
            this.layoutControlItem34.Location = new System.Drawing.Point(548, 96);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(305, 24);
            this.layoutControlItem34.Text = "医生电话:";
            this.layoutControlItem34.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.TEsendDoctor;
            this.layoutControlItem33.CustomizationFormText = "送检医生:";
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(276, 24);
            this.layoutControlItem33.Text = "送检医生:";
            this.layoutControlItem33.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEsampleLocation;
            this.layoutControlItem1.Location = new System.Drawing.Point(276, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem1.Tag = "sampleLocation";
            this.layoutControlItem1.Text = "采样地点:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layGroupItem
            // 
            this.layGroupItem.CaptionImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.layGroupItem.CustomizationFormText = "layoutControlGroup6";
            this.layGroupItem.ExpandButtonVisible = true;
            this.layGroupItem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.layGroupItem.Location = new System.Drawing.Point(0, 377);
            this.layGroupItem.Name = "layGroupItem";
            this.layGroupItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layGroupItem.Size = new System.Drawing.Size(859, 321);
            this.layGroupItem.Text = "项目信息";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.splitContainerControl3;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(853, 294);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // GCSampleInfo
            // 
            this.GCSampleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSampleInfo.Location = new System.Drawing.Point(0, 0);
            this.GCSampleInfo.MainView = this.GVSampleInfo;
            this.GCSampleInfo.Name = "GCSampleInfo";
            this.GCSampleInfo.Size = new System.Drawing.Size(313, 740);
            this.GCSampleInfo.TabIndex = 0;
            this.GCSampleInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVSampleInfo});
            this.GCSampleInfo.Click += new System.EventHandler(this.GCSampleInfo_Click);
            // 
            // GVSampleInfo
            // 
            this.GVSampleInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.barcode,
            this.patientNames});
            this.GVSampleInfo.GridControl = this.GCSampleInfo;
            this.GVSampleInfo.Name = "GVSampleInfo";
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.AllowFocus = false;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 0;
            // 
            // patientNames
            // 
            this.patientNames.Caption = "姓名";
            this.patientNames.FieldName = "patientName";
            this.patientNames.Name = "patientNames";
            this.patientNames.OptionsColumn.AllowFocus = false;
            this.patientNames.Visible = true;
            this.patientNames.VisibleIndex = 1;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.DocksampleList,
            this.DockCenter});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel1.ID = new System.Guid("6c76af40-1ed4-48dc-b9bf-bd9163991562");
            this.dockPanel1.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedIndex = 1;
            this.dockPanel1.Size = new System.Drawing.Size(200, 200);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 171);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // DocksampleList
            // 
            this.DocksampleList.Controls.Add(this.dockPanel2_Container);
            this.DocksampleList.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.DocksampleList.ID = new System.Guid("0e60e09c-742f-461e-958b-7c4b375740f3");
            this.DocksampleList.Location = new System.Drawing.Point(0, 0);
            this.DocksampleList.Name = "DocksampleList";
            this.DocksampleList.OriginalSize = new System.Drawing.Size(320, 200);
            this.DocksampleList.Size = new System.Drawing.Size(320, 769);
            this.DocksampleList.Text = "信息列表";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.GCSampleInfo);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(313, 740);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // DockCenter
            // 
            this.DockCenter.Controls.Add(this.dockPanel3_Container);
            this.DockCenter.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.DockCenter.ID = new System.Guid("7a6def0a-50ac-4199-a47a-891af441ade6");
            this.DockCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DockCenter.Location = new System.Drawing.Point(320, 0);
            this.DockCenter.Name = "DockCenter";
            this.DockCenter.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.Left;
            this.DockCenter.Options.ShowAutoHideButton = false;
            this.DockCenter.Options.ShowCloseButton = false;
            this.DockCenter.Options.ShowMaximizeButton = false;
            this.DockCenter.OriginalSize = new System.Drawing.Size(1026, 200);
            this.DockCenter.Size = new System.Drawing.Size(867, 769);
            this.DockCenter.Text = "详细信息";
            this.DockCenter.Click += new System.EventHandler(this.DockCenter_Click);
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.BTClear);
            this.dockPanel3_Container.Controls.Add(this.layoutControl2);
            this.dockPanel3_Container.Controls.Add(this.BTSave);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(861, 740);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // BTClear
            // 
            this.BTClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTClear.Location = new System.Drawing.Point(755, 708);
            this.BTClear.Name = "BTClear";
            this.BTClear.Size = new System.Drawing.Size(75, 23);
            this.BTClear.TabIndex = 6;
            this.BTClear.Text = "取  消";
            this.BTClear.UseVisualStyleBackColor = true;
            this.BTClear.Click += new System.EventHandler(this.BTClear_Click);
            // 
            // BTSave
            // 
            this.BTSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTSave.Location = new System.Drawing.Point(640, 709);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(75, 23);
            this.BTSave.TabIndex = 5;
            this.BTSave.Text = "保  存";
            this.BTSave.UseVisualStyleBackColor = true;
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // FrmSampleInfoCheckEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 769);
            this.Controls.Add(this.DockCenter);
            this.Controls.Add(this.DocksampleList);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmSampleInfoCheckEdit.IconOptions.LargeImage")));
            this.Name = "FrmSampleInfoCheckEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改样本信息";
            this.Load += new System.EventHandler(this.FrmSampleInfoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCapplyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVapplyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCcheckInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVcheckInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEnumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpassportNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEurgent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsampleLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEhospitalBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsendDoctor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdoctorPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEageYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEageMoth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEageDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEmedicalNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEbedNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpatientCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEsampleTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEsampleTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEreceiveTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEreceiveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEpathologyNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEcutPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEmenstrualTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEmenstrualTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEclinicalDiagnosis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEperRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEpatientTypeNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEsampleTypeNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEsampleShapeNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEpatientSexNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEagentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEhospitalNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.DocksampleList.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.DockCenter.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private LayoutControl layoutControl2;
        private CheckEdit CEurgent;
        private TextEdit TEsampleLocation;
        private TextEdit TEdepartment;
        private TextEdit TEhospitalBarcode;
        private TextEdit TEsendDoctor;
        private TextEdit TEdoctorPhone;
        private TextEdit TEpatientName;
        private TextEdit TEageYear;
        private TextEdit TEageMoth;
        private TextEdit TEageDay;
        private TextEdit TEbarcode;
        private TextEdit TEmedicalNo;
        private TextEdit TEbedNo;
        private TextEdit TEpatientPhone;
        private TextEdit TEpatientCardNo;
        private DateEdit DEsampleTime;
        private DateEdit DEreceiveTime;
        private TextEdit TEpathologyNo;
        private TextEdit TEcutPart;
        private DateEdit DEmenstrualTime;
        private MemoEdit TEclinicalDiagnosis;
        private MemoEdit TEperRemark;
        private GridLookUpEdit GEpatientTypeNO;
        private GridView gridLookUpEdit1View;
        private GridLookUpEdit GEsampleTypeNO;
        private GridView gridView3;
        private GridLookUpEdit GEsampleShapeNO;
        private GridView gridView5;
        private GridLookUpEdit GEpatientSexNO;
        private GridView gridView6;
        private GridLookUpEdit GEagentNo;
        private GridView gridView2;
        private GridLookUpEdit GEhospitalNo;
        private GridView gridView4;
        private LayoutControlGroup LayGroupInfo;
        private LayoutControlGroup layGroupOther;
        private LayoutControlGroup layGroupInfos;
        private LayoutControlItem layoutControlItem40;
        private LayoutControlItem layoutControlItem53;
        private LayoutControlItem layoutControlItem30;
        private LayoutControlItem layoutControlItem31;
        private LayoutControlItem layoutControlItem28;
        private LayoutControlItem layoutControlItem32;
        private LayoutControlItem layoutControlItem35;
        private LayoutControlItem layoutControlItem36;
        private LayoutControlItem layoutControlItem37;
        private LayoutControlItem layoutControlItem38;
        private LayoutControlItem layoutControlItem39;
        private SimpleLabelItem simpleLabelItem2;
        private LayoutControlItem layoutControlItem29;
        private LayoutControlItem layoutControlItem33;
        private LayoutControlItem layoutControlItem34;
        private LayoutControlItem layoutControlItem41;
        private LayoutControlItem layoutControlItem42;
        private LayoutControlItem layoutControlItem43;
        private LayoutControlItem layoutControlItem44;
        private LayoutControlItem layoutControlItem45;
        private LayoutControlItem layoutControlItem46;
        private LayoutControlItem layoutControlItem47;
        private LayoutControlItem layoutControlItem48;
        private LayoutControlItem layoutControlItem49;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem50;
        private LayoutControlItem layoutControlItem51;
        private LayoutControlItem layoutControlItem52;
        private LayoutControlItem layoutControlItem2;
        private GridControl GCSampleInfo;
        private GridView GVSampleInfo;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn patientNames;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private System.Windows.Forms.Button BTClear;
        private System.Windows.Forms.Button BTSave;
        private DevExpress.XtraBars.Docking.DockPanel DocksampleList;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel DockCenter;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private TextEdit TEpatientAddress;
        private TextEdit TEpassportNo;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem4;
        private TextEdit TEnumber;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlGroup layGroupItem;
        private SplitContainerControl splitContainerControl3;
        private GroupControl groupControl1;
        private GridControl GCapplyInfo;
        private GridView GVapplyInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn AshortNames;
        private DevExpress.XtraGrid.Columns.GridColumn AcustomCode;
        private GroupControl groupControl2;
        private GridControl GCcheckInfo;
        private GridView GVcheckInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private LayoutControlItem layoutControlItem6;
    }
}