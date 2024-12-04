
namespace WorkQC.ItemInfo
{
    partial class FrmEditResults
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTClear = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemNOs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEitemNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.itemResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultRule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zVlaue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gradeid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEgradeid = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEitemNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgradeid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
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
            this.BTSave,
            this.BTClear});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTClear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 0;
            this.BTSave.ImageOptions.Image = global::WorkQC.ItemInfo.Properties.Resources.apply_16x1610;
            this.BTSave.ImageOptions.LargeImage = global::WorkQC.ItemInfo.Properties.Resources.apply_32x326;
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTClear
            // 
            this.BTClear.Caption = "取消";
            this.BTClear.Id = 1;
            this.BTClear.ImageOptions.Image = global::WorkQC.ItemInfo.Properties.Resources.cancel_16x169;
            this.BTClear.ImageOptions.LargeImage = global::WorkQC.ItemInfo.Properties.Resources.cancel_32x325;
            this.BTClear.Name = "BTClear";
            this.BTClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTClear_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1151, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 542);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1151, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 518);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1151, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 518);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEgradeid,
            this.RGEitemNO,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1151, 518);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.itemNOs,
            this.itemResult,
            this.resultType,
            this.sort,
            this.resultRule,
            this.zVlaue,
            this.state,
            this.gradeid,
            this.qcTime,
            this.gridColumn1});
            this.gridView1.DetailHeight = 408;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // id
            // 
            this.id.Caption = "编号";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            // 
            // itemNOs
            // 
            this.itemNOs.Caption = "项目名称";
            this.itemNOs.ColumnEdit = this.RGEitemNO;
            this.itemNOs.FieldName = "itemNO";
            this.itemNOs.MinWidth = 23;
            this.itemNOs.Name = "itemNOs";
            this.itemNOs.OptionsColumn.AllowFocus = false;
            this.itemNOs.Visible = true;
            this.itemNOs.VisibleIndex = 0;
            this.itemNOs.Width = 87;
            // 
            // RGEitemNO
            // 
            this.RGEitemNO.AutoHeight = false;
            this.RGEitemNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEitemNO.Name = "RGEitemNO";
            this.RGEitemNO.PopupView = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 408;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "项目结果";
            this.itemResult.FieldName = "itemResult";
            this.itemResult.MinWidth = 23;
            this.itemResult.Name = "itemResult";
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 3;
            this.itemResult.Width = 87;
            // 
            // resultType
            // 
            this.resultType.Caption = "结果类型";
            this.resultType.FieldName = "resultType";
            this.resultType.MaxWidth = 60;
            this.resultType.MinWidth = 23;
            this.resultType.Name = "resultType";
            this.resultType.OptionsColumn.AllowFocus = false;
            this.resultType.Visible = true;
            this.resultType.VisibleIndex = 5;
            this.resultType.Width = 60;
            // 
            // sort
            // 
            this.sort.Caption = "次数";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 41;
            this.sort.MinWidth = 23;
            this.sort.Name = "sort";
            this.sort.OptionsColumn.AllowFocus = false;
            this.sort.Visible = true;
            this.sort.VisibleIndex = 2;
            this.sort.Width = 41;
            // 
            // resultRule
            // 
            this.resultRule.Caption = "违反规则";
            this.resultRule.FieldName = "resultRule";
            this.resultRule.MinWidth = 23;
            this.resultRule.Name = "resultRule";
            this.resultRule.OptionsColumn.AllowFocus = false;
            this.resultRule.Visible = true;
            this.resultRule.VisibleIndex = 6;
            this.resultRule.Width = 87;
            // 
            // zVlaue
            // 
            this.zVlaue.Caption = "Z分数值";
            this.zVlaue.FieldName = "zVlaue";
            this.zVlaue.MinWidth = 23;
            this.zVlaue.Name = "zVlaue";
            this.zVlaue.OptionsColumn.AllowFocus = false;
            this.zVlaue.Visible = true;
            this.zVlaue.VisibleIndex = 4;
            this.zVlaue.Width = 87;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 41;
            this.state.MinWidth = 23;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 9;
            this.state.Width = 41;
            // 
            // gradeid
            // 
            this.gradeid.Caption = "质控品类型";
            this.gradeid.ColumnEdit = this.RGEgradeid;
            this.gradeid.FieldName = "planGradeid";
            this.gradeid.MinWidth = 23;
            this.gradeid.Name = "gradeid";
            this.gradeid.OptionsColumn.AllowFocus = false;
            this.gradeid.Visible = true;
            this.gradeid.VisibleIndex = 1;
            this.gradeid.Width = 87;
            // 
            // RGEgradeid
            // 
            this.RGEgradeid.AutoHeight = false;
            this.RGEgradeid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgradeid.Name = "RGEgradeid";
            this.RGEgradeid.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 408;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // qcTime
            // 
            this.qcTime.Caption = "质控时间";
            this.qcTime.ColumnEdit = this.repositoryItemDateEdit1;
            this.qcTime.FieldName = "qcTime";
            this.qcTime.MinWidth = 23;
            this.qcTime.Name = "qcTime";
            this.qcTime.Visible = true;
            this.qcTime.VisibleIndex = 7;
            this.qcTime.Width = 87;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "g";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "g";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "g";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "备注";
            this.gridColumn1.FieldName = "remark";
            this.gridColumn1.MaxWidth = 300;
            this.gridColumn1.MinWidth = 200;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 200;
            // 
            // FrmEditResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 542);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = global::WorkQC.ItemInfo.Properties.Resources.new3;
            this.Name = "FrmEditResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑质控结果";
            this.Load += new System.EventHandler(this.FrmEditResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEitemNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgradeid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTClear;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn itemNOs;
        private DevExpress.XtraGrid.Columns.GridColumn itemResult;
        private DevExpress.XtraGrid.Columns.GridColumn resultType;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraGrid.Columns.GridColumn resultRule;
        private DevExpress.XtraGrid.Columns.GridColumn zVlaue;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn gradeid;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEitemNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgradeid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn qcTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
    }
}