using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SgLinxExecutor
{
    public partial class FormDuplicidadeRV : Form
    {
        public FormDuplicidadeRV()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            MysqlConnect mysqlConnect = new MysqlConnect();
            Geral geral = new Geral();

            mysqlConnect.AlterIp(txtIp.Text);

            string lj = cbLoja.Text;
            string cx = cbCaixa.Text;

            string intitialDt = dtData.ToString();
            string date = geral.InverterDataTimePicker(intitialDt);
            string dt = geral.ToDt(date, '-');


            List<string> caixas = new List<string>();

            if (cbCaixa.Text != "" && cbLoja.Text != "")
            {
                if (mysqlConnect.DuplicidadeRV(lj, dt, cx))
                {
                    MessageBox.Show("Processamento Executado Com Sucesso");
                }
                else
                {
                    MessageBox.Show("Processamento Não Executado");
                }
            }
            else
            {
                MessageBox.Show("Preencha os campos corretamente");
            }
            
        }

        private void FormDuplicidadeRV_Load(object sender, EventArgs e)
        {
            dtData.Value = DateTime.Now;

            MysqlConnect mysqlConnect = new MysqlConnect();

            

            string[] lojas = mysqlConnect.EmpresasCad();
            for(int i = 0;i < lojas.Length; i++)
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

                for(int i = 0;i < caixas.Length; i++)
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

        private void cbCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
