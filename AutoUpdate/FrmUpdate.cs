using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{

    public partial class FrmUpdate : Form
    {
        string FileInfoPath = "";
        clientModel clientModel;
        public FrmUpdate()
        {
            InitializeComponent();
            FileInfoPath = Application.StartupPath;
        }
        //List<FileInfoModel> fileInfos;
        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            FileInfoPath += "\\UpDateFileInfo.log";
            if (File.Exists(FileInfoPath))
            {
                StreamReader fileStream = new StreamReader(FileInfoPath, Encoding.UTF8);
                string info = fileStream.ReadToEnd().Replace("\r\n", "");
                clientModel = JsonConvertObject<clientModel>(info);
                LBversion.Text = "更新版本号:" + clientModel.Version;

                fileStream.Close();



                progressBar.Maximum = clientModel.fileInfo.Count;
                backgroundWorker.WorkerReportsProgress = true;
                //backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("未找到更新配置文件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //fileInfos = clientModel.fileInfo;



        }

        /// <summary>
        /// 将对象序列化为json格式
        /// </summary>
        /// <param name="obj">序列化对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObjct(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static T JsonConvertObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (clientModel != null)
                {

                    if (clientModel.fileInfo.Count > 0)
                    {
                        int i = 0;

                        foreach (FileInfoModel fileInfo in clientModel.fileInfo)
                        {
                            i += 1;

                            string FileName = fileInfo.FileName != null ? fileInfo.FileName : "";
                            if (FileName != "")
                            {

                                DownFileModel downFile = new DownFileModel();
                                downFile.UserName = clientModel.userName;
                                downFile.UserToken = clientModel.userToken;
                                downFile.FileName = FileName;
                                string ApiHerf = clientModel.urlPath;
                                string sr = SerializeObjct(downFile);
                                ApiHelper.PostHttpDownFile(ApiHerf, sr, FileName);
                                //a = a;
                            }





                            backgroundWorker.ReportProgress(i);

                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("更新完成，请从新登录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            File.Delete(FileInfoPath);
            Application.Exit();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            LBText.Text = $"{e.ProgressPercentage}/{clientModel.fileInfo.Count}";
        }
    }
}
