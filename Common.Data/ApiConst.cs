using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class ApiConst
    {
        public static string ConnApi = "http://localhost:8800/api/";
        public static string version = "1.0.0.1";
        public static string UserToken = "http://localhost:9610/api/User/Login/Logins";
        public static string ApiHLimsInfo = "http://localhost:8800/api/HLimsInfo";
        public static string ApiSelect = "http://localhost:8800/api/HLimsSelectInfo";
        public static string ApiUpdate = "http://localhost:8800/api/HLimsUpdateInfo";
        public static string ApiInsert = "http://localhost:8800/api/HLimsInsertInfo";
        public static string ApiDelete = "http://localhost:8800/api/HLimsDeleteInfo";
        public static string ApiHide = "http://localhost:8800/api/HLimsHideInfo";
        public static string ApiSaveDT = "http://localhost:8800/api/HLimsSaveDTInfo";


        public static string BaseApiSelect = "http://localhost:8800/api/HLIMSBaseSelectInfo";
        public static string BaseApiUpdate = "http://localhost:8800/api/HLIMSBaseUpdateInfo";
        public static string BaseApiInsert = "http://localhost:8800/api/HLIMSBaseInsertInfo";
        public static string BaseApiDelete = "http://localhost:8800/api/HLIMSBaseDeleteInfo";
        public static string BaseApiHide = "http://localhost:8800/api/HLIMSBaseHideInfo";
        public static string BaseApiSaveDT = "http://localhost:8800/api/HLIMSBaseSaveDTInfo";



        public static string UrlSysDownFile = "";
        public static string UrlSysUpFile = "";
        public static string UrlFlowDownFile = "";
        public static string UrlFlowUpFile = "";
        public static string UrlTestDownFile = "";
        public static string UrlTestUpFile = "";

        /// <summary>
        ///下载报告接口地址
        /// </summary>
        public static string UrlReportDownFile = "";

        /// <summary>
        /// 上传报告接口地址
        /// </summary>
        public static string UrlReportUpFile = "";

        public const string Api_sys_userinfo = "sys_userinfo";//用户信息表
        public const string Api_sys_roleinfo = "sys_roleinfo";//角色信息表
        public const string Api_sys_rolemenu = "sys_rolemenu";//角色信息表




        public static string Api_comm_client_group = ConnApi + "System/ClientGroupHandle";//客户专业组配置
        public static string Api_comm_client_info = ConnApi + "System/ClientInfoHandle";//客户信息
        public static string Api_comm_group_test = ConnApi + "System/GroupTestHandle";//专业组信息
        public static string Api_comm_item_apply = ConnApi + "System/ItemApplyHandle";//组套信息表
        public static string Api_comm_item_group = ConnApi + "System/ItemGroupHandle";//组合项目信息
        public static string Api_comm_item_test = ConnApi + "System/ItemTestHandle";//检验项目信息
        public static string Api_comm_item_reference = ConnApi + "System/ItemReferenceHandle";//项目参考值信息
        public static string Api_comm_item_flow = ConnApi + "System/ItemFlowHandle";//组合项目流程信息
        public static string Api_finance_group_charge = ConnApi + "System/FinanceGroupCharge";//组合项目收费信息
    }
}
