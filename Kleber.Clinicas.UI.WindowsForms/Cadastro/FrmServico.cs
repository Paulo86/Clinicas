using Kleber.Clinicas.Business.Cadastro;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Windows.Forms;

namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    public partial class FrmServico : Form
    {
        private void PrincipalGridLoad()
        {
            try
            {
                this.gdvPrincipal.DataSource = new ServicoBUS().ServicoList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ServicoMOD ServicoLoadObj()
        {
            try
            {
                return new ServicoBUS().ServicoById(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmServico()
        {
            InitializeComponent();
            try
            {
                this.gdvPrincipal.AutoGenerateColumns = false;
                this.PrincipalGridLoad();
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
                var frmServicoCadastro = new FrmServicoCadastro(Action.Add, null);
                frmServicoCadastro.ShowDialog();
                this.PrincipalGridLoad();
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
                var frmServicoCadastro = new FrmServicoCadastro(Action.Edit, this.ServicoLoadObj());
                frmServicoCadastro.ShowDialog();
                this.PrincipalGridLoad();
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
                DialogResult resposta = MessageBox.Show("Confirma a exclusão detse registro ?", "Responda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (!resposta.Equals(DialogResult.Yes)) { return; }
                else
                {
                    var retorno = "";
                    var negocios = new ServicoBUS();
                    retorno = negocios.Excluir(Convert.ToInt32(this.gdvPrincipal.CurrentRow.Cells[0].Value));
                    if (!Char.IsNumber(retorno, 0)) { throw new Exception(retorno); }
                    else
                    {
                        MessageBox.Show("Seviço Excluido com Sucesso !", "Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.PrincipalGridLoad();
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
                var frmServicoCadastro = new FrmServicoCadastro(Action.Details, this.ServicoLoadObj());
                frmServicoCadastro.ShowDialog();
                this.PrincipalGridLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar informações !\nDetalhes: " + ex.Message, "Alerta de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
