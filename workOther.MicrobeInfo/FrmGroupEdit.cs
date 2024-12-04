using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;

namespace workOther.MicrobeInfo
{
    public partial class FrmGroupEdit : XtraForm
    {
        int EditState = 0;
        int SelectID = 0;
        public FrmGroupEdit(int infoNO, DataRow dataRow)
        {
            InitializeComponent();

            TextEdits.TextFormat(TEsort);


            if (dataRow == null)
            {
                TEno.EditValue = infoNO;
                TEsort.EditValue = 999;
                CEstate.Checked = true;
                EditState = 1;

            }
            else
            {
                EditState = 2;
                CEstate.Checked = Convert.ToBoolean(dataRow["state"]);
                SelectID = Convert.ToInt32(dataRow["id"]);
                TEno.EditValue = dataRow["no"];
                TEsort.EditValue = dataRow["sort"];
                TEcustomCode.EditValue = dataRow["customCode"];
                TEnames.EditValue = dataRow["names"];
                TEremark.EditValue = dataRow["remark"];
                TEshortNames.EditValue = dataRow["shortNames"];
            }
        }

        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTSave_Click(object sender, EventArgs e)
        {

            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("state", CEstate.EditValue);
            //pairs.Add("id", TEid.EditValue);
            pairs.Add("no", TEno.EditValue);
            pairs.Add("sort", TEsort.EditValue);
            pairs.Add("customCode", TEcustomCode.EditValue);
            pairs.Add("names", TEnames.EditValue);
            pairs.Add("remark", TEremark.EditValue);
            pairs.Add("shortNames", TEshortNames.EditValue);
            pairs.Add("dstate", 0);


            int a = 0;
            if (EditState == 1)
            {
                iInfo iInfo = new iInfo();
                iInfo.TableName = "WorkComm.MicrobeGroupList";
                iInfo.values = pairs;
                a = ApiHelpers.postInfo(iInfo);
            }
            else
            {
                if (SelectID != 0)
                {
                    uInfo uInfo = new uInfo();
                    uInfo.TableName = "WorkComm.MicrobeGroupList";
                    uInfo.values = pairs;
                    uInfo.DataValueID = SelectID;
                    a = ApiHelpers.postInfo(uInfo);
                }
            }
            this.Close();
        }

        private void TEnames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
            {
                TEshortNames.EditValue = ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
            }

        }
    }
}
