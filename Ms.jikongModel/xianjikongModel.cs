using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.jikongModel
{

    public class XiAnUserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }



    public class getDataByCode
    {
        public string msg { get; set; }
        public string code { get; set; }
        public sampleInfo data { get; set; }
    }
    public class sampleInfo 
    {
        /// <summary>
        /// 试管编号
        /// </summary>
        public string tubeCode { get; set; }
        /// <summary>
        /// 接收机构 id
        /// </summary>
        public string receiveOrgId { get; set; }
        /// <summary>
        /// 检测机构名称
        /// </summary>
        public string receiveOrgName { get; set; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public string receiveTime { get; set; }
        /// <summary>
        /// 检测时间
        /// </summary>
        public string checkTime { get; set; }
        /// <summary>
        /// 检测结果 1 阴性 2 阳性 3 未检出 9 未检测
        /// </summary>
        public string checkResult { get; set; }
        /// <summary>
        /// 结果信息
        /// </summary>
        public sampleResult receiveVO { get; set; }
        /// <summary>
        /// 人员信息
        /// </summary>
        public string person { get; set; }

    }
    public class sampleResult
    {
        /// <summary>
        /// 采集部位：1：口咽 2：鼻咽 3：呼吸道 4：支气管 5：肺部 6 血清
        /// </summary>
        public string collectionPart { get; set; }
        /// <summary>
        /// 采集类型 1：上呼吸道 2：下呼吸道 3：静脉采血
        /// </summary>
        public string collectionType { get; set; }
        /// <summary>
        /// 试管采集样本数量
        /// </summary>
        public int collectionNum { get; set; } = 10;
        /// <summary>
        /// 采样开始时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 采样结束时间
        /// </summary>
        public string endTime { get; set; }
        public string collectionLimit { get; set; }
    }
    public class personInfo
    {
        /// <summary>
        /// 被采集人员姓名
        /// </summary>
        public string personName { get; set; }
        /// <summary>
        /// 被采集人员手机
        /// </summary>
        public string personPhone { get; set; }
        /// <summary>
        /// 被采集人员证件号码
        /// </summary>
        public string idCard { get; set; }
        /// <summary>
        /// 被采集人员关系 1: 本人、2:子女、3:父母、4:亲属、5:其他
        /// </summary>
        public string relation { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
    }
    #region 根据试管编号录入（核酸）结果
    /// <summary>
    /// 根据试管编号录入（核酸）结果
    /// 标准 List<Map> json 数据入参
    /// </summary>
    public class insertResultByCode
    {
        /// <summary>
        /// ”试管编号”
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 试管状态 1：阴性 2：阳性 3：未检出
        /// </summary>
        public string status { get; set; }

    }


    #endregion

    #region 批量主动推送核酸检测结果
    /// <summary>
    /// /open/api/batchInsertNucResult
    /// 标准 List<Map>json 数据入参：
    /// </summary>
    public class batchInsertNucResult
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string cardType { get; set; } = "0";
        /// <summary>
        /// 证件号码
        /// </summary>
        public string cardNum { get; set; }
        /// <summary>
        /// /联系方式
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 送检单位
        /// </summary>
        public string fromOrg { get; set; }
        /// <summary>
        /// 采样时间
        /// </summary>
        public string collectTime { get; set; }
        /// <summary>
        /// 采样部位
        /// </summary>
        public string collectPart{ get; set; }
        /// <summary>
        /// 检测机构
        /// </summary>
        public string detOrg { get; set; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public string recieveTime { get; set; }
        /// <summary>
        /// 检测结果
        /// </summary>
        public string detResult { get; set; }
        /// <summary>
        /// 检测时间
        /// </summary>
        public string detTime { get; set; }

        /// <summary>
        /// 检测方法（选填）
        /// </summary>
        public string detMethod { get; set; }
        /// <summary>
        /// 检测项目（选填）
        /// </summary>
        public string detProgram { get; set; }
        /// <summary>
        /// 检验者（选填）
        /// </summary>
        public string detUser { get; set; }
        /// <summary>
        /// 审核者（选填）
        /// </summary>
        public string approveUser { get; set; }
        /// <summary>
        /// 报告时间（选填）
        /// </summary>
        public string reportTime { get; set; }
    }
    #endregion
}
