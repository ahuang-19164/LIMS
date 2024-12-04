using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace Common.SampleInfoEdit
{
    partial class FrmSampleInfoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSampleInfoEdit));
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.BTClear = new System.Windows.Forms.Button();
            this.BTSave = new System.Windows.Forms.Button();
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GEhospitalNo = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
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
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.q = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layGroupOther = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.DocksampleList.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.DockCenter.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEhospitalNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // GCSampleInfo
            // 
            this.GCSampleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCSampleInfo.Location = new System.Drawing.Point(0, 0);
            this.GCSampleInfo.MainView = this.GVSampleInfo;
            this.GCSampleInfo.Name = "GCSampleInfo";
            this.GCSampleInfo.Size = new System.Drawing.Size(390, 655);
            this.GCSampleInfo.TabIndex = 0;
            this.GCSampleInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVSampleInfo});
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
            this.DocksampleList.OriginalSize = new System.Drawing.Size(397, 200);
            this.DocksampleList.Size = new System.Drawing.Size(397, 684);
            this.DocksampleList.Text = "信息列表";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.GCSampleInfo);
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(390, 655);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // DockCenter
            // 
            this.DockCenter.Controls.Add(this.dockPanel3_Container);
            this.DockCenter.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.DockCenter.ID = new System.Guid("7a6def0a-50ac-4199-a47a-891af441ade6");
            this.DockCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DockCenter.Location = new System.Drawing.Point(397, 0);
            this.DockCenter.Name = "DockCenter";
            this.DockCenter.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.Left;
            this.DockCenter.Options.ShowAutoHideButton = false;
            this.DockCenter.Options.ShowCloseButton = false;
            this.DockCenter.Options.ShowMaximizeButton = false;
            this.DockCenter.OriginalSize = new System.Drawing.Size(200, 200);
            this.DockCenter.Size = new System.Drawing.Size(788, 684);
            this.DockCenter.Text = "详细信息";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.layoutControl1);
            this.dockPanel3_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(782, 655);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.TEnumber);
            this.layoutControl1.Controls.Add(this.TEpatientAddress);
            this.layoutControl1.Controls.Add(this.TEpassportNo);
            this.layoutControl1.Controls.Add(this.CEurgent);
            this.layoutControl1.Controls.Add(this.TEsampleLocation);
            this.layoutControl1.Controls.Add(this.TEdepartment);
            this.layoutControl1.Controls.Add(this.TEhospitalBarcode);
            this.layoutControl1.Controls.Add(this.TEsendDoctor);
            this.layoutControl1.Controls.Add(this.TEdoctorPhone);
            this.layoutControl1.Controls.Add(this.TEpatientName);
            this.layoutControl1.Controls.Add(this.TEageYear);
            this.layoutControl1.Controls.Add(this.TEageMoth);
            this.layoutControl1.Controls.Add(this.TEageDay);
            this.layoutControl1.Controls.Add(this.TEbarcode);
            this.layoutControl1.Controls.Add(this.TEmedicalNo);
            this.layoutControl1.Controls.Add(this.TEbedNo);
            this.layoutControl1.Controls.Add(this.TEpatientPhone);
            this.layoutControl1.Controls.Add(this.TEpatientCardNo);
            this.layoutControl1.Controls.Add(this.DEsampleTime);
            this.layoutControl1.Controls.Add(this.DEreceiveTime);
            this.layoutControl1.Controls.Add(this.TEpathologyNo);
            this.layoutControl1.Controls.Add(this.TEcutPart);
            this.layoutControl1.Controls.Add(this.DEmenstrualTime);
            this.layoutControl1.Controls.Add(this.TEclinicalDiagnosis);
            this.layoutControl1.Controls.Add(this.TEperRemark);
            this.layoutControl1.Controls.Add(this.GEpatientTypeNO);
            this.layoutControl1.Controls.Add(this.GEsampleTypeNO);
            this.layoutControl1.Controls.Add(this.GEsampleShapeNO);
            this.layoutControl1.Controls.Add(this.GEpatientSexNO);
            this.layoutControl1.Controls.Add(this.GEagentNo);
            this.layoutControl1.Controls.Add(this.GEhospitalNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.MinimumSize = new System.Drawing.Size(583, 467);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(121, 241, 1185, 718);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(782, 655);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BTClear);
            this.panelControl1.Controls.Add(this.BTSave);
            this.panelControl1.Location = new System.Drawing.Point(2, 626);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(778, 27);
            this.panelControl1.TabIndex = 32;
            // 
            // BTClear
            // 
            this.BTClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTClear.Location = new System.Drawing.Point(678, 2);
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
            this.BTSave.Location = new System.Drawing.Point(557, 2);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(75, 23);
            this.BTSave.TabIndex = 5;
            this.BTSave.Text = "保  存";
            this.BTSave.UseVisualStyleBackColor = true;
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // TEnumber
            // 
            this.TEnumber.Location = new System.Drawing.Point(161, 218);
            this.TEnumber.Name = "TEnumber";
            this.TEnumber.Size = new System.Drawing.Size(94, 20);
            this.TEnumber.StyleController = this.layoutControl1;
            this.TEnumber.TabIndex = 27;
            this.TEnumber.Tag = "number";
            // 
            // TEpatientAddress
            // 
            this.TEpatientAddress.Location = new System.Drawing.Point(314, 218);
            this.TEpatientAddress.Name = "TEpatientAddress";
            this.TEpatientAddress.Size = new System.Drawing.Size(168, 20);
            this.TEpatientAddress.StyleController = this.layoutControl1;
            this.TEpatientAddress.TabIndex = 28;
            this.TEpatientAddress.Tag = "patientAddress";
            // 
            // TEpassportNo
            // 
            this.TEpassportNo.Location = new System.Drawing.Point(60, 98);
            this.TEpassportNo.Name = "TEpassportNo";
            this.TEpassportNo.Size = new System.Drawing.Size(194, 20);
            this.TEpassportNo.StyleController = this.layoutControl1;
            this.TEpassportNo.TabIndex = 11;
            this.TEpassportNo.Tag = "passportNo";
            // 
            // CEurgent
            // 
            this.CEurgent.Location = new System.Drawing.Point(60, 218);
            this.CEurgent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CEurgent.Name = "CEurgent";
            this.CEurgent.Properties.Caption = "加急";
            this.CEurgent.Size = new System.Drawing.Size(64, 20);
            this.CEurgent.StyleController = this.layoutControl1;
            this.CEurgent.TabIndex = 26;
            this.CEurgent.Tag = "urgent";
            // 
            // TEsampleLocation
            // 
            this.TEsampleLocation.Location = new System.Drawing.Point(313, 98);
            this.TEsampleLocation.Name = "TEsampleLocation";
            this.TEsampleLocation.Size = new System.Drawing.Size(169, 20);
            this.TEsampleLocation.StyleController = this.layoutControl1;
            this.TEsampleLocation.TabIndex = 12;
            this.TEsampleLocation.Tag = "sampleLocation";
            // 
            // TEdepartment
            // 
            this.TEdepartment.Location = new System.Drawing.Point(60, 122);
            this.TEdepartment.Name = "TEdepartment";
            this.TEdepartment.Size = new System.Drawing.Size(194, 20);
            this.TEdepartment.StyleController = this.layoutControl1;
            this.TEdepartment.TabIndex = 14;
            this.TEdepartment.Tag = "department";
            // 
            // TEhospitalBarcode
            // 
            this.TEhospitalBarcode.Location = new System.Drawing.Point(313, 50);
            this.TEhospitalBarcode.Name = "TEhospitalBarcode";
            this.TEhospitalBarcode.Size = new System.Drawing.Size(169, 20);
            this.TEhospitalBarcode.StyleController = this.layoutControl1;
            this.TEhospitalBarcode.TabIndex = 4;
            this.TEhospitalBarcode.Tag = "hospitalBarcode";
            // 
            // TEsendDoctor
            // 
            this.TEsendDoctor.Location = new System.Drawing.Point(60, 194);
            this.TEsendDoctor.Name = "TEsendDoctor";
            this.TEsendDoctor.Size = new System.Drawing.Size(194, 20);
            this.TEsendDoctor.StyleController = this.layoutControl1;
            this.TEsendDoctor.TabIndex = 23;
            this.TEsendDoctor.Tag = "sendDoctor";
            // 
            // TEdoctorPhone
            // 
            this.TEdoctorPhone.Location = new System.Drawing.Point(541, 122);
            this.TEdoctorPhone.Name = "TEdoctorPhone";
            this.TEdoctorPhone.Size = new System.Drawing.Size(236, 20);
            this.TEdoctorPhone.StyleController = this.layoutControl1;
            this.TEdoctorPhone.TabIndex = 16;
            this.TEdoctorPhone.Tag = "doctorPhone";
            // 
            // TEpatientName
            // 
            this.TEpatientName.Location = new System.Drawing.Point(60, 74);
            this.TEpatientName.Name = "TEpatientName";
            this.TEpatientName.Size = new System.Drawing.Size(194, 20);
            this.TEpatientName.StyleController = this.layoutControl1;
            this.TEpatientName.TabIndex = 6;
            this.TEpatientName.Tag = "patientName";
            // 
            // TEageYear
            // 
            this.TEageYear.Location = new System.Drawing.Point(477, 74);
            this.TEageYear.Name = "TEageYear";
            this.TEageYear.Size = new System.Drawing.Size(83, 20);
            this.TEageYear.StyleController = this.layoutControl1;
            this.TEageYear.TabIndex = 8;
            this.TEageYear.Tag = "ageYear";
            // 
            // TEageMoth
            // 
            this.TEageMoth.Location = new System.Drawing.Point(581, 74);
            this.TEageMoth.Name = "TEageMoth";
            this.TEageMoth.Size = new System.Drawing.Size(76, 20);
            this.TEageMoth.StyleController = this.layoutControl1;
            this.TEageMoth.TabIndex = 9;
            this.TEageMoth.Tag = "ageMoth";
            // 
            // TEageDay
            // 
            this.TEageDay.Location = new System.Drawing.Point(678, 74);
            this.TEageDay.Name = "TEageDay";
            this.TEageDay.Size = new System.Drawing.Size(77, 20);
            this.TEageDay.StyleController = this.layoutControl1;
            this.TEageDay.TabIndex = 10;
            this.TEageDay.Tag = "ageDay";
            // 
            // TEbarcode
            // 
            this.TEbarcode.EditValue = "";
            this.TEbarcode.Location = new System.Drawing.Point(60, 26);
            this.TEbarcode.Name = "TEbarcode";
            this.TEbarcode.Size = new System.Drawing.Size(194, 20);
            this.TEbarcode.StyleController = this.layoutControl1;
            this.TEbarcode.TabIndex = 1;
            this.TEbarcode.Tag = "barcode";
            // 
            // TEmedicalNo
            // 
            this.TEmedicalNo.Location = new System.Drawing.Point(313, 146);
            this.TEmedicalNo.Name = "TEmedicalNo";
            this.TEmedicalNo.Size = new System.Drawing.Size(169, 20);
            this.TEmedicalNo.StyleController = this.layoutControl1;
            this.TEmedicalNo.TabIndex = 18;
            this.TEmedicalNo.Tag = "medicalNo";
            // 
            // TEbedNo
            // 
            this.TEbedNo.Location = new System.Drawing.Point(313, 122);
            this.TEbedNo.Name = "TEbedNo";
            this.TEbedNo.Size = new System.Drawing.Size(169, 20);
            this.TEbedNo.StyleController = this.layoutControl1;
            this.TEbedNo.TabIndex = 15;
            this.TEbedNo.Tag = "bedNo";
            // 
            // TEpatientPhone
            // 
            this.TEpatientPhone.Location = new System.Drawing.Point(541, 98);
            this.TEpatientPhone.Name = "TEpatientPhone";
            this.TEpatientPhone.Size = new System.Drawing.Size(236, 20);
            this.TEpatientPhone.StyleController = this.layoutControl1;
            this.TEpatientPhone.TabIndex = 13;
            this.TEpatientPhone.Tag = "patientPhone";
            // 
            // TEpatientCardNo
            // 
            this.TEpatientCardNo.Location = new System.Drawing.Point(541, 50);
            this.TEpatientCardNo.Name = "TEpatientCardNo";
            this.TEpatientCardNo.Size = new System.Drawing.Size(236, 20);
            this.TEpatientCardNo.StyleController = this.layoutControl1;
            this.TEpatientCardNo.TabIndex = 5;
            this.TEpatientCardNo.Tag = "patientCardNo";
            // 
            // DEsampleTime
            // 
            this.DEsampleTime.EditValue = null;
            this.DEsampleTime.Location = new System.Drawing.Point(60, 170);
            this.DEsampleTime.Name = "DEsampleTime";
            this.DEsampleTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEsampleTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEsampleTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.DEsampleTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEsampleTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.DEsampleTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEsampleTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.DEsampleTime.Size = new System.Drawing.Size(194, 20);
            this.DEsampleTime.StyleController = this.layoutControl1;
            this.DEsampleTime.TabIndex = 20;
            this.DEsampleTime.Tag = "sampleTime";
            // 
            // DEreceiveTime
            // 
            this.DEreceiveTime.EditValue = null;
            this.DEreceiveTime.Location = new System.Drawing.Point(313, 170);
            this.DEreceiveTime.Name = "DEreceiveTime";
            this.DEreceiveTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEreceiveTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEreceiveTime.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.DEreceiveTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEreceiveTime.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.DEreceiveTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEreceiveTime.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.DEreceiveTime.Size = new System.Drawing.Size(169, 20);
            this.DEreceiveTime.StyleController = this.layoutControl1;
            this.DEreceiveTime.TabIndex = 21;
            this.DEreceiveTime.Tag = "receiveTime";
            // 
            // TEpathologyNo
            // 
            this.TEpathologyNo.Location = new System.Drawing.Point(541, 170);
            this.TEpathologyNo.Name = "TEpathologyNo";
            this.TEpathologyNo.Size = new System.Drawing.Size(236, 20);
            this.TEpathologyNo.StyleController = this.layoutControl1;
            this.TEpathologyNo.TabIndex = 22;
            this.TEpathologyNo.Tag = "pathologyNo";
            // 
            // TEcutPart
            // 
            this.TEcutPart.Location = new System.Drawing.Point(313, 194);
            this.TEcutPart.Name = "TEcutPart";
            this.TEcutPart.Size = new System.Drawing.Size(169, 20);
            this.TEcutPart.StyleController = this.layoutControl1;
            this.TEcutPart.TabIndex = 24;
            this.TEcutPart.Tag = "cutPart";
            // 
            // DEmenstrualTime
            // 
            this.DEmenstrualTime.EditValue = null;
            this.DEmenstrualTime.Location = new System.Drawing.Point(541, 194);
            this.DEmenstrualTime.Name = "DEmenstrualTime";
            this.DEmenstrualTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEmenstrualTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEmenstrualTime.Properties.DisplayFormat.FormatString = "";
            this.DEmenstrualTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEmenstrualTime.Properties.EditFormat.FormatString = "";
            this.DEmenstrualTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DEmenstrualTime.Properties.Mask.EditMask = "g";
            this.DEmenstrualTime.Size = new System.Drawing.Size(236, 20);
            this.DEmenstrualTime.StyleController = this.layoutControl1;
            this.DEmenstrualTime.TabIndex = 25;
            this.DEmenstrualTime.Tag = "menstrualTime";
            // 
            // TEclinicalDiagnosis
            // 
            this.TEclinicalDiagnosis.Location = new System.Drawing.Point(60, 242);
            this.TEclinicalDiagnosis.Name = "TEclinicalDiagnosis";
            this.TEclinicalDiagnosis.Size = new System.Drawing.Size(315, 100);
            this.TEclinicalDiagnosis.StyleController = this.layoutControl1;
            this.TEclinicalDiagnosis.TabIndex = 30;
            this.TEclinicalDiagnosis.Tag = "clinicalDiagnosis";
            // 
            // TEperRemark
            // 
            this.TEperRemark.Location = new System.Drawing.Point(434, 242);
            this.TEperRemark.Name = "TEperRemark";
            this.TEperRemark.Size = new System.Drawing.Size(343, 100);
            this.TEperRemark.StyleController = this.layoutControl1;
            this.TEperRemark.TabIndex = 31;
            this.TEperRemark.Tag = "perRemark";
            // 
            // GEpatientTypeNO
            // 
            this.GEpatientTypeNO.Location = new System.Drawing.Point(541, 146);
            this.GEpatientTypeNO.Name = "GEpatientTypeNO";
            this.GEpatientTypeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEpatientTypeNO.Properties.NullText = "";
            this.GEpatientTypeNO.Properties.PopupView = this.gridLookUpEdit1View;
            this.GEpatientTypeNO.Size = new System.Drawing.Size(236, 20);
            this.GEpatientTypeNO.StyleController = this.layoutControl1;
            this.GEpatientTypeNO.TabIndex = 19;
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
            this.GEsampleTypeNO.EditValue = "46";
            this.GEsampleTypeNO.Location = new System.Drawing.Point(60, 146);
            this.GEsampleTypeNO.Name = "GEsampleTypeNO";
            this.GEsampleTypeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEsampleTypeNO.Properties.NullText = "";
            this.GEsampleTypeNO.Properties.PopupView = this.gridView3;
            this.GEsampleTypeNO.Size = new System.Drawing.Size(194, 20);
            this.GEsampleTypeNO.StyleController = this.layoutControl1;
            this.GEsampleTypeNO.TabIndex = 17;
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
            this.GEsampleShapeNO.EditValue = "48";
            this.GEsampleShapeNO.Location = new System.Drawing.Point(541, 218);
            this.GEsampleShapeNO.Name = "GEsampleShapeNO";
            this.GEsampleShapeNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEsampleShapeNO.Properties.NullText = "";
            this.GEsampleShapeNO.Properties.PopupView = this.gridView5;
            this.GEsampleShapeNO.Size = new System.Drawing.Size(236, 20);
            this.GEsampleShapeNO.StyleController = this.layoutControl1;
            this.GEsampleShapeNO.TabIndex = 29;
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
            this.GEpatientSexNO.Location = new System.Drawing.Point(313, 74);
            this.GEpatientSexNO.Name = "GEpatientSexNO";
            this.GEpatientSexNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEpatientSexNO.Properties.DisplayFormat.FormatString = "d";
            this.GEpatientSexNO.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GEpatientSexNO.Properties.EditFormat.FormatString = "d";
            this.GEpatientSexNO.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.GEpatientSexNO.Properties.NullText = "";
            this.GEpatientSexNO.Properties.PopupView = this.gridView6;
            this.GEpatientSexNO.Size = new System.Drawing.Size(127, 20);
            this.GEpatientSexNO.StyleController = this.layoutControl1;
            this.GEpatientSexNO.TabIndex = 7;
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
            this.GEagentNo.Location = new System.Drawing.Point(60, 50);
            this.GEagentNo.Name = "GEagentNo";
            this.GEagentNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEagentNo.Properties.NullText = "";
            this.GEagentNo.Properties.PopupView = this.gridView1;
            this.GEagentNo.Size = new System.Drawing.Size(194, 20);
            this.GEagentNo.StyleController = this.layoutControl1;
            this.GEagentNo.TabIndex = 3;
            this.GEagentNo.Tag = "agentNO";
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 408;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // GEhospitalNo
            // 
            this.GEhospitalNo.Location = new System.Drawing.Point(313, 26);
            this.GEhospitalNo.Name = "GEhospitalNo";
            this.GEhospitalNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GEhospitalNo.Properties.NullText = "";
            this.GEhospitalNo.Properties.PopupView = this.gridView2;
            this.GEhospitalNo.Size = new System.Drawing.Size(464, 20);
            this.GEhospitalNo.StyleController = this.layoutControl1;
            this.GEhospitalNo.TabIndex = 2;
            this.GEhospitalNo.Tag = "hospitalNO";
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 408;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layGroupInfos,
            this.layGroupOther,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(782, 655);
            this.layoutControlGroup1.TextVisible = false;
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
            this.layoutControlItem42,
            this.layoutControlItem43,
            this.layoutControlItem44,
            this.layoutControlItem47,
            this.layoutControlItem48,
            this.layoutControlItem49,
            this.layoutControlItem50,
            this.layoutControlItem51,
            this.layoutControlItem52,
            this.layoutControlItem2,
            this.q,
            this.layoutControlItem46,
            this.layoutControlItem32,
            this.layoutControlItem34,
            this.layoutControlItem3,
            this.layoutControlItem29,
            this.layoutControlItem1,
            this.layoutControlItem33,
            this.layoutControlItem41,
            this.layoutControlItem45,
            this.layoutControlItem4});
            this.layGroupInfos.Location = new System.Drawing.Point(0, 0);
            this.layGroupInfos.Name = "layGroupInfos";
            this.layGroupInfos.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layGroupInfos.Size = new System.Drawing.Size(782, 347);
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
            this.layoutControlItem40.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem40.Text = "条 码  号:";
            this.layoutControlItem40.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.TEperRemark;
            this.layoutControlItem53.CustomizationFormText = "申请备注:";
            this.layoutControlItem53.Location = new System.Drawing.Point(374, 216);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(402, 104);
            this.layoutControlItem53.Text = "申请备注:";
            this.layoutControlItem53.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem30.Control = this.GEhospitalNo;
            this.layoutControlItem30.CustomizationFormText = "送检单位:";
            this.layoutControlItem30.Location = new System.Drawing.Point(253, 0);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(523, 24);
            this.layoutControlItem30.Text = "送检客户:";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.TEhospitalBarcode;
            this.layoutControlItem31.CustomizationFormText = "外部条码:";
            this.layoutControlItem31.Location = new System.Drawing.Point(253, 24);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem31.Text = "外部条码:";
            this.layoutControlItem31.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.GEagentNo;
            this.layoutControlItem28.CustomizationFormText = "代 理  商:";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(253, 24);
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
            this.layoutControlItem35.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem35.Text = "姓      名:";
            this.layoutControlItem35.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.GEpatientSexNO;
            this.layoutControlItem36.CustomizationFormText = "性      别:";
            this.layoutControlItem36.Location = new System.Drawing.Point(253, 48);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(186, 24);
            this.layoutControlItem36.Text = "性      别:";
            this.layoutControlItem36.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.TEageYear;
            this.layoutControlItem37.CustomizationFormText = "年      龄:";
            this.layoutControlItem37.Location = new System.Drawing.Point(439, 48);
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
            this.layoutControlItem38.Location = new System.Drawing.Point(559, 48);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(97, 24);
            this.layoutControlItem38.Text = "岁";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(12, 14);
            this.layoutControlItem38.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.TEageDay;
            this.layoutControlItem39.CustomizationFormText = "月";
            this.layoutControlItem39.Location = new System.Drawing.Point(656, 48);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(98, 24);
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
            this.simpleLabelItem2.Location = new System.Drawing.Point(754, 48);
            this.simpleLabelItem2.Name = "simpleLabelItem2";
            this.simpleLabelItem2.Size = new System.Drawing.Size(22, 24);
            this.simpleLabelItem2.Text = "天";
            this.simpleLabelItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem2.TextSize = new System.Drawing.Size(12, 14);
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.TEbedNo;
            this.layoutControlItem42.CustomizationFormText = "床     号:";
            this.layoutControlItem42.Location = new System.Drawing.Point(253, 96);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem42.Text = "床      号:";
            this.layoutControlItem42.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.TEpatientPhone;
            this.layoutControlItem43.CustomizationFormText = "联系电话:";
            this.layoutControlItem43.Location = new System.Drawing.Point(481, 72);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(295, 24);
            this.layoutControlItem43.Text = "联系电话:";
            this.layoutControlItem43.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Control = this.GEsampleTypeNO;
            this.layoutControlItem44.CustomizationFormText = "标本类型:";
            this.layoutControlItem44.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem44.Text = "标本类型:";
            this.layoutControlItem44.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.DEsampleTime;
            this.layoutControlItem47.CustomizationFormText = "采样时间:";
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem47.Text = "采样时间:";
            this.layoutControlItem47.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.DEreceiveTime;
            this.layoutControlItem48.CustomizationFormText = "接收时间:";
            this.layoutControlItem48.Location = new System.Drawing.Point(253, 144);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem48.Text = "接收时间:";
            this.layoutControlItem48.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.TEpathologyNo;
            this.layoutControlItem49.CustomizationFormText = "病 理  号:";
            this.layoutControlItem49.Location = new System.Drawing.Point(481, 144);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(295, 24);
            this.layoutControlItem49.Text = "病 理  号:";
            this.layoutControlItem49.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.TEcutPart;
            this.layoutControlItem50.CustomizationFormText = "切取部位:";
            this.layoutControlItem50.Location = new System.Drawing.Point(253, 168);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem50.Text = "切取部位:";
            this.layoutControlItem50.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.DEmenstrualTime;
            this.layoutControlItem51.CustomizationFormText = "末次月经:";
            this.layoutControlItem51.Location = new System.Drawing.Point(481, 168);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(295, 24);
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
            this.layoutControlItem52.Size = new System.Drawing.Size(374, 104);
            this.layoutControlItem52.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem52.Text = "临床诊断:";
            this.layoutControlItem52.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CEurgent;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(123, 24);
            this.layoutControlItem2.Text = "是否加急:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 14);
            // 
            // q
            // 
            this.q.Control = this.TEpatientAddress;
            this.q.Location = new System.Drawing.Point(254, 192);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(227, 24);
            this.q.Text = "电子邮箱:";
            this.q.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.TEpatientCardNo;
            this.layoutControlItem46.CustomizationFormText = "身 份  证:";
            this.layoutControlItem46.Location = new System.Drawing.Point(481, 24);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(295, 24);
            this.layoutControlItem46.Text = "身 份  证:";
            this.layoutControlItem46.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.GEpatientTypeNO;
            this.layoutControlItem32.CustomizationFormText = "病人类别:";
            this.layoutControlItem32.Location = new System.Drawing.Point(481, 120);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(295, 24);
            this.layoutControlItem32.Text = "病人类别:";
            this.layoutControlItem32.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.TEdoctorPhone;
            this.layoutControlItem34.CustomizationFormText = "医生电话:";
            this.layoutControlItem34.Location = new System.Drawing.Point(481, 96);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(295, 24);
            this.layoutControlItem34.Text = "医生电话:";
            this.layoutControlItem34.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.TEpassportNo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem3.Text = "护  照 号:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.TEdepartment;
            this.layoutControlItem29.CustomizationFormText = "送检科室:";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem29.Text = "送检科室:";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEsampleLocation;
            this.layoutControlItem1.Location = new System.Drawing.Point(253, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem1.Text = "采样地点:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.TEsendDoctor;
            this.layoutControlItem33.CustomizationFormText = "送检医生:";
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(253, 24);
            this.layoutControlItem33.Text = "送检医生:";
            this.layoutControlItem33.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.TEmedicalNo;
            this.layoutControlItem41.CustomizationFormText = "病 历  号:";
            this.layoutControlItem41.Location = new System.Drawing.Point(253, 120);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem41.Text = "病 历  号:";
            this.layoutControlItem41.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.Control = this.GEsampleShapeNO;
            this.layoutControlItem45.CustomizationFormText = "标本性状:";
            this.layoutControlItem45.Location = new System.Drawing.Point(481, 192);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(295, 24);
            this.layoutControlItem45.Text = "标本性状:";
            this.layoutControlItem45.TextSize = new System.Drawing.Size(52, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TEnumber;
            this.layoutControlItem4.Location = new System.Drawing.Point(123, 192);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(109, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(131, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "数量:";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(28, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layGroupOther
            // 
            this.layGroupOther.CaptionImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.layGroupOther.CustomizationFormText = "layoutControlGroup6";
            this.layGroupOther.ExpandButtonVisible = true;
            this.layGroupOther.Location = new System.Drawing.Point(0, 347);
            this.layGroupOther.Name = "layGroupOther";
            this.layGroupOther.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layGroupOther.Size = new System.Drawing.Size(782, 277);
            this.layGroupOther.Text = "扩展信息";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.panelControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 624);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(782, 31);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // FrmSampleInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 684);
            this.Controls.Add(this.DockCenter);
            this.Controls.Add(this.DocksampleList);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmSampleInfoEdit.IconOptions.LargeImage")));
            this.Name = "FrmSampleInfoEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改样本信息";
            this.Load += new System.EventHandler(this.FrmSampleInfoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSampleInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.DocksampleList.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.DockCenter.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GEhospitalNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private LayoutControl layoutControl1;
        private TextEdit TEnumber;
        private TextEdit TEpatientAddress;
        private TextEdit TEpassportNo;
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
        private GridView gridView1;
        private GridLookUpEdit GEhospitalNo;
        private GridView gridView2;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlGroup layGroupInfos;
        private LayoutControlItem layoutControlItem40;
        private LayoutControlItem layoutControlItem53;
        private LayoutControlItem layoutControlItem30;
        private LayoutControlItem layoutControlItem31;
        private LayoutControlItem layoutControlItem28;
        private LayoutControlItem layoutControlItem35;
        private LayoutControlItem layoutControlItem36;
        private LayoutControlItem layoutControlItem37;
        private LayoutControlItem layoutControlItem38;
        private LayoutControlItem layoutControlItem39;
        private SimpleLabelItem simpleLabelItem2;
        private LayoutControlItem layoutControlItem42;
        private LayoutControlItem layoutControlItem43;
        private LayoutControlItem layoutControlItem44;
        private LayoutControlItem layoutControlItem47;
        private LayoutControlItem layoutControlItem48;
        private LayoutControlItem layoutControlItem49;
        private LayoutControlItem layoutControlItem50;
        private LayoutControlItem layoutControlItem51;
        private LayoutControlItem layoutControlItem52;
        private LayoutControlItem layoutControlItem2;
        private LayoutControlItem q;
        private LayoutControlItem layoutControlItem46;
        private LayoutControlItem layoutControlItem32;
        private LayoutControlItem layoutControlItem34;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem29;
        private LayoutControlItem layoutControlItem1;
        private LayoutControlItem layoutControlItem33;
        private LayoutControlItem layoutControlItem41;
        private LayoutControlItem layoutControlItem45;
        private LayoutControlItem layoutControlItem4;
        private LayoutControlGroup layGroupOther;
        private PanelControl panelControl1;
        private LayoutControlItem layoutControlItem5;
    }
}