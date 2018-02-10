﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyBodyWeightRecorder.Models;

namespace TinyBodyWeightRecorder
{
    public partial class Main : Form
    {
        private const string DefaultFileName = "data.json";

        public Main()
        {
            InitializeComponent();
        }

        #region "イベント"

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // データ読み込み
            bodyWights.Load(DefaultFileName);

            // 入力コントロールの初期化
            clerInputControl();

            // グリッドバインド
            recordData.DataSource = bodyWights;
            recordData.Sort(recordData.Columns[0], ListSortDirection.Descending);

            recordData.CellValidating += (s,args) =>
            {
                if(args.ColumnIndex == 1)
                {
                    var temp = 0M;
                    if(! Decimal.TryParse(args.FormattedValue.ToString(),out temp))
                    {
                        recordData.CancelEdit();
                    }
                }
            };
        }

        /// <summary>
        /// 体重情報の追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // 日付コントロールの値
            var inputDate = dateTimePicker.Value.Date;

            // 日付がすでに登録されている場合はそのまま終了
            if (bodyWights.Where((item) => item.WeighingDate.Date == inputDate).Any())
            {
                return;
            }

            // 体重が0以下の場合はそのまま終了
            if (bodyWight.Value <= 0M)
            {
                return;
            }

            // 体重情報を追加
            bodyWights.Add(new BodyWight(inputDate, bodyWight.Value));
            recordData.Sort(recordData.Columns[0], ListSortDirection.Descending);
        }

        /// <summary>
        /// ファイル保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSaveFile_Click(object sender, EventArgs e)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // データ保存
            bodyWights.Save(DefaultFileName);
        }

        #endregion

        #region "プライベートメソッド"

        /// <summary>
        /// 入力コントロールのクリア
        /// </summary>
        private void clerInputControl()
        {
            var bodyWights = BodyWights.GetInstance();

            dateTimePicker.Value = DateTime.Now.Date;
            bodyWight.Value = 0M;

            // 最終登録日の体重を設定する
            if (bodyWights.Any())
            {
                bodyWight.Value = bodyWights.OrderByDescending(item => item.WeighingDate).First().Wight;
            }
        }

        #endregion
    }
}
