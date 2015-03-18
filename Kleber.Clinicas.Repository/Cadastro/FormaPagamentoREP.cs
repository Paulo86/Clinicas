using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class FormaPagamentoREP
    {
        /// <inserir>
        /// Inseri uma nova forma de pagamento
        /// </inserir>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public String Inserir(FormaPagamentoMOD formaPagamento)
        {
            try
            {
                var acessoDados = new AcessoSqlServer();
                acessoDados.AdicionarParametros("@DS_FORMA_PAGTO", formaPagamento.Descricao);
                return acessoDados.Persistencia("USP_FORMA_PAGTO_INS");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <atualizar>
        /// Atualiza uma forma de pagamento já existente
        /// </atualizar>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public String Atualizar(FormaPagamentoMOD formaPagamento)
        {
            try
            {
                var acessaDados = new AcessoSqlServer();
                acessaDados.AdicionarParametros("@ID_FORMA_PAGTO", formaPagamento.Codigo);
                acessaDados.AdicionarParametros("@DS_FORMA_PAGTO", formaPagamento.Descricao);
                return acessaDados.Persistencia("USP_FORMA_PAGTO_UPD");
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        /// <excluir>
        /// Exclui uma forma de pagamento existente
        /// </excluir>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public String Excluir(Int32 Codigo)
        {
            try
            {
                var acessaDados = new AcessoSqlServer();
                acessaDados.AdicionarParametros("@ID_FORMA_PAGTO", Codigo);
                return acessaDados.Persistencia("USP_FORMA_PAGTO_DEL");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Lista>
        /// Retorna uma lista de todas as formas de pagamento cadastradas
        /// </Lista>
        /// <returns></returns>
        public FormaPagamentoListaMOD ListByAll()
        {
            try
            {
                var list = new FormaPagamentoListaMOD();
                var acessaDados = new AcessoSqlServer();
                var dados = acessaDados.Pesquisar("USP_FORMA_PAGTO_SEL_LIST");
                foreach (DataRow dado in dados.Rows)
                {
                    list.Add(new FormaPagamentoMOD
                    {
                        Codigo = Convert.ToInt32(dado["ID_FORMA_PAGTO"]),
                        Descricao = dado["DS_FORMA_PAGTO"].ToString()
                    });
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <FormaPagamento>
        /// Retorna um registro de forma de pagamento
        /// </FormaPagamento>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public FormaPagamentoMOD FormaPamentoById(Int32 Codigo)
        {
            try
            {
                var acessaDados = new AcessoSqlServer();
                var dado = acessaDados.Pesquisar("USP_FORMA_PAGTO_SEL_BY_ID").Rows[0];
                return new FormaPagamentoMOD
                {
                    Codigo = Convert.ToInt32(dado["ID_FORMA_PAGTO"]),
                    Descricao = dado["DS_FORMA_PAGTO"].ToString()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
