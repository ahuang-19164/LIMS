using System;
using System.Collections.Generic;

namespace Common.TestResultModel
{
    public class ResultTCT
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
        public int testid { get; set; }=0;
        public DateTime CreateTime { get; set; }
        public string PathologyNo { get; set; }
        /// <summary>
        /// 图片信息集合
        /// </summary>
        public List<ResultPictureInfo> ListPicture { get; set; }

    }
}
