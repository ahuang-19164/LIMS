using System;
using System.IO;

namespace Common.Log
{
    public static class CommonLogText
    {
        public static void WriteLog(string LogType, string LogValue)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"/log";
            if (Directory.Exists(path) == false)//如果不存
            {
                Directory.CreateDirectory(path);
            }
            string pathfile = System.IO.Directory.GetCurrentDirectory() + @"/log/" + LogType + ".txt";
            if (File.Exists(pathfile) == false)
            {
                File.Create(pathfile).Close();
            }
            //FileStream fs = new FileStream(pathfile, FileMode.Open, FileAccess.Write);
            //StreamWriter sr = new StreamWriter(pathfile);//创建新的文件写入
            using (StreamWriter sw = File.AppendText(pathfile))//源文件追加
            {
                sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + LogValue + "\r\n");
                sw.Close();
                sw.Dispose();
            }



            //sr.WriteLine(jm.data.ToString());//开始写入值
            //sr.Close(); sr.Dispose();
            //fs.Close(); fs.Dispose();
        }
    }
}
