using Kleber.Clinicas.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.Models.Financeiro.Orcamento;
using Kleber.Clinicas.Repository.Financeiro.Orcamento;

namespace Kleber.Clinicas.Business.Financeiro.Orcamento
{
   public class OrcamentoItemBUS
    {       
        public OrcamentoMOD Inserir(OrcamentoItemMOD orcamentoItemMOD)
        {
            try
            {
                return new OrcamentoItemREP().Inserir(orcamentoItemMOD);
            }
            catch (Exception)
            {

                throw;
            }
        }
       //
        public OrcamentoItemListaMOD itensOrcamento(int idOrcamento)
        {
            try
            {
                return new OrcamentoItemREP().itensOrcamento(idOrcamento);
            }
            catch (Exception)
            {
                
                throw;
            }
        }       
       //
        public OrcamentoMOD Delete(int idOrcamento, int sequencia, int idServico)
        {
            try
            {
                return new OrcamentoItemREP().Delete(idOrcamento, sequencia, idServico);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
