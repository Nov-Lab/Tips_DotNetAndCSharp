// @(h)Tips_Using_NonNested.cs ver 0.00 ( '24.04.27 Nov-Lab ) プロトタイプを元に作成開始
// @(h)Tips_Using_NonNested.cs ver 0.51 ( '24.04.27 Nov-Lab ) ベータ版完成

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;


namespace Tips_DotNetAndCSharp
{
    public partial class Tips
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【C#の小技：using ステートメントが複数連続するときの非ネスト記述】<br/>
        /// ・using ステートメントが複数連続するときは、入れ子にせずに同階層へ並べて書くことができます。<br/>
        /// ・直前の using ステートメントで生成したオブジェクトを参照することもできます。<br/>
        /// </summary>
        //--------------------------------------------------------------------------------
        [TipsMethod("C#の小技：using ステートメントが複数連続するときの非ネスト記述 ①入れ子にせずに同階層へ並べて書いた場合")]
        public static void Using_NonNestedDescription()
        {
            //------------------------------------------------------------
            /// 連続する複数の using ステートメントを、入れ子にせずに同階層へ並べて書いたサンプル
            //------------------------------------------------------------
            Trace.WriteLine("using 開始前");

            using (var catMeat = new ItemCategoryInfo("肉類"))          //// using：アイテム分類情報(肉類)を生成する
            using (var catFruits = new ItemCategoryInfo("果物"))        //// using：アイテム分類情報(果物)を生成する
            using (var itemBeef = new ItemInfo(catMeat, "牛肉"))        //// using：アイテム情報(牛肉)を生成する
            using (var itemGrape = new ItemInfo(catFruits, "ぶどう"))   //// using：アイテム情報(ぶどう)を生成する
            using (var itemPeach = new ItemInfo(catFruits, "桃"))       //// using：アイテム情報(桃)を生成する
            {
                Trace.Indent();
                Trace.WriteLine("処理本体開始");

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する
                itemBeef.NumberOfStock += 29;                           /////  牛肉を入庫する

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する
                itemPeach.NumberOfStock += 8;                           /////  桃を入庫する

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する
                itemBeef.NumberOfStock -= 23;                           /////  牛肉を出庫する

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する

                Trace.WriteLine("処理本体終了");
                Trace.Unindent();
            }

            Trace.WriteLine("using 終了後");


            // 【実行結果の出力例】
            // using 開始前
            // ItemCategoryInfo.ctor:肉類
            // ItemCategoryInfo.ctor:果物
            // ItemInfo.ctor:肉類.牛肉(在庫数=0)
            // ItemInfo.ctor:果物.ぶどう(在庫数=0)
            // ItemInfo.ctor:果物.桃(在庫数=0)
            //   処理本体開始
            //   肉類.牛肉(在庫数=0) 果物.ぶどう(在庫数=0) 果物.桃(在庫数=0)
            //   肉類.牛肉(在庫数=29) 果物.ぶどう(在庫数=0) 果物.桃(在庫数=0)
            //   肉類.牛肉(在庫数=29) 果物.ぶどう(在庫数=0) 果物.桃(在庫数=8)
            //   肉類.牛肉(在庫数=6) 果物.ぶどう(在庫数=0) 果物.桃(在庫数=8)
            //   処理本体終了
            // ItemInfo.Dispose:果物.桃(在庫数=8)
            // ItemInfo.Dispose:果物.ぶどう(在庫数=0)
            // ItemInfo.Dispose:肉類.牛肉(在庫数=6)
            // ItemCategoryInfo.Dispose:果物
            // ItemCategoryInfo.Dispose:肉類
            // using 終了後
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【C#の小技：using ステートメントが複数連続するときの非ネスト記述】<br/>
        /// ・入れ子にして書いた場合のサンプルです。ネストが無駄に深くなってしまっています。<br/>
        /// </summary>
        //--------------------------------------------------------------------------------
        [TipsMethod("C#の小技：using ステートメントが複数連続するときの非ネスト記述 ②入れ子にして書いた場合")]
        public static void Using_NestedDescription()
        {
            //------------------------------------------------------------
            /// 連続する複数の using ステートメントを入れ子にして書いたサンプル
            //------------------------------------------------------------
            Trace.WriteLine("using 開始前");

            using (var catMeat = new ItemCategoryInfo("肉類"))                          //// using：アイテム分類情報(肉類)を生成する
            {
                using (var catFruits = new ItemCategoryInfo("果物"))                    /////  using：アイテム分類情報(果物)を生成する
                {
                    using (var itemBeef = new ItemInfo(catMeat, "牛肉"))                //////   using：アイテム情報(牛肉)を生成する
                    {
                        using (var itemGrape = new ItemInfo(catFruits, "ぶどう"))       ///////    using：アイテム情報(ぶどう)を生成する
                        {
                            using (var itemPeach = new ItemInfo(catFruits, "桃"))       ////////     using：アイテム情報(桃)を生成する
                            {
                                Trace.Indent();
                                Trace.WriteLine("処理本体開始");

                                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////////      在庫状況を表示する
                                itemBeef.NumberOfStock += 29;                           /////////      牛肉を入庫する

                                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////////      在庫状況を表示する
                                itemPeach.NumberOfStock += 8;                           /////////      桃を入庫する

                                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////////      在庫状況を表示する
                                itemBeef.NumberOfStock -= 23;                           /////////      牛肉を出庫する

                                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////////      在庫状況を表示する

                                Trace.WriteLine("処理本体終了");
                                Trace.Unindent();
                            }
                        }
                    }
                }
            }

            Trace.WriteLine("using 終了後");

            // 【実行結果の出力例】は、非ネスト記述の場合と同じ結果になるため省略します。
        }


        // ＜参考メモ＞
        // ・C#8.0以降なら using 宣言(スコープ外へ出るときに自動的に破棄されるよう変数を宣言する方法)も使えるようです。
        //   下記のサンプルではあまり意味がありませんが、ブロックの途中で追加生成する場合に有効です。
#if false
        public static void UsingDeclaration()
        {
            //------------------------------------------------------------
            /// using 宣言を使った場合のイメージ(本プロジェクトではコンパイルエラーになります)
            //------------------------------------------------------------
            Trace.WriteLine("using 宣言ブロック開始前");

            {                                                           //// using 宣言ブロック
                using var catMeat = new ItemCategoryInfo("肉類");       /////  using 宣言：アイテム分類情報(肉類)を生成する
                using var catFruits = new ItemCategoryInfo("果物");     /////  using 宣言：アイテム分類情報(果物)を生成する
                using var itemBeef = new ItemInfo(catMeat, "牛肉");     /////  using 宣言：アイテム情報(牛肉)を生成する
                using var itemGrape = new ItemInfo(catFruits, "ぶどう");/////  using 宣言：アイテム情報(ぶどう)を生成する
                using var itemPeach = new ItemInfo(catFruits, "桃");    /////  using 宣言：アイテム情報(桃)を生成する

                Trace.Indent();
                Trace.WriteLine("処理本体開始");

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する
                itemBeef.NumberOfStock += 29;                           /////  牛肉を入庫する

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する
                itemPeach.NumberOfStock += 8;                           /////  桃を入庫する

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する
                itemBeef.NumberOfStock -= 23;                           /////  牛肉を出庫する

                Trace.WriteLine($"{itemBeef} {itemGrape} {itemPeach}"); /////  在庫状況を表示する

                Trace.WriteLine("処理本体終了");
                Trace.Unindent();
            }

            Trace.WriteLine("using 宣言ブロック終了後");
        }
#endif

    } // class


    // ＜メモ＞
    // ・下記条件を満たす既存のクラスが見当たらなかったため、サンプル用のダミークラスを用意しました。
    //   1)IDispose I/F を実装すること
    //   2)直前に生成したオブジェクトを参照しながら新しいインスタンスを生成すること
    //   3)オブジェクトの内容が後から変化すること
    //   4)サンプル用として扱いやすいこと
    //====================================================================================================
    /// <summary>
    /// 【アイテム分類情報】アイテム分類に関する情報を管理します。
    /// </summary>
    /// <remarks>
    /// 補足<br/>
    /// ・サンプル用のダミークラスであり、<see cref="IDisposable"/> I/F の実装に実質的な役割はありません。<br/>
    /// </remarks>
    //====================================================================================================
    public partial class ItemCategoryInfo : IDisposable
    {
        /// <summary>
        /// 【アイテム分類表示名(読み取り専用)】このアイテム分類の表示名です。
        /// </summary>
        public string DisplayName => bf_displayName;
        protected readonly string bf_displayName;   // バッキングフィールド


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【文字列化】このインスタンスの内容を文字列形式に変換します。
        /// </summary>
        /// <returns>文字列形式</returns>
        //--------------------------------------------------------------------------------
        public override string ToString() => DisplayName;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【完全コンストラクター】すべての内容を指定してアイテム分類情報を生成します。
        /// </summary>
        /// <param name="displayName">[in ]：アイテム分類表示名</param>
        //--------------------------------------------------------------------------------
        public ItemCategoryInfo(string displayName)
        {
            bf_displayName = displayName;
            Trace.WriteLine($"ItemCategoryInfo.ctor:{this}");
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【明示的リソース破棄】すべてのリソースを破棄します(<see cref="IDisposable.Dispose"/> の実装)
        /// </summary>
        /// <remarks>
        /// 補足<br/>
        /// ・Disposeが呼び出されるタイミングを可視化するためのダミーメソッドであり、実質的な役割はありません。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        void IDisposable.Dispose()
        {
            Trace.WriteLine($"ItemCategoryInfo.Dispose:{this}");
        }

    } // class


    //====================================================================================================
    /// <summary>
    /// 【アイテム情報】アイテムに関する情報を管理します。
    /// </summary>
    /// <remarks>
    /// 補足<br/>
    /// ・サンプル用のダミークラスであり、<see cref="IDisposable"/> I/F の実装に実質的な役割はありません。<br/>
    /// </remarks>
    //====================================================================================================
    public partial class ItemInfo : IDisposable
    {
        /// <summary>
        /// 【アイテム表示名(読み取り専用)】このアイテムの表示名です。
        /// </summary>
        public string DisplayName => bf_displayName;
        protected readonly string bf_displayName;   // バッキングフィールド


        /// <summary>
        /// 【アイテム分類情報】このアイテムが所属する分類を示すアイテム分類情報です。
        /// </summary>
        protected readonly ItemCategoryInfo m_itemCategoryInfo;


        /// <summary>
        /// 【在庫数】このアイテムの現在の在庫数です。
        /// </summary>
        public int NumberOfStock { get; set; }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【文字列化】このインスタンスの内容を文字列形式に変換します。
        /// </summary>
        /// <returns>文字列形式</returns>
        //--------------------------------------------------------------------------------
        public override string ToString() => $"{m_itemCategoryInfo.DisplayName}.{DisplayName}(在庫数={NumberOfStock})";


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【完全コンストラクター】すべての内容を指定してアイテム情報を生成します。
        /// </summary>
        /// <param name="itemCategoryInfo">[in ]：アイテム分類情報</param>
        /// <param name="displayName">     [in ]：アイテム表示名</param>
        //--------------------------------------------------------------------------------
        public ItemInfo(ItemCategoryInfo itemCategoryInfo, string displayName)
        {
            m_itemCategoryInfo = itemCategoryInfo;
            bf_displayName = displayName;
            NumberOfStock = 0;
            Trace.WriteLine($"ItemInfo.ctor:{this}");
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【明示的リソース破棄】すべてのリソースを破棄します(<see cref="IDisposable.Dispose"/> の実装)
        /// </summary>
        /// <remarks>
        /// 補足<br/>
        /// ・Disposeが呼び出されるタイミングを可視化するためのダミーメソッドであり、実質的な役割はありません。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        void IDisposable.Dispose()
        {
            Trace.WriteLine($"ItemInfo.Dispose:{this}");
        }

    } // class

} // namespace
