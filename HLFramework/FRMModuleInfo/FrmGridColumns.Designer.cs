namespace HLFramework
{
    partial class FrmGridColumns
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
            this.BTExpand = new DevExpress.XtraBars.BarButtonItem();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BTEdit = new DevExpress.XtraBars.BarButtonItem();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ControlNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ControlName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ControlType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ColumnFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnBandTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnBandNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnAllFocus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.State = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
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
            this.BTDelete,
            this.BTExpand});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTExpand, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTExpand
            // 
            this.BTExpand.Caption = "展开全部";
            this.BTExpand.Id = 4;
            this.BTExpand.ImageOptions.Image = global::HLFramework.Properties.Resources.group_16x16;
            this.BTExpand.ImageOptions.LargeImage = global::HLFramework.Properties.Resources.group_32x32;
            this.BTExpand.Name = "BTExpand";
            this.BTExpand.Tag = "0";
            this.BTExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTExpand_ItemClick);
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "新增";
            this.BTAdd.Id = 0;
            this.BTAdd.ImageOptions.Image = global::HLFramework.Properties.Resources.add_16x161;
            this.BTAdd.ImageOptions.LargeImage = global::HLFramework.Properties.Resources.add_32x321;
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.Tag = "100601";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // BTEdit
            // 
            this.BTEdit.Caption = "编辑";
            this.BTEdit.Id = 1;
            this.BTEdit.ImageOptions.Image = global::HLFramework.Properties.Resources.addfile_16x161;
            this.BTEdit.ImageOptions.LargeImage = global::HLFramework.Properties.Resources.addfile_32x321;
            this.BTEdit.Name = "BTEdit";
            this.BTEdit.Tag = "100602";
            this.BTEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTEdit_ItemClick);
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 2;
            this.BTSave.ImageOptions.Image = global::HLFramework.Properties.Resources.apply_16x161;
            this.BTSave.ImageOptions.LargeImage = global::HLFramework.Properties.Resources.apply_32x321;
            this.BTSave.Name = "BTSave";
            this.BTSave.Tag = "100603";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // BTDelete
            // 
            this.BTDelete.Caption = "删除";
            this.BTDelete.Id = 3;
            this.BTDelete.ImageOptions.Image = global::HLFramework.Properties.Resources.cancel_16x161;
            this.BTDelete.ImageOptions.LargeImage = global::HLFramework.Properties.Resources.cancel_32x321;
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.Tag = "100604";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1051, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 556);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1051, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 532);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1051, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 532);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 532);
            this.panel1.TabIndex = 14;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.gridControl1.Size = new System.Drawing.Size(1051, 532);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.ControlNO,
            this.ControlName,
            this.ControlType,
            this.ColumnName,
            this.ColumnType,
            this.ColumnFileName,
            this.ColumnCaption,
            this.ColumnBandTable,
            this.ColumnBandNO,
            this.ColumnVisible,
            this.ColumnEnable,
            this.ColumnAllFocus,
            this.State,
            this.Sort});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ControlName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // ID
            // 
            this.ID.Caption = "id";
            this.ID.FieldName = "id";
            this.ID.Name = "id";
            // 
            // ControlNO
            // 
            this.ControlNO.Caption = "编号";
            this.ControlNO.FieldName = "ControlNO";
            this.ControlNO.Name = "ControlNO";
            this.ControlNO.Visible = true;
            this.ControlNO.VisibleIndex = 0;
            // 
            // ControlName
            // 
            this.ControlName.Caption = "名称";
            this.ControlName.FieldName = "ControlName";
            this.ControlName.Name = "ControlName";
            this.ControlName.Visible = true;
            this.ControlName.VisibleIndex = 1;
            // 
            // ControlType
            // 
            this.ControlType.Caption = "控件类型";
            this.ControlType.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.ControlType.FieldName = "ControlType";
            this.ControlType.Name = "ControlType";
            this.ControlType.Visible = true;
            this.ControlType.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // ColumnName
            // 
            this.ColumnName.Caption = "字段名称";
            this.ColumnName.FieldName = "ColumnName";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Visible = true;
            this.ColumnName.VisibleIndex = 2;
            // 
            // ColumnType
            // 
            this.ColumnType.Caption = "字段控件类型";
            this.ColumnType.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.ColumnType.FieldName = "ColumnType";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Visible = true;
            this.ColumnType.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // ColumnFileName
            // 
            this.ColumnFileName.Caption = "对应名称";
            this.ColumnFileName.FieldName = "ColumnFileName";
            this.ColumnFileName.Name = "ColumnFileName";
            this.ColumnFileName.Visible = true;
            this.ColumnFileName.VisibleIndex = 4;
            // 
            // ColumnCaption
            // 
            this.ColumnCaption.Caption = "显示名称";
            this.ColumnCaption.FieldName = "ColumnCaption";
            this.ColumnCaption.Name = "ColumnCaption";
            this.ColumnCaption.Visible = true;
            this.ColumnCaption.VisibleIndex = 5;
            // 
            // ColumnBandTable
            // 
            this.ColumnBandTable.Caption = "绑定表名";
            this.ColumnBandTable.FieldName = "ColumnBandTable";
            this.ColumnBandTable.Name = "ColumnBandTable";
            this.ColumnBandTable.Visible = true;
            this.ColumnBandTable.VisibleIndex = 6;
            // 
            // ColumnBandNO
            // 
            this.ColumnBandNO.Caption = "绑定编号";
            this.ColumnBandNO.FieldName = "ColumnBandNO";
            this.ColumnBandNO.Name = "ColumnBandNO";
            this.ColumnBandNO.Visible = true;
            this.ColumnBandNO.VisibleIndex = 7;
            // 
            // ColumnVisible
            // 
            this.ColumnVisible.Caption = "是否显示";
            this.ColumnVisible.ColumnEdit = this.repositoryItemCheckEdit1;
            this.ColumnVisible.FieldName = "ColumnVisible";
            this.ColumnVisible.Name = "ColumnVisible";
            this.ColumnVisible.Visible = true;
            this.ColumnVisible.VisibleIndex = 8;
            // 
            // ColumnEnable
            // 
            this.ColumnEnable.Caption = "是否编辑";
            this.ColumnEnable.ColumnEdit = this.repositoryItemCheckEdit2;
            this.ColumnEnable.FieldName = "ColumnEnable";
            this.ColumnEnable.Name = "ColumnEnable";
            this.ColumnEnable.Visible = true;
            this.ColumnEnable.VisibleIndex = 9;
            // 
            // ColumnAllFocus
            // 
            this.ColumnAllFocus.Caption = "是否可选";
            this.ColumnAllFocus.ColumnEdit = this.repositoryItemCheckEdit3;
            this.ColumnAllFocus.FieldName = "ColumnAllFocus";
            this.ColumnAllFocus.Name = "ColumnAllFocus";
            this.ColumnAllFocus.Visible = true;
            this.ColumnAllFocus.VisibleIndex = 10;
            // 
            // State
            // 
            this.State.Caption = "启用";
            this.State.ColumnEdit = this.repositoryItemCheckEdit4;
            this.State.FieldName = "state";
            this.State.Name = "state";
            this.State.Visible = true;
            this.State.VisibleIndex = 11;
            // 
            // Sort
            // 
            this.Sort.Caption = "排序";
            this.Sort.FieldName = "sort";
            this.Sort.Name = "sort";
            this.Sort.Visible = true;
            this.Sort.VisibleIndex = 12;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // FrmGridColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 556);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmGridColumns";
            this.Text = "FRMModuleInfos";
            this.Load += new System.EventHandler(this.FrmGridColumns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
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
            private DevExpress.XtraBars.BarButtonItem BTAdd;
            private DevExpress.XtraBars.BarButtonItem BTEdit;
            private DevExpress.XtraBars.BarButtonItem BTSave;
            private DevExpress.XtraBars.BarButtonItem BTDelete;
            private System.Windows.Forms.Panel panel1;
            private DevExpress.XtraBars.BarButtonItem BTExpand;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn ControlNO;
        private DevExpress.XtraGrid.Columns.GridColumn ControlName;
        private DevExpress.XtraGrid.Columns.GridColumn ControlType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnType;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnFileName;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnCaption;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnBandTable;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnBandNO;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnVisible;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnEnable;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnAllFocus;
        private DevExpress.XtraGrid.Columns.GridColumn State;
        private DevExpress.XtraGrid.Columns.GridColumn Sort;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
    }
    
}