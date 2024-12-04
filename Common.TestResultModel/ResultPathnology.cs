using System;
using System.Collections.Generic;

namespace Common.TestResultModel
{
    public class ResultPathnology
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
        /// 图片编号
        /// </summary>
        public string PictureCode { get; set; }
        /// <summary>
        /// 样本ID
        /// </summary>
        public int testid { get; set; }=0;


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 图片信息集合
        /// </summary>
        public List<ResultPictureInfo> ListPicture { get; set; }




    }
}
