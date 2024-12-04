using Common.BLL;
using Common.Conn;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using DevExpress.LookAndFeel;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmLoadInfo : DevExpress.XtraEditors.XtraForm
    {
        string UpFileHandle = "";
        public FrmLoadInfo()
        {

            InitializeComponent();
            UpFileHandle = ConfigInfos.ReadConfigInfo("GetUpgradeInfos");
            UpInfoHandle();
            backgroundWorker.RunWorkerAsync();
        }

        public void UpInfoHandle()
        {
            ClientInfoModel clientInfo = new ClientInfoModel();
            clientInfo.UserName = CommonData.UserInfo.names;
            //clientInfo.UserToken = CommonData.tokenInfo.token;
            clientInfo.Name = Application.ProductName;
            clientInfo.Version = CommonData.version;
            clientInfo.state = 1;
            string sr = JsonHelper.SerializeObjct(clientInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(UpFileHandle, sr);
            
            if (jm.code == 0&& jm.data!=null)
            {
                clientModel clientInfos = JsonHelper.JsonConvertObject<clientModel>(jm);
                clientInfos.userName = CommonData.UserInfo.names;
                //clientInfos.userToken = CommonData.tokenInfo.token;
                FrmUpFileInfo frmUpFileInfo = new FrmUpFileInfo(clientInfos);
                frmUpFileInfo.ShowDialog();
            }
        }





        private void BTClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLoadInfo_Shown(object sender, EventArgs e)
        {
            ////try
            ////{
            ////string configpath = Application.StartupPath+"\\AppConnection.info";
            ////if(File.Exists(configpath))
            ////{
            ////    StreamReader streamReader = new StreamReader(configpath);
            ////    string infos = streamReader.ReadToEnd();

            ////}
            //Task CommInfoLoad = new Task(() =>
            //{
            //        //CommonDataRefresh systemInfo = new CommonDataRefresh();
            //        CommonDataRefresh.GetSystemInfo();

            //});
            //CommInfoLoad.Start();
            //CommInfoLoad.Wait();
            //this.Close();
            //FrmSystemMain frmSystem = new FrmSystemMain();
            //frmSystem.Show();
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////}





        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Task CommInfoLoad = new Task(() =>
            {
                //CommonDataRefresh systemInfo = new CommonDataRefresh();
                CommonDataRefresh.GetSystemInfo();

            });
            CommInfoLoad.Start();
            CommInfoLoad.Wait();

        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {


        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Close();
            if(CommonData.style=="2")
            {
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");//皮肤主题
                FrmSystemMain frmSystem = new FrmSystemMain();
                frmSystem.Show();
            }
            else
            {
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
            }

        }
    }
}
