// 24/02/02

using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace Tips_DotNetAndCSharp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAppTips());
        }

    } // class

} // namespace
