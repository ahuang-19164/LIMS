using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Common.BLL
{
    public static class FileConverHelpers
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
            try
            {
                byte[] bytes = File.ReadAllBytes(Filepath);
                string base64String = Convert.ToBase64String(bytes);
                return base64String;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// string 转换成文件。
        /// </summary>
        /// <param name="FilePath">文件完整路径(包含文件名称及扩展名称)@"C:\Users\huang\Desktop\新建文件夹\2\aaa.rar"</param>
        /// <param name="FileString">文件string内容</param>
        /// <returns></returns>
        public static bool StringToFile(string FilePath, string FileString)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(FileString);
                File.WriteAllBytes(FilePath, bytes);
                return true;
            }
            catch (Exception ex)
            {
                File.Delete(FilePath);
                return false;
            }

        }



        /// <summary>
        /// bitmap转二进制流
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static string BitmapTostring(Bitmap bitmap)
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

        
        ///// <summary>
        ///// bitmap转二进制流
        ///// </summary>
        ///// <param name="bitmap"></param>
        ///// <returns></returns>
        //public static string FileTostring(string FilePath)
        //{
        //    byte[] bytsize = new byte[1024 * 1024 * 5];
        //    using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
        //        while (true)
        //        {
        //            int r = stream.Read(bytsize, 0, bytsize.Length);
        //            //如果读取到的字节数为0，说明已到达文件结尾，则退出while循
        //            if (r == 0)
        //            {
        //                break;
        //            }
        //            string str = Encoding.Default.GetString(bytsize, 0, r);
        //            Console.WriteLine(str);
        //        }
        //    }
        //}




        /// <summary>
        /// 文件转换成二进制流
        /// </summary>
        /// <param name="FilePath">文件路径</param>
        /// <returns></returns>
        private static byte[] FilePathToByte(string FilePath)
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
        public static byte[] BitmapToByte(Bitmap bitmap)
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
        public static byte[] StreanToByte(Stream stream)
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
        public static Bitmap FilePathToBitmap(string Filepath)
        {
            try
            {
                Bitmap bitmap = new Bitmap(Filepath);
                return bitmap;
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
        public static Bitmap StreamToBitmap(Stream stream)
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
        public static Bitmap StringToBitmap(string base64String)
        {
            try
            {
                if (base64String.Length > 0)
                {
                    byte[] arr = Convert.FromBase64String(base64String);
                    using (MemoryStream stream = new MemoryStream(arr))
                    {
                        Bitmap bmp = new Bitmap(stream);
                        return bmp;
                    }
                }
                else
                {
                    return null;
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
        public static Stream StreamToBitmap(Bitmap bitmap)
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
        public static Stream Bitmap2Byte(byte[] bytes)
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
        public static string FileTostring(string filePath)
        {
            //    byte[] bytsize = new byte[1024 * 1024 * 5];
            //    using (FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //    {
            //        while (true)
            //        {
            //            int r = stream.Read(bytsize, 0, bytsize.Length);
            //            //如果读取到的字节数为0，说明已到达文件结尾，则退出while循
            //            if (r == 0)
            //            {
            //                break;
            //            }
            //            string str = Encoding.Default.GetString(bytsize, 0, r);
            //            Console.WriteLine(str);
            //        }
            //    }
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
        public static Stream FilePathToStream(string filePath)
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
        public static void StringToFile(string path, string binary, string filename)
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


        public static string FileStreamToString(FileStream fileStream)
        {
            byte[] bt = new byte[fileStream.Length];
            //file.Read(a, 0, (int)file.Length);
            string myStr = System.Text.Encoding.UTF8.GetString(bt);
            return myStr;
        }

        //public static Stream StringToStream(string filestring)
        //{

        //    MemoryStream stream = new MemoryStream();
        //    StreamWriter writer = new StreamWriter(stream);
        //    writer.Write(filestring);
        //    writer.Flush();
        //    return stream;

        //}
        /// <summary>
        ///string转Stream
        /// </summary>
        /// <param name="filestring">文件string</param>
        /// <returns></returns>
        public static Stream StringToStream(string filestring)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(filestring);

                using (Stream stream = new MemoryStream(bytes))
                {
                    return stream;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        ///string转Stream
        /// </summary>
        /// <param name="filestring">文件string</param>
        /// <returns></returns>
        public static string StreamToString(Stream fileStream)
        {
            try
            {
                StreamReader reader = new StreamReader(fileStream);
                string text = reader.ReadToEnd();
                return text;
            }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}