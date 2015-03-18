using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmMedico : Form
    {
        private void GridPricipalLoad()
        {
            try
            {
                this.gdvPrincipal.DataSource = new MedicoBUS().MedicoList().Select(x => new
                {
                    Codigo = x.Pessoa.CodigoPessoa,
                    Nome = x.NomeMedico,
                    Telefone = x.Telefone,
                    Celular = x.Celular
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private MedicoMOD MedicoLoad()
        {
            try
            {
                if (this.gdvPrincipal.Rows.Count == 0)
                    throw new Exception("Selecione um médico para continuar !");
                else
                    return new MedicoBUS().MedicoById(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmMedico()
        {
            InitializeComponent();
            this.gdvPrincipal.AutoGenerateColumns = false;
            try
            {
                this.GridPricipalLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var frmMedicoCadastro = new FrmMedicoCadastro(Action.Edit, this.MedicoLoad());
                frmMedicoCadastro.ShowDialog();
                this.GridPricipalLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resposta = MessageBox.Show("Confirma a Exclusão deste registro ?", "Responda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (!resposta.Equals(DialogResult.Yes)) { return; }
                else
                {
                    if (this.gdvPrincipal.Rows.Count == 0) { throw new Exception("Nenhum médico selecionado !"); }
                    else
                    {
                        var retorno = new MedicoBUS().Excluir(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                        if (!Char.IsNumber(retorno, 0)) { throw new Exception(retorno); }
                        else
                        {
                            MessageBox.Show("Registro Excluido com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.GridPricipalLoad();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                var frmMedicoCadastro = new FrmMedicoCadastro(Action.Details, this.MedicoLoad());
                frmMedicoCadastro.ShowDialog();
                this.GridPricipalLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var frmMedicoCadastro = new FrmMedicoCadastro(Action.Add, null);
                frmMedicoCadastro.ShowDialog();
                this.GridPricipalLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
