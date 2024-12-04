using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkTest.TestTCTScreen
{
    public partial class SuperPictureEdit : UserControl
    {




        //public  delegate void DLShowImgEdit(object sender, EventArgs e);//委托的声明
        //public DLShowImgEdit DLShowImgEdits;//创建委托对象;


        //public PictureEdit PictureEdit { get; set; }
        public string labstring { get; set; }
        public string combostring { get; set; }
        /// <summary>
        /// 图片类型   1.取材图片，2.阅片图片
        /// </summary>
        public string pictureType { get; set; }
        public Bitmap bitmap { get; set; }


        public SuperPictureEdit()
        {
            InitializeComponent();
            //DLShowImgEdits += dLShowImg;
        }
        private void SuperPictureEdit_Load(object sender, EventArgs e)
        {



            Bitmap bitmaps = new Bitmap(bitmap);
            pictureEdit1.Image = bitmaps;
            pictureEdit1.Click += PictureEdit_Click;
            pictureEdit1.DoubleClick += PictureEdit_DoubleClick; ;
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            labelControl1.Text = labstring;
            comboBoxEdit1.Properties.Items.AddRange(new string[] { "HE：10X10", "HE：4X10", "HE：20X10", "HE：40X10", "HE：100X10", "巴氏：10X10", "巴氏：20X10", "巴氏：4X10", "巴氏：40X10", "巴氏：100X10" });
            if (pictureType == "1")
            {
                comboBoxEdit1.Visible = false;
            }
            if (combostring == null)
            {
                comboBoxEdit1.SelectedIndex = 5;
            }
            else
            {
                comboBoxEdit1.EditValue = combostring;
            }


        }
        private void PictureEdit_Click(object sender, EventArgs e)
        {
            FrmTestTCTScreen.Picture = sender as PictureEdit;
            FrmTestTCTScreen.SuperPicture = this;
        }

        private void PictureEdit_DoubleClick(object sender, EventArgs e)
        {
            pictureEdit1.ShowImageEditorDialog();
        }
    }
}
