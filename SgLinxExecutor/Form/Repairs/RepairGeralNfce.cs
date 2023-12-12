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
    public partial class RepairGeralNfce : Form
    {
        public RepairGeralNfce()
        {
            InitializeComponent();
        }

        Geral geral = new Geral();
        MysqlConnect mysqlConnect = new MysqlConnect();
        Repair repair = new Repair();
        bool vLojas = false;
        private void RepairGeralNfce_Load(object sender, EventArgs e)
        {
            lblQntLojas.Visible = false;
            txtQntLojas.Visible = false;
            lblInfo.Visible = false;


            string[] lojas = mysqlConnect.EmpresasCad();
            for (int i = 0; i < lojas.Length; i++)
            {
                cbLoja.Items.Add(lojas[i]);
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            mysqlConnect.AlterIp(txtIp.Text);

            string initialDate = dtData.Text;
            string date = geral.InverterDataTimePicker(initialDate);
            string dt = geral.ToDt(date, '-');
            string lj;
            if (vLojas)
            {
                lj = txtQntLojas.Text;
            }
            else
            {
                lj = cbLoja.Text;
            }
            repair.RepairGeralNfce(vLojas,dt, lj); ;
        }

        private void cbVariasLojas_CheckedChanged(object sender, EventArgs e)
        {
            vLojas = cbVariasLojas.Checked;
            lblQntLojas.Visible = vLojas;
            txtQntLojas.Visible = vLojas;
            cbLoja.Enabled = !vLojas;
            lblInfo.Visible = vLojas;
        }

        private void cbLoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
