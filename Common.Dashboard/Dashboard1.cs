using Common.BLL;
using Common.JsonHelper;
using Common.Model;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess;
using DevExpress.DataAccess.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Dashboard
{
    public partial class Dashboard1 : DevExpress.DashboardCommon.Dashboard
    {

        string GetDashboard = "";
        public Dashboard1()
        {
            GetDashboard = ConfigInfos.ReadConfigInfo("GetDashboard");
            InitializeComponent();
            WebApiCallBack jm = ApiHelpers.postInfo(GetDashboard);
            loadinfo(jm);


        }
        public void loadinfo(WebApiCallBack jm)
        {
            DashboardModel dashboardinfo =Common.JsonHelper.JsonHelper.JsonConvertObject<DashboardModel>(jm);
            if(dashboardinfo!=null)
            {
                if (dashboardinfo.piesView != null)
                {
                    if (dashboardinfo.piesView.data != null)
                    {
                        piesjsonsrouce jsonsrouce = new piesjsonsrouce();

                        pieDashboardItem1.Name = dashboardinfo.piesView.name;

                        jsonsrouce.piesdata = dashboardinfo.piesView.data;

                        string str = Common.JsonHelper.JsonHelper.SerializeObjct(jsonsrouce);
                        var jsonDataSource = new DashboardJsonDataSource();
                        jsonDataSource.JsonSource = new CustomJsonSource(str);
                        jsonDataSource.RootElement = "piesdata";
                        this.DataSources.Add(jsonDataSource);
                        formartPies(jsonDataSource);
                    }

                }
                if (dashboardinfo.cardView != null)
                {
                    if (dashboardinfo.cardView.data != null)
                    {
                        cardjsonsrouce jsonsrouce = new cardjsonsrouce();

                        cardDashboardItem1.Name = dashboardinfo.cardView.name;

                        jsonsrouce.carddata = dashboardinfo.cardView.data;

                        string str = Common.JsonHelper.JsonHelper.SerializeObjct(jsonsrouce);
                        var jsonDataSource = new DashboardJsonDataSource();
                        jsonDataSource.JsonSource = new CustomJsonSource(str);
                        jsonDataSource.RootElement = "carddata";
                        this.DataSources.Add(jsonDataSource);
                        formartCard(jsonDataSource);
                    }

                }
                if (dashboardinfo.chartView != null)
                {
                    if (dashboardinfo.chartView.data != null)
                    {
                        chartjsonsrouce jsonsrouce = new chartjsonsrouce();


                        chartDashboardItem1.Name = dashboardinfo.chartView.name;

                        jsonsrouce.chartdata = dashboardinfo.chartView.data;

                        string str = Common.JsonHelper.JsonHelper.SerializeObjct(jsonsrouce);
                        var jsonDataSource = new DashboardJsonDataSource();
                        jsonDataSource.JsonSource = new CustomJsonSource(str);
                        jsonDataSource.RootElement = "chartdata";
                        this.DataSources.Add(jsonDataSource);
                        formartChart(jsonDataSource);
                    }

                }
            }



            //this.DataSources.Add(CreateJsonDataSourceFromString());
            //formartPies1(CreateJsonDataSourceFromString());
            //formartCard(CreateJsonDataSourceFromString());
            //formartChart(CreateJsonDataSourceFromString());
        }
        /// <summary>
        /// 生成pies表
        /// </summary>
        /// <param name="dataSource"></param>
        private void formartPies(IDashboardDataSource dataSource)
        {


            //PieDashboardItem pies = new PieDashboardItem();
            pieDashboardItem1.DataSource = dataSource;
            //pieDashboardItem1.Values.Add(new Measure("Extended Price"));
            //pieDashboardItem1.Arguments.Add(new Dimension("Country"));
            //pieDashboardItem1.SeriesDimensions.Add(new Dimension("OrderDate"));



            //pieDashboardItem1.Values.Add(new Measure("CompanyName"));
            pieDashboardItem1.Values.Add(new Measure("number"));
            pieDashboardItem1.Arguments.Add(new Dimension("name"));
            //pieDashboardItem1.SeriesDimensions.Add(new Dimension("CompanyName"));
            ////return pieDashboardItem1;
            //treemapDashboardItem2.PieType = PieType.Donut;
        }

        private void formartCard(IDashboardDataSource dataSource)
        {

            // Creates a card dashboard item and specifies its data source.
            //CardDashboardItem cards = new CardDashboardItem();
            cardDashboardItem1.DataSource = dataSource;

            // Creates the Card object with measures that provide data for calculating actual and target
            // values, and then adds this object to the Cards collection of the card dashboard item.

            
            Card card = new Card();


            //card.ActualValue = new Measure("RevenueQTD (Sum)");
            //card.TargetValue = new Measure("RevenueQTDTarget (Sum)");

            card.ActualValue = new Measure("number");
            //card.TargetValue = new Measure("RevenueQTDTarget (Sum)");
            cardDashboardItem1.Cards.Add(card);
            //cardDashboardItem1.SeriesDimensions.Clear();
            // Specifies dimensions that provides data for a card dashboard item series.
            cardDashboardItem1.SeriesDimensions.Add(new Dimension("name"));
            //cardDashboardItem1.SeriesDimensions.Add(new Dimension("CompanyName"));
            //cardDashboardItem1.SeriesDimensions.Add(new Dimension("number"));
            cardDashboardItem1.InteractivityOptions.IsDrillDownEnabled = false;

            //return cards;





            //CardCompactLayoutTemplate layout = new CardCompactLayoutTemplate();
            //cardDashboardItem1.Cards[0].LayoutTemplate = layout;
            //cardDashboardItem1.DataSource = dataSource;
            //AddRulesToTheFirstCard(cardDashboardItem1.FormatRules, cardDashboardItem1.Cards[0]);
            ////AddRulesToTheSecondCard(cardItem.FormatRules, cardItem.Cards[1]);
            //AddCommonRule(cardDashboardItem1.FormatRules, cardDashboardItem1.SeriesDimensions[0]);
            //AddRulesToTheFirstCard(cardDashboardItem1.FormatRules, card);
            AddCommonRule(cardDashboardItem1.FormatRules, cardDashboardItem1.SeriesDimensions);




        }


        private void formartChart(IDashboardDataSource dataSource)
        {




            chartDashboardItem1.DataSource = dataSource;

            // Specifies the dimension used to provide data for arguments on a chart.
            //chartDashboardItem1.Arguments.Add(new Dimension("number", DateTimeGroupInterval.Year));
            chartDashboardItem1.Arguments.Add(new Dimension("name"));

            // Specifies the dimension that provides data for chart series.
            chartDashboardItem1.SeriesDimensions.Add(new Dimension("name"));

            // Adds a new chart pane to the chart's Panes collection.
            chartDashboardItem1.Panes.Add(new ChartPane());
            // Creates a new series of the Bar type.
            SimpleSeries salesAmountSeries = new SimpleSeries(SimpleSeriesType.Bar);
            // Specifies the measure that provides data used to calculate
            // the Y-coordinate of data points.
            salesAmountSeries.Value = new Measure("number");
            // Adds created series to the pane's Series collection to display within this pane.
            chartDashboardItem1.Panes[0].Series.Add(salesAmountSeries);

            //chartDashboardItem1.Panes.Add(new ChartPane());
            //SimpleSeries taxesAmountSeries = new SimpleSeries(SimpleSeriesType.StackedBar);
            //taxesAmountSeries.Value = new Measure("CompanyName");
            //chartDashboardItem1.Panes[1].Series.Add(taxesAmountSeries);
        }

        #region pies相关
        private PieDashboardItem CreatePies(IDashboardDataSource dataSource)
        {
            PieDashboardItem pies = new PieDashboardItem();
            pies.DataSource = dataSource;
            pies.Values.Add(new Measure("CompanyName"));
            pies.Arguments.Add(new Dimension("Country"));
            pies.SeriesDimensions.Add(new Dimension("PostalCode"));
            return pies;
        }



        public static DashboardJsonDataSource CreateJsonDataSourceFromWeb()
        {
            var jsonDataSource = new DashboardJsonDataSource();
            jsonDataSource.JsonSource = new UriJsonSource(new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"));
            jsonDataSource.RootElement = "Customers";
            return jsonDataSource;
        }

        public static DashboardJsonDataSource CreateJsonDataSourceFromFile()
        {
            var jsonDataSource = new DashboardJsonDataSource();
            Uri fileUri = new Uri("customers.json", UriKind.RelativeOrAbsolute);
            jsonDataSource.JsonSource = new UriJsonSource(fileUri);
            jsonDataSource.RootElement = "Customers";
            return jsonDataSource;
        }


        public static DashboardJsonDataSource CreateJsonDataSourceFromString()
        {
            var jsonDataSource = new DashboardJsonDataSource();
            //string json = "{\"Customers\":[{\"Id\":\"ALFKI\",\"CompanyName\":\"Alfreds Futterkiste\",\"ContactName\":\"Maria Anders\",\"ContactTitle\":\"Sales Representative\",\"Address\":\"Obere Str. 57\",\"City\":\"Berlin\",\"PostalCode\":\"12209\",\"Country\":\"Germany\",\"Phone\":\"030-0074321\",\"Fax\":\"030-0076545\"}],\"ResponseStatus\":{}}";
            //string json = "{\"Customers\":[{\"Id\":\"1\",\"CompanyName\":\"aaaaa\",\"number\":1},{\"Id\":\"2\",\"CompanyName\":\"aaaaa2\",\"number\":2},{\"Id\":\"3\",\"CompanyName\":\"aaaaa3\",\"number\":3},{\"Id\":\"4\",\"CompanyName\":\"aaaaa4\",\"number\":4},{\"Id\":\"5\",\"CompanyName\":\"aaaaa5\",\"number\":5},{\"Id\":\"6\",\"CompanyName\":\"aaaaa6\",\"number\":6},{\"Id\":\"7\",\"CompanyName\":\"aaaaa7\",\"number\":7},{\"Id\":\"8\",\"CompanyName\":\"aaaaa8\",\"number\":8},{\"Id\":\"9\",\"CompanyName\":\"aaaaa9\",\"number\":9},{\"Id\":\"10\",\"CompanyName\":\"aaaaa10\",\"number\":10},{\"Id\":\"11\",\"CompanyName\":\"aaaaa11\",\"number\":11}],\"ResponseStatus\":{ }}";
            string json = "{\"Customers\":[{\"Id\":\"1\",\"CompanyName\":\"测试用户\",\"number\":1},{\"Id\":\"2\",\"CompanyName\":\"aaaaa2\",\"number\":2},{\"Id\":\"3\",\"CompanyName\":\"aaaaa3\",\"number\":3},{\"Id\":\"4\",\"CompanyName\":\"aaaaa4\",\"number\":4},{\"Id\":\"5\",\"CompanyName\":\"aaaaa5\",\"number\":5},{\"Id\":\"6\",\"CompanyName\":\"aaaaa6\",\"number\":6},{\"Id\":\"7\",\"CompanyName\":\"aaaaa7\",\"number\":7},{\"Id\":\"8\",\"CompanyName\":\"aaaaa8\",\"number\":8},{\"Id\":\"9\",\"CompanyName\":\"aaaaa9\",\"number\":9},{\"Id\":\"10\",\"CompanyName\":\"aaaaa10\",\"number\":10},{\"Id\":\"11\",\"CompanyName\":\"aaaaa11\",\"number\":11}],\"ResponseStatus\":{ }}";
            jsonDataSource.JsonSource = new CustomJsonSource(json);
            jsonDataSource.RootElement = "Customers";
            return jsonDataSource;
        }
        #endregion

        #region card 相关
        public void AddCommonRule(CardItemFormatRuleCollection formatRules, DimensionCollection dataItems)
        {
            foreach(DataItem dataItem in dataItems)
            {
                // Applies a light-green background color to cards whose actual value is equal to the set condition.
                CardItemFormatRule backColorStyleRule = new CardItemFormatRule(dataItem);
                backColorStyleRule.ApplyToLayoutElement = CardFormatRuleLayoutElement.ActualValue;
                FormatConditionValue valueCondition = new FormatConditionValue(DashboardFormatCondition.ContainsText, "a");

                valueCondition.StyleSettings = new AppearanceSettings(Color.LightGreen);
                backColorStyleRule.Condition = valueCondition;
                formatRules.Add(backColorStyleRule);
            }

        }
        //public void AddRulesToTheFirstCard(CardItemFormatRuleCollection formatRules, Card card)
        //{
        //    // Applies a predefined range of colors to cards.
        //    CardItemDeltaFormatRule gradientRule = new CardItemDeltaFormatRule();
        //    gradientRule.DeltaValueType = DeltaValueType.AbsoluteVariation;
        //    gradientRule.Card = card;
        //    var rangeCondition = new FormatConditionRangeGradient(FormatConditionRangeGradientPredefinedType.BlueWhiteGreen);
        //    gradientRule.Condition = rangeCondition;
        //    formatRules.Add(gradientRule);

        //    // Applies the bold dark-blue font style to the cards' actual value that is between the range of condition values.
        //    CardItemFormatRule fontStyleRule = new CardItemFormatRule();
        //    fontStyleRule.DataItem = card.ActualValue;
        //    fontStyleRule.ApplyToLayoutElement = CardFormatRuleLayoutElement.ActualValue;
        //    FormatConditionValue valueCondition = new FormatConditionValue(DashboardFormatCondition.Between, 0, 10);
        //    valueCondition.StyleSettings = new AppearanceSettings(Color.DarkBlue, FontStyle.Bold);
        //    fontStyleRule.Condition = valueCondition;
        //    formatRules.Add(fontStyleRule);

        //    // Applies full gray star icons to cards whose percentage variation value is greater than the set condition value.
        //    CardItemDeltaFormatRule iconRule = new CardItemDeltaFormatRule(card, DeltaValueType.PercentVariation, CardFormatRuleLayoutElement.Title);
        //    FormatConditionValue valueCondition2 = new FormatConditionValue(DashboardFormatCondition.Greater, 0.1);
        //    valueCondition2.StyleSettings = new IconSettings(FormatConditionIconType.RatingFullGrayStar);
        //    iconRule.Condition = valueCondition2;
        //    formatRules.Add(iconRule);
        //}
        //public void AddRulesToTheSecondCard(CardItemFormatRuleCollection formatRules, Card card)
        //{
        //    // Applies a predefined range of colors to cards.
        //    CardItemDeltaFormatRule rangeRule = new CardItemDeltaFormatRule();
        //    rangeRule.DeltaValueType = DeltaValueType.AbsoluteVariation;
        //    rangeRule.Card = card;
        //    var rangeCondition = new FormatConditionRangeSet(FormatConditionRangeSetPredefinedType.ColorsPaleRedOrangeYellowGreenBlue);
        //    rangeRule.Condition = rangeCondition;
        //    formatRules.Add(rangeRule);

        //    // Applies the underlined red font style to the title of cards whose absolute variation value is less than the condition value.
        //    CardItemDeltaFormatRule fontStyleUnderlinedRule = new CardItemDeltaFormatRule(card, DeltaValueType.AbsoluteVariation, CardFormatRuleLayoutElement.Title);
        //    FormatConditionValue valueCondition = new FormatConditionValue(DashboardFormatCondition.Less, 0);
        //    valueCondition.StyleSettings = new AppearanceSettings(Color.Red, FontStyle.Underline);
        //    fontStyleUnderlinedRule.Condition = valueCondition;
        //    formatRules.Add(fontStyleUnderlinedRule);

        //    // Applies the positive-negative icon range to cards.
        //    CardItemDeltaFormatRule deltaIconRule = new CardItemDeltaFormatRule(card, DeltaValueType.AbsoluteVariation, CardFormatRuleLayoutElement.Indicator);
        //    var iconRangeCondition = new FormatConditionRangeSet(FormatConditionRangeSetPredefinedType.PositiveNegative3);
        //    deltaIconRule.Condition = iconRangeCondition;
        //    formatRules.Add(deltaIconRule);
        //}

        //public DashboardExcelDataSource CreateExcelDataSource()
        //{
        //    // Generates the Excel Data Source.
        //    DashboardExcelDataSource excelDataSource = new DashboardExcelDataSource();
        //    excelDataSource.FileName = @"Data\Sales.xlsx";
        //    ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings("Sheet1", "A1:I4166");
        //    excelDataSource.SourceOptions = new ExcelSourceOptions(worksheetSettings);
        //    excelDataSource.Fill();

        //    return excelDataSource;
        //}

        #endregion
    }
}
