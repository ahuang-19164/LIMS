using Common.Model;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common.MessageHandle
{
    public partial class FrmMessage : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 枚举，描述消息窗口加载的形式
        /// </summary>
        public enum LoadMode
        {
            /// <summary>
            /// 警告
            /// </summary>
            Warning,

            /// <summary>
            /// 错误
            /// </summary>
            Error,

            /// <summary>
            /// 提示
            /// </summary>
            Prompt
        }







        int formNO = 0;
        ReMessageInfo info = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Num">第几条信息</param>
        /// <param name="infos">信息内容</param>
        public FrmMessage(int Num, ReMessageInfo infos)
        {
            InitializeComponent();
            if (Num > 0)
            {
                formNO = Num;
                info = infos;
                this.MouseMove += plShow_MouseMove;
                this.MouseLeave += plShow_MouseLeave;
                TEBarcode.EditValue = infos.barcode;
                TETypeState.EditValue = infos.stateName;
                //GETypeState.EditValue = infos.stateNo;
                TERecord.EditValue = infos.msg;
                DEDateTime.EditValue = infos.createTime;
            }
            else
            {
                this.Close();
            }
        }


        public void FrmLoad(int Num, ReMessageInfo infos)
        {
            if (Num > 0)
            {
                formNO = Num;
                info = infos;
                this.MouseMove += plShow_MouseMove;
                this.MouseLeave += plShow_MouseLeave;
                TEBarcode.EditValue = infos.barcode;
                TETypeState.EditValue = infos.stateName;
                //GETypeState.EditValue = infos.stateNo;
                TERecord.EditValue = infos.msg;
                DEDateTime.EditValue = infos.createTime;
            }
            else
            {
                this.Close();
            }
        }



        private void FrmMessage_Load(object sender, EventArgs e)
        {

            int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            int top = height - 35 - this.Height * formNO;
            int left = width - this.Width - 5;
            this.Top = top;
            this.Left = left;
            this.TopMost = true;

            AnimateWindow(this.Handle, 500, AW_SLIDE + AW_VER_NEGATIVE);//开始窗体动画
            this.Refresh();
            this.ShowInTaskbar = false;
            Timer_Close = new Timer();
            Timer_Close.Interval = 10000;
            Timer_Close.Tick += new EventHandler(Timer_Close_Tick);
            Timer_Close.Start();
        }


        string FrmState = "";

        /// <summary>
        /// 其他功能反射
        /// </summary>
        /// <param name="ValueInfo"></param>
        /// <returns></returns>
        public string ReState()
        {
            return FrmState;

        }

        #region ***********************字 段***********************

        /// <summary>
        /// 窗体加载模式
        /// </summary>
#pragma warning disable CS0414 // 字段“FrmMessage.FormMode”已被赋值，但从未使用过它的值
        private static LoadMode FormMode = LoadMode.Prompt;
#pragma warning restore CS0414 // 字段“FrmMessage.FormMode”已被赋值，但从未使用过它的值

        /// <summary>
        /// 显示的消息正文
        /// </summary>
#pragma warning disable CS0414 // 字段“FrmMessage.ShowMessage”已被赋值，但从未使用过它的值
        private static string ShowMessage = null;
#pragma warning restore CS0414 // 字段“FrmMessage.ShowMessage”已被赋值，但从未使用过它的值

        /// <summary>
        /// 关闭窗口的定时器
        /// </summary>
        private Timer Timer_Close;


        [DllImportAttribute("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);   // 该函数可以实现窗体的动画效果

        public const Int32 AW_HOR_POSITIVE = 0x00000001;   // 自左向右显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略 
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;   // 自右向左显示窗口。当使用了 AW_CENTER 标志时该标志被忽略

        public const Int32 AW_VER_POSITIVE = 0x00000004;   // 自顶向下显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略
        public const Int32 AW_VER_NEGATIVE = 0x00000008;   // 自下向上显示窗口。该标志可以在滚动动画和滑动动画中使用。当使用AW_CENTER标志时，该标志将被忽略

        public const Int32 AW_CENTER = 0x00000010;         // 若使用了AW_HIDE标志，则使窗口向内重叠；若未使用AW_HIDE标志，则使窗口向外扩展
        public const Int32 AW_HIDE = 0x00010000;           // 隐藏窗口，缺省则显示窗口
        public const Int32 AW_ACTIVATE = 0x00020000;       // 激活窗口。在使用了AW_HIDE标志后不要使用这个标志
        public const Int32 AW_SLIDE = 0x00040000;          // 使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        public const Int32 AW_BLEND = 0x00080000;          // 使用淡入效果。只有当hWnd为顶层窗口的时候才可以使用此标志

        #endregion*************************************************


        #region ***********************方 法***********************

        ///// <summary>
        ///// 构造方法
        ///// </summary>
        ///// <param name="loadMode">加载模式</param>
        ///// <param name="message">消息正文</param>

        //public static void Show(LoadMode loadMode, string message)
        //{
        //    FormMode = loadMode;
        //    ShowMessage = message;

        //    FormMessageBox box = new FormMessageBox();
        //    box.Show();
        //}



        #endregion*************************************************


        #region ***********************事 件***********************

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMessageBox_Load(object sender, EventArgs e)
        {
            //this.lblTitle.Text = "";
            //if (FormMode == LoadMode.Error)
            //{
            //    this.lblTitle.Text = "错误";
            //    this.plShow.BackgroundImage = global::dataSource.Properties.Resources.error;    // 更换背景
            //}
            //else if (FormMode == LoadMode.Warning)
            //{
            //    this.lblTitle.Text = "警告";
            //    this.plShow.BackgroundImage = global::dataSource.Properties.Resources.warning;  // 更换背景
            //}
            //else
            //{
            //    this.plShow.BackgroundImage = global::dataSource.Properties.Resources.Prompt;   // 更换背景
            //}

            //this.lblMessage.Text = ShowMessage;


        }

        /// <summary>
        /// 关闭窗口的定时器响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Close_Tick(object sender, EventArgs e)
        {
            Timer_Close.Stop();

            this.Close();
        }

        /// <summary>
        /// 窗口已经关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_SLIDE + AW_VER_POSITIVE + AW_HIDE);

            Timer_Close.Stop();
            Timer_Close.Dispose();
        }

        /// <summary>
        /// 鼠标移动在消息框上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plShow_MouseMove(object sender, MouseEventArgs e)
        {
            this.Timer_Close.Stop();
        }

        /// <summary>
        /// 鼠标移动离开消息框上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plShow_MouseLeave(object sender, EventArgs e)
        {
            this.Timer_Close.Start();
        }

        #endregion

        private void FrmMessage_MouseEnter(object sender, EventArgs e)
        {
            this.Timer_Close.Stop();
        }

        private void panelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Timer_Close.Stop();
        }
        //声明委托 和 事件
        public delegate void TransfDelegate(String value);
        public event TransfDelegate TransfEvent;
        private void BTOK_Click(object sender, EventArgs e)
        {

            FrmState = info.stateNo != null ? info.stateNo : "";
            //触发事件
            TransfEvent(FrmState.ToString());
            this.Close();
        }

        private void FrmMessage_Move(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
