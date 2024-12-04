using Aspose.Pdf;
using Common.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.MergePDF
{
    public class MergePDFHelper
    {
        /// <summary>
        /// 读取Aspose.PDF授权
        /// </summary>
        public static void License()
        {
            string license = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Aspose.Total.lic";

            Aspose.Pdf.License license2 = new Aspose.Pdf.License();
            license2.SetLicense(license);





            //Aspose.Words.License license3 = new Aspose.Words.License();
            //license3.SetLicense(license);
            //Aspose.Cells.License license4 = new Aspose.Cells.License();
            //license4.SetLicense(license);
            //Aspose.Slides.License license5 = new Aspose.Slides.License();
            //license5.SetLicense(license);
        }








        //    private static string Key =
        //"PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPkFzcG9zZSBTY290bGFuZCB" +
        //"UZWFtPC9MaWNlbnNlZFRvPg0KICAgIDxFbWFpbFRvPmJpbGx5Lmx1bmRpZUBhc3Bvc2UuY2" +
        //"9tPC9FbWFpbFRvPg0KICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlV" +
        //"HlwZT4NCiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1p" +
        //"dGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+DQogICAgPE9yZGVySUQ+MTQ" +
        //"wNDA4MDUyMzI0PC9PcmRlcklEPg0KICAgIDxVc2VySUQ+OTQyMzY8L1VzZXJJRD4NCiAgIC" +
        //"A8T0VNPlRoaXMgaXMgYSByZWRpc3RyaWJ1dGFibGUgbGljZW5zZTwvT0VNPg0KICAgIDxQc" +
        //"m9kdWN0cz4NCiAgICAgIDxQcm9kdWN0PkFzcG9zZS5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVj" +
        //"dD4NCiAgICA8L1Byb2R1Y3RzPg0KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl" +
        //"0aW9uVHlwZT4NCiAgICA8U2VyaWFsTnVtYmVyPjlhNTk1NDdjLTQxZjAtNDI4Yi1iYTcyLT" +
        //"djNDM2OGYxNTFkNzwvU2VyaWFsTnVtYmVyPg0KICAgIDxTdWJzY3JpcHRpb25FeHBpcnk+M" +
        //"jAxNTEyMzE8L1N1YnNjcmlwdGlvbkV4cGlyeT4NCiAgICA8TGljZW5zZVZlcnNpb24+My4w" +
        //"PC9MaWNlbnNlVmVyc2lvbj4NCiAgICA8TGljZW5zZUluc3RydWN0aW9ucz5odHRwOi8vd3d" +
        //"3LmFzcG9zZS5jb20vY29ycG9yYXRlL3B1cmNoYXNlL2xpY2Vuc2UtaW5zdHJ1Y3Rpb25zLm" +
        //"FzcHg8L0xpY2Vuc2VJbnN0cnVjdGlvbnM+DQogIDwvRGF0YT4NCiAgPFNpZ25hdHVyZT5GT" +
        //"zNQSHNibGdEdDhGNTlzTVQxbDFhbXlpOXFrMlY2RThkUWtJUDdMZFRKU3hEaWJORUZ1MXpP" +
        //"aW5RYnFGZkt2L3J1dHR2Y3hvUk9rYzF0VWUwRHRPNmNQMVpmNkowVmVtZ1NZOGkvTFpFQ1R" +
        //"Hc3pScUpWUVJaME1vVm5CaHVQQUprNWVsaTdmaFZjRjhoV2QzRTRYUTNMemZtSkN1YWoyTk" +
        //"V0ZVJpNUhyZmc9PC9TaWduYXR1cmU+DQo8L0xpY2Vuc2U+";



        #region Aspose.Pdf;
        /// <summary>
        /// 根据文件路径合并PDF
        /// </summary>
        /// <param name="FilePaths">文件地址集合</param>
        /// <param name="fileNO">文件随机编号</param>
        /// <returns></returns>
        public static string MergeAspose(List<string> FilePaths, out string filePath)
        {
            License();
            filePath = CommonData.StartPath+ "\\TempReport";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = filePath +"\\Temp-"+ Guid.NewGuid().ToString("N")+".pdf";

            string newFilePath = filePath;
            if (File.Exists(newFilePath))
                File.Delete(newFilePath);


            //new Aspose.Pdf.License().SetLicense(new MemoryStream(Convert.FromBase64String(Key)));




            Document pdfdoc = new Document();



            foreach (var item in FilePaths)
            {

                Document pdf = new Document(item);
                pdfdoc.Pages.Add(pdf.Pages);
                File.Delete(item);

            }
            pdfdoc.Save(newFilePath);
            return newFilePath;
        }
        #endregion



        //#region Spire.Pdf;
        ///// <summary>
        ///// 根据文件路径合并PDF
        ///// </summary>
        ///// <param name="FilePaths">文件地址集合</param>
        ///// <param name="fileNO">文件随机编号</param>
        ///// <returns></returns>
        //public static string MergeSpire(List<string> FilePaths, int fileNO)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(CommonData.ReportFilePath))
        //        {

        //            Directory.CreateDirectory(CommonData.ReportFilePath);
        //        }
        //        string newFilePath = CommonData.ReportFilePath + $"\\TempReport-{fileNO}.pdf";
        //        if (File.Exists(newFilePath))
        //            File.Delete(newFilePath);



        //        //String[] files = new String[] { "文件1.pdf", "文件2.pdf", "文件3.pdf" };
        //        string outputFile = newFilePath;
        //        PdfDocumentBase doc = Spire.Pdf.PdfDocument.MergeFiles(FilePaths.ToArray());
        //        doc.Save(outputFile, FileFormat.PDF);
        //        doc.Pages.RemoveAt(0);
        //        //PdfDocument pdfDocument = new PdfDocument();
        //        //pdfDocument.Pages.Add();
        //        //pdfDocument.Pages.RemoveAt(0);
        //        //System.Diagnostics.Process.Start(outputFile);

        //        return newFilePath;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return "";
        //    }

        //}
        //#endregion



        //#region iTextSharp;
        ///// <summary>
        ///// 根据文件路径合并PDF iTextSharp
        ///// </summary>
        ///// <param name = "FilePaths" > 文件地址集合 </ param >
        ///// < param name="fileNO">文件随机编号</param>
        ///// <returns></returns>
        //public static string MergeiTextSharp(List<string> FilePaths, int fileNO)
        //{
        //    if (!Directory.Exists(CommonData.ReportFilePath))
        //    {

        //        Directory.CreateDirectory(CommonData.ReportFilePath);
        //    }
        //    string newFilePath = CommonData.ReportFilePath + $"\\TempReport-{fileNO}.pdf";
        //    if (File.Exists(newFilePath))
        //        File.Delete(newFilePath);





        //    //string zipFilePath = CommonData.ReportFilePath + $"\\TempReport-{fileNO}.rar";
        //    //string newFilePath = CommonData.ReportFilePath + $"\\TempReport.pdf";
        //    //string zipFilePath = CommonData.ReportFilePath + $"\\TempReport.rar";

        //    //if (File.Exists(zipFilePath))
        //    //{
        //    //    File.Delete(zipFilePath);
        //    //}
        //    FileStream fileStream = new FileStream(newFilePath, FileMode.Create);

        //    //string[] fileList = { originalFilePath, mergeFilePath };
        //    List<PdfReader> readerList = new List<PdfReader>();
        //    PdfReader reader = null;
        //    //iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(1660, 1000);
        //    //iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(1660, 1000);
        //    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);




        //    PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
        //    //PdfWriter writer = PdfWriter.GetInstance(document, fileStream);


        //    //PdfContentByte contentPlacer;
        //    //writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);

        //    writer.CompressionLevel = PdfStream.BEST_SPEED;




        //    document.Open();
        //    PdfContentByte cb = writer.DirectContent;
        //    PdfImportedPage newPage;
        //    foreach (var item in FilePaths)
        //    {
        //        reader = new PdfReader(item);
        //        int iPageNum = reader.NumberOfPages;
        //        for (int j = 1; j <= iPageNum; j++)
        //        {
        //            document.NewPage();
        //            newPage = writer.GetImportedPage(reader, j);

        //            //newPage.

        //            //cb.AddTemplate(newPage, 0, 0);
        //            cb.AddTemplate(newPage, 0, document.PageSize.Height - reader.GetPageSize(j).Height);
        //            //cb.AddTemplate(newPage, 0, document.PageSize.Height-reader.GetPageSize(j).Height,);
        //        }
        //        //readerList.Add(reader);
        //        reader.Close();
        //    }
        //    document.Close();
        //    //foreach (var item in readerList)
        //    //{
        //    //    item.Dispose();
        //    //}
        //    fileStream.Dispose();
        //    fileStream.Close();



        //    return newFilePath;


        //    //string rarPath = Path.GetDirectoryName(zipFilePath);
        //    //if (!Directory.Exists(rarPath))
        //    //    Directory.CreateDirectory(rarPath);
        //    //Process Process1 = new Process();
        //    //Process1.StartInfo.FileName = CommonData.RarApplictionPath;
        //    //Process1.StartInfo.CreateNoWindow = true;
        //    //string cmd = "";
        //    ////if (!string.IsNullOrEmpty(PassWord) && IsCover)
        //    ////    //压缩加密文件且覆盖已存在压缩文件( -p密码 -o+覆盖 )
        //    ////    cmd = string.Format(" a -ep1 -p{0} -o+ {1} {2} -r", PassWord, rarPathName, filesPath);
        //    ////else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
        //    ////    //压缩加密文件且不覆盖已存在压缩文件( -p密码 -o-不覆盖 )
        //    ////    cmd = string.Format(" a -ep1 -p{0} -o- {1} {2} -r", PassWord, rarPathName, filesPath);
        //    ////else if (string.IsNullOrEmpty(PassWord) && IsCover)
        //    ////    //压缩且覆盖已存在压缩文件( -o+覆盖 )
        //    ////    cmd = string.Format(" a -ep1 -o+ {0} {1} -r", rarPathName, filesPath);
        //    ////else
        //    ////    //压缩且不覆盖已存在压缩文件( -o-不覆盖 )
        //    ////cmd = string.Format(" a -ep1 -dw -o+ {0} {1} -r -y -ibck", zipFilePath, newFilePath);
        //    //cmd = string.Format(" a -ep1 -o+ {0} {1} -r -y -ibck", zipFilePath, newFilePath);
        //    ////命令
        //    //Process1.StartInfo.Arguments = cmd;




        //    //Process1.Start();
        //    //Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
        //    //                       //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行


        //    //if (File.Exists(newFilePath))
        //    //{
        //    //    File.Delete(newFilePath);
        //    //}


        //    //if (Process1.ExitCode == 0)
        //    //{
        //    //    Process1.Close();
        //    //    return zipFilePath;
        //    //}
        //    //else
        //    //{
        //    //    Process1.Close();
        //    //    return "";
        //    //}

        //}
        //#endregion


        //#region iTextSharp.LGPLv2.Core

        /////// </summary>
        /////// <param name="directory">存放多个pdf的文件夹路径</param>
        /////// <param name="pdfpath">合并的pdf路径</param>
        ////public static string MergeLGPLv2(List<string> FilePaths, int fileNO)
        ////{

        ////    if (!Directory.Exists(CommonData.ReportFilePath))
        ////    {

        ////        Directory.CreateDirectory(CommonData.ReportFilePath);
        ////    }
        ////    string newFilePath = CommonData.ReportFilePath + $"\\TempReport-{fileNO}.pdf";
        ////    if (File.Exists(newFilePath))
        ////        File.Delete(newFilePath);





        ////    iTextSharp.text.Document document = null;
        ////    try
        ////    {
        ////        PdfReader reader;
        ////        if (FilePaths.Count > 0)
        ////        {
        ////            //此处将内容从文本提取至文件流中的目的是避免文件被占用,无法删除
        ////            FileStream fs1 = new FileStream(FilePaths[0], FileMode.Open);
        ////            byte[] bytes1 = new byte[(int)fs1.Length];
        ////            fs1.Read(bytes1, 0, bytes1.Length);
        ////            fs1.Close();
        ////            reader = new PdfReader(bytes1);
        ////            reader.GetPageSize(1);
        ////            iTextSharp.text.Rectangle rec = reader.GetPageSize(1);
        ////            document = new iTextSharp.text.Document(rec, 50, 50, 50, 50);
        ////            FileStream f = new FileStream(newFilePath, FileMode.OpenOrCreate);
        ////            PdfReader.AllowOpenWithFullPermissions = true;
        ////            PdfWriter writer = PdfWriter.GetInstance(document, f);
        ////            document.Open();
        ////            PdfContentByte cb = writer.DirectContent;
        ////            PdfImportedPage newPage;
        ////            for (int i = 0; i < FilePaths.Count; i++)
        ////            {
        ////                FileStream fs = new FileStream(FilePaths[i], FileMode.Open);
        ////                byte[] bytes = new byte[(int)fs.Length];
        ////                fs.Read(bytes, 0, bytes.Length);
        ////                fs.Close();
        ////                reader = new PdfReader(bytes);
        ////                int iPageNum = reader.NumberOfPages;
        ////                for (int j = 1; j <= iPageNum; j++)
        ////                {
        ////                    document.NewPage();
        ////                    newPage = writer.GetImportedPage(reader, j);
        ////                    cb.AddTemplate(newPage, 0, 0);

        ////                }
        ////                // File.Delete(fileList[i]);
        ////            }
        ////            document.Close();
        ////        }
        ////        else
        ////        {
        ////            newFilePath = "";
        ////        }

        ////    }
        ////    catch (Exception e)
        ////    {
        ////        newFilePath = "";
        ////    }
        ////    finally
        ////    {
        ////        newFilePath = "";
        ////        if (document != null)
        ////            document.Close();
        ////    }
        ////    return newFilePath;

        ////}






        //#endregion

    }
}
