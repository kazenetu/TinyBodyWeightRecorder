using System;

namespace TinyBodyWeightRecorder.Models
{
    /// <summary>
    /// 体重情報
    /// </summary>
    public class BodyWight
    {
        #region プロパティ

        /// <summary>
        /// 計量日
        /// </summary>
        public DateTime WeighingDate { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Wight { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="weighingDate">計量日</param>
        /// <param name="wight">体重</param>
        public BodyWight(DateTime weighingDate, decimal wight)
        {
            WeighingDate = weighingDate;
            Wight = wight;
        }

        #endregion
    }
}
