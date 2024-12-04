using System.IO;

namespace WorkComm.Clients
{
    public static class FileHelper
    {
        /// <summary>
        /// 复制大文件
        /// </summary>
        /// <param name="fromPath">源文件的路径</param>
        /// <param name="toPath">文件保存的路径</param>
        /// <param name="eachReadLength">每次读取的长度</param>
        /// <returns>是否复制成功</returns>
        public static bool CopyFile(string fromPath, string toPath, int eachReadLength)
        {
            //将源文件 读取成文件流
            FileStream fromFile = new FileStream(fromPath, FileMode.Open, FileAccess.Read);
            //已追加的方式 写入文件流
            FileStream toFile = new FileStream(toPath, FileMode.Append, FileAccess.Write);
            //实际读取的文件长度
            int toCopyLength = 0;
            //如果每次读取的长度小于 源文件的长度 分段读取
            if (eachReadLength < fromFile.Length)
            {
                byte[] buffer = new byte[eachReadLength];
                long copied = 0;
                while (copied <= fromFile.Length - eachReadLength)
                {
                    toCopyLength = fromFile.Read(buffer, 0, eachReadLength);
                    fromFile.Flush();
                    toFile.Write(buffer, 0, eachReadLength);
                    toFile.Flush();
                    //流的当前位置
                    toFile.Position = fromFile.Position;
                    copied += toCopyLength;

                }
                int left = (int)(fromFile.Length - copied);
                toCopyLength = fromFile.Read(buffer, 0, left);
                fromFile.Flush();
                toFile.Write(buffer, 0, left);
                toFile.Flush();

            }
            else
            {
                //如果每次拷贝的文件长度大于源文件的长度 则将实际文件长度直接拷贝
                byte[] buffer = new byte[fromFile.Length];
                fromFile.Read(buffer, 0, buffer.Length);
                fromFile.Flush();
                toFile.Write(buffer, 0, buffer.Length);
                toFile.Flush();

            }
            fromFile.Close();
            toFile.Close();
            return true;
        }
    }
}
