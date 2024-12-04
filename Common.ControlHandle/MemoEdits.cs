using DevExpress.XtraEditors;
using System;

namespace Common.ControlHandle
{
    public class MemoEdits
    {
        public static void AddDoubleMethod(MemoEdit memoEdit)
        {
            memoEdit.DoubleClick += MemoEdit_DoubleClick;
        }
        public static void AddDoubleMethod(TextEdit textEdit)
        {
            textEdit.DoubleClick += textEdit_DoubleClick;
        }

        private static void MemoEdit_DoubleClick(object sender, EventArgs e)
        {
            MemoEdit memoEdit = sender as MemoEdit;
            try
            {
                if (memoEdit.Tag != null&& memoEdit.Tag.ToString()!=",")
                {
                    string[] a = memoEdit.Tag.ToString().Split(',');
                    if (a.Length == 2)
                    {
                        FrmShowDictionary frmShowDictionary = new FrmShowDictionary(a[0], a[1]);
                        Func<string> func = frmShowDictionary.ReturnResult;
                        frmShowDictionary.ShowDialog();

                        string rea = func();
                        if (rea != "")
                        {
                            memoEdit.EditValue = rea;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void textEdit_DoubleClick(object sender, EventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            try
            {
                if (textEdit.Tag != null && textEdit.Tag.ToString() != ",")
                {
                    string[] a = textEdit.Tag.ToString().Split(',');
                    if (a.Length == 2)
                    {
                        FrmShowDictionary frmShowDictionary = new FrmShowDictionary(a[0], a[1]);
                        Func<string> func = frmShowDictionary.ReturnResult;
                        frmShowDictionary.ShowDialog();

                        string rea = func();
                        if (rea != "")
                        {
                            textEdit.EditValue = rea;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
