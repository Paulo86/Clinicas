using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class ConsultorioREP
    {        
        public String Inserir(ConsultorioMOD consultorio)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();

                conexao.AdicionarParametros("@NM_RAZAO_SOCIAL", consultorio.RazaoSocial);
                conexao.AdicionarParametros("@NM_FANTASIA", consultorio.NomeFantasia);
                conexao.AdicionarParametros("@NR_CPF_CNPJ", consultorio.CpfCnpj);
                conexao.AdicionarParametros("@NR_RG_IE", consultorio.RgIE);
                conexao.AdicionarParametros("@ID_TIPO_PESSOA", consultorio.Pessoa.PessoaTipo.CodigoPessoaTipo);
                conexao.AdicionarParametros("@NR_TELEFONE", consultorio.Telefone);
                conexao.AdicionarParametros("@NR_FAX", consultorio.Fax);
                conexao.AdicionarParametros("@DS_EMAIL", consultorio.Email);
                conexao.AdicionarParametros("@NM_CONTATO", consultorio.NomeContato);
                conexao.AdicionarParametros("@NR_TELEFONE_CONTATO", consultorio.TelefoneContato);
                conexao.AdicionarParametros("@NR_CELULAR_CONTATO", consultorio.CelularContato);
                conexao.AdicionarParametros("@DS_EMAIL_CONTATO", consultorio.EmailContato);
                conexao.AdicionarParametros("@DS_OBSERVACAO", consultorio.Observacao);
                conexao.AdicionarParametros("@ID_STATUS", consultorio.Status.CodigoStatus);
                conexao.AdicionarParametros("@ID_CIDADE", consultorio.Cidade.Codigo);
                conexao.AdicionarParametros("@NR_CEP", consultorio.Cep);
                conexao.AdicionarParametros("@DS_ENDERECO", consultorio.Endereco);
                conexao.AdicionarParametros("@NR_ENDERECO", consultorio.Numero);
                conexao.AdicionarParametros("@DS_ENDERECO_COMPLEMENTO", consultorio.Complemento);
                conexao.AdicionarParametros("@NM_BAIRRO", consultorio.NomeBairro);

                return conexao.Persistencia("USP_CONSULTORIO_INS");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ConsultorioListaMOD ListaGridPrincipal()
        {
            try
            {
                var lista = new ConsultorioListaMOD();
                var conexao = new AcessoSqlServer();
                foreach (DataRow consultorio in conexao.Pesquisar("USP_CONSULTORIO_LISTA_GRID").Rows)
                {
                    lista.Add(new ConsultorioMOD
                    {
                        RazaoSocial = consultorio["NM_RAZAO_SOCIAL"].ToString(),
                        NomeFantasia = consultorio["NM_FANTASIA"].ToString(),
                        Telefone = consultorio["NR_TELEFONE"].ToString(),
                        NomeContato = consultorio["NM_CONTATO"].ToString(),
                        Endereco = consultorio["DS_ENDERECO"].ToString(),
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(consultorio["ID_CONSULTORIO"].ToString())
                        }
                    });
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsultorioMOD Detalhes(Int32 CodigoCosultorio)
        {
            try
            {
                var consultorioMOD = new ConsultorioMOD();
                var conexao = new AcessoSqlServer();
                conexao.AdicionarParametros("@ID_CONSULTORIO", CodigoCosultorio);
                DataRow consultorio = conexao.Pesquisar("USP_CONSULTORIO_SEL").Rows[0];

                consultorioMOD.Pessoa.CodigoPessoa = Convert.ToInt32(consultorio["ID_CONSULTORIO"]);
                consultorioMOD.Pessoa.PessoaTipo.CodigoPessoaTipo = Convert.ToInt32(consultorio["ID_TIPO_PESSOA"]);
                consultorioMOD.Cidade.Codigo = Convert.ToInt32(consultorio["ID_CIDADE"]);
                consultorioMOD.Pessoa.PessoaTipo.CodigoPessoaTipo = Convert.ToInt32(consultorio["ID_TIPO_PESSOA"]);
                consultorioMOD.Cidade.Estado.CodigoEstado = Convert.ToInt32(consultorio["ID_ESTADO"]);
                consultorioMOD.Status.CodigoStatus = Convert.ToInt32(consultorio["ID_STATUS"]);
                consultorioMOD.RazaoSocial = consultorio["NM_RAZAO_SOCIAL"].ToString();
                consultorioMOD.NomeFantasia = consultorio["NM_FANTASIA"].ToString();
                consultorioMOD.CpfCnpj = consultorio["NR_CPF_CNPJ"].ToString();
                consultorioMOD.RgIE = consultorio["NR_RG_IE"].ToString();
                consultorioMOD.Telefone = consultorio["NR_TELEFONE"].ToString();
                consultorioMOD.Fax = consultorio["NR_FAX"].ToString();
                consultorioMOD.Email = consultorio["DS_EMAIL"].ToString();
                consultorioMOD.NomeContato = consultorio["NM_CONTATO"].ToString();
                consultorioMOD.TelefoneContato = consultorio["NR_TELEFONE_CONTATO"].ToString();
                consultorioMOD.CelularContato = consultorio["NR_CELULAR_CONTATO"].ToString();
                consultorioMOD.EmailContato = consultorio["DS_EMAIL_CONTATO"].ToString();
                consultorioMOD.Observacao = consultorio["DS_OBSERVACAO"].ToString();
                consultorioMOD.Cep = consultorio["NR_CEP"].ToString();
                consultorioMOD.Endereco = consultorio["DS_ENDERECO"].ToString();
                consultorioMOD.Numero = consultorio["NR_ENDERECO"].ToString();
                consultorioMOD.Complemento = consultorio["DS_ENDERECO_COMPLEMENTO"].ToString();
                consultorioMOD.NomeBairro = consultorio["NM_BAIRRO"].ToString();
                
                return consultorioMOD;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Excluir(Int32 CodigoConsultorio)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.AdicionarParametros("@ID_CONSULTORIO", CodigoConsultorio);
                return conexao.Persistencia("USP_CONSULTORIO_DEL");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public String Atualizar(ConsultorioMOD consultorio)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();

                conexao.AdicionarParametros("@ID_CONSULTORIO", consultorio.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@NM_RAZAO_SOCIAL", consultorio.RazaoSocial);
                conexao.AdicionarParametros("@NM_FANTASIA", consultorio.NomeFantasia);
                conexao.AdicionarParametros("@NR_CPF_CNPJ", consultorio.CpfCnpj);
                conexao.AdicionarParametros("@NR_RG_IE", consultorio.RgIE);
                conexao.AdicionarParametros("@ID_TIPO_PESSOA", consultorio.Pessoa.PessoaTipo.CodigoPessoaTipo);
                conexao.AdicionarParametros("@NR_TELEFONE", consultorio.Telefone);
                conexao.AdicionarParametros("@NR_FAX", consultorio.Fax);
                conexao.AdicionarParametros("@DS_EMAIL", consultorio.Email);
                conexao.AdicionarParametros("@NM_CONTATO", consultorio.NomeContato);
                conexao.AdicionarParametros("@NR_TELEFONE_CONTATO", consultorio.TelefoneContato);
                conexao.AdicionarParametros("@NR_CELULAR_CONTATO", consultorio.CelularContato);
                conexao.AdicionarParametros("@DS_EMAIL_CONTATO", consultorio.EmailContato);
                conexao.AdicionarParametros("@DS_OBSERVACAO", consultorio.Observacao);
                conexao.AdicionarParametros("@ID_STATUS", consultorio.Status.CodigoStatus);
                conexao.AdicionarParametros("@ID_CIDADE", consultorio.Cidade.Codigo);
                conexao.AdicionarParametros("@NR_CEP", consultorio.Cep);
                conexao.AdicionarParametros("@DS_ENDERECO", consultorio.Endereco);
                conexao.AdicionarParametros("@NR_ENDERECO", consultorio.Numero);
                conexao.AdicionarParametros("@DS_ENDERECO_COMPLEMENTO", consultorio.Complemento);
                conexao.AdicionarParametros("@NM_BAIRRO", consultorio.NomeBairro);

                return conexao.Persistencia("USP_CONSULTORIO_UPD");                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
