using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.LoadShow
{
    public partial class FrmWait : WaitForm
    {
        public FrmWait()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
        /// <summary>
        /// 初始化等待框
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="description"></param>
        /// <param name="caption"></param>
        public void ShowMe(XtraForm owner, string description, string caption)
        {
            SplashScreenManager.ShowForm(owner, typeof(FrmWait), true, true, false);
            SplashScreenManager.Default.SetWaitFormDescription(description);//描述
            SplashScreenManager.Default.SetWaitFormCaption(caption);//标题    
        }

        /// <summary>
        /// 展示等待框
        /// </summary>
        /// <param name="owner"></param>
        public void ShowMe(XtraForm owner)
        {
            SplashScreenManager.ShowForm(owner, typeof(FrmWait), true, true, false);
        }
        /// <summary>
        /// 隐藏等待框
        /// </summary>
        /// <param name="owner"></param>
        public void HideMe(XtraForm owner)
        {
            SplashScreenManager.CloseForm(false, 0, owner);
        }
    }
}