using System;
using System.Reflection;
using System.Windows.Forms;

namespace Common.BLL
{
    public class ReflectionHelper
    {
        /// <summary>
        /// 打开新的子窗体
        /// </summary>
        /// <param name="strName">窗体的类名</param>
        /// <param name="AssemblyName">窗体所在类库的名称</param>
        /// <param name="MdiParentForm">父窗体</param>
        public static Type CreateForm(string strName, string AssemblyName, Form MdiParentForm)
        {
            try
            {
                if (!ShowChildForm(strName, MdiParentForm))
                {
                    string path = AssemblyName;//项目的Assembly选项名称
                    string name = AssemblyName + "." + strName; //类的名字
                    //Form doc = (Form)Assembly.Load(path).CreateInstance(name);
                    Type FrmType = Assembly.Load(path).GetType(name);//获取反射对象方法集合
                    //object Frmobject = Activator.CreateInstance(FrmType);//封装反射对象

                    return FrmType;




                    //Form form = (Form)Frmobject;//将对象转换成窗体

                    ////doc.WindowState = FormWindowState.Maximized;
                    ////doc.MdiParent = MdiParentForm;
                    ////doc.Show();
                    //return form;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }




            //int Index = strName.LastIndexOf(".");
            //string FormName = strName.Substring(23);
            //if (!ShowChildForm(FormName, MdiParentForm))
            //{
            //    string path = AssemblyName;//项目的Assembly选项名称
            //    string name = strName; //类的名字
            //    Form doc = (Form)Assembly.Load(path).CreateInstance(name);
            //    doc.WindowState = FormWindowState.Maximized;
            //    doc.MdiParent = MdiParentForm;
            //    doc.Show();
            //}
        }

        /// <summary>
        /// 防止子窗体再度打开
        /// </summary>
        /// <param name="p_ChildrenFormText"></param>
        /// <param name="MdiParentForm"></param>
        /// <returns></returns>
        public static bool ShowChildForm(string p_ChildrenFormText, Form MdiParentForm)
        {
            int i;
            //依次检测当前窗体的子窗体
            for (i = 0; i < MdiParentForm.MdiChildren.Length; i++)
            {
                //判断当前子窗体的Text属性值是否与传入的字符串值相同
                if (MdiParentForm.MdiChildren[i].Name == p_ChildrenFormText)
                {
                    //如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    MdiParentForm.MdiChildren[i].Activate();
                    return true;
                }
            }
            //如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return false;
        }
    }
}
