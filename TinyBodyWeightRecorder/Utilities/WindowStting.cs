using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace TinyBodyWeightRecorder.Utilities
{
    /// <summary>
    /// Window設定クラス
    /// </summary>
    public class WindowStting
    {
        #region 定数

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string SettingFileName = "setting.json";

        #endregion

        #region クラスメソッド

        /// <summary>
        /// 対象フォームの設定ファイル保存
        /// </summary>
        /// <param name="targetForm">対象フォーム</param>
        public static void Save(Form targetForm)
        {
            var settings = new Dictionary<string, string>();

            // 設定データを設定
            var formType = targetForm.GetType();
            foreach (var key in getSettingKeys(targetForm))
            {
                var value = formType.GetProperty(key)?.GetValue(targetForm);

                if(value != null)
                {
                    settings.Add(key, value.ToString());
                }
            }

            // 設定ファイルを作成
            using (var fs = new StreamWriter(SettingFileName, false))
            {
                var sw = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
                sw.WriteObject(fs.BaseStream, settings);
            }
        }

        /// <summary>
        /// 設定ファイルを対象フォームに設定
        /// </summary>
        /// <param name="targetForm">対象フォーム</param>
        public static void Load(Form targetForm)
        {
            // 設定ファイルの確認
            if (!File.Exists(SettingFileName))
            {
                return;
            }

            Dictionary<string, string> settings = null;

            // 設定ファイルの読み込み
            using (var fs = new StreamReader(SettingFileName, false))
            {
                var sw = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
                settings = sw.ReadObject(fs.BaseStream) as Dictionary<string, string>;
            }

            // 対象フォームの値を設定
            var formType = targetForm.GetType();
            foreach (var key in getSettingKeys(targetForm))
            {
                if (settings.ContainsKey(key))
                {
                    var property = formType.GetProperty(key);
                    var propertyType = property.PropertyType;

                    var value = Convert.ChangeType(settings[key], propertyType);
                    formType.GetProperty(key)?.SetValue(targetForm,value);
                }
            }
        }
        #endregion

        #region プライベートクラスメソッド

        /// <summary>
        /// 保存対象のキー名を取得
        /// </summary>
        /// <param name="targetForm">対象フォーム</param>
        /// <returns>キーリスト</returns>
        private static List<string> getSettingKeys(Form targetForm)
        {
            var result = new List<string>();

            result.Add(nameof(targetForm.Height));
            result.Add(nameof(targetForm.Left));
            result.Add(nameof(targetForm.Top));

            return result;
        }

        #endregion

    }
}
