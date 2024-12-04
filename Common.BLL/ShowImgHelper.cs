using DevExpress.XtraEditors;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Common.BLL
{
    public class ShowImgHelper
    {

        /// <summary>
        /// 查看原图
        /// </summary>
        /// <param name="image"></param>
        //public static void ViewOrignalImage(Image image)
        public static void ViewOrignalImage(Bitmap image)
        {
            //查看原图
            if (image != null)
            {
                ProcessHelper.KillProcess("Microsoft.Photos");
                var tempFilePath = string.Empty;

                tempFilePath = System.Windows.Forms.Application.StartupPath + "\\temp.png";
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
                //Bitmap bm = new Bitmap(image);
                Bitmap bm = new Bitmap(image);
                bm.Save(tempFilePath);
                bm.Dispose();

                //建立新的系统进程     

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                //设置图片的真实路径和文件名     
                process.StartInfo.FileName = tempFilePath;

                //设置进程运行参数，这里以最大化窗口方法显示图片。     
                process.StartInfo.Arguments = "rundl132.exe C://WINDOWS//system32//shimgvw.dll,ImageView_Fullscreen";

                //此项为是否使用Shell执行程序，因系统默认为true，此项也可不设，但若设置必须为true     
                process.StartInfo.UseShellExecute = true;

                //此处可以更改进程所打开窗体的显示样式，可以不设     
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();
                process.Close();
            }
            else
            {
                MessageBox.Show("未找到该信息原始单信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
