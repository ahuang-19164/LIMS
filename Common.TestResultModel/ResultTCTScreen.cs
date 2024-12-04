﻿using System;
using System.Collections.Generic;

namespace Common.TestResultModel
{
    public class ResultTCTScreen
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