
namespace WorkTest.TestMicrobe
{
    partial class FrmTestMicrobe
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
            this.GVAntibiotic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.aid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.antibioticNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.antibioticNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.amic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.akb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.methodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.aqualitative = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVItemInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEresultType = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.itemResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RTEitemResult = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RTEsort = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.reportState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BTGroup = new DevExpress.XtraBars.BarButtonItem();
            this.BTAddAntibiotic = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelAntibiotic = new DevExpress.XtraBars.BarButtonItem();
            this.BTTest = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.GVAntibiotic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVItemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEresultType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEitemResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEsort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // GVAntibiotic
            // 
            this.GVAntibiotic.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.aid,
            this.antibioticNo,
            this.antibioticNames,
            this.amic,
            this.akb,
            this.methodName,
            this.aqualitative,
            this.remark});
            this.GVAntibiotic.DetailHeight = 525;
            this.GVAntibiotic.FixedLineWidth = 3;
            this.GVAntibiotic.GridControl = this.GCInfo;
            this.GVAntibiotic.Name = "GVAntibiotic";
            this.GVAntibiotic.OptionsView.ShowGroupPanel = false;
            this.GVAntibiotic.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // aid
            // 
            this.aid.Caption = "id";
            this.aid.FieldName = "id";
            this.aid.MinWidth = 26;
            this.aid.Name = "aid";
            this.aid.Width = 99;
            // 
            // antibioticNo
            // 
            this.antibioticNo.Caption = "编号";
            this.antibioticNo.FieldName = "antibioticNo";
            this.antibioticNo.MinWidth = 26;
            this.antibioticNo.Name = "antibioticNo";
            this.antibioticNo.Visible = true;
            this.antibioticNo.VisibleIndex = 0;
            this.antibioticNo.Width = 99;
            // 
            // antibioticNames
            // 
            this.antibioticNames.Caption = "抗生素名称";
            this.antibioticNames.FieldName = "antibioticNames";
            this.antibioticNames.MinWidth = 26;
            this.antibioticNames.Name = "antibioticNames";
            this.antibioticNames.Visible = true;
            this.antibioticNames.VisibleIndex = 1;
            this.antibioticNames.Width = 99;
            // 
            // amic
            // 
            this.amic.Caption = "定量(MIC值)";
            this.amic.FieldName = "micValue";
            this.amic.MinWidth = 26;
            this.amic.Name = "amic";
            this.amic.Visible = true;
            this.amic.VisibleIndex = 2;
            this.amic.Width = 99;
            // 
            // akb
            // 
            this.akb.Caption = "K-B值";
            this.akb.FieldName = "kbValue";
            this.akb.MinWidth = 26;
            this.akb.Name = "akb";
            this.akb.Visible = true;
            this.akb.VisibleIndex = 3;
            this.akb.Width = 99;
            // 
            // methodName
            // 
            this.methodName.Caption = "方法";
            this.methodName.FieldName = "methodName";
            this.methodName.MinWidth = 26;
            this.methodName.Name = "methodName";
            this.methodName.Visible = true;
            this.methodName.VisibleIndex = 4;
            this.methodName.Width = 99;
            // 
            // aqualitative
            // 
            this.aqualitative.Caption = "定性";
            this.aqualitative.FieldName = "qualitative";
            this.aqualitative.MinWidth = 26;
            this.aqualitative.Name = "aqualitative";
            this.aqualitative.Visible = true;
            this.aqualitative.VisibleIndex = 5;
            this.aqualitative.Width = 99;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.MinWidth = 26;
            this.remark.Name = "remark";
            this.remark.Visible = true;
            this.remark.VisibleIndex = 6;
            this.remark.Width = 99;
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCInfo.Location = new System.Drawing.Point(0, 30);
            this.GCInfo.MainView = this.GVItemInfo;
            this.GCInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEresultType,
            this.RTEitemResult,
            this.RTEsort});
            this.GCInfo.Size = new System.Drawing.Size(943, 826);
            this.GCInfo.TabIndex = 4;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVItemInfo,
            this.GVAntibiotic});
            // 
            // GVItemInfo
            // 
            this.GVItemInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.itemCodes,
            this.itemNames,
            this.resultType,
            this.itemResult,
            this.itemRemark,
            this.sort,
            this.reportState});
            this.GVItemInfo.DetailHeight = 525;
            this.GVItemInfo.FixedLineWidth = 3;
            this.GVItemInfo.GridControl = this.GCInfo;
            this.GVItemInfo.Name = "GVItemInfo";
            this.GVItemInfo.OptionsDetail.AllowZoomDetail = false;
            this.GVItemInfo.OptionsDetail.ShowDetailTabs = false;
            this.GVItemInfo.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.True;
            this.GVItemInfo.OptionsDetail.SmartDetailHeight = true;
            this.GVItemInfo.OptionsView.ShowGroupPanel = false;
            this.GVItemInfo.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.GVItemInfo_MasterRowExpanded);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 26;
            this.id.Name = "id";
            this.id.Width = 99;
            // 
            // itemCodes
            // 
            this.itemCodes.Caption = "编号";
            this.itemCodes.FieldName = "itemCodes";
            this.itemCodes.MinWidth = 26;
            this.itemCodes.Name = "itemCodes";
            this.itemCodes.OptionsColumn.AllowFocus = false;
            this.itemCodes.Visible = true;
            this.itemCodes.VisibleIndex = 0;
            this.itemCodes.Width = 87;
            // 
            // itemNames
            // 
            this.itemNames.Caption = "项目名称";
            this.itemNames.FieldName = "itemNames";
            this.itemNames.MinWidth = 26;
            this.itemNames.Name = "itemNames";
            this.itemNames.OptionsColumn.AllowFocus = false;
            this.itemNames.Visible = true;
            this.itemNames.VisibleIndex = 1;
            this.itemNames.Width = 209;
            // 
            // resultType
            // 
            this.resultType.Caption = "结果类型";
            this.resultType.ColumnEdit = this.RGEresultType;
            this.resultType.FieldName = "resultType";
            this.resultType.MinWidth = 114;
            this.resultType.Name = "resultType";
            this.resultType.Visible = true;
            this.resultType.VisibleIndex = 2;
            this.resultType.Width = 209;
            // 
            // RGEresultType
            // 
            this.RGEresultType.AutoHeight = false;
            this.RGEresultType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEresultType.Name = "RGEresultType";
            this.RGEresultType.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.RGEresultType.EditValueChanged += new System.EventHandler(this.RGEresultType_EditValueChanged);
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 450;
            this.repositoryItemGridLookUpEdit1View.FixedLineWidth = 3;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "结果";
            this.itemResult.ColumnEdit = this.RTEitemResult;
            this.itemResult.FieldName = "itemResult";
            this.itemResult.MinWidth = 171;
            this.itemResult.Name = "itemResult";
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 3;
            this.itemResult.Width = 209;
            // 
            // RTEitemResult
            // 
            this.RTEitemResult.AutoHeight = false;
            this.RTEitemResult.Name = "RTEitemResult";
            this.RTEitemResult.DoubleClick += new System.EventHandler(this.RTEitemResult_DoubleClick);
            // 
            // itemRemark
            // 
            this.itemRemark.Caption = "备注";
            this.itemRemark.FieldName = "itemRemark";
            this.itemRemark.MinWidth = 171;
            this.itemRemark.Name = "itemRemark";
            this.itemRemark.Visible = true;
            this.itemRemark.VisibleIndex = 4;
            this.itemRemark.Width = 272;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.ColumnEdit = this.RTEsort;
            this.sort.FieldName = "itemSort";
            this.sort.MaxWidth = 47;
            this.sort.MinWidth = 26;
            this.sort.Name = "sort";
            this.sort.Visible = true;
            this.sort.VisibleIndex = 5;
            this.sort.Width = 47;
            // 
            // RTEsort
            // 
            this.RTEsort.AutoHeight = false;
            this.RTEsort.Name = "RTEsort";
            // 
            // reportState
            // 
            this.reportState.Caption = "报告";
            this.reportState.FieldName = "reportState";
            this.reportState.MaxWidth = 40;
            this.reportState.MinWidth = 23;
            this.reportState.Name = "reportState";
            this.reportState.Visible = true;
            this.reportState.VisibleIndex = 6;
            this.reportState.Width = 40;
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
            this.BTAdd,
            this.BTDelete,
            this.BTGroup,
            this.BTAddAntibiotic,
            this.BTDelAntibiotic,
            this.BTTest});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAddAntibiotic, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelAntibiotic, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTTest, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "增加项目";
            this.BTAdd.Id = 0;
            this.BTAdd.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.add_16x16;
            this.BTAdd.ImageOptions.LargeImage = global::WorkTest.TestMicrobe.Properties.Resources.add_32x32;
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // BTDelete
            // 
            this.BTDelete.Caption = "移除项目";
            this.BTDelete.Id = 1;
            this.BTDelete.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.close_16x16;
            this.BTDelete.ImageOptions.LargeImage = global::WorkTest.TestMicrobe.Properties.Resources.close_32x32;
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelete_ItemClick);
            // 
            // BTGroup
            // 
            this.BTGroup.Caption = "增加抗生素组合";
            this.BTGroup.Id = 2;
            this.BTGroup.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.group_16x16;
            this.BTGroup.ImageOptions.LargeImage = global::WorkTest.TestMicrobe.Properties.Resources.group_32x32;
            this.BTGroup.Name = "BTGroup";
            this.BTGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTGroup_ItemClick);
            // 
            // BTAddAntibiotic
            // 
            this.BTAddAntibiotic.Caption = "增加抗生素";
            this.BTAddAntibiotic.Id = 3;
            this.BTAddAntibiotic.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.additem_16x16;
            this.BTAddAntibiotic.ImageOptions.LargeImage = global::WorkTest.TestMicrobe.Properties.Resources.additem_32x32;
            this.BTAddAntibiotic.Name = "BTAddAntibiotic";
            this.BTAddAntibiotic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAddAntibiotic_ItemClick);
            // 
            // BTDelAntibiotic
            // 
            this.BTDelAntibiotic.Caption = "移除抗生素";
            this.BTDelAntibiotic.Id = 4;
            this.BTDelAntibiotic.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.deletelist2_16x16;
            this.BTDelAntibiotic.ImageOptions.LargeImage = global::WorkTest.TestMicrobe.Properties.Resources.deletelist2_32x32;
            this.BTDelAntibiotic.Name = "BTDelAntibiotic";
            this.BTDelAntibiotic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelAntibiotic_ItemClick);
            // 
            // BTTest
            // 
            this.BTTest.Caption = "测试";
            this.BTTest.Id = 5;
            this.BTTest.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.clear_16x16;
            this.BTTest.ImageOptions.LargeImage = global::WorkTest.TestMicrobe.Properties.Resources.clear_32x32;
            this.BTTest.Name = "BTTest";
            this.BTTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTTest_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(943, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 856);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(943, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 826);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(943, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 826);
            // 
            // FrmTestMicrobe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 856);
            this.Controls.Add(this.GCInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmTestMicrobe";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmTestMicrobe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GVAntibiotic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVItemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEresultType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEitemResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTEsort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVItemInfo;
        private DevExpress.XtraBars.BarButtonItem BTAdd;
        private DevExpress.XtraBars.BarButtonItem BTDelete;
        private DevExpress.XtraBars.BarButtonItem BTGroup;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn itemCodes;
        private DevExpress.XtraGrid.Columns.GridColumn itemNames;
        private DevExpress.XtraGrid.Columns.GridColumn resultType;
        private DevExpress.XtraGrid.Columns.GridColumn itemResult;
        private DevExpress.XtraGrid.Columns.GridColumn itemRemark;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraBars.BarButtonItem BTAddAntibiotic;
        private DevExpress.XtraBars.BarButtonItem BTDelAntibiotic;
        private DevExpress.XtraGrid.Views.Grid.GridView GVAntibiotic;
        private DevExpress.XtraGrid.Columns.GridColumn antibioticNo;
        private DevExpress.XtraGrid.Columns.GridColumn antibioticNames;
        private DevExpress.XtraGrid.Columns.GridColumn amic;
        private DevExpress.XtraGrid.Columns.GridColumn akb;
        private DevExpress.XtraGrid.Columns.GridColumn methodName;
        private DevExpress.XtraGrid.Columns.GridColumn aqualitative;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn aid;
        private DevExpress.XtraGrid.Columns.GridColumn reportState;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEresultType;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RTEitemResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit RTEsort;
        private DevExpress.XtraBars.BarButtonItem BTTest;
    }
}