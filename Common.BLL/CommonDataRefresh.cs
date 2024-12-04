using Common.Conn;

namespace Common.BLL
{
    public class CommonDataRefresh
    {
        //ICommonData commonData = new CommDataHandle();

        /// <summary>
        /// 获取全部系统信息
        /// </summary>
        public static void GetSystemInfo()
        {
            CommDataHandle.GetSystemInfo();
            WorkCommDataHandle.GetWorkAll();
            QCCommDataHandle.GetQCAll();
        }
        #region common.data
        /// <summary>
        /// 获取业务类型信息
        /// </summary>
        public static void GetWorkType()
        {
            WorkCommDataHandle.GetWorkType();
        }
        /// <summary>
        /// 获取业务信息
        /// </summary>
        public static void GetWorkInfo()
        {
            WorkCommDataHandle.GetWorkInfo();
        }
        /// <summary>
        /// 获取公司信息
        /// </summary>
        public static void GetCommpanyInfo()
        {
            CommDataHandle.GetCommpanyInfo();
        }
        /// <summary>
        /// 获取部门信息
        /// </summary>
        public static void GetDepartmentInfo()
        {
            CommDataHandle.GetDepartmentInfo();
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public static void GetRoleInfo()
        {
            CommDataHandle.GetRoleInfo();
        }
        /// <summary>
        /// 获取Web角色列表
        /// </summary>
        public static void GetWebRoleInfo()
        {
            CommDataHandle.GetWebRoleInfo();
        }
        /// <summary>
        /// 获取用户信息标
        /// </summary>
        public static void GetUserInfo()
        {
            CommDataHandle.GetUserInfo();
        }
        /// <summary>
        /// 获取用户图片信息
        /// </summary>
        public static void GetUserImg()
        {
            CommDataHandle.GetUserImg();
        }
        /// <summary>
        /// 获取完整用户视图
        /// </summary>
        public static void GetPowerList()
        {
            CommDataHandle.GetPowerList();
        }
        /// <summary>
        /// 获取Web权限列表
        /// </summary>
        public static void GetWebPowerList()
        {
            CommDataHandle.GetWebPowerList();
        }
        /// <summary>
        /// 获取完整用户视图
        /// </summary>
        public static void GetUserInfoFullView()
        {
            CommDataHandle.GetUserInfoFullView();
        }
        /// <summary>
        /// 获取权限列表
        /// </summary>
        public static void GetPowerListString()
        {
            CommDataHandle.GetUserInfoFullView();
        }

        #endregion


        #region WorkCommData
        public static void GetClientAgent()
        {
            WorkCommDataHandle.GetClientAgent();
        }
        /// <summary>
        /// 客户信息
        /// </summary>
        public static void GetClientInfo()
        {
            WorkCommDataHandle.GetClientInfo();
        }
        ///// <summary>
        ///// 委托客户
        ///// </summary>
        //public static void GetDelegeteCompanyInfo()
        //{
        //    WorkCommDataHandle.GetDelegeteCompanyInfo();
        //}

        /// <summary>
        /// 工作组信息
        /// </summary>
        public static void GetGroupWork()
        {
            WorkCommDataHandle.GetGroupWork();
        }
        /// <summary>
        /// 项目组信息
        /// </summary>
        public static void GetGroupApply()
        {
            WorkCommDataHandle.GetGroupApply();
        }
        /// <summary>
        /// 专业组信息
        /// </summary>
        public static void GetGroupTest()
        {
            WorkCommDataHandle.GetGroupTest();
        }
        /// <summary>
        /// 专业组权限
        /// </summary>
        public static void GetGroupPower()
        {
            WorkCommDataHandle.GetGroupPower();
        }
        /// <summary>
        /// 组套项目
        /// </summary>
        public static void GetItemApply()
        {
            WorkCommDataHandle.GetItemApply();
        }
        /// <summary>
        /// 组合项目
        /// </summary>
        public static void GetItemGroup()
        {
            WorkCommDataHandle.GetItemGroup();
        }
        /// <summary>
        /// 检测项目
        /// </summary>
        public static void GetItemTest()
        {
            WorkCommDataHandle.GetItemTest();
        }
        /// <summary>
        /// 检测项目
        /// </summary>
        public static void GetItemFlow()
        {
            WorkCommDataHandle.GetItemFlow();
        }
        /// <summary>
        /// 组套项目和组合项目对应表
        /// </summary>
        public static void GetTestCorrelationAG()
        {
            WorkCommDataHandle.GetTestCorrelationAG();
        }
        /// <summary>
        /// 组合项目和项目对应表
        /// </summary>
        public static void GetTestCorrelationGT()
        {
            WorkCommDataHandle.GetTestCorrelationGT();
        }
        /// <summary>
        /// 项目参考值信息
        /// </summary>
        public static void GetItemReference()
        {
            WorkCommDataHandle.GetItemReference();
        }
        /// <summary>
        /// 项目其他相关信息
        /// </summary>
        public static void GetItemOtherInfo()
        {
            WorkCommDataHandle.GetItemOtherInfo();
        }
        /// <summary>
        /// 业务字典信息
        /// </summary>
        public static void GetWorkDictionary()
        {
            WorkCommDataHandle.GetWorkDictionary();
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        public static void GetInstrumentInfo()
        {
            WorkCommDataHandle.GetInstrumentInfo();
        }
        /// <summary>
        /// 委托客户信息
        /// </summary>
        public static void GetDelegeteCompanyInfo()
        {
            WorkCommDataHandle.GetDelegeteCompanyInfo();
        }

        #endregion




        #region reportinfo

        public static void GetreportBind()
        {
            WorkCommDataHandle.GetReprotBindInfo();
        }
        public static void GetreportSrouce()
        {
            WorkCommDataHandle.GetReprotSrouceInfo();
        }

        #endregion




    }
}
