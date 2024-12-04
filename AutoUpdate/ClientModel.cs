using System.Collections.Generic;

namespace AutoUpdate
{


    /// <summary>
    ///     微信接口回调Json实体
    /// </summary>
    public class WebApiCallBack
    {
        /// <summary>
        ///     请求接口返回说明
        /// </summary>
        public string methodDescription { get; set; }


        /// <summary>
        ///     提交数据
        /// </summary>
        public object otherData { get; set; } = null;

        /// <summary>
        ///     状态码
        /// </summary>
        public bool status { get; set; } = false;

        /// <summary>
        ///     信息说明。
        /// </summary>
        public string msg { get; set; } = "接口响应成功";

        /// <summary>
        ///返回数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        ///返回编码 0,成功 1，失败,2,错误
        /// </summary>
        public int code { get; set; } = 0;
    }






    /// <summary>
    /// 给客户端发送的客户端信息
    /// </summary>
    public class clientModel
    {
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string Name { get; set; }
        public string urlPath { get; set; }
        public string Version { get; set; }
        public string userName { get; set; }
        public string userToken { get; set; }
        public List<FileInfoModel> fileInfo { get; set; }
        public string msg { get; set; }
        public string createTime { get; set; }
    }
    /// <summary>
    /// 文件信息
    /// </summary>
    public class FileInfoModel
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件版本
        /// </summary>
        public string FileFullName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
    public class DownFileModel
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密钥
        /// </summary>
        public string UserToken { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件存储地址
        /// </summary>
        public string FilePath { get; set; }
    }
}
