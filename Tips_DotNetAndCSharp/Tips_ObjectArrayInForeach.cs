// @(h)Tips_ObjectArrayInForeach.cs ver 0.00 ( '24.02.02 Nov-Lab ) 作成開始
// @(h)Tips_ObjectArrayInForeach.cs ver 0.51 ( '24.02.02 Nov-Lab ) ベータ版完成
// @(h)Tips_ObjectArrayInForeach.cs ver 0.51b( '24.04.27 Nov-Lab ) その他  ：コメント整理

using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace Tips_DotNetAndCSharp
{
    public partial class Tips
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【C#の小技：foreach 構文で、派生型の要素が格納された基本型配列を変換しながら扱う方法】<br/>
        /// ・ジェネリックの概念は .NET Framework 2.0 で追加されました。<br/>
        /// ・そのため、型を指定して配列を取得するメソッドのうち、.NET Framework 1.0 から存在するものなどは、
        ///   「派生型の配列」ではなく、「派生型の要素が格納された基本型配列」を返します。<br/>
        /// ・そのような配列を扱う場合は、配列に格納された個々の要素を派生型に変換してから扱うことになります。<br/>
        /// ・このとき、foreach 構文の中で、foreach (＜派生型の型名＞ ＜変数名＞ in ＜配列＞) のようにすることで、
        ///   個々の要素を変換しながら繰り返し処理を行うことができます。<br/>
        /// <br/>
        /// ＜派生型の要素が格納された基本型配列を返すメソッドの一例＞<br/>
        /// ・<see cref="Attribute.GetCustomAttributes(System.Reflection.MemberInfo, Type)"/><br/>
        /// ・<see cref="Type.FindMembers(System.Reflection.MemberTypes, System.Reflection.BindingFlags, System.Reflection.MemberFilter, object)"/><br/>
        /// </summary>
        //--------------------------------------------------------------------------------
        [TipsMethod("C#の小技：foreach 構文で、派生型の要素が格納された基本型配列を変換しながら扱う方法")]
        public static void Tips_ObjectArrayInForeach()
        {
            //------------------------------------------------------------
            /// 国番号と国名を一覧表示する
            //------------------------------------------------------------
            // ＜メモ＞
            // ・foreach 構文の中で、配列に格納された個々の要素を派生型に変換することができます
            Trace.WriteLine("＜小技を使った場合＞");
            {
                var objs = GetCountryCodeAndName();
                foreach (Tuple<int, string> tmpTuple in objs)       // foreach 構文の中で、個々の要素を変換しながら繰り返し処理を行う
                {
                    PrintCountryCodeAndName(tmpTuple);
                }
            }

            // ＜メモ＞
            // ・小技を使わない場合、変数と変換処理が１つ増えて、変換前変数と変換後変数の混同にも注意が必要となります
            Trace.WriteLine("");
            Trace.WriteLine("＜小技を使わない場合＞");
            {
                var objs = GetCountryCodeAndName();
                foreach (var tmpItem in objs)
                {
                    var tmpTuple = (Tuple<int, string>)tmpItem;     // foreach ブロック内で個々の要素を変換する
                    PrintCountryCodeAndName(tmpTuple);
                }
            }

            // ＜参考メモ＞
            // ・必要な場合は、Array.CopyTo で配列を丸ごと変換する方法も使えます
            Trace.WriteLine("");
            Trace.WriteLine("＜Array.CopyTo で配列を丸ごと変換した場合＞");
            {
                var objs = GetCountryCodeAndName();
                var tuples = new Tuple<int, string>[objs.Length];   // 変換先配列を生成する
                objs.CopyTo(tuples, 0);                             // 配列をコピーする(個々の要素について自動的に型キャストが行われる)
                foreach (var tmpTuple in tuples)
                {
                    PrintCountryCodeAndName(tmpTuple);
                }
            }

            // ＜参考メモ＞
            // ・「派生型の要素が格納された基本型配列」を「派生型の配列」にキャストすることはできません。
#if false
            Tuple<int, string>[] tuples = (Tuple<int, string>[])GetCountryCodeAndName();    // 実行時にキャスト失敗例外
            foreach (var tmpTuple in tuples)
            {
                PrintCountryCodeAndName(tmpTuple);
            }
#endif


            //------------------------------------------------------------
            /// 【ローカル関数】Tuple＜int, string＞ の要素が格納されたobject配列を返す関数例
            //------------------------------------------------------------
            object[] GetCountryCodeAndName()
            {
                List<object> objList = new List<object>
                {
                    new Tuple<int, string>(1, "アメリカ"),
                    new Tuple<int, string>(33, "フランス"),
                    new Tuple<int, string>(49, "ドイツ"),
                    new Tuple<int, string>(81, "日本"),
                    new Tuple<int, string>(358, "フィンランド"),
                };

                return objList.ToArray();
            }


            //------------------------------------------------------------
            /// 【ローカル関数】国番号と国名を表示
            //------------------------------------------------------------
            void PrintCountryCodeAndName(Tuple<int, string> info)   // [in ]：Tuple(＜国番号＞, ＜国名＞)
            {
                Trace.WriteLine($"国際電話の国番号 +{info.Item1} は {info.Item2}");
            }


            // 【実行結果の出力例】小技を使った場合も、使わなかった場合も、実行結果は同じです。
            // 国際電話の国番号 +1 は アメリカ
            // 国際電話の国番号 +33 は フランス
            // 国際電話の国番号 +49 は ドイツ
            // 国際電話の国番号 +81 は 日本
            // 国際電話の国番号 +358 は フィンランド
        }

    } // class

} // namespace
