
namespace WorkComm.Items
{
    partial class FrmDesignInfo
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GCFlowInfo = new DevExpress.XtraGrid.GridControl();
            this.GVFlowInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.names = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sort = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCFlowInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVFlowInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(956, 586);
            this.splitContainerControl1.SplitterPosition = 251;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.GCFlowInfo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(251, 586);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "节点列表";
            // 
            // GCFlowInfo
            // 
            this.GCFlowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCFlowInfo.Location = new System.Drawing.Point(2, 23);
            this.GCFlowInfo.MainView = this.GVFlowInfo;
            this.GCFlowInfo.Name = "GCFlowInfo";
            this.GCFlowInfo.Size = new System.Drawing.Size(247, 561);
            this.GCFlowInfo.TabIndex = 0;
            this.GCFlowInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVFlowInfo});
            // 
            // GVFlowInfo
            // 
            this.GVFlowInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.no,
            this.names,
            this.sort});
            this.GVFlowInfo.GridControl = this.GCFlowInfo;
            this.GVFlowInfo.Name = "GVFlowInfo";
            this.GVFlowInfo.OptionsView.ShowGroupPanel = false;
            this.GVFlowInfo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GVFlowInfo_RowClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 586);
            this.panel1.TabIndex = 0;
            // 
            // no
            // 
            this.no.Caption = "编号";
            this.no.FieldName = "no";
            this.no.MaxWidth = 50;
            this.no.MinWidth = 50;
            this.no.Name = "no";
            this.no.Visible = true;
            this.no.VisibleIndex = 0;
            this.no.Width = 50;
            // 
            // names
            // 
            this.names.Caption = "名称";
            this.names.FieldName = "names";
            this.names.Name = "names";
            this.names.Visible = true;
            this.names.VisibleIndex = 1;
            // 
            // sort
            // 
            this.sort.Caption = "排序";
            this.sort.FieldName = "sort";
            this.sort.MaxWidth = 50;
            this.sort.MinWidth = 50;
            this.sort.Name = "sort";
            this.sort.Visible = true;
            this.sort.VisibleIndex = 2;
            this.sort.Width = 50;
            // 
            // FrmDesignInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 586);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FrmDesignInfo";
            this.Text = "FrmDesignInfo";
            this.Load += new System.EventHandler(this.FrmDesignInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCFlowInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVFlowInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GCFlowInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVFlowInfo;
        private DevExpress.XtraGrid.Columns.GridColumn no;
        private DevExpress.XtraGrid.Columns.GridColumn names;
        private DevExpress.XtraGrid.Columns.GridColumn sort;
        private System.Windows.Forms.Panel panel1;
    }
}