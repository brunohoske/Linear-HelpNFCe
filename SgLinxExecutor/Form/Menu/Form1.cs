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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Executar9020 ex9020 = new Executar9020();
            ex9020.Show();
        }

        private void repairGeralDeNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepairGeralNfce repairGeralNfce = new RepairGeralNfce();
            repairGeralNfce.Show();
        }

        private void logVendaLogFinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logvendadiflogfin logvendadiflogfin = new logvendadiflogfin();
            logvendadiflogfin.Show();
        }

        private void logVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertLogVenda insertLogVenda = new InsertLogVenda();
            insertLogVenda.Show();
        }

        private void duplicidadeValorDiferenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDuplicidadeRV form = new FormDuplicidadeRV();
            form.Show();
        }

        private void logFinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertLogFin form = new InsertLogFin();
            form.Show();
        }

        private void logVendaELogFinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertLogVendaFin form = new InsertLogVendaFin();
            form.Show();
        }
    }
}
