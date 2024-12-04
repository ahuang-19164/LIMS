namespace Perwork.SampleInfos
{
    partial class FrmImportConfigInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportConfigInfo));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BTEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.excelCellNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.defaultValues = new DevExpress.XtraGrid.Columns.GridColumn();
            this.isNull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
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
            this.BTAdd,
            this.BTEdit,
            this.BTSave,
            this.BTDelete});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAdd, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTEdit, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelete, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "新增";
            this.BTAdd.Id = 1;
            this.BTAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.Image")));
            this.BTAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.LargeImage")));
            this.BTAdd.Name = "BTAdd";
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑";
            this.BTEdit.Id = 2;
            this.BTEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.Image")));
            this.BTEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTEdit.ImageOptions.LargeImage")));
            this.BTEdit.Name = "BTEdit";
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 3;
            this.BTSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.Image")));
            this.BTSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.LargeImage")));
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTDelete
            // 
            this.BTDelete.Caption = "删除";
            this.BTDelete.Id = 4;
            this.BTDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTDelete.ImageOptions.Image")));
            this.BTDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTDelete.ImageOptions.LargeImage")));
            this.BTDelete.Name = "BTDelete";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(772, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 665);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(772, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 641);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(772, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 641);
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(772, 641);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tableNames,
            this.columnNames,
            this.excelCellNames,
            this.defaultValues,
            this.isNull,
            this.state,
            this.sort});
            this.gridView1.DetailHeight = 408;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // tableNames
            // 
            this.tableNames.Caption = "表名";
            this.tableNames.FieldName = "tableNames";
            this.tableNames.MinWidth = 23;
            this.tableNames.Name = "tableNames";
            this.tableNames.OptionsColumn.AllowFocus = false;
            this.tableNames.Width = 87;
            // 
            // columnNames
            // 
            this.columnNames.Caption = "字段名称";
            this.columnNames.FieldName = "columnNames";
            this.columnNames.MinWidth = 23;
            this.columnNames.Name = "columnNames";
            this.columnNames.OptionsColumn.AllowFocus = false;
            this.columnNames.Visible = true;
            this.columnNames.VisibleIndex = 0;
            this.columnNames.Width = 87;
            // 
            // excelCellNames
            // 
            this.excelCellNames.Caption = "对应Excel列名";
            this.excelCellNames.FieldName = "excelCellNames";
            this.excelCellNames.MinWidth = 23;
            this.excelCellNames.Name = "excelCellNames";
            this.excelCellNames.Visible = true;
            this.excelCellNames.VisibleIndex = 1;
            this.excelCellNames.Width = 87;
            // 
            // defaultValues
            // 
            this.defaultValues.Caption = "默认值";
            this.defaultValues.FieldName = "defaultValues";
            this.defaultValues.MinWidth = 23;
            this.defaultValues.Name = "defaultValues";
            this.defaultValues.Visible = true;
            this.defaultValues.VisibleIndex = 2;
            this.defaultValues.Width = 87;
            // 
            // isNull
            // 
            this.isNull.Caption = "非空";
            this.isNull.FieldName = "isNull";
            this.isNull.MaxWidth = 50;
            this.isNull.MinWidth = 50;
            this.isNull.Name = "isNull";
            this.isNull.Visible = true;
            this.isNull.VisibleIndex = 3;
            this.isNull.Width = 50;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 50;
            this.state.MinWidth = 50;
            this.state.Name = "state";
            this.state.Visible = true;
            this.state.VisibleIndex = 4;
            this.state.Width = 50;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 50;
            this.sort.MinWidth = 50;
            this.sort.Name = "sort";
            this.sort.Visible = true;
            this.sort.VisibleIndex = 5;
            this.sort.Width = 50;
            // 
            // FrmImportConfigInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 665);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FrmImportConfigInfo.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmImportConfigInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel对应关系设置";
            this.Load += new System.EventHandler(this.FrmImportConfigInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem BTAdd;
        private DevExpress.XtraBars.BarButtonItem BTEdit;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.BarButtonItem BTDelete;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn tableNames;
        private DevExpress.XtraGrid.Columns.GridColumn columnNames;
        private DevExpress.XtraGrid.Columns.GridColumn excelCellNames;
        private DevExpress.XtraGrid.Columns.GridColumn defaultValues;
#pragma warning disable CS0169 // 从不使用字段“FrmImportConfigInfo.State”
        private DevExpress.XtraGrid.Columns.GridColumn State;
#pragma warning restore CS0169 // 从不使用字段“FrmImportConfigInfo.State”
        private DevExpress.XtraGrid.Columns.GridColumn isNull;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
    }
}