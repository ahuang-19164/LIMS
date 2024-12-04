
namespace WorkQC.ItemInfo
{
    partial class FrmgradeShow
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
            this.GCgradeInfo = new DevExpress.XtraGrid.GridControl();
            this.GVgradeInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ids = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.namess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNamess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.level = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGElevelNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.validityTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.produceTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.producer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.states = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.GCgradeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVgradeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGElevelNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // GCgradeInfo
            // 
            this.GCgradeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCgradeInfo.Location = new System.Drawing.Point(0, 24);
            this.GCgradeInfo.MainView = this.GVgradeInfo;
            this.GCgradeInfo.Name = "GCgradeInfo";
            this.GCgradeInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGElevelNO});
            this.GCgradeInfo.Size = new System.Drawing.Size(1009, 563);
            this.GCgradeInfo.TabIndex = 4;
            this.GCgradeInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVgradeInfo});
            // 
            // GVgradeInfo
            // 
            this.GVgradeInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ids,
            this.check,
            this.nos,
            this.namess,
            this.shortNamess,
            this.customCodes,
            this.nameEn,
            this.level,
            this.validityTime,
            this.produceTime,
            this.producer,
            this.gridColumn1,
            this.gridColumn2,
            this.states});
            this.GVgradeInfo.GridControl = this.GCgradeInfo;
            this.GVgradeInfo.Name = "GVgradeInfo";
            this.GVgradeInfo.OptionsView.ShowGroupPanel = false;
            // 
            // ids
            // 
            this.ids.Caption = "id";
            this.ids.FieldName = "id";
            this.ids.Name = "ids";
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
            // nos
            // 
            this.nos.Caption = "编号";
            this.nos.FieldName = "no";
            this.nos.MaxWidth = 75;
            this.nos.Name = "nos";
            this.nos.OptionsColumn.AllowFocus = false;
            this.nos.Visible = true;
            this.nos.VisibleIndex = 1;
            this.nos.Width = 32;
            // 
            // namess
            // 
            this.namess.Caption = "质控品批号";
            this.namess.FieldName = "names";
            this.namess.Name = "namess";
            this.namess.OptionsColumn.AllowFocus = false;
            this.namess.Visible = true;
            this.namess.VisibleIndex = 2;
            this.namess.Width = 73;
            // 
            // shortNamess
            // 
            this.shortNamess.Caption = "质控品名称";
            this.shortNamess.FieldName = "shortNames";
            this.shortNamess.Name = "shortNamess";
            this.shortNamess.OptionsColumn.AllowFocus = false;
            this.shortNamess.Visible = true;
            this.shortNamess.VisibleIndex = 3;
            this.shortNamess.Width = 73;
            // 
            // customCodes
            // 
            this.customCodes.Caption = "质控品编号";
            this.customCodes.FieldName = "customCode";
            this.customCodes.Name = "customCodes";
            this.customCodes.OptionsColumn.AllowFocus = false;
            this.customCodes.Visible = true;
            this.customCodes.VisibleIndex = 4;
            this.customCodes.Width = 73;
            // 
            // nameEn
            // 
            this.nameEn.Caption = "英文名称";
            this.nameEn.FieldName = "nameEn";
            this.nameEn.Name = "nameEn";
            this.nameEn.OptionsColumn.AllowFocus = false;
            this.nameEn.Visible = true;
            this.nameEn.VisibleIndex = 5;
            this.nameEn.Width = 73;
            // 
            // level
            // 
            this.level.Caption = "水平类型";
            this.level.ColumnEdit = this.RGElevelNO;
            this.level.FieldName = "levelNO";
            this.level.Name = "level";
            this.level.OptionsColumn.AllowFocus = false;
            this.level.Visible = true;
            this.level.VisibleIndex = 7;
            this.level.Width = 73;
            // 
            // RGElevelNO
            // 
            this.RGElevelNO.AutoHeight = false;
            this.RGElevelNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGElevelNO.Name = "RGElevelNO";
            this.RGElevelNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // validityTime
            // 
            this.validityTime.Caption = "有效期";
            this.validityTime.FieldName = "validityTime";
            this.validityTime.Name = "validityTime";
            this.validityTime.OptionsColumn.AllowFocus = false;
            this.validityTime.Visible = true;
            this.validityTime.VisibleIndex = 8;
            this.validityTime.Width = 73;
            // 
            // produceTime
            // 
            this.produceTime.Caption = "生产日期";
            this.produceTime.FieldName = "produceTime";
            this.produceTime.Name = "produceTime";
            this.produceTime.OptionsColumn.AllowFocus = false;
            this.produceTime.Visible = true;
            this.produceTime.VisibleIndex = 9;
            this.produceTime.Width = 73;
            // 
            // producer
            // 
            this.producer.Caption = "生产厂家";
            this.producer.FieldName = "producer";
            this.producer.Name = "producer";
            this.producer.OptionsColumn.AllowFocus = false;
            this.producer.Visible = true;
            this.producer.VisibleIndex = 6;
            this.producer.Width = 73;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "排序";
            this.gridColumn1.FieldName = "sort";
            this.gridColumn1.MaxWidth = 35;
            this.gridColumn1.MinWidth = 35;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 11;
            this.gridColumn1.Width = 35;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "备注";
            this.gridColumn2.FieldName = "remark";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            this.gridColumn2.Width = 83;
            // 
            // states
            // 
            this.states.Caption = "状态";
            this.states.FieldName = "state";
            this.states.MaxWidth = 35;
            this.states.MinWidth = 35;
            this.states.Name = "states";
            this.states.OptionsColumn.AllowFocus = false;
            this.states.Width = 35;
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
            this.BTSave,
            this.BTClose});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTSave
            // 
            this.BTSave.Caption = "确定";
            this.BTSave.Id = 0;
            this.BTSave.ImageOptions.Image = global::WorkQC.ItemInfo.Properties.Resources.apply_16x165;
            this.BTSave.ImageOptions.LargeImage = global::WorkQC.ItemInfo.Properties.Resources.apply_32x323;
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTClose
            // 
            this.BTClose.Caption = "取消";
            this.BTClose.Id = 1;
            this.BTClose.ImageOptions.Image = global::WorkQC.ItemInfo.Properties.Resources.cancel_16x167;
            this.BTClose.ImageOptions.LargeImage = global::WorkQC.ItemInfo.Properties.Resources.cancel_32x324;
            this.BTClose.Name = "BTClose";
            this.BTClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1009, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 587);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1009, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1009, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
            // 
            // FrmgradeShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 587);
            this.Controls.Add(this.GCgradeInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = global::WorkQC.ItemInfo.Properties.Resources.new1;
            this.Name = "FrmgradeShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控品选择";
            ((System.ComponentModel.ISupportInitialize)(this.GCgradeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVgradeInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGElevelNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl GCgradeInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVgradeInfo;
        private DevExpress.XtraGrid.Columns.GridColumn ids;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraGrid.Columns.GridColumn nos;
        private DevExpress.XtraGrid.Columns.GridColumn namess;
        private DevExpress.XtraGrid.Columns.GridColumn shortNamess;
        private DevExpress.XtraGrid.Columns.GridColumn customCodes;
        private DevExpress.XtraGrid.Columns.GridColumn nameEn;
        private DevExpress.XtraGrid.Columns.GridColumn level;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGElevelNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn validityTime;
        private DevExpress.XtraGrid.Columns.GridColumn produceTime;
        private DevExpress.XtraGrid.Columns.GridColumn producer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn states;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}