using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpdate
{
    public class ApiHelper
    {
        //static string filePath = Application.StartupPath;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">抓取url</param>
        /// <param name="filePath">保存文件名</param>
        /// <param name="oldurl">来源路径</param>
        /// <returns></returns>
        //public static bool HttpDown(string url, string filePath, string oldurl)
        public static bool PostHttpDownFile(string url, string jsonstr, string fileName)
        {
            string filePath = Application.StartupPath;
            //GuidInfo guidInfo = new GuidInfo();
            //guidInfo.TsqlInfo = jsonstr;
            //string sr = JsonConvert.SerializeObject(guidInfo);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string fileFullPath = filePath + "\\" + fileName;
            string[] filePaths = fileName.Split('\\');
            if (filePaths.Length > 0)
            {
                for (int i = 0; i < filePaths.Length - 1; i++)
                {
                    filePath += $"\\{filePaths[i]}";
                }
            }


            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);    //存在则删除
            }
            if (System.IO.File.Exists(fileFullPath))
            {
                System.IO.File.Delete(fileFullPath);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(fileFullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                Encoding encoding = Encoding.UTF8;
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                byte[] buffer = encoding.GetBytes(jsonstr);
                request.ContentLength = buffer.Length;
                if (request.ContentLength > 0)
                {


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

                }
                else
                {
                    fs.Close();
                }


                //System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        /// <summary>
        /// 通用Post请求
        /// </summary>
        /// <param name="Controller">控制器名称</param>
        /// <param name="JsonStr">接收参数"{Code:\"test089\",Name:\"test1\"}</param>
        /// <returns></returns>
        public static WebApiCallBack postInfo(string Controller, object info)
        {
            string JsonStr = JsonHelper.SerializeObjct(info);
            string str = PostHttpApi(Controller, JsonStr);
            if (str != "")
            {
                WebApiCallBack jm = JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return jm;
            }
            else
            {
                WebApiCallBack jm = new WebApiCallBack();
                return jm;
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
