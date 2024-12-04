using Common.Conn;
using Common.Data;
using Common.JsonHelper;
using Common.MergePDF;
using Common.Model;
using Common.ReportModel;
using Common.SqlModel;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Common.BLL
{
    public class ApiHelpers
    {

        private static string filePath = Application.StartupPath;

        /// <summary>
        /// 通用Post请求
        /// </summary>
        /// <param name="Controller">控制器名称</param>
        /// <param name="JsonStr">接收参数"{Code:\"test089\",Name:\"test1\"}</param>
        /// <returns></returns>
        public static WebApiCallBack postInfo(string Controller)
        {
            string str = ApiConnections.PostHttpApi(Controller);
            if (str != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return jm;
            }
            else
            {
                WebApiCallBack jm = new WebApiCallBack();
                return jm;
            }

        }



        /// <summary>
        /// 通用Post请求
        /// </summary>
        /// <param name="Controller">控制器名称</param>
        /// <param name="JsonStr">接收参数"{Code:\"test089\",Name:\"test1\"}</param>
        /// <returns></returns>
        public static WebApiCallBack postInfo(string Controller, object info)
        {
            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(Controller, JsonStr);
            if(str!="")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return jm;
            }
            else
            {
                WebApiCallBack jm = new WebApiCallBack();
                return jm;
            }

        }

        /// <summary>
        /// 通用Post请求
        /// </summary>
        /// <param name="Controller">控制器名称</param>
        /// <param name="JsonStr">接收参数"{Code:\"test089\",Name:\"test1\"}</param>
        /// <returns></returns>
        public static WebApiCallBack postInfo(string Controller, string info)
        {
            //string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(Controller, info);
            if (str != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return jm;
            }
            else
            {
                WebApiCallBack jm = new WebApiCallBack();
                return jm;
            }

        }


        /// <summary>
        /// 系统查询方法
        /// </summary>
        /// <param name="selectInfo"></param>
        /// <returns></returns>
        public static DataTable postInfo(sInfo info)
        {
            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiSelect, JsonStr);
            if(str!="")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                if(jm.data!=null)
                {
                    //DataTable dataTable = Common.JsonHelper.JsonHelper.JsonConvertObject<DataTable>(jm.data.ToString());
                    DataTable dataTable = Common.JsonHelper.JsonHelper.StringToDT(jm.data.ToString()); 
                    return dataTable;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public static int postInfo(uInfo info)
        {

            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiUpdate, JsonStr);
            if(str!="")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (info.MessageShow == 0||jm.code!=0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                if (jm.data != null)
                {
                    int i = 0;
                    //DataTable dataTable = Common.JsonHelper.JsonHelper.JsonConvertObject<DataTable>(jm.data.ToString());
                    bool result = int.TryParse(jm.data.ToString(), out i);
                    return i;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }



        public static int postInfo(dInfo info)
        {
            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiDelete, JsonStr);
            if (str != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                int changeCount = Convert.ToInt32(jm.data);
                if (info.MessageShow == 0 || jm.code != 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                if (jm.data != null)
                {
                    int i = 0;
                    //DataTable dataTable = Common.JsonHelper.JsonHelper.JsonConvertObject<DataTable>(jm.data.ToString());
                    bool result = int.TryParse(jm.data.ToString(), out i);
                    return i;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }



        public static int postInfo(hideInfo info)
        {
            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiHide, JsonStr);
            if (str != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                int changeCount = Convert.ToInt32(jm.data);
                if (info.MessageShow == 0 || jm.code != 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                if (jm.data != null)
                {
                    int i = 0;
                    //DataTable dataTable = Common.JsonHelper.JsonHelper.JsonConvertObject<DataTable>(jm.data.ToString());
                    bool result = int.TryParse(jm.data.ToString(), out i);
                    return i;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }



        public static int postInfo(iInfo info)
        {
            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiInsert, JsonStr);
            if(str!="")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                int changeCount = Common.JsonHelper.JsonHelper.JsonConvertObject<int>(jm);
                 //= Convert.ToInt32(jm.data);
                if (info.MessageShow == 0 || jm.code != 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                if (jm.data != null)
                {
                    int i = 0;
                    //DataTable dataTable = Common.JsonHelper.JsonHelper.JsonConvertObject<DataTable>(jm.data.ToString());
                    bool result = int.TryParse(jm.data.ToString(), out i);
                    return i;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            
        }


        public static bool postInfo(SaveTableInfo info)
        {
            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiSaveDT, JsonStr);
            if (str != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                bool changeState = Convert.ToBoolean(jm.data);
                return changeState;
            }
            else
            {
                return false;
            }
        }


        public static bool postInfo(DataTable dt,string tableName)
        {
            SaveTableInfo saveTableInfo = new SaveTableInfo();
            saveTableInfo.UserName = CommonData.UserInfo.names;

            saveTableInfo.TableName = tableName;
            saveTableInfo.DT = dt;


            string JsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(saveTableInfo);
            string str = ApiConnections.PostHttpApi(ApiConst.ApiSaveDT, JsonStr);
            if (str != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(str);
                if (jm.code != 0)
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                bool changeState = Convert.ToBoolean(jm.data);
                return changeState;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 存放文件夹名称（数据表名同名）
        /// </summary>
        /// <param name="dirname"></param>
        /// <param name="info"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool PostDownTestFile(commInfoModel<FileModel> info,out string SavePath)
        {
            //返回下载文件路径
            SavePath = "";
            //文件是否下载成功
            bool filestate = false;
            info.UserName = CommonData.UserInfo.names;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostDownFile(ApiConst.UrlTestDownFile, jsonStr);
            //commReInfo<FileModel> reInfo = new commReInfo<FileModel>();
            //List<FileModel> files = new List<FileModel>();
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<FileModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<FileModel>>(jm);
                    string msg = "";
                    foreach (FileModel fileinfo in commReInfo.infos)
                    {
                        if (fileinfo.code == 0)
                        {
                            string fullFilePath = filePath + "\\test";
                            if (!Directory.Exists(fullFilePath))
                                Directory.CreateDirectory(fullFilePath);
                            if (fileinfo.dirname != null && fileinfo.dirname != "")
                            {
                                fullFilePath = filePath + "\\test\\" + fileinfo.dirname;
                                if (!Directory.Exists(fullFilePath))
                                    Directory.CreateDirectory(fullFilePath);
                            }
                            fullFilePath += "\\" + fileinfo.fileName;

                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);
                            //返回生成是否成功
                            filestate = FileConverHelpers.StringToFile(fullFilePath, fileinfo.fileString.ToString());
                            if (filestate)
                            {
                                SavePath = fullFilePath;
                                //FileModel fileModel = new FileModel();
                                //fileModel.code = 0;
                                //fileModel.fileName = fullFilePath;
                                //files.Add(fileModel);
                            }
                            else
                            {
                                msg += fileinfo.fileName + ":" + "获取文件失败" + "\r\n";
                                break;
                            }
                        }
                        else
                        {
                            msg += fileinfo.fileName + ":" + fileinfo.msg + "\r\n";
                        }
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //reInfo.infos = files;
            return filestate;
        }
        public static void PostUpTestFile(commInfoModel<FileModel> info)
        {
            info.UserName = CommonData.UserInfo.names;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostUpFile(ApiConst.UrlTestUpFile, jsonStr);
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<commRehandleModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<commRehandleModel>>(jm);
                    string msg = "";
                    foreach (commRehandleModel commRehandle in commReInfo.infos)
                    {
                        //if (commRehandle.code != 0)
                        //{
                        msg += commRehandle.info + ":" + commRehandle.msg + "\r\n";
                        //}
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 流程文件下载
        /// </summary>
        /// <param name="fileType">文件类型</param>
        /// <param name="info">获取文件信息</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static bool PostDownFlowFile(commInfoModel<FileModel> info)
        {
            //文件是否下载成功
            bool filestate = false;
            info.UserName = CommonData.UserInfo.names;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostDownFile(ApiConst.UrlFlowDownFile, jsonStr);
            //commReInfo<FileModel> reInfo = new commReInfo<FileModel>();
            //List<FileModel> files = new List<FileModel>();
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<FileModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<FileModel>>(jm);
                    string msg = "";
                    foreach (FileModel fileinfo in commReInfo.infos)
                    {
                        if (fileinfo.code == 0)
                        {
                            string fullFilePath = filePath+ "\\flow";

                            if (!Directory.Exists(fullFilePath))
                                Directory.CreateDirectory(fullFilePath);
                            if (fileinfo.dirname != null && fileinfo.dirname != "")
                            {
                                fullFilePath = filePath + "\\flow\\" + fileinfo.dirname;
                                if (!Directory.Exists(fullFilePath))
                                    Directory.CreateDirectory(fullFilePath);
                            }
                            fullFilePath += "\\" + fileinfo.fileName;
                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);
                            //返回生成是否成功
                            filestate = FileConverHelpers.StringToFile(fullFilePath, fileinfo.fileString.ToString());
                            if(filestate)
                            {
                                //FileModel fileModel = new FileModel();
                                //fileModel.code = 0;
                                //fileModel.fileName = fullFilePath;
                                //files.Add(fileModel);
                            }
                            else
                            {
                                msg += fileinfo.fileName + ":" + "获取文件失败" + "\r\n";
                                break;
                            }
                        }
                        else
                        {
                            msg += fileinfo.fileName + ":" + fileinfo.msg + "\r\n";
                        }
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //reInfo.infos = files;
            return filestate;
        }

        /// <summary>
        /// 流程文件上传
        /// </summary>
        /// <param name="fileType">文件类型</param>
        /// <param name="info">获取文件信息</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static void PostUpFlowFile(commInfoModel<FileModel> info)
        {
            info.UserName = CommonData.UserInfo.names;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr= ApiConnections.PostUpFile(ApiConst.UrlFlowUpFile, jsonStr);
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0&&jm.data!=null)
                {
                    commReInfo<commRehandleModel> commReInfo= Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<commRehandleModel>>(jm);
                    string msg = "";
                    foreach(commRehandleModel commRehandle in commReInfo.infos)
                    {
                        if (commRehandle.code != 0)
                        {
                            msg += commRehandle.info + ":" + commRehandle.msg + "\r\n";
                        }
                    }
                    if(msg!="")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public static string PostDownSysFile(string dirname, string info, string fileName)
        {
            return ApiConnections.PostTestDownFile(dirname, ApiConst.UrlSysDownFile, info, fileName);
        }
        public static void PostUpSysFile(commInfoModel<FileModel> info)
        {
            info.UserName = CommonData.UserInfo.names;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostUpFile(ApiConst.UrlSysUpFile, jsonStr);
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<commRehandleModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<commRehandleModel>>(jm);
                    string msg = "";
                    foreach (commRehandleModel commRehandle in commReInfo.infos)
                    {
                        //if(commRehandle.code==0)
                        //{
                        msg += commRehandle.info + ":" + commRehandle.msg + "\r\n";
                        //}
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 下载报告文件
        /// </summary>
        /// <param name="info"></param>
        /// <param name="SavePath"></param>
        /// <returns></returns>
        public static bool PostDownReportFile(GetReportModel info,out string SavePath)
        {
            SavePath = "";
            //文件是否下载成功
            bool filestate = false;
            info.UserName = CommonData.UserInfo.names;
            //string ApiHerf = UrlReportDownFile;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostDownFile(ApiConst.UrlReportDownFile, jsonStr);
            //commReInfo<FileModel> reInfo = new commReInfo<FileModel>();
            //List<FileModel> files = new List<FileModel>();
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<FileModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<FileModel>>(jm);
                    string msg = "";
                    foreach (FileModel fileinfo in commReInfo.infos)
                    {
                        if (fileinfo.code == 0)
                        {

                            string fullFilePath = filePath + "\\Report";
                            if (!Directory.Exists(fullFilePath))
                                Directory.CreateDirectory(fullFilePath);
                            if (fileinfo.dirname != null && fileinfo.dirname != "")
                            {
                                fullFilePath = filePath + "\\Report\\" + fileinfo.dirname;
                                if (!Directory.Exists(fullFilePath))
                                    Directory.CreateDirectory(fullFilePath);
                            }
                                
                            fullFilePath += "\\" + fileinfo.fileName;
                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);
                            //返回生成是否成功
                            filestate = FileConverHelpers.StringToFile(fullFilePath, fileinfo.fileString.ToString());
                            if (filestate)
                            {
                                SavePath = fullFilePath;
                                //FileModel fileModel = new FileModel();
                                //fileModel.code = 0;
                                //fileModel.fileName = fullFilePath;
                                //files.Add(fileModel);
                            }
                            else
                            {
                                msg += fileinfo.fileName + ":" + "获取文件失败" + "\r\n";
                                break;
                            }
                        }
                        else
                        {
                            msg += fileinfo.fileName + ":" + fileinfo.msg + "\r\n";
                        }
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if(jm.code!=2)
                        MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //reInfo.infos = files;
            return filestate;
        }


        /// <summary>
        /// 下载报告文件到指定文件目录
        /// </summary>
        /// <param name="info"></param>
        /// <param name="SavePath"></param>
        /// <returns></returns>
        public static bool PostDownReportFile(GetReportModel info,string SavePath)
        {
            //文件是否下载成功
            bool filestate = false;
            info.UserName = CommonData.UserInfo.names;
            //string ApiHerf = UrlReportDownFile;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostDownFile(ApiConst.UrlReportDownFile, jsonStr);
            //commReInfo<FileModel> reInfo = new commReInfo<FileModel>();
            //List<FileModel> files = new List<FileModel>();
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<FileModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<FileModel>>(jm);
                    string msg = "";
                    foreach (FileModel fileinfo in commReInfo.infos)
                    {
                        if (fileinfo.code == 0)
                        {
                            string fullFilePath = SavePath;
                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);
                            //返回生成是否成功
                            filestate = FileConverHelpers.StringToFile(fullFilePath, fileinfo.fileString.ToString());

                        }
                        else
                        {
                            msg += fileinfo.fileName + ":" + fileinfo.msg + "\r\n";
                        }
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (jm.code != 2)
                        MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //reInfo.infos = files;
            return filestate;
        }




        /// <summary>
        /// 预览报告文件
        /// </summary>
        /// <param name="info">下载文件参数</param>
        /// <param name="SavePath">文件生成地址</param>
        /// <returns></returns>
        public static bool PostViewReportFile(GetReportModel info, out string SavePath)
        {
            SavePath = "";
            //SavePath ="Temp-"+Guid.NewGuid().ToString("N");
            //文件是否下载成功
            bool filestate = false;
            info.UserName = CommonData.UserInfo.names;
            //string ApiHerf = UrlReportDownFile;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostDownFile(ApiConst.UrlReportDownFile, jsonStr);
            //commReInfo<FileModel> reInfo = new commReInfo<FileModel>();
            //List<FileModel> files = new List<FileModel>();
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<FileModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<FileModel>>(jm);
                    string msg = "";
                    List<string> filePaths = new List<string>();
                    foreach (FileModel fileinfo in commReInfo.infos)
                    {
                        if (fileinfo.code == 0)
                        {
                            string fullFilePath = filePath + "\\Report";
                            if (!Directory.Exists(fullFilePath))
                                Directory.CreateDirectory(fullFilePath);
                            if (fileinfo.dirname != null && fileinfo.dirname != "")
                            {
                                fullFilePath = filePath + "\\Report\\" + fileinfo.dirname;
                                if (!Directory.Exists(fullFilePath))
                                    Directory.CreateDirectory(fullFilePath);
                            }

                            fullFilePath += "\\" + fileinfo.fileName;
                            if (File.Exists(fullFilePath))
                                File.Delete(fullFilePath);
                            //返回生成是否成功
                            filestate = FileConverHelpers.StringToFile(fullFilePath, fileinfo.fileString.ToString());
                            if (filestate)
                            {
                                filePaths.Add(fullFilePath);
                                //FileModel fileModel = new FileModel();
                                //fileModel.code = 0;
                                //fileModel.fileName = fullFilePath;
                                //files.Add(fileModel);
                            }
                            else
                            {
                                msg += fileinfo.fileName + ":" + "获取文件失败" + "\r\n";
                                break;
                            }
                        }
                        else
                        {
                            msg += fileinfo.fileName + ":" + fileinfo.msg + "\r\n";
                        }
                    }

                    if(filePaths.Count>0)
                    {
                        MergePDFHelper.MergeAspose(filePaths,out SavePath);
                    }



                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (jm.code != 2)
                        MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //reInfo.infos = files;
            return filestate;
        }


        /// <summary>
        /// 下载报告文件stream信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static bool PostDownReportStream(GetReportModel info,out Stream fileStream)
        {
            fileStream = null;
            //文件是否下载成功
            bool filestate = false;
            info.UserName = CommonData.UserInfo.names;
            //string ApiHerf = UrlReportDownFile;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostDownFile(ApiConst.UrlReportDownFile, jsonStr);
            //commReInfo<FileModel> reInfo = new commReInfo<FileModel>();
            //List<FileModel> files = new List<FileModel>();
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<FileModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<FileModel>>(jm);
                    string msg = "";
                    foreach (FileModel fileinfo in commReInfo.infos)
                    {
                        if (fileinfo.code == 0)
                        {
                            fileStream = FileConverHelpers.StringToStream(fileinfo.fileString.ToString());
                            if(fileStream!=null)
                                filestate = true;
                        }
                        else
                        {
                            msg += fileinfo.fileName + ":" + fileinfo.msg + "\r\n";
                        }
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (jm.code != 2)
                        MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //reInfo.infos = files;
            return filestate;
        }

        public static void PostUpReportFile(GetReportModel info)
        {
            info.UserName = CommonData.UserInfo.names;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            string sr = ApiConnections.PostUpFile(ApiConst.UrlReportUpFile, jsonStr);
            if (sr != "")
            {
                WebApiCallBack jm = Common.JsonHelper.JsonHelper.JsonConvertObject<WebApiCallBack>(sr);
                if (jm.code == 0 && jm.data != null)
                {
                    commReInfo<commRehandleModel> commReInfo = Common.JsonHelper.JsonHelper.JsonConvertObject<commReInfo<commRehandleModel>>(jm);
                    string msg = "";
                    foreach (commRehandleModel commRehandle in commReInfo.infos)
                    {
                        //if (commRehandle.code != 0)
                        //{
                            msg += commRehandle.info + ":" + commRehandle.msg + "\r\n";
                        //}
                    }
                    if (msg != "")
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        /// <summary>
        /// 获取报告文件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool GetReportFile(GetReportModel info)
        {
            info.UserName = CommonData.UserInfo.names;
            string ApiHerf = ApiConst.UrlReportDownFile;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            bool s = ApiConnections.PostHttpReportFile(ApiHerf, jsonStr);
            return s;
        }

        /// <summary>
        /// 压缩文件下载
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool GetReportRar(GetReportModel info)
        {
            info.UserName = CommonData.UserInfo.names;
            string ApiHerf = ApiConst.UrlReportDownFile;
            string jsonStr = Common.JsonHelper.JsonHelper.SerializeObjct(info);
            bool s = ApiConnections.PostHttpReportRar(ApiHerf, jsonStr);
            return s;
        }
    }
}
