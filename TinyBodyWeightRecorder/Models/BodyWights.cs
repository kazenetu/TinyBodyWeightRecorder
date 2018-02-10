using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
        /// <param name="fileName">ファイル名</param>
        /// <returns>保存結果</returns>
        public bool Save(string fileName)
        {
            // TODO 保存処理

            return false;
        }

        /// <summary>
        /// データ読み込み
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>読み込み結果</returns>
        public bool Load(string fileName)
        {
            // HACK 読み込み処理

            Items.Add(new BodyWight(DateTime.Parse("2018/02/05"), 55.4M));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/06"), 55.5M));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/07"), 55.6M));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/08"), 55.7M));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/01"), 55));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/02"), 55.1M));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/03"), 55.2M));
            Items.Add(new BodyWight(DateTime.Parse("2018/02/04"), 55.3M));


            return false;
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
