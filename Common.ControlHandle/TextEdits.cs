using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;

namespace Common.ControlHandle
{
    public class TextEdits
    {
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="textEdit"></param>
        public static void TextFormat(TextEdit textEdit)
        {
            textEdit.KeyPress += TextEdit_KeyPress;
        }
        /// <summary>
        /// 只能输入数字
        /// </summary>
        /// <param name="repositoryItemTextEdit"></param>
        public static void TextFormat(RepositoryItemTextEdit repositoryItemTextEdit)
        {
            repositoryItemTextEdit.KeyPress += TextEdit_KeyPress;
        }
        /// <summary>
        /// 允许输入数字和一个点
        /// </summary>
        /// <param name="repositoryItemTextEdit"></param>
        public static void TextFormats(RepositoryItemTextEdit repositoryItemTextEdit)
        {
            repositoryItemTextEdit.KeyPress += TextEdits_KeyPress;
        }
        /// <summary>
        /// 允许输入数字和点
        /// </summary>
        /// <param name="textEdit"></param>
        public static void TextFormatDecimal(TextEdit textEdit)
        {
            textEdit.KeyPress += TextEdit_KeyPresss;
        }
        public static void TextFormatDecimal(RepositoryItemTextEdit repositoryItemTextEdit)
        {
            repositoryItemTextEdit.KeyPress += TextEdit_KeyPresss;
        }
        /// <summary>
        /// 只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextEdit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }


        }
        /// <summary>
        /// 允许输入数字和点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TextEdits_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == ''))
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar == '.')
                    {
                        string str = textEdit.Text;
                        int num = str.IndexOf('.');
                        if (num != -1)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        private static void TextEdit_KeyPresss(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;//消除不合适字符
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar != '.' || ((TextEdit)sender).EditValue.ToString().Length == 0)//小数点
                {
                    e.Handled = true;
                }
                if (((TextEdit)sender).EditValue.ToString().LastIndexOf('.') != -1)
                {
                    e.Handled = true;
                }
            }
        }

    }
}
