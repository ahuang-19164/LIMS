using Common.Data;
using Common.SqlModel;
using System.Data;
using System.Linq;

namespace Common.BLL
{
    public class CommDataHandle
    {
        /// <summary>
        /// 获取全部公共信息
        /// </summary>
        public static void GetSystemInfo()
        {
            GetCommpanyInfo();
            GetDepartmentInfo();
            GetRoleInfo();
            GetWebRoleInfo();
            GetUserInfo();
            //GetUserImg();
            GetPowerList();
            GetWebPowerList();
            GetUserInfoFullView();
            GetPowerListString();
        }

        #region
        /// <summary>
        /// 更新所有公司信息
        /// </summary>
        public static void GetCommpanyInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.CompanyInfo";
            selectInfo.OrderColumns = "sort";
            CommonData.DTCommonyInfoAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有部门信息
        /// </summary>
        public static void GetDepartmentInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.DepartmentInfo";
            selectInfo.OrderColumns = "companyNO,sort";
            CommonData.DTDepertmentInfoAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有角色信息
        /// </summary>
        public static void GetRoleInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.RoleInfo";
            selectInfo.OrderColumns = "companyNO,departmentNO,sort";
            CommonData.DTRoleInfoAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有Web角色信息
        /// </summary>
        public static void GetWebRoleInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.RoleInfoWeb";
            selectInfo.OrderColumns = "companyNO,departmentNO,sort";
            CommonData.DTWebRoleInfoAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有用户信息
        /// </summary>
        public static void GetUserInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.UserInfo";
            selectInfo.OrderColumns = "companyNO,departmentNO,roleNO,sort";
            CommonData.DTUserInfoAll = ApiHelpers.postInfo(selectInfo);
        }

        /// <summary>
        /// 获取用户图片
        /// </summary>
        public static void GetUserImg()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.UserImg";
            //selectInfo.OrderColumns = "companyNO,departmentNO,roleNO,sort";
            CommonData.DTUserImgAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有权限信息
        /// </summary>
        public static void GetPowerList()
        {
            sInfo selectInfo = new sInfo();
            //selectInfo.values = "id,no,moduleNO,itemImg,names,libraryName,className,tagValue,remark,state,sort";
            //selectInfo.values = "id,no,moduleNO,names,libraryName,className,tagValue,remark,state,sort";
            selectInfo.TableName = "Common.PowerList";
            selectInfo.OrderColumns = "no,moduleNO";
            CommonData.DTPowerListAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有Web权限信息
        /// </summary>
        public static void GetWebPowerList()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.PowerListWeb";
            selectInfo.OrderColumns = "no,moduleNO";
            CommonData.DTWebPowerListAll = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 更新所有用户详细信息
        /// </summary>
        public static void GetUserInfoFullView()
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.TableName = "Common.UserInfoFullView";
            //selectInfo.wheres = "state=1";
            //selectInfo.OrderColumns = "companyNO,departmentNO,roleNO,sort";
            //CommonData.DTUserInfoAllFullView = ApiHelpers.postInfo(selectInfo);
        }

        /// <summary>
        /// 更新所有类型信息
        /// </summary>
        public static void GetTypeInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Common.TypeInfo";
            selectInfo.OrderColumns = "typeNO,sort";
            CommonData.DTTypeInfoAll = ApiHelpers.postInfo(selectInfo);
        }


        #endregion

        /// <summary>
        /// 获取权限列表
        /// </summary>
        public static void GetPowerListString()
        {
            if (CommonData.DTRoleInfoAll == null)
            {
                CommonData.powerList = null;
            }
            else
            {
                if (CommonData.UserInfo.roleNO != null)
                {
                    DataRow[] rows = CommonData.DTRoleInfoAll.Select($"no='{CommonData.UserInfo.roleNO}'");
                    if (rows.Count() == 1)
                    {
                        CommonData.powerList = rows[0]["powerList"].ToString().Split(',');
                    }
                    else
                    {
                        CommonData.powerList = null;
                    }
                }
                else
                {
                    CommonData.powerList = null;
                }
            }

        }
    }
}
