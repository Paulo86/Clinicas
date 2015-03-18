using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmConsultorioCadastro : Form
    {
        Action actionGeneral;

        private void cbbEstadoLoad()
        {
            try
            {
                var negocios = new EstadoBUS();
                this.cbbEstado.ValueMember = "CodigoEstado";
                this.cbbEstado.DisplayMember = "NomeEstado";
                this.cbbEstado.DataSource = negocios.EstadoLista();
                this.cbbEstado.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbbStatusLoad()
        {
            try
            {
                var negocios = new StatusBUS();
                this.cbbStatus.ValueMember = "CodigoStatus";
                this.cbbStatus.DisplayMember = "Status";
                this.cbbStatus.DataSource = new StatusBUS().StatusLista();//negocios.StatusLista();
                this.cbbStatus.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbbPessoaTipoLoad()
        {
            try
            {
                this.cbbTipoPessoa.ValueMember = "CodigoPessoaTipo";
                this.cbbTipoPessoa.DisplayMember = "TipoPessoa";
                this.cbbTipoPessoa.DataSource = new PessoaTipoBUS().PessoaTipoLista();
                this.cbbTipoPessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbbCidadeLoad(int CodigoEstado)
        {
            try
            {
                this.cbbCidade.ValueMember = "Codigo";
                this.cbbCidade.DisplayMember = "NomeCidade";
                this.cbbCidade.DataSource = new CidadeBUS().CidadeLista(CodigoEstado);
                this.cbbCidade.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CarregarTela(ConsultorioMOD consultorio)
        {
            try
            {
                this.txtCodigo.Text = consultorio.Pessoa.CodigoPessoa.ToString();
                this.cbbStatus.SelectedValue = consultorio.Status.CodigoStatus;
                this.cbbTipoPessoa.SelectedValue = consultorio.Pessoa.PessoaTipo.CodigoPessoaTipo;
                this.txtRazaoSocial.Text = consultorio.RazaoSocial;
                this.txtNomeFantasia.Text = consultorio.NomeFantasia;
                this.txtCpfCnpj.Text = consultorio.CpfCnpj;
                this.txtRgIe.Text = consultorio.RgIE;
                this.txtTelefone.Text = consultorio.Telefone;
                this.txtFax.Text = consultorio.Fax;
                this.txtEmail.Text = consultorio.Email;
                this.txtCep.Text = consultorio.Cep;
                this.txtEndereco.Text = consultorio.Endereco;
                this.txtNumero.Text = consultorio.Numero;
                this.txtComplemento.Text = consultorio.Complemento;
                this.cbbEstado.SelectedValue = consultorio.Cidade.Estado.CodigoEstado;
                this.cbbCidadeLoad(Convert.ToInt32(this.cbbEstado.SelectedValue));
                this.cbbCidade.SelectedValue = consultorio.Cidade.Codigo;
                this.txtNomeContato.Text = consultorio.NomeContato;
                this.txtTelefoneContato.Text = consultorio.TelefoneContato;
                this.txtCelularContato.Text = consultorio.CelularContato;
                this.txtEmailContato.Text = consultorio.EmailContato;
                this.txtObservacao.Text = consultorio.Observacao;
                this.txtBairro.Text = consultorio.NomeBairro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ConsultorioMOD carregarConsultorioMOD()
        {
            try
            {
                var consultorio = new ConsultorioMOD();
                consultorio.Status.CodigoStatus = Convert.ToInt32(this.cbbStatus.SelectedValue);
                consultorio.Pessoa.PessoaTipo.CodigoPessoaTipo = Convert.ToInt32(this.cbbTipoPessoa.SelectedValue);
                consultorio.RazaoSocial = this.txtRazaoSocial.Text;
                consultorio.NomeFantasia = this.txtNomeFantasia.Text;
                consultorio.CpfCnpj = this.txtCpfCnpj.Text;
                consultorio.RgIE = this.txtRgIe.Text;
                consultorio.Telefone = this.txtTelefone.Text;
                consultorio.Fax = this.txtFax.Text;
                consultorio.Email = this.txtEmail.Text;
                consultorio.Cep = this.txtCep.Text;
                consultorio.Cidade.Codigo = Convert.ToInt32(this.cbbCidade.SelectedValue);
                consultorio.Endereco = this.txtEndereco.Text;
                consultorio.Numero = this.txtNumero.Text;
                consultorio.NomeBairro = this.txtBairro.Text;
                consultorio.Complemento = this.txtComplemento.Text;
                consultorio.NomeContato = this.txtNomeContato.Text;
                consultorio.CelularContato = this.txtCelularContato.Text;
                consultorio.EmailContato = this.txtEmailContato.Text;
                consultorio.TelefoneContato = this.txtTelefoneContato.Text;
                consultorio.Observacao = this.txtObservacao.Text;
                consultorio.Cidade.Estado.CodigoEstado = Convert.ToInt32(this.cbbEstado.SelectedValue);
                if (!string.IsNullOrEmpty(this.txtCodigo.Text.Trim()))
                    consultorio.Pessoa.CodigoPessoa = Convert.ToInt32(this.txtCodigo.Text);

                return consultorio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DesableControls()
        {
            try
            {
                this.txtCodigo.ReadOnly = true;
                this.cbbStatus.Enabled = false;
                this.cbbTipoPessoa.Enabled = false;
                this.txtRazaoSocial.ReadOnly = true;
                this.txtNomeFantasia.ReadOnly = true;
                this.txtCpfCnpj.ReadOnly = true;
                this.txtRgIe.ReadOnly = true;
                this.txtTelefone.ReadOnly = true;
                this.txtFax.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtCep.ReadOnly = true;
                this.txtEndereco.ReadOnly = true;
                this.txtNumero.ReadOnly = true;
                this.txtComplemento.ReadOnly = true;
                this.cbbEstado.Enabled = false;
                this.cbbCidade.Enabled = false;
                this.txtNomeContato.ReadOnly = true;
                this.txtTelefoneContato.ReadOnly = true;
                this.txtCelularContato.ReadOnly = true;
                this.txtEmailContato.ReadOnly = true;
                this.txtObservacao.ReadOnly = true;
                this.txtBairro.ReadOnly = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmConsultorioCadastro(ConsultorioMOD consultorio, Action action)
        {
            try
            {
                InitializeComponent();
                actionGeneral = action;
                this.cbbEstadoLoad();
                this.cbbStatusLoad();
                this.cbbPessoaTipoLoad();
                switch (action)
                {
                    case Action.Add:
                        this.lblTitulo.Text = "Cadastrar Consultório";
                        break;
                    case Action.Edit:
                        this.lblTitulo.Text = "Editar Cadastro Consultório";
                        this.CarregarTela(consultorio);
                        break;
                    case Action.Delete:
                        break;
                    case Action.Details:
                        this.lblTitulo.Text = "Detalhes do Cadastro de Consultório";
                        this.CarregarTela(consultorio);
                        this.DesableControls();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar Formuário\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        #region Manipulação do Evento Enter dos Controles

        private void cmmTipoPessoa_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Tipo de Pessoa";
        }

        private void cbbStatus_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Status do Consultorio";
        }

        private void txtRazaoSocial_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe a Razão Social";
        }

        private void txtNomeFantasia_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome Fantasia";
        }

        private void txtCpfCnpj_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o CPF ou CNPJ";
        }

        private void txtRgIe_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o RG ou IE";
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Telefone Principal";
        }

        private void txtFax_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Telefone para Fax";
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o E-Mail";
        }

        private void txtCep_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o CEP";
        }

        private void cbbEstado_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione um Estado ou Digite o Nome";
        }

        private void cbbCidade_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione uma Cidade ou Digite o Nome";
            try
            {
                if (this.cbbEstado.SelectedIndex != -1)
                    this.cbbCidadeLoad(Convert.ToInt32(this.cbbEstado.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEndereco_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Infome o Endereço";
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome do Bairro";
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Número";
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Complemento do Endereço";
        }

        private void txtNomeContato_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome do Contato na Clinica";
        }

        private void txtEmailContato_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o E-Mail do Contato";
        }

        private void txtTelefoneContato_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Telefone do Contato";
        }

        private void txtCelularContato_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Celular do Contato";
        }

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe a Observação";
        }
        #endregion

        private void txtCpfCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else if (cbbTipoPessoa.SelectedIndex == -1)
            {
                e.Handled = true;
                cbbTipoPessoa.Focus();
                MessageBox.Show("Selecione o Tipo de Pessoa !", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                #region Mascara Dinamica para CNPJ

                if (cbbTipoPessoa.Text == "Jurídica" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtCpfCnpj.MaxLength = 18;
                    if (txtCpfCnpj.Text.Length == 2)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 3;
                    }
                    else if (txtCpfCnpj.Text.Length == 6)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 7;
                    }
                    else if (txtCpfCnpj.Text.Length == 10)
                    {
                        txtCpfCnpj.Text += '/';
                        txtCpfCnpj.SelectionStart = 11;
                    }
                    else if (txtCpfCnpj.Text.Length == 15)
                    {
                        txtCpfCnpj.Text += '-';
                        txtCpfCnpj.SelectionStart = 16;
                    }
                }

                #endregion

                #region Mascara Dinamica para CPF

                else if (cbbTipoPessoa.Text == "Física" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtCpfCnpj.MaxLength = 14;

                    if (txtCpfCnpj.Text.Length == 3)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 4;
                    }
                    else if (txtCpfCnpj.Text.Length == 7)
                    {
                        txtCpfCnpj.Text += '.';
                        txtCpfCnpj.SelectionStart = 8;
                    }
                    else if (txtCpfCnpj.Text.Length == 11)
                    {
                        txtCpfCnpj.Text += '-';
                        txtCpfCnpj.SelectionStart = 12;
                    }
                }

                #endregion
            }
        }

        private void txtRgIe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else if (cbbTipoPessoa.SelectedIndex == -1)
            {
                e.Handled = true;
                cbbTipoPessoa.Focus();
                MessageBox.Show("Selecione o Tipo de Pessoa !", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                #region Mascara Dinamica para IE
                if (cbbTipoPessoa.Text == "Jurídica" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtRgIe.MaxLength = 15;
                    if (txtRgIe.Text.Length == 3)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 4;
                    }
                    else if (txtRgIe.Text.Length == 7)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 8;
                    }
                    else if (txtRgIe.Text.Length == 11)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 12;
                    }
                }
                #endregion

                #region Mascara Dinamica para RG
                else if (cbbTipoPessoa.Text == "Física" && e.KeyChar != Convert.ToChar(Keys.Back))
                {
                    txtRgIe.MaxLength = 12;
                    if (txtRgIe.Text.Length == 2)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 3;
                    }
                    else if (txtRgIe.Text.Length == 6)
                    {
                        txtRgIe.Text += '.';
                        txtRgIe.SelectionStart = 7;
                    }
                    else if (txtRgIe.Text.Length == 10)
                    {
                        txtRgIe.Text += '-';
                        txtRgIe.SelectionStart = 11;
                    }
                }
                #endregion
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtTelefone.MaxLength = 13;
                if (txtTelefone.Text.Length == 0)
                {
                    txtTelefone.Text += '(';
                    txtTelefone.SelectionStart = 2;
                }
                else if (txtTelefone.Text.Length == 3)
                {
                    txtTelefone.Text += ')';
                    txtTelefone.SelectionStart = 4;
                }
                else if (txtTelefone.Text.Length == 8)
                {
                    txtTelefone.Text += '-';
                    txtTelefone.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtFax.MaxLength = 13;
                if (txtFax.Text.Length == 0)
                {
                    txtFax.Text += '(';
                    txtFax.SelectionStart = 2;
                }
                else if (txtFax.Text.Length == 3)
                {
                    txtFax.Text += ')';
                    txtFax.SelectionStart = 4;
                }
                else if (txtFax.Text.Length == 8)
                {
                    txtFax.Text += '-';
                    txtFax.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica para CEP
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtCep.MaxLength = 9;
                if (txtCep.Text.Length == 5)
                {
                    txtCep.Text += '-';
                    txtCep.SelectionStart = 6;
                }
            }
            #endregion
        }

        private void cbbTipoPessoa_DropDown(object sender, EventArgs e)
        {
            this.txtCpfCnpj.Clear();
            this.txtRgIe.Clear();
        }

        private void txtTelefoneContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtTelefoneContato.MaxLength = 13;
                if (txtTelefoneContato.Text.Length == 0)
                {
                    txtTelefoneContato.Text += '(';
                    txtTelefoneContato.SelectionStart = 2;
                }
                else if (txtTelefoneContato.Text.Length == 3)
                {
                    txtTelefoneContato.Text += ')';
                    txtTelefoneContato.SelectionStart = 4;
                }
                else if (txtTelefoneContato.Text.Length == 8)
                {
                    txtTelefoneContato.Text += '-';
                    txtTelefoneContato.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void txtCelularContato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtCelularContato.MaxLength = 13;
                if (txtCelularContato.Text.Length == 0)
                {
                    txtCelularContato.Text += '(';
                    txtCelularContato.SelectionStart = 2;
                }
                else if (txtCelularContato.Text.Length == 3)
                {
                    txtCelularContato.Text += ')';
                    txtCelularContato.SelectionStart = 4;
                }
                else if (txtCelularContato.Text.Length == 8)
                {
                    txtCelularContato.Text += '-';
                    txtCelularContato.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void cbbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbCidade.SelectedIndex = -1;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = "";
                var negocios = new ConsultorioBUS();
                negocios.ValidaDados(this.carregarConsultorioMOD());

                if (actionGeneral.Equals(Action.Add))
                {
                    retorno = negocios.Inserir(this.carregarConsultorioMOD());
                    if (Char.IsNumber(retorno, 0))
                    {
                        this.txtCodigo.Text = retorno;
                        MessageBox.Show("Consutório Cadastrado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult.Equals(DialogResult.Yes);
                    }
                    else
                    {
                        this.DialogResult.Equals(DialogResult.No);
                        throw new Exception(retorno);
                    }
                }
                else if (actionGeneral.Equals(Action.Edit))
                {
                    retorno = negocios.Atualizar(this.carregarConsultorioMOD());
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Cadastro de Consultório Atualizado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult.Equals(DialogResult.Yes);
                    }
                    else
                    {
                        this.DialogResult.Equals(DialogResult.No);
                        throw new Exception(retorno);
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
