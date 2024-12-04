namespace WorkTest.TestImg
{
    partial class FrmTestImg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestImg));
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
            this.reportState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.resultTypeNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTUpImg = new System.Windows.Forms.ToolStripButton();
            this.BTDeleteImg = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.GCTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GCTestInfo
            // 
            this.GCTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCTestInfo.Location = new System.Drawing.Point(2, 23);
            this.GCTestInfo.MainView = this.GVTestInfo;
            this.GCTestInfo.Name = "GCTestInfo";
            this.GCTestInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.RGEmethodNO});
            this.GCTestInfo.Size = new System.Drawing.Size(1205, 393);
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
            this.reportState,
            this.resultTypeNO});
            this.GVTestInfo.DetailHeight = 408;
            this.GVTestInfo.GridControl = this.GCTestInfo;
            this.GVTestInfo.Name = "GVTestInfo";
            // 
            // id
            // 
            this.id.Caption = "ID";
            this.id.FieldName = "id";
            this.id.MinWidth = 23;
            this.id.Name = "id";
            this.id.Width = 87;
            // 
            // groupCode
            // 
            this.groupCode.Caption = "组合编号";
            this.groupCode.FieldName = "groupCode";
            this.groupCode.MaxWidth = 61;
            this.groupCode.MinWidth = 61;
            this.groupCode.Name = "groupCode";
            this.groupCode.OptionsColumn.AllowFocus = false;
            this.groupCode.Width = 61;
            // 
            // groupName
            // 
            this.groupName.Caption = "组合名称";
            this.groupName.FieldName = "groupName";
            this.groupName.MinWidth = 23;
            this.groupName.Name = "groupName";
            this.groupName.OptionsColumn.AllowFocus = false;
            this.groupName.Width = 92;
            // 
            // itemCodes
            // 
            this.itemCodes.Caption = "项目编号";
            this.itemCodes.FieldName = "itemCodes";
            this.itemCodes.MaxWidth = 61;
            this.itemCodes.MinWidth = 61;
            this.itemCodes.Name = "itemCodes";
            this.itemCodes.OptionsColumn.AllowFocus = false;
            this.itemCodes.Visible = true;
            this.itemCodes.VisibleIndex = 0;
            this.itemCodes.Width = 61;
            // 
            // itemNames
            // 
            this.itemNames.Caption = "项目名称";
            this.itemNames.FieldName = "itemNames";
            this.itemNames.MinWidth = 23;
            this.itemNames.Name = "itemNames";
            this.itemNames.OptionsColumn.AllowFocus = false;
            this.itemNames.Visible = true;
            this.itemNames.VisibleIndex = 1;
            this.itemNames.Width = 216;
            // 
            // itemResult
            // 
            this.itemResult.Caption = "结果";
            this.itemResult.FieldName = "itemResult";
            this.itemResult.MaxWidth = 233;
            this.itemResult.MinWidth = 117;
            this.itemResult.Name = "itemResult";
            this.itemResult.Visible = true;
            this.itemResult.VisibleIndex = 2;
            this.itemResult.Width = 117;
            // 
            // flag
            // 
            this.flag.Caption = "标记";
            this.flag.FieldName = "flag";
            this.flag.MaxWidth = 35;
            this.flag.MinWidth = 35;
            this.flag.Name = "flag";
            this.flag.OptionsColumn.AllowFocus = false;
            this.flag.Visible = true;
            this.flag.VisibleIndex = 3;
            this.flag.Width = 35;
            // 
            // unit
            // 
            this.unit.Caption = "单位";
            this.unit.FieldName = "unit";
            this.unit.MaxWidth = 58;
            this.unit.MinWidth = 58;
            this.unit.Name = "unit";
            this.unit.OptionsColumn.AllowFocus = false;
            this.unit.Visible = true;
            this.unit.VisibleIndex = 4;
            this.unit.Width = 58;
            // 
            // itemReference
            // 
            this.itemReference.Caption = "参考值";
            this.itemReference.FieldName = "valueDescribe";
            this.itemReference.MaxWidth = 175;
            this.itemReference.MinWidth = 117;
            this.itemReference.Name = "itemReference";
            this.itemReference.OptionsColumn.AllowFocus = false;
            this.itemReference.Visible = true;
            this.itemReference.VisibleIndex = 5;
            this.itemReference.Width = 117;
            // 
            // itemResultLog
            // 
            this.itemResultLog.Caption = "历史结果";
            this.itemResultLog.FieldName = "itemResultLog";
            this.itemResultLog.MaxWidth = 175;
            this.itemResultLog.MinWidth = 117;
            this.itemResultLog.Name = "itemResultLog";
            this.itemResultLog.OptionsColumn.AllowFocus = false;
            this.itemResultLog.Visible = true;
            this.itemResultLog.VisibleIndex = 6;
            this.itemResultLog.Width = 117;
            // 
            // methodNO
            // 
            this.methodNO.Caption = "实验方法";
            this.methodNO.ColumnEdit = this.RGEmethodNO;
            this.methodNO.FieldName = "methodName";
            this.methodNO.MinWidth = 23;
            this.methodNO.Name = "methodNO";
            this.methodNO.Width = 162;
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
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 408;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // methodName
            // 
            this.methodName.Caption = "实验方法";
            this.methodName.FieldName = "methodName";
            this.methodName.MaxWidth = 175;
            this.methodName.MinWidth = 117;
            this.methodName.Name = "methodName";
            this.methodName.OptionsColumn.AllowFocus = false;
            this.methodName.Visible = true;
            this.methodName.VisibleIndex = 7;
            this.methodName.Width = 117;
            // 
            // reportState
            // 
            this.reportState.Caption = "报告";
            this.reportState.ColumnEdit = this.repositoryItemCheckEdit1;
            this.reportState.FieldName = "reportState";
            this.reportState.MaxWidth = 35;
            this.reportState.MinWidth = 35;
            this.reportState.Name = "reportState";
            this.reportState.Visible = true;
            this.reportState.VisibleIndex = 8;
            this.reportState.Width = 35;
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
            this.resultTypeNO.MinWidth = 23;
            this.resultTypeNO.Name = "resultTypeNO";
            this.resultTypeNO.Width = 87;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1209, 700);
            this.splitContainerControl1.SplitterPosition = 272;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.GCTestInfo);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1209, 418);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "项目信息";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.toolStrip1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1209, 272);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "项目结果图片";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 50);
            this.panelControl1.MaximumSize = new System.Drawing.Size(0, 233);
            this.panelControl1.MinimumSize = new System.Drawing.Size(0, 233);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1205, 233);
            this.panelControl1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTUpImg,
            this.BTDeleteImg});
            this.toolStrip1.Location = new System.Drawing.Point(2, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1205, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTUpImg
            // 
            this.BTUpImg.Image = ((System.Drawing.Image)(resources.GetObject("BTUpImg.Image")));
            this.BTUpImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTUpImg.Name = "BTUpImg";
            this.BTUpImg.Size = new System.Drawing.Size(80, 24);
            this.BTUpImg.Text = "上传图片";
            this.BTUpImg.Click += new System.EventHandler(this.BTUpImg_Click);
            // 
            // BTDeleteImg
            // 
            this.BTDeleteImg.Image = ((System.Drawing.Image)(resources.GetObject("BTDeleteImg.Image")));
            this.BTDeleteImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTDeleteImg.Name = "BTDeleteImg";
            this.BTDeleteImg.Size = new System.Drawing.Size(80, 24);
            this.BTDeleteImg.Text = "删除图片";
            this.BTDeleteImg.Click += new System.EventHandler(this.BTDeleteImg_Click);
            // 
            // FrmTestImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 700);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmTestImg";
            this.Text = "FrmTest";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEmethodNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTUpImg;
        private System.Windows.Forms.ToolStripButton BTDeleteImg;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}

