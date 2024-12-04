using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TestModel.Result
{
    /// <summary>
    /// 蜡块信息类
    /// </summary>
    public class BlockInfoModel
    {
        public bool dstate { get; set; }
        /// <summary>
        /// 制片状态0新增，1取材，2包埋，3切片,4反包埋，5反切片，6退回取材
        /// </summary>
        public int state { get; set; } = 0;
        public DateTime createTime { get; set; }
        public int id { get; set; } = 0;
        public string barcode { get; set; }
        public string blockNo { get; set; }
        public string operater { get; set; }
        public string operatTime { get; set; }
        public string pathologyNo { get; set; }
        public int perid { get; set; } = 0;
        public string recorder { get; set; }
        public string remark { get; set; }
        public int testid { get; set; } = 0;

        public string bmPerson { get; set; }
        public string bmTime { get; set; }

        public string qpPerson { get; set; }
        public string qpTime { get; set; }
    }

    /// <summary>
    /// 图片信息
    /// </summary>
    public class PictureInfoModel
    {
        /// <summary>
        /// 病例编号
        /// </summary>
        public string pathologyNo { get; set; }
        /// <summary>
        /// 图片类型1 取材图片，2阅片彩图
        /// </summary>
        public string ClassNo { get; set; }
        /// <summary>
        /// 图片类型名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 染色倍数
        /// </summary>
        public string PictureDye { get; set; }
        /// <summary>
        /// 图片信息
        /// </summary>
        public string filestring { get; set; }
        /// <summary>
        /// 检验id
        /// </summary>
        public int testid { get; set; } = 0;


        /// <summary>
        /// 录入id
        /// </summary>
        public int perid { get; set; } = 0;

        /// <summary>
        /// 图片名称
        /// </summary>
        public string PictureNames { get; set; }

    }

    /// <summary>
    /// 组织病理
    /// </summary>
    public class PathnologyInfoModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 专业组编号
        /// </summary>
        public string groupNO { get; set; }
        /// <summary>
        /// 病变描述
        /// </summary>
        public string DescriptionLesions { get; set; }
        /// <summary>
        /// 病理备注
        /// </summary>
        public string diagnosisRemark { get; set; }
        /// <summary>
        /// 原单位诊断
        /// </summary>
        public string primaryDiagnosis { get; set; }
        /// <summary>
        /// 肉眼可见
        /// </summary>
        public string EyeVisible { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public string PathologyNo { get; set; }
        /// <summary>
        /// 病理诊断
        /// </summary>
        public string pathologicDiagnosis { get; set; }
        /// <summary>
        /// 免疫组化结果
        /// </summary>
        public string ihcResult { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public string PictureCode { get; set; }
        /// <summary>
        /// 样本ID
        /// </summary>
        public int testid { get; set; } = 0;


        /// <summary>
        /// 录入ID
        /// </summary>
        public int perid { get; set; } = 0;

        /// <summary>
        /// 检验唯一值ID
        /// </summary>
        public string sampleID { get; set; } = "";
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 图片信息集合
        /// </summary>
        public List<PictureInfoModel> ListPicture { get; set; }


        /// <summary>
        /// 蜡块信息集合
        /// </summary>
        public List<BlockInfoModel> ListBlock { get; set; }




    }

    /// <summary>
    /// 瓜片信息
    /// </summary>
    public class ScreenInfoModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string Barcode { get; set; }
        public string groupNO { get; set; }
        /// <summary>
        /// 病变描述
        /// </summary>
        public string descriptionLesions { get; set; }
        /// <summary>
        /// 病理备注
        /// </summary>
        public string diagnosisRemark { get; set; }
        /// <summary>
        /// 原单位诊断
        /// </summary>
        public string primaryDiagnosis { get; set; }
        /// <summary>
        /// 肉眼可见
        /// </summary>
        public string eyeVisible { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public string pathologyNo { get; set; }
        /// <summary>
        /// 病理诊断
        /// </summary>
        public string diagnosis { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public string PictureCode { get; set; }
        /// <summary>
        /// 样本ID
        /// </summary>
        public int testid { get; set; } = 0;
        /// <summary>
        ///录入ID
        /// </summary>
        public int perid { get; set; } = 0;

        /// <summary>
        /// 检验唯一值ID
        /// </summary>
        public string sampleID { get; set; } = "";
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 图片信息集合
        /// </summary>
        public List<PictureInfoModel> ListPicture { get; set; }


    }

    /// <summary>
    /// 细胞病理（TCT）
    /// </summary>
    public class TCTInfoModel
    {
        public bool State { get; set; }
        public bool TCT1 { get; set; }
        public bool TCT10 { get; set; }
        public bool TCT11 { get; set; }
        public bool TCT12 { get; set; }
        public bool TCT13 { get; set; }
        public bool TCT14 { get; set; }
        public bool TCT15 { get; set; }
        public bool TCT16 { get; set; }
        public bool TCT17 { get; set; }
        public bool TCT18 { get; set; }
        public bool TCT19 { get; set; }
        public bool TCT2 { get; set; }
        public bool TCT20 { get; set; }
        public bool TCT21 { get; set; }
        public bool TCT22 { get; set; }
        public bool TCT23 { get; set; }
        public bool TCT24 { get; set; }
        public bool TCT25 { get; set; }
        public bool TCT26 { get; set; }
        public bool TCT27 { get; set; }
        public bool TCT28 { get; set; }
        public bool TCT29 { get; set; }
        public bool TCT3 { get; set; }
        public bool TCT30 { get; set; }
        public bool TCT31 { get; set; }
        public bool TCT32 { get; set; }
        public bool TCT33 { get; set; }
        public bool TCT34 { get; set; }
        public bool TCT35 { get; set; }
        public bool TCT36 { get; set; }
        public bool TCT37 { get; set; }
        public bool TCT38 { get; set; }
        public bool TCT39 { get; set; }
        public bool TCT4 { get; set; }
        public bool TCT40 { get; set; }
        public bool TCT5 { get; set; }
        public bool TCT6 { get; set; }
        public bool TCT7 { get; set; }
        public bool TCT8 { get; set; }
        public bool TCT9 { get; set; }
        public string Barcode { get; set; }
        public string groupNO { get; set; }
        /// <summary>
        /// 肉眼可见
        /// </summary>
        public string eyeVisible { get; set; }
        /// <summary>
        /// 镜下可见
        /// </summary>
        public string descriptionLesions { get; set; }


        public string diagnosis { get; set; }
        public string diagnosisRemark { get; set; }
        public string NO { get; set; }
        public string PictureCode { get; set; }
        public int testid { get; set; } = 0;
        public int perid { get; set; } = 0;
        /// <summary>
        /// 检验唯一值ID
        /// </summary>
        public string sampleID { get; set; } = "";
        public DateTime CreateTime { get; set; }
        public string PathologyNo { get; set; }
        /// <summary>
        /// 图片信息集合
        /// </summary>
        public List<PictureInfoModel> ListPicture { get; set; }

    }
    /// <summary>
    /// 细胞瓜片
    /// </summary>
    public class TCTScreenModel
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 条码号
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 病理备注
        /// </summary>
        public string diagnosisRemark { get; set; }

        /// <summary>
        /// 图片编号
        /// </summary>
        public string PathologyNo { get; set; }
        /// <summary>
        /// 病理诊断
        /// </summary>
        public string diagnosis { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public string PictureCode { get; set; }
        /// <summary>
        /// 样本ID
        /// </summary>
        public int testid { get; set; } = 0;
        /// <summary>
        /// 检验唯一值ID
        /// </summary>
        public string sampleID { get; set; } = "";
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 图片信息集合
        /// </summary>
        public List<PictureInfoModel> ListPicture { get; set; }
    }
}
