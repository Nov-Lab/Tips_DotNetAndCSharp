// @(h)AppBase_Tips.cs ver 0.00 ( '24.02.02 Nov-Lab ) 作成開始
// @(h)AppBase_Tips.cs ver 0.51 ( '24.02.02 Nov-Lab ) ベータ版完成
// @(h)AppBase_Tips.cs ver 0.52 ( '24.04.27 Nov-Lab ) 機能追加：トレースリスナーにインデント機能を追加した。

// @(s)
// 　【アプリケーション基本部】Tipsアプリケーションの基本部分や共通部分を管理します。

using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace Tips_DotNetAndCSharp
{
    //====================================================================================================
    /// <summary>
    /// 【アプリケーション基本部】Tipsアプリケーションの基本部分や共通部分を管理します。
    /// </summary>
    //====================================================================================================
    public partial class AppBase
    {
        //====================================================================================================
        // グローバル変数
        //====================================================================================================
        /// <summary>
        /// 【メインフォームのインスタンス】
        /// </summary>
        public static FrmAppTips MainForm { get; protected set; }


        //====================================================================================================
        // static内部フィールド
        //====================================================================================================
        /// <summary>
        /// 【トレースリスナー】
        /// </summary>
        protected static MyTraceListener m_myTraceListener = new MyTraceListener();


        //====================================================================================================
        // static公開メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【アプリケーション初期化】アプリケーションを初期化します。
        /// </summary>
        /// <param name="mainForm">[in ]：メインフォームのインスタンス</param>
        //--------------------------------------------------------------------------------
        public static void Initialize(FrmAppTips mainForm)
        {
            //------------------------------------------------------------
            /// アプリケーションを初期化する
            //------------------------------------------------------------
            MainForm = mainForm;                                        //// メインフォームのインスタンスをグローバル変数に設定する
            Trace.Listeners.Add(m_myTraceListener);                     //// トレースリスナーを登録する
        }

    } // class


    //====================================================================================================
    /// <summary>
    /// 【トレースリスナー】トレース出力やデバッグ出力をメイン画面に転送するトレースリスナー機能を提供します。
    /// </summary>
    //====================================================================================================
    public partial class MyTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            message = M_AppendIndent(message);
            AppBase.MainForm.AddOutput(message);
        }

        public override void WriteLine(string message)
        {
            message = M_AppendIndent(message);
            AppBase.MainForm.AddOutput(message);
        }

        protected string M_AppendIndent(string message)
        {
            for(int ctrTmp = 0; ctrTmp < IndentLevel; ctrTmp++)
            {
                message = "  " + message;
            }
            return message;
        }

    } // class

} // namespace
