namespace Perwork.SampleInfos
{
    partial class FrmItemInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemInfo));
            this.GCTestInfo = new DevExpress.XtraGrid.GridControl();
            this.GVTestInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEgroupNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.disNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleTypeNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEsampleTypeNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.methodNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEmethodNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.instrumentNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEinstrumentNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.GCTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEsampleTypeNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEinstrumentNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // GCTestInfo
            // 
            this.GCTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCTestInfo.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCTestInfo.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCTestInfo.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCTestInfo.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCTestInfo.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCTestInfo.Location = new System.Drawing.Point(0, 0);
            this.GCTestInfo.MainView = this.GVTestInfo;
            this.GCTestInfo.Name = "GCTestInfo";
            this.GCTestInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemGridLookUpEdit1,
            this.RGEgroupNO,
            this.RGEmethodNO,
            this.RGEinstrumentNO,
            this.RGEsampleTypeNO});
            this.GCTestInfo.Size = new System.Drawing.Size(933, 525);
            this.GCTestInfo.TabIndex = 5;
            this.GCTestInfo.UseEmbeddedNavigator = true;
            this.GCTestInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVTestInfo});
            // 
            // GVTestInfo
            // 
            this.GVTestInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.groupNO,
            this.names,
            this.disNames,
            this.shortNames,
            this.sampleTypeNO,
            this.methodNO,
            this.instrumentNO,
            this.state});
            this.GVTestInfo.DetailHeight = 476;
            this.GVTestInfo.GridControl = this.GCTestInfo;
            this.GVTestInfo.Name = "GVTestInfo";
            this.GVTestInfo.OptionsFind.AlwaysVisible = true;
            this.GVTestInfo.OptionsFind.ShowCloseButton = false;
            this.GVTestInfo.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 27;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Width = 101;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 58;
            this.no.MinWidth = 58;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 58;
            // 
            // groupNO
            // 
            this.groupNO.Caption = "专业组";
            this.groupNO.ColumnEdit = this.RGEgroupNO;
            this.groupNO.FieldName = "groupNO";
            this.groupNO.MinWidth = 27;
            this.groupNO.Name = "groupNO";
            this.groupNO.OptionsColumn.AllowFocus = false;
            this.groupNO.Visible = true;
            this.groupNO.VisibleIndex = 2;
            this.groupNO.Width = 101;
            // 
            // RGEgroupNO
            // 
            this.RGEgroupNO.AutoHeight = false;
            this.RGEgroupNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgroupNO.Name = "RGEgroupNO";
            this.RGEgroupNO.PopupView = this.repositoryItemGridLookUpEdit3View;
            // 
            // repositoryItemGridLookUpEdit3View
            // 
            this.repositoryItemGridLookUpEdit3View.DetailHeight = 476;
            this.repositoryItemGridLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit3View.Name = "repositoryItemGridLookUpEdit3View";
            this.repositoryItemGridLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // names
            // 
            this.names.Caption = "项目名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 27;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            this.names.Width = 120;
            // 
            // disNames
            // 
            this.disNames.Caption = "项目别名";
            this.disNames.FieldName = "disNames";
            this.disNames.MinWidth = 27;
            this.disNames.Name = "disNames";
            this.disNames.OptionsColumn.AllowFocus = false;
            this.disNames.Width = 89;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "拼音简拼";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.MinWidth = 27;
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 3;
            this.shortNames.Width = 101;
            // 
            // sampleTypeNO
            // 
            this.sampleTypeNO.Caption = "标本类型";
            this.sampleTypeNO.ColumnEdit = this.RGEsampleTypeNO;
            this.sampleTypeNO.FieldName = "sampleTypeNO";
            this.sampleTypeNO.MinWidth = 27;
            this.sampleTypeNO.Name = "sampleTypeNO";
            this.sampleTypeNO.OptionsColumn.AllowFocus = false;
            this.sampleTypeNO.Visible = true;
            this.sampleTypeNO.VisibleIndex = 4;
            this.sampleTypeNO.Width = 89;
            // 
            // RGEsampleTypeNO
            // 
            this.RGEsampleTypeNO.AutoHeight = false;
            this.RGEsampleTypeNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEsampleTypeNO.Name = "RGEsampleTypeNO";
            this.RGEsampleTypeNO.PopupView = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 408;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // methodNO
            // 
            this.methodNO.Caption = "实验方法";
            this.methodNO.ColumnEdit = this.RGEmethodNO;
            this.methodNO.FieldName = "methodNO";
            this.methodNO.MinWidth = 27;
            this.methodNO.Name = "methodNO";
            this.methodNO.OptionsColumn.AllowFocus = false;
            this.methodNO.Visible = true;
            this.methodNO.VisibleIndex = 5;
            this.methodNO.Width = 101;
            // 
            // RGEmethodNO
            // 
            this.RGEmethodNO.AutoHeight = false;
            this.RGEmethodNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEmethodNO.Name = "RGEmethodNO";
            this.RGEmethodNO.PopupView = this.gridView10;
            // 
            // gridView10
            // 
            this.gridView10.DetailHeight = 476;
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.OptionsView.ShowGroupPanel = false;
            // 
            // instrumentNO
            // 
            this.instrumentNO.Caption = "检测仪器";
            this.instrumentNO.ColumnEdit = this.RGEinstrumentNO;
            this.instrumentNO.FieldName = "instrumentNO";
            this.instrumentNO.MinWidth = 27;
            this.instrumentNO.Name = "instrumentNO";
            this.instrumentNO.OptionsColumn.AllowFocus = false;
            this.instrumentNO.Visible = true;
            this.instrumentNO.VisibleIndex = 6;
            this.instrumentNO.Width = 101;
            // 
            // RGEinstrumentNO
            // 
            this.RGEinstrumentNO.AutoHeight = false;
            this.RGEinstrumentNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEinstrumentNO.Name = "RGEinstrumentNO";
            this.RGEinstrumentNO.PopupView = this.gridView11;
            // 
            // gridView11
            // 
            this.gridView11.DetailHeight = 476;
            this.gridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView11.Name = "gridView11";
            this.gridView11.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView11.OptionsView.ShowGroupPanel = false;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 58;
            this.state.MinWidth = 58;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 7;
            this.state.Width = 58;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("no", "no"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("names", "名称")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 476;
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // FrmItemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.GCTestInfo);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FrmItemInfo.IconOptions.LargeImage")));
            this.Name = "FrmItemInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验项目信息列表";
            this.Load += new System.EventHandler(this.FrmItemInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEsampleTypeNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEinstrumentNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCTestInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVTestInfo;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn groupNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgroupNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit3View;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn disNames;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn sampleTypeNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEsampleTypeNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn methodNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEmethodNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn instrumentNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEinstrumentNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
    }
}