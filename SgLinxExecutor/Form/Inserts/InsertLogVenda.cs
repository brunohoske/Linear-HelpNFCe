using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SgLinxExecutor
{
    public partial class InsertLogVenda : Form
    {
        Geral geral = new Geral();
        Command9020 command = new Command9020();
        MysqlConnect mysqlConnect = new MysqlConnect();

        bool vNfce = false;
        bool sequencia = false;

        public InsertLogVenda()
        {
            InitializeComponent();
        }
        private void InsertLogVenda_Load(object sender, EventArgs e)
        {
            txtNfce.Enabled = true;
            lblQntNfce.Visible = false;
            lblQntNfce.Enabled = false;
            txtQntNFce.Visible = false;
            txtQntNFce.Enabled = false;
            lblNfceIni.Visible = false;
            lblNfceFin.Visible = false;
            txtNfceIni.Visible = false;
            txtNfceFin.Visible = false;
            txtNfceIni.Visible = false;
            txtNfceFin.Visible = false;
            dtData.Value = DateTime.Now;

            string[] lojas = mysqlConnect.EmpresasCad();
            for (int i = 0; i < lojas.Length; i++)
            {
                cbLoja.Items.Add(lojas[i]);
            }
        }

        private void cbLoja_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCaixa.Items.Clear();
            MysqlConnect mysqlConnect = new MysqlConnect();

            if (mysqlConnect.SglinxConnect())
            {
                string[] caixas = mysqlConnect.CaixasCad(int.Parse(cbLoja.Text));

                for (int i = 0; i < caixas.Length; i++)
                {
                    cbCaixa.Items.Add(caixas[i]);

                }
            }
        }



        private void btnExecute_Click(object sender, EventArgs e)
        {
            mysqlConnect.AlterIp(txtIp.Text);

            string initialDate = dtData.Text;
            string date = geral.InverterDataTimePicker(initialDate);

            string dt = geral.ToDt(date, '-');
            string lj = cbLoja.Text;
            string cx = cbCaixa.Text;
            string nfce = "";

            if (vNfce == false)
            {
                nfce = txtNfce.Text;
            }
            else if (vNfce == true)
            {
                nfce = txtQntNFce.Text;
            }
            else if(sequencia == true)
            {
                nfce = "";
            }

            if(vNfce == false && sequencia == false)
            {
                if (command.InserirLogVenda(lj, dt, date, cx, nfce))
                {
                    MessageBox.Show($"Venda {nfce} inserida com sucesso");
                }
                else
                {
                    MessageBox.Show("Venda não foi inserida. Confira os valores digitados.");
                }
            }
            else if(vNfce == true && sequencia == false)
            {
                string[] qntNfce = txtQntNFce.Text.Split(',', ' ');
                for (int i = 0; i < qntNfce.Length; i++)
                {
                    if (command.InserirLogVenda(lj, dt, date, cx, qntNfce[i]))
                    {
                        MessageBox.Show($"Venda {qntNfce[i]} Inserida.");
                    }
                    else
                    {
                        MessageBox.Show($"Venda {qntNfce[i]} não foi inserida.");
                    }
                }
            }
            else if(sequencia = true && vNfce == false)
            {
                string nfceIni = txtNfceIni.Text;
                string nfceFin = txtNfceFin.Text;
                if (command.InserirSequenciaLogVenda(lj, dt, date, cx,nfceIni,nfceFin))
                {
                    MessageBox.Show("Sequência inserida com sucesso.");
                }
                else
                {
                    MessageBox.Show("Sequência não foi inserida. Confira os valores digitados");
                }
            }

        }
        private void cbVariosNfce_CheckedChanged(object sender, EventArgs e)
        {
            cbSequencia.Checked = false;
            sequencia = false;

            vNfce = cbVariosNfce.Checked;

            lblQntNfce.Visible = vNfce;
            lblQntNfce.Enabled = vNfce;
            txtQntNFce.Visible = vNfce;
            txtQntNFce.Enabled = vNfce;
            txtNfce.Enabled = !vNfce;

        }

        private void cbSequencia_CheckedChanged(object sender, EventArgs e)
        {

            cbVariosNfce.Checked = false;
            vNfce = false;

            sequencia = cbSequencia.Checked;

            lblNfceFin.Visible = sequencia;
            lblNfceIni.Visible = sequencia;
            txtNfceFin.Visible = sequencia;
            txtNfceIni.Visible = sequencia;
            txtNfce.Enabled = !sequencia;

        }

        private void cbLoja_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void cbCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cbCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
