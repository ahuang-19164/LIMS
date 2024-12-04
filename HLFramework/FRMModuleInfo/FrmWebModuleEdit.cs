using Common.BLL;
using Common.Data;
using Common.SqlModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace HLFramework
{
    public partial class FrmWebModuleEdit : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.PowerListWeb";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmWebModuleEdit()
        {
            InitializeComponent();
        }
        public FrmWebModuleEdit(string ModuleNO, string NOs, int State)
        {
            InitializeComponent();
            EditState = State;
            TENO.Text = TETagValue.Text = NOs;
            TEModuleNO.EditValue = ModuleNO;
            TEModuleNO.Properties.DataSource = CommonData.DTWebPowerListAll;
            TEModuleNO.Properties.ValueMember = "no";
            TEModuleNO.Properties.DisplayMember = "names";
            //TEModuleNO.Properties.itemindex = 0;
        }
        public FrmWebModuleEdit(DataRow DR, int State)
        {
            InitializeComponent();
            EditState = State;
            TEModuleNO.Properties.DataSource = CommonData.DTWebPowerListAll;
            TEModuleNO.Properties.ValueMember = "no";
            TEModuleNO.Properties.DisplayMember = "names";

            SelectValueID = Convert.ToInt32(DR["id"]);
            TEModuleNO.EditValue = DR["ModuleNO"];
            TENO.Text = DR["no"].ToString();
            TENames.Text = DR["names"].ToString();
            TEItemicon.Text = DR["itemicon"].ToString();
            TEHrefPath.Text = DR["HrefPath"].ToString();
            TETagValue.Text = DR["tagValue"].ToString();
            TERemark.Text = DR["Remark"].ToString();
            CBstate.Checked = Convert.ToBoolean(DR["state"]);

        }















        private void BTSave_Click(object sender, EventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("ModuleNO", TEModuleNO.EditValue.ToString());
                pairs.Add("no", TENO.Text.ToString());
                pairs.Add("names", TENames.Text.ToString());
                pairs.Add("itemicon", TEItemicon.Text.ToString());
                pairs.Add("HrefPath", TEHrefPath.Text.ToString());
                pairs.Add("tagValue", TETagValue.Text.ToString());
                pairs.Add("Remark", TERemark.Text.ToString());
                pairs.Add("state", CBstate.Checked.ToString());
                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                ApiHelpers.postInfo(insertInfo);
            }
            if (EditState == 2)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("ModuleNO", TEModuleNO.EditValue.ToString());
                pairs.Add("no", TENO.Text.ToString());
                pairs.Add("names", TENames.Text.ToString());
                pairs.Add("itemicon", TEItemicon.Text.ToString());
                pairs.Add("HrefPath", TEHrefPath.Text.ToString());
                pairs.Add("tagValue", TETagValue.Text.ToString());
                pairs.Add("Remark", TERemark.Text.ToString());
                pairs.Add("state", CBstate.Checked.ToString());
                uInfo updateInfo = new uInfo();
                updateInfo.TableName = tableName;
                updateInfo.values = pairs;
                ApiHelpers.postInfo(updateInfo);
            }
            this.Close();
        }
        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
