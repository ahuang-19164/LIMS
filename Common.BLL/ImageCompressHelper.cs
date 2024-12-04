using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Common.BLL
{
    public class ImageCompressHelper
    {
        /// <summary>
        /// 通用无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static bool CommImageCompress(string sFile, string dFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            //如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true
            FileInfo firstFileInfo = new FileInfo(sFile);
            if (sfsc == true && firstFileInfo.Length < size * 1024)
            {
                firstFileInfo.CopyTo(dFile);
                return true;
            }
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(dFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        CommImageCompress(sFile, dFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
        /// <summary>
        /// 通用无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static Bitmap ImageCompress(Bitmap bitmap, int flag = 10, int size = 1200, bool sfsc = true)
        {

            int newW = bitmap.Width < size ? bitmap.Width : size;
            int newH = int.Parse(Math.Round(bitmap.Height * (double)newW / bitmap.Width).ToString());
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, newW, newH), new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
                g.Dispose();
                //以下代码为保存图片时，设置压缩质量
                ImageFormat tFormat = bitmap.RawFormat;
                EncoderParameters ep = new EncoderParameters();
                long[] qy = new long[1];
                qy[0] = flag;//设置压缩的比例1-100
                EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
                ep.Param[0] = eParam;
                return b;



                //try
                //{
                //    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageDecoders();
                //    ImageCodecInfo jpegICIinfo = null;
                //    for (int x = 0; x < arrayICI.Length; x++)
                //    {
                //        if (arrayICI[x].FormatDescription.Equals("png"))
                //        {
                //            jpegICIinfo = arrayICI[x];
                //            break;
                //        }
                //    }
                //    if (jpegICIinfo != null)
                //        bitmap.Save(outPath, jpegICIinfo, ep);
                //    else
                //        bitmap.Save(outPath, tFormat);
                //    iSource.Dispose();
                //    return b;
                //}
                //catch
                //{
                //    //iSource.Dispose();
                //    return null;
                //}
            }
            catch (Exception)
            {
                return null;
            }











            //int dHeight = bitmap.Height / 2;
            //int dWidth = bitmap.Width / 2;
            //int sW = 0, sH = 0;
            ////按比例缩放
            //Size tem_size = new Size(dWidth, dHeight);
            //if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            //{
            //    if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
            //    {
            //        sW = dWidth;
            //        sH = (dWidth * tem_size.Height) / tem_size.Width;
            //    }
            //    else
            //    {
            //        sH = dHeight;
            //        sW = (tem_size.Width * dHeight) / tem_size.Height;
            //    }
            //}
            //else
            //{
            //    sW = tem_size.Width;
            //    sH = tem_size.Height;
            //}

            //Bitmap ob = new Bitmap(dWidth, dHeight);
            //Graphics g = Graphics.FromImage(ob);

            //g.Clear(Color.WhiteSmoke);
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.DrawImage(bitmap, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            //g.Dispose();
            ////以下代码为保存图片时，设置压缩质量
            //EncoderParameters ep = new EncoderParameters();
            //long[] qy = new long[1];
            //qy[0] = flag;//设置压缩的比例1-100
            //EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            //ep.Param[0] = eParam;

            //return ob;

        }

        /// <summary> 
        /// 按照指定大小缩放图片 最小800
        /// </summary> 
        /// <param name="srcImage"></param> 
        /// <param name="iWidth"></param> 
        /// <param name="iHeight"></param> 
        /// <returns></returns> 
        public static Bitmap SizeImage(Bitmap srcImage, int iWidth = 500, int iHeight = 500)
        {
            try
            {
                double rw = srcImage.Width;
                double rh = srcImage.Height;
                for (double w = srcImage.Width; w >= 800;)
                {
                    rw = rw * 0.9;
                    rh = rh * 0.9;
                    w = rw * 0.9;
                }
                // 要保存到的图片 
                Bitmap b = new Bitmap(Convert.ToInt32(rw), Convert.ToInt32(rh));
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(srcImage, new Rectangle(0, 0, Convert.ToInt32(rw), Convert.ToInt32(rh)), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary> 
        /// 按照指定大小缩放图片 
        /// </summary> 
        /// <param name="srcImage"></param> 
        /// <param name="iWidth"></param> 
        /// <param name="iHeight"></param> 
        /// <returns></returns> 
        public static Bitmap SizeImage32(Bitmap srcImage, int iWidth = 32, int iHeight = 32)
        {
            try
            {
                double rw = srcImage.Width;
                double rh = srcImage.Height;
                for (double w = srcImage.Width; w >= 32;)
                {
                    rw = rw * 0.9;
                    rh = rh * 0.9;
                    w = rw * 0.9;
                }
                // 要保存到的图片 
                Bitmap b = new Bitmap(Convert.ToInt32(rw), Convert.ToInt32(rh));
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(srcImage, new Rectangle(0, 0, Convert.ToInt32(rw), Convert.ToInt32(rh)), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
