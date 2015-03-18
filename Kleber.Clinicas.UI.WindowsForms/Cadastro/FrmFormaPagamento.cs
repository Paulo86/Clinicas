using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Windows.Forms;


namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmFormaPagamento : Form
    {
        /// <CarregaObjeto>
        /// Carrega o objeto Forma de pagamento com os dados do formulário
        /// </CarregaObjeto>
        /// <returns></returns>
        private FormaPagamentoMOD CarregarFormaPagamento()
        {
            return new FormaPagamentoMOD
            {
                Codigo = Convert.ToInt32(gdvPrincipal.CurrentRow.Cells[0].Value),
                Descricao = gdvPrincipal.CurrentRow.Cells[1].Value.ToString()
            };
        }

        private void CarregarGrid()
        {
            try
            {
                this.gdvPrincipal.DataSource = new FormaPagamentoBUS().FormaPagamentoListByAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmFormaPagamento()
        {
            InitializeComponent();
            try
            {
                this.CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmFormaPagamentoCadastro frmFormaPagamentoCadastro = new FrmFormaPagamentoCadastro(Action.Add, this.CarregarFormaPagamento());
            DialogResult dialogo = frmFormaPagamentoCadastro.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmFormaPagamentoCadastro frmFormaPagamentoCadastro = new FrmFormaPagamentoCadastro(Action.Edit, this.CarregarFormaPagamento());
            DialogResult dialogo = frmFormaPagamentoCadastro.ShowDialog();
            this.CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogo =
            MessageBox.Show("Confirma a exclusão desse registro ?", "Responda", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dialogo.Equals(DialogResult.No))
                {
                    return;
                }
                else
                {
                    var retorno = new FormaPagamentoBUS().Excluir(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Forma de pagamento excluida com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CarregarGrid();
                    }
                    else
                    {
                        throw new Exception(retorno);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar excluir dados\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            FrmFormaPagamentoCadastro frmFormaPagamentoCadastro = new FrmFormaPagamentoCadastro(Action.Details, this.CarregarFormaPagamento());
            DialogResult dialogo = frmFormaPagamentoCadastro.ShowDialog();
        }
    }
}
