using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
    public class FormaPagamentoBUS
    {
        /// <Validações>
        /// Valida os dados para inserir e atualizar
        /// </Validações>
        /// <param name="formaPagamento"></param>
        public void ValidarDados(FormaPagamentoMOD formaPagamento)
        {
            try
            {
                if (String.IsNullOrEmpty(formaPagamento.Descricao.Trim()))
                {
                    throw new Exception("Campo Descrição é Obrigatório !");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Inserir>
        /// Inserir uma nova forma de Pagamento após validar
        /// </Inserir>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public String Inserir(FormaPagamentoMOD formaPagamento)
        {
            try
            {
                return new FormaPagamentoREP().Inserir(formaPagamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Atualizar>
        /// Atualiza um dados existente
        /// </Atualizar>
        /// <param name="formaPagamento"></param>
        /// <returns></returns>
        public String Atualizar(FormaPagamentoMOD formaPagamento)
        {
            try
            {
                return new FormaPagamentoREP().Atualizar(formaPagamento);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Excluir>
        /// Exclui uma forma de pagamento existente
        /// </Excluir>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public String Excluir(Int32 Codigo)
        {
            try
            {
                return new FormaPagamentoREP().Excluir(Codigo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <Lista>
        /// Retorna uma lista de dados
        /// </Lista>
        /// <returns></returns>
        public FormaPagamentoListaMOD FormaPagamentoListByAll()
        {
            try
            {
                return new FormaPagamentoREP().ListByAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <FormaPagamento>
        /// Retorna um objeto FormaPagamentoMOD com informação
        /// </FormaPagamento>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public FormaPagamentoMOD FormaPagamentoById(Int32 Codigo)
        {
            try
            {
                return new FormaPagamentoREP().FormaPamentoById(Codigo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
