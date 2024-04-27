// @(h)Tips_MethodAutoDetectByAttribute.cs ver 0.00 ( '24.02.02 Nov-Lab ) 作成開始
// @(h)Tips_MethodAutoDetectByAttribute.cs ver 0.51 ( '24.02.02 Nov-Lab ) ベータ版完成
// @(h)Tips_MethodAutoDetectByAttribute.cs ver 0.52 ( '24.02.03 Nov-Lab ) 機能追加：ソート機能を追加した
// @(h)Tips_MethodAutoDetectByAttribute.cs ver 0.52a( '24.04.27 Nov-Lab ) その他  ：コメント整理

using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace Tips_DotNetAndCSharp
{
    //====================================================================================================
    /// <summary>
    /// 【.NET Framework の小技：目印属性クラスによるメソッドの自動検出】<br/>
    /// ・属性クラスで目印をつけておくことで、特定目的のメソッドを自動的に検出できるようにする小技です。<br/>
    /// ・こうすることで、新しいメソッドを追加したときに、既存部分を修正しなくても自動的に検出させることができます。<br/>
    /// ・このプロジェクトの場合、Tipsのサンプルメソッドに <see cref="TipsMethodAttribute"/> 属性をつけています。<br/>
    /// ・<see cref="TipsMethodAttribute"/> 属性をつけたメソッドは、メインフォームのTips一覧リストへ自動的に追加されます。<br/>
    /// </summary>
    //====================================================================================================
    public class About_TipsMethodAttribute { }


    //====================================================================================================
    /// <summary>
    /// 【Tipメソッド属性】
    /// メソッドをTipsのサンプルメソッドとしてマークし、メイン画面が自動的に認識できるようにします。
    /// </summary>
    /// <remarks>
    /// 補足<br/>
    /// ・この属性を付加するメソッドは <see cref="Action"/> デリゲートに合致していなければなりません。<br/>
    /// </remarks>
    //====================================================================================================
    [AttributeUsage(AttributeTargets.Method)]   // 属性適用対象 = メソッド
    public partial class TipsMethodAttribute : Attribute
    {
        //====================================================================================================
        // 公開フィールド
        //====================================================================================================
        /// <summary>
        /// 【Tipメソッド表示名(読み取り専用)】Tipメソッドの表示名です。
        /// </summary>
        public readonly string displayName;


        //====================================================================================================
        // コンストラクター・公開プロパティー
        //====================================================================================================
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【Tipメソッド属性】
        /// メソッドをTipsのサンプルメソッドとしてマークし、メイン画面が自動的に認識できるようにします。
        /// </summary>
        /// <param name="displayName">[in ]：Tipメソッド表示名</param>
        /// <remarks>
        /// 補足<br/>
        /// ・この属性を付加するメソッドは <see cref="Action"/> デリゲートに合致していなければなりません。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public TipsMethodAttribute(string displayName)
        {
            this.displayName = displayName;
        }


        //====================================================================================================
        // static公開メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【Tipsメソッド情報収集】読み込み済みアセンブリから、Tipsメソッドを検索・収集します。
        /// </summary>
        /// <returns>
        /// Tipsメソッド情報配列
        /// </returns>
        //--------------------------------------------------------------------------------
        public static TipsMethodInfo[] CollectInfo()
        {
            //------------------------------------------------------------
            /// Tipsメソッドを検索・収集する
            //------------------------------------------------------------
            var tipsMethodInfos = new List<TipsMethodInfo>();           //// Tipsメソッド情報リストを生成する

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {                                                           //// 読み込み済みアセンブリを繰り返す
                foreach (var typeInfo in assembly.GetTypes())
                {                                                       /////  アセンブリ内の型情報を繰り返す
                    foreach (var methodInfo in typeInfo.GetMethods())
                    {                                                   //////   メソッド情報を繰り返す
                        var attributes =                                ///////    Tipsメソッド属性の配列を取得する
                            methodInfo.GetCustomAttributes(typeof(TipsMethodAttribute), false);
                        foreach (TipsMethodAttribute tmpAttr in attributes)
                        {                                               ///////    Tipsメソッド属性配列を繰り返す(シングルユース属性なので実際は１つだけ取得可能なはず)
                            var actTipsMethod =                         ////////     メソッド情報から、TipsメソッドのActionデリゲートインスタンスを生成する
                                (Action)Delegate.CreateDelegate(
                                        typeof(Action), methodInfo);

                            tipsMethodInfos.Add(                        ////////     Tipsメソッド情報を生成してリストへ追加する
                                new TipsMethodInfo(tmpAttr, actTipsMethod));
                        }
                    }
                }
            }
            tipsMethodInfos.Sort();                                     //// Tipsメソッド情報リストをソートする

            return tipsMethodInfos.ToArray();                           //// 戻り値 = Tipsメソッド情報リストから生成した配列 で関数終了
        }

    } // class


    //====================================================================================================
    /// <summary>
    /// 【Tipsメソッド情報】Tipsメソッドを扱うための情報をひとまとめに管理します。
    /// </summary>
    //====================================================================================================
    public partial class TipsMethodInfo : IComparable<TipsMethodInfo>   // List<T>.Sort に必要
    {
        //====================================================================================================
        // 公開フィールド
        //====================================================================================================
        /// <summary>
        /// 【Tipsメソッド属性】
        /// </summary>
        public readonly TipsMethodAttribute tipsMethodAttribute;

        /// <summary>
        /// 【TipsメソッドのActionデリゲートインスタンス】
        /// </summary>
        public readonly Action actTipsMethod;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【文字列化】Tipメソッドの表示名を取得します。リストボックスでの一行表示に使用します。
        /// </summary>
        /// <returns>文字列形式(Tipメソッドの表示名)</returns>
        //--------------------------------------------------------------------------------
        public override string ToString() => tipsMethodAttribute.displayName;


        //====================================================================================================
        // 公開プロパティー
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【Tipsメソッド表示名】Tipメソッドの表示名を取得します。
        /// </summary>
        /// <remarks>
        /// 補足<br/>
        /// ・tipsMethodAttribute.displayName のショートカットです。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public string DisplayName { get => tipsMethodAttribute.displayName; }


        //====================================================================================================
        // IComparable I/F の実装
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【比較】他のインスタンスと内容を比較します。Tipメソッド表示名で比較します。
        /// </summary>
        /// <param name="other">[in ]：比較相手</param>
        /// <returns>
        /// 比較結果値[0より小さい = 比較相手よりも小さい、0 = 比較相手と等しい、0より大きい = 比較相手よりも大きい]
        /// </returns>
        /// <remarks>
        /// 補足<br/>
        /// ・<see cref="IComparable{T}.CompareTo(T)"/> の実装です。ソート処理に使用します。
        /// </remarks>
        //--------------------------------------------------------------------------------
        public int CompareTo(TipsMethodInfo other) => this.DisplayName.CompareTo(other.DisplayName);


        //====================================================================================================
        // コンストラクター
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【完全コンストラクター】すべての情報を指定してTipsメソッド情報を生成します。
        /// </summary>
        /// <param name="tipsMethodAttribute">[in ]：Tipsメソッド属性</param>
        /// <param name="actTipsMethod">      [in ]：TipsメソッドのActionデリゲートインスタンス</param>
        //--------------------------------------------------------------------------------
        public TipsMethodInfo(TipsMethodAttribute tipsMethodAttribute, Action actTipsMethod)
        {
            this.tipsMethodAttribute = tipsMethodAttribute;
            this.actTipsMethod = actTipsMethod;
        }

    } // class

} // namespace
