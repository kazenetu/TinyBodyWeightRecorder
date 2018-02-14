using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TinyBodyWeightRecorder.Models;

namespace TinyBodyWeightRecorder
{
    public partial class GraphView : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GraphView()
        {
            InitializeComponent();
        }

        #region イベント

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphView_Load(object sender, EventArgs e)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // 体重情報が存在しない場合は検索コントロールを無効にして終了
            if (!bodyWights.Any())
            {
                searchPanel.Enabled = false;
                return;
            }

            // 検索日付コントロールの設定
            targetDateFrom.Value = bodyWights.Min(item => item.WeighingDate).Date;
            targetDateTo.Value = bodyWights.Max(item => item.WeighingDate).Date;

            // 検索ボタンクリックイベント実行
            search.PerformClick();

            // 検索ボタンをアクティブに設定
            search.Focus();
        }

        /// <summary>
        /// 検索ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_Click(object sender, EventArgs e)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // 検索日付コントロールを日付情報を取得
            var targetFrom = targetDateFrom.Value.Date;
            var targetTo = targetDateTo.Value.Date;

            // グラフ表示
            drawGraph(targetFrom, targetTo);
        }

        #endregion

        #region プライベートメソッド

        /// <summary>
        /// グラフ表示
        /// </summary>
        /// <param name="targetFrom">検索対象の開始日付</param>
        /// <param name="targetTo">検索対象の終了日付</param>
        private void drawGraph(DateTime targetFrom, DateTime targetTo)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // 検索対象期間を取得
            var targetItems = bodyWights.Where(item => item.WeighingDate >= targetFrom && item.WeighingDate <= targetTo)?.OrderBy(item => item.WeighingDate);
            if (!targetItems.Any())
            {
                // ゼロ件の場合は終了
                return;
            }
            
            Series test = new Series();
            test.ChartType = SeriesChartType.Line;

            var points = test.Points;
            var year = 0;
            foreach (var item in targetItems)
            {
                var dateFormat = "MM/dd";
                if (year != item.WeighingDate.Year)
                {
                    dateFormat = "yyyy/" + dateFormat;
                    year = item.WeighingDate.Year;
                }

                points.AddXY(item.WeighingDate.ToString(dateFormat), item.Wight);
            }

            chart1.Series.Add(test);

            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = (double)targetItems.Min(item=>item.Wight)-1;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = (double)targetItems.Max(item => item.Wight)+1;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 0.5;
        }
    }

    #endregion
}
