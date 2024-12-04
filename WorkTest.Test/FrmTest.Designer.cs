namespace WorkTest.Test
{
    partial class FrmTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GCTestInfo = new DevExpress.XtraGrid.GridControl();
            this.GVTestInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.flag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemResultLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.methodNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEmethodNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.methodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemSort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reportState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.resultTypeNO = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GCTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // GCTestInfo
            // 
            this.GCTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCTestInfo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCTestInfo.Location = new System.Drawing.Point(0, 0);
            this.GCTestInfo.MainView = this.GVTestInfo;
            this.GCTestInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCTestInfo.Name = "GCTestInfo";
            this.GCTestInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.RGEmethodNO});
            this.GCTestInfo.Size = new System.Drawing.Size(1066, 675);
            this.GCTestInfo.TabIndex = 0;
            this.GCTestInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVTestInfo});
            // 
            // GVTestInfo
            // 
            this.GVTestInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.groupCode,
            this.groupName,
            this.itemCodes,
            this.itemNames,
            this.itemResult,
            this.flag,
            this.unit,
            this.itemReference,
            this.itemResultLog,
            this.methodNO,
            this.methodName,
            this.itemSort,
            this.reportState,
            this.resultTypeNO});
            this.GVTestInfo.DetailHeight = 525;
            this.GVTestInfo.FixedLineWidth = 3;
            this.GVTestInfo.GridControl = this.GCTestInfo;
            this.GVTestInfo.Name = "GVTestInfo";
            this.GVTestInfo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GVTestInfo_RowClick);
            this.GVTestInfo.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GVTestInfo_CellValueChanged);
            // 
            // id
            // 
            this.id.Caption = "ID";
            this.id.FieldName = "id";
            this.id.MinWidth = 26;
            this.id.Name = "id";
            this.id.Width = 99;
            // 
            // groupCode
            // 
            this.groupCode.Caption = "组合编号";
            this.groupCode.FieldName = "groupCode";
            this.groupCode.MaxWidth = 70;
            this.groupCode.MinWidth = 70;
            this.groupCode.Name = "groupCode";
            this.groupCode.OptionsColumn.AllowFocus = false;
            this.groupCode.Width = 70;
            // 
            // groupName
            // 
            this.groupName.Caption = "组合名称";
            this.groupName.FieldName = "groupName";
            this.groupName.MinWidth = 26;
            this.groupName.Name = "groupName";
            this.groupName.OptionsColumn.AllowFocus = false;
            this.groupName.Width = 105;
            // 
            // itemCodes
            // 
            this.itemCodes.Caption = "项目编号";
            this.itemCodes.FieldName = "itemCodes";
            this.itemCodes.MaxWidth = 70;
            this.itemCodes.MinWidth = 70;
            this.itemCodes.Name = "itemCodes";
            this.itemCodes.OptionsColumn.AllowFocus = false;
            this.itemCodes.Visible = true;
            this.itemCodes.VisibleIndex = 0;
            this.itemCodes.Width = 70;
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
            this.itemNames.Width = 247;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "结果";
            this.itemResult.FieldName = "itemResult";
            this.itemResult.MinWidth = 100;
            this.itemResult.Name = "itemResult";
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 2;
            this.itemResult.Width = 134;
            // 
            // flag
            // 
            this.flag.Caption = "标记";
            this.flag.FieldName = "flag";
            this.flag.MaxWidth = 40;
            this.flag.MinWidth = 40;
            this.flag.Name = "flag";
            this.flag.OptionsColumn.AllowFocus = false;
            this.flag.Visible = true;
            this.flag.VisibleIndex = 3;
            this.flag.Width = 40;
            // 
            // unit
            // 
            this.unit.Caption = "单位";
            this.unit.FieldName = "unit";
            this.unit.MaxWidth = 100;
            this.unit.MinWidth = 66;
            this.unit.Name = "unit";
            this.unit.OptionsColumn.AllowFocus = false;
            this.unit.Visible = true;
            this.unit.VisibleIndex = 4;
            this.unit.Width = 66;
            // 
            // itemReference
            // 
            this.itemReference.Caption = "参考值";
            this.itemReference.FieldName = "valueDescribe";
            this.itemReference.MinWidth = 100;
            this.itemReference.Name = "itemReference";
            this.itemReference.OptionsColumn.AllowFocus = false;
            this.itemReference.Visible = true;
            this.itemReference.VisibleIndex = 5;
            this.itemReference.Width = 134;
            // 
            // itemResultLog
            // 
            this.itemResultLog.Caption = "历史结果";
            this.itemResultLog.FieldName = "itemResultLog";
            this.itemResultLog.MaxWidth = 200;
            this.itemResultLog.MinWidth = 10;
            this.itemResultLog.Name = "itemResultLog";
            this.itemResultLog.OptionsColumn.AllowFocus = false;
            this.itemResultLog.Visible = true;
            this.itemResultLog.VisibleIndex = 6;
            this.itemResultLog.Width = 134;
            // 
            // methodNO
            // 
            this.methodNO.Caption = "实验方法";
            this.methodNO.ColumnEdit = this.RGEmethodNO;
            this.methodNO.FieldName = "methodName";
            this.methodNO.MinWidth = 26;
            this.methodNO.Name = "methodNO";
            this.methodNO.Width = 185;
            // 
            // RGEmethodNO
            // 
            this.RGEmethodNO.AutoHeight = false;
            this.RGEmethodNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEmethodNO.Name = "RGEmethodNO";
            this.RGEmethodNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 525;
            this.repositoryItemGridLookUpEdit1View.FixedLineWidth = 3;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // methodName
            // 
            this.methodName.Caption = "实验方法";
            this.methodName.FieldName = "methodName";
            this.methodName.MaxWidth = 200;
            this.methodName.MinWidth = 10;
            this.methodName.Name = "methodName";
            this.methodName.OptionsColumn.AllowFocus = false;
            this.methodName.Visible = true;
            this.methodName.VisibleIndex = 7;
            this.methodName.Width = 134;
            // 
            // itemSort
            // 
            this.itemSort.Caption = "排序";
            this.itemSort.FieldName = "itemSort";
            this.itemSort.MaxWidth = 40;
            this.itemSort.MinWidth = 40;
            this.itemSort.Name = "itemSort";
            this.itemSort.OptionsColumn.AllowIncrementalSearch = false;
            this.itemSort.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.itemSort.OptionsEditForm.UseEditorColRowSpan = false;
            this.itemSort.Visible = true;
            this.itemSort.VisibleIndex = 8;
            this.itemSort.Width = 40;
            // 
            // reportState
            // 
            this.reportState.Caption = "报告";
            this.reportState.ColumnEdit = this.repositoryItemCheckEdit1;
            this.reportState.FieldName = "reportState";
            this.reportState.MaxWidth = 40;
            this.reportState.MinWidth = 40;
            this.reportState.Name = "reportState";
            this.reportState.Visible = true;
            this.reportState.VisibleIndex = 9;
            this.reportState.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // resultTypeNO
            // 
            this.resultTypeNO.Caption = "结果类型";
            this.resultTypeNO.FieldName = "resultTypeNO";
            this.resultTypeNO.MinWidth = 26;
            this.resultTypeNO.Name = "resultTypeNO";
            this.resultTypeNO.Width = 99;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 675);
            this.Controls.Add(this.GCTestInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCTestInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVTestInfo;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn groupCode;
        private DevExpress.XtraGrid.Columns.GridColumn groupName;
        private DevExpress.XtraGrid.Columns.GridColumn itemCodes;
        private DevExpress.XtraGrid.Columns.GridColumn itemNames;
        private DevExpress.XtraGrid.Columns.GridColumn itemResult;
        private DevExpress.XtraGrid.Columns.GridColumn flag;
        private DevExpress.XtraGrid.Columns.GridColumn unit;
        private DevExpress.XtraGrid.Columns.GridColumn itemReference;
        private DevExpress.XtraGrid.Columns.GridColumn itemResultLog;
        private DevExpress.XtraGrid.Columns.GridColumn methodName;
        private DevExpress.XtraGrid.Columns.GridColumn reportState;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn resultTypeNO;
        private DevExpress.XtraGrid.Columns.GridColumn methodNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEmethodNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn itemSort;
    }
}

