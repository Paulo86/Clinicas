using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Business.Financeiro.Orcamento;
using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Models.Financeiro;
using Kleber.Clinicas.Models.Financeiro.Orcamento;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro.Financeiro.Orcamento
{
    public partial class FrmOrcamentoCadastro : Form
    {
        Action action = new Action();
        String Status = string.Empty;
        //
        //Méto carregar Status. carrega o comboBox com os tipos de status
        private void carregarStatus()
        {
            try
            {
                this.cbbStatus.DisplayMember = "Status";
                this.cbbStatus.ValueMember = "CodigoStatus";
                this.cbbStatus.DataSource = new StatusBUS().StatusLista();
                this.cbbStatus.SelectedIndex = -1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        //Método carregarConsultorio. carrega o comboBox com os consultórios cadastrados
        private void carregarConsultorio()
        {
            try
            {
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
        //
        //Método carregarServico. cerrega o comboBox com os serviços cadastrados
        private void carregarServico()
        {
            try
            {
                this.cbbServico.DisplayMember = "descricao";
                this.cbbServico.ValueMember = "idServico";
                this.cbbServico.DataSource = new ServicoBUS().ServicoList().Select(x => new
                {
                    descricao = x.Descricao,
                    idServico = x.CodigoServico
                }).ToList();
                this.cbbServico.SelectedIndex = -1;
                this.txtCodigoServico.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        //Método carregarClientes. carrega o comboBox com o cadastro de clientes
        private void carregarClientes()
        {
            try
            {
                this.cbbCliente.DisplayMember = "nomeCliente";
                this.cbbCliente.ValueMember = "idCliente";
                this.cbbCliente.DataSource = new ClienteBUS().ClienteLista().Select(x => new
                {
                    idCliente = x.Pessoa.CodigoPessoa,
                    nomeCliente = x.NomeCompleto
                }).ToList();
                this.cbbCliente.SelectedIndex = -1;
                this.txtCodigoCliente.Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //
        //Método carregarMedico. Carrega o comboBox com cadastro de médicos
        private void carregarMedico()
        {
            try
            {
                this.cbbMedico.DisplayMember = "nomeMedico";
                this.cbbMedico.ValueMember = "idMedico";
                this.cbbMedico.DataSource = new MedicoBUS().MedicoList().Select(x => new
                {
                    nomeMedico = x.NomeMedico,
                    idMedico = x.Pessoa.CodigoPessoa
                }).ToList();
                this.cbbMedico.SelectedIndex = -1;
                this.txtCodigoMedico.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        //Método cbbLoad. Carrega todos os comboBox da tela.
        private void cbbLoad()
        {
            try
            {
                //Carrega o comboBox de Status
                this.carregarStatus();
                //
                //Carrega o comboBox de consultório
                this.carregarConsultorio();
                //
                //Carrega o comboBox de serviços
                this.carregarServico();
                //
                //Carregar comboBox de clientes
                this.carregarClientes();
                //
                //Carregar comboBox de médicos
                this.carregarMedico();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados !\nDetalhes: " + ex.Message, "Alerta de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //Método Construtor
        public FrmOrcamentoCadastro(Action action)
        {
            InitializeComponent();
            this.gdvPrincipal.AutoGenerateColumns = false;
            //
            this.action = action;
            //
            this.cbbLoad();
            switch (action)
            {
                case Action.Add:
                    this.lblTitulo.Text = "Cadastro de novo orçamento";
                    break;
                case Action.Edit:
                    this.lblTitulo.Text = "Alteração de cadastro de orçamento";
                    break;
                case Action.Delete:
                    break;
                case Action.Details:
                    this.lblTitulo.Text = "Detalhes de cadastro de orçamento";
                    break;
                default:
                    break;
            }
        }
        //
        //Método para atualizar os dados na tela.
        private void addServico()
        {
            try
            {
                var servico = new ServicoBUS().ServicoById(Convert.ToInt32(this.cbbServico.SelectedValue));
                this.txtQuantidade.Text = (1).ToString();
                this.txtValorUnitario.Text = servico.Valor.ToString("N2");
                this.txtValorTotalItem.Text = (Convert.ToDecimal(this.txtValorUnitario.Text) * (Convert.ToDecimal(this.txtQuantidade.Text))).ToString();
                this.cbbTipoAcrescimo.SelectedIndex = 0;
                this.cbbTipoDesconto.SelectedIndex = 0;
                switch (cbbTipoAcrescimo.SelectedIndex)
                {
                    case 0:
                        txtTotalAcrescimoUnitario.Text = (Convert.ToDecimal(this.txtValorTotalItem.Text) * (Convert.ToDecimal(this.txtValorAcrescimo.Text)) / 100).ToString("N2");
                        break;
                    //
                    case 1:
                        txtTotalAcrescimoUnitario.Text = (Convert.ToDecimal(this.txtValorAcrescimo.Text) * (Convert.ToDecimal(this.txtQuantidade.Text))).ToString("N2");
                        break;
                }
                //
                switch (cbbTipoDesconto.SelectedIndex)
                {
                    case 0:
                        this.txtTotalDescontoUnitario.Text = ((Convert.ToDecimal(this.txtValorTotalItem.Text)) * (Convert.ToDecimal(this.txtValorDesconto.Text)) / 100).ToString("N2");
                        break;
                    //
                    case 1:
                        this.txtTotalDescontoUnitario.Text = ((Convert.ToDecimal(this.txtValorDesconto.Text) * (Convert.ToDecimal(this.txtQuantidade.Text)))).ToString("N2");
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        //Método para atualizar os totalizadores
        private void updateTotais()
        {
            try
            {
                if (this.txtTotalDescontoUnitario.Text.Trim() == "")
                {
                    this.txtTotalDescontoUnitario.Text = (0).ToString("N2");
                }
                if (this.txtTotalAcrescimoUnitario.Text.Trim() == "")
                {
                    this.txtTotalAcrescimoUnitario.Text = (0).ToString("N2");
                }
                switch (cbbTipoAcrescimo.SelectedIndex)
                {
                    case 0:
                        txtTotalAcrescimoUnitario.Text = (Convert.ToDecimal(this.txtValorTotalItem.Text) * (Convert.ToDecimal(this.txtValorAcrescimo.Text)) / 100).ToString("N2");
                        break;
                    //
                    case 1:
                        txtTotalAcrescimoUnitario.Text = (Convert.ToDecimal(this.txtValorAcrescimo.Text) * (Convert.ToInt32(this.txtQuantidade.Text))).ToString("N2");
                        break;
                }
                //
                switch (cbbTipoDesconto.SelectedIndex)
                {
                    case 0:
                        this.txtTotalDescontoUnitario.Text = ((Convert.ToDecimal(this.txtValorTotalItem.Text)) * (Convert.ToDecimal(this.txtValorDesconto.Text)) / 100).ToString("N2");
                        break;
                    //
                    case 1:
                        this.txtTotalDescontoUnitario.Text = ((Convert.ToDecimal(this.txtValorDesconto.Text) * (Convert.ToDecimal(this.txtQuantidade.Text)))).ToString("N2");
                        break;
                }
                this.txtValorTotalItem.Text = (Convert.ToDecimal(this.txtQuantidade.Text) * Convert.ToDecimal(this.txtValorUnitario.Text)).ToString("N2");
            }
            catch (Exception)
            {

                throw;
            }

        }
        //
        //Método para converter informações dos campos para decimal
        private String myDecimal(String valor)
        {
            String _valor = String.Empty;
            //
            if (valor.Trim() == "")
            {
                _valor = (0.00).ToString("N2");
            }
            else
            {
                _valor = Convert.ToDecimal(valor).ToString("N2");
            }
            return _valor;
        }
        //
        //Método para carregar o Objeto MODEL (OrcamentoMOD)
        private OrcamentoMOD LoadOrcamentoMOD()
        {
            try
            {
                int _codigo = 0;
                if (this.txtCodigoOrcamento.Text.Trim() != "")
                {
                    _codigo = Convert.ToInt32(this.txtCodigoOrcamento.Text);
                }
                return new OrcamentoMOD
                {
                    CodigoOrcamento = _codigo,
                    NumeroFicha = this.txtNumeroFicha.Text,
                    ValorTotalBruto = Convert.ToDecimal(this.txtTotalBrutoGeral.Text),
                    ValorTotalAcrescimo = Convert.ToDecimal(this.txtTotalAcrescimoGeral.Text),
                    ValorTotalDesconto = Convert.ToDecimal(this.txtTotalDescontoGeral.Text),
                    ValorTotalLiquido = Convert.ToDecimal(this.txtTotalLiquidoGeral.Text),
                    DataOrcamento = this.dtpDataOrcamento.Value,
                    Validade = this.dtpDataValidade.Value,
                    Observacao = this.txtObservacao.Text,
                    QuantidadeItens = Convert.ToInt32(this.txtTotalItensGeral.Text),
                    Consultorio = new ConsultorioMOD
                    {
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(this.cbbConsultorio.SelectedValue)
                        }
                    },
                    Cliente = new ClienteMOD
                    {
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(this.txtCodigoCliente.Text)
                        }
                    },
                    Medico = new MedicoMOD
                    {
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(this.txtCodigoMedico.Text)
                        }
                    },
                    Status = new StatusMOD
                    {
                        CodigoStatus = Convert.ToInt32(this.cbbStatus.SelectedValue)
                    }

                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        //Método para carregar o Objeto MODEL (OrcamentoItemMOD)
        private OrcamentoItemMOD LoadOrcamentoItemMOD()
        {
            return new OrcamentoItemMOD
            {
                Servico = new ServicoMOD
                {
                    CodigoServico = Convert.ToInt32(this.txtCodigoServico.Text),
                    Valor = Convert.ToDecimal(this.txtValorUnitario.Text)
                },
                Orcamento = new OrcamentoMOD
                {
                    CodigoOrcamento = Convert.ToInt32(this.txtCodigoOrcamento.Text),
                },
                Quantidade = Convert.ToInt32(this.txtQuantidade.Text),
                TipoAcrescimo = this.cbbTipoAcrescimo.Text,
                AcrescimoValor = Convert.ToDecimal(this.txtValorAcrescimo.Text),
                TipoDesconto = this.cbbTipoDesconto.Text,
                DescontoValor = Convert.ToDecimal(this.txtValorDesconto.Text),
                ValorTotalItem = Convert.ToDecimal(this.txtValorTotalItem.Text)
            };
        }
        //
        //Método para carregar adicioar Gravar um Serviço
        private void GravarItem()
        {
            try
            {
                if (this.txtCodigoOrcamento.Text.Trim() == "")
                {
                    var orcamentoBUS = new OrcamentoBUS();
                    //                
                    orcamentoBUS.validarOrcamento(this.LoadOrcamentoMOD());
                    String retorno = orcamentoBUS.Inserir(this.LoadOrcamentoMOD());
                    this.txtCodigoOrcamento.Text = retorno;
                }
                //
                var orcamentoItemBUS = new OrcamentoItemBUS();
                var orcamentoMOD = orcamentoItemBUS.Inserir(this.LoadOrcamentoItemMOD());
                //
                this.txtTotalAcrescimoGeral.Text = orcamentoMOD.ValorTotalAcrescimo.ToString("N2");
                this.txtTotalBrutoGeral.Text = orcamentoMOD.ValorTotalBruto.ToString("N2");
                this.txtTotalDescontoGeral.Text = orcamentoMOD.ValorTotalDesconto.ToString("N2");
                this.txtTotalItensGeral.Text = orcamentoMOD.QuantidadeItens.ToString();
                this.txtTotalLiquidoGeral.Text = orcamentoMOD.ValorTotalLiquido.ToString("N2");
                //
                this.cbbServico.SelectedIndex = -1;
                this.txtCodigoServico.Text = String.Empty.Trim();
                this.txtQuantidade.Text = (0).ToString();
                this.txtValorUnitario.Text = (0).ToString("N2");
                this.txtValorAcrescimo.Text = (0).ToString("N2");
                this.txtValorDesconto.Text = (0).ToString("N2");
                this.txtTotalAcrescimoUnitario.Text = (0).ToString("N2");
                this.txtTotalDescontoUnitario.Text = "";
                this.txtValorTotalItem.Text = (0).ToString("N2");
                //
                MessageBox.Show("Serviço adicionado com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //
        //Método para carregar os itens do Orçamento no grid de Itens
        private void carregarItensOrcamento()
        {
            try
            {
                int idOrcamento = Convert.ToInt32(this.txtCodigoOrcamento.Text);
                this.gdvPrincipal.DataSource = new OrcamentoItemBUS().itensOrcamento(idOrcamento).Select(x => new
                {
                    //
                    codigoOrcamento = x.Orcamento.CodigoOrcamento,
                    codigoServico = x.Servico.CodigoServico,
                    descricaoServico = x.Servico.Descricao,
                    quantidadeServico = x.Quantidade,
                    valorUnitarioServico = x.Servico.Valor,
                    valorUnitarioAcrescimo = x.AcrescimoValor,
                    valorUnitarioDesconto = x.DescontoValor,
                    valorServicoBruto = x.Orcamento.ValorTotalBruto,
                    valorTotalDesconto = x.Orcamento.ValorTotalDesconto,
                    valorTotalAcrescimo = x.Orcamento.ValorTotalAcrescimo,
                    valorTotalServicoLiquido = x.Orcamento.ValorTotalLiquido,
                    sequencia = x.Sequencia
                    //
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cbbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cbbCliente.SelectedIndex != -1)
            {
                this.txtCodigoCliente.Text = this.cbbCliente.SelectedValue.ToString();
            }
        }

        private void btnCadastroServico_Click(object sender, EventArgs e)
        {
            var dialog = new FrmServico().ShowDialog();
            this.carregarServico();
        }

        private void btnCadastroConsultorio_Click(object sender, EventArgs e)
        {
            var dialog = new FrmConsultorio().ShowDialog();
            this.carregarConsultorio();
        }

        private void btnCadastroCliente_Click(object sender, EventArgs e)
        {
            var dialog = new FrmCliente().ShowDialog();
            this.carregarClientes();
        }

        private void btnCadastroMedico_Click(object sender, EventArgs e)
        {
            var dialog = new FrmMedico().ShowDialog();
            this.carregarMedico();
        }

        private void cbbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbMedico.SelectedIndex > -1)
            {
                this.txtCodigoMedico.Text = cbbMedico.SelectedValue.ToString();
            }
        }

        private void cbbServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbServico.SelectedIndex > -1)
            {
                this.txtCodigoServico.Text = this.cbbServico.SelectedValue.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                this.addServico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar serviço." + "\nDetalhes: " + ex.Message, "Alerta de erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            try
            {
                this.updateTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtValorUnitario_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtValorUnitario.Text = this.myDecimal(this.txtValorUnitario.Text);
                this.updateTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtValorAcrescimo_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtValorAcrescimo.Text = this.myDecimal(this.txtValorAcrescimo.Text);
                this.updateTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtValorDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtValorDesconto.Text = this.myDecimal(this.txtValorDesconto.Text);
                this.updateTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbbTipoAcrescimo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtValorAcrescimo.Text = this.myDecimal(this.txtValorAcrescimo.Text);
                this.updateTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbbTipoDesconto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtValorAcrescimo.Text = this.myDecimal(this.txtValorAcrescimo.Text);
                this.updateTotais();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                var orcamentoBUS = new OrcamentoBUS();
                //                
                orcamentoBUS.validarOrcamento(this.LoadOrcamentoMOD());
                String retorno = orcamentoBUS.Inserir(this.LoadOrcamentoMOD());
                this.txtCodigoOrcamento.Text = retorno;
                this.Status = "confirmado";
                //MessageBox.Show(retorno);                      

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGravarItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.GravarItem();
                this.updateTotais();
                this.carregarItensOrcamento();
                this.Status = "gravado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gdvPrincipal.Rows.Count > 0)
                {
                    if (this.gdvPrincipal.SelectedRows.Count > 0)
                    {
                        DialogResult dialog = MessageBox.Show("Deseja realmente retirar esse item do Orçamento ?", "Pergunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        //
                        if (dialog == DialogResult.Yes)
                        {
                            int idOrcamento = Convert.ToInt32(gdvPrincipal.CurrentRow.Cells[0].Value);
                            int idServico = Convert.ToInt32(gdvPrincipal.CurrentRow.Cells[1].Value);
                            int sequencia = Convert.ToInt32(gdvPrincipal.CurrentRow.Cells[2].Value);
                            //
                            OrcamentoMOD orcamentoMOD = new OrcamentoItemBUS().Delete(idOrcamento, sequencia, idServico);
                            if (orcamentoMOD != null)
                            {
                                this.carregarItensOrcamento();
                                this.txtTotalBrutoGeral.Text = orcamentoMOD.ValorTotalBruto.ToString("N2");
                                this.txtTotalLiquidoGeral.Text = orcamentoMOD.ValorTotalLiquido.ToString("N2");
                                this.txtTotalAcrescimoGeral.Text = orcamentoMOD.ValorTotalAcrescimo.ToString("N2");
                                this.txtTotalDescontoGeral.Text = orcamentoMOD.ValorTotalDesconto.ToString("N2");
                                this.txtTotalItensGeral.Text = orcamentoMOD.QuantidadeItens.ToString();
                            }
                            else
                            {
                                throw new Exception("Erro desconhecido !");
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível Excluir item da lista\nDetalhes: " + ex.Message,
                    "Alerta de Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnListarItens_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tabPage1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Deseja realmente cancelar este Orçamento ?", "Pergunta", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //
                if (dialog == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int idOrcamento = Convert.ToInt32(this.txtCodigoOrcamento.Text);
                    var retorno = String.Empty;
                    var negocios = new OrcamentoBUS();
                    retorno = negocios.Cancelar(idOrcamento);
                    //
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Orçamento cancelado com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        throw new Exception(retorno);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cancelar Orçamento !\nDetalhes: " + ex.Message, "Alerta de Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Atenção !\nOs dados do Orçamento excluido não poderão mais serem recuperados.\n" +
                    "Deseja continuar com o processo de exlusão deste Orçamento ?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //
                if (dialog == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int idOrcamento = Convert.ToInt32(this.txtCodigoOrcamento.Text);
                    var retorno = String.Empty;
                    var negocios = new OrcamentoBUS();
                    retorno = negocios.Delete(idOrcamento);
                    //
                    if (Char.IsNumber(retorno, 0))
                    {
                        MessageBox.Show("Orçamento Excluido com sucesso !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception(retorno);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir Orçamento !\nDetalhes: " + ex.Message, "Alerta de Erro",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
