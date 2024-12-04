using Common.BLL;
using Common.Conn;
using Common.JsonHelper;
using Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmUpFileInfo : DevExpress.XtraEditors.XtraForm
    {


        clientModel clientInfos;
        public FrmUpFileInfo(clientModel clientInfo)
        {
            InitializeComponent();

            if (clientInfo != null)
            {
                TEName.EditValue = clientInfo.Name;
                TEVersion.EditValue = clientInfo.Version;
                TEMsg.EditValue = clientInfo.msg;
                List<FileInfoModel> fileInfos = clientInfo.fileInfo;
                BindingList<FileInfoModel> bFlieInfo = new BindingList<FileInfoModel>(fileInfos);
                GCFileInfo.DataSource = bFlieInfo;
            }
            clientInfo.urlPath =ConfigInfos.ReadConfigInfo("UpgradeClient"); ;
            clientInfos = clientInfo;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmUpFileInfo_Load(object sender, EventArgs e)
        {
            //List<FileResult> fileResults = new List<FileResult>();
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTUpdate_Click(object sender, EventArgs e)
        {

            string UpApplication = Application.StartupPath;
            string FileInfoPath = UpApplication + "\\UpDateFileInfo.log";
            string sr = JsonHelper.SerializeObjct(clientInfos);
            StreamWriter streamWriter = new StreamWriter(FileInfoPath, false, Encoding.UTF8);
            streamWriter.Write(sr);
            streamWriter.Close();




            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = $"{UpApplication}\\AutoUpdate.exe"; //"输入完整的路径"
            process.StartInfo.Arguments = "AutoUpdate.exe"; //启动参数
            process.Start();



            Application.Exit();




            //BindingList<FileInfoModel> DTFileInfo = GCFileInfo.DataSource as BindingList<FileInfoModel>;
            //if(DTFileInfo != null)
            //{
            //    List<FileInfoModel> ListFileInfo = new List<FileInfoModel>(DTFileInfo);
            //    foreach (FileInfoModel DRFileInfo in ListFileInfo)
            //    {
            //        string FileName = DRFileInfo.FileName != null ? DRFileInfo.FileName : "";
            //        if(FileName!="")
            //        {

            //            DownFileModel downFile = new DownFileModel();
            //            downFile.UserName = CommonData.UserInfo.names;
            //            downFile.UserToken = CommonData.tokenInfo.token;
            //            downFile.FileName = FileName;
            //            string sr = JsonHelper.SerializeObjct(downFile);
            //            SqlConnServer.PostDownFile(sr,FileName);
            //            //a = a;
            //        }

            //    }

            //}
        }
    }
}
