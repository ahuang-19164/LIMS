
namespace WorkComm.logisticsInfo
{
    partial class FrmLogisticeLog
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupList = new DevExpress.XtraEditors.GroupControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupInfo = new DevExpress.XtraEditors.GroupControl();
            this.GCLog = new DevExpress.XtraGrid.GridControl();
            this.GVLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hospitalNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.operatType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.logInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.operater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).BeginInit();
            this.groupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).BeginInit();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVLog)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupList);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupInfo);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1414, 624);
            this.splitContainerControl1.SplitterPosition = 634;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.GCInfo);
            this.groupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupList.Location = new System.Drawing.Point(0, 0);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(634, 624);
            this.groupList.TabIndex = 0;
            this.groupList.Text = "信息列表";
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(2, 23);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.Size = new System.Drawing.Size(630, 599);
            this.GCInfo.TabIndex = 0;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.names,
            this.shortNames,
            this.customCode,
            this.state});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.Click += new System.EventHandler(this.GVInfo_Click);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 80;
            this.no.MinWidth = 80;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 80;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "拼音简拼";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 2;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定编码";
            this.customCode.FieldName = "customCode";
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Visible = true;
            this.customCode.VisibleIndex = 3;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 50;
            this.state.MinWidth = 50;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 4;
            this.state.Width = 50;
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.GCLog);
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInfo.Location = new System.Drawing.Point(0, 0);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(770, 624);
            this.groupInfo.TabIndex = 0;
            this.groupInfo.Text = "详细信息";
            // 
            // GCLog
            // 
            this.GCLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCLog.Location = new System.Drawing.Point(2, 23);
            this.GCLog.MainView = this.GVLog;
            this.GCLog.Name = "GCLog";
            this.GCLog.Size = new System.Drawing.Size(766, 599);
            this.GCLog.TabIndex = 0;
            this.GCLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVLog});
            // 
            // GVLog
            // 
            this.GVLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hospitalNO,
            this.operatType,
            this.logInfo,
            this.operater,
            this.createTime});
            this.GVLog.DetailHeight = 408;
            this.GVLog.GridControl = this.GCLog;
            this.GVLog.Name = "GVLog";
            this.GVLog.OptionsView.ShowGroupPanel = false;
            // 
            // hospitalNO
            // 
            this.hospitalNO.Caption = "医院名称";
            this.hospitalNO.FieldName = "hospitalNO";
            this.hospitalNO.MinWidth = 23;
            this.hospitalNO.Name = "hospitalNO";
            this.hospitalNO.Visible = true;
            this.hospitalNO.VisibleIndex = 0;
            this.hospitalNO.Width = 87;
            // 
            // operatType
            // 
            this.operatType.Caption = "操作类型";
            this.operatType.FieldName = "operatType";
            this.operatType.MaxWidth = 93;
            this.operatType.MinWidth = 93;
            this.operatType.Name = "operatType";
            this.operatType.Visible = true;
            this.operatType.VisibleIndex = 1;
            this.operatType.Width = 93;
            // 
            // logInfo
            // 
            this.logInfo.Caption = "记录";
            this.logInfo.FieldName = "logInfo";
            this.logInfo.MinWidth = 23;
            this.logInfo.Name = "logInfo";
            this.logInfo.Visible = true;
            this.logInfo.VisibleIndex = 2;
            this.logInfo.Width = 87;
            // 
            // operater
            // 
            this.operater.Caption = "操作者";
            this.operater.FieldName = "operater";
            this.operater.MaxWidth = 82;
            this.operater.MinWidth = 82;
            this.operater.Name = "operater";
            this.operater.Visible = true;
            this.operater.VisibleIndex = 3;
            this.operater.Width = 82;
            // 
            // createTime
            // 
            this.createTime.Caption = "操作时间";
            this.createTime.FieldName = "createTime";
            this.createTime.MaxWidth = 175;
            this.createTime.MinWidth = 175;
            this.createTime.Name = "createTime";
            this.createTime.Visible = true;
            this.createTime.VisibleIndex = 4;
            this.createTime.Width = 175;
            // 
            // FrmLogisticeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 624);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmLogisticeLog";
            this.Text = "FrmLogisticsBarcode";
            this.Load += new System.EventHandler(this.FrmLogisticeLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupList)).EndInit();
            this.groupList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInfo)).EndInit();
            this.groupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupList;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraEditors.GroupControl groupInfo;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private DevExpress.XtraGrid.Columns.GridColumn state;
        private DevExpress.XtraGrid.GridControl GCLog;
        private DevExpress.XtraGrid.Views.Grid.GridView GVLog;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNO;
        private DevExpress.XtraGrid.Columns.GridColumn operatType;
        private DevExpress.XtraGrid.Columns.GridColumn logInfo;
        private DevExpress.XtraGrid.Columns.GridColumn operater;
        private DevExpress.XtraGrid.Columns.GridColumn createTime;
    }
}