
namespace workOther.MicrobeInfo
{
    partial class FrmGroupEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupEdit));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CEstate = new DevExpress.XtraEditors.CheckEdit();
            this.BTClose = new DevExpress.XtraEditors.SimpleButton();
            this.BTSave = new DevExpress.XtraEditors.SimpleButton();
            this.TEremark = new DevExpress.XtraEditors.MemoEdit();
            this.TEsort = new DevExpress.XtraEditors.TextEdit();
            this.TEcustomCode = new DevExpress.XtraEditors.TextEdit();
            this.TEshortNames = new DevExpress.XtraEditors.TextEdit();
            this.TEnames = new DevExpress.XtraEditors.TextEdit();
            this.TEno = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CEstate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEcustomCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEshortNames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEnames.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CEstate);
            this.layoutControl1.Controls.Add(this.BTClose);
            this.layoutControl1.Controls.Add(this.BTSave);
            this.layoutControl1.Controls.Add(this.TEremark);
            this.layoutControl1.Controls.Add(this.TEsort);
            this.layoutControl1.Controls.Add(this.TEcustomCode);
            this.layoutControl1.Controls.Add(this.TEshortNames);
            this.layoutControl1.Controls.Add(this.TEnames);
            this.layoutControl1.Controls.Add(this.TEno);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(569, 541);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CEstate
            // 
            this.CEstate.Location = new System.Drawing.Point(81, 166);
            this.CEstate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CEstate.Name = "CEstate";
            this.CEstate.Properties.Caption = "启用";
            this.CEstate.Size = new System.Drawing.Size(475, 24);
            this.CEstate.StyleController = this.layoutControl1;
            this.CEstate.TabIndex = 12;
            // 
            // BTClose
            // 
            this.BTClose.ImageOptions.Image = global::workOther.MicrobeInfo.Properties.Resources.cancel_16x161;
            this.BTClose.Location = new System.Drawing.Point(436, 498);
            this.BTClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTClose.Name = "BTClose";
            this.BTClose.Size = new System.Drawing.Size(120, 27);
            this.BTClose.StyleController = this.layoutControl1;
            this.BTClose.TabIndex = 11;
            this.BTClose.Text = "取消";
            this.BTClose.Click += new System.EventHandler(this.BTClose_Click);
            // 
            // BTSave
            // 
            this.BTSave.ImageOptions.Image = global::workOther.MicrobeInfo.Properties.Resources.apply_16x161;
            this.BTSave.Location = new System.Drawing.Point(241, 498);
            this.BTSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(113, 27);
            this.BTSave.StyleController = this.layoutControl1;
            this.BTSave.TabIndex = 10;
            this.BTSave.Text = "保存";
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // TEremark
            // 
            this.TEremark.Location = new System.Drawing.Point(81, 196);
            this.TEremark.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEremark.Name = "TEremark";
            this.TEremark.Size = new System.Drawing.Size(475, 296);
            this.TEremark.StyleController = this.layoutControl1;
            this.TEremark.TabIndex = 9;
            // 
            // TEsort
            // 
            this.TEsort.Location = new System.Drawing.Point(81, 136);
            this.TEsort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEsort.Name = "TEsort";
            this.TEsort.Size = new System.Drawing.Size(475, 24);
            this.TEsort.StyleController = this.layoutControl1;
            this.TEsort.TabIndex = 8;
            // 
            // TEcustomCode
            // 
            this.TEcustomCode.Location = new System.Drawing.Point(81, 106);
            this.TEcustomCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEcustomCode.Name = "TEcustomCode";
            this.TEcustomCode.Size = new System.Drawing.Size(475, 24);
            this.TEcustomCode.StyleController = this.layoutControl1;
            this.TEcustomCode.TabIndex = 7;
            // 
            // TEshortNames
            // 
            this.TEshortNames.Location = new System.Drawing.Point(81, 76);
            this.TEshortNames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEshortNames.Name = "TEshortNames";
            this.TEshortNames.Size = new System.Drawing.Size(475, 24);
            this.TEshortNames.StyleController = this.layoutControl1;
            this.TEshortNames.TabIndex = 6;
            // 
            // TEnames
            // 
            this.TEnames.Location = new System.Drawing.Point(81, 46);
            this.TEnames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEnames.Name = "TEnames";
            this.TEnames.Size = new System.Drawing.Size(475, 24);
            this.TEnames.StyleController = this.layoutControl1;
            this.TEnames.TabIndex = 5;
            this.TEnames.Leave += new System.EventHandler(this.TEnames_Leave);
            // 
            // TEno
            // 
            this.TEno.Location = new System.Drawing.Point(81, 16);
            this.TEno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEno.Name = "TEno";
            this.TEno.Properties.ReadOnly = true;
            this.TEno.Size = new System.Drawing.Size(475, 24);
            this.TEno.StyleController = this.layoutControl1;
            this.TEno.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(569, 541);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TEno;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(547, 30);
            this.layoutControlItem1.Text = "组合编号:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 482);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(228, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TEnames;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(547, 30);
            this.layoutControlItem2.Text = "组合名称:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(65, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.TEshortNames;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(547, 30);
            this.layoutControlItem3.Text = "组合简称:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(65, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.TEcustomCode;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(547, 30);
            this.layoutControlItem4.Text = "自定名称:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(65, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.TEsort;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(547, 30);
            this.layoutControlItem5.Text = "排      序:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(65, 18);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.TEremark;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 180);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(547, 302);
            this.layoutControlItem6.Text = "备      注:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(65, 18);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.BTSave;
            this.layoutControlItem7.Location = new System.Drawing.Point(228, 482);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(117, 33);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.BTClose;
            this.layoutControlItem8.Location = new System.Drawing.Point(423, 482);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(124, 33);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(345, 482);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(78, 33);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.CEstate;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 150);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(547, 30);
            this.layoutControlItem9.Text = "状      态:";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(65, 18);
            // 
            // FrmGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 541);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FrmGroupEdit.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGroupEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抗生素组合信息";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CEstate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEsort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEcustomCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEshortNames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEnames.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit TEsort;
        private DevExpress.XtraEditors.TextEdit TEcustomCode;
        private DevExpress.XtraEditors.TextEdit TEshortNames;
        private DevExpress.XtraEditors.TextEdit TEnames;
        private DevExpress.XtraEditors.TextEdit TEno;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton BTClose;
        private DevExpress.XtraEditors.SimpleButton BTSave;
        private DevExpress.XtraEditors.MemoEdit TEremark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.CheckEdit CEstate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}