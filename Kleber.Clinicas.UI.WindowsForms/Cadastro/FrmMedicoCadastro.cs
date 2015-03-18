using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmMedicoCadastro : Form
    {
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

                this.cbbConsultorio.DisplayMember = "Consultorio";
                this.cbbConsultorio.ValueMember = "Codigo";
                this.cbbConsultorio.DataSource = new ConsultorioBUS().ListaGridPrincipal().Select(x => new
                {
                    Codigo = x.Pessoa.CodigoPessoa,
                    Consultorio = x.RazaoSocial
                }).ToList();
                this.cbbConsultorio.SelectedIndex = -1;
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

        private MedicoMOD MedicoLoad()
        {
            try
            {
                var codigoMedico = 0;
                if (!this.txtCodigo.Text.Trim().Equals(String.Empty))
                    codigoMedico = Convert.ToInt32(this.txtCodigo.Text);
                return new MedicoMOD
                {
                    Pessoa = new PessoaMOD
                    {
                        CodigoPessoa = codigoMedico
                    },
                    Consultorio = new ConsultorioMOD
                    {
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(this.cbbConsultorio.SelectedValue)
                        }
                    },
                    Sexo = new SexoMOD
                    {
                        CodigoSexo = Convert.ToInt32(this.cbbSexo.SelectedValue)
                    },
                    Cidade = new CidadeMOD
                    {
                        Codigo = Convert.ToInt32(this.cbbCidade.SelectedValue)
                    },
                    Status = new StatusMOD
                    {
                        CodigoStatus = Convert.ToInt32(this.cbbStatus.SelectedValue)
                    },
                    Bairro = this.txtBairro.Text,
                    Celular = this.txtCelular.Text,
                    Complemento = this.txtComplemento.Text,
                    Cep = this.txtCep.Text,
                    Cpf = this.txtCpf.Text,
                    Crm = this.txtNumeroCrm.Text,
                    DataNascimento = Convert.ToDateTime(this.dtpDataNascimento.Value),
                    Email = this.txtEmail.Text,
                    Endereco = this.txtEndereco.Text,
                    NomeMedico = this.txtNomeCompleto.Text,
                    Numero = this.txtNumero.Text,
                    Rg = this.txtRg.Text,
                    Telefone = this.txtTelefoneResidencial.Text
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TelaLoad(MedicoMOD medico)
        {
            try
            {
                this.txtCodigo.Text = medico.Pessoa.CodigoPessoa.ToString();
                this.cbbConsultorio.SelectedValue = medico.Consultorio.Pessoa.CodigoPessoa;
                this.cbbStatus.SelectedValue = medico.Status.CodigoStatus;
                this.cbbSexo.SelectedValue = medico.Sexo.CodigoSexo;
                this.txtNomeCompleto.Text = medico.NomeMedico;
                this.txtRg.Text = medico.Rg;
                this.txtCpf.Text = medico.Cpf;
                this.txtNumeroCrm.Text = medico.Crm;
                this.dtpDataNascimento.Value = medico.DataNascimento;
                this.txtTelefoneResidencial.Text = medico.Telefone;
                this.txtCelular.Text = medico.Celular;
                this.txtEmail.Text = medico.Email;
                this.txtCep.Text = medico.Cep;
                this.cbbEstado.SelectedValue = medico.Cidade.Estado.CodigoEstado;
                this.cbbCidadeLoad(Convert.ToInt32(this.cbbEstado.SelectedValue));
                this.cbbCidade.SelectedValue = medico.Cidade.Codigo;
                this.txtEndereco.Text = medico.Endereco;
                this.txtBairro.Text = medico.Bairro;
                this.txtNumero.Text = medico.Numero;
                this.txtComplemento.Text = medico.Complemento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        Action acticonDefault;

        public FrmMedicoCadastro(Action action, MedicoMOD medico)
        {
            InitializeComponent();

            try
            {
                this.cbbLoad();
                acticonDefault = action;

                switch (action)
                {
                    case Action.Add:
                        this.lblTitulo.Text = "Cadastrar novo Médico";
                        break;
                    case Action.Edit:
                        this.lblTitulo.Text = "Editar Cadastro de Médico";
                        this.TelaLoad(medico);                        
                        break;
                    case Action.Details:
                        this.lblTitulo.Text = "Detalhes do Cadastro de Médico";
                        this.TelaLoad(medico);
                        this.btnGravar.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Manipulação do Evento Enter dos controles
        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Código do Médico";
        }

        private void cbbStatus_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Status";
        }

        private void cbbSexo_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Selecione o Sexo";
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome";
        }

        private void txtSobreNome_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o SobreNome";
        }

        private void txtNomeCompleto_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Nome Completo";
        }

        private void txtRg_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Numero de Rg";
        }

        private void dtpDataNascimento_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe da Data de Nascimento";
        }

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o CPF";
        }

        private void txtTelefoneResidencial_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Telefone Residencial";
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Telefone Celular";
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
            this.lblAjuda.Text = "Selecione ou Digite o Nome da Cidade";
            try
            {
                this.cbbCidadeLoad(Convert.ToInt32(this.cbbEstado.SelectedValue));
            }
            catch (Exception)
            {
                return;
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
            this.lblAjuda.Text = "Informe o Número";
        }

        private void txtComplemento_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe o Complemento";
        }

        private void dtpDataEmissaoRg_Enter(object sender, EventArgs e)
        {
            this.lblAjuda.Text = "Informe a Data de Emissão do Rg";
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
            #endregion

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
        #endregion

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                var negocios = new MedicoBUS();
                negocios.ValidarDados(this.MedicoLoad());
                var retorno = "";
                if (acticonDefault == Action.Add)
                {
                    retorno = negocios.Inserir(this.MedicoLoad());
                    if (!Char.IsNumber(retorno, 0)) { throw new Exception(retorno); }
                    else
                    {
                        this.txtCodigo.Text = retorno;
                        MessageBox.Show("Médico cadastrado com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (acticonDefault == Action.Edit)
                {
                    retorno = negocios.Atualizar(this.MedicoLoad());
                    if (!Char.IsNumber(retorno, 0)) { throw new Exception(retorno); }
                    else
                    {
                        MessageBox.Show("Registro atualizado com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
