namespace Common.CreateReport
{
    partial class FrmReportHandle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportHandle));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.NBReportBind = new DevExpress.XtraNavBar.NavBarItem();
            this.NBReportEdit = new DevExpress.XtraNavBar.NavBarItem();
            this.NBReportTest = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(933, 525);
            this.splitContainerControl1.SplitterPosition = 267;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.NBReportBind,
            this.NBReportEdit,
            this.navBarItem4,
            this.NBReportTest});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 267;
            this.navBarControl1.Size = new System.Drawing.Size(267, 525);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "报表设置";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarGroup1.ImageOptions.SvgImage")));
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.NBReportBind),
            new DevExpress.XtraNavBar.NavBarItemLink(this.NBReportEdit),
            new DevExpress.XtraNavBar.NavBarItemLink(this.NBReportTest)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // NBReportBind
            // 
            this.NBReportBind.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.NBReportBind.Appearance.Options.UseFont = true;
            this.NBReportBind.Caption = "项目报表绑定";
            this.NBReportBind.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NBReportBind.ImageOptions.SvgImage")));
            this.NBReportBind.Name = "NBReportBind";
            // 
            // NBReportEdit
            // 
            this.NBReportEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.NBReportEdit.Appearance.Options.UseFont = true;
            this.NBReportEdit.Caption = "数据绑定编辑";
            this.NBReportEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NBReportEdit.ImageOptions.SvgImage")));
            this.NBReportEdit.Name = "NBReportEdit";
            // 
            // NBReportTest
            // 
            this.NBReportTest.Caption = "ReportTest";
            this.NBReportTest.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NBReportTest.ImageOptions.SvgImage")));
            this.NBReportTest.Name = "NBReportTest";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "报告生成器";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarGroup2.ImageOptions.SvgImage")));
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.navBarItem4.Appearance.Options.UseFont = true;
            this.navBarItem4.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 11F);
            this.navBarItem4.AppearanceDisabled.Options.UseFont = true;
            this.navBarItem4.Caption = "自动生成报告";
            this.navBarItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItem4.ImageOptions.SvgImage")));
            this.navBarItem4.Name = "navBarItem4";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 525);
            this.panel1.TabIndex = 0;
            // 
            // FrmReportHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmReportHandle";
            this.Text = "报表编辑器";
            this.Load += new System.EventHandler(this.FrmReportHandle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem NBReportBind;
        private DevExpress.XtraNavBar.NavBarItem NBReportEdit;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraNavBar.NavBarItem NBReportTest;
    }
}