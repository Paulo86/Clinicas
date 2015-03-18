using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmFormaPagamentoCadastro : Form
    {
        Action action = new Action();

        private FormaPagamentoMOD CarregarFormadePagamentoMOD()
        {
            Int32 codigo = 0;
            if (this.txtCodigo.Text == String.Empty)
            {
                codigo = 0;
            }
            else
            {
                codigo = Convert.ToInt32(txtCodigo.Text);
            }
            return new FormaPagamentoMOD
            {
                Codigo = codigo,
                Descricao = this.txtDescricao.Text
            };
        }

        public FrmFormaPagamentoCadastro(Action AcaoNaTela, FormaPagamentoMOD FormaPagamento)
        {
            action = AcaoNaTela;            
            InitializeComponent();
            this.txtDescricao.Focus();
            try
            {
                switch (AcaoNaTela)
                {
                    case Action.Add:
                        this.lblTitulo.Text = "Cadastrar forma de pagamento";
                        break;
                    case Action.Edit:
                        this.lblTitulo.Text = "Alerar cadastrar forma de pagamento";
                        this.txtCodigo.Text = FormaPagamento.Codigo.ToString();
                        this.txtDescricao.Text = FormaPagamento.Descricao;
                        break;
                    case Action.Details:
                        this.lblTitulo.Text = "Detalhes do cadastro de forma de pagamento";
                        this.txtDescricao.ReadOnly = true;
                        this.txtCodigo.Text = FormaPagamento.Codigo.ToString();
                        this.txtDescricao.Text = FormaPagamento.Descricao;
                        this.btnAdicionar.Visible = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            String msgErro = String.Empty;
            String retorno = String.Empty;
            try
            {
                switch (action)
                {
                    case Action.Add:
                        retorno = new FormaPagamentoBUS().Inserir(this.CarregarFormadePagamentoMOD());
                        if (Char.IsNumber(retorno, 0))
                        {
                            MessageBox.Show("Forma de pagamento cadastrada com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtCodigo.Text = retorno;
                        }
                        else
                        {
                            msgErro = "Erro ao Inserir novo registro ";
                            throw new Exception(retorno);
                        }
                        break;
                    case Action.Edit:
                        retorno = new FormaPagamentoBUS().Atualizar(this.CarregarFormadePagamentoMOD());
                        if (Char.IsNumber(retorno, 0))
                        {
                            MessageBox.Show("Forma de pagamento atualizada com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            msgErro = "Erro ao Atualizar registro ";
                            throw new Exception(retorno);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(msgErro + "\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmFormaPagamentoCadastro_Load(object sender, EventArgs e)
        {
            this.txtDescricao.Focus();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
