using System;
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
    public partial class InsertLogFin : Form
    {
        public InsertLogFin()
        {
            InitializeComponent();
        }

        Geral geral = new Geral();
        Command9020 command = new Command9020();
        MysqlConnect mysqlConnect = new MysqlConnect();

        bool vCupom = false;
        bool sequencia = false;

        private void InsertLogFin_Load(object sender, EventArgs e)
        {
            txtCupom.Enabled = true;
            lblQntCupom.Visible = false;
            lblQntCupom.Enabled = false;
            txtQntCupom.Visible = false;
            txtQntCupom.Enabled = false;
            lblCupomIni.Visible = false;
            lblCupomFin.Visible = false;
            txtCupomIni.Visible = false;
            txtCupomFin.Visible = false;
            txtCupomIni.Visible = false;
            txtCupomFin.Visible = false;
            dtData.Value = DateTime.Now;

            string[] lojas = mysqlConnect.EmpresasCad();
            for (int i = 0; i < lojas.Length; i++)
            {
                cbLoja.Items.Add(lojas[i]);
            }
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {

            mysqlConnect.AlterIp(txtIp.Text);

            string initialDate = dtData.Text;
            string date = geral.InverterDataTimePicker(initialDate);

            string dt = geral.ToDt(date, '-');
            string lj = cbLoja.Text;
            string cupom = "";

            if (vCupom == false)
            {
                cupom = txtCupom.Text;
            }
            else if (vCupom == true)
            {
                cupom = txtQntCupom.Text;
            }
            else if (sequencia == true)
            {
                cupom = "";
            }

            if (vCupom == false && sequencia == false)
            {
                if (command.InserirLogFin(lj, dt, cupom))
                {
                    MessageBox.Show($"Venda {cupom} inserida com sucesso");
                }
                else
                {
                    MessageBox.Show("Venda não foi inserida. Confira os valores digitados.");
                }
            }
            else if (vCupom == true && sequencia == false)
            {
                string[] qntCupom = txtQntCupom.Text.Split(',', ' ');
                for (int i = 0; i < qntCupom.Length; i++)
                {
                    if (command.InserirLogFin(lj, dt, qntCupom[i]))
                    {
                        MessageBox.Show($"Venda {qntCupom[i]} Inserida.");
                    }
                    else
                    {
                        MessageBox.Show($"Venda {qntCupom[i]} não foi inserida.");
                    }
                }
            }
            else if (sequencia = true && vCupom == false)
            {
                string cupomIni = txtCupomIni.Text;
                string cupomFin = txtCupomFin.Text;
                if (command.InserirSequenciaLogFin(lj,dt,cupomIni,cupomFin))
                {
                    MessageBox.Show("Sequência inserida com sucesso.");
                }
                else
                {
                    MessageBox.Show("Sequência não foi inserida. Confira os valores digitados");
                }
            }
        }
        private void cbLoja_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void cbVariosCupons_CheckedChanged(object sender, EventArgs e)
        {
            cbSequencia.Checked = false;
            sequencia = false;

            vCupom = cbVariosCupons.Checked;

            lblQntCupom.Visible = vCupom;
            lblQntCupom.Enabled = vCupom;
            txtQntCupom.Visible = vCupom;
            txtQntCupom.Enabled = vCupom;
            txtCupom.Enabled = !vCupom;
        }
        private void cbSequencia_CheckedChanged_1(object sender, EventArgs e)
        {
            cbVariosCupons.Checked = false;
            vCupom = false;

            sequencia = cbSequencia.Checked;

            lblCupomFin.Visible = sequencia;
            lblCupomIni.Visible = sequencia;
            txtCupomFin.Visible = sequencia;
            txtCupomIni.Visible = sequencia;
            txtCupom.Enabled = !sequencia;
        }

       
    }
}

