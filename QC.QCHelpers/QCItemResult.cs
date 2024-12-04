using Common.Data;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace QC.QCHelpers
{
    public class QCItemResult
    {
        //public static BandedGridView createQCResultInfoDT(DataTable QCResultInfoDT)
        //{
        //    BandedGridView bandedGridView = new BandedGridView();
        //    bandedGridView.Name = "bGVQCResult";
        //    //((System.ComponentModel.ISupportInitialize)(bandedGridView)).BeginInit();
        //    DataTable DTresult = new DataTable();
        //    bandedGridView.CustomDrawCell += BandedGridView_CustomDrawCell;

        //    //try
        //    //{


        //    if (QCResultInfoDT != null && QCResultInfoDT.Rows.Count > 0)
        //    {
        //        GridBand gridBand = new GridBand();
        //        gridBand.AppearanceHeader.Options.UseTextOptions = true;
        //        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //        gridBand.Caption = "质控";
        //        gridBand.Name = "QC";
        //        bandedGridView.Bands.Add(gridBand);
        //        if (QCResultInfoDT.Columns.Contains("qcTime"))
        //        {
        //            BandedGridColumn bandedGridColumn = new BandedGridColumn
        //            {
        //                Caption = "质控日期",
        //                Name = "ResultQCTime",
        //                FieldName = "qcTime",
        //                Visible = true
        //            };
        //            bandedGridColumn.OptionsColumn.AllowFocus = false;
        //            bandedGridView.Columns.Add(bandedGridColumn);
        //            gridBand.Columns.Add(bandedGridColumn);
        //        }

        //        if (QCResultInfoDT.Columns.Contains("itemResultsort"))
        //        {
        //            BandedGridColumn bandedGridColumn = new BandedGridColumn
        //            {
        //                Caption = "次数",
        //                Name = "ResultItemResultsort",
        //                FieldName = "itemResultsort",
        //                Visible = true
        //            };
        //            bandedGridColumn.OptionsColumn.AllowFocus = false;
        //            bandedGridView.Columns.Add(bandedGridColumn);
        //            gridBand.Columns.Add(bandedGridColumn);
        //        }
        //        if (QCResultInfoDT.Columns.Contains("resultState"))
        //        {
        //            BandedGridColumn bandedGridColumn = new BandedGridColumn
        //            {
        //                Caption = "状态",
        //                Name = "ResultresultState",
        //                FieldName = "resultState",
        //                Visible = true,
        //                Width = 35
        //            };
        //            bandedGridColumn.OptionsColumn.AllowFocus = false;
        //            bandedGridView.Columns.Add(bandedGridColumn);
        //            gridBand.Columns.Add(bandedGridColumn);
        //        }
        //        gridBand.VisibleIndex = 0;
        //        //bandedGridView.Bands.Add(gridBand);


        //        string levelNOs = "";
        //        List<string> planGradeLowids = new List<string>();
        //        List<string> planGradeMiddleids = new List<string>();
        //        List<string> planGradeHeightids = new List<string>();
        //        int a = 1;
        //        //格式化bandedGridView并生成datatable架构表
        //        foreach (DataColumn column in QCResultInfoDT.Columns)
        //        {


        //            if (column.ColumnName.Contains("Low"))
        //            {
        //                if(column.ColumnName.Contains("LowItemResult"))
        //                {
        //                    planGradeLowids.Add(column.ColumnName);
        //                    GridBand gridBandLow = new GridBand();
        //                    gridBandLow.AppearanceHeader.Options.UseTextOptions = true;
        //                    gridBandLow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //                    gridBandLow.Caption = "低水平" + resultDR["planGradeCode"];
        //                    gridBandLow.Name = "QCLow" + planGradeid;

        //                    BandedGridColumn bandedGridColumn = new BandedGridColumn
        //                    {
        //                        Caption = "结果(低)",
        //                        Name = "qcLowItemResult" + planGradeid,
        //                        FieldName = "qcLowItemResult" + planGradeid,
        //                        Visible = true
        //                    };
        //                    bandedGridColumn.OptionsColumn.AllowFocus = false;
        //                    bandedGridView.Columns.Add(bandedGridColumn);
        //                    gridBandLow.Columns.Add(bandedGridColumn);
        //                }





        //                BandedGridColumn bandedGridColumn2 = new BandedGridColumn
        //                {
        //                    Caption = "违反规则(低)",
        //                    Name = "qcLowRule" + planGradeid,
        //                    FieldName = "qcLowRule" + planGradeid,
        //                    Visible = true
        //                };
        //                //RepositoryItemGridLookUpEdit RGEQCLowRemark = new RepositoryItemGridLookUpEdit();
        //                //RGEQCLowRemark.Name = "RGE" + "qcLowRule" + planGradeid;
        //                //GridLookUpEdites.Formats(RGEQCLowRemark);
        //                //RGEQCLowRemark.DataSource = QCInfoData.DTRuleQC;
        //                //bandedGridColumn2.ColumnEdit = RGEQCLowRemark;
        //                bandedGridColumn2.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn2);
        //                gridBandLow.Columns.Add(bandedGridColumn2);
        //                DTresult.Columns.Add("qcLowRule" + planGradeid, typeof(string));


        //                BandedGridColumn bandedGridColumn3 = new BandedGridColumn
        //                {
        //                    Caption = "Z分数值(低)",
        //                    Name = "qcLowZValue" + planGradeid,
        //                    FieldName = "qcLowZValue" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn3.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn3);
        //                gridBandLow.Columns.Add(bandedGridColumn3);
        //                DTresult.Columns.Add("qcLowZValue" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn4 = new BandedGridColumn
        //                {
        //                    Caption = "状态(低)",
        //                    Name = "qcLowType" + planGradeid,
        //                    FieldName = "qcLowType" + planGradeid,
        //                    Visible = true
        //                };
        //                RepositoryItemGridLookUpEdit RGEQCLowType = new RepositoryItemGridLookUpEdit();
        //                RGEQCLowType.Name = "RGE" + "qcLowType" + planGradeid;
        //                GridLookUpEdites.Formats(RGEQCLowType);
        //                RGEQCLowType.DataSource = QCInfoData.DTCriteriaType;
        //                bandedGridColumn4.ColumnEdit = RGEQCLowType;
        //                bandedGridColumn4.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn4);
        //                gridBandLow.Columns.Add(bandedGridColumn4);
        //                DTresult.Columns.Add("qcLowType" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn5 = new BandedGridColumn
        //                {
        //                    Caption = "备注(低)",
        //                    Name = "qcLowRemark" + planGradeid,
        //                    FieldName = "qcLowRemark" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn5.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn5);
        //                gridBandLow.Columns.Add(bandedGridColumn5);
        //                DTresult.Columns.Add("qcLowRemark" + planGradeid, typeof(string));

        //                gridBandLow.VisibleIndex = resultDR["planGradesort"] != DBNull.Value ? Convert.ToInt32(resultDR["planGradesort"]) : 1; ;
        //                a += 1;
        //                //bandedGridView.Bands.Add(gridBandLow);
        //                bandedGridView.Bands.Add(gridBandLow);
        //            }

        //            if (!planGradeMiddleids.Contains(planGradeid))
        //            {
        //                planGradeMiddleids.Add(planGradeid);
        //                GridBand gridBandLow = new GridBand();
        //                gridBandLow.AppearanceHeader.Options.UseTextOptions = true;
        //                gridBandLow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //                gridBandLow.Caption = "中水平" + resultDR["planGradeCode"];
        //                gridBandLow.Name = "QCMiddle" + planGradeid;
        //                //bandedGridView.Bands.Add(gridBandLow);
        //                BandedGridColumn bandedGridColumn = new BandedGridColumn
        //                {
        //                    Caption = "结果(中)",
        //                    Name = "qcMiddleItemResult" + planGradeid,
        //                    FieldName = "qcMiddleItemResult" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn);
        //                gridBandLow.Columns.Add(bandedGridColumn);
        //                DTresult.Columns.Add("qcMiddleItemResult" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn2 = new BandedGridColumn
        //                {
        //                    Caption = "违反规则(中)",
        //                    Name = "qcMiddleRule" + planGradeid,
        //                    FieldName = "qcMiddleRule" + planGradeid,
        //                    Visible = true
        //                };
        //                //RepositoryItemGridLookUpEdit RGEQCLowRemark = new RepositoryItemGridLookUpEdit();
        //                //RGEQCLowRemark.Name = "RGE" + "qcMiddleRule" + planGradeid;
        //                //GridLookUpEdites.Formats(RGEQCLowRemark);
        //                //RGEQCLowRemark.DataSource = QCInfoData.DTRuleQC;
        //                //bandedGridColumn2.ColumnEdit = RGEQCLowRemark;
        //                bandedGridColumn2.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn2);
        //                gridBandLow.Columns.Add(bandedGridColumn2);
        //                DTresult.Columns.Add("qcMiddleRule" + planGradeid, typeof(string));


        //                BandedGridColumn bandedGridColumn3 = new BandedGridColumn
        //                {
        //                    Caption = "Z分数值(中)",
        //                    Name = "qcMiddleZValue" + planGradeid,
        //                    FieldName = "qcMiddleZValue" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn3.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn3);
        //                gridBandLow.Columns.Add(bandedGridColumn3);
        //                DTresult.Columns.Add("qcMiddleZValue" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn4 = new BandedGridColumn
        //                {
        //                    Caption = "状态(中)",
        //                    Name = "qcMiddleType" + planGradeid,
        //                    FieldName = "qcMiddleType" + planGradeid,
        //                    Visible = true
        //                };
        //                RepositoryItemGridLookUpEdit RGEQCMiddleType = new RepositoryItemGridLookUpEdit();
        //                RGEQCMiddleType.Name = "RGE" + "qcMiddleType" + planGradeid;
        //                GridLookUpEdites.Formats(RGEQCMiddleType);
        //                RGEQCMiddleType.DataSource = QCInfoData.DTCriteriaType;
        //                bandedGridColumn4.ColumnEdit = RGEQCMiddleType;
        //                bandedGridColumn4.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn4);
        //                gridBandLow.Columns.Add(bandedGridColumn4);
        //                DTresult.Columns.Add("qcMiddleType" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn5 = new BandedGridColumn
        //                {
        //                    Caption = "备注(中)",
        //                    Name = "qcMiddleRemark" + planGradeid,
        //                    FieldName = "qcMiddleRemark" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn5.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn5);
        //                gridBandLow.Columns.Add(bandedGridColumn5);
        //                DTresult.Columns.Add("qcMiddleRemark" + planGradeid, typeof(string));

        //                gridBandLow.VisibleIndex = resultDR["planGradesort"] != DBNull.Value ? Convert.ToInt32(resultDR["planGradesort"]) : 1; ;
        //                a += 1;
        //                bandedGridView.Bands.Add(gridBandLow);

        //            }

        //            if (!planGradeHeightids.Contains(planGradeid))
        //            {
        //                planGradeHeightids.Add(planGradeid);
        //                GridBand gridBandLow = new GridBand();
        //                gridBandLow.AppearanceHeader.Options.UseTextOptions = true;
        //                gridBandLow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //                gridBandLow.Caption = "高水平" + resultDR["planGradeCode"];
        //                gridBandLow.Name = "QCHeight" + planGradeid;
        //                //bandedGridView.Bands.Add(gridBandLow);
        //                BandedGridColumn bandedGridColumn = new BandedGridColumn
        //                {
        //                    Caption = "结果(高)",
        //                    Name = "qcHeightItemResult" + planGradeid,
        //                    FieldName = "qcHeightItemResult" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn);
        //                gridBandLow.Columns.Add(bandedGridColumn);
        //                DTresult.Columns.Add("qcHeightItemResult" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn2 = new BandedGridColumn
        //                {
        //                    Caption = "违反规则(高)",
        //                    Name = "qcHeightRule" + planGradeid,
        //                    FieldName = "qcHeightRule" + planGradeid,
        //                    Visible = true
        //                };
        //                //RepositoryItemGridLookUpEdit RGEQCLowRemark = new RepositoryItemGridLookUpEdit();
        //                //RGEQCLowRemark.Name = "RGE" + "qcHeightRule" + planGradeid;
        //                //GridLookUpEdites.Formats(RGEQCLowRemark);
        //                //RGEQCLowRemark.DataSource = QCInfoData.DTRuleQC;
        //                //bandedGridColumn2.ColumnEdit = RGEQCLowRemark;
        //                bandedGridColumn2.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn2);
        //                gridBandLow.Columns.Add(bandedGridColumn2);
        //                DTresult.Columns.Add("qcHeightRule" + planGradeid, typeof(string));


        //                BandedGridColumn bandedGridColumn3 = new BandedGridColumn
        //                {
        //                    Caption = "Z分数值(高)",
        //                    Name = "qcHeightZValue" + planGradeid,
        //                    FieldName = "qcHeightZValue" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn3.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn3);
        //                gridBandLow.Columns.Add(bandedGridColumn3);
        //                DTresult.Columns.Add("qcHeightZValue" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn4 = new BandedGridColumn
        //                {
        //                    Caption = "状态(高)",
        //                    Name = "qcHeightType" + planGradeid,
        //                    FieldName = "qcHeightType" + planGradeid,
        //                    Visible = true
        //                };
        //                RepositoryItemGridLookUpEdit RGEQCHeightType = new RepositoryItemGridLookUpEdit();
        //                RGEQCHeightType.Name = "RGE" + "qcHeightType" + planGradeid;
        //                GridLookUpEdites.Formats(RGEQCHeightType);
        //                RGEQCHeightType.DataSource = QCInfoData.DTCriteriaType;
        //                bandedGridColumn4.ColumnEdit = RGEQCHeightType;
        //                bandedGridColumn4.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn4);
        //                gridBandLow.Columns.Add(bandedGridColumn4);
        //                DTresult.Columns.Add("qcHeightType" + planGradeid, typeof(string));



        //                BandedGridColumn bandedGridColumn5 = new BandedGridColumn
        //                {
        //                    Caption = "备注(高)",
        //                    Name = "qcHeightRemark" + planGradeid,
        //                    FieldName = "qcHeightRemark" + planGradeid,
        //                    Visible = true
        //                };
        //                bandedGridColumn5.OptionsColumn.AllowFocus = false;
        //                bandedGridView.Columns.Add(bandedGridColumn5);
        //                gridBandLow.Columns.Add(bandedGridColumn5);
        //                DTresult.Columns.Add("qcHeightRemark" + planGradeid, typeof(string));

        //                gridBandLow.VisibleIndex = resultDR["planGradesort"] != DBNull.Value ? Convert.ToInt32(resultDR["planGradesort"]) : 1; ;
        //                a += 1;
        //                bandedGridView.Bands.Add(gridBandLow);

        //            }

        //        }

        //        return bandedGridView;
        //    }
        //}


        public static BandedGridView createQCResultInfoDT(DataTable selectQCInfoDT, out DataTable DTresultInfo)
        {
            BandedGridView bandedGridView = new BandedGridView();
            bandedGridView.Name = "bGVQCResult";
            //((System.ComponentModel.ISupportInitialize)(bandedGridView)).BeginInit();
            DataTable DTresult = new DataTable();
            bandedGridView.CustomDrawCell += BandedGridView_CustomDrawCell;


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
                    bandedGridColumn.MinWidth = 25;
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


                string levelNOs = "";

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
                                //RepositoryItemGridLookUpEdit RGEQCLowType = new RepositoryItemGridLookUpEdit();
                                //RGEQCLowType.Name = "RGE" + "qcLowType" + planGradeid;
                                //GridLookUpEdites.Formats(RGEQCLowType);
                                //RGEQCLowType.DataSource = QCInfoData.DTCriteriaType;
                                //bandedGridColumn4.ColumnEdit = RGEQCLowType;
                                bandedGridColumn4.OptionsColumn.AllowFocus = false;
                                bandedGridColumn4.MinWidth = 50;
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
                                //RepositoryItemGridLookUpEdit RGEQCMiddleType = new RepositoryItemGridLookUpEdit();
                                //RGEQCMiddleType.Name = "RGE" + "qcMiddleType" + planGradeid;
                                //GridLookUpEdites.Formats(RGEQCMiddleType);
                                //RGEQCMiddleType.DataSource = QCInfoData.DTCriteriaType;
                                //bandedGridColumn4.ColumnEdit = RGEQCMiddleType;
                                bandedGridColumn4.OptionsColumn.AllowFocus = false;
                                bandedGridColumn4.MinWidth = 50;
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
                                //RepositoryItemGridLookUpEdit RGEQCHeightType = new RepositoryItemGridLookUpEdit();
                                //RGEQCHeightType.Name = "RGE" + "qcHeightType" + planGradeid;
                                //GridLookUpEdites.Formats(RGEQCHeightType);
                                //RGEQCHeightType.DataSource = QCInfoData.DTCriteriaType;
                                //bandedGridColumn4.ColumnEdit = RGEQCHeightType;
                                bandedGridColumn4.OptionsColumn.AllowFocus = false;
                                bandedGridColumn4.MinWidth = 50;
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
                            if (QCInfoData.DTCriteriaType.Select($"names='{e.CellValue}'").Count() > 0)
                            {
                                int b = Convert.ToInt32(QCInfoData.DTCriteriaType.Select($"names='{e.CellValue}'").CopyToDataTable().Rows[0]["typeColor"]);
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
