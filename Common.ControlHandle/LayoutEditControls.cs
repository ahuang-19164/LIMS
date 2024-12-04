using Common.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Data;
using System.Windows.Forms;

namespace Common.ControlHandle
{
    public class LayoutEditControls
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static LayoutControl Produce(DataTable dt)
        {
            try
            {
                DataTable datas = dt.Select("state=1", "sort").CopyToDataTable();
                LayoutControl layoutControl = new LayoutControl();
                LayoutControlGroup layoutGroup = new LayoutControlGroup();
                layoutGroup.GroupBordersVisible = false;
                foreach (DataRow dataRow in datas.Rows)
                {
                    if (Convert.ToBoolean(dataRow["state"]) == false)
                    {
                        if (dataRow["ControlType"].ToString() == "TextEdit")
                        {
                            TextEdit textEdit = new TextEdit();
                            textEdit.Name = dataRow["ControlNames"].ToString();
                            textEdit.EditValue = dataRow["DefaultValue"].ToString();
                            textEdit.Visible = Convert.ToBoolean(dataRow["ControlVisible"]);
                            textEdit.Enabled = Convert.ToBoolean(dataRow["ControlEnabled"]);
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), textEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "ButtonEdit")
                        {
                            ButtonEdit buttonEdit = new ButtonEdit();
                            buttonEdit.Name = dataRow["ControlNames"].ToString();
                            buttonEdit.EditValue = dataRow["DefaultValue"].ToString();
                            buttonEdit.Visible = Convert.ToBoolean(dataRow["ControlVisible"]);
                            buttonEdit.Enabled = Convert.ToBoolean(dataRow["ControlEnabled"]);
                            //buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["Caption"].ToString(), buttonEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "DateEdit")
                        {
                            DateEdit dateEdit = new DateEdit();
                            dateEdit.Name = dataRow["ControlNames"].ToString();
                            dateEdit.Properties.DisplayFormat.FormatString = "g";
                            dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            dateEdit.Properties.EditFormat.FormatString = "g";
                            dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            dateEdit.Properties.Mask.EditMask = "g";
                            dateEdit.EditValue = dataRow["DefaultValue"].ToString();
                            dateEdit.Visible = Convert.ToBoolean(dataRow["ControlVisible"]);
                            dateEdit.Enabled = Convert.ToBoolean(dataRow["ControlEnabled"]);
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), dateEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "CheckEdit")
                        {
                            CheckEdit checkEdit = new CheckEdit();
                            checkEdit.Name = dataRow["ControlNames"].ToString();
                            checkEdit.Checked = true;
                            checkEdit.Visible = Convert.ToBoolean(dataRow["ControlVisible"]);
                            checkEdit.Enabled = Convert.ToBoolean(dataRow["ControlEnabled"]);
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), checkEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "GridLookUpEdit")
                        {
                            GridLookUpEdit gridLookUpEdit = new GridLookUpEdit();
                            gridLookUpEdit.Properties.DataSource = WorkCommData.DTWorkType.Select($"TypeNames='{dataRow["classNames"].ToString()}' and state=1 and dstate=0");
                            GridLookUpEdites.Formats(gridLookUpEdit);
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), gridLookUpEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "GridControl")
                        {
                            DataTable data = ControlViewData.GridViewData.Select($"TypeNames='{dataRow["classNames"].ToString()}' and state=1 and dstate=0").CopyToDataTable();
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlNames"].ToString(), GridControls.ProduceGridControl(data, true, true)) as LayoutControlItem;
                            layoutItem.TextVisible = false;
                            GridControls.ProduceGridControl(data, true, true).DataSource = data;
                        }

                    }
                }








                return layoutControl;
            }
            catch
            {
                return null;
            }

        }


        public static LayoutControlGroup GroupProduce(DataTable dt, Form form)
        {
            try
            {
                LayoutControl layoutControl = new LayoutControl();
                LayoutControlGroup layoutGroup = new LayoutControlGroup();
                layoutGroup.GroupBordersVisible = false;
                foreach (DataRow dataRow in dt.Rows)
                {
                    if (Convert.ToBoolean(dataRow["state"]) == false)
                    {
                        if (dataRow["ControlType"].ToString() == "TextEdit")
                        {
                            TextEdit textEdit = new TextEdit();
                            textEdit.Name = dataRow["ControlNames"].ToString();
                            textEdit.EditValue = dataRow["DefaultValue"].ToString();
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), textEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "ButtonEdit")
                        {
                            ButtonEdit buttonEdit = new ButtonEdit();
                            buttonEdit.Name = dataRow["ControlNames"].ToString();
                            buttonEdit.EditValue = dataRow["DefaultValue"].ToString();
                            //buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), buttonEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "DateEdit")
                        {
                            DateEdit dateEdit = new DateEdit();
                            dateEdit.Name = dataRow["ControlNames"].ToString();
                            dateEdit.Properties.DisplayFormat.FormatString = "g";
                            dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            dateEdit.Properties.EditFormat.FormatString = "g";
                            dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                            dateEdit.Properties.Mask.EditMask = "g";
                            dateEdit.EditValue = dataRow["DefaultValue"].ToString();
                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlCaption"].ToString(), dateEdit) as LayoutControlItem;
                        }
                        if (dataRow["ControlType"].ToString() == "GridLookUpEdit")
                        {
                            GridLookUpEdit gridLookUpEdit = new GridLookUpEdit();
                            gridLookUpEdit.Properties.DataSource = WorkCommData.DTWorkType.Select($"TypeName='{dataRow["classNames"].ToString()}' and state=1 and dstate=0");
                            GridLookUpEdites.Formats(gridLookUpEdit);
                        }


                        if (dataRow["ControlType"].ToString() == "GridControl")
                        {
                            DataTable data = ControlViewData.GridViewData.Select($"TypeName='{dataRow["classNames"].ToString()}' and state=1 and dstate=0").CopyToDataTable();

                            LayoutControlItem layoutItem = layoutGroup.AddItem(dataRow["ControlNames"].ToString(), GridControls.ProduceGridControl(data, true, true)) as LayoutControlItem;
                            layoutItem.TextVisible = false;
                            GridControls.ProduceGridControl(data, true, true).DataSource = data;
                        }

                    }
                }
                return layoutGroup;
            }
            catch
            {
                return null;
            }

        }
    }
}
