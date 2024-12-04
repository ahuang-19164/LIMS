using System.Data;

namespace Common.Data
{
    public class WorkCommData
    {


        #region 业务类型
        /// <summary>
        /// 所有业务类型
        /// </summary>
        public static DataTable DTWorkType { get; set; }
        /// <summary>
        /// 容器类别
        /// </summary>
        public static DataTable DTTypeContainer { get; set; }
        /// <summary>
        /// 仪器类别
        /// </summary>
        public static DataTable DTTypeInstrument { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        public static DataTable DTTypeItem { get; set; }
        /// <summary>
        /// 实验方法
        /// </summary>
        public static DataTable DTTypeMethod { get; set; }

        /// <summary>
        /// 病人类别
        /// </summary>
        public static DataTable DTTypePatient { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public static DataTable DTTypeSex { get; set; }

        /// <summary>
        /// 报告类别
        /// </summary>
        public static DataTable DTTypeReport { get; set; }
        /// <summary>
        /// 结果类别
        /// </summary>
        public static DataTable DTTypeResult { get; set; }

        /// <summary>
        /// 样本类别
        /// </summary>
        public static DataTable DTTypeSample { get; set; }
        /// <summary>
        /// 标本性状
        /// </summary>
        public static DataTable DTTypeShape { get; set; }
        /// <summary>
        /// 检测类别
        /// </summary>
        public static DataTable DTTypeTest { get; set; }
        /// <summary>
        /// 项目流程类型
        /// </summary>
        //public static DataTable DTTypeTestFlow { get; set; }

        /// <summary>
        /// 客户等级
        /// </summary>
        public static DataTable DTTypeLevel { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public static DataTable DTTypeClient { get; set; }
        /// <summary>
        /// 物流方式
        /// </summary>
        public static DataTable DTTypeDistribution { get; set; }

        /// <summary>
        /// 提交状态
        /// </summary>
        public static DataTable DTStateSample { get; set; }


        #endregion


        #region 数据信息表
        /// <summary>
        /// 代理商信息
        /// </summary>
        public static DataTable DTClientAgent { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        public static DataTable DTClientInfo { get; set; }
        /// <summary>
        /// 工作组信息
        /// </summary>
        public static DataTable DTGroupWork { get; set; }
        /// <summary>
        /// 组合项目信息
        /// </summary>
        public static DataTable DTGroupApply { get; set; }
        /// <summary>
        /// 检验组信息
        /// </summary>
        public static DataTable DTGroupTest { get; set; }

        /// <summary>
        /// 检验组权限
        /// </summary>
        public static DataTable DTGroupPower { get; set; }

        /// <summary>
        /// 项目组套信息
        /// </summary>
        public static DataTable DTItemApply { get; set; }
        /// <summary>
        /// 项目组合信息
        /// </summary>
        public static DataTable DTItemGroup { get; set; }
        /// <summary>
        /// 项目检测信息
        /// </summary>
        public static DataTable DTItemTest { get; set; }
        /// <summary>
        /// 项目流程
        /// </summary>
        public static DataTable DTItemFlow { get; set; }
        /// <summary>
        /// 组套与组合项目对应关系表
        /// </summary>
        public static DataTable DTTestCorrelationAG { get; set; }
        /// <summary>
        /// 组合项目和组套对应关系表
        /// </summary>
        public static DataTable DTTestCorrelationGT { get; set; }
        /// <summary>
        /// 项目参考值信息
        /// </summary>
        public static DataTable DTItemReference { get; set; }
        /// <summary>
        /// 项目其他信息表
        /// </summary>
        public static DataTable DTItemTestOtherInfo { get; set; }
        /// <summary>
        /// 项目其他信息表
        /// </summary>
        public static DataTable DTItemGroupOtherInfo { get; set; }

        /// <summary>
        /// 录入状态
        /// </summary>
        public static DataTable DTStatePerWork { get; set; }
        /// <summary>
        /// 检验状态
        /// </summary>
        public static DataTable DTStateTest { get; set; }
        /// <summary>
        /// 交接状态
        /// </summary>
        public static DataTable DTStateTake { get; set; }
        /// <summary>
        /// 委托单位信息
        /// </summary>
        public static DataTable DTClientDelegateInfo { get; set; }
        /// <summary>
        /// 仪器信息
        /// </summary>
        public static DataTable DTInstrumentInfo { get; set; }
        /// <summary>
        /// 微生物抗生素信息
        /// </summary>
        public static DataTable DTMicrobeAntibiotic { get; set; }
        /// <summary>
        /// 微生物培养信息
        /// </summary>
        public static DataTable DTMicrobeCultivation { get; set; }
        /// <summary>
        /// 微生物细菌信息
        /// </summary>
        public static DataTable DTMicrobeGerm { get; set; }
        /// <summary>
        /// 微生物涂片信息
        /// </summary>
        public static DataTable DTMicrobeSmear { get; set; }
        /// <summary>
        /// 微生物结果信息
        /// </summary>
        public static DataTable DTMicrobeTest { get; set; }
        /// <summary>
        /// 微生物抗生素组合
        /// </summary>
        public static DataTable DTMicrobeGroupList { get; set; }



        #endregion


        #region 视图控件

        /// <summary>
        /// 专业组gird视图数据
        /// </summary>
        public static DataTable DTGroupGridView { get; set; }
        /// <summary>
        /// 专业组控件集合数据
        /// </summary>
        public static DataTable DTGroupLayView { get; set; }
        /// <summary>
        /// 其他Grid模块视图
        /// </summary>
        public static DataTable DTOtherGridView { get; set; }
        /// <summary>
        /// 其他Laycontrol模块视图
        /// </summary>
        public static DataTable DTOtherLayView { get; set; }




        #endregion

        #region 字典信息
        /// <summary>
        /// 业务字典表
        /// </summary>
        public static DataTable DTWorkDictionary { get; set; }
        #endregion




    }
}
