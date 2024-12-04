namespace WorkComm.TestInfo
{
    partial class FrmUserCheck
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
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.userNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.state = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(0, 0);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.Size = new System.Drawing.Size(586, 529);
            this.GCInfo.TabIndex = 0;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.no,
            this.userNO,
            this.names,
            this.shortNames,
            this.customCode,
            this.state});
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.DoubleClick += new System.EventHandler(this.GVInfo_DoubleClick);
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 100;
            this.no.MinWidth = 50;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 50;
            // 
            // userNO
            // 
            this.userNO.Caption = "账号";
            this.userNO.FieldName = "userNO";
            this.userNO.MaxWidth = 150;
            this.userNO.MinWidth = 100;
            this.userNO.Name = "userNO";
            this.userNO.OptionsColumn.AllowFocus = false;
            this.userNO.Visible = true;
            this.userNO.VisibleIndex = 1;
            this.userNO.Width = 100;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.MaxWidth = 150;
            this.names.MinWidth = 100;
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 2;
            this.names.Width = 100;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "拼音编码";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.MaxWidth = 150;
            this.shortNames.MinWidth = 100;
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            this.shortNames.Visible = true;
            this.shortNames.VisibleIndex = 3;
            this.shortNames.Width = 100;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定义码";
            this.customCode.FieldName = "customCode";
            this.customCode.MaxWidth = 150;
            this.customCode.MinWidth = 100;
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            this.customCode.Visible = true;
            this.customCode.VisibleIndex = 4;
            this.customCode.Width = 100;
            // 
            // state
            // 
            this.state.Caption = "状态";
            this.state.FieldName = "state";
            this.state.MaxWidth = 40;
            this.state.MinWidth = 40;
            this.state.Name = "state";
            this.state.OptionsColumn.AllowFocus = false;
            this.state.Visible = true;
            this.state.VisibleIndex = 5;
            this.state.Width = 40;
            // 
            // FrmUserCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 529);
            this.Controls.Add(this.GCInfo);
            this.Name = "FrmUserCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户选择列表";
            this.Load += new System.EventHandler(this.FrmUserCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn userNO;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
        private DevExpress.XtraGrid.Columns.GridColumn state;
    }
}