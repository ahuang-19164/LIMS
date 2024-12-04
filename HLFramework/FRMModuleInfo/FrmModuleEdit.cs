using Common.BLL;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmModuleEdit : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.PowerList";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmModuleEdit()
        {
            InitializeComponent();
        }
        public FrmModuleEdit(string ModuleNO, string NOs, int State)
        {
            InitializeComponent();
            EditState = State;
            TENO.Text = TETagValue.Text = NOs;
            TEModuleNO.EditValue = ModuleNO;


            TEModuleNO.Properties.DataSource = CommonData.DTPowerListAll;
            TEModuleNO.Properties.ValueMember = "no";
            TEModuleNO.Properties.DisplayMember = "names";
            //TEModuleNO.Properties.itemindex = 0;
        }
        public FrmModuleEdit(DataRow DR, int State)
        {
            InitializeComponent();
            EditState = State;
            TEModuleNO.Properties.DataSource = CommonData.DTPowerListAll;
            TEModuleNO.Properties.ValueMember = "no";
            TEModuleNO.Properties.DisplayMember = "names";

            SelectValueID = Convert.ToInt32(DR["id"]);
            PEItemImg.EditValue = DR["itemImg"];
            TEModuleNO.EditValue = DR["moduleNO"];
            TENO.Text = DR["no"].ToString();
            TENames.Text = DR["names"].ToString();
            TELibraryName.Text = DR["libraryName"].ToString();
            TEClassName.Text = DR["className"].ToString();
            TETagValue.Text = DR["tagValue"].ToString();
            TERemark.Text = DR["remark"].ToString();
            CBstate.Checked = Convert.ToBoolean(DR["state"]);
        }

        /// <summary>
        /// 将对象转换为byte数组
        /// </summary>
        /// <param name="obj">被转换对象</param>
        /// <returns>转换后byte数组</returns>
        public static byte[] Object2Bytes(object obj)
        {
            byte[] buff;
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter iFormatter = new BinaryFormatter();
                iFormatter.Serialize(ms, obj);
                buff = ms.GetBuffer();
            }
            return buff;
        }
















        private void BTSave_Click(object sender, EventArgs e)
        {
            FileConverHelper fileConverHelper = new FileConverHelper();
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("moduleNO", TEModuleNO.EditValue.ToString());
                pairs.Add("itemImg", fileConverHelper.BitmapTostring(bitmap));
                pairs.Add("no", TENO.Text.ToString());
                pairs.Add("names", TENames.Text.ToString());
                pairs.Add("libraryName", TELibraryName.Text.ToString());
                pairs.Add("className", TEClassName.Text.ToString());
                pairs.Add("tagValue", TETagValue.Text.ToString());
                pairs.Add("remark", TERemark.Text.ToString());
                pairs.Add("state", CBstate.Checked.ToString());
                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                ApiHelpers.postInfo(insertInfo);

                //Dictionary<string, DataParameterType> pairs = new Dictionary<string, DataParameterType>();
                //DataParameterType dataParameter = new DataParameterType();
                //dataParameter.DataTypes = "text";
                //dataParameter.DataTypes = TEModuleNO.EditValue.ToString();
                //pairs.Add("ModuleNO", dataParameter);

                //pairs.Add("no", new DataParameterType { DataTypes = "text", DataValues = TENO.Text.ToString() });
                //pairs.Add("names", new DataParameterType { DataTypes = "text", DataValues = TENames.Text.ToString() });
                //pairs.Add("itemImg", new DataParameterType { DataTypes = "FileData", DataValues = PEItemImg.EditValue });
                //pairs.Add("libraryName", new DataParameterType { DataTypes = "text", DataValues = TELibraryName.Text.ToString() });
                //pairs.Add("className", new DataParameterType { DataTypes = "text", DataValues = TEClassName.Text.ToString() });
                //pairs.Add("tagValue", new DataParameterType { DataTypes = "text", DataValues = TETagValue.Text.ToString() });
                //pairs.Add("Remark", new DataParameterType { DataTypes = "text", DataValues = TERemark.Text.ToString() });
                //pairs.Add("state", new DataParameterType { DataTypes = "Bit", DataValues = CBstate.Checked });
                //sysAdmin.postinserts("Common.PowerList", valueID.ToString(), pairs);
                //MessageBox.Show
            }
            //if (EditState == 2)
            //{
            //    Dictionary<string, DataParameterType> pairs = new Dictionary<string, DataParameterType>();
            //    DataParameterType dataParameter = new DataParameterType();
            //    dataParameter.DataTypes = "text";
            //    dataParameter.DataTypes = TEModuleNO.EditValue.ToString();
            //    pairs.Add("ModuleNO", dataParameter);

            //    pairs.Add("no", new DataParameterType { DataTypes = "text", DataValues = TENO.Text.ToString() });
            //    pairs.Add("names", new DataParameterType { DataTypes = "text", DataValues = TENames.Text.ToString() });
            //    pairs.Add("itemImg", new DataParameterType { DataTypes = "FileData", DataValues = PEItemImg.EditValue });
            //    pairs.Add("libraryName", new DataParameterType { DataTypes = "text", DataValues = TELibraryName.Text.ToString() });
            //    pairs.Add("className", new DataParameterType { DataTypes = "text", DataValues = TEClassName.Text.ToString() });
            //    pairs.Add("tagValue", new DataParameterType { DataTypes = "text", DataValues = TETagValue.Text.ToString() });
            //    pairs.Add("Remark", new DataParameterType { DataTypes = "text", DataValues = TERemark.Text.ToString() });
            //    pairs.Add("state", new DataParameterType { DataTypes = "Bit", DataValues = CBstate.Checked });
            //    sysAdmin.EditFile("Common.PowerList", valueID.ToString(), pairs);
            //}
            if (EditState == 2)
            {

                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("moduleNO", TEModuleNO.EditValue.ToString());
                pairs.Add("itemImg", fileConverHelper.BitmapTostring(bitmap));
                pairs.Add("no", TENO.Text.ToString());
                pairs.Add("names", TENames.Text.ToString());
                pairs.Add("libraryName", TELibraryName.Text.ToString());
                pairs.Add("className", TEClassName.Text.ToString());
                pairs.Add("tagValue", TETagValue.Text.ToString());
                pairs.Add("remark", TERemark.Text.ToString());
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
        Bitmap bitmap = null;
        private void BTUpImg_Click(object sender, EventArgs e)
        {
            try
            {
                PEItemImg.Image = bitmap = FileConverHelpers.FilePathToBitmap(OpenFileHelpers.GetFilePath());
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查选择文件是否正常！" + ex, "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private byte[] getImageByte(string imagePath)
        //{
        //    FileStream files = new FileStream(imagePath, FileMode.Open);
        //    byte[] imgByte = new byte[files.Length];
        //    files.Read(imgByte, 0, imgByte.Length);
        //    files.Close();
        //    return imgByte;
        //}
    }
}
