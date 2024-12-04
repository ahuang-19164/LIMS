
using System;
using System.ComponentModel;


namespace Common.SystemModel
{
    /// <summary>
    /// 用户表
    /// </summary>

    public class sys_userinfo
    {
        public sys_userinfo()
        {


        }
        /// <summary>
        /// Desc:用户ID
        /// Default:
        /// Nullable:False
        /// </summary>  

        public int id { get; set; }

        /// <summary>
        /// Desc:用户编号
        /// Default:
        /// Nullable:True
        /// </summary>   

        public int no { get; set; }

        /// <summary>
        /// Desc:账号
        /// Default:
        /// Nullable:True
        /// </summary>    

        public string userNO { get; set; }

        /// <summary>
        /// Desc:用户名称
        /// Default:
        /// Nullable:True
        /// </summary>   

        public string names { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>   
        public string shortNames { get; set; }

        /// <summary>
        /// Desc:自定义码
        /// Default:
        /// Nullable:True
        /// </summary>     

        public string customCode { get; set; }

        /// <summary>
        /// Desc:公司编号
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string companyNO { get; set; }

        /// <summary>
        /// Desc:部门编号
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string departmentNO { get; set; }

        /// <summary>
        /// Desc:角色编号
        /// Default:
        /// Nullable:True
        /// </summary>   
        public int roleNO { get; set; }

        /// <summary>
        /// Desc:Web角色编号
        /// Default:
        /// Nullable:True
        /// </summary>   
        public int webRoleNO { get; set; }

        /// <summary>
        /// Desc:排序
        /// Default:
        /// Nullable:True
        /// </summary>   
        public string sort { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>   

        public string pwd { get; set; }

        /// <summary>
        /// Desc:性别
        /// Default:
        /// Nullable:True
        /// </summary>   
        public string sex { get; set; }

        /// <summary>
        /// Desc:生日
        /// Default:
        /// Nullable:True
        /// </summary>     
        public DateTime birthday { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string phone { get; set; }

        /// <summary>
        /// Desc:邮箱
        /// Default:
        /// Nullable:True
        /// </summary>   
        public string email { get; set; }

        /// <summary>
        /// Desc:工作电话
        /// Default:
        /// Nullable:True
        /// </summary>   
        public string workPhone { get; set; }

        /// <summary>
        /// Desc:微信
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string weChat { get; set; }

        /// <summary>
        /// Desc:客户列表
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string clientList { get; set; }

        /// <summary>
        /// Desc:备注
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string remark { get; set; }

        /// <summary>
        /// Desc:账号状态 0 禁用 1 启用
        /// Default:
        /// Nullable:True
        /// </summary>    
        public bool state { get; set; }

        /// <summary>
        /// Desc:Web状态
        /// Default:
        /// Nullable:True
        /// </summary>  
        public bool webstate { get; set; }

        /// <summary>
        /// Desc:删除状态
        /// Default:
        /// Nullable:True
        /// </summary>  
        public bool dstate { get; set; } = false;

        /// <summary>
        /// Desc:用户图片
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string headImageUrl { get; set; }

        /// <summary>
        /// Desc:Token
        /// Default:
        /// Nullable:True
        /// </summary>  
        public string token { get; set; }

        /// <summary>
        /// Desc:最后登录时间
        /// Default:
        /// Nullable:True
        /// </summary>   
        public DateTime lastModifyPwdDate { get; set; }

        /// <summary>
        /// Desc:创建时间
        /// Default:
        /// Nullable:True
        /// </summary>   

        public DateTime createDate { get; set; }
    }
}
