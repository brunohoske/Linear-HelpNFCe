namespace SgLinxExecutor
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicidadeValorDiferenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logVendaLogFinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repairGeralDeNFCeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logFinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logVendaELogFinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.repairsToolStripMenuItem,
            this.insertsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicidadeValorDiferenteToolStripMenuItem,
            this.logVendaLogFinToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Resolver";
            // 
            // duplicidadeValorDiferenteToolStripMenuItem
            // 
            this.duplicidadeValorDiferenteToolStripMenuItem.Name = "duplicidadeValorDiferenteToolStripMenuItem";
            this.duplicidadeValorDiferenteToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.duplicidadeValorDiferenteToolStripMenuItem.Text = "Duplicidade com valor diferente";
            this.duplicidadeValorDiferenteToolStripMenuItem.Click += new System.EventHandler(this.duplicidadeValorDiferenteToolStripMenuItem_Click);
            // 
            // logVendaLogFinToolStripMenuItem
            // 
            this.logVendaLogFinToolStripMenuItem.Name = "logVendaLogFinToolStripMenuItem";
            this.logVendaLogFinToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.logVendaLogFinToolStripMenuItem.Text = "LogVenda ≠ LogFin";
            this.logVendaLogFinToolStripMenuItem.Click += new System.EventHandler(this.logVendaLogFinToolStripMenuItem_Click);
            // 
            // repairsToolStripMenuItem
            // 
            this.repairsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repairGeralDeNFCeToolStripMenuItem});
            this.repairsToolStripMenuItem.Name = "repairsToolStripMenuItem";
            this.repairsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.repairsToolStripMenuItem.Text = "Repairs";
            // 
            // repairGeralDeNFCeToolStripMenuItem
            // 
            this.repairGeralDeNFCeToolStripMenuItem.Name = "repairGeralDeNFCeToolStripMenuItem";
            this.repairGeralDeNFCeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.repairGeralDeNFCeToolStripMenuItem.Text = "Repair geral de NFCe ";
            this.repairGeralDeNFCeToolStripMenuItem.Click += new System.EventHandler(this.repairGeralDeNFCeToolStripMenuItem_Click);
            // 
            // insertsToolStripMenuItem
            // 
            this.insertsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logVendaToolStripMenuItem,
            this.logFinToolStripMenuItem,
            this.logVendaELogFinToolStripMenuItem});
            this.insertsToolStripMenuItem.Name = "insertsToolStripMenuItem";
            this.insertsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.insertsToolStripMenuItem.Text = "Inserts";
            // 
            // logVendaToolStripMenuItem
            // 
            this.logVendaToolStripMenuItem.Name = "logVendaToolStripMenuItem";
            this.logVendaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.logVendaToolStripMenuItem.Text = "LogVenda";
            this.logVendaToolStripMenuItem.Click += new System.EventHandler(this.logVendaToolStripMenuItem_Click);
            // 
            // logFinToolStripMenuItem
            // 
            this.logFinToolStripMenuItem.Name = "logFinToolStripMenuItem";
            this.logFinToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.logFinToolStripMenuItem.Text = "LogFin";
            this.logFinToolStripMenuItem.Click += new System.EventHandler(this.logFinToolStripMenuItem_Click);
            // 
            // logVendaELogFinToolStripMenuItem
            // 
            this.logVendaELogFinToolStripMenuItem.Name = "logVendaELogFinToolStripMenuItem";
            this.logVendaELogFinToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.logVendaELogFinToolStripMenuItem.Text = "LogVenda e LogFin";
            this.logVendaELogFinToolStripMenuItem.Click += new System.EventHandler(this.logVendaELogFinToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "SGLinx Resolve";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Escolha o que realizar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(645, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desenvolvido por Bruno Hoske";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem repairsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repairGeralDeNFCeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logVendaLogFinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicidadeValorDiferenteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem logFinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logVendaELogFinToolStripMenuItem;
    }
}

