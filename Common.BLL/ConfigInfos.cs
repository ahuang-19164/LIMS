using Common.Data;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Common.BLL
{
    public class ConfigInfos
    {
        /// <summary>
        /// 获取config配置信息
        /// </summary>
        /// <param name="startPath"></param>
        public static void GetConfigInfo(string startPath)
        {
            try
            {


                //string file = startPath + "\\HLFramework.exe.config";
                //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                //CommonData.apiCommonUrl=config.ConnectionStrings.ConnectionStrings["urlstring"].ToString();
                CommonData.sqlconnH = ConfigurationManager.ConnectionStrings["urlstring"].ToString();

                if (ConfigurationManager.AppSettings.HasKeys())
                {
                    Dictionary<string, string> configInfos = new Dictionary<string, string>();
                    List<string> theKeys = new List<string>(); //保存Key的集合 
                                                               //List<string> theValues = new List<string>(); //保存Value的集合 
                                                               //遍历出所有的Key并添加进theKeys集合 



                    foreach (string theKey in ConfigurationManager.AppSettings.Keys)
                    {
                        configInfos.Add(theKey, ConfigurationManager.AppSettings.GetValues(theKey)[0]);
                    }
                    CommonData.configInfos = configInfos;
                }
            }
            catch
            {
                MessageBox.Show("配置文件读取失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 读取配置key信息中vlaue
        /// </summary>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public static string ReadConfigInfo(string KeyName)
        {
            //try
            //{
            if (CommonData.configInfos != null)
            {
                CommonData.configInfos.TryGetValue(KeyName, out string keyValue);
                return keyValue;
            }
            else
            {
                MessageBox.Show($"未找到可用的配置文件信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"{KeyName}配置文件读取失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return "";
            //}
        }
    }
}
