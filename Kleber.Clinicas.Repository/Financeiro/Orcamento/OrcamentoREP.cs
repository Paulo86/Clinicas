using Kleber.Clinicas.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.DataAccess;

namespace Kleber.Clinicas.Repository.Financeiro.Orcamento
{
    public class OrcamentoREP
    {
        public String Inserir(OrcamentoMOD orcamentoMOD)
        {
            try
            {
                String retorno = String.Empty;
                var conexao = new AcessoSqlServer();
                //
                conexao.LimparParametros();
                //
                conexao.AdicionarParametros("@ID_ORCAMENTO", orcamentoMOD.CodigoOrcamento);
                conexao.AdicionarParametros("@NM_FICHA", orcamentoMOD.NumeroFicha);
                conexao.AdicionarParametros("@ID_CLIENTE", orcamentoMOD.Cliente.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@ID_CONSULTORIO", orcamentoMOD.Consultorio.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@ID_MEDICO", orcamentoMOD.Medico.Pessoa.CodigoPessoa);
                conexao.AdicionarParametros("@ID_STATUS", orcamentoMOD.Status.CodigoStatus);
                conexao.AdicionarParametros("@VL_TOTAL_BRUTO", orcamentoMOD.ValorTotalBruto);
                conexao.AdicionarParametros("@VL_TOTAL_LIQUIDO", orcamentoMOD.ValorTotalLiquido);
                conexao.AdicionarParametros("@VL_TOTAL_ACRESCIMO", orcamentoMOD.ValorTotalAcrescimo);
                conexao.AdicionarParametros("@VL_TOTAL_DESCONTO", orcamentoMOD.ValorTotalDesconto);
                conexao.AdicionarParametros("@QTD_ITENS", orcamentoMOD.QuantidadeItens);
                conexao.AdicionarParametros("@DS_OBSERVACAO", orcamentoMOD.Observacao);
                conexao.AdicionarParametros("@DT_ORCAMENTO", orcamentoMOD.DataOrcamento.Date);
                conexao.AdicionarParametros("@DT_VENCIMENTO", orcamentoMOD.Validade.Date);
                //
                retorno = conexao.Persistencia("USP_ORCAMENTO_PERCISTENCIA");
                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
