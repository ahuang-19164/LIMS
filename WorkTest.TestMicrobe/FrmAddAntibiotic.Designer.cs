
namespace WorkTest.TestMicrobe
{
    partial class FrmAddAntibiotic
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.BTClose = new DevExpress.XtraEditors.SimpleButton();
            this.BTOK = new DevExpress.XtraEditors.SimpleButton();
            this.GCInfos = new DevExpress.XtraGrid.GridControl();
            this.GVInfos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.namesEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.channel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.smearValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.micValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kbValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.methodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.aqualitative = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.RGEgroupCode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.BTClose);
            this.layoutControl1.Controls.Add(this.BTOK);
            this.layoutControl1.Controls.Add(this.GCInfos);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(961, 603);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // BTClose
            // 
            this.BTClose.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.cancel_16x162;
            this.BTClose.Location = new System.Drawing.Point(846, 569);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(103, 22);
            this.BTClose.StyleController = this.layoutControl1;
            this.BTClose.TabIndex = 6;
            this.BTClose.Text = "取消";
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // BTOK
            // 
            this.BTOK.ImageOptions.Image = global::WorkTest.TestMicrobe.Properties.Resources.apply_16x162;
            this.BTOK.Location = new System.Drawing.Point(672, 569);
            this.BTOK.Name = "BTOK";
            this.BTOK.Size = new System.Drawing.Size(108, 22);
            this.BTOK.StyleController = this.layoutControl1;
            this.BTOK.TabIndex = 5;
            this.BTOK.Text = "确定";
            this.BTOK.Click += new System.EventHandler(this.BTOK_Click);
            // 
            // GCInfos
            // 
            this.GCInfos.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.GCInfos.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.GCInfos.Location = new System.Drawing.Point(12, 12);
            this.GCInfos.MainView = this.GVInfos;
            this.GCInfos.Name = "GCInfos";
            this.GCInfos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1,
            this.repositoryItemCheckEdit1,
            this.RGEgroupCode});
            this.GCInfos.Size = new System.Drawing.Size(937, 553);
            this.GCInfos.TabIndex = 4;
            this.GCInfos.UseEmbeddedNavigator = true;
            this.GCInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfos});
            // 
            // GVInfos
            // 
            this.GVInfos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.check,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.namesEn,
            this.channel,
            this.smearValue,
            this.remark,
            this.gridColumn6,
            this.gridColumn7,
            this.micValue,
            this.kbValue,
            this.itemResult,
            this.methodName,
            this.aqualitative});
            this.GVInfos.DetailHeight = 408;
            this.GVInfos.GridControl = this.GCInfos;
            this.GVInfos.Name = "GVInfos";
            this.GVInfos.OptionsFind.ShowCloseButton = false;
            this.GVInfos.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "id";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 87;
            // 
            // check
            // 
            this.check.Caption = "选择";
            this.check.FieldName = "check";
            this.check.MaxWidth = 35;
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 35;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "编号";
            this.gridColumn2.FieldName = "no";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 65;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "名称";
            this.gridColumn3.FieldName = "names";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 90;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "拼音简拼";
            this.gridColumn4.FieldName = "shortNames";
            this.gridColumn4.MinWidth = 23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 125;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "自定编码";
            this.gridColumn5.FieldName = "customCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // namesEn
            // 
            this.namesEn.Caption = "英文名称";
            this.namesEn.FieldName = "namesEn";
            this.namesEn.Name = "namesEn";
            this.namesEn.OptionsColumn.AllowFocus = false;
            this.namesEn.Visible = true;
            this.namesEn.VisibleIndex = 5;
            // 
            // channel
            // 
            this.channel.Caption = "通道号";
            this.channel.FieldName = "channel";
            this.channel.Name = "channel";
            this.channel.OptionsColumn.AllowFocus = false;
            this.channel.Visible = true;
            this.channel.VisibleIndex = 6;
            // 
            // smearValue
            // 
            this.smearValue.Caption = "说明信息";
            this.smearValue.FieldName = "value";
            this.smearValue.Name = "smearValue";
            this.smearValue.OptionsColumn.AllowFocus = false;
            this.smearValue.Visible = true;
            this.smearValue.VisibleIndex = 12;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowFocus = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 13;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "排序";
            this.gridColumn6.FieldName = "sort";
            this.gridColumn6.MaxWidth = 35;
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 14;
            this.gridColumn6.Width = 35;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "状态";
            this.gridColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn7.FieldName = "state";
            this.gridColumn7.MaxWidth = 35;
            this.gridColumn7.MinWidth = 23;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 15;
            this.gridColumn7.Width = 35;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // micValue
            // 
            this.micValue.Caption = "默认MIC";
            this.micValue.FieldName = "micValue";
            this.micValue.Name = "micValue";
            this.micValue.Visible = true;
            this.micValue.VisibleIndex = 7;
            // 
            // kbValue
            // 
            this.kbValue.Caption = "默认K-B";
            this.kbValue.FieldName = "kbValue";
            this.kbValue.Name = "kbValue";
            this.kbValue.Visible = true;
            this.kbValue.VisibleIndex = 8;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "默认结果";
            this.itemResult.FieldName = "itemResult";
            this.itemResult.Name = "itemResult";
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 9;
            // 
            // methodName
            // 
            this.methodName.Caption = "默认方法";
            this.methodName.FieldName = "methodName";
            this.methodName.Name = "methodName";
            this.methodName.Visible = true;
            this.methodName.VisibleIndex = 10;
            // 
            // aqualitative
            // 
            this.aqualitative.Caption = "默认定性";
            this.aqualitative.FieldName = "aqualitative";
            this.aqualitative.Name = "aqualitative";
            this.aqualitative.Visible = true;
            this.aqualitative.VisibleIndex = 11;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.StoreColorAsInteger = true;
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
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(961, 603);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GCInfos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(941, 557);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.BTOK;
            this.layoutControlItem2.Location = new System.Drawing.Point(660, 557);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(112, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BTClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(834, 557);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(107, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 557);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(660, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(772, 557);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(62, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FrmAddAntibiotic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 603);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmAddAntibiotic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抗生素列表";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEgroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton BTClose;
        private DevExpress.XtraEditors.SimpleButton BTOK;
        private DevExpress.XtraGrid.GridControl GCInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn namesEn;
        private DevExpress.XtraGrid.Columns.GridColumn channel;
        private DevExpress.XtraGrid.Columns.GridColumn smearValue;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn micValue;
        private DevExpress.XtraGrid.Columns.GridColumn kbValue;
        private DevExpress.XtraGrid.Columns.GridColumn itemResult;
        private DevExpress.XtraGrid.Columns.GridColumn methodName;
        private DevExpress.XtraGrid.Columns.GridColumn aqualitative;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEgroupCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}