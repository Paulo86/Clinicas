using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kleber.Clinicas.UI.WindowsForms.Cadastro;
using Kleber.Clinicas.UI.WindowsForms.Cadastro.Financeiro;
using Kleber.Clinicas.UI.WindowsForms.Cadastro.Financeiro.Orcamento;

namespace Kleber.Clinicas.UI.WindowsForms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            lblData.Text = "Data do Sistema: " + DateTime.Now.ToShortDateString();
        }

        private void consultórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultorio frmConsultorio = new FrmConsultorio();
            frmConsultorio.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.ShowDialog();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmServico = new FrmServico();
            frmServico.ShowDialog();
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMedico = new FrmMedico();
            frmMedico.ShowDialog();
        }

        private void formasDePagamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFormaPagamento frmFormaPagamento = new FrmFormaPagamento();
            DialogResult dialogo = frmFormaPagamento.ShowDialog();
        }

        private void orçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrcamentoCadastro frmOrcamentoCadastro = new FrmOrcamentoCadastro(Action.Add);
            DialogResult dialogo = frmOrcamentoCadastro.ShowDialog();
        }
    }
}
