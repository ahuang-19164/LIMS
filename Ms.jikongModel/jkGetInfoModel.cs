using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.jikongModel
{

    public class EntryInfo
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
        /// 检验接收信息集合
        /// </summary>
        public EntrysampleInfo sampleinfo { get; set; }

    }
    public class EntrysampleInfo
    {
        public int id { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 外部条码
        /// </summary>
        public string hospitalBarcode { get; set; }
        /// <summary>
        /// 试管架号
        /// </summary>
        public string frameNo { get; set; } = "";
        /// <summary>
        /// 采样日期
        /// </summary>
        public string sampleTime { get; set; }
        /// <summary>
        /// 接收日期
        /// </summary>
        public string receiveTime { get; set; }
        /// <summary>
        /// 采样地点
        /// </summary>
        public string sampleLocation { get; set; }
        /// <summary>
        /// 样本类型
        /// </summary>
        public string sampleTypeNO { get; set; }
        /// <summary>
        /// 样本类型名称
        /// </summary>
        public string sampleTypeNames { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string creater { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string clientCode { get; set; }
        /// <summary>
        /// 客户客户名称
        /// </summary>
        public string clientName { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string applyCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string applyName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 性别编号1男2女3其他
        /// </summary>
        public string patientSexNO { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string patientSexNames { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string ageYear { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string patientPhone { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string patientCardNo { get; set; }
        /// <summary>
        /// 其他证件号
        /// </summary>
        public string passportNo { get; set; }
        /// <summary>
        /// 现居住地址
        /// </summary>
        public string patientAddress { get; set; }

        /// <summary>
        /// 采样状态 1单采 2混采
        /// </summary>
        public int sampleType { get; set; } = 0;

    }



    #region 接收信息
    public class jkinfoModel
    {
        public string msg { get; set; }
        public string code { get; set; }
        public Entrytubeinfo data { get; set; }
    }

    public class Entrytubeinfo
    {

        public string tubeCode { get; set; }
        public string receiveOrgId { get; set; }
        public string receiveOrgName { get; set; }
        public string receiveTime { get; set; }
        public string checkTime { get; set; }
        public string checkResult { get; set; }
        public string collectLocationName { get; set; }
        public EntrytestInfo receiveVO { get; set; }
        /// <summary>
        /// 人员信息
        /// </summary>
        public personInfo person { get; set; }
        public personListInfo personList { get; set; }


    }
    public class EntrytestInfo
    {
        /// <summary>
        /// 样本条码号
        /// </summary>
        public string collectionPart { get; set; }
        public string collectionType { get; set; }
        /// <summary>
        /// 采样管样本数量
        /// </summary>
        public string collectionNum { get; set; }
        public string collectionLimit { get; set; }
        /// <summary>
        /// 采样时间
        /// </summary>
        public string startTime { get; set; }
        public string endTime { get; set; }
        /// <summary>
        /// 采样地点
        /// </summary>
        public string collectLocationName { get; set; }
        public string tubeCode { get; set; }
    }

    public class EntrypersonInfo
    {
        public string tubeCode { get; set; }
        public string personId { get; set; }
        public string bodyParts { get; set; }
        public string respiratoryTractType { get; set; }
        public string personName { get; set; }
        public string personPhone { get; set; }
        public string idCard { get; set; }
        public string relation { get; set; }
        public string collectTime { get; set; }
        /// <summary>
        /// 性别1男2女3其他
        /// </summary>
        public string sex { get; set; }
        public string cardType { get; set; }
        public string age { get; set; }
    }
    public class personListInfo
    {

    }
    #endregion

}
