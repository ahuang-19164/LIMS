
namespace WorkQC.ItemInfo
{
    partial class FrmQCSort
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
            this.GCInfos = new DevExpress.XtraGrid.GridControl();
            this.GVInfos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.customCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.explain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.remark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // GCInfos
            // 
            this.GCInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfos.Location = new System.Drawing.Point(0, 0);
            this.GCInfos.MainView = this.GVInfos;
            this.GCInfos.Name = "GCInfos";
            this.GCInfos.Size = new System.Drawing.Size(800, 450);
            this.GCInfos.TabIndex = 0;
            this.GCInfos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfos});
            // 
            // GVInfos
            // 
            this.GVInfos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.no,
            this.names,
            this.shortNames,
            this.customCode,
            this.explain,
            this.remark});
            this.GVInfos.GridControl = this.GCInfos;
            this.GVInfos.Name = "GVInfos";
            this.GVInfos.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "编号";
            this.id.FieldName = "id";
            this.id.MaxWidth = 100;
            this.id.MinWidth = 100;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Width = 100;
            // 
            // no
            // 
            this.no.Caption = "规则分类代码";
            this.no.FieldName = "no";
            this.no.MaxWidth = 100;
            this.no.Name = "no";
            this.no.OptionsColumn.AllowFocus = false;
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 100;
            // 
            // names
            // 
            this.names.Caption = "规则分类名称";
            this.names.FieldName = "names";
            this.names.Name = "names";
            this.names.OptionsColumn.AllowFocus = false;
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            this.names.Width = 180;
            // 
            // shortNames
            // 
            this.shortNames.Caption = "拼音";
            this.shortNames.FieldName = "shortNames";
            this.shortNames.Name = "shortNames";
            this.shortNames.OptionsColumn.AllowFocus = false;
            // 
            // customCode
            // 
            this.customCode.Caption = "自定义码";
            this.customCode.FieldName = "customCode";
            this.customCode.Name = "customCode";
            this.customCode.OptionsColumn.AllowFocus = false;
            // 
            // explain
            // 
            this.explain.Caption = "说明";
            this.explain.FieldName = "explain";
            this.explain.Name = "explain";
            this.explain.OptionsColumn.AllowFocus = false;
            this.explain.Visible = true;
            this.explain.VisibleIndex = 2;
            this.explain.Width = 180;
            // 
            // remark
            // 
            this.remark.Caption = "备注";
            this.remark.FieldName = "remark";
            this.remark.Name = "remark";
            this.remark.OptionsColumn.AllowFocus = false;
            this.remark.Visible = true;
            this.remark.VisibleIndex = 3;
            this.remark.Width = 182;
            // 
            // FrmQCSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GCInfos);
            this.Name = "FrmQCSort";
            this.Text = "FrmQCSort";
            this.Load += new System.EventHandler(this.FrmQCSort_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GCInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCInfos;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfos;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn explain;
        private DevExpress.XtraGrid.Columns.GridColumn remark;
        private DevExpress.XtraGrid.Columns.GridColumn shortNames;
        private DevExpress.XtraGrid.Columns.GridColumn customCode;
    }
}