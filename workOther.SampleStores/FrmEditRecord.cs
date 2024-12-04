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
    public partial class FrmEditRecord : XtraForm
    {

        DataRow infoDR;

        public FrmEditRecord()
        {
            InitializeComponent();
        }
        public FrmEditRecord(DataRow recordDR)
        {
            InitializeComponent();

            GridLookUpEdites.Formats(GErecordTypeNO, SWCommData.DTRecordType);


            infoDR = recordDR;
            TEid.EditValue         = recordDR["id"];
            TEbarcode.EditValue    = recordDR["barcode"];
            DEcreateTime.EditValue = recordDR["createTime"];
            DEoutTime.EditValue     = recordDR["outTime"];
            GErecordTypeNO.EditValue = recordDR["recordTypeNO"];
            TEremark.EditValue= recordDR["remark"];
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            uInfo uInfo = new uInfo();
            uInfo.TableName = "sw_record";
            Dictionary<string, object> pairs = new Dictionary<string, object>();

            infoDR["outTime"] = DEoutTime.EditValue;
            infoDR["recordTypeNO"] = GErecordTypeNO.EditValue;
            infoDR["remark"] = TEremark.EditValue;
            pairs.Add("state",0);
            pairs.Add("outTime", DEoutTime.EditValue);
            pairs.Add("recordTypeNO", GErecordTypeNO.EditValue);
            pairs.Add("remark", TEremark.EditValue);
            uInfo.values = pairs;
            uInfo.wheres = $"id={TEid.EditValue}";
            uInfo.MessageShow = 1;
            ApiHelpers.postInfo(uInfo);
            this.Close();
        }

        private void BTClaer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
