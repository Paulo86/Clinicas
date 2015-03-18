using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class ClienteREP
    {

        public String Inserir(ClienteMOD cliente)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.AdicionarParametros("@NM_PRIMEIRO_NOME", cliente.PrimeiroNome);
                conexao.AdicionarParametros("@NM_SOBRE_NOME", cliente.SobreNome);
                conexao.AdicionarParametros("@NM_COMPLETO", cliente.NomeCompleto);
                conexao.AdicionarParametros("@DT_NASCIMENTO", cliente.DataNascimento);
                conexao.AdicionarParametros("@NR_RG", cliente.Rg);
                conexao.AdicionarParametros("@DT_EMISSAO_RG", cliente.DataEmissaoRg);
                conexao.AdicionarParametros("@NR_CPF", cliente.Cpf);
                conexao.AdicionarParametros("@DS_EMAIL", cliente.Email);
                conexao.AdicionarParametros("@ID_CIDADE", cliente.Cidade.Codigo);
                conexao.AdicionarParametros("@ID_STATUS", cliente.Status.CodigoStatus);
                conexao.AdicionarParametros("@NM_BAIRRO", cliente.NomeBairro);
                conexao.AdicionarParametros("@DS_ENDERECO", cliente.Endereco);
                conexao.AdicionarParametros("@NR_ENDERECO", cliente.Numero);
                conexao.AdicionarParametros("@NR_CEP", cliente.Cep);
                conexao.AdicionarParametros("@DS_COMPLEMENTO", cliente.Complemento);
                conexao.AdicionarParametros("@NR_TELEFONE", cliente.Telefone);
                conexao.AdicionarParametros("@NR_CELULAR", cliente.Celular);
                conexao.AdicionarParametros("@ID_TIPO_PESSOA", cliente.Pessoa.PessoaTipo.CodigoPessoaTipo);
                conexao.AdicionarParametros("@ID_SEXO", cliente.Sexo.CodigoSexo);

                return conexao.Persistencia("USP_CLIENTE_INS");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Atualizar(ClienteMOD cliente)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.AdicionarParametros("@ID_CLIENTE", cliente.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@NM_PRIMEIRO_NOME", cliente.PrimeiroNome);
                conexao.AdicionarParametros("@NM_SOBRE_NOME", cliente.SobreNome);
                conexao.AdicionarParametros("@NM_COMPLETO", cliente.NomeCompleto);
                conexao.AdicionarParametros("@DT_NASCIMENTO", cliente.DataNascimento);
                conexao.AdicionarParametros("@NR_RG", cliente.Rg);
                conexao.AdicionarParametros("@DT_EMISSAO_RG", cliente.DataEmissaoRg);
                conexao.AdicionarParametros("@NR_CPF", cliente.Cpf);
                conexao.AdicionarParametros("@DS_EMAIL", cliente.Email);
                conexao.AdicionarParametros("@ID_CIDADE", cliente.Cidade.Codigo);
                conexao.AdicionarParametros("@ID_STATUS", cliente.Status.CodigoStatus);
                conexao.AdicionarParametros("@NM_BAIRRO", cliente.NomeBairro);
                conexao.AdicionarParametros("@DS_ENDERECO", cliente.Endereco);
                conexao.AdicionarParametros("@NR_ENDERECO", cliente.Numero);
                conexao.AdicionarParametros("@NR_CEP", cliente.Cep);
                conexao.AdicionarParametros("@DS_COMPLEMENTO", cliente.Complemento);
                conexao.AdicionarParametros("@NR_TELEFONE", cliente.Telefone);
                conexao.AdicionarParametros("@NR_CELULAR", cliente.Celular);
                conexao.AdicionarParametros("@ID_TIPO_PESSOA", cliente.Pessoa.PessoaTipo.CodigoPessoaTipo);
                conexao.AdicionarParametros("@ID_SEXO", cliente.Sexo.CodigoSexo);

                return conexao.Persistencia("USP_CLIENTE_UPD");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Excluir(Int32 CodigoCliente)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_CLIENTE", CodigoCliente);
                return conexao.Persistencia("USP_CLIENTE_DEL");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteMOD ClienteByID(Int32 CodigoCliente)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_CLIENTE", CodigoCliente);
                DataRow dado = conexao.Pesquisar("USP_CLIENTE_SEL").Rows[0];

                return new ClienteMOD
                {
                    Celular = dado["NR_CELULAR"].ToString(),
                    Cep = dado["NR_CEP"].ToString(),
                    Cidade = new CidadeMOD
                    {
                        Codigo = Convert.ToInt32(dado["ID_CIDADE"]),
                        Estado = new EstadoMOD
                        {
                            CodigoEstado = Convert.ToInt32(dado["ID_ESTADO"])
                        }
                    },
                    Complemento = dado["DS_COMPLEMENTO"].ToString(),
                    Cpf = dado["NR_CPF"].ToString(),
                    Email = dado["DS_EMAIL"].ToString(),
                    Endereco = dado["DS_ENDERECO"].ToString(),
                    PrimeiroNome = dado["NM_PRIMEIRO_NOME"].ToString(),
                    SobreNome = dado["NM_SOBRE_NOME"].ToString(),
                    NomeCompleto = dado["NM_COMPLETO"].ToString(),
                    DataEmissaoRg = Convert.ToDateTime(dado["DT_EMISSAO_RG"]),
                    DataNascimento = Convert.ToDateTime(dado["DT_NASCIMENTO"]),
                    NomeBairro = dado["NM_BAIRRO"].ToString(),
                    Numero = dado["NR_ENDERECO"].ToString(),
                    Rg = dado["NR_RG"].ToString(),
                    Telefone = dado["NR_TELEFONE"].ToString(),
                    Pessoa = new PessoaMOD
                    {
                        CodigoPessoa = Convert.ToInt32(dado["ID_CLIENTE"]),
                        PessoaTipo = new PessoaTipoMOD
                        {
                            CodigoPessoaTipo = Convert.ToInt32(dado["ID_TIPO_PESSOA"])
                        }
                    },
                    Status = new StatusMOD
                    {
                        CodigoStatus = Convert.ToInt32(dado["ID_STATUS"])
                    },
                    Sexo = new SexoMOD
                    {
                        CodigoSexo = Convert.ToInt32(dado["ID_SEXO"])
                    }
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteListaMOD ClienteLista()
        {
            try
            {
                var lista = new ClienteListaMOD();
                foreach (DataRow cliente in new AcessoSqlServer().Pesquisar("USP_CLIENTE_SEL_LIST").Rows)
                {
                    lista.Add(new ClienteMOD
                    {
                        Endereco = cliente["DS_ENDERECO"].ToString(),
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(cliente["ID_CLIENTE"])
                        },
                        Status = new StatusMOD
                        {
                            Status = cliente["DS_STATUS"].ToString()
                        },
                        NomeBairro = cliente["NM_BAIRRO"].ToString(),
                        NomeCompleto = cliente["NM_COMPLETO"].ToString(),
                        Celular = cliente["NR_CELULAR"].ToString(),
                        Telefone = cliente["NR_TELEFONE"].ToString()
                    });
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteListaMOD ClienteListaByDesc(String Descricao)
        {
            try
            {
                var lista = new ClienteListaMOD();
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@NM_COMPLETO", Descricao);
                DataRow cliente = conexao.Pesquisar("USP_CLIENTE_SEL_LIST_BY_DESC").Rows[0];

                lista.Add(new ClienteMOD
                {
                    Endereco = cliente["DS_ENDERECO"].ToString(),
                    Pessoa = new PessoaMOD
                    {
                        CodigoPessoa = Convert.ToInt32(cliente["ID_CLIENTE"])
                    },
                    Status = new StatusMOD
                    {
                        Status = cliente["DS_STATUS"].ToString()
                    },
                    NomeBairro = cliente["NM_BAIRRO"].ToString(),
                    NomeCompleto = cliente["NM_COMPLETO"].ToString(),
                    Celular = cliente["NR_CELULAR"].ToString(),
                    Telefone = cliente["NR_TELEFONE"].ToString()
                });

                return lista;

            }
            catch (Exception)
            {

                throw new Exception("Nenhum Cliente Encontrado com os Dados Informados !");
            }
        }
    }
}
