using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class ServicoREP
    {
        public String Inserir(ServicoMOD servico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@DS_SERVICO", servico.Descricao);
                conexao.AdicionarParametros("@VL_SERVICO", servico.Valor);
                return conexao.Persistencia("USP_SERVICO_INS");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Atualizar(ServicoMOD servico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_SERVICO", servico.CodigoServico);
                conexao.AdicionarParametros("@DS_SERVICO", servico.Descricao);
                conexao.AdicionarParametros("@VL_SERVICO", servico.Valor);
                return conexao.Persistencia("USP_SERVICO_UPD");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Excluir(Int32 CodigoServico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_SERVICO", CodigoServico);
                return conexao.Persistencia("USP_SERVICO_DEL");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServicoMOD ServicoById(Int32 CodigoServico)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                conexao.LimparParametros();
                conexao.AdicionarParametros("@ID_SERVICO", CodigoServico);

                DataRow servico = conexao.Pesquisar("USP_SERVICO_SEL").Rows[0];
                return new ServicoMOD
                {
                    CodigoServico = Convert.ToInt32(servico["ID_SERVICO"]),
                    Descricao = servico["DS_SERVICO"].ToString(),
                    Valor = Convert.ToDecimal(servico["VL_SERVICO"])
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServicoListaMOD ServicoList()
        {
            try
            {
                var lista = new ServicoListaMOD();
                var conexao = new AcessoSqlServer();
                foreach (DataRow servico in conexao.Pesquisar("USP_SERVICO_SEL_LIST").Rows)
                {
                    lista.Add(new ServicoMOD
                    {
                        CodigoServico = Convert.ToInt32(servico["ID_SERVICO"]),
                        Descricao = servico["DS_SERVICO"].ToString(),
                        Valor = Convert.ToDecimal(servico["VL_SERVICO"])
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
