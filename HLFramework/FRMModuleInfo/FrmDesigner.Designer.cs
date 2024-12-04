//namespace HLFramework
//{
//    partial class FrmDesigner
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
//            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
//            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
//            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
//            this.bar2 = new DevExpress.XtraBars.Bar();
//            this.bar3 = new DevExpress.XtraBars.Bar();
//            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
//            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
//            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
//            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
//            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
//            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
//            this.pnlToolBox = new System.Windows.Forms.Panel();
//            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
//            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
//            this.pnlPropertyGrid = new System.Windows.Forms.Panel();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.tabContent = new System.Windows.Forms.TabControl();
//            this.tpDesign = new System.Windows.Forms.TabPage();
//            this.tpCode = new System.Windows.Forms.TabPage();
//            this.cmbControls = new System.Windows.Forms.ComboBox();
//            this.tsmiDelete = new DevExpress.XtraBars.BarButtonItem();
//            this.tsmiSelectAll = new DevExpress.XtraBars.BarButtonItem();
//            this.tsmiRun = new DevExpress.XtraBars.BarButtonItem();
//            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
//            this.dockPanel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
//            this.dockPanel2.SuspendLayout();
//            this.dockPanel2_Container.SuspendLayout();
//            this.dockPanel3.SuspendLayout();
//            this.dockPanel3_Container.SuspendLayout();
//            this.panel1.SuspendLayout();
//            this.tabContent.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // dockManager1
//            // 
//            this.dockManager1.Form = this;
//            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
//            this.dockPanel1});
//            this.dockManager1.MenuManager = this.barManager1;
//            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
//            this.dockPanel2,
//            this.dockPanel3});
//            this.dockManager1.TopZIndexControls.AddRange(new string[] {
//            "DevExpress.XtraBars.BarDockControl",
//            "DevExpress.XtraBars.StandaloneBarDockControl",
//            "System.Windows.Forms.StatusBar",
//            "System.Windows.Forms.MenuStrip",
//            "System.Windows.Forms.StatusStrip",
//            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
//            "DevExpress.XtraBars.Ribbon.RibbonControl",
//            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
//            "DevExpress.XtraBars.Navigation.TileNavPane",
//            "DevExpress.XtraBars.TabFormControl"});
//            // 
//            // dockPanel1
//            // 
//            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
//            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
//            this.dockPanel1.ID = new System.Guid("0f8288bc-1e8b-420c-b3ff-8284874b0d8b");
//            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
//            this.dockPanel1.Name = "dockPanel1";
//            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
//            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Top;
//            this.dockPanel1.SavedIndex = 0;
//            this.dockPanel1.Size = new System.Drawing.Size(817, 200);
//            this.dockPanel1.Text = "dockPanel1";
//            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
//            // 
//            // dockPanel1_Container
//            // 
//            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
//            this.dockPanel1_Container.Name = "dockPanel1_Container";
//            this.dockPanel1_Container.Size = new System.Drawing.Size(809, 172);
//            this.dockPanel1_Container.TabIndex = 0;
//            // 
//            // barManager1
//            // 
//            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
//            this.bar2,
//            this.bar3});
//            this.barManager1.DockControls.Add(this.barDockControlTop);
//            this.barManager1.DockControls.Add(this.barDockControlBottom);
//            this.barManager1.DockControls.Add(this.barDockControlLeft);
//            this.barManager1.DockControls.Add(this.barDockControlRight);
//            this.barManager1.DockManager = this.dockManager1;
//            this.barManager1.Form = this;
//            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
//            this.tsmiDelete,
//            this.tsmiSelectAll,
//            this.tsmiRun});
//            this.barManager1.MainMenu = this.bar2;
//            this.barManager1.MaxItemId = 3;
//            this.barManager1.StatusBar = this.bar3;
//            // 
//            // bar2
//            // 
//            this.bar2.BarName = "Main menu";
//            this.bar2.DockCol = 0;
//            this.bar2.DockRow = 0;
//            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
//            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
//            new DevExpress.XtraBars.LinkPersistInfo(this.tsmiDelete),
//            new DevExpress.XtraBars.LinkPersistInfo(this.tsmiSelectAll),
//            new DevExpress.XtraBars.LinkPersistInfo(this.tsmiRun)});
//            this.bar2.OptionsBar.MultiLine = true;
//            this.bar2.OptionsBar.UseWholeRow = true;
//            this.bar2.Text = "Main menu";
//            // 
//            // bar3
//            // 
//            this.bar3.BarName = "Status bar";
//            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
//            this.bar3.DockCol = 0;
//            this.bar3.DockRow = 0;
//            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
//            this.bar3.OptionsBar.AllowQuickCustomization = false;
//            this.bar3.OptionsBar.DrawDragBorder = false;
//            this.bar3.OptionsBar.UseWholeRow = true;
//            this.bar3.Text = "Status bar";
//            // 
//            // barDockControlTop
//            // 
//            this.barDockControlTop.CausesValidation = false;
//            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
//            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
//            this.barDockControlTop.Manager = this.barManager1;
//            this.barDockControlTop.Size = new System.Drawing.Size(817, 24);
//            // 
//            // barDockControlBottom
//            // 
//            this.barDockControlBottom.CausesValidation = false;
//            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
//            this.barDockControlBottom.Location = new System.Drawing.Point(0, 583);
//            this.barDockControlBottom.Manager = this.barManager1;
//            this.barDockControlBottom.Size = new System.Drawing.Size(817, 23);
//            // 
//            // barDockControlLeft
//            // 
//            this.barDockControlLeft.CausesValidation = false;
//            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
//            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
//            this.barDockControlLeft.Manager = this.barManager1;
//            this.barDockControlLeft.Size = new System.Drawing.Size(0, 559);
//            // 
//            // barDockControlRight
//            // 
//            this.barDockControlRight.CausesValidation = false;
//            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
//            this.barDockControlRight.Location = new System.Drawing.Point(817, 24);
//            this.barDockControlRight.Manager = this.barManager1;
//            this.barDockControlRight.Size = new System.Drawing.Size(0, 559);
//            // 
//            // dockPanel2
//            // 
//            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
//            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
//            this.dockPanel2.ID = new System.Guid("0a825ef1-9baf-4244-98d8-e4f654bdfe23");
//            this.dockPanel2.Location = new System.Drawing.Point(0, 24);
//            this.dockPanel2.Name = "dockPanel2";
//            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
//            this.dockPanel2.Size = new System.Drawing.Size(200, 559);
//            this.dockPanel2.Text = "控件列表";
//            // 
//            // dockPanel2_Container
//            // 
//            this.dockPanel2_Container.Controls.Add(this.pnlToolBox);
//            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
//            this.dockPanel2_Container.Name = "dockPanel2_Container";
//            this.dockPanel2_Container.Size = new System.Drawing.Size(191, 532);
//            this.dockPanel2_Container.TabIndex = 0;
//            // 
//            // pnlToolBox
//            // 
//            this.pnlToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pnlToolBox.Location = new System.Drawing.Point(0, 0);
//            this.pnlToolBox.Name = "pnlToolBox";
//            this.pnlToolBox.Size = new System.Drawing.Size(191, 532);
//            this.pnlToolBox.TabIndex = 0;
//            // 
//            // dockPanel3
//            // 
//            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
//            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
//            this.dockPanel3.ID = new System.Guid("25bcb943-2406-4cd2-ac51-f51ff7ba3cf0");
//            this.dockPanel3.Location = new System.Drawing.Point(617, 24);
//            this.dockPanel3.Name = "dockPanel3";
//            this.dockPanel3.OriginalSize = new System.Drawing.Size(200, 200);
//            this.dockPanel3.Size = new System.Drawing.Size(200, 559);
//            this.dockPanel3.Text = "方法列表";
//            // 
//            // dockPanel3_Container
//            // 
//            this.dockPanel3_Container.Controls.Add(this.cmbControls);
//            this.dockPanel3_Container.Controls.Add(this.pnlPropertyGrid);
//            this.dockPanel3_Container.Location = new System.Drawing.Point(5, 23);
//            this.dockPanel3_Container.Name = "dockPanel3_Container";
//            this.dockPanel3_Container.Size = new System.Drawing.Size(191, 532);
//            this.dockPanel3_Container.TabIndex = 0;
//            // 
//            // pnlPropertyGrid
//            // 
//            this.pnlPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.pnlPropertyGrid.Location = new System.Drawing.Point(-3, 20);
//            this.pnlPropertyGrid.Name = "pnlPropertyGrid";
//            this.pnlPropertyGrid.Size = new System.Drawing.Size(192, 512);
//            this.pnlPropertyGrid.TabIndex = 0;
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.tabContent);
//            this.panel1.Location = new System.Drawing.Point(206, 20);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(411, 563);
//            this.panel1.TabIndex = 6;
//            // 
//            // tabContent
//            // 
//            this.tabContent.Alignment = System.Windows.Forms.TabAlignment.Bottom;
//            this.tabContent.Controls.Add(this.tpDesign);
//            this.tabContent.Controls.Add(this.tpCode);
//            this.tabContent.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.tabContent.Location = new System.Drawing.Point(0, 0);
//            this.tabContent.Name = "tabContent";
//            this.tabContent.SelectedIndex = 0;
//            this.tabContent.Size = new System.Drawing.Size(411, 563);
//            this.tabContent.TabIndex = 1;
//            // 
//            // tpDesign
//            // 
//            this.tpDesign.Location = new System.Drawing.Point(4, 4);
//            this.tpDesign.Name = "tpDesign";
//            this.tpDesign.Padding = new System.Windows.Forms.Padding(3);
//            this.tpDesign.Size = new System.Drawing.Size(403, 537);
//            this.tpDesign.TabIndex = 0;
//            this.tpDesign.Text = "Design";
//            this.tpDesign.UseVisualStyleBackColor = true;
//            // 
//            // tpCode
//            // 
//            this.tpCode.Location = new System.Drawing.Point(4, 4);
//            this.tpCode.Name = "tpCode";
//            this.tpCode.Padding = new System.Windows.Forms.Padding(3);
//            this.tpCode.Size = new System.Drawing.Size(248, 395);
//            this.tpCode.TabIndex = 1;
//            this.tpCode.Text = "Code";
//            this.tpCode.UseVisualStyleBackColor = true;
//            // 
//            // cmbControls
//            // 
//            this.cmbControls.Dock = System.Windows.Forms.DockStyle.Top;
//            this.cmbControls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbControls.FormattingEnabled = true;
//            this.cmbControls.Items.AddRange(new object[] {
//            "Form1 System.Windows.Forms"});
//            this.cmbControls.Location = new System.Drawing.Point(0, 0);
//            this.cmbControls.Name = "cmbControls";
//            this.cmbControls.Size = new System.Drawing.Size(191, 20);
//            this.cmbControls.TabIndex = 2;
//            // 
//            // tsmiDelete
//            // 
//            this.tsmiDelete.Caption = "tsmiDelete";
//            this.tsmiDelete.Id = 0;
//            this.tsmiDelete.Name = "tsmiDelete";
//            // 
//            // tsmiSelectAll
//            // 
//            this.tsmiSelectAll.Caption = "tsmiSelectAll";
//            this.tsmiSelectAll.Id = 1;
//            this.tsmiSelectAll.Name = "tsmiSelectAll";
//            // 
//            // tsmiRun
//            // 
//            this.tsmiRun.Caption = "tsmiRun";
//            this.tsmiRun.Id = 2;
//            this.tsmiRun.Name = "tsmiRun";
//            // 
//            // FrmDesigner
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(817, 606);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.dockPanel3);
//            this.Controls.Add(this.dockPanel2);
//            this.Controls.Add(this.barDockControlLeft);
//            this.Controls.Add(this.barDockControlRight);
//            this.Controls.Add(this.barDockControlBottom);
//            this.Controls.Add(this.barDockControlTop);
//            this.Name = "FrmDesigner";
//            this.Text = "FrmDesigner";
//            this.Load += new System.EventHandler(this.FrmDesigner_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
//            this.dockPanel1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
//            this.dockPanel2.ResumeLayout(false);
//            this.dockPanel2_Container.ResumeLayout(false);
//            this.dockPanel3.ResumeLayout(false);
//            this.dockPanel3_Container.ResumeLayout(false);
//            this.panel1.ResumeLayout(false);
//            this.tabContent.ResumeLayout(false);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private DevExpress.XtraBars.Docking.DockManager dockManager1;
//        private System.Windows.Forms.Panel panel1;
//        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
//        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
//        private System.Windows.Forms.Panel pnlPropertyGrid;
//        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
//        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
//        private System.Windows.Forms.Panel pnlToolBox;
//        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
//        private DevExpress.XtraBars.BarManager barManager1;
//        private DevExpress.XtraBars.Bar bar2;
//        private DevExpress.XtraBars.Bar bar3;
//        private DevExpress.XtraBars.BarDockControl barDockControlTop;
//        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
//        private DevExpress.XtraBars.BarDockControl barDockControlRight;
//        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
//        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
//        private System.Windows.Forms.TabControl tabContent;
//        private System.Windows.Forms.TabPage tpDesign;
//        private System.Windows.Forms.TabPage tpCode;
//        private System.Windows.Forms.ComboBox cmbControls;
//        private DevExpress.XtraBars.BarButtonItem tsmiDelete;
//        private DevExpress.XtraBars.BarButtonItem tsmiSelectAll;
//        private DevExpress.XtraBars.BarButtonItem tsmiRun;
//    }
//}