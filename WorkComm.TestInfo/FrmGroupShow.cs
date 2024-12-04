using Common.BLL;
using Common.Data;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WorkComm.TestInfo
{
    public partial class FrmGroupShow : DevExpress.XtraEditors.XtraForm
    {
        string workNOs = "0";
        public FrmGroupShow(string workNO)
        {
            InitializeComponent();
            workNOs = workNO;
        }
        DevExpress.XtraBars.Ribbon.GalleryControl galleryControl;
        private void FrmGroupShow_Load(object sender, EventArgs e)
        {
            try
            {
                galleryControl = new DevExpress.XtraBars.Ribbon.GalleryControl();
                galleryControl.Dock = System.Windows.Forms.DockStyle.Fill;
                galleryControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
                galleryControl.Gallery.ImageSize = new Size(120, 90);
                galleryControl.Gallery.ShowItemText = true;
                //galleryControl.Click += GalleryControl_Click;
                DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
                galleryItemGroup.Caption = "专业组列表";
                galleryControl.Gallery.Groups.Add(galleryItemGroup);
                //DataTable DTUserGroup= WorkCommData.DTGroupWork.Select($"UserNO='2' and state=1").CopyToDataTable();
                DataTable DTUserGroup = WorkCommData.DTGroupPower.Select($"userNO='{CommonData.UserInfo.id}' and state=1").CopyToDataTable();
                if (CommonData.UserInfo.id == 1)
                {
                    DataTable DTTest = WorkCommData.DTGroupTest.Select("state=1 and dstate=0", "sort").CopyToDataTable();
                    foreach (DataRow Testrow in DTTest.Rows)
                    {
                        DevExpress.XtraBars.Ribbon.GalleryItem galleryItem = new DevExpress.XtraBars.Ribbon.GalleryItem();
                        galleryItem.Caption = Testrow["names"].ToString();
                        galleryItem.ImageOptions.Image = FileConverHelpers.StringToBitmap(Testrow["itemImg"].ToString());
                        galleryItem.ItemClick += GalleryItem_ItemClick;
                        galleryItem.Tag = Testrow["no"].ToString();
                        galleryItemGroup.Items.Add(galleryItem);
                    }
                    this.Controls.Add(galleryControl);
                }
                else
                {


                    if (workNOs == "0")
                    {
                        DataTable DTTest = WorkCommData.DTGroupTest.Select("state=1 and dstate=0", "sort").CopyToDataTable();
                        foreach (DataRow Testrow in DTTest.Rows)
                        {
                            foreach (DataRow Userrow in DTUserGroup.Rows)
                            {
                                if (Testrow["no"].ToString() == Userrow["testNO"].ToString())
                                {
                                    DevExpress.XtraBars.Ribbon.GalleryItem galleryItem = new DevExpress.XtraBars.Ribbon.GalleryItem();
                                    galleryItem.Caption = Testrow["names"].ToString();
                                    galleryItem.ImageOptions.Image = FileConverHelpers.StringToBitmap(Testrow["itemImg"].ToString());
                                    galleryItem.ItemClick += GalleryItem_ItemClick;
                                    galleryItem.Tag = Testrow["no"].ToString();
                                    galleryItemGroup.Items.Add(galleryItem);
                                }
                            }
                        }
                        this.Controls.Add(galleryControl);

                    }
                    else
                    {
                        DataTable DTTest = WorkCommData.DTGroupTest.Select($"state=1 and dstate=0 and workNO='{workNOs}'", "sort").CopyToDataTable();
                        foreach (DataRow Testrow in DTTest.Rows)
                        {
                            foreach (DataRow Userrow in DTUserGroup.Rows)
                            {
                                if (Testrow["no"].ToString() == Userrow["testNO"].ToString())
                                {
                                    DevExpress.XtraBars.Ribbon.GalleryItem galleryItem = new DevExpress.XtraBars.Ribbon.GalleryItem();
                                    galleryItem.Caption = Testrow["names"].ToString();
                                    galleryItem.ImageOptions.Image = FileConverHelpers.StringToBitmap(Testrow["itemImg"].ToString());
                                    galleryItem.ItemClick += GalleryItem_ItemClick;
                                    galleryItem.Tag = Testrow["no"].ToString();
                                    galleryItemGroup.Items.Add(galleryItem);
                                }
                            }
                        }
                        this.Controls.Add(galleryControl);
                    }
                }

            }
            catch
            {
                this.Close();
                MessageBox.Show("请检查系统配置", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }



        }
        string ItemTag = "";
        private void GalleryItem_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            DevExpress.XtraBars.Ribbon.GalleryItem GalleryItem = sender as DevExpress.XtraBars.Ribbon.GalleryItem;
            string c = e.Item.Tag.ToString();
            ItemTag = c;
            this.Close();

        }
        public string ReturnTag()
        {
            return ItemTag;
        }
    }
}
