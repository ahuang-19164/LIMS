
namespace Common.SelectTool
{
    partial class FrmSelectOtherInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectOtherInfo));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.CEcheckAll = new DevExpress.XtraBars.BarCheckItem();
            this.BTok = new DevExpress.XtraBars.BarButtonItem();
            this.BTclose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GCContextMexnustrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BTBestColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.BToutExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            this.GCContextMexnustrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
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
            this.BTok,
            this.CEcheckAll,
            this.BTclose});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.CEcheckAll),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTok, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTclose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // CEcheckAll
            // 
            this.CEcheckAll.Caption = "全选";
            this.CEcheckAll.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.CEcheckAll.Id = 1;
            this.CEcheckAll.Name = "CEcheckAll";
            this.CEcheckAll.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.CEcheckAll_CheckedChanged);
            // 
            // BTok
            // 
            this.BTok.Caption = "确定";
            this.BTok.Id = 0;
            this.BTok.ImageOptions.Image = global::Common.SelectTool.Properties.Resources.apply_16x16;
            this.BTok.ImageOptions.LargeImage = global::Common.SelectTool.Properties.Resources.apply_32x32;
            this.BTok.Name = "BTok";
            this.BTok.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTok_ItemClick);
            // 
            // BTclose
            // 
            this.BTclose.Caption = "取消";
            this.BTclose.Id = 2;
            this.BTclose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTclose.ImageOptions.Image")));
            this.BTclose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTclose.ImageOptions.LargeImage")));
            this.BTclose.Name = "BTclose";
            this.BTclose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTclose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(660, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 515);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(660, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 491);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(660, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 491);
            // 
            // GCInfo
            // 
            this.GCInfo.ContextMenuStrip = this.GCContextMexnustrip;
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(0, 24);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.Size = new System.Drawing.Size(660, 491);
            this.GCInfo.TabIndex = 4;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GCContextMexnustrip
            // 
            this.GCContextMexnustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTBestColumns,
            this.BToutExcel});
            this.GCContextMexnustrip.Name = "GCContextMexnustrip";
            this.GCContextMexnustrip.Size = new System.Drawing.Size(154, 48);
            // 
            // BTBestColumns
            // 
            this.BTBestColumns.Name = "BTBestColumns";
            this.BTBestColumns.Size = new System.Drawing.Size(153, 22);
            this.BTBestColumns.Text = "自动调整列宽";
            // 
            // BToutExcel
            // 
            this.BToutExcel.Name = "BToutExcel";
            this.BToutExcel.Size = new System.Drawing.Size(153, 22);
            this.BToutExcel.Text = "导出Excel文件";
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.no,
            this.names,
            this.shortNames,
            this.customCode});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.Click += new System.EventHandler(this.GVInfo_Click);
            // 
            // check
            // 
            this.check.Caption = "选择";
            this.check.FieldName = "check";
            this.check.MaxWidth = 41;
            this.check.MinWidth = 41;
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 41;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 100;
            this.no.MinWidth = 23;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 1;
            this.no.Width = 87;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 23;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 2;
            this.names.Width = 87;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "简称";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.MinWidth = 23;
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 3;
            this.shortNames.Width = 87;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定编码";
            this.customCode.FieldName = "customCode";
            this.customCode.MinWidth = 23;
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Visible = true;
            this.customCode.VisibleIndex = 4;
            this.customCode.Width = 87;
            // 
            // FrmSelectOtherInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 515);
            this.Controls.Add(this.GCInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmSelectOtherInfo.IconOptions.LargeImage")));
            this.Name = "FrmSelectOtherInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询条件选择";
            this.Load += new System.EventHandler(this.FrmSelectInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            this.GCContextMexnustrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTok;
        private DevExpress.XtraBars.BarCheckItem CEcheckAll;
        private DevExpress.XtraBars.BarButtonItem BTclose;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private System.Windows.Forms.ContextMenuStrip GCContextMexnustrip;
        private System.Windows.Forms.ToolStripMenuItem BTBestColumns;
        private System.Windows.Forms.ToolStripMenuItem BToutExcel;
    }
}