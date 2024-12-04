using System;
using System.IO;
using System.Windows.Forms;



namespace Common.BLL
{
    public enum FileExtensionName
    {
        img = 0,
        PDF = 1,
        Text = 2,
        Other = 3
    }
    public class OpenFileHelpers
    {
        public static string DeskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        /// <summary>
        /// 选择文件，返回文件路径和扩展名称
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath()
        {
            try
            {
                string FilePath = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.InitialDirectory = DeskPath;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        FilePath = openFileDialog.FileName;
                    }

                }
                return FilePath;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 选择文件，返回文件路径和扩展名称
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath(FileExtensionName fileExtensionName)
        {
            try
            {
                string FilePath = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = DeskPath;
                    if (fileExtensionName == FileExtensionName.img)
                    {
                        openFileDialog.Filter = "Img|*.jpg;*.png;*.jpeg;*.bmp;*.gif|All files(*.*)|*.*";
                    }
                    if (fileExtensionName == FileExtensionName.PDF)
                    {
                        openFileDialog.Filter = "文本文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";
                    }
                    if (fileExtensionName == FileExtensionName.Text)
                    {
                        openFileDialog.Filter = "文本文件(*.text)|*.text|所有文件(*.*)|*.*";
                    }
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        FilePath = openFileDialog.FileName;
                    }

                }
                return FilePath;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 选择文件，返回文件路径和扩展名称
        /// </summary>
        /// <param name="FileExtensionName">扩展名称</param>
        /// <returns></returns>
        public static string GetFilePath(out string FileExtensionName)
        {
            try
            {
                string FilePath = "";
                FileExtensionName = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = DeskPath;
                    openFileDialog.Filter = "文本文件(*.text)|*.text|所有文件(*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        FilePath = openFileDialog.FileName;
                        FileExtensionName = Path.GetExtension(FilePath);
                    }

                }
                return FilePath;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 选择文件，返回文件路径和扩展名称
        /// </summary>
        /// <param name="FileExtensionName">扩展名称</param>
        /// <returns></returns>
        public static string GetFilePath(FileExtensionName FEName, out string fileExtensionName)
        {
            try
            {
                string FilePath = "";
                fileExtensionName = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = DeskPath;
                    if (FEName == FileExtensionName.img)
                    {
                        openFileDialog.Filter = "Img|*.jpg;*.png;*.jpeg;*.bmp;*.gif|All files(*.*)|*.*";
                    }
                    if (FEName == FileExtensionName.PDF)
                    {
                        openFileDialog.Filter = "文本文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";
                    }
                    if (FEName == FileExtensionName.Text)
                    {
                        openFileDialog.Filter = "文本文件(*.text)|*.text|所有文件(*.*)|*.*";
                    }
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FilterIndex = 1;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                        FilePath = openFileDialog.FileName;
                        fileExtensionName = Path.GetExtension(FilePath);
                    }

                }
                return FilePath;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
