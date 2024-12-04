namespace HLFramework
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
            this.TBUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBUserPWD1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBUserPWD2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTChangeOK = new System.Windows.Forms.Button();
            this.BTchangeClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBUserName
            // 
            this.TBUserName.Enabled = false;
            this.TBUserName.Location = new System.Drawing.Point(124, 42);
            this.TBUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBUserName.Name = "TBUserName";
            this.TBUserName.Size = new System.Drawing.Size(200, 26);
            this.TBUserName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名:";
            // 
            // TBUserPWD1
            // 
            this.TBUserPWD1.Location = new System.Drawing.Point(124, 92);
            this.TBUserPWD1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBUserPWD1.Name = "TBUserPWD1";
            this.TBUserPWD1.Size = new System.Drawing.Size(200, 26);
            this.TBUserPWD1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "密   码:";
            // 
            // TBUserPWD2
            // 
            this.TBUserPWD2.Location = new System.Drawing.Point(124, 132);
            this.TBUserPWD2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBUserPWD2.Name = "TBUserPWD2";
            this.TBUserPWD2.Size = new System.Drawing.Size(200, 26);
            this.TBUserPWD2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "确认密码:";
            // 
            // BTChangeOK
            // 
            this.BTChangeOK.Location = new System.Drawing.Point(51, 198);
            this.BTChangeOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTChangeOK.Name = "BTChangeOK";
            this.BTChangeOK.Size = new System.Drawing.Size(85, 30);
            this.BTChangeOK.TabIndex = 2;
            this.BTChangeOK.Text = "确   认";
            this.BTChangeOK.UseVisualStyleBackColor = true;
            this.BTChangeOK.Click += new System.EventHandler(this.BTChangeOK_Click);
            // 
            // BTchangeClose
            // 
            this.BTchangeClose.Location = new System.Drawing.Point(263, 198);
            this.BTchangeClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTchangeClose.Name = "BTchangeClose";
            this.BTchangeClose.Size = new System.Drawing.Size(85, 30);
            this.BTchangeClose.TabIndex = 2;
            this.BTchangeClose.Text = "取   消";
            this.BTchangeClose.UseVisualStyleBackColor = true;
            this.BTchangeClose.Click += new System.EventHandler(this.BTchangeClose_Click);
            // 
            // FrmChengePWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 270);
            this.ControlBox = false;
            this.Controls.Add(this.BTchangeClose);
            this.Controls.Add(this.BTChangeOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBUserPWD2);
            this.Controls.Add(this.TBUserPWD1);
            this.Controls.Add(this.TBUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmChengePWD.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmChengePWD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.TextBox TBUserName;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox TBUserPWD1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox TBUserPWD2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Button BTChangeOK;
            private System.Windows.Forms.Button BTchangeClose;
        }
    }