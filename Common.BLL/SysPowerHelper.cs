using Common.Data;
using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using System.Linq;
using System.Windows.Forms;

namespace Common.BLL
{
    public class SysPowerHelper
    {
        /// <summary>
        /// BarManager权限管理方法
        /// </summary>
        public static void UserPower(BarManager barManager)
        {

            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager.Items)
            {

                if (CommonData.UserInfo.id != 1)
                {
                    //if (CommonData.powerList != null)
                    if (CommonData.powerList != null)
                    {
                        if (BT.Tag != null)
                        {
                            if (CommonData.powerList.Contains(BT.Tag.ToString()))
                            {
                                BT.Enabled = true;
                            }
                            else
                            {
                                BT.Enabled = false;
                            }
                        }
                        else
                        {
                            BT.Enabled = true;
                        }
                    }
                    else
                    {
                        BT.Enabled = false;
                    }
                }
                else
                {
                    BT.Enabled = true;
                }

            }

        }
        public static void UserPower(LayoutControl layoutControl)
        {

            foreach (var control in layoutControl.Items)
            {
                if (control is LayoutControlItem)
                {
                    LayoutControlItem tmp = control as LayoutControlItem;

                    if (CommonData.UserInfo.id != 1)
                    {
                        if (CommonData.powerList != null)
                        {
                            if (tmp.Tag != null)
                            {
                                if (CommonData.powerList.Contains(tmp.Tag.ToString()))
                                {
                                    tmp.Enabled = true;
                                }
                                else
                                {
                                    tmp.Enabled = false;
                                }
                            }
                            else
                            {
                                tmp.Enabled = true;
                            }
                        }
                        else
                        {
                            tmp.Enabled = false;
                        }
                    }
                    else
                    {
                        tmp.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// ToolStrip权限管理方法
        /// </summary>
        public static void UserPower(ToolStrip barManager)
        {

            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager.Items)
            {
                if (CommonData.UserInfo.id != 1)
                {
                    if (BT.Tag != null)
                    {
                        if (CommonData.powerList.Contains(BT.Tag.ToString()))
                        {
                            BT.Enabled = true;
                        }
                        else
                        {
                            BT.Enabled = false;
                        }
                    }
                    else
                    {
                        BT.Enabled = false;
                    }
                }
                else
                {
                    BT.Enabled = true;
                }

            }

        }
    }
}
