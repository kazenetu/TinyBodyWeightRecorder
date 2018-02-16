using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TinyBodyWeightRecorder.Models;
using TinyBodyWeightRecorder.Utilities;

namespace TinyBodyWeightRecorder
{
    public partial class Main : Form
    {
        #region 定数

        /// <summary>
        /// ファイル名の初期値
        /// </summary>
        private const string DefaultFileName = "data.txt";

        #endregion

        #region プロパティ

        /// <summary>
        /// 自動保存
        /// </summary>
        public bool AutoSave
        {
            set
            {
                toolStripMenuItemAutoSave.Checked = value;
            }
            get
            {
                return toolStripMenuItemAutoSave.Checked;
            }
        }

        #endregion

        public Main()
        {
            InitializeComponent();
        }

        #region イベント

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            // 設定ファイルの読み込み・設定
            WindowStting.Load(this);

            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            // データ読み込み
            bodyWights.Load(DefaultFileName);

            // 入力コントロールの初期化
            clerInputControl();

            // グリッドバインド
            recordData.DataSource = bodyWights;
            recordData.Sort(recordData.Columns[0], ListSortDirection.Descending);

            // グリッドのセル編集後の入力チェック
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

            // 自動保存
            if (AutoSave)
            {
                bodyWights.Save(DefaultFileName);
            }
        }

        /// <summary>
        /// 体重入力コントロールのキーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bodyWight_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                add.PerformClick();
            }
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

        /// <summary>
        /// グラフ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemGraph_Click(object sender, EventArgs e)
        {
            using(var window = new  GraphView())
            {
                window.ShowDialog();
            }
        }

        /// <summary>
        /// メニュー：自動保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAutoSave_Click(object sender, EventArgs e)
        {
            // ON/OFFを切り替える
            toolStripMenuItemAutoSave.Checked = !toolStripMenuItemAutoSave.Checked;
        }

        /// <summary>
        /// 閉じる直前イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 体重情報コレクションクラスを取得
            var bodyWights = BodyWights.GetInstance();

            if (!bodyWights.Saved)
            {
                // 保存確認
                var result = MessageBox.Show("保存しますか？", "編集されています", MessageBoxButtons.YesNoCancel);

                // 選択内容ごとの処理
                switch (result)
                {
                    case DialogResult.Yes:
                        bodyWights.Save(DefaultFileName);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                }
            }

            // 設定ファイルを作成
            WindowStting.Save(this);
        }

        #region グリッドイベント

        /// <summary>
        /// セル変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recordData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 自動保存
            if (AutoSave)
            {
                BodyWights.GetInstance().Save(DefaultFileName);
            }
        }

        /// <summary>
        /// グリッドでマウスダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recordData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // 右クリックの場合はその行を選択しコンテキストメニュー表示に備える
            if (e.Button == MouseButtons.Right)
            {
                recordData.CurrentCell = recordData.Rows[e.RowIndex].Cells[0];
                recordData.Rows[e.RowIndex].Selected = true;
            }
        }

        /// <summary>
        ///  グリッド用コンテキストメニュー：削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextRowRemove_Click(object sender, EventArgs e)
        {
            // 選択行の日付情報を取得
            var targetDate = DateTime.Parse(recordData.CurrentRow.Cells[0].Value.ToString()).ToShortDateString();

            // 確認ダイアログを表示
            var result = MessageBox.Show(string.Format("{0}を削除しますか？", targetDate), "削除の確認", MessageBoxButtons.YesNo);

            // 選択内容ごとの処理
            switch (result)
            {
                case DialogResult.Yes:
                    // 選択行の削除
                    recordData.Rows.Remove(recordData.CurrentRow);

                    // 自動保存
                    if (AutoSave)
                    {
                        BodyWights.GetInstance().Save(DefaultFileName);
                    }
                    break;
            }
        }
        #endregion

        #endregion

        #region プライベートメソッド

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
