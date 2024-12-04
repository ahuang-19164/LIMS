using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace Common.BLL
{
    public class FileConverHelper
    {
        //图片处理
        #region 

        /// <summary>
        /// 文件转string
        /// </summary>
        /// <param name="Filepath"></param>
        /// <returns></returns>
        public static string FilePathToString(string Filepath)
        {
            byte[] bytes = File.ReadAllBytes(Filepath);
            string base64String = Convert.ToBase64String(bytes);
            return base64String;
        }

        /// <summary>
        /// 下载网络图片转换成string    http://www.wangxiaokc.com/CL.ExamWebService/image/55/1928007_0.jpg
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        #region 下载图片到Image
        public static string UrlImageToString(string url)
        {
            WebClient mywebclient = new WebClient();
            byte[] Bytes = mywebclient.DownloadData(url);
            string base64String = Convert.ToBase64String(Bytes);
            return base64String;
        }
        #endregion

        /// <summary>
        /// bitmap转二进制流
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public string BitmapTostring(Bitmap bitmap)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    byte[] data = new byte[stream.Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(data, 0, Convert.ToInt32(stream.Length));
                    //return data;
                    string base64String = Convert.ToBase64String(data);
                    return base64String;
                }
            }
            catch
            {
                //throw ex;
                return null;
            }
        }

        /// <summary>
        /// 文件转换成二进制流
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        private byte[] FilePathToByte(string FilePath)
        {
            FileStream files = new FileStream(FilePath, FileMode.Open);
            byte[] imgByte = new byte[files.Length];
            files.Read(imgByte, 0, imgByte.Length);
            files.Close();
            return imgByte;
        }

        /// <summary>
        /// bitmap转二进制流
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public byte[] BitmapToByte(Bitmap bitmap)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    byte[] data = new byte[stream.Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(data, 0, Convert.ToInt32(stream.Length));
                    return data;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// stream转二进制流
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public byte[] StreanToByte(Stream stream)
        {
            try
            {
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
            catch
            {
                return null;
            }
        }






        /// <summary>
        /// 转换指定路径图片
        /// </summary>
        /// <param name="Filepath"></param>
        /// <returns></returns>
        public Bitmap FilePathToBitmap(string Filepath)
        {
            Bitmap bitmap = new Bitmap(Filepath);
            return bitmap;
        }


        /// <summary>
        /// Stream转Bitmap
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Bitmap StreamToBitmap(Stream stream)
        {
            try
            {
                Bitmap bmp = new Bitmap(stream);
                return bmp;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Stream转Bitmap
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Bitmap StreamToBitmaps(Stream stream)
        {
            try
            {
                Bitmap bmp = new Bitmap(stream);
                return bmp;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// string数据字符串转Bitmap
        /// </summary>
        /// <param name="base64String">数据字符串</param>
        /// <returns></returns>
        public Bitmap StringToBitmap(string base64String)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(base64String);
                using (MemoryStream stream = new MemoryStream(arr))
                {
                    Bitmap bmp = new Bitmap(stream);
                    return bmp;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Bitmap转Stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Stream StreamToBitmap(Bitmap bitmap)
        {
            try
            {
                Stream stream = new MemoryStream(BitmapToByte(bitmap));
                return stream;

            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// 二进制流转stream
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public Stream Bitmap2Byte(byte[] bytes)
        {
            try
            {
                Stream stream = new MemoryStream(bytes);
                return stream;
            }
            catch
            {
                return null;
            }
        }


        #endregion



        //文件处理
        #region
        /// <summary>  
        /// 将传进来的文件转换成字符串  
        /// </summary>  
        /// <param name="FilePath">待处理的文件路径(本地或服务器)</param>  
        /// <returns></returns>
        public string FileTostring(string filePath)
        {
            try
            {
                //利用新传来的路径实例化一个FileStream对像  
                System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                //得到对象的大小
                int fileLength = Convert.ToInt32(fs.Length);
                //声明一个byte数组 
                byte[] fileByteArray = new byte[fileLength];
                //声明一个读取二进流的BinaryReader对像
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                for (int i = 0; i < fileLength; i++)
                {
                    //将数据读取出来放在数组中 
                    br.Read(fileByteArray, 0, fileLength);
                }
                //装数组转换为String字符串
                string strData = Convert.ToBase64String(fileByteArray);
                br.Close();
                fs.Close();
                return strData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        //文件处理
        #region
        /// <summary>  
        /// 将传进来的文件转换成字符串  
        /// </summary>  
        /// <param name="FilePath">待处理的文件路径(本地或服务器)</param>  
        /// <returns></returns>
        public Stream FilePathToStream(string filePath)
        {
            try
            {
                //利用新传来的路径实例化一个FileStream对像  
                using (Stream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    return fs;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>  
        /// 将传进来的字符串保存为文件  
        /// </summary>  
        /// <param name="path">需要保存的位置路径</param>  
        /// <param name="binary">需要转换的字符串</param>  
        /// <param name="filename">文件名称（包含扩展名称）</param>  
        public void StringToFile(string path, string binary, string filename)
        {
            try
            {
                path = path + "\\" + filename;
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                //利用新传来的路径实例化一个FileStream对像  
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
                //实例化一个用于写的BinaryWriter  
                bw.Write(Convert.FromBase64String(binary));
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}