using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace TinyBodyWeightRecorder.Models
{
    /// <summary>
    /// 体重情報コレクション
    /// </summary>
    /// <remarks>シングルトン</remarks>
    public class BodyWights : BindingList<BodyWight>
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static BodyWights instance = null;

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>シングルトンのためプライベートメソッド</remarks>
        private  BodyWights()
        {
        }

        #endregion

        #region メソッド

        /// <summary>
        /// データ保存
        /// </summary>
        /// <param name="filPath">ファイルパス</param>
        /// <returns>保存結果</returns>
        public bool Save(string filPath)
        {
            // 保存処理
            using (var fs = new StreamWriter(filPath, false))
            {
                foreach (var item in Items)
                {
                    fs.WriteLine(string.Format("{0},{1}",item.WeighingDate,item.Wight));
                }
            }

            return true;
        }

        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="filPath">ファイルパス</param>
        /// <returns>読み込み結果</returns>
        public bool Load(string filPath)
        {
            // ファイルの存在確認
            if (!File.Exists(filPath))
            {
                return false;
            }

            // 読み込み処理
            using (var fs = new StreamReader(filPath))
            {
                DateTime inputDate;
                decimal inputWeght;

                while (!fs.EndOfStream)
                {
                    // 一行を読み込み
                    var values = fs.ReadLine().Split(',');

                    // カンマ区切りで2カラム以上、DateTimeとdecimalの場合はアイテム追加
                    if (values.Length >= 2
                         && DateTime.TryParse(values[0], out inputDate)
                         && decimal.TryParse(values[1], out inputWeght))
                    {
                        Items.Add(new BodyWight(inputDate,inputWeght));
                    }
                }
            }

            return true;
        }

        #endregion

        #region クラスメソッド

        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns>インスタンス</returns>
        public static BodyWights GetInstance()
        {
            if(instance == null)
            {
                instance = new BodyWights();
            }
            return instance;
        }

        #endregion

        #region BindingList用処理

        /// <summary>
        /// ソート済みか否か
        /// </summary>
        private bool isSorted = false;

        /// <summary>
        /// リストがソートをサポートしているかどうかを示す値を取得します。
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        /// <summary>
        /// リストがソートされたか否か
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return this.isSorted; }
        }

        /// <summary>
        /// ソートされたリストの並べ替え操作の方向を取得します。
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return ListSortDirection.Descending; }
        }

        /// <summary>
        /// 指定されたプロパティおよび方向でのソート
        /// </summary>
        /// <param name="prop">抽象化プロパティ</param>
        /// <param name="direction">並べ替え操作の方向</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            // ソートを行うリストを取得
            var list = Items as List<BodyWight>;
            if (list == null)
            {
                return;
            }

            // ソート処理
            list.Sort((leftItem, rightItem) =>
            {
                if (leftItem == null && rightItem == null) return 0;
                if (leftItem == null) return -1;
                if (rightItem == null) return 1;
                return -leftItem.WeighingDate.CompareTo(rightItem.WeighingDate);
            });

            // ソート完了
            isSorted = true;

            // ListChanged イベントの発生
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        #endregion
    }
}
