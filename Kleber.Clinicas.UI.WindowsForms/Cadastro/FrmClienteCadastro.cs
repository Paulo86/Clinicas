using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmClienteCadastro : Form
    {
        Action actionDefault;

        private void cbbLoad()
        {
            try
            {
                this.cbbStatus.DisplayMember = "Status";
                this.cbbStatus.ValueMember = "CodigoStatus";
                this.cbbStatus.DataSource = new StatusBUS().StatusLista();
                this.cbbStatus.SelectedIndex = -1;

                this.cbbSexo.DisplayMember = "Sexo";
                this.cbbSexo.ValueMember = "CodigoSexo";
                this.cbbSexo.DataSource = new SexoBUS().SexoLista();
                this.cbbSexo.SelectedIndex = -1;

                this.cbbEstado.DisplayMember = "NomeEstado";
                this.cbbEstado.ValueMember = "CodigoEstado";
                this.cbbEstado.DataSource = new EstadoBUS().EstadoLista();
                this.cbbEstado.SelectedIndex = -1;
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
                if (cbbEstado.SelectedIndex == -1)
                    throw new Exception("Selecione o Estado para Prosseguir !");
                else
                {
                    this.cbbCidade.ValueMember = "Codigo";
                    this.cbbCidade.DisplayMember = "NomeCidade";
                    this.cbbCidade.DataSource = new CidadeBUS().CidadeLista(CodigoEstado);
                    this.cbbCidade.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ClienteMOD CarregarClienteObject()
        {
            try
            {
                int codigoCliente = 0;
                if (!this.txtCodigo.Text.Trim().Equals(String.Empty))
                    codigoCliente = Convert.ToInt32(this.txtCodigo.Text);
                
                return new ClienteMOD
                {
                    Celular = this.txtCelular.Text,
                    Cep = this.txtCep.Text,
                    Cidade = new CidadeMOD
                    {
                        Codigo = Convert.ToInt32(this.cbbCidade.SelectedValue),
                        Estado = new EstadoMOD
                        {
                            CodigoEstado = Convert.ToInt32(this.cbbEstado.SelectedValue)
                        }
                    },
                    Complemento = this.txtComplemento.Text,
                    Cpf = this.txtCpf.Text,
                    DataEmissaoRg = Convert.ToDateTime(this.dtpDataEmissaoRg.Value),
                    DataNascimento = Convert.ToDateTime(this.dtpDataNascimento.Value),
                    Email = this.txtEmail.Text,
                    Endereco = this.txtEndereco.Text,
                    NomeBairro = this.txtBairro.Text,
                    NomeCompleto = this.txtNomeCompleto.Text,
                    Numero = this.txtNumero.Text,
                    PrimeiroNome = this.txtNome.Text,
                    Rg = this.txtRg.Text,
                    Sexo = new SexoMOD
                    {
                        CodigoSexo = Convert.ToInt32(this.cbbSexo.SelectedValue)
                    },
                    SobreNome = this.txtSobreNome.Text,
                    Status = new StatusMOD
                    {
                        CodigoStatus = Convert.ToInt32(this.cbbStatus.SelectedValue)
                    },
                    Telefone = this.txtTelefoneResidencial.Text,
                    Pessoa = new PessoaMOD
                    {
                        CodigoPessoa = codigoCliente,
                        PessoaTipo = new PessoaTipoMOD
                        {
                             CodigoPessoaTipo = 1
                        }
                    }
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CarregarClienteTela(ClienteMOD cliente)
        {
            try
            {
                this.txtCodigo.Text = cliente.Pessoa.CodigoPessoa.ToString();
                this.cbbStatus.SelectedValue = cliente.Status.CodigoStatus;
                this.cbbSexo.SelectedValue = cliente.Sexo.CodigoSexo;
                this.cbbEstado.SelectedValue = cliente.Cidade.Estado.CodigoEstado;
                this.cbbCidadeLoad(Convert.ToInt32(this.cbbEstado.SelectedValue));
                this.cbbCidade.SelectedValue = cliente.Cidade.Codigo;
                this.txtNome.Text = cliente.PrimeiroNome;
                this.txtSobreNome.Text = cliente.SobreNome;
                this.txtNomeCompleto.Text = cliente.NomeCompleto;
                this.txtRg.Text = cliente.Rg;
                this.dtpDataEmissaoRg.Value = cliente.DataEmissaoRg;
                this.dtpDataNascimento.Value = cliente.DataNascimento;
                this.txtCpf.Text = cliente.Cpf;
                this.txtTelefoneResidencial.Text = cliente.Telefone;
                this.txtCelular.Text = cliente.Celular;
                this.txtEmail.Text = cliente.Email;
                this.txtCep.Text = cliente.Cep;
                this.txtEndereco.Text = cliente.Endereco;
                this.txtNumero.Text = cliente.Numero;
                this.txtComplemento.Text = cliente.Complemento;
                this.txtBairro.Text = cliente.NomeBairro;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmClienteCadastro(Action action, ClienteMOD cliente)
        {
            InitializeComponent();
            actionDefault = action;
            try
            {
                this.cbbLoad();
                switch (action)
                {
                    case Action.Add:
                        this.lblTitulo.Text = "Cadastro de Novo Cliente";
                        break;
                    case Action.Edit:
                        this.lblTitulo.Text = "Editar Cadastro de Cliente";
                        this.CarregarClienteTela(cliente);
                        break;
                    case Action.Delete:
                        break;
                    case Action.Details:
                        this.lblTitulo.Text = "Detalhes do Cadastro do Cliente";
                        this.CarregarClienteTela(cliente);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Manipulação do Evento Enter dos controles
        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Código do Cliente";
        }

        private void cbbStatus_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Status do Cliente";
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome do Cliente";
        }

        private void cbbSexo_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Sexo do Cliente";
        }

        private void txtNomeCompleto_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome Completo do Cliente";
        }

        private void txtRg_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Número do Rg";
        }

        private void dtpDataEmissaoRg_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe da Data de Emissão do Rg";
        }

        private void dtpDataNascimento_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "informe da Data de Nascimento";
        }

        private void txtTelefoneResidencial_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Telefone Telefone Residencial";
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Celular";
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Email";
        }

        private void txtCep_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o CEP";
        }

        private void cbbEstado_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione ou Digite o Nome do Estado";
        }

        private void cbbCidade_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione ou digite o Nome da Cidade";
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
            this.lblAjuda.Text = "Informe o Endereço";
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome do Bairro";
        }

        private void txtNumero_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Infome o Numero";
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Complemento do Endereço";
        }

        private void txtSobreNome_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Sobrenome do Cliente";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Manipulação do Evento KeyPress

        private void txtRg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                txtRg.MaxLength = 12;
                if (txtRg.Text.Length == 2)
                {
                    txtRg.Text += '.';
                    txtRg.SelectionStart = 3;
                }
                else if (txtRg.Text.Length == 6)
                {
                    txtRg.Text += '.';
                    txtRg.SelectionStart = 7;
                }
                else if (txtRg.Text.Length == 10)
                {
                    txtRg.Text += '-';
                    txtRg.SelectionStart = 11;
                }
            }

        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                txtCpf.MaxLength = 14;

                if (txtCpf.Text.Length == 3)
                {
                    txtCpf.Text += '.';
                    txtCpf.SelectionStart = 4;
                }
                else if (txtCpf.Text.Length == 7)
                {
                    txtCpf.Text += '.';
                    txtCpf.SelectionStart = 8;
                }
                else if (txtCpf.Text.Length == 11)
                {
                    txtCpf.Text += '-';
                    txtCpf.SelectionStart = 12;
                }
            }
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

        private void txtTelefoneResidencial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtTelefoneResidencial.MaxLength = 13;
                if (txtTelefoneResidencial.Text.Length == 0)
                {
                    txtTelefoneResidencial.Text += '(';
                    txtTelefoneResidencial.SelectionStart = 2;
                }
                else if (txtTelefoneResidencial.Text.Length == 3)
                {
                    txtTelefoneResidencial.Text += ')';
                    txtTelefoneResidencial.SelectionStart = 4;
                }
                else if (txtTelefoneResidencial.Text.Length == 8)
                {
                    txtTelefoneResidencial.Text += '-';
                    txtTelefoneResidencial.SelectionStart = 9;
                }
            }
            #endregion
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            #region Mascara Dinamica de Telefone
            if (e.KeyChar != Convert.ToChar(Keys.Back))
            {
                txtCelular.MaxLength = 13;
                if (txtCelular.Text.Length == 0)
                {
                    txtCelular.Text += '(';
                    txtCelular.SelectionStart = 2;
                }
                else if (txtCelular.Text.Length == 3)
                {
                    txtCelular.Text += ')';
                    txtCelular.SelectionStart = 4;
                }
                else if (txtCelular.Text.Length == 8)
                {
                    txtCelular.Text += '-';
                    txtCelular.SelectionStart = 9;
                }
            }
            #endregion
        }
        #endregion

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = "";
                var negocios = new ClienteBUS();
                negocios.ValidarCliente(this.CarregarClienteObject());


                switch (actionDefault)
                {
                    case Action.Add:
                        retorno = negocios.Inserir(this.CarregarClienteObject());
                        if (!Char.IsNumber(retorno, 0))
                            throw new Exception(retorno);
                        else
                        {
                            MessageBox.Show("Cliente Cadastrado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtCodigo.Text = retorno;
                            this.actionDefault = Action.Edit;
                        }
                        break;
                    case Action.Edit:
                        retorno = negocios.Atualizar(this.CarregarClienteObject());
                        if (!Char.IsNumber(retorno, 0))
                            throw new Exception(retorno);
                        else
                        {
                            MessageBox.Show("Cliente Atualizado com Sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            this.actionDefault.Equals(Action.Edit);
                        }                                
                        break;
                    case Action.Details:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Gravar Informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
