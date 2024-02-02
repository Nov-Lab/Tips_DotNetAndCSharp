
namespace Tips_DotNetAndCSharp
{
    partial class FrmAppTips
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LstOutput = new System.Windows.Forms.ListBox();
            this.CMnu_LstOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMnu_LstOutput_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.CMnu_LstOutput_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.LstTips = new System.Windows.Forms.ListBox();
            this.BtnRunTips = new System.Windows.Forms.Button();
            this.TtlTips = new System.Windows.Forms.Label();
            this.TtlOutput = new System.Windows.Forms.Label();
            this.stackSplitter = new System.Windows.Forms.SplitContainer();
            this.PnlButtons = new System.Windows.Forms.Panel();
            this.CMnu_LstOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackSplitter)).BeginInit();
            this.stackSplitter.Panel1.SuspendLayout();
            this.stackSplitter.Panel2.SuspendLayout();
            this.stackSplitter.SuspendLayout();
            this.PnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstOutput
            // 
            this.LstOutput.ContextMenuStrip = this.CMnu_LstOutput;
            this.LstOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstOutput.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstOutput.FormattingEnabled = true;
            this.LstOutput.ItemHeight = 12;
            this.LstOutput.Location = new System.Drawing.Point(8, 26);
            this.LstOutput.Name = "LstOutput";
            this.LstOutput.Size = new System.Drawing.Size(784, 230);
            this.LstOutput.TabIndex = 1;
            // 
            // CMnu_LstOutput
            // 
            this.CMnu_LstOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMnu_LstOutput_Copy,
            this.CMnu_LstOutput_Clear});
            this.CMnu_LstOutput.Name = "CMnu_LstOutput";
            this.CMnu_LstOutput.Size = new System.Drawing.Size(116, 48);
            // 
            // CMnu_LstOutput_Copy
            // 
            this.CMnu_LstOutput_Copy.Name = "CMnu_LstOutput_Copy";
            this.CMnu_LstOutput_Copy.Size = new System.Drawing.Size(115, 22);
            this.CMnu_LstOutput_Copy.Text = "コピー(&C)";
            this.CMnu_LstOutput_Copy.Click += new System.EventHandler(this.CMnu_LstOutput_Copy_Click);
            // 
            // CMnu_LstOutput_Clear
            // 
            this.CMnu_LstOutput_Clear.Name = "CMnu_LstOutput_Clear";
            this.CMnu_LstOutput_Clear.Size = new System.Drawing.Size(115, 22);
            this.CMnu_LstOutput_Clear.Text = "クリア(&R)";
            this.CMnu_LstOutput_Clear.Click += new System.EventHandler(this.CMnu_LstOutput_Clear_Click);
            // 
            // LstTips
            // 
            this.LstTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstTips.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstTips.FormattingEnabled = true;
            this.LstTips.ItemHeight = 12;
            this.LstTips.Location = new System.Drawing.Point(8, 26);
            this.LstTips.Name = "LstTips";
            this.LstTips.Size = new System.Drawing.Size(784, 118);
            this.LstTips.TabIndex = 1;
            this.LstTips.DoubleClick += new System.EventHandler(this.LstTips_DoubleClick);
            // 
            // BtnRunTips
            // 
            this.BtnRunTips.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRunTips.Location = new System.Drawing.Point(704, 6);
            this.BtnRunTips.Name = "BtnRunTips";
            this.BtnRunTips.Size = new System.Drawing.Size(80, 26);
            this.BtnRunTips.TabIndex = 0;
            this.BtnRunTips.Text = "実行(&R)";
            this.BtnRunTips.UseVisualStyleBackColor = true;
            this.BtnRunTips.Click += new System.EventHandler(this.BtnRunTips_Click);
            // 
            // TtlTips
            // 
            this.TtlTips.AutoSize = true;
            this.TtlTips.Dock = System.Windows.Forms.DockStyle.Top;
            this.TtlTips.Location = new System.Drawing.Point(8, 8);
            this.TtlTips.Name = "TtlTips";
            this.TtlTips.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.TtlTips.Size = new System.Drawing.Size(68, 18);
            this.TtlTips.TabIndex = 0;
            this.TtlTips.Text = "Tips一覧(&T):";
            // 
            // TtlOutput
            // 
            this.TtlOutput.AutoSize = true;
            this.TtlOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.TtlOutput.Location = new System.Drawing.Point(8, 8);
            this.TtlOutput.Name = "TtlOutput";
            this.TtlOutput.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.TtlOutput.Size = new System.Drawing.Size(105, 18);
            this.TtlOutput.TabIndex = 0;
            this.TtlOutput.Text = "実行結果の出力(&O):";
            // 
            // stackSplitter
            // 
            this.stackSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.stackSplitter.Location = new System.Drawing.Point(0, 0);
            this.stackSplitter.Name = "stackSplitter";
            this.stackSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // stackSplitter.Panel1
            // 
            this.stackSplitter.Panel1.Controls.Add(this.LstTips);
            this.stackSplitter.Panel1.Controls.Add(this.PnlButtons);
            this.stackSplitter.Panel1.Controls.Add(this.TtlTips);
            this.stackSplitter.Panel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            // 
            // stackSplitter.Panel2
            // 
            this.stackSplitter.Panel2.Controls.Add(this.LstOutput);
            this.stackSplitter.Panel2.Controls.Add(this.TtlOutput);
            this.stackSplitter.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.stackSplitter.Size = new System.Drawing.Size(800, 450);
            this.stackSplitter.SplitterDistance = 182;
            this.stackSplitter.TabIndex = 0;
            this.stackSplitter.TabStop = false;
            // 
            // PnlButtons
            // 
            this.PnlButtons.Controls.Add(this.BtnRunTips);
            this.PnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButtons.Location = new System.Drawing.Point(8, 144);
            this.PnlButtons.Name = "PnlButtons";
            this.PnlButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.PnlButtons.Size = new System.Drawing.Size(784, 38);
            this.PnlButtons.TabIndex = 2;
            // 
            // FrmAppTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stackSplitter);
            this.Name = "FrmAppTips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tips for .NET Framework and C#";
            this.Load += new System.EventHandler(this.FrmAppTips_Load);
            this.CMnu_LstOutput.ResumeLayout(false);
            this.stackSplitter.Panel1.ResumeLayout(false);
            this.stackSplitter.Panel1.PerformLayout();
            this.stackSplitter.Panel2.ResumeLayout(false);
            this.stackSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackSplitter)).EndInit();
            this.stackSplitter.ResumeLayout(false);
            this.PnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstOutput;
        private System.Windows.Forms.ListBox LstTips;
        private System.Windows.Forms.Button BtnRunTips;
        private System.Windows.Forms.ContextMenuStrip CMnu_LstOutput;
        private System.Windows.Forms.ToolStripMenuItem CMnu_LstOutput_Copy;
        private System.Windows.Forms.ToolStripMenuItem CMnu_LstOutput_Clear;
        private System.Windows.Forms.Label TtlTips;
        private System.Windows.Forms.Label TtlOutput;
        private System.Windows.Forms.SplitContainer stackSplitter;
        private System.Windows.Forms.Panel PnlButtons;
    }
}

