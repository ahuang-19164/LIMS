
namespace WorkTest.TestMicrobe
{
    partial class FrmResultType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResultType));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.GCInfos = new DevExpress.XtraGrid.GridControl();
            this.GVInfos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEgroupCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.smearValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.BTClose = new DevExpress.XtraEditors.SimpleButton();
            this.BTOK = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GCInfos);
            this.layoutControl1.Controls.Add(this.BTClose);
            this.layoutControl1.Controls.Add(this.BTOK);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(830, 648);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // GCInfos
            // 
            this.GCInfos.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfos.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCInfos.Location = new System.Drawing.Point(12, 12);
            this.GCInfos.MainView = this.GVInfos;
            this.GCInfos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GCInfos.Name = "GCInfos";
            this.GCInfos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1,
            this.repositoryItemCheckEdit1,
            this.RGEgroupCode});
            this.GCInfos.Size = new System.Drawing.Size(806, 593);
            this.GCInfos.TabIndex = 7;
            this.GCInfos.UseEmbeddedNavigator = true;
            this.GCInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfos});
            // 
            // GVInfos
            // 
            this.GVInfos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.names,
            this.ShortNames,
            this.customCode,
            this.groupNO,
            this.smearValue,
            this.remark,
            this.sort,
            this.state});
            this.GVInfos.DetailHeight = 525;
            this.GVInfos.FixedLineWidth = 3;
            this.GVInfos.GridControl = this.GCInfos;
            this.GVInfos.Name = "GVInfos";
            this.GVInfos.OptionsFind.AllowFindPanel = false;
            this.GVInfos.OptionsFind.AlwaysVisible = true;
            this.GVInfos.OptionsFind.ShowCloseButton = false;
            this.GVInfos.OptionsView.ShowGroupPanel = false;
            this.GVInfos.DoubleClick += new System.EventHandler(this.GVInfos_DoubleClick);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.MinWidth = 26;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Width = 99;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MinWidth = 26;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 87;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.MinWidth = 26;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            this.names.Width = 127;
            // 
            // ShortNames
            // 
            this.ShortNames.Caption = "拼音简拼";
            this.ShortNames.FieldName = "shortNames";
            this.ShortNames.MinWidth = 26;
            this.ShortNames.Name = "ShortNames";
            this.ShortNames.OptionsColumn.AllowFocus = false;
            this.ShortNames.Visible = true;
            this.ShortNames.VisibleIndex = 2;
            this.ShortNames.Width = 72;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定编码";
            this.customCode.FieldName = "customCode";
            this.customCode.MinWidth = 23;
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Visible = true;
            this.customCode.VisibleIndex = 3;
            this.customCode.Width = 122;
            // 
            // groupNO
            // 
            this.groupNO.Caption = "项目名称";
            this.groupNO.ColumnEdit = this.RGEgroupCode;
            this.groupNO.FieldName = "groupCode";
            this.groupNO.MinWidth = 26;
            this.groupNO.Name = "groupNO";
            this.groupNO.OptionsColumn.AllowFocus = false;
            this.groupNO.Width = 198;
            // 
            // RGEgroupCode
            // 
            this.RGEgroupCode.AutoHeight = false;
            this.RGEgroupCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEgroupCode.Name = "RGEgroupCode";
            this.RGEgroupCode.PopupView = this.repositoryItemGridLookUpEdit1View;
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
            // smearValue
            // 
            this.smearValue.Caption = "结果信息";
            this.smearValue.FieldName = "value";
            this.smearValue.MinWidth = 23;
            this.smearValue.Name = "smearValue";
            this.smearValue.OptionsColumn.AllowFocus = false;
            this.smearValue.Visible = true;
            this.smearValue.VisibleIndex = 4;
            this.smearValue.Width = 201;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.MinWidth = 23;
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowFocus = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 5;
            this.remark.Width = 112;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 40;
            this.sort.MinWidth = 26;
            this.sort.Name = "sort";
            this.sort.OptionsColumn.AllowFocus = false;
            this.sort.Visible = true;
            this.sort.VisibleIndex = 6;
            this.sort.Width = 27;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.ColumnEdit = this.repositoryItemCheckEdit1;
            this.state.FieldName = "state";
            this.state.MaxWidth = 40;
            this.state.MinWidth = 26;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 7;
            this.state.Width = 28;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.StoreColorAsInteger = true;
            // 
            // BTClose
            // 
            this.BTClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTClose.ImageOptions.Image")));
            this.BTClose.Location = new System.Drawing.Point(720, 609);
            this.BTClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(98, 27);
            this.BTClose.StyleController = this.layoutControl1;
            this.BTClose.TabIndex = 6;
            this.BTClose.Text = "取消";
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // BTOK
            // 
            this.BTOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTOK.ImageOptions.Image")));
            this.BTOK.Location = new System.Drawing.Point(608, 609);
            this.BTOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTOK.Name = "BTOK";
            this.BTOK.Size = new System.Drawing.Size(98, 27);
            this.BTOK.StyleController = this.layoutControl1;
            this.BTOK.TabIndex = 5;
            this.BTOK.Text = "确定";
            this.BTOK.Click += new System.EventHandler(this.BTOK_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(830, 648);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BTOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(596, 597);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(102, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BTClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(708, 597);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(102, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(698, 597);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 31);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 597);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(596, 31);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GCInfos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(810, 597);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmResultType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 648);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmResultType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结果";
            this.Load += new System.EventHandler(this.FrmResultType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton BTClose;
        private DevExpress.XtraEditors.SimpleButton BTOK;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl GCInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfos;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn ShortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private DevExpress.XtraGrid.Columns.GridColumn groupNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgroupCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn smearValue;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}