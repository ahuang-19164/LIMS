using Common.Data;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Conn
{
    public class ApiConnections
    {


        static string filePath = Application.StartupPath;



        /// <summary>
        /// 调用api返回jsonstring ss = HttpPost("http://localhost:41558/api/Demo/PostXXX", "{Code:\"test089\",Name:\"test1\"}");
        /// public static string PostHttpApi(string url, string jsonstr, string type)
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string PostHttpApi(string url)
        {
            try
            {
                Task<string> task = new Task<string>(() =>
                {
                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "text/html,application/xhtml+xml,*/*";
                    request.ContentType = "application/json";
                    request.Method = "POST";//get或者post
                    request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                    //byte[] buffer = encoding.GetBytes(jsonstr);
                    //request.ContentLength = buffer.Length;
                    Stream reqStream = request.GetRequestStream();
                    //reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                    using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                });
                task.Start();
                return task.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连到远程服务，请联系管理员。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }






        /// <summary>
        /// 调用api返回jsonstring ss = HttpPost("http://localhost:41558/api/Demo/PostXXX", "{Code:\"test089\",Name:\"test1\"}");
        /// public static string PostHttpApi(string url, string jsonstr, string type)
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string PostHttpApi(string url, string jsonstr)
        {
            try
            {
                Task<string> task = new Task<string>(() =>
                {
                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "text/html,application/xhtml+xml,*/*";
                    request.ContentType = "application/json";
                    request.Method = "POST";//get或者post
                    if(CommonData.tokenInfo!=null)
                        request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                    byte[] buffer = encoding.GetBytes(jsonstr);
                    request.ContentLength = buffer.Length;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                    using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                });
                task.Start();
                return task.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连到远程服务，请联系管理员。\r\n{ex.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }


        /// <summary>
        /// 调用api返回jsonstring ss = HttpPost("http://localhost:41558/api/Demo/PostXXX", "{Code:\"test089\",Name:\"test1\"}");
        /// public static string PostHttpApi(string url, string jsonstr, string type)
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static void PostDownFileHttpApi(string url, string jsonstr)
        {
            string filepath = "C:\\ExportHost-New\\1.png";
            Task task = new Task(() =>
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);




                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();




                //request.ContentLength = buffer.Length;
                FileStream fs = new FileStream(filepath, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buffer);
                bw.Close();
                fs.Close();




                //FileStream fs=new FileStream("",)
                //using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                //{
                //    return sr.ReadToEnd();
                //}
            });
            task.Start();
        }







        /// <summary>
        /// 调用api返回jsonstring ss = HttpPost("http://localhost:41558/api/Demo/PostXXX", "{Code:\"test089\",Name:\"test1\"}");
        /// public static string GetHttpApi(string url, string type)
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string GetHttpApi(string url)
        {
            try
            {
                Task<string> task = new Task<string>(() =>
                {

                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "text/html,application/xhtml+xml,*/*";
                    request.ContentType = "application/json";
                    request.Method = "GET";//get或者post
                    request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                });
                task.Start();
                return task.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连到远程服务，请联系管理员。\r\n{ex.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }



        /// <summary>
        /// 下载Web图片返回File to string;
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlImageToString(string url)
        {
            WebClient mywebclient = new WebClient();
            byte[] Bytes = mywebclient.DownloadData(url);
            string base64String = Convert.ToBase64String(Bytes);
            return base64String;
        }
        /// <summary>
        /// 下载Web图片返回File to string;
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Bitmap UrlImageToBitmap(string url)
        {
            Bitmap bmp;
            WebClient mywebclient = new WebClient();
            byte[] Bytes = mywebclient.DownloadData(url);
            using (MemoryStream stream = new MemoryStream(Bytes))
            {
                bmp = new Bitmap(stream);
            }
            return bmp;
        }


        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="url">抓取url</param>
        /// <param name="filePath">保存文件名</param>
        /// <param name="oldurl">来源路径</param>
        /// <returns></returns>
        //public static bool HttpDown(string url, string filePath, string oldurl)
        public static bool PostHttpDownFile(string url, string jsonstr, string fileName)
        {

            string fileFullPath = filePath + "\\" + fileName;
            //string fileFullPath = fileName;
            if (System.IO.File.Exists(fileFullPath))
            {
                System.IO.File.Delete(fileFullPath);    //存在则删除
            }

            try
            {
                //FileStream fs = new FileStream(fileFullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                FileStream fs = new FileStream(fileFullPath, FileMode.Create);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();





                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                //System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        /// <summary>
        /// 公共文件下载
        /// </summary>
        /// <param name="fileType">1,流程文件  2,图片文件</param>
        /// <param name="url"></param>
        /// <param name="jsonstr"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool PostBaseDownFile(string fileType,string url, string jsonstr, string fileName)
        {
            string newpath = "";
            switch(fileType)
            {
                case "1":
                    newpath = filePath + "\\flow";
                    break;
                case "2":
                    newpath = filePath + "\\img";
                    break;
                default:
                    break;

            }
            if (!Directory.Exists(newpath))
            {
                Directory.CreateDirectory(newpath);
            }
            string fileFullPath = newpath + "\\" + fileName;
            //string fileFullPath = fileName;
            if (System.IO.File.Exists(fileFullPath))
            {
                System.IO.File.Delete(fileFullPath);    //存在则删除
            }

            try
            {
                //FileStream fs = new FileStream(fileFullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                FileStream fs = new FileStream(fileFullPath, FileMode.Create);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();

                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                //System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                File.Delete(fileFullPath);
                return false;
            }
        }



        /// <summary>
        /// 检验结果图片下载
        /// </summary>
        /// <param name="dirname"></param>
        /// <param name="url"></param>
        /// <param name="jsonstr"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string PostTestDownFile(string dirname, string url, string jsonstr, string fileName)
        {
            string newpath = filePath + "\\TestImg\\" + dirname + "\\" + fileName;
            if (!Directory.Exists(newpath))
            {
                Directory.CreateDirectory(newpath);
            }
            string fileFullPath = newpath + "\\" + fileName;
            //string fileFullPath = fileName;
            if (System.IO.File.Exists(fileFullPath))
            {
                System.IO.File.Delete(fileFullPath);    //存在则删除
            }

            try
            {
                //FileStream fs = new FileStream(fileFullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                FileStream fs = new FileStream(fileFullPath, FileMode.Create);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                //System.IO.File.Move(tempFile, path);
                return newpath;
            }
            catch (Exception ex)
            {
                File.Delete(fileFullPath);
                return "";
            }


        }

        public static bool PostBaseUpFile(string url, string jsonstr)
        {
            try
            {
                Task<string> task = new Task<string>(() =>
                {
                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "text/html,application/xhtml+xml,*/*";
                    request.ContentType = "application/json";
                    request.Method = "POST";//get或者post
                    request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                    byte[] buffer = encoding.GetBytes(jsonstr);
                    request.ContentLength = buffer.Length;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                    using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                });
                task.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连到远程服务，请联系管理员。\r\n{ex.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /// <summary>
        /// 文件预览
        /// </summary>
        /// <param name="url">抓取url</param>
        /// <param name="filePath">保存文件名</param>
        /// <param name="oldurl">来源路径</param>
        /// <returns></returns>
        //public static bool HttpDown(string url, string filePath, string oldurl)
        public static bool PostHttpReportFile(string url, string jsonstr)
        {


            //string rarfilePath = filePath + "\\TempReport.rar";
            //string rarfilePath = filePath + "\\TempReport.pdf";




            string newfileDir = filePath + "\\TempReport";
            string rarfilePath = newfileDir + "\\TempReport.pdf";

            if (!Directory.Exists(newfileDir))
            {
                Directory.CreateDirectory(newfileDir);
            }
            string[] fileName = Directory.GetFiles(newfileDir);
            foreach (string names in fileName)
            {
                File.Delete(names);
            }





            //string newfilePath= newfileDir + "\\TempReport.pdf";
            //if (System.IO.File.Exists(rarfilePath))
            //{
            //    System.IO.File.Delete(rarfilePath);    //存在则删除
            //}
            FileStream fs = new FileStream(rarfilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            try
            {

                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();

                //long a = responseStream.Length;
                if (responseStream != null)
                {
                    //创建本地文件写入流
                    //Stream stream = new FileStream(tempFile, FileMode.Create);
                    byte[] bArr = new byte[1024];
                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        //stream.Write(bArr, 0, size);
                        fs.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    }


                    fs.Close();
                    fs.Dispose();
                    responseStream.Close();
                    responseStream.Dispose();






                    //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
                    //string rarPath = key.GetValue("").ToString();
                    //if(rarPath!="")
                    //{
                    //    //if (File.Exists(newfilePath))
                    //    //    File.Delete(newfilePath);
                    //    Process Process1 = new Process();
                    //    //Process1.StartInfo.FileName = "Winrar.exe";
                    //    Process1.StartInfo.FileName = rarPath;
                    //    Process1.StartInfo.CreateNoWindow = true;
                    //    string cmd = "";
                    //    //if (!string.IsNullOrEmpty(PassWord) && IsCover)
                    //    //    //解压加密文件且覆盖已存在文件( -p密码 )
                    //    //    cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
                    //    //else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                    //    //    //解压加密文件且不覆盖已存在文件( -p密码 )
                    //    //    cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
                    //    //else if (IsCover)
                    //    //    //覆盖命令( x -o+ 代表覆盖已存在的文件)
                    //    //    cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
                    //    //else
                    //    //不覆盖命令( x -o- 代表不覆盖已存在的文件)TempReport.pdf



                    //    cmd = string.Format(" x -o- {0} {1} -y -ibck -iadm", rarfilePath, newfileDir);
                    //    //命令
                    //    Process1.StartInfo.Arguments = cmd;
                    //    Process1.Start();
                    //    Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
                    //                           //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
                    //    if (Process1.ExitCode == 0)
                    //    {
                    //        Process1.Close();
                    //        return true;
                    //    }
                    //    else
                    //    {
                    //        Process1.Close();
                    //        return false;
                    //    }
                    //}
                    return true;
                }


                else
                {
                    fs.Close();
                    fs.Dispose();
                    return false;
                }

            }
            catch (Exception ex)
            {
                fs.Close();
                fs.Dispose();
                return false;
            }


        }

        public static bool PostHttpReportFiles(string url, string jsonstr)
        {


            //string rarfilePath = filePath + "\\TempReport.rar";
            //string rarfilePath = filePath + "\\TempReport.pdf";




            string newfileDir = filePath + "\\TempReport";
            string rarfilePath = newfileDir + "\\TempReport.pdf";

            if (!Directory.Exists(newfileDir))
            {
                Directory.CreateDirectory(newfileDir);
            }
            string[] fileName = Directory.GetFiles(newfileDir);
            foreach (string names in fileName)
            {
                File.Delete(names);
            }





            //string newfilePath= newfileDir + "\\TempReport.pdf";
            //if (System.IO.File.Exists(rarfilePath))
            //{
            //    System.IO.File.Delete(rarfilePath);    //存在则删除
            //}
            FileStream fs = new FileStream(rarfilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            try
            {

                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();

                //long a = responseStream.Length;
                if (responseStream != null)
                {
                    //创建本地文件写入流
                    //Stream stream = new FileStream(tempFile, FileMode.Create);
                    byte[] bArr = new byte[1024];
                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        //stream.Write(bArr, 0, size);
                        fs.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    }


                    fs.Close();
                    fs.Dispose();
                    responseStream.Close();
                    responseStream.Dispose();






                    //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
                    //string rarPath = key.GetValue("").ToString();
                    //if(rarPath!="")
                    //{
                    //    //if (File.Exists(newfilePath))
                    //    //    File.Delete(newfilePath);
                    //    Process Process1 = new Process();
                    //    //Process1.StartInfo.FileName = "Winrar.exe";
                    //    Process1.StartInfo.FileName = rarPath;
                    //    Process1.StartInfo.CreateNoWindow = true;
                    //    string cmd = "";
                    //    //if (!string.IsNullOrEmpty(PassWord) && IsCover)
                    //    //    //解压加密文件且覆盖已存在文件( -p密码 )
                    //    //    cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
                    //    //else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                    //    //    //解压加密文件且不覆盖已存在文件( -p密码 )
                    //    //    cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
                    //    //else if (IsCover)
                    //    //    //覆盖命令( x -o+ 代表覆盖已存在的文件)
                    //    //    cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
                    //    //else
                    //    //不覆盖命令( x -o- 代表不覆盖已存在的文件)TempReport.pdf



                    //    cmd = string.Format(" x -o- {0} {1} -y -ibck -iadm", rarfilePath, newfileDir);
                    //    //命令
                    //    Process1.StartInfo.Arguments = cmd;
                    //    Process1.Start();
                    //    Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
                    //                           //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
                    //    if (Process1.ExitCode == 0)
                    //    {
                    //        Process1.Close();
                    //        return true;
                    //    }
                    //    else
                    //    {
                    //        Process1.Close();
                    //        return false;
                    //    }
                    //}
                    return true;
                }


                else
                {
                    fs.Close();
                    fs.Dispose();
                    return false;
                }

            }
            catch (Exception ex)
            {
                fs.Close();
                fs.Dispose();
                return false;
            }


        }
        /// <summary>
        /// 文件预览
        /// </summary>
        /// <param name="url">抓取url</param>
        /// <param name="filePath">保存文件名</param>
        /// <param name="oldurl">来源路径</param>
        /// <returns></returns>
        //public static bool HttpDown(string url, string filePath, string oldurl)
        public static bool PostHttpReportRar(string url, string jsonstr)
        {


            //string rarfilePath = filePath + "\\TempReport.rar";
            //string rarfilePath = filePath + "\\TempReport.pdf";


            //Task<bool> task = new Task<bool>(() =>
            //{


            string newfileDir = filePath + "\\TempReport";
            string rarfilePath = newfileDir + "\\TempReport.rar";

            if (!Directory.Exists(newfileDir))
            {
                Directory.CreateDirectory(newfileDir);
            }
            string[] fileName = Directory.GetFiles(newfileDir);
            foreach (string names in fileName)
            {
                File.Delete(names);
            }





            //string newfilePath= newfileDir + "\\TempReport.pdf";
            //if (System.IO.File.Exists(rarfilePath))
            //{
            //    System.IO.File.Delete(rarfilePath);    //存在则删除
            //}
            FileStream fs = new FileStream(rarfilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            try
            {

                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();

                //long a = responseStream.Length;
                if (responseStream != null)
                {
                    //创建本地文件写入流
                    //Stream stream = new FileStream(tempFile, FileMode.Create);
                    byte[] bArr = new byte[1024];
                    int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        //stream.Write(bArr, 0, size);
                        fs.Write(bArr, 0, size);
                        size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    }


                    fs.Close();
                    fs.Dispose();
                    responseStream.Close();
                    responseStream.Dispose();






                    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
                    string rarPath = key.GetValue("").ToString();
                    if (rarPath != "")
                    {
                        //if (File.Exists(newfilePath))
                        //    File.Delete(newfilePath);
                        Process Process1 = new Process();
                        //Process1.StartInfo.FileName = "Winrar.exe";
                        Process1.StartInfo.FileName = rarPath;
                        Process1.StartInfo.CreateNoWindow = true;
                        string cmd = "";
                        //if (!string.IsNullOrEmpty(PassWord) && IsCover)
                        //    //解压加密文件且覆盖已存在文件( -p密码 )
                        //    cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
                        //else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                        //    //解压加密文件且不覆盖已存在文件( -p密码 )
                        //    cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
                        //else if (IsCover)
                        //    //覆盖命令( x -o+ 代表覆盖已存在的文件)
                        //    cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
                        //else
                        //不覆盖命令( x -o- 代表不覆盖已存在的文件)TempReport.pdf



                        cmd = string.Format(" x -o- {0} {1} -y -ibck -iadm", rarfilePath, newfileDir);
                        //命令
                        Process1.StartInfo.Arguments = cmd;
                        Process1.Start();
                        Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
                                               //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
                        if (Process1.ExitCode == 0)
                        {
                            Process1.Close();
                            return true;
                        }
                        else
                        {
                            Process1.Close();
                            return false;
                        }
                    }
                    return true;
                }


                else
                {
                    fs.Close();
                    fs.Dispose();
                    return false;
                }

            }
            catch (Exception ex)
            {
                fs.Close();
                fs.Dispose();
                return false;
            }


            //});
            //task.Wait();
            //return task.Result;







        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static string PostUpFile(string url, string jsonstr)
        {
            try
            {
                Task<string> task = new Task<string>(() =>
                {
                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "text/html,application/xhtml+xml,*/*";
                    request.ContentType = "application/json";
                    request.Method = "POST";//get或者post
                    request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                    byte[] buffer = encoding.GetBytes(jsonstr);
                    request.ContentLength = buffer.Length;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                    using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                });
                task.Start();
                return task.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连到远程服务，请联系管理员。\r\n{ex.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="jsonstr">请求参数</param>
        ///// <param name="filetype">文件类型</param>
        ///// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static string PostDownFile(string url, string jsonstr)
        {

            //string fileFullPath = filePath + "\\" + fileName;
            ////string fileFullPath = fileName;
            //if (System.IO.File.Exists(fileFullPath))
            //{
            //    System.IO.File.Delete(fileFullPath);    //存在则删除
            //}
            try
            {
                Task<string> task = new Task<string>(() =>
                {
                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "text/html,application/xhtml+xml,*/*";
                    request.ContentType = "application/json";
                    request.Method = "POST";//get或者post
                    request.Headers.Add("Authorization", CommonData.tokenInfo.token_type+" " + CommonData.tokenInfo.token);
                    byte[] buffer = encoding.GetBytes(jsonstr);
                    request.ContentLength = buffer.Length;
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                    using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                    {
                        return sr.ReadToEnd();
                    }
                });
                task.Start();
                return task.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法连到远程服务，请联系管理员。\r\n{ex.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }



    }
}
