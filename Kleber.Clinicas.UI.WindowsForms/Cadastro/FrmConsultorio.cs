using Kleber.Clinicas.Business.Cadastro;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmConsultorio : Form
    {
        private void CarregarGrid()
        {
            try
            {
                var ConsultorioLista = new ConsultorioBUS().ListaGridPrincipal();
                this.gdvPrincipal.DataSource = ConsultorioLista.Select(x => new
                {
                    RazaoSocial = x.RazaoSocial,
                    NomeFantasia = x.NomeFantasia,
                    Telefone = x.Telefone,
                    NomeContato = x.NomeContato,
                    Endereco = x.Endereco,
                    CodigoPessoa = x.Pessoa.CodigoPessoa
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public FrmConsultorio()
        {
            InitializeComponent();
            this.gdvPrincipal.AutoGenerateColumns = false;
            try
            {
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmConsultorioCadastro frmConultorioCadastro = new FrmConsultorioCadastro(null, Action.Add);
            frmConultorioCadastro.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var consultorio = new ConsultorioBUS().Detalhes(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                FrmConsultorioCadastro frmConultorioCadastro = new FrmConsultorioCadastro(consultorio, Action.Edit);
                frmConultorioCadastro.ShowDialog();
                this.CarregarGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resposta = MessageBox.Show("Confirma a Exclusão deste Registro ?", "Responda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resposta.Equals(DialogResult.No))
                    return;
                else
                {
                    String retorno = new ConsultorioBUS().Excluir(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Consultório Excluido com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CarregarGrid();
                    }
                    else
                        throw new Exception(retorno);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brnDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                var consultorio = new ConsultorioBUS().Detalhes(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                FrmConsultorioCadastro frmConultorioCadastro = new FrmConsultorioCadastro(consultorio, Action.Details);
                frmConultorioCadastro.ShowDialog();
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
