using Common.ControlHandle;
using Common.Data;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace QC.QCHelpers
{
    public class QCItemResultImg
    {
        //质控结果指控图
        public static ChartControl createQCResultImg(string itemName, object startTime, object endTime, DataTable QCResultInfoDT, out XRChart xRChart)
        {

            xRChart = createXRQCResultImg(itemName, startTime, endTime, QCResultInfoDT);

            ChartControl chart = new ChartControl();
            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "项目名称: " + itemName;
            //chartTitle.Text = "项目名称:"+itemName+$"({startTime}-{endTime})";
            chartTitle.TextColor = Color.Black;
            chartTitle.Font = new Font("Tahoma", 20, FontStyle.Bold);
            //chartTitle.Alignment = StringAlignment.Near;
            chart.Titles.Add(chartTitle);

            ////横标题设置
            ChartTitle titles = new ChartTitle();            //声明标题
            titles.Text = $"{startTime}-{endTime}";                       //名称
            titles.TextColor = System.Drawing.Color.Black;   //颜色
            titles.Indent = 5;                                //设置距离  值越小柱状图就越大
            titles.Font = new Font("Tahoma", 10, FontStyle.Bold);            //设置字体
            titles.Dock = ChartTitleDockStyle.Top;           //设置对齐方式
            titles.Alignment = StringAlignment.Far;       //居中对齐
            //titles.Dock = ChartTitleDockStyle.Right;
            chart.Titles.Add(titles);                 //添加标题       



            SetCrosshair(chart, true);


            //高水平
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            lineSeriesView1.LineMarkerOptions.Size = 8;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;//显示点记号
            lineSeriesView1.LineMarkerOptions.Kind = MarkerKind.Triangle;//MarkerKind.Diamond;//记号性状
            lineSeriesView1.Color = Color.FromArgb(-12566464);// Color.Black;//线颜色-12566464
            //中水平
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            lineSeriesView2.LineMarkerOptions.Size = 8;
            lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            lineSeriesView2.LineMarkerOptions.Kind = MarkerKind.Square;//记号性状
            lineSeriesView2.Color = Color.FromArgb(-7667712);
            //低水平
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            lineSeriesView3.LineMarkerOptions.Size = 8;
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            lineSeriesView3.LineMarkerOptions.Kind = MarkerKind.InvertedTriangle;//记号性状
            lineSeriesView3.Color = Color.FromArgb(-13726889);


            List<Series> listSeries = new List<Series>();



            //series1.CrosshairLabelPattern = "{S}{V}" + $"\r\n{"其他"}";//设置悬浮文本

            //Series series1a = new Series("高质水平", ViewType.Line);

            if (QCResultInfoDT.Select($"planGradelevelNO='3'").Count() > 0)
            {
                DataRow[] dataRowInfos = QCResultInfoDT.Select($"planGradelevelNO='3'", "planGradeid");
                List<string> gradeids = new List<string>();

                foreach (DataRow dataRow in dataRowInfos)
                {
                    string gradeid = dataRow["planGradeid"].ToString();
                    if (!gradeids.Contains(gradeid))
                    {
                        DataRow[] dataRows = QCResultInfoDT.Select($"planGradeid='{gradeid}'");
                        string planGraderemark = dataRow["planGraderemark"] != DBNull.Value && dataRow["planGraderemark"].ToString() != "" ? $"({dataRow["planGraderemark"].ToString()})" : "";
                        Series series1 = new Series("高质水平" + planGraderemark, ViewType.Line);
                        series1.View = lineSeriesView1;
                        for (int i = 0; i < dataRows.Length; i++)
                        {
                            double value = Convert.ToDouble(dataRows[i]["zVlaue"]);//参数值  
                            SeriesPoint point = new SeriesPoint(dataRows[i]["qcTime"], value);
                            string resultType = dataRows[i]["resultType"] != DBNull.Value ? dataRows[i]["resultType"].ToString() : "";
                            if (resultType == "警告")
                            {
                                point.Color = Color.Yellow;
                            }
                            if (resultType == "失控")
                            {
                                point.Color = Color.Red;
                            }
                            point.Tag = "质控编号:" + dataRows[i]["planGradeCode"] + "\r\nZ  分数值:" + dataRows[i]["zVlaue"] + "\r\n质控结果:" + dataRows[i]["itemResult"] + "\r\n质控状态:" + resultType + "\r\n违反规则:" + dataRows[i]["resultRule"] + "\r\n质控备注:" + dataRows[i]["itemResultRemark"];
                            series1.Points.Add(point);
                            //series1.Tag = i + "aa";
                        }
                        ////必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示 
                        ////也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative 
                        ////series1.ArgumentScaleType = ScaleType.Qualitative;
                        ////series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;//显示标注标签 
                        series1.ArgumentScaleType = ScaleType.DateTime;
                        listSeries.Add(series1);
                        gradeids.Add(gradeid);
                    }

                }





            }



            if (QCResultInfoDT.Select($"planGradelevelNO='2'").Count() > 0)
            {
                DataRow[] dataRowInfos = QCResultInfoDT.Select($"planGradelevelNO='2'", "planGradeid");
                List<string> gradeids = new List<string>();

                foreach (DataRow dataRow in dataRowInfos)
                {
                    string gradeid = dataRow["planGradeid"].ToString();
                    if (!gradeids.Contains(gradeid))
                    {
                        DataRow[] dataRows = QCResultInfoDT.Select($"planGradeid='{gradeid}'");
                        string planGraderemark = dataRow["planGraderemark"] != DBNull.Value && dataRow["planGraderemark"].ToString() != "" ? $"({dataRow["planGraderemark"].ToString()})" : "";
                        Series series2 = new Series("中质水平" + planGraderemark, ViewType.Line);
                        series2.View = lineSeriesView2;
                        for (int i = 0; i < dataRows.Length; i++)
                        {
                            double value = Convert.ToDouble(dataRows[i]["zVlaue"]);//参数值  
                            SeriesPoint point = new SeriesPoint(dataRows[i]["qcTime"], value);
                            string resultType = dataRows[i]["resultType"] != DBNull.Value ? dataRows[i]["resultType"].ToString() : "";
                            if (resultType == "警告")
                            {
                                point.Color = Color.Yellow;
                            }
                            if (resultType == "失控")
                            {
                                point.Color = Color.Red; 
                            }
                            point.Tag = "质控编号:" + dataRows[i]["planGradeCode"] + "\r\nZ  分数值:" + dataRows[i]["zVlaue"] + "\r\n质控结果:" + dataRows[i]["itemResult"] + "\r\n质控状态:" + resultType + "\r\n违反规则:" + dataRows[i]["resultRule"] + "\r\n质控备注:" + dataRows[i]["itemResultRemark"];
                            series2.Points.Add(point);
                            //series1.Tag = i + "aa";
                        }
                        ////必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示 
                        ////也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative 
                        ////series1.ArgumentScaleType = ScaleType.Qualitative;
                        ////series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;//显示标注标签 
                        series2.ArgumentScaleType = ScaleType.DateTime;
                        listSeries.Add(series2);
                        gradeids.Add(gradeid);
                    }

                }





            }

            if (QCResultInfoDT.Select($"planGradelevelNO='1'").Count() > 0)
            {
                DataRow[] dataRowInfos = QCResultInfoDT.Select($"planGradelevelNO='1'", "planGradeid");
                List<string> gradeids = new List<string>();

                foreach(DataRow dataRow in dataRowInfos)
                {
                    string gradeid = dataRow["planGradeid"].ToString();
                    if (!gradeids.Contains(gradeid))
                    {
                        DataRow[] dataRows = QCResultInfoDT.Select($"planGradeid='{gradeid}'");
                        string planGraderemark = dataRow["planGraderemark"] != DBNull.Value && dataRow["planGraderemark"].ToString() != "" ? $"({dataRow["planGraderemark"].ToString()})" : "";
                        Series series3 = new Series("低质水平"+ planGraderemark, ViewType.Line);
                        series3.View = lineSeriesView3;
                        for (int i = 0; i < dataRows.Length; i++)
                        {
                            double value = Convert.ToDouble(dataRows[i]["zVlaue"]);//参数值  
                            SeriesPoint point = new SeriesPoint(dataRows[i]["qcTime"], value);
                            string resultType = dataRows[i]["resultType"] != DBNull.Value ? dataRows[i]["resultType"].ToString() : "";
                            if (resultType == "警告")
                            {
                                point.Color = Color.Yellow;
                            }
                            if (resultType == "失控")
                            {
                                point.Color = Color.Red;
                            }
                            point.Tag = "质控编号:" + dataRows[i]["planGradeCode"] + "\r\nZ  分数值:" + dataRows[i]["zVlaue"] + "\r\n质控结果:" + dataRows[i]["itemResult"] + "\r\n质控状态:" + resultType + "\r\n违反规则:" + dataRows[i]["resultRule"] + "\r\n质控备注:" + dataRows[i]["itemResultRemark"];
                            series3.Points.Add(point);
                            //series1.Tag = i + "aa";
                        }
                        ////必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示 
                        ////也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative 
                        ////series1.ArgumentScaleType = ScaleType.Qualitative;
                        ////series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;//显示标注标签 
                        series3.ArgumentScaleType = ScaleType.DateTime;
                        listSeries.Add(series3);
                        gradeids.Add(gradeid);
                    }

                }





            }



            //List<Series> listSeries = new List<Series>() { series1, series2, series3 };
            chart.Series.AddRange(listSeries.ToArray());

            chart.Location = new System.Drawing.Point(0, 0);
            ////chart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;//legend 位置
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;//legend 位置


            //chart.ObjectSelected += Chart_ObjectSelected;






            XYDiagram xyDiagram = (XYDiagram)chart.Diagram;
            xyDiagram.Margins.All = 10;
            xyDiagram.Margins.Left = 50;
            //xyDiagram.AxisX.DateTimeOptions.Format = DateTimeFormat.MonthAndDay;//格式化文字
            xyDiagram.AxisX.Label.TextPattern = "{A:MM-dd}";
            //xyDiagram.AxisX.QualitativeScaleOptions.AutoGrid = false;//x轴字自动网格
            //xyDiagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;//x轴字运行隐藏
            xyDiagram.AxisX.Label.Staggered = false;////x轴字允许交错
            xyDiagram.AxisX.Label.Angle = 1;//x轴字体旋转角度


            xyDiagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;//X轴刻度单位
            xyDiagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;//X轴刻度间距
            //xyDiagram.AxisX.Label.Alignment = AxisLabelAlignment.Near;




            //xyDiagram.AxisX.Label.Angle = Angle;


            //xyDiagram.AxisY.Label.TextPattern = "{A:MM-dd}";

            //xyDiagram.AxisY.Interlaced = true;//各行变色
            xyDiagram.AxisY.InterlacedColor = Color.FromArgb(-657931);//各行背景色

            xyDiagram.AxisX.Interlaced = true;//各行变色
            xyDiagram.AxisX.InterlacedColor = Color.FromArgb(-657931);//各行背景色



            #region  y轴辅助线

            CustomAxisLabel customAxisLabel1 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel2 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel3 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel4 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel5 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel6 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel7 = new CustomAxisLabel();

            customAxisLabel1.AxisValueSerializable = "3";
            customAxisLabel1.Name = "   3s";
            ConstantLine constantLine1 = new ConstantLine();
            constantLine1.AxisValueSerializable = "3";
            constantLine1.CheckableInLegend = false;
            constantLine1.CheckedInLegend = false;
            constantLine1.LegendName = "Default Legend";
            constantLine1.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine1.Name = "Constant Line 1";
            constantLine1.ShowInLegend = false;
            constantLine1.Title.Visible = false;
            constantLine1.Color = System.Drawing.Color.OrangeRed;
            constantLine1.LineStyle.Thickness = 2;

            customAxisLabel2.AxisValueSerializable = "2";
            customAxisLabel2.Name = "   2S";
            ConstantLine constantLine2 = new ConstantLine();
            constantLine2.AxisValueSerializable = "2";
            constantLine2.CheckableInLegend = false;
            constantLine2.CheckedInLegend = false;
            constantLine2.LegendName = "Default Legend";
            constantLine2.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine2.Name = "Constant Line 1";
            constantLine2.ShowInLegend = false;
            constantLine2.Title.Visible = false;
            constantLine2.Color = System.Drawing.Color.BlueViolet;
            constantLine2.LineStyle.Thickness = 2;

            customAxisLabel3.AxisValueSerializable = "1";
            customAxisLabel3.Name = "   1s";
            ConstantLine constantLine3 = new ConstantLine();
            constantLine3.AxisValueSerializable = "1";
            constantLine3.CheckableInLegend = false;
            constantLine3.CheckedInLegend = false;
            constantLine3.LegendName = "Default Legend";
            constantLine3.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine3.Name = "Constant Line 1";
            constantLine3.ShowInLegend = false;
            constantLine3.Title.Visible = false;
            constantLine3.Color = System.Drawing.Color.Green;
            constantLine3.LineStyle.Thickness = 2;

            customAxisLabel4.AxisValueSerializable = "0";
            customAxisLabel4.Name = "   x";
            ConstantLine constantLine4 = new ConstantLine();
            constantLine4.AxisValueSerializable = "0";
            constantLine4.CheckableInLegend = false;
            constantLine4.CheckedInLegend = false;
            constantLine4.LegendName = "Default Legend";
            //constantLine4.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine4.Name = "Constant Line 1";
            constantLine4.ShowInLegend = false;
            constantLine4.Title.Visible = false;
            constantLine4.Color = System.Drawing.Color.Black;
            constantLine4.LineStyle.Thickness = 2;

            customAxisLabel5.AxisValueSerializable = "-1";
            customAxisLabel5.Name = "   -1s";
            ConstantLine constantLine5 = new ConstantLine();
            constantLine5.AxisValueSerializable = "-1";
            constantLine5.CheckableInLegend = false;
            constantLine5.CheckedInLegend = false;
            constantLine5.LegendName = "Default Legend";
            constantLine5.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine5.Name = "Constant Line 1";
            constantLine5.ShowInLegend = false;
            constantLine5.Title.Visible = false;
            constantLine5.Color = System.Drawing.Color.Green;
            constantLine5.LineStyle.Thickness = 2;

            customAxisLabel6.AxisValueSerializable = "-2";
            customAxisLabel6.Name = "   -2s";
            ConstantLine constantLine6 = new ConstantLine();
            constantLine6.AxisValueSerializable = "-2";
            constantLine6.CheckableInLegend = false;
            constantLine6.CheckedInLegend = false;
            constantLine6.LegendName = "Default Legend";
            constantLine6.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine6.Name = "Constant Line 1";
            constantLine6.ShowInLegend = false;
            constantLine6.Title.Visible = false;
            constantLine6.Color = System.Drawing.Color.BlueViolet;
            constantLine6.LineStyle.Thickness = 2;

            customAxisLabel7.AxisValueSerializable = "-3";
            customAxisLabel7.Name = "   -3s";
            ConstantLine constantLine7 = new ConstantLine();
            constantLine7.AxisValueSerializable = "-3";
            constantLine7.CheckableInLegend = false;
            constantLine7.CheckedInLegend = false;
            constantLine7.LegendName = "Default Legend";
            constantLine7.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine7.Name = "Constant Line 1";
            constantLine7.ShowInLegend = false;
            constantLine7.Title.Visible = false;
            constantLine7.Color = System.Drawing.Color.OrangeRed;
            constantLine7.LineStyle.Thickness = 2;



            xyDiagram.AxisY.CustomLabels.AddRange(new DevExpress.XtraCharts.CustomAxisLabel[] {
            customAxisLabel1,
            customAxisLabel2,
            customAxisLabel3,
            customAxisLabel4,
            customAxisLabel5,
            customAxisLabel6,
            customAxisLabel7});
            xyDiagram.AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine1,
            constantLine2,
            constantLine3,
            constantLine4,
            constantLine5,
            constantLine6,
            constantLine7});


            #endregion


            //panel1.Controls.Add(chart);
            //chart.Dock = DockStyle.Fill;


            chart.CustomDrawCrosshair += Chart_CustomDrawCrosshair;


            return chart;
        }


        //质控报告质控图
        public static XRChart createXRQCResultImg(string itemName, object startTime, object endTime, DataTable QCResultInfoDT)
        {



            XRChart chart = new XRChart();
            //ChartTitle chartTitle = new ChartTitle();
            //chartTitle.Text = "项目名称: " + itemName;
            ////chartTitle.Text = "项目名称:"+itemName+$"({startTime}-{endTime})";
            //chartTitle.TextColor = Color.Black;
            //chartTitle.Font = new Font("Tahoma", 20, FontStyle.Bold);
            ////chartTitle.Alignment = StringAlignment.Near;
            //chart.Titles.Add(chartTitle);

            //////横标题设置
            //ChartTitle titles = new ChartTitle();            //声明标题
            //titles.Text = $"{startTime}-{endTime}";                       //名称
            //titles.TextColor = System.Drawing.Color.Black;   //颜色
            //titles.Indent = 5;                                //设置距离  值越小柱状图就越大
            //titles.Font = new Font("Tahoma", 10, FontStyle.Bold);            //设置字体
            //titles.Dock = ChartTitleDockStyle.Top;           //设置对齐方式
            //titles.Alignment = StringAlignment.Far;       //居中对齐
            ////titles.Dock = ChartTitleDockStyle.Right;
            //chart.Titles.Add(titles);                 //添加标题       



            //SetCrosshair(chart, true);


            //高水平
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            lineSeriesView1.LineMarkerOptions.Size = 8;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;//显示点记号
            lineSeriesView1.LineMarkerOptions.Kind = MarkerKind.Triangle;//MarkerKind.Diamond;//记号性状
            lineSeriesView1.Color = Color.FromArgb(-12566464);// Color.Black;//线颜色-12566464
            //lineSeriesView1.f = Color.FromArgb(-12566464);// Color.Black;//线颜色-12566464

            //中水平
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            lineSeriesView2.LineMarkerOptions.Size = 8;
            lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            lineSeriesView2.LineMarkerOptions.Kind = MarkerKind.Square;//记号性状
            lineSeriesView2.Color = Color.FromArgb(-7667712);
            //低水平
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            lineSeriesView3.LineMarkerOptions.Size = 8;
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            lineSeriesView3.LineMarkerOptions.Kind = MarkerKind.InvertedTriangle;//记号性状
            lineSeriesView3.Color = Color.FromArgb(-13726889);





            Series series1 = new Series("高质水平", ViewType.Line);
            series1.View = lineSeriesView1;
            //series1.CrosshairLabelPattern = "{S}{V}" + $"\r\n{"其他"}";//设置悬浮文本

            //Series series1a = new Series("高质水平", ViewType.Line);
            if (QCResultInfoDT.Select($"planGradelevelNO='3'").Count() > 0)
            {
                DataTable dataTable = QCResultInfoDT.Select($"planGradelevelNO='3'").CopyToDataTable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    double value = Convert.ToDouble(dataTable.Rows[i]["zVlaue"]);//参数值  
                    SeriesPoint point = new SeriesPoint(dataTable.Rows[i]["qcTime"], value);

                    string resultType = dataTable.Rows[i]["resultType"] != DBNull.Value ? dataTable.Rows[i]["resultType"].ToString() : "";
                    if (resultType == "警告")
                    {
                        point.Color = Color.Yellow;
                    }
                    if (resultType == "失控")
                    {
                        point.Color = Color.Red;
                    }
                    point.Tag = "Z  分数值:" + dataTable.Rows[i]["zVlaue"] + "\r\n质控结果:" + dataTable.Rows[i]["itemResult"] + "\r\n质控状态:" + dataTable.Rows[i]["resultType"] + "\r\n违反规则:" + dataTable.Rows[i]["resultRule"] + "\r\n质控备注:" + dataTable.Rows[i]["itemResultRemark"];
                    series1.Points.Add(point);
                    //series1.Tag = i + "aa";
                }
                //必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示 
                //也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative 
                //series1.ArgumentScaleType = ScaleType.Qualitative;
                series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;//显示标注标签 
                series1.ArgumentScaleType = ScaleType.DateTime;
            }
            Series series2 = new Series("中质水平", ViewType.Line);

            series2.View = lineSeriesView2;
            if (QCResultInfoDT.Select($"planGradelevelNO='2'").Count() > 0)
            {
                DataTable dataTable = QCResultInfoDT.Select($"planGradelevelNO='2'").CopyToDataTable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    double value = Convert.ToDouble(dataTable.Rows[i]["zVlaue"]);//参数值  
                    SeriesPoint point = new SeriesPoint(dataTable.Rows[i]["qcTime"], value);
                    string resultType = dataTable.Rows[i]["resultType"] != DBNull.Value ? dataTable.Rows[i]["resultType"].ToString() : "";
                    if (resultType == "警告")
                    {
                        point.Color = Color.Yellow;
                    }
                    if (resultType == "失控")
                    {
                        point.Color = Color.Red;
                    }
                    point.Tag = "Z  分数值:" + dataTable.Rows[i]["zVlaue"] + "\r\n质控结果:" + dataTable.Rows[i]["itemResult"] + "\r\n质控状态:" + dataTable.Rows[i]["resultType"] + "\r\n违反规则:" + dataTable.Rows[i]["resultRule"] + "\r\n质控备注:" + dataTable.Rows[i]["itemResultRemark"];
                    series2.Points.Add(point);
                    //series1.Tag = i + "aa";
                }
                //必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示 
                //也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative 
                //series1.ArgumentScaleType = ScaleType.Qualitative;
                series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;//显示标注标签 
                series2.ArgumentScaleType = ScaleType.DateTime;
            }
            Series series3 = new Series("低质水平", ViewType.Line);
            series3.View = lineSeriesView3;
            if (QCResultInfoDT.Select($"planGradelevelNO='1'").Count() > 0)
            {
                DataTable dataTable = QCResultInfoDT.Select($"planGradelevelNO='1'").CopyToDataTable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    double value = Convert.ToDouble(dataTable.Rows[i]["zVlaue"]);//参数值  
                    SeriesPoint point = new SeriesPoint(dataTable.Rows[i]["qcTime"], value);
                    string resultType = dataTable.Rows[i]["resultType"] != DBNull.Value ? dataTable.Rows[i]["resultType"].ToString() : "";
                    if (resultType == "警告")
                    {
                        point.Color = Color.Yellow;
                    }
                    if (resultType == "失控")
                    {
                        point.Color = Color.Red;
                    }
                    point.Tag = "Z  分数值:" + dataTable.Rows[i]["zVlaue"] + "\r\n质控结果:" + dataTable.Rows[i]["itemResult"] + "\r\n质控状态:" + resultType + "\r\n违反规则:" + dataTable.Rows[i]["resultRule"] + "\r\n质控备注:" + dataTable.Rows[i]["itemResultRemark"];
                    series3.Points.Add(point);
                    //series1.Tag = i + "aa";
                }
                //必须设置ArgumentScaleType的类型，否则显示会转换为日期格式，导致不是希望的格式显示 
                //也就是说，显示字符串的参数，必须设置类型为ScaleType.Qualitative 
                //series1.ArgumentScaleType = ScaleType.Qualitative;
                series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;//显示标注标签 
                series3.ArgumentScaleType = ScaleType.DateTime;
            }



            List<Series> list = new List<Series>() { series1, series2, series3 };
            chart.Series.AddRange(list.ToArray());

            chart.Location = new System.Drawing.Point(0, 0);
            //chart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.TopToBottom;
            chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;//legend 位置
            chart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;//legend 位置


            //chart.ObjectSelected += Chart_ObjectSelected;






            XYDiagram xyDiagram = (XYDiagram)chart.Diagram;
            xyDiagram.Margins.All = 10;
            xyDiagram.Margins.Left = 50;
            //xyDiagram.AxisX.DateTimeOptions.Format = DateTimeFormat.MonthAndDay;//格式化文字
            xyDiagram.AxisX.Label.TextPattern = "{A:MM-dd}";
            //xyDiagram.AxisX.QualitativeScaleOptions.AutoGrid = false;//x轴字自动网格
            //xyDiagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;//x轴字运行隐藏
            xyDiagram.AxisX.Label.Staggered = false;////x轴字允许交错
            xyDiagram.AxisX.Label.Angle = 1;//x轴字体旋转角度


            xyDiagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;//X轴刻度单位
            xyDiagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;//X轴刻度间距
            //xyDiagram.AxisX.Label.Alignment = AxisLabelAlignment.Near;




            //xyDiagram.AxisX.Label.Angle = Angle;


            //xyDiagram.AxisY.Label.TextPattern = "{A:MM-dd}";

            //xyDiagram.AxisY.Interlaced = true;//各行变色
            xyDiagram.AxisY.InterlacedColor = Color.FromArgb(-657931);//各行背景色

            xyDiagram.AxisX.Interlaced = true;//各行变色
            xyDiagram.AxisX.InterlacedColor = Color.FromArgb(-657931);//各行背景色



            #region  y轴辅助线

            CustomAxisLabel customAxisLabel1 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel2 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel3 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel4 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel5 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel6 = new CustomAxisLabel();
            CustomAxisLabel customAxisLabel7 = new CustomAxisLabel();

            customAxisLabel1.AxisValueSerializable = "3";
            customAxisLabel1.Name = "   3s";
            ConstantLine constantLine1 = new ConstantLine();
            constantLine1.AxisValueSerializable = "3";
            constantLine1.CheckableInLegend = false;
            constantLine1.CheckedInLegend = false;
            constantLine1.LegendName = "Default Legend";
            constantLine1.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine1.Name = "Constant Line 1";
            constantLine1.ShowInLegend = false;
            constantLine1.Title.Visible = false;
            constantLine1.Color = System.Drawing.Color.OrangeRed;
            constantLine1.LineStyle.Thickness = 2;

            customAxisLabel2.AxisValueSerializable = "2";
            customAxisLabel2.Name = "   2S";
            ConstantLine constantLine2 = new ConstantLine();
            constantLine2.AxisValueSerializable = "2";
            constantLine2.CheckableInLegend = false;
            constantLine2.CheckedInLegend = false;
            constantLine2.LegendName = "Default Legend";
            constantLine2.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine2.Name = "Constant Line 1";
            constantLine2.ShowInLegend = false;
            constantLine2.Title.Visible = false;
            constantLine2.Color = System.Drawing.Color.BlueViolet;
            constantLine2.LineStyle.Thickness = 2;

            customAxisLabel3.AxisValueSerializable = "1";
            customAxisLabel3.Name = "   1s";
            ConstantLine constantLine3 = new ConstantLine();
            constantLine3.AxisValueSerializable = "1";
            constantLine3.CheckableInLegend = false;
            constantLine3.CheckedInLegend = false;
            constantLine3.LegendName = "Default Legend";
            constantLine3.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine3.Name = "Constant Line 1";
            constantLine3.ShowInLegend = false;
            constantLine3.Title.Visible = false;
            constantLine3.Color = System.Drawing.Color.Green;
            constantLine3.LineStyle.Thickness = 2;

            customAxisLabel4.AxisValueSerializable = "0";
            customAxisLabel4.Name = "   x";
            ConstantLine constantLine4 = new ConstantLine();
            constantLine4.AxisValueSerializable = "0";
            constantLine4.CheckableInLegend = false;
            constantLine4.CheckedInLegend = false;
            constantLine4.LegendName = "Default Legend";
            //constantLine4.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine4.Name = "Constant Line 1";
            constantLine4.ShowInLegend = false;
            constantLine4.Title.Visible = false;
            constantLine4.Color = System.Drawing.Color.Black;
            constantLine4.LineStyle.Thickness = 2;

            customAxisLabel5.AxisValueSerializable = "-1";
            customAxisLabel5.Name = "   -1s";
            ConstantLine constantLine5 = new ConstantLine();
            constantLine5.AxisValueSerializable = "-1";
            constantLine5.CheckableInLegend = false;
            constantLine5.CheckedInLegend = false;
            constantLine5.LegendName = "Default Legend";
            constantLine5.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine5.Name = "Constant Line 1";
            constantLine5.ShowInLegend = false;
            constantLine5.Title.Visible = false;
            constantLine5.Color = System.Drawing.Color.Green;
            constantLine5.LineStyle.Thickness = 2;

            customAxisLabel6.AxisValueSerializable = "-2";
            customAxisLabel6.Name = "   -2s";
            ConstantLine constantLine6 = new ConstantLine();
            constantLine6.AxisValueSerializable = "-2";
            constantLine6.CheckableInLegend = false;
            constantLine6.CheckedInLegend = false;
            constantLine6.LegendName = "Default Legend";
            constantLine6.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine6.Name = "Constant Line 1";
            constantLine6.ShowInLegend = false;
            constantLine6.Title.Visible = false;
            constantLine6.Color = System.Drawing.Color.BlueViolet;
            constantLine6.LineStyle.Thickness = 2;

            customAxisLabel7.AxisValueSerializable = "-3";
            customAxisLabel7.Name = "   -3s";
            ConstantLine constantLine7 = new ConstantLine();
            constantLine7.AxisValueSerializable = "-3";
            constantLine7.CheckableInLegend = false;
            constantLine7.CheckedInLegend = false;
            constantLine7.LegendName = "Default Legend";
            constantLine7.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.DashDot;
            constantLine7.Name = "Constant Line 1";
            constantLine7.ShowInLegend = false;
            constantLine7.Title.Visible = false;
            constantLine7.Color = System.Drawing.Color.OrangeRed;
            constantLine7.LineStyle.Thickness = 2;



            xyDiagram.AxisY.CustomLabels.AddRange(new DevExpress.XtraCharts.CustomAxisLabel[] {
            customAxisLabel1,
            customAxisLabel2,
            customAxisLabel3,
            customAxisLabel4,
            customAxisLabel5,
            customAxisLabel6,
            customAxisLabel7});
            xyDiagram.AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine1,
            constantLine2,
            constantLine3,
            constantLine4,
            constantLine5,
            constantLine6,
            constantLine7});


            #endregion


            //panel1.Controls.Add(chart);
            //chart.Dock = DockStyle.Fill;


            chart.CustomDrawCrosshair += Chart_CustomDrawCrosshair;


            return chart;
        }
        ///// <summary>
        ///// 获取图上坐标信息
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private static void Chart_ObjectSelected(object sender, HotTrackEventArgs e)
        //{
        //    e.Cancel = false;
        //    XYDiagram xyDiagram = null;
        //    if (e.Object is XYDiagram)
        //    {
        //        xyDiagram = (XYDiagram)e.Object;
        //    }
        //    else if (e.Object is SeriesBase)
        //    {
        //        xyDiagram = (XYDiagram)(e.HitInfo.Diagram);
        //    }
        //    if (xyDiagram != null)
        //    {
        //        DiagramCoordinates coord = xyDiagram.PointToDiagram(e.HitInfo.HitPoint);
        //        DateTime pTime = coord.DateTimeArgument;//时间点



        //        MessageBox.Show(pTime.ToString());
        //        /*..其他针对该时间点的处理..*/
        //    }
        //}


        /// <summary>
        /// 自定义Crosshair（浮动框信息）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Chart_CustomDrawCrosshair(object sender, CustomDrawCrosshairEventArgs e)
        {
            //foreach (CrosshairElement element in e.CrosshairElements)
#pragma warning disable CS0618 // “CustomDrawCrosshairEventArgs.CrosshairElements”已过时:“The CustomDrawCrosshairEventArgs.CrosshairElements property is now obsolete. Use the CustomDrawCrosshairEventArgs.CrosshairElementGroups.CrosshairElements property instead.”
            foreach (CrosshairElement element in e.CrosshairElements)
#pragma warning restore CS0618 // “CustomDrawCrosshairEventArgs.CrosshairElements”已过时:“The CustomDrawCrosshairEventArgs.CrosshairElements property is now obsolete. Use the CustomDrawCrosshairEventArgs.CrosshairElementGroups.CrosshairElements property instead.”
            {
                SeriesPoint point = element.SeriesPoint;
                //element.LabelElement.MarkerImage = Image.FromFile(@"C:\Users\huang\Desktop\aa.png");// 设置图片路径  
                //element.LabelElement.MarkerImageSizeMode = ChartImageSizeMode.Stretch;
                //element.LabelElement.MarkerSize = new Size(20, 20); // 大小  
                element.LabelElement.Text = element.Series.Name + ":" + point.Values[0].ToString() + "\r\n" + point.Tag;//显示要显示的文字  
            }

        }


        /// <summary>
        /// 设置是否显示十字标线
        /// </summary>
        /// <param name="chart">ChartControl</param>
        /// <param name="crosshair">是否显示十字标线</param>
        public static void SetCrosshair(ChartControl chart, bool crosshair)
        {
            chart.CrosshairEnabled = crosshair ? DefaultBoolean.True : DefaultBoolean.False;
            //chart.CrosshairOptions.ShowArgumentLabels = crosshair;



            chart.CrosshairOptions.ShowArgumentLabels = crosshair;
            chart.CrosshairOptions.ShowArgumentLine = crosshair;



            chart.CrosshairOptions.ShowValueLabels = crosshair;
            chart.CrosshairOptions.ShowValueLine = crosshair;

            chart.CrosshairOptions.ValueSelectionMode = CrosshairValueSelectionMode.Value;
        }

        /// <summary>
        /// 增加数据筛选
        /// </summary>
        /// <param name="SeriesBase">Series</param>
        /// <param name="columnName">列名称</param>
        /// <param name="value">列名称对应的筛选数值</param>
        /// <param name="dataFilterCondition">DataFilterCondition枚举</param>
        public static void AddDataFilter(SeriesBase series, string columnName, object value, DataFilterCondition dataFilterCondition)
        {
#pragma warning disable CS0618 // “SeriesBase.DataFilters”已过时:“This property is obsolete now. Use the FilterString or FilterCriteria property instead.”
            series.DataFilters.Add(new DataFilter(columnName, value.GetType().FullName, dataFilterCondition, value));
#pragma warning restore CS0618 // “SeriesBase.DataFilters”已过时:“This property is obsolete now. Use the FilterString or FilterCriteria property instead.”
        }

        /// <summary>
        /// 设置X轴Lable角度
        /// </summary>
        /// <param name="chart">ChartControl</param>
        /// <param name="angle">角度</param>
        public static void SetXLableAngle(ChartControl chart, int angle)
        {
            XYDiagram _xyDiagram = (XYDiagram)chart.Diagram;
            if (_xyDiagram != null)
                _xyDiagram.AxisX.Label.Angle = angle;
        }

        /// <summary>
        ///  设置Y轴Lable角度
        /// </summary>
        /// <param name="chart">ChartControl</param>
        /// <param name="angle">角度</param>
        public static void SetYLableAngle(ChartControl chart, int angle)
        {
            XYDiagram _xyDiagram = (XYDiagram)chart.Diagram;
            _xyDiagram.AxisY.Label.Angle = angle;
        }

        /// <summary>
        /// 设置ColorEach
        /// </summary>
        /// <param name="chart">ChartControl</param>
        /// <param name="colorEach">是否设置成ColorEach</param>
        public static void SetColorEach(Series series, bool colorEach)
        {
            SeriesViewColorEachSupportBase colorEachView = (SeriesViewColorEachSupportBase)series.View;
            if (colorEachView != null)
            {
                colorEachView.ColorEach = colorEach;
            }
        }


        /// <summary>
        /// 新增ChartControl的Title文字
        /// </summary>
        /// <param name="chart">ChartControl</param>
        /// <param name="title">Title文字</param>
        public static void AddTitle(ChartControl chart, string title)
        {
            ChartTitle _title = new ChartTitle();
            _title.Text = title;
            chart.Titles.Add(_title);
        }

        /// <summary>
        /// 饼状Series设置成百分比显示
        /// </summary>
        /// <param name="series">Series</param>
        public static void SetPiePercentage(Series series)
        {
            if (series.View is PieSeriesView)
            {
#pragma warning disable CS0618 // “SeriesBase.PointOptions”已过时:“This property is obsolete now. Use the SeriesLabelBase.TextPattern property instead.”
                ((PiePointOptions)series.PointOptions).PercentOptions.ValueAsPercent = true;
#pragma warning restore CS0618 // “SeriesBase.PointOptions”已过时:“This property is obsolete now. Use the SeriesLabelBase.TextPattern property instead.”
#pragma warning disable CS0618 // “SeriesBase.PointOptions”已过时:“This property is obsolete now. Use the SeriesLabelBase.TextPattern property instead.”
                ((PiePointOptions)series.PointOptions).ValueNumericOptions.Format = NumericFormat.Percent;
#pragma warning restore CS0618 // “SeriesBase.PointOptions”已过时:“This property is obsolete now. Use the SeriesLabelBase.TextPattern property instead.”
#pragma warning disable CS0618 // “SeriesBase.PointOptions”已过时:“This property is obsolete now. Use the SeriesLabelBase.TextPattern property instead.”
                ((PiePointOptions)series.PointOptions).ValueNumericOptions.Precision = 0;
#pragma warning restore CS0618 // “SeriesBase.PointOptions”已过时:“This property is obsolete now. Use the SeriesLabelBase.TextPattern property instead.”
            }
        }










































        public static BandedGridView createQCResultInfoDT(DataTable selectQCInfoDT, out DataTable DTresultInfo)
        {
            BandedGridView bandedGridView = new BandedGridView();
            bandedGridView.Name = "bGVQCResult";
            //((System.ComponentModel.ISupportInitialize)(bandedGridView)).BeginInit();
            DataTable DTresult = new DataTable();
            bandedGridView.CustomDrawCell += BandedGridView_CustomDrawCell;

            //try
            //{


            if (selectQCInfoDT != null && selectQCInfoDT.Rows.Count > 0)
            {
                GridBand gridBand = new GridBand();
                gridBand.AppearanceHeader.Options.UseTextOptions = true;
                gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand.Caption = "质控";
                gridBand.Name = "QC";
                bandedGridView.Bands.Add(gridBand);
                if (!DTresult.Columns.Contains("qcTime"))
                {
                    BandedGridColumn bandedGridColumn = new BandedGridColumn
                    {
                        Caption = "质控日期",
                        Name = "ResultQCTime",
                        FieldName = "qcTime",
                        Visible = true
                    };
                    bandedGridColumn.OptionsColumn.AllowFocus = false;
                    bandedGridView.Columns.Add(bandedGridColumn);
                    gridBand.Columns.Add(bandedGridColumn);
                    DTresult.Columns.Add("qcTime", typeof(DateTime));
                }

                if (!DTresult.Columns.Contains("itemResultsort"))
                {
                    BandedGridColumn bandedGridColumn = new BandedGridColumn
                    {
                        Caption = "次数",
                        Name = "ResultItemResultsort",
                        FieldName = "itemResultsort",
                        Visible = true
                    };
                    bandedGridColumn.OptionsColumn.AllowFocus = false;
                    bandedGridView.Columns.Add(bandedGridColumn);
                    gridBand.Columns.Add(bandedGridColumn);
                    DTresult.Columns.Add("itemResultsort", typeof(string));
                }
                if (!DTresult.Columns.Contains("resultState"))
                {
                    BandedGridColumn bandedGridColumn = new BandedGridColumn
                    {
                        Caption = "状态",
                        Name = "ResultresultState",
                        FieldName = "resultState",
                        Visible = true,
                        Width = 35
                    };
                    bandedGridColumn.OptionsColumn.AllowFocus = false;
                    bandedGridView.Columns.Add(bandedGridColumn);
                    gridBand.Columns.Add(bandedGridColumn);
                    DTresult.Columns.Add("resultState", typeof(bool));
                }
                gridBand.VisibleIndex = 0;
                //bandedGridView.Bands.Add(gridBand);


#pragma warning disable CS0219 // 变量“levelNOs”已被赋值，但从未使用过它的值
                string levelNOs = "";
#pragma warning restore CS0219 // 变量“levelNOs”已被赋值，但从未使用过它的值
                List<string> planGradeLowids = new List<string>();
                List<string> planGradeMiddleids = new List<string>();
                List<string> planGradeHeightids = new List<string>();
                int a = 1;
                //格式化bandedGridView并生成datatable架构表
                foreach (DataRow resultDR in selectQCInfoDT.Rows)
                {

                    string levelNO = resultDR["planGradelevelNO"] != DBNull.Value ? resultDR["planGradelevelNO"].ToString() : "";
                    string planGradeCode = resultDR["planGradeCode"] != DBNull.Value ? resultDR["planGradeCode"].ToString() : "";
                    string planGradeid = resultDR["planGradeid"] != DBNull.Value ? resultDR["planGradeid"].ToString() : "";

                    if (levelNO != "")
                    {
                        if (levelNO == "1")
                        {
                            if (!planGradeLowids.Contains(planGradeid))
                            {
                                planGradeLowids.Add(planGradeid);
                                GridBand gridBandLow = new GridBand();
                                gridBandLow.AppearanceHeader.Options.UseTextOptions = true;
                                gridBandLow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                gridBandLow.Caption = "低水平" + resultDR["planGradeCode"];
                                gridBandLow.Name = "QCLow" + planGradeid;

                                BandedGridColumn bandedGridColumn = new BandedGridColumn
                                {
                                    Caption = "结果(低)",
                                    Name = "qcLowItemResult" + planGradeid,
                                    FieldName = "qcLowItemResult" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn);
                                gridBandLow.Columns.Add(bandedGridColumn);
                                DTresult.Columns.Add("qcLowItemResult" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn2 = new BandedGridColumn
                                {
                                    Caption = "违反规则(低)",
                                    Name = "qcLowRule" + planGradeid,
                                    FieldName = "qcLowRule" + planGradeid,
                                    Visible = true
                                };
                                //RepositoryItemGridLookUpEdit RGEQCLowRemark = new RepositoryItemGridLookUpEdit();
                                //RGEQCLowRemark.Name = "RGE" + "qcLowRule" + planGradeid;
                                //GridLookUpEdites.Formats(RGEQCLowRemark);
                                //RGEQCLowRemark.DataSource = QCInfoData.DTRuleQC;
                                //bandedGridColumn2.ColumnEdit = RGEQCLowRemark;
                                bandedGridColumn2.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn2);
                                gridBandLow.Columns.Add(bandedGridColumn2);
                                DTresult.Columns.Add("qcLowRule" + planGradeid, typeof(string));


                                BandedGridColumn bandedGridColumn3 = new BandedGridColumn
                                {
                                    Caption = "Z分数值(低)",
                                    Name = "qcLowZValue" + planGradeid,
                                    FieldName = "qcLowZValue" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn3.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn3);
                                gridBandLow.Columns.Add(bandedGridColumn3);
                                DTresult.Columns.Add("qcLowZValue" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn4 = new BandedGridColumn
                                {
                                    Caption = "状态(低)",
                                    Name = "qcLowType" + planGradeid,
                                    FieldName = "qcLowType" + planGradeid,
                                    Visible = true
                                };
                                RepositoryItemGridLookUpEdit RGEQCLowType = new RepositoryItemGridLookUpEdit();
                                RGEQCLowType.Name = "RGE" + "qcLowType" + planGradeid;
                                GridLookUpEdites.Formats(RGEQCLowType);
                                RGEQCLowType.DataSource = QCInfoData.DTCriteriaType;
                                bandedGridColumn4.ColumnEdit = RGEQCLowType;
                                bandedGridColumn4.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn4);
                                gridBandLow.Columns.Add(bandedGridColumn4);
                                DTresult.Columns.Add("qcLowType" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn5 = new BandedGridColumn
                                {
                                    Caption = "备注(低)",
                                    Name = "qcLowRemark" + planGradeid,
                                    FieldName = "qcLowRemark" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn5.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn5);
                                gridBandLow.Columns.Add(bandedGridColumn5);
                                DTresult.Columns.Add("qcLowRemark" + planGradeid, typeof(string));

                                gridBandLow.VisibleIndex = resultDR["planGradesort"] != DBNull.Value ? Convert.ToInt32(resultDR["planGradesort"]) : 1; ;
                                a += 1;
                                //bandedGridView.Bands.Add(gridBandLow);
                                bandedGridView.Bands.Add(gridBandLow);
                            }
                        }
                        if (levelNO == "2")
                        {
                            if (!planGradeMiddleids.Contains(planGradeid))
                            {
                                planGradeMiddleids.Add(planGradeid);
                                GridBand gridBandLow = new GridBand();
                                gridBandLow.AppearanceHeader.Options.UseTextOptions = true;
                                gridBandLow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                gridBandLow.Caption = "中水平" + resultDR["planGradeCode"];
                                gridBandLow.Name = "QCMiddle" + planGradeid;
                                //bandedGridView.Bands.Add(gridBandLow);
                                BandedGridColumn bandedGridColumn = new BandedGridColumn
                                {
                                    Caption = "结果(中)",
                                    Name = "qcMiddleItemResult" + planGradeid,
                                    FieldName = "qcMiddleItemResult" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn);
                                gridBandLow.Columns.Add(bandedGridColumn);
                                DTresult.Columns.Add("qcMiddleItemResult" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn2 = new BandedGridColumn
                                {
                                    Caption = "违反规则(中)",
                                    Name = "qcMiddleRule" + planGradeid,
                                    FieldName = "qcMiddleRule" + planGradeid,
                                    Visible = true
                                };
                                //RepositoryItemGridLookUpEdit RGEQCLowRemark = new RepositoryItemGridLookUpEdit();
                                //RGEQCLowRemark.Name = "RGE" + "qcMiddleRule" + planGradeid;
                                //GridLookUpEdites.Formats(RGEQCLowRemark);
                                //RGEQCLowRemark.DataSource = QCInfoData.DTRuleQC;
                                //bandedGridColumn2.ColumnEdit = RGEQCLowRemark;
                                bandedGridColumn2.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn2);
                                gridBandLow.Columns.Add(bandedGridColumn2);
                                DTresult.Columns.Add("qcMiddleRule" + planGradeid, typeof(string));


                                BandedGridColumn bandedGridColumn3 = new BandedGridColumn
                                {
                                    Caption = "Z分数值(中)",
                                    Name = "qcMiddleZValue" + planGradeid,
                                    FieldName = "qcMiddleZValue" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn3.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn3);
                                gridBandLow.Columns.Add(bandedGridColumn3);
                                DTresult.Columns.Add("qcMiddleZValue" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn4 = new BandedGridColumn
                                {
                                    Caption = "状态(中)",
                                    Name = "qcMiddleType" + planGradeid,
                                    FieldName = "qcMiddleType" + planGradeid,
                                    Visible = true
                                };
                                RepositoryItemGridLookUpEdit RGEQCMiddleType = new RepositoryItemGridLookUpEdit();
                                RGEQCMiddleType.Name = "RGE" + "qcMiddleType" + planGradeid;
                                GridLookUpEdites.Formats(RGEQCMiddleType);
                                RGEQCMiddleType.DataSource = QCInfoData.DTCriteriaType;
                                bandedGridColumn4.ColumnEdit = RGEQCMiddleType;
                                bandedGridColumn4.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn4);
                                gridBandLow.Columns.Add(bandedGridColumn4);
                                DTresult.Columns.Add("qcMiddleType" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn5 = new BandedGridColumn
                                {
                                    Caption = "备注(中)",
                                    Name = "qcMiddleRemark" + planGradeid,
                                    FieldName = "qcMiddleRemark" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn5.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn5);
                                gridBandLow.Columns.Add(bandedGridColumn5);
                                DTresult.Columns.Add("qcMiddleRemark" + planGradeid, typeof(string));

                                gridBandLow.VisibleIndex = resultDR["planGradesort"] != DBNull.Value ? Convert.ToInt32(resultDR["planGradesort"]) : 1; ;
                                a += 1;
                                bandedGridView.Bands.Add(gridBandLow);

                            }
                        }
                        if (levelNO == "3")
                        {
                            if (!planGradeHeightids.Contains(planGradeid))
                            {
                                planGradeHeightids.Add(planGradeid);
                                GridBand gridBandLow = new GridBand();
                                gridBandLow.AppearanceHeader.Options.UseTextOptions = true;
                                gridBandLow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                gridBandLow.Caption = "高水平" + resultDR["planGradeCode"];
                                gridBandLow.Name = "QCHeight" + planGradeid;
                                //bandedGridView.Bands.Add(gridBandLow);
                                BandedGridColumn bandedGridColumn = new BandedGridColumn
                                {
                                    Caption = "结果(高)",
                                    Name = "qcHeightItemResult" + planGradeid,
                                    FieldName = "qcHeightItemResult" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn);
                                gridBandLow.Columns.Add(bandedGridColumn);
                                DTresult.Columns.Add("qcHeightItemResult" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn2 = new BandedGridColumn
                                {
                                    Caption = "违反规则(高)",
                                    Name = "qcHeightRule" + planGradeid,
                                    FieldName = "qcHeightRule" + planGradeid,
                                    Visible = true
                                };
                                //RepositoryItemGridLookUpEdit RGEQCLowRemark = new RepositoryItemGridLookUpEdit();
                                //RGEQCLowRemark.Name = "RGE" + "qcHeightRule" + planGradeid;
                                //GridLookUpEdites.Formats(RGEQCLowRemark);
                                //RGEQCLowRemark.DataSource = QCInfoData.DTRuleQC;
                                //bandedGridColumn2.ColumnEdit = RGEQCLowRemark;
                                bandedGridColumn2.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn2);
                                gridBandLow.Columns.Add(bandedGridColumn2);
                                DTresult.Columns.Add("qcHeightRule" + planGradeid, typeof(string));


                                BandedGridColumn bandedGridColumn3 = new BandedGridColumn
                                {
                                    Caption = "Z分数值(高)",
                                    Name = "qcHeightZValue" + planGradeid,
                                    FieldName = "qcHeightZValue" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn3.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn3);
                                gridBandLow.Columns.Add(bandedGridColumn3);
                                DTresult.Columns.Add("qcHeightZValue" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn4 = new BandedGridColumn
                                {
                                    Caption = "状态(高)",
                                    Name = "qcHeightType" + planGradeid,
                                    FieldName = "qcHeightType" + planGradeid,
                                    Visible = true
                                };
                                RepositoryItemGridLookUpEdit RGEQCHeightType = new RepositoryItemGridLookUpEdit();
                                RGEQCHeightType.Name = "RGE" + "qcHeightType" + planGradeid;
                                GridLookUpEdites.Formats(RGEQCHeightType);
                                RGEQCHeightType.DataSource = QCInfoData.DTCriteriaType;
                                bandedGridColumn4.ColumnEdit = RGEQCHeightType;
                                bandedGridColumn4.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn4);
                                gridBandLow.Columns.Add(bandedGridColumn4);
                                DTresult.Columns.Add("qcHeightType" + planGradeid, typeof(string));



                                BandedGridColumn bandedGridColumn5 = new BandedGridColumn
                                {
                                    Caption = "备注(高)",
                                    Name = "qcHeightRemark" + planGradeid,
                                    FieldName = "qcHeightRemark" + planGradeid,
                                    Visible = true
                                };
                                bandedGridColumn5.OptionsColumn.AllowFocus = false;
                                bandedGridView.Columns.Add(bandedGridColumn5);
                                gridBandLow.Columns.Add(bandedGridColumn5);
                                DTresult.Columns.Add("qcHeightRemark" + planGradeid, typeof(string));

                                gridBandLow.VisibleIndex = resultDR["planGradesort"] != DBNull.Value ? Convert.ToInt32(resultDR["planGradesort"]) : 1; ;
                                a += 1;
                                bandedGridView.Bands.Add(gridBandLow);

                            }
                        }
                    }
                }
                DataRow DRinfo = DTresult.NewRow(); ;
                string QCDates = "";
                string itemResultsorts = "";
                //遍历生成dataTable数据
                foreach (DataRow resultDR in selectQCInfoDT.Rows)
                {

                    string levelNO = resultDR["planGradelevelNO"] != DBNull.Value ? resultDR["planGradelevelNO"].ToString() : "";
                    string planGradeid = resultDR["planGradeid"] != DBNull.Value ? resultDR["planGradeid"].ToString() : "";
                    string QCDate = resultDR["qcTime"] != DBNull.Value ? Convert.ToDateTime(resultDR["qcTime"]).ToString("yyyy-MM-dd") : DateTime.MinValue.ToString("yyyy-MM-dd");
                    string itemResultsort = resultDR["itemResultsort"] != DBNull.Value ? resultDR["itemResultsort"].ToString() : "";
                    if (QCDate != "" && itemResultsort != "")
                    {
                        if (QCDates != QCDate || itemResultsorts != itemResultsort)
                        {
                            QCDates = QCDate;
                            itemResultsorts = itemResultsort;
                            DRinfo = DTresult.NewRow();
                            DTresult.Rows.Add(DRinfo);
                        }

                        DRinfo["qcTime"] = resultDR["qcTime"];
                        DRinfo["itemResultsort"] = itemResultsort;
                        DRinfo["resultState"] = resultDR["resultState"];
                        if (levelNO == "1")
                        {
                            DRinfo["qcLowItemResult" + planGradeid] = resultDR["itemResult"];
                            DRinfo["qcLowRule" + planGradeid] = resultDR["resultRule"];
                            DRinfo["qcLowZValue" + planGradeid] = resultDR["zVlaue"];
                            DRinfo["qcLowType" + planGradeid] = resultDR["resultType"];
                            DRinfo["qcLowRemark" + planGradeid] = resultDR["itemResultRemark"];
                        }
                        if (levelNO == "2")
                        {
                            DRinfo["qcMiddleItemResult" + planGradeid] = resultDR["itemResult"];
                            DRinfo["qcMiddleRule" + planGradeid] = resultDR["resultRule"];
                            DRinfo["qcMiddleZValue" + planGradeid] = resultDR["zVlaue"];
                            DRinfo["qcMiddleType" + planGradeid] = resultDR["resultType"];
                            DRinfo["qcMiddleRemark" + planGradeid] = resultDR["itemResultRemark"];
                        }
                        if (levelNO == "3")
                        {
                            DRinfo["qcHeightItemResult" + planGradeid] = resultDR["itemResult"];
                            DRinfo["qcHeightRule" + planGradeid] = resultDR["resultRule"];
                            DRinfo["qcHeightZValue" + planGradeid] = resultDR["zVlaue"];
                            DRinfo["qcHeightType" + planGradeid] = resultDR["resultType"];
                            DRinfo["qcHeightRemark" + planGradeid] = resultDR["itemResultRemark"];
                        }



                    }

                }
            }
            else
            {
                DTresult = null;
                //return bandedGridView;
            }
            //}
            //catch(Exception ex)
            //{
            //    DTresult = null;
            //    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
            DTresultInfo = DTresult;
            //bandedGridView.BestFitColumns();
            //((System.ComponentModel.ISupportInitialize)(bandedGridView)).EndInit();
            return bandedGridView;
        }

        private static void BandedGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Contains("Type"))
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() != "")
                        {
                            if (QCInfoData.DTCriteriaType.Select($"no={e.CellValue}").Count() > 0)
                            {
                                int b = Convert.ToInt32(QCInfoData.DTCriteriaType.Select($"no='{e.CellValue}'").CopyToDataTable().Rows[0]["typeColor"]);
                                e.Appearance.BackColor = Color.FromArgb(b);
                            }
                        }
                    }
                }
            }
            catch //(Exception ex)
            {

                //MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }
}
