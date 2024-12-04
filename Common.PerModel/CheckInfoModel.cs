using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PerModel
{
    /// <summary>
    /// 查询审核信息
    /// </summary>
    public class CheckSelectModel
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
        /// 录入表明
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 0.系统接收，1，微信接收，2，A接口接收
        /// </summary>
        public int checkType { get; set; } = 0;
        /// <summary>
        /// 条码号
        /// </summary>
        public List<string> barcode { get; set; }
        /// <summary>
        /// 外部条码号
        /// </summary>
        public string hosbarcode { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 样本状态
        /// </summary>
        public string sampleState { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string groupNO { get; set; }
        /// <summary>
        /// 录入人员
        /// </summary>
        public string entryUserName { get; set; }
        /// <summary>
        /// 0.系统录入，1.疾控导入，2.微信导入
        /// </summary>
        public int connstate { get; set; }
    }
    /// <summary>
    /// 提交样核信息
    /// </summary>
    public class CheckInfoModel
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
        /// 0.系统接收，1，微信接收，2，A接口接收
        /// </summary>
        public int checkType { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public List<CheckSampleInfoModel> checkSampleInfos { get; set; }

    }
    /// <summary>
    /// 提交样本审核信息
    /// </summary>
    public class CheckSampleInfoModel
    {
        public int id { get; set; } = 0;
        public int perid { get; set; } = 0;
        public int testid { get; set; } = 0;
        public string barcode { get; set; }
    }
    /// <summary>
    /// 返回样本审核信息
    /// </summary>
    public class ReCheckeModel
    {
        /// <summary>
        /// 返回信息编号0.失败，1.成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 二级条码信息
        /// </summary>
        public List<CheckGroupBarcode> groupcodeInfo { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
    }
    /// <summary>
    /// 二级条码信息
    /// </summary>
    public class CheckGroupBarcode
    {

        public int id { get; set; }
        /// <summary>
        /// 样本编号
        /// </summary>
        public int sampleID { get; set; } = 0;
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string hospitalNames { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 病人性别
        /// </summary>
        public string patientSexNames { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string ageYear { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string groupNO { get; set; }
        /// <summary>
        ///组合项目名称
        /// </summary>
        public string groupName { get; set; }
        /// <summary>
        /// 组合项目编码
        /// </summary>
        public string groupCodes { get; set; }
        /// <summary>
        /// 组合项目名称
        /// </summary>
        public string groupNames { get; set; }
    }
}
