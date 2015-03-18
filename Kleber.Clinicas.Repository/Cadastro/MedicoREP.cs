using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;


namespace Kleber.Clinicas.Repository.Cadastro
{
    public class MedicoREP
    {
        public String Inserir(MedicoMOD medico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_SEXO", medico.Sexo.CodigoSexo);
                conexao.AdicionarParametros("@DT_NASCIMENTO", medico.DataNascimento);
                conexao.AdicionarParametros("@NM_MEDICO", medico.NomeMedico);
                conexao.AdicionarParametros("@NR_RG", medico.Rg);
                conexao.AdicionarParametros("@NR_CPF", medico.Cpf);
                conexao.AdicionarParametros("@NR_CRM", medico.Crm);
                conexao.AdicionarParametros("@ID_CONSULTORIO", medico.Consultorio.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@ID_STATUS", medico.Status.CodigoStatus);
                conexao.AdicionarParametros("@DS_EMAIL", medico.Email);
                conexao.AdicionarParametros("@NR_TELEFONE", medico.Telefone);
                conexao.AdicionarParametros("@NR_CELULAR", medico.Celular);
                conexao.AdicionarParametros("@NR_CEP", medico.Cep);
                conexao.AdicionarParametros("@ID_CIDADE", medico.Cidade.Codigo);
                conexao.AdicionarParametros("@NR_ENDERECO", medico.Numero);
                conexao.AdicionarParametros("@DS_ENDERECO", medico.Endereco);
                conexao.AdicionarParametros("@NM_BAIRRO", medico.Bairro);
                conexao.AdicionarParametros("@DS_COMPLEMENTO", medico.Complemento);

                return conexao.Persistencia("USP_MEDICO_INS");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Atualizar(MedicoMOD medico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_SEXO", medico.Sexo.CodigoSexo);
                conexao.AdicionarParametros("@ID_MEDICO", medico.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@DT_NASCIMENTO", medico.DataNascimento);
                conexao.AdicionarParametros("@NM_MEDICO", medico.NomeMedico);
                conexao.AdicionarParametros("@NR_RG", medico.Rg);
                conexao.AdicionarParametros("@NR_CPF", medico.Cpf);
                conexao.AdicionarParametros("@NR_CRM", medico.Crm);
                conexao.AdicionarParametros("@ID_CONSULTORIO", medico.Consultorio.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@ID_STATUS", medico.Status.CodigoStatus);
                conexao.AdicionarParametros("@DS_EMAIL", medico.Email);
                conexao.AdicionarParametros("@NR_TELEFONE", medico.Telefone);
                conexao.AdicionarParametros("@NR_CELULAR", medico.Celular);
                conexao.AdicionarParametros("@NR_CEP", medico.Cep);
                conexao.AdicionarParametros("@ID_CIDADE", medico.Cidade.Codigo);
                conexao.AdicionarParametros("@NR_ENDERECO", medico.Numero);
                conexao.AdicionarParametros("@DS_ENDERECO", medico.Endereco);
                conexao.AdicionarParametros("@NM_BAIRRO", medico.Bairro);
                conexao.AdicionarParametros("@DS_COMPLEMENTO", medico.Complemento);

                return conexao.Persistencia("USP_MEDICO_UPD");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Excluir(Int32 CodigoMedico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_MEDICO", CodigoMedico);
                return conexao.Persistencia("USP_MEDICO_DEL");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MedicoMOD MedicoById(Int32 CodigoMedico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_MEDICO", CodigoMedico);

                DataRow medico = conexao.Pesquisar("USP_MEDICO_SEL").Rows[0];
                return new MedicoMOD
                {
                    Pessoa = new PessoaMOD
                    {
                        CodigoPessoa = Convert.ToInt32(medico["ID_MEDICO"])
                    },
                    NomeMedico = medico["NM_MEDICO"].ToString(),
                    Rg = medico["NR_RG"].ToString(),
                    Cpf = medico["NR_CPF"].ToString(),
                    Crm = medico["NR_CRM"].ToString(),
                    Consultorio = new ConsultorioMOD
                    {
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(medico["ID_CONSULTORIO"])
                        }
                    },
                    Status = new StatusMOD
                    {
                        CodigoStatus = Convert.ToInt32(medico["ID_STATUS"])
                    },
                    Email = medico["DS_EMAIL"].ToString(),
                    Telefone = medico["NR_TELEFONE"].ToString(),
                    Celular = medico["NR_CELULAR"].ToString(),
                    Cep = medico["NR_CEP"].ToString(),
                    Cidade = new CidadeMOD
                    {
                        Codigo = Convert.ToInt32(medico["ID_CIDADE"]),
                        Estado = new EstadoMOD
                        {
                            CodigoEstado = Convert.ToInt32(medico["ID_ESTADO"])
                        }

                    },
                    Numero = medico["NR_ENDERECO"].ToString(),
                    Endereco = medico["DS_ENDERECO"].ToString(),
                    Bairro = medico["NM_BAIRRO"].ToString(),
                    Complemento = medico["DS_COMPLEMENTO"].ToString(),
                    Sexo = new SexoMOD{
                        CodigoSexo = Convert.ToInt32(medico["ID_SEXO"])
                    },
                    DataNascimento = Convert.ToDateTime(medico["DT_NASCIMENTO"])
                };
            }
            catch (Exception)
            {

                throw;
            }

        }

        public MedicoListaMOD MedicoList()
        {
            try
            {
                var lista = new MedicoListaMOD();
                var conexao = new AcessoSqlServer();
                foreach (DataRow medico in conexao.Pesquisar("USP_MEDICO_SEL_LIST").Rows)
                {
                    lista.Add(new MedicoMOD
                    {
                        Pessoa = new PessoaMOD
                        {
                            CodigoPessoa = Convert.ToInt32(medico["ID_MEDICO"])
                        },
                        NomeMedico = medico["NM_MEDICO"].ToString(),
                        Telefone = medico["NR_TELEFONE"].ToString(),
                        Celular = medico["NR_CELULAR"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
