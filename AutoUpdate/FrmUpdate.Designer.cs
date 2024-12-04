
namespace AutoUpdate
{
    partial class FrmUpdate
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LBText = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.LBversion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "正在更新文件，请稍等。。。";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(31, 48);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(520, 22);
            this.progressBar.TabIndex = 1;
            // 
            // LBText
            // 
            this.LBText.AutoSize = true;
            this.LBText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBText.Location = new System.Drawing.Point(557, 54);
            this.LBText.Name = "LBText";
            this.LBText.Size = new System.Drawing.Size(32, 16);
            this.LBText.TabIndex = 2;
            this.LBText.Text = "0/0";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // LBversion
            // 
            this.LBversion.AutoSize = true;
            this.LBversion.Location = new System.Drawing.Point(412, 20);
            this.LBversion.Name = "LBversion";
            this.LBversion.Size = new System.Drawing.Size(71, 12);
            this.LBversion.TabIndex = 3;
            this.LBversion.Text = "更新版本号:";
            // 
            // FrmUpdate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(626, 90);
            this.Controls.Add(this.LBversion);
            this.Controls.Add(this.LBText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HLIMS自动更新程序";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label LBText;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label LBversion;
    }
}

