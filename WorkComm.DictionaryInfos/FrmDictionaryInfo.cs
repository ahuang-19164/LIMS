using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.DictionaryInfos
{
    public partial class FrmDictionaryInfo : DevExpress.XtraEditors.XtraForm
    {

        
        string tableName = "WorkComm.WorkDictionary";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmDictionaryInfo()
        {
            InitializeComponent();
            layoutControl1.Enabled = false;
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);

            TextEdits.TextFormat(TESort);
        }
        private void FrmDictionaryInfo_Load(object sender, EventArgs e)
        {
            GCInfo.DataSource = WorkCommData.DTWorkDictionary;
        }

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl1.Enabled = true;
            EditState = 1;
            if (WorkCommData.DTWorkDictionary.Select("no is not NULL", "no DESC").Count() == 0)
            {
                TENO.EditValue = 1;
            }
            else
            {
                TENO.EditValue = Convert.ToInt32(WorkCommData.DTWorkDictionary.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            //TENames.EditValue = "";
            TEclass.EditValue = "";
            TEType.EditValue = "";
            TEShortNames.EditValue = "";
            TECustomCode.EditValue = "";
            TESort.EditValue = 999;
            CEState.Checked = false;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue);
                pairs.Add("state", CEState.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("class", TEclass.EditValue);
                pairs.Add("type", TEType.EditValue);
                pairs.Add("ShortNames", TEShortNames.EditValue);
                pairs.Add("sort", TESort.EditValue);
                pairs.Add("CustomCode", TECustomCode.EditValue);
                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = ApiHelpers.postInfo(insertInfo);

            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    //pairs.Add("no", TENO.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("class", TEclass.EditValue);
                    pairs.Add("type", TEType.EditValue);
                    pairs.Add("ShortNames", TEShortNames.EditValue);
                    pairs.Add("sort", TESort.EditValue);
                    pairs.Add("CustomCode", TECustomCode.EditValue);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }
            }
            EditState = 0;
            CommonDataRefresh.GetWorkDictionary();
            FrmDictionaryInfo_Load(null, null);
            layoutControl1.Enabled = false;

        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("确定删除当前信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    if (SelectValueID != 0)
                    {
                        int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                        if (a > 0)
                        {
                            CommonDataRefresh.GetWorkDictionary();
                            GVInfo.DeleteSelectedRows();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GVInfo_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                if (WorkCommData.DTWorkDictionary != null)
                {
                    SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));

                    DataRow[] rows = WorkCommData.DTWorkDictionary.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        CEState.EditValue = Convert.ToBoolean(rows[0]["state"]);
                        TENO.EditValue = rows[0]["no"];
                        TENames.EditValue = rows[0]["names"];
                        TEclass.EditValue = rows[0]["class"];
                        TEType.EditValue = rows[0]["type"];
                        TEShortNames.EditValue = rows[0]["ShortNames"];
                        TECustomCode.EditValue = rows[0]["CustomCode"];
                        TESort.EditValue = rows[0]["sort"];

                    }
                }
            }
        }

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TENames.EditValue != null)
            {
                TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
            }

        }
    }
}
