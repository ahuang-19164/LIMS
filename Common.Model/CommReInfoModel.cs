using System.Collections.Generic;

namespace Common.Model
{
    public class commReInfo<T>
    {
        /// <summary>
        /// 返回信息编号0-返回成功1-返回报错2-双输成功。
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 返回信息内容
        /// </summary>
        public List<T> infos { get; set; }
        /// <summary>
        /// 返回下一流程编号
        /// </summary>
        public string nextFlowNO { get; set; }
        /// <summary>
        /// 返回附加信息
        /// </summary>
        public string msg { get; set; }
    }

    /// <summary>
    /// 条码返回信息
    /// </summary>
    public class commReBarcodeInfo
    {
        /// <summary>
        /// 返回信息编号0-返回成功1-返回报错。
        /// </summary>
        public int code { get; set; } = 1;
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 条码状态
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 条码消息
        /// </summary>
        public string msg { get; set; }
    }







    /// <summary>
    /// 返回样本信息状态列表
    /// </summary>
    public class commReSampleInfo
    {
        /// <summary>
        /// 0成功1失败||状态编号
        /// </summary>
        public int code { get; set; } = 1;
        /// <summary>
        /// 录入编号
        /// </summary>
        public int perid { get; set; } = 0;
        /// <summary>
        /// 样本编号
        /// </summary>
        public int testid { get; set; } = 0;
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 前处理状态
        /// </summary>
        public int perState { get; set; }

        /// <summary>
        /// 检验状态
        /// </summary>
        public int testState { get; set; } = 0;
        /// <summary>
        /// 其他处理状态
        /// </summary>
        public int handleState { get; set; }
        /// <summary>
        /// 条码号执行记录信息
        /// </summary>
        public string msg { get; set; }
    }
    /// <summary>
    /// 返回样本结果信息
    /// </summary>
    public class commReItemInfo
    {
        /// <summary>
        /// 0成功1失败||状态编号
        /// </summary>
        public int code { get; set; } = 1;
        /// <summary>
        /// 录入编号
        /// </summary>
        public int perid { get; set; } = 0;
        /// <summary>
        /// 样本编号
        /// </summary>
        public int testid { get; set; } = 0;
        /// <summary>
        /// 条码号
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ItemNO { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// 返回项目结果提示
        /// </summary>
        public string ItemFlag { get; set; }


        /// <summary>
        /// 信息执行结果0失败1成功
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 项目执行记录信息
        /// </summary>
        public string ItemMsg { get; set; }
    }
    /// <summary>
    /// 公共返回处理状态
    /// </summary>
    public class commRehandleModel
    {
        /// <summary>
        /// 信息处理状态 0 成功 1失败
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 信息名称
        /// </summary>
        public string info { get; set; }
        /// <summary>
        /// 返回处理消息
        /// </summary>
        public string msg { get; set; }
    }
}
