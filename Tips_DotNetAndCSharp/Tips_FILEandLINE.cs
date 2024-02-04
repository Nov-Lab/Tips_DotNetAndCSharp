// @(h)Tips_FILEandLINE.cs ver 0.00 ( '24.02.04 Nov-Lab ) 作成開始
// @(h)Tips_FILEandLINE.cs ver 0.51 ( '24.02.04 Nov-Lab ) ベータ版完成

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace Tips_DotNetAndCSharp
{
    public partial class Tips
    {
        // ＜メモ＞
        // ・NovLab.Base クラスライブラリに、FILEandLINE というユーティリティークラスを用意してあります。
        //====================================================================================================
        /// <summary>
        /// 【.NET Framework の機能：C言語/C++の事前定義済みマクロ __FILE__ や __LINE__ に相当する情報を取得する方法】<br></br>
        /// .NET Framework 4.5 以降では、<see cref="System.Runtime.CompilerServices"/> 名前空間で定義されている
        /// 呼び出し元情報の属性を利用することで、各種情報を取得できます。<br></br>
        /// <code>
        /// ・__FILE__  ：<see cref="CallerFilePathAttribute"/> を利用したメソッドを用意することで取得できます。
        /// ・__LINE__  ：<see cref="CallerLineNumberAttribute"/> を利用したメソッドを用意することで取得できます。
        /// ・メンバー名：<see cref="CallerMemberNameAttribute"/> を利用したメソッドを用意することで取得できます。
        /// </code>
        /// .NET Framework 4.0以前でも <see cref="StackFrame"/> クラスで取得できますが、*.pdb ファイルがないとソースファイル名と行番号は取得できません。<br></br>
        /// <br></br>
        /// また、クラス名とメンバー名だけであれば、より簡単な方法で取得できます。<br></br>
        /// <code>
        /// ・クラス名  ：<see cref="MethodBase.GetCurrentMethod"/>.ReflectedType.Name で取得できます。
        /// ・メンバー名：<see cref="MethodBase.GetCurrentMethod"/>.Name で取得できます。
        /// </code>
        /// </summary>
        /// <remarks>
        /// 注意事項<br></br>
        /// ・<see cref="CallerFilePathAttribute"/> を使用すると、バイナリーファイルの中にフルパスソースファイル名が含まれますのでご注意ください。<br></br>
        /// </remarks>
        //====================================================================================================
        [TipsMethod(".NET Framework の機能：C言語/C++の事前定義済みマクロ __FILE__ や __LINE__ に相当する情報を取得する方法")]
        public static void Tips_FILEandLINE()
        {
            // ＜メモ＞
            // ・メソッドのレスポンス測定をしているイメージのサンプルです。
            var timeOfProcess = Stopwatch.StartNew();
            TraceLog("処理開始");

            TraceLog("電文受信(予約要求)"); Thread.Sleep(20);
            TraceLog("トランザクション開始"); Thread.Sleep(20);
            TraceLog("予約要求情報読み込み"); Thread.Sleep(60);
            TraceLog("在庫引き当て"); Thread.Sleep(240);
            TraceLog("予約台帳更新"); Thread.Sleep(120);
            TraceLog("トランザクションコミット"); Thread.Sleep(80);
            TraceLog("電文送信(処理結果)"); Thread.Sleep(20);

            timeOfProcess.Stop();
            TraceLog($"処理終了({timeOfProcess.Elapsed})");


            // 【実行結果の出力例】
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:47] : 処理開始
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:49] : 電文受信(予約要求)
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:50] : トランザクション開始
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:51] : 予約要求情報読み込み
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:52] : 在庫引き当て
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:53] : 予約台帳更新
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:54] : トランザクションコミット
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:55] : 電文送信(処理結果)
            // Tips.Tips_FILEandLINE() in Tips_FILEandLINE.cs[line:58] : 処理終了(00:00:00.6390854)
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【トレースログ出力】
        /// </summary>
        /// <param name="message">         [in ]：メッセージ文字列</param>
        /// <param name="memberName">      [in ]：省略してください。</param>
        /// <param name="sourceFilePath">  [in ]：省略してください。</param>
        /// <param name="sourceLineNumber">[in ]：省略してください。</param>
        /// <remarks>
        /// 注意事項<br></br>
        /// ・このメソッドを使用すると、バイナリーファイルの中にフルパスソースファイル名が含まれますのでご注意ください。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void TraceLog(string message,
                                    [CallerMemberName] string memberName = "",
                                    [CallerFilePath] string sourceFilePath = "",
                                    [CallerLineNumber] int sourceLineNumber = 0)
        {
            var className = MethodBase.GetCurrentMethod().ReflectedType.Name;
            var sourceFileName = System.IO.Path.GetFileName(sourceFilePath);

            Trace.WriteLine(string.Format($"{className}.{memberName}()" +
                                          $" in {sourceFileName}[line:{sourceLineNumber}]" +
                                          $" : {message}"));
        }

    } // class

} // namespace
