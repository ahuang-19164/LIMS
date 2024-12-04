/***********************************************************************
 *            Project: CoreCms
 *        ProjectName: 核心内容管理系统                                
 *                Web: https://www.corecms.net                      
 *             Author: 大灰灰                                          
 *              Email: jianweie@163.com
 *         CreateTime: 2021-06-08 22:14:59
 *        Description: 暂无
***********************************************************************/


using System;

namespace Common.SystemModel.Entities
{
    /// <summary>
    /// 用户日志
    /// </summary>

    public partial class sys_userlog
    {
        /// <summary>
        /// 用户日志
        /// </summary>
        public sys_userlog()
        {
        }

        /// <summary>
        /// id
        /// </summary>

        public int id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>

        public int userId { get; set; }


        ///// <summary>
        ///// 用户账号
        ///// </summary>
        //[Display(Name = "用户账号")]
        //[SugarColumn(ColumnDescription = "用户账号")]
        //[Required(ErrorMessage = "请输入{0}")]
        //public int userNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>

        public string names { get; set; }
        /// <summary>
        /// 状态
        /// </summary>

        public int state { get; set; }
        /// <summary>
        /// 参数
        /// </summary>

        public string parameters { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>

        public string ip { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime createTime { get; set; }
    }
}