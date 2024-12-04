namespace WorkComm.TestInfo
{
        partial class FrmChengePWD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChengePWD));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TEUserName = new DevExpress.XtraEditors.TextEdit();
            this.TEUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.BTOK = new DevExpress.XtraEditors.SimpleButton();
            this.BTClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TEUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEUserPWD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "密   码:";
            // 
            // TEUserName
            // 
            this.TEUserName.Location = new System.Drawing.Point(89, 29);
            this.TEUserName.Name = "TEUserName";
            this.TEUserName.Properties.ReadOnly = true;
            this.TEUserName.Size = new System.Drawing.Size(175, 20);
            this.TEUserName.TabIndex = 3;
            // 
            // TEUserPWD
            // 
            this.TEUserPWD.Location = new System.Drawing.Point(89, 76);
            this.TEUserPWD.Name = "TEUserPWD";
            this.TEUserPWD.Properties.PasswordChar = '*';
            this.TEUserPWD.Size = new System.Drawing.Size(175, 20);
            this.TEUserPWD.TabIndex = 4;
            // 
            // BTOK
            // 
            this.BTOK.Location = new System.Drawing.Point(24, 118);
            this.BTOK.Name = "BTOK";
            this.BTOK.Size = new System.Drawing.Size(75, 23);
            this.BTOK.TabIndex = 5;
            this.BTOK.Text = "确定";
            this.BTOK.Click += new System.EventHandler(this.BTOK_Click);
            // 
            // BTClear
            // 
            this.BTClear.Location = new System.Drawing.Point(202, 118);
            this.BTClear.Name = "BTClear";
            this.BTClear.Size = new System.Drawing.Size(75, 23);
            this.BTClear.TabIndex = 6;
            this.BTClear.Text = "取消";
            this.BTClear.Click += new System.EventHandler(this.BTClear_Click);
            // 
            // FrmChengePWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 177);
            this.ControlBox = false;
            this.Controls.Add(this.BTClear);
            this.Controls.Add(this.BTOK);
            this.Controls.Add(this.TEUserPWD);
            this.Controls.Add(this.TEUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmChengePWD.IconOptions.Icon")));
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FrmChengePWD.IconOptions.SvgImage")));
            this.Name = "FrmChengePWD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份验证";
            ((System.ComponentModel.ISupportInitialize)(this.TEUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEUserPWD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit TEUserName;
        private DevExpress.XtraEditors.TextEdit TEUserPWD;
        private DevExpress.XtraEditors.SimpleButton BTOK;
        private DevExpress.XtraEditors.SimpleButton BTClear;
    }
    }