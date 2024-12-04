using System.Collections.Generic;

namespace Common.Model
{
    /// <summary>
    /// 客户端发来的客户端信息
    /// </summary>
    public class ClientInfoModel
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
        /// 提交信息状态0,错误信息 1,检验客户端。2为报告客户端
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 客户端版本
        /// </summary>
        public string Version { get; set; }

    }




    /// <summary>
    /// 更新记录信息
    /// </summary>
    public class UpInfoModel
    {
        /// <summary>
        /// 更新文件状态  0 成功 1失败
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 更新信息
        /// </summary>
        public clientModel clientInfo { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
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
        /// <summary>
        /// 更新访问地址
        /// </summary>
        public string urlPath { get; set; }
        /// <summary>
        /// 更新版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 授权信息
        /// </summary>
        public string userToken { get; set; }
        /// <summary>
        /// 文件信息内容
        /// </summary>
        public List<FileInfoModel> fileInfo { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
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

    /// <summary>
    /// 文件传输对象
    /// </summary>
    public class FileModel
    {
        /// <summary>
        /// 样本信息状态0 获取报告成功 1 获取报告失败
        /// </summary>
        public int code { get; set; } = 1;
        /// <summary>
        /// 下载文件名称
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// 1.流程文件（xml） 2.图片文件
        /// </summary>
        public string fileType { get; set; }
        /// <summary>
        /// 文档名称（数据库表名称）
        /// </summary>
        public string dirname { get; set; }
        /// <summary>
        /// 文件内容字符串
        /// </summary>
        public object fileString { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>

        public string msg { get; set; }
    }
}
