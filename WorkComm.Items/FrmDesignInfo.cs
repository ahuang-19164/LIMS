using Common.BLL;
using Common.ControlHandle;
using Common.Data;
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

namespace WorkComm.Items
{
    public partial class FrmDesignInfo : XtraForm
    {


        public FrmDesignInfo()
        {
            InitializeComponent();
            GridControls.formartGridView(GVFlowInfo);
            GridControls.showEmbeddedNavigator(GCFlowInfo);
        }

        private void FrmDesignInfo_Load(object sender, EventArgs e)
        {
            GCFlowInfo.DataSource = DTHelper.DTVisible(WorkCommData.DTItemFlow).Select("frmState=1").CopyToDataTable();
        }

        private void GVFlowInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVFlowInfo.GetFocusedDataRow();

        }
        //panl内部切换窗体方法
        private void form(Form form)
        {
            foreach (Control item in this.panel1.Controls)
            {
                if (item is Form)
                {
                    Form ctl = (Form)item;
                    ctl.Close();
                    //((Form)item).Close();
                }
            }
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            //form.ControlBox = false;
            form.Parent = this.panel1;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
    }
}
