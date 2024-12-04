using System;

namespace Common.TestResultModel
{
    public class ResultPictureInfo
    {
        /// <summary>
        /// 病例编号
        /// </summary>
        public string pathologyNo { get; set; }
        /// <summary>
        /// 图片类型
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
        public DateTime CreatTime { get; set; }
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
        public int testid { get; set; }=0;

        /// <summary>
        /// 图片名称
        /// </summary>
        public string PictureNames { get; set; }

    }
}
