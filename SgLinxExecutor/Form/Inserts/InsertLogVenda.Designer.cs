namespace SgLinxExecutor
{
    partial class InsertLogVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblQntNfce = new System.Windows.Forms.Label();
            this.txtQntNFce = new System.Windows.Forms.TextBox();
            this.cbVariosNfce = new System.Windows.Forms.CheckBox();
            this.txtNfce = new System.Windows.Forms.TextBox();
            this.lblCupom = new System.Windows.Forms.Label();
            this.lblCaixa = new System.Windows.Forms.Label();
            this.lblLoja = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblNfceIni = new System.Windows.Forms.Label();
            this.txtNfceIni = new System.Windows.Forms.TextBox();
            this.cbSequencia = new System.Windows.Forms.CheckBox();
            this.lblNfceFin = new System.Windows.Forms.Label();
            this.txtNfceFin = new System.Windows.Forms.TextBox();
            this.cbLoja = new System.Windows.Forms.ComboBox();
            this.cbCaixa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtData
            // 
            this.dtData.CustomFormat = "";
            this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData.Location = new System.Drawing.Point(156, 195);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(101, 20);
            this.dtData.TabIndex = 0;
            this.dtData.Value = new System.DateTime(2023, 2, 1, 0, 0, 0, 0);
            // 
            // lblQntNfce
            // 
            this.lblQntNfce.AutoSize = true;
            this.lblQntNfce.Location = new System.Drawing.Point(21, 297);
            this.lblQntNfce.Name = "lblQntNfce";
            this.lblQntNfce.Size = new System.Drawing.Size(41, 13);
            this.lblQntNfce.TabIndex = 31;
            this.lblQntNfce.Text = "NFCe\'s";
            // 
            // txtQntNFce
            // 
            this.txtQntNFce.Location = new System.Drawing.Point(24, 313);
            this.txtQntNFce.Multiline = true;
            this.txtQntNFce.Name = "txtQntNFce";
            this.txtQntNFce.Size = new System.Drawing.Size(127, 39);
            this.txtQntNFce.TabIndex = 30;
            // 
            // cbVariosNfce
            // 
            this.cbVariosNfce.AutoSize = true;
            this.cbVariosNfce.Location = new System.Drawing.Point(24, 272);
            this.cbVariosNfce.Name = "cbVariosNfce";
            this.cbVariosNfce.Size = new System.Drawing.Size(81, 17);
            this.cbVariosNfce.TabIndex = 29;
            this.cbVariosNfce.Text = "Vários Nfce";
            this.cbVariosNfce.UseVisualStyleBackColor = true;
            this.cbVariosNfce.CheckedChanged += new System.EventHandler(this.cbVariosNfce_CheckedChanged);
            // 
            // txtNfce
            // 
            this.txtNfce.Location = new System.Drawing.Point(24, 245);
            this.txtNfce.Name = "txtNfce";
            this.txtNfce.Size = new System.Drawing.Size(100, 20);
            this.txtNfce.TabIndex = 28;
            // 
            // lblCupom
            // 
            this.lblCupom.AutoSize = true;
            this.lblCupom.Location = new System.Drawing.Point(24, 228);
            this.lblCupom.Name = "lblCupom";
            this.lblCupom.Size = new System.Drawing.Size(34, 13);
            this.lblCupom.TabIndex = 27;
            this.lblCupom.Text = "NFCe";
            // 
            // lblCaixa
            // 
            this.lblCaixa.AutoSize = true;
            this.lblCaixa.Location = new System.Drawing.Point(156, 228);
            this.lblCaixa.Name = "lblCaixa";
            this.lblCaixa.Size = new System.Drawing.Size(33, 13);
            this.lblCaixa.TabIndex = 25;
            this.lblCaixa.Text = "Caixa";
            // 
            // lblLoja
            // 
            this.lblLoja.AutoSize = true;
            this.lblLoja.Location = new System.Drawing.Point(24, 178);
            this.lblLoja.Name = "lblLoja";
            this.lblLoja.Size = new System.Drawing.Size(30, 13);
            this.lblLoja.TabIndex = 23;
            this.lblLoja.Text = "Loja:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(153, 178);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 13);
            this.lblDate.TabIndex = 21;
            this.lblDate.Text = "Dia da venda";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(311, 245);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 32;
            this.btnExecute.Text = "Inserir";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblNfceIni
            // 
            this.lblNfceIni.AutoSize = true;
            this.lblNfceIni.Location = new System.Drawing.Point(159, 301);
            this.lblNfceIni.Name = "lblNfceIni";
            this.lblNfceIni.Size = new System.Drawing.Size(64, 13);
            this.lblNfceIni.TabIndex = 35;
            this.lblNfceIni.Text = "NFCe Inicial";
            // 
            // txtNfceIni
            // 
            this.txtNfceIni.Location = new System.Drawing.Point(162, 317);
            this.txtNfceIni.Name = "txtNfceIni";
            this.txtNfceIni.Size = new System.Drawing.Size(80, 20);
            this.txtNfceIni.TabIndex = 34;
            // 
            // cbSequencia
            // 
            this.cbSequencia.AutoSize = true;
            this.cbSequencia.Location = new System.Drawing.Point(159, 272);
            this.cbSequencia.Name = "cbSequencia";
            this.cbSequencia.Size = new System.Drawing.Size(77, 17);
            this.cbSequencia.TabIndex = 33;
            this.cbSequencia.Text = "Sequência";
            this.cbSequencia.UseVisualStyleBackColor = true;
            this.cbSequencia.CheckedChanged += new System.EventHandler(this.cbSequencia_CheckedChanged);
            // 
            // lblNfceFin
            // 
            this.lblNfceFin.AutoSize = true;
            this.lblNfceFin.Location = new System.Drawing.Point(245, 301);
            this.lblNfceFin.Name = "lblNfceFin";
            this.lblNfceFin.Size = new System.Drawing.Size(59, 13);
            this.lblNfceFin.TabIndex = 37;
            this.lblNfceFin.Text = "NFCe Final";
            // 
            // txtNfceFin
            // 
            this.txtNfceFin.Location = new System.Drawing.Point(248, 317);
            this.txtNfceFin.Name = "txtNfceFin";
            this.txtNfceFin.Size = new System.Drawing.Size(80, 20);
            this.txtNfceFin.TabIndex = 36;
            // 
            // cbLoja
            // 
            this.cbLoja.FormattingEnabled = true;
            this.cbLoja.Location = new System.Drawing.Point(24, 195);
            this.cbLoja.Name = "cbLoja";
            this.cbLoja.Size = new System.Drawing.Size(100, 21);
            this.cbLoja.TabIndex = 47;
            this.cbLoja.SelectedIndexChanged += new System.EventHandler(this.cbLoja_SelectedIndexChanged);
            this.cbLoja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLoja_KeyPress);
            // 
            // cbCaixa
            // 
            this.cbCaixa.FormattingEnabled = true;
            this.cbCaixa.Location = new System.Drawing.Point(159, 244);
            this.cbCaixa.Name = "cbCaixa";
            this.cbCaixa.Size = new System.Drawing.Size(100, 21);
            this.cbCaixa.TabIndex = 46;
            this.cbCaixa.SelectedIndexChanged += new System.EventHandler(this.cbCaixa_SelectedIndexChanged);
            this.cbCaixa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCaixa_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(698, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "IP Banco de Dados";
            // 
            // txtIp
            // 
            this.txtIp.AcceptsReturn = true;
            this.txtIp.Location = new System.Drawing.Point(698, 12);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 20);
            this.txtIp.TabIndex = 52;
            this.txtIp.Text = "localhost";
            this.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 71;
            this.label1.Text = "LOGVENDA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 23);
            this.label3.TabIndex = 70;
            this.label3.Text = "INSERIR REGISTROS NA TABELA";
            // 
            // InsertLogVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.cbLoja);
            this.Controls.Add(this.cbCaixa);
            this.Controls.Add(this.lblNfceFin);
            this.Controls.Add(this.txtNfceFin);
            this.Controls.Add(this.lblNfceIni);
            this.Controls.Add(this.txtNfceIni);
            this.Controls.Add(this.cbSequencia);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblQntNfce);
            this.Controls.Add(this.txtQntNFce);
            this.Controls.Add(this.cbVariosNfce);
            this.Controls.Add(this.txtNfce);
            this.Controls.Add(this.lblCupom);
            this.Controls.Add(this.lblCaixa);
            this.Controls.Add(this.lblLoja);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtData);
            this.MaximizeBox = false;
            this.Name = "InsertLogVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir registros na logvenda";
            this.Load += new System.EventHandler(this.InsertLogVenda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblQntNfce;
        private System.Windows.Forms.TextBox txtQntNFce;
        private System.Windows.Forms.CheckBox cbVariosNfce;
        private System.Windows.Forms.TextBox txtNfce;
        private System.Windows.Forms.Label lblCupom;
        private System.Windows.Forms.Label lblCaixa;
        private System.Windows.Forms.Label lblLoja;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblNfceIni;
        private System.Windows.Forms.TextBox txtNfceIni;
        private System.Windows.Forms.CheckBox cbSequencia;
        private System.Windows.Forms.Label lblNfceFin;
        private System.Windows.Forms.TextBox txtNfceFin;
        private System.Windows.Forms.ComboBox cbLoja;
        private System.Windows.Forms.ComboBox cbCaixa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}