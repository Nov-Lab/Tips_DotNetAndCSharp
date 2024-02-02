// @(h)Tips_LocalFunction.cs ver 0.00 ( '24.02.02 Nov-Lab ) 作成開始
// @(h)Tips_LocalFunction.cs ver 0.51 ( '24.02.02 Nov-Lab ) ベータ版完成
// @(h)Tips_LocalFunction.cs ver 0.51a( '24.02.03 Nov-Lab ) その他  ：コメント整理

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;


namespace Tips_DotNetAndCSharp
{
    public partial class Tips
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【C#の機能：ローカル関数】<br></br>
        /// ・ローカル関数は、メソッドやプロパティーアクセサーなど、親メンバーの中に定義する内部メソッドです。<br></br>
        /// ・ローカル関数は、そのローカル関数が定義されている親メンバーからのみ呼び出すことができます。<br></br>
        /// ・そのため、無関係なメソッドから誤って呼び出してしまう心配がなく、親メンバーの内部で完結することができます。<br></br>
        /// ・ローカル関数は、親メンバーで宣言されているローカル変数を直接読み書きすることができます。<br></br>
        /// ・そのため、引数や戻り値を介さずに情報をやり取りすることができます。<br></br>
        /// </summary>
        //--------------------------------------------------------------------------------
        [TipsMethod("C#の機能：ローカル関数")]
        public static void Tips_LocalFunction()
        {
            //------------------------------------------------------------
            /// カルチャ情報を一覧表示する
            //------------------------------------------------------------
            int seqNo = 0;                                              //// 連番 = 0 に初期化する

            PrintCultureInfo(0x0409);                                   //// カルチャ情報表示処理を行う(en-US：英語)
            PrintCultureInfo(0x0411);                                   //// カルチャ情報表示処理を行う(ja-JP：日本語)
            PrintCultureInfo(0x040c);                                   //// カルチャ情報表示処理を行う(fr-FR：フランス語)
            PrintCultureInfo(0x0407);                                   //// カルチャ情報表示処理を行う(de-DE：ドイツ語)
            PrintCultureInfo(0x0410);                                   //// カルチャ情報表示処理を行う(it-IT：イタリア語)
            PrintCultureInfo(0x0c0a);                                   //// カルチャ情報表示処理を行う(es-ES：スペイン語)
            PrintCultureInfo(0x0804);                                   //// カルチャ情報表示処理を行う(zh-CN：簡体字中国語)
            PrintCultureInfo(0x0404);                                   //// カルチャ情報表示処理を行う(zh-TW：繁体字中国語)
            PrintCultureInfo(0x0412);                                   //// カルチャ情報表示処理を行う(ko-KR：韓国語)


            //------------------------------------------------------------
            /// 【ローカル関数】カルチャ情報表示
            //------------------------------------------------------------
            void PrintCultureInfo(int localeID) // [in ]：カルチャ識別子
            {
                seqNo++;                                                //// 連番をインクリメントする
                var cultureInfo = new CultureInfo(localeID);            //// 指定されたカルチャ識別子に対応するカルチャ情報を取得する
                Trace.WriteLine(                                        //// カルチャ情報を表示する
                    $"{seqNo:D2}:LCID=0x{localeID:X4}, カルチャ名={cultureInfo.Name}, 表示名={cultureInfo.DisplayName}");
            }


            // 【実行結果の出力例】
            // 01:LCID=0x0409, カルチャ名=en-US, 表示名=英語 (米国)
            // 02:LCID=0x0411, カルチャ名=ja-JP, 表示名=日本語 (日本)
            // 03:LCID=0x040C, カルチャ名=fr-FR, 表示名=フランス語 (フランス)
            // 04:LCID=0x0407, カルチャ名=de-DE, 表示名=ドイツ語 (ドイツ)
            // 05:LCID=0x0410, カルチャ名=it-IT, 表示名=イタリア語 (イタリア)
            // 06:LCID=0x0C0A, カルチャ名=es-ES, 表示名=スペイン語 (スペイン)
            // 07:LCID=0x0804, カルチャ名=zh-CN, 表示名=中国語 (簡体字、中国)
            // 08:LCID=0x0404, カルチャ名=zh-TW, 表示名=中国語 (繁体字、台湾)
            // 09:LCID=0x0412, カルチャ名=ko-KR, 表示名=韓国語 (韓国)
        }

    } // class

} // namespace
