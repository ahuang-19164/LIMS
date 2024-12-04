using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workOther.SampleStores
{
    public partial class FrmShelfAdd : XtraForm
    {
        int EditState = 0;
        int shelfId = 0;
        string tablename = "sw_shelf";
        string GetShelfSerial = "";
        public FrmShelfAdd()
        {
            InitializeComponent();
            FRMInit();

        }
        /// <summary>
        /// 新建标本架方法
        /// </summary>
        /// <param name="StoresInfoDR"></param>
        public FrmShelfAdd(DataRow StoresInfoDR)
        {
            EditState = 1;
            this.Text ="新增标本架";
            InitializeComponent();
            TENO.EditValue = StoresInfoDR["id"]+"-"+DateTime.Now.ToString("yyyyMMddHHmmss");
            TEStoresNO.EditValue = StoresInfoDR["id"];
            TESaveDay.EditValue = StoresInfoDR["saveDay"];
            TEShelfCell.EditValue = StoresInfoDR["storesCell"];
            TEShelfRow.EditValue = StoresInfoDR["storesRow"];
            //标本架状态

            GEShelfType.EditValue = "1";//1.正常 2.存在过期 3.到存储时间 4.已处理 5.异常
            GEShelfType.Enabled = false;
            CEState.Checked = true;

            FRMInit();



            var jm= ApiHelpers.postInfo(GetShelfSerial);
            TENO.EditValue = jm.data.ToString();


        }
        /// <summary>
        /// 编辑标本架方法
        /// </summary>
        /// <param name="editstate"></param>
        /// <param name="shelfDR"></param>
        public FrmShelfAdd(int editstate,DataRow shelfDR)
        {
            this.Text = "编辑标本架";
            EditState = editstate;
            InitializeComponent();
            shelfId = Convert.ToInt32(shelfDR["id"]);
            TENO.EditValue = shelfDR["no"];
            TENames.EditValue = shelfDR["names"];
            TEStoresSaveNo.EditValue = shelfDR["saveNo"];
            TEStoresNO.EditValue = shelfDR["storesNO"];
            TESaveDay.EditValue = shelfDR["saveDay"];
            TEShelfCell.EditValue = shelfDR["shelfCell"];
            TEShelfRow.EditValue = shelfDR["shelfRow"];
            CEState.Checked = Convert.ToBoolean(shelfDR["state"]);
            //标本架状态
            GEShelfType.EditValue = shelfDR["shelfTypeNO"];;//1.正常 2.存在过期 3.到存储时间 4.已处理 5.异常
            TERemark.EditValue= shelfDR["remark"];
            FRMInit();

        }

        /// <summary>
        /// 窗体初始化方法
        /// </summary>
        private void FRMInit()
        {
            TextEdits.TextFormat(TESaveDay);
            TextEdits.TextFormat(TEShelfCell);
            TextEdits.TextFormat(TEShelfRow);
            GridLookUpEdites.Formats(GEShelfType, SWCommData.DTShelfType);
            GetShelfSerial = ConfigInfos.ReadConfigInfo("GetShelfSerial");
        }


        private void BTSave_Click(object sender, EventArgs e)
        {
            if(EditState==1)
            {
                iInfo iInfo = new iInfo();
                iInfo.TableName = tablename;
                Dictionary<string, object> pairs = new Dictionary<string, object>();


                pairs.Add("no", TENO.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("saveNo", TEStoresSaveNo.EditValue);
                pairs.Add("storesNO", TEStoresNO.EditValue);
                pairs.Add("saveDay", TESaveDay.EditValue);
                pairs.Add("shelfCell", TEShelfCell.EditValue);
                pairs.Add("shelfRow", TEShelfRow.EditValue);
                pairs.Add("shelfTypeNO", GEShelfType.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                pairs.Add("sampleCount", 0);
                pairs.Add("state", CEState.Checked);
                pairs.Add("createTime", DateTime.Now);
                iInfo.values = pairs;
                iInfo.MessageShow = 1;

                //pairs.Add("createTime", DateTime.Now);
                int a = ApiHelpers.postInfo(iInfo);
                this.Close();
            }
            if (EditState == 2)
            {
                uInfo uInfo = new uInfo();
                uInfo.TableName = tablename;
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("saveNo", TEStoresSaveNo.EditValue);
                pairs.Add("storesNO", TEStoresNO.EditValue);
                pairs.Add("saveDay", TESaveDay.EditValue);
                pairs.Add("shelfCell", TEShelfCell.EditValue);
                pairs.Add("shelfRow", TEShelfRow.EditValue);
                pairs.Add("shelfTypeNO", GEShelfType.EditValue);
                pairs.Add("state", CEState.Checked);
                pairs.Add("remark", TERemark.EditValue);
                uInfo.values = pairs;
                uInfo.DataValueID = shelfId;

                //pairs.Add("createTime", DateTime.Now);
                int a = ApiHelpers.postInfo(uInfo);
                this.Close();
            }

        }
        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
