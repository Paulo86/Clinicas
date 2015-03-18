using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmServicoCadastro : Form
    {
        private ServicoMOD servicoLoadObj()
        {
            try
            {
                Int32 Codigo = 0;
                if (!this.txtCodigo.Text.Trim().Equals(string.Empty))
                    Codigo = Convert.ToInt32(this.txtCodigo.Text);

                return new ServicoMOD
                {
                    CodigoServico = Codigo,
                    Descricao = this.txtDescricao.Text,
                    Valor = Convert.ToDecimal(this.txtValor.Text)
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void servicoLoadTela(ServicoMOD servico)
        {
            try
            {
                this.txtCodigo.Text = servico.CodigoServico.ToString();
                this.txtDescricao.Text = servico.Descricao;
                this.txtValor.Text = servico.Valor.ToString("N2");
            }
            catch (Exception)
            {

                throw;
            }
        }

        Action actionDefault;

        public FrmServicoCadastro(Action action, ServicoMOD servico)
        {
            actionDefault = action;

            InitializeComponent();

            switch (action)
            {
                case Action.Add:
                    this.lblTitulo.Text = "Cadastro de Novo Serviço";
                    break;
                case Action.Edit:
                    this.lblTitulo.Text = "Editar Cadastro de Serviço";
                    this.servicoLoadTela(servico);
                    break;
                case Action.Details:
                    this.lblTitulo.Text = "Detalhes do Cadastro de Serviço";
                    this.servicoLoadTela(servico);
                    this.btnAdicionar.Visible = false;
                    break;
            }
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Código do Serviço";
        }

        private void txtStatus_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Status do Serviço";
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe a Descrição do Servico";
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Valor á ser Cobrado";
        }

        private void txtQuantidadeDias_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe a quantidade de Dias/Visitas para conclusão";
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != ',')
                e.Handled = true;
        }

        private void txtQuantidadeDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
                e.Handled = true;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = "";
                var negocios = new ServicoBUS();

                if (actionDefault == Action.Add)
                {
                    retorno = negocios.Inserir(this.servicoLoadObj());
                    if (!Char.IsNumber(retorno, 0)) { throw new Exception(retorno); }
                    else
                    {
                        this.txtCodigo.Text = retorno;
                        MessageBox.Show("Serviço Cadastrado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (actionDefault == Action.Edit)
                {
                    retorno = negocios.Atualizar(this.servicoLoadObj());
                    if (!Char.IsNumber(retorno, 0)) { throw new Exception(retorno); }
                    else
                    {
                        MessageBox.Show("Serviço Atualizado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
