using Kleber.Clinicas.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.Repository.Financeiro.Orcamento;

namespace Kleber.Clinicas.Business.Financeiro.Orcamento
{
    public class OrcamentoBUS
    {
        //Método que valida os dados antes de chamar o repositório para inserção
        public void validarOrcamento(OrcamentoMOD orcamentoMOD)
        {
            try
            {
                if (orcamentoMOD.Cliente.Pessoa.CodigoPessoa.ToString() == "" || orcamentoMOD.Cliente.Pessoa.CodigoPessoa <= 0)
                {
                    throw new Exception("Informe o Cliente !");
                }
                else if (orcamentoMOD.Consultorio.Pessoa.CodigoPessoa.ToString() == "" || orcamentoMOD.Consultorio.Pessoa.CodigoPessoa <= 0)
                {
                    throw new Exception("Informe o Consultório !");
                }
                else if (orcamentoMOD.Medico.Pessoa.CodigoPessoa.ToString() == "" || orcamentoMOD.Medico.Pessoa.CodigoPessoa <= 0)
                {
                    throw new Exception("Informe o Cliente !");
                }
                else if (orcamentoMOD.Status.CodigoStatus.ToString() == "" || orcamentoMOD.Status.CodigoStatus <= 0)
                {
                    throw new Exception("Informe o Status !");
                }
                else if (orcamentoMOD.DataOrcamento.Date < DateTime.Now.Date)
                {
                    throw new Exception("Data do Orçamento não pode ser menor que a data atual !");
                }
                else if (orcamentoMOD.Validade.Date < DateTime.Now.Date || orcamentoMOD.Validade.Date < orcamentoMOD.DataOrcamento.Date)
                {
                    throw new Exception("Data de Vencimento deve ser maior que a data atual e 'Data do Orçamento'!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //
        //Método que chama a classe repositório para inserção
        public String Inserir(OrcamentoMOD orcamentoMOD)
        {
            try
            {
                return new OrcamentoREP().Inserir(orcamentoMOD);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public String Cancelar(int idOrcamento)
        {
            try
            {
                return new OrcamentoREP().Cancelar(idOrcamento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Delete(int idOrcamento)
        {
            try
            {
                return new OrcamentoREP().Delete(idOrcamento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
