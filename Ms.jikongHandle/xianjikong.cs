using Common.JsonHelper;
using Ms.jikongModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.jikongHandle
{
    public class xianjikong
    {
        /// <summary>
        /// 获取Token
        /// </summary>
        public static void GetToken()
        {
            //string url = "http://m.neusoftxb.com:9011/prod-api/naat/open/api/getToken";
            XiAnUserInfo xiAnUserInfo = new XiAnUserInfo();
            xiAnUserInfo.userName = "HJRW1";
            xiAnUserInfo.password = "9r9!!r^6V^^n";
            string userInfo = JsonHelper.SerializeObjct(xiAnUserInfo);
            xianjkApi.PostApiXiAnJK(userInfo);
        }

        /// <summary>
        /// 根据管子号获取样本信息
        /// </summary>
        /// <param name="tubeCode"></param>
        /// <returns></returns>
        public static string getDataByCode(string tubeCode)
        {
            ////XiAnUserInfo xiAnUserInfo = new XiAnUserInfo();
            ////xiAnUserInfo.userName = "HJRW1";
            ////xiAnUserInfo.password = "9r9!!r^6V^^n";
            //string tubeCode = "{\"code\":\"HJ32961046\"}";
            ////string userInfo = JsonHelper.SerializeObjct(xiAnUserInfo);
            ////string a= xianjkApi.getDataByCode(tubeCode);
            string a= xianjkApi.getDataByCode(tubeCode);
            return a;


        }
    }
}
