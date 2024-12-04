namespace Common.Conn
{
    public interface ICommonData
    {
        /// <summary>
        /// 获取全部信息
        /// </summary>
        void GetSystemInfo();
        /// <summary>
        /// 获取公司信息
        /// </summary>
        void GetCommpanyInfo();
        /// <summary>
        /// 获取部门信息
        /// </summary>
        void GetDepartmentInfo();
        /// <summary>
        /// 获取权限列表
        /// </summary>
        void GetRoleInfo();

        /// <summary>
        /// 获取Web权限列表
        /// </summary>
        void GetWebRoleInfo();
        /// <summary>
        /// 获取用户信息标
        /// </summary>
        void GetUserInfo();

        /// <summary>
        /// 获取权限列表
        /// </summary>
        void GetPowerList();
        /// <summary>
        /// 获取Web权限列表
        /// </summary>
        void GetWebPowerList();
        /// <summary>
        /// 获取完整用户视图
        /// </summary>
        void GetUserInfoFullView();
        /// <summary>
        /// 获取权限列表
        /// </summary>
        void GetPowerListString();

    }
}
