using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ms.jikongHandle
{
    public class xianjkApi
    {
        public static string jkUrl = "https://yqpt.xa.gov.cn/prod-api/naat";
        static string Authorization = @"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjdXN0b21Vc2VySWQiOjEzMDc4NjIwMDM0MjcxODQ2NDAsImV4cCI6MTYwMTU0ODAxNn0.ARPcBBiEfSi4EENRdEE9jTrsHzwbJBQ0QUiXgf55VaU";

        /// <summary>
        /// 样本信息获取
        /// {
        /// “userName”:”XXX”, // 用户名
        /// “password”:”x” //密码
        /// }
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static void PostApiXiAnJK(string jsonstr)
        {
            string NewUrl = jkUrl + "/open/api/getToken";
            Task<string> task = new Task<string>(() =>
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NewUrl);//webrequest请求api地址
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post
                //byte[] buffer = encoding.GetBytes(jsonstr);
                using (var postStream = new StreamWriter(request.GetRequestStream()))
                {
                    postStream.Write(jsonstr);
                }

                //request.ContentLength = buffer.Length;
                //Stream reqStream = request.GetRequestStream();
                //reqStream.Write(Buffer, 0, buffer.Length);
                //reqStream.Close();
                using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            });
            task.Start();
            string a = task.Result;
            var x = JsonConvert.DeserializeObject<JObject>(task.Result);
            if (x["code"].ToString() == "200")
            {
                string resMag = x["data"].ToString();
                Authorization = resMag;
            }
            else
            {
                MessageBox.Show($"疾控服务器链接错误！\r\n{x["msg"].ToString()}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 样本信息获取
        /// {
        /// “code”:”HJ10000000” // 试管号
        /// }
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string getDataByCode(string jsonstr)
        {
            string NewUrl = jkUrl + $"/open/api/getDataByCode?code={jsonstr}";
            Task<string> task = new Task<string>(() =>
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NewUrl);//webrequest请求api地址
                request.Headers.Add("Authorization", Authorization);
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post


                //using (var postStream = new StreamWriter(request.GetRequestStream()))
                //{
                //    postStream.Write(jsonstr);
                //}


                //byte[] buffer = encoding.GetBytes(jsonstr);
                //request.ContentLength = buffer.Length;
                //Stream reqStream = request.GetRequestStream();
                //reqStream.Write(buffer, 0, buffer.Length);
                //reqStream.Close();
                using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            });
            task.Start();
            return task.Result;
        }

        /// <summary>
        /// 根据试管编号录入（核酸）结果
        ///[{
        /// “code”:”HJ10000000”, //试管编号
        /// “status”:1 //试管状态 1：阴性 2：阳性 3：未检出
        ///}]
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string insertResultByCode(string jsonstr)
        {
            string NewUrl = jkUrl + "/open/api/insertResultByCode";
            Task<string> task = new Task<string>(() =>
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NewUrl);//webrequest请求api地址
                request.Headers.Add("Authorization", Authorization);
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


        /// <summary>
        /// 调用api返回jsonstring ss = HttpPost("http://localhost:41558/api/Demo/PostXXX", "{Code:\"test089\",Name:\"test1\"}");
        /// 批量主动推送核酸检测结果
        /// [{
        /// "userName":"张三",//姓名
        /// "sex":"男",//性别
        /// "cardType":1,//证件类型 1 身份证 2其他
        /// "cardNum":"610629198505214415",//证件号码
        /// "phone":"18629386584",//联系方式
        /// "fromOrg":"XXX 医院",//送检单位
        /// "collectTime":"2020-10-09 10:30:00",//采样时间
        /// "collectPart":"咽部",//采样部位
        /// "detOrg":"XXX 检测机构",//检测机构
        /// "recieveTime":"2020-10-09 10:50:00",//接收时间
        /// "detResult":"阴性",//检测结果
        /// "detTime":"2020-10-09 11:50:00",//检测时间
        /// "detMethod":"检测方法",//检测方法（选填）
        /// "detProgram":"检测项目",//检测项目（选填）
        /// "detUser":"李四",//检验者（选填）
        /// "approveUser":"王五",//审核者（选填）
        /// "reportTime":"2020-10-09 
        ///12:50:00"//报告时间（选填）
        ///}]
        /// </summary>
        /// <param name="url">api地址</param>
        /// <param name="jsonstr">接收参数"{Code:\"test089\",Name:\"test1\"}"</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static string batchInsertNucResult(string jsonstr)
        {
            string NewUrl = jkUrl + "/open/api/batchInsertNucResult";
            Task<string> task = new Task<string>(() =>
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NewUrl);//webrequest请求api地址
                request.Headers.Add("Authorization", Authorization);
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/json";
                request.Method = "POST";//get或者post

                //using (var postStream = new StreamWriter(request.GetRequestStream()))
                //{
                //    postStream.Write(jsonstr);
                //}


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
    }
}
