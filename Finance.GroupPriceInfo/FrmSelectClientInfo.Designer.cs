
namespace Finance.GroupPriceInfo
{
    partial class FrmSelectClientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectClientInfo));
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
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clientTypeNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEclientTypeNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.personNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEpersonNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chargeLevelNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEchargeLevelNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.province = new DevExpress.XtraGrid.Columns.GridColumn();
            this.city = new DevExpress.XtraGrid.Columns.GridColumn();
            this.area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEclientTypeNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEpersonNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEchargeLevelNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.BTok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTok.ImageOptions.Image")));
            this.BTok.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTok.ImageOptions.LargeImage")));
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
            this.barDockControlTop.Size = new System.Drawing.Size(911, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 550);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(911, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 526);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(911, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 526);
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(0, 24);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEclientTypeNO,
            this.RGEchargeLevelNO,
            this.RGEpersonNO});
            this.GCInfo.Size = new System.Drawing.Size(911, 526);
            this.GCInfo.TabIndex = 4;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.no,
            this.names,
            this.shortNames,
            this.customCode,
            this.clientTypeNO,
            this.personNO,
            this.chargeLevelNO,
            this.province,
            this.city,
            this.area,
            this.state});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.Click += new System.EventHandler(this.GVInfo_Click);
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
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 100;
            this.no.MinWidth = 40;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 1;
            this.no.Width = 40;
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
            this.names.Width = 89;
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
            this.shortNames.Width = 89;
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
            this.customCode.Width = 89;
            // 
            // clientTypeNO
            // 
            this.clientTypeNO.Caption = "客户类型";
            this.clientTypeNO.ColumnEdit = this.RGEclientTypeNO;
            this.clientTypeNO.FieldName = "clientTypeNO";
            this.clientTypeNO.MaxWidth = 75;
            this.clientTypeNO.MinWidth = 50;
            this.clientTypeNO.Name = "clientTypeNO";
            this.clientTypeNO.OptionsColumn.AllowFocus = false;
            this.clientTypeNO.Visible = true;
            this.clientTypeNO.VisibleIndex = 6;
            // 
            // RGEclientTypeNO
            // 
            this.RGEclientTypeNO.AutoHeight = false;
            this.RGEclientTypeNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEclientTypeNO.Name = "RGEclientTypeNO";
            this.RGEclientTypeNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // personNO
            // 
            this.personNO.Caption = "负责人";
            this.personNO.ColumnEdit = this.RGEpersonNO;
            this.personNO.FieldName = "personNO";
            this.personNO.MaxWidth = 80;
            this.personNO.MinWidth = 60;
            this.personNO.Name = "personNO";
            this.personNO.OptionsColumn.AllowFocus = false;
            this.personNO.Visible = true;
            this.personNO.VisibleIndex = 5;
            this.personNO.Width = 60;
            // 
            // RGEpersonNO
            // 
            this.RGEpersonNO.AutoHeight = false;
            this.RGEpersonNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEpersonNO.Name = "RGEpersonNO";
            this.RGEpersonNO.PopupView = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // chargeLevelNO
            // 
            this.chargeLevelNO.Caption = "客户等级";
            this.chargeLevelNO.ColumnEdit = this.RGEchargeLevelNO;
            this.chargeLevelNO.FieldName = "chargeLevelNO";
            this.chargeLevelNO.MaxWidth = 75;
            this.chargeLevelNO.MinWidth = 50;
            this.chargeLevelNO.Name = "chargeLevelNO";
            this.chargeLevelNO.OptionsColumn.AllowFocus = false;
            this.chargeLevelNO.Visible = true;
            this.chargeLevelNO.VisibleIndex = 7;
            // 
            // RGEchargeLevelNO
            // 
            this.RGEchargeLevelNO.AutoHeight = false;
            this.RGEchargeLevelNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEchargeLevelNO.Name = "RGEchargeLevelNO";
            this.RGEchargeLevelNO.PopupView = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // province
            // 
            this.province.Caption = "所属省";
            this.province.FieldName = "province";
            this.province.MaxWidth = 100;
            this.province.MinWidth = 40;
            this.province.Name = "province";
            this.province.OptionsColumn.AllowFocus = false;
            this.province.Visible = true;
            this.province.VisibleIndex = 8;
            this.province.Width = 100;
            // 
            // city
            // 
            this.city.Caption = "所属市";
            this.city.FieldName = "city";
            this.city.MaxWidth = 100;
            this.city.MinWidth = 40;
            this.city.Name = "city";
            this.city.OptionsColumn.AllowFocus = false;
            this.city.Visible = true;
            this.city.VisibleIndex = 9;
            this.city.Width = 76;
            // 
            // area
            // 
            this.area.Caption = "所属区";
            this.area.FieldName = "area";
            this.area.MaxWidth = 100;
            this.area.MinWidth = 40;
            this.area.Name = "area";
            this.area.OptionsColumn.AllowFocus = false;
            this.area.Visible = true;
            this.area.VisibleIndex = 10;
            this.area.Width = 92;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 35;
            this.state.MinWidth = 35;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 11;
            this.state.Width = 35;
            // 
            // FrmSelectClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 550);
            this.Controls.Add(this.GCInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmSelectClientInfo.IconOptions.LargeImage")));
            this.Name = "FrmSelectClientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询条件选择";
            this.Load += new System.EventHandler(this.FrmSelectInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEclientTypeNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEpersonNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEchargeLevelNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn clientTypeNO;
        private DevExpress.XtraGrid.Columns.GridColumn personNO;
        private DevExpress.XtraGrid.Columns.GridColumn chargeLevelNO;
        private DevExpress.XtraGrid.Columns.GridColumn province;
        private DevExpress.XtraGrid.Columns.GridColumn city;
        private DevExpress.XtraGrid.Columns.GridColumn area;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEclientTypeNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEpersonNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEchargeLevelNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}