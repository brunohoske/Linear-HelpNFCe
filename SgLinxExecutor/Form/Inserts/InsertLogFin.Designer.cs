namespace SgLinxExecutor
{
    partial class InsertLogFin
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
            this.cbLoja = new System.Windows.Forms.ComboBox();
            this.lblCupomFin = new System.Windows.Forms.Label();
            this.txtCupomFin = new System.Windows.Forms.TextBox();
            this.lblCupomIni = new System.Windows.Forms.Label();
            this.txtCupomIni = new System.Windows.Forms.TextBox();
            this.cbSequencia = new System.Windows.Forms.CheckBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblQntCupom = new System.Windows.Forms.Label();
            this.txtQntCupom = new System.Windows.Forms.TextBox();
            this.cbVariosCupons = new System.Windows.Forms.CheckBox();
            this.txtCupom = new System.Windows.Forms.TextBox();
            this.lblCupom = new System.Windows.Forms.Label();
            this.lblLoja = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtData = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbLoja
            // 
            this.cbLoja.FormattingEnabled = true;
            this.cbLoja.Location = new System.Drawing.Point(29, 200);
            this.cbLoja.Name = "cbLoja";
            this.cbLoja.Size = new System.Drawing.Size(100, 21);
            this.cbLoja.TabIndex = 64;
            this.cbLoja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbLoja_KeyPress);
            // 
            // lblCupomFin
            // 
            this.lblCupomFin.AutoSize = true;
            this.lblCupomFin.Location = new System.Drawing.Point(252, 323);
            this.lblCupomFin.Name = "lblCupomFin";
            this.lblCupomFin.Size = new System.Drawing.Size(65, 13);
            this.lblCupomFin.TabIndex = 62;
            this.lblCupomFin.Text = "Cupom Final";
            // 
            // txtCupomFin
            // 
            this.txtCupomFin.Location = new System.Drawing.Point(255, 339);
            this.txtCupomFin.Name = "txtCupomFin";
            this.txtCupomFin.Size = new System.Drawing.Size(80, 20);
            this.txtCupomFin.TabIndex = 61;
            // 
            // lblCupomIni
            // 
            this.lblCupomIni.AutoSize = true;
            this.lblCupomIni.Location = new System.Drawing.Point(166, 323);
            this.lblCupomIni.Name = "lblCupomIni";
            this.lblCupomIni.Size = new System.Drawing.Size(70, 13);
            this.lblCupomIni.TabIndex = 60;
            this.lblCupomIni.Text = "Cupom Inicial";
            // 
            // txtCupomIni
            // 
            this.txtCupomIni.Location = new System.Drawing.Point(169, 339);
            this.txtCupomIni.Name = "txtCupomIni";
            this.txtCupomIni.Size = new System.Drawing.Size(80, 20);
            this.txtCupomIni.TabIndex = 59;
            // 
            // cbSequencia
            // 
            this.cbSequencia.AutoSize = true;
            this.cbSequencia.Location = new System.Drawing.Point(166, 294);
            this.cbSequencia.Name = "cbSequencia";
            this.cbSequencia.Size = new System.Drawing.Size(77, 17);
            this.cbSequencia.TabIndex = 58;
            this.cbSequencia.Text = "Sequência";
            this.cbSequencia.UseVisualStyleBackColor = true;
            this.cbSequencia.CheckedChanged += new System.EventHandler(this.cbSequencia_CheckedChanged_1);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(316, 250);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 57;
            this.btnExecute.Text = "Inserir";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblQntCupom
            // 
            this.lblQntCupom.AutoSize = true;
            this.lblQntCupom.Location = new System.Drawing.Point(28, 319);
            this.lblQntCupom.Name = "lblQntCupom";
            this.lblQntCupom.Size = new System.Drawing.Size(43, 13);
            this.lblQntCupom.TabIndex = 56;
            this.lblQntCupom.Text = "Cupons";
            // 
            // txtQntCupom
            // 
            this.txtQntCupom.Location = new System.Drawing.Point(31, 335);
            this.txtQntCupom.Multiline = true;
            this.txtQntCupom.Name = "txtQntCupom";
            this.txtQntCupom.Size = new System.Drawing.Size(127, 39);
            this.txtQntCupom.TabIndex = 55;
            // 
            // cbVariosCupons
            // 
            this.cbVariosCupons.AutoSize = true;
            this.cbVariosCupons.Location = new System.Drawing.Point(31, 294);
            this.cbVariosCupons.Name = "cbVariosCupons";
            this.cbVariosCupons.Size = new System.Drawing.Size(94, 17);
            this.cbVariosCupons.TabIndex = 54;
            this.cbVariosCupons.Text = "Vários Cupons";
            this.cbVariosCupons.UseVisualStyleBackColor = true;
            this.cbVariosCupons.CheckedChanged += new System.EventHandler(this.cbVariosCupons_CheckedChanged);
            // 
            // txtCupom
            // 
            this.txtCupom.Location = new System.Drawing.Point(118, 267);
            this.txtCupom.Name = "txtCupom";
            this.txtCupom.Size = new System.Drawing.Size(100, 20);
            this.txtCupom.TabIndex = 53;
            // 
            // lblCupom
            // 
            this.lblCupom.AutoSize = true;
            this.lblCupom.Location = new System.Drawing.Point(118, 250);
            this.lblCupom.Name = "lblCupom";
            this.lblCupom.Size = new System.Drawing.Size(40, 13);
            this.lblCupom.TabIndex = 52;
            this.lblCupom.Text = "Cupom";
            // 
            // lblLoja
            // 
            this.lblLoja.AutoSize = true;
            this.lblLoja.Location = new System.Drawing.Point(29, 183);
            this.lblLoja.Name = "lblLoja";
            this.lblLoja.Size = new System.Drawing.Size(30, 13);
            this.lblLoja.TabIndex = 50;
            this.lblLoja.Text = "Loja:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(158, 183);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(27, 13);
            this.lblDate.TabIndex = 49;
            this.lblDate.Text = "Mês";
            // 
            // dtData
            // 
            this.dtData.CustomFormat = "";
            this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtData.Location = new System.Drawing.Point(161, 200);
            this.dtData.Name = "dtData";
            this.dtData.Size = new System.Drawing.Size(101, 20);
            this.dtData.TabIndex = 48;
            this.dtData.Value = new System.DateTime(2023, 2, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(688, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "IP Banco de Dados";
            // 
            // txtIp
            // 
            this.txtIp.AcceptsReturn = true;
            this.txtIp.Location = new System.Drawing.Point(688, 12);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 20);
            this.txtIp.TabIndex = 65;
            this.txtIp.Text = "localhost";
            this.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Obs: O dia não faz diferença";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(236, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 23);
            this.label3.TabIndex = 68;
            this.label3.Text = "INSERIR REGISTROS NA TABELA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 69;
            this.label1.Text = "LOGFIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(403, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Atenção! Para realizar esse insert, é necessário ter a informação do RV, na logve" +
    "nda";
            // 
            // InsertLogFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.cbLoja);
            this.Controls.Add(this.lblCupomFin);
            this.Controls.Add(this.txtCupomFin);
            this.Controls.Add(this.lblCupomIni);
            this.Controls.Add(this.txtCupomIni);
            this.Controls.Add(this.cbSequencia);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblQntCupom);
            this.Controls.Add(this.txtQntCupom);
            this.Controls.Add(this.cbVariosCupons);
            this.Controls.Add(this.txtCupom);
            this.Controls.Add(this.lblCupom);
            this.Controls.Add(this.lblLoja);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtData);
            this.MaximizeBox = false;
            this.Name = "InsertLogFin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir Registros na LogFin";
            this.Load += new System.EventHandler(this.InsertLogFin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLoja;
        private System.Windows.Forms.Label lblCupomFin;
        private System.Windows.Forms.TextBox txtCupomFin;
        private System.Windows.Forms.Label lblCupomIni;
        private System.Windows.Forms.TextBox txtCupomIni;
        private System.Windows.Forms.CheckBox cbSequencia;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblQntCupom;
        private System.Windows.Forms.TextBox txtQntCupom;
        private System.Windows.Forms.CheckBox cbVariosCupons;
        private System.Windows.Forms.TextBox txtCupom;
        private System.Windows.Forms.Label lblCupom;
        private System.Windows.Forms.Label lblLoja;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}