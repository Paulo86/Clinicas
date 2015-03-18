using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmCliente : Form
    {
        private void CarregarGrid()
        {
            try
            {
                this.gdvPrincipal.DataSource = new ClienteBUS().ClienteLista().Select(x => new
                {
                    CodigoCliente = x.Pessoa.CodigoPessoa,
                    Endereco = x.Endereco,
                    Status = x.Status.Status,
                    Complemento = x.Complemento,
                    Celular = x.Celular,
                    Telefone = x.Telefone,
                    NomeCompleto = x.NomeCompleto
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ClienteMOD CarregarCliente()
        {
            try
            {
                return new ClienteBUS().ClienteByID(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmCliente()
        {
            InitializeComponent();
            try
            {
                this.gdvPrincipal.AutoGenerateColumns = false;
                this.CarregarGrid();
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
                var frmClienteCadastro = new FrmClienteCadastro(Action.Add, null);
                frmClienteCadastro.ShowDialog();
                this.CarregarGrid();
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
                if (this.gdvPrincipal.SelectedRows.Count == 0)
                    MessageBox.Show("Nenhum Cliente Selecionado para Edição", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    var frmClienteCadastro = new FrmClienteCadastro(Action.Edit, this.CarregarCliente());
                    frmClienteCadastro.ShowDialog();
                    this.CarregarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (this.gdvPrincipal.SelectedRows.Count == 0)
                MessageBox.Show("Nenhum Cliente Selecionado para Exclusão !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                DialogResult resposta = MessageBox.Show("Confirma a Exclusão Desse Registro ?", "Responda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta.Equals(DialogResult.No)) { return; }
                else
                {
                    var retorno = new ClienteBUS().Excluir(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                    if (!char.IsNumber(retorno, 0))
                        throw new Exception(retorno);
                    else
                    {
                        MessageBox.Show("Cliente Excluido com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CarregarGrid();
                    }
                }

            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gdvPrincipal.SelectedRows.Count == 0)
                    MessageBox.Show("Nenhum Cliente Selecionado para visualização de Detalhes !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    var frmClienteCadastro = new FrmClienteCadastro(Action.Details, this.CarregarCliente());
                    frmClienteCadastro.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNomeCliente_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome do Cliente para pesquisar";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.gdvPrincipal.DataSource = new ClienteBUS().ClienteListaByDesc(this.txtNomeCliente.Text).Select(x => new
                {
                    CodigoCliente = x.Pessoa.CodigoPessoa,
                    Endereco = x.Endereco,
                    Status = x.Status.Status,
                    Complemento = x.Complemento,
                    Celular = x.Celular,
                    Telefone = x.Telefone,
                    NomeCompleto = x.NomeCompleto
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CarregarGrid();
            }
        }
    }
}
