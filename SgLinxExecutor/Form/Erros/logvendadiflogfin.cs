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
    public partial class logvendadiflogfin : Form
    {
        public logvendadiflogfin()
        {
            InitializeComponent();
        }
        MysqlConnect mysqlConnect = new MysqlConnect();
        Geral geral = new Geral();
        Command9020 command = new Command9020();
        private void logvendadiflogfin_Load(object sender, EventArgs e)
        {
            dtData.Value = DateTime.Now;

            string[] lojas = mysqlConnect.EmpresasCad();
            for (int i = 0; i < lojas.Length; i++)
            {
                cbLoja.Items.Add(lojas[i]);
            }

        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            mysqlConnect.AlterIp(txtIp.Text);

            string intitialDt = dtData.ToString();
            string date = geral.InverterDataTimePicker(intitialDt);
            string dt = geral.ToDt(date, '-');
            string lj = cbLoja.Text;
            string cx = cbCaixa.Text;
            string cp = txtCupom.Text;

            command.ExecutarDivLogvendalogfin(lj,dt,cx,cp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string intitialDt = dtData.ToString();
            string date = geral.InverterDataTimePicker(intitialDt);
            string dt = geral.ToDt(date, '-');

            string lj = cbLoja.Text;
            string cx = cbCaixa.Text;
            string cp = txtCupom.Text;
            command.ExecutarFullDivLogvendalogfin(lj, dt, cx, cp);
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
