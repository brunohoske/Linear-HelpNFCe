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
    public partial class Executar9020 : Form
    {
        public Executar9020()
        {
            InitializeComponent();
        }
        Geral geral = new Geral();
        Command9020 command = new Command9020();
        MysqlConnect mysqlConnect = new MysqlConnect();
        bool vCupons = false;
        private void Executar9020_Load(object sender, EventArgs e)
        {
            txtQntCupons.Visible = false;
            txtQntCupons.Enabled = false;
            lblQntCupons.Visible = false;
            lblQntCupons.Enabled = false;
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

            //quando executa cupons inexistentes ele ainda da como correto.
            //

            string intitialDt = dtData.ToString();
            string date = geral.InverterDataTimePicker(intitialDt);
            string dt = geral.ToDt(date, '-');
            string lj = cbLoja.Text;
            string cx = cbCaixa.Text;
            string cp;
            if (vCupons == false)
            {
                cp = txtCupom.Text;
            }
            else
            {
                cp = txtCupom.Text;
            }
           

            if( vCupons == false)
            {
                if (command.Executar9020(lj, dt, cx, cp))
                {
                    MessageBox.Show("Comando executado com sucesso");
                }

            }
            else
            {
                string[] qntCupons = txtQntCupons.Text.Split(',',' ');
                for (int i = 0; i < qntCupons.Length; i++)
                {

                    if(command.Executar9020(lj, dt, cx, qntCupons[i]) && i == qntCupons.Length -1)
                    {
                        MessageBox.Show("Comando executado com sucesso");
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lj = cbLoja.Text;
            string intitialDt = dtData.ToString();
            string date = geral.InverterDataTimePicker(intitialDt);
            string dt = geral.ToDt(date, '-');

            command.ExecutarFull9020(lj, dt);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            vCupons = cbVariosCupons.Checked;
            lblQntCupons.Visible = vCupons;
            lblQntCupons.Enabled = vCupons;
            txtQntCupons.Visible = vCupons;
            txtQntCupons.Enabled = vCupons;
            txtCupom.Enabled = !vCupons;
        }

        private void cbLoja_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCaixa.Items.Clear();

            if (mysqlConnect.SglinxConnect())
            {
                string[] caixas = mysqlConnect.CaixasCad(int.Parse(cbLoja.Text));

                for (int i = 0; i < caixas.Length; i++)
                {
                    cbCaixa.Items.Add(caixas[i]);
                }
                mysqlConnect.SglinxClose();
            }
        }

        private void cbLoja_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cbCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
