// @(h)Tips_StringInterpolation.cs ver 0.00 ( '24.02.02 Nov-Lab ) 作成開始
// @(h)Tips_StringInterpolation.cs ver 0.51 ( '24.02.02 Nov-Lab ) ベータ版完成
// @(h)Tips_StringInterpolation.cs ver 0.51b( '24.04.27 Nov-Lab ) その他  ：コメント整理

using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace Tips_DotNetAndCSharp
{
    public partial class Tips
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【C#の機能：$-補完文字列を用いた文字列の書き入れ】<br/>
        /// ・文字列リテラル内で書式設定対象オブジェクトや書式指定文字列を直接指定して、
        ///   変数などの内容を書き入れることができます。<br/>
        /// </summary>
        //--------------------------------------------------------------------------------
        [TipsMethod("C#の機能：$-補完文字列を用いた文字列の書き入れ")]
        public static void Tips_StringInterpolation()
        {
            DateTime date = new DateTime(2023, 5, 27);  // 日付
            string cityName = "千葉市";                 // 都市名
            float maxTemperature = 19.5F;               // 最高気温(値はダミー)


            // 文字列を連結する方法
            Trace.WriteLine(date.ToLongDateString() + "の" + cityName + "の最高気温は" + maxTemperature.ToString("N0") + "℃です。");

            // 書式指定文字列を用いて文字列を埋め込む方法
            Trace.WriteLine(string.Format("{0:D}の{1}の最高気温は{2:N0}℃です。", date, cityName, maxTemperature));

            // $-補完文字列を用いて文字列を書き入れる方法
            Trace.WriteLine($"{date:D}の{cityName}の最高気温は{maxTemperature:N0}℃です。");


            // 【実行結果の出力例】どの方法でも実行結果は同じです。
            // 2023年5月27日の千葉市の最高気温は20℃です。
        }

    } // class

} // namespace
