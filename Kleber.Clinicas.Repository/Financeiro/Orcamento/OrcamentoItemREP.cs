using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Financeiro.Orcamento;
using Kleber.Clinicas.Models.Financeiro;
using System.Data;

namespace Kleber.Clinicas.Repository.Financeiro.Orcamento
{
    public class OrcamentoItemREP
    {
        public OrcamentoMOD Inserir(OrcamentoItemMOD orcamentoItemMOD)
        {
            try
            {
                var conexao = new AcessoSqlServer();
                var orcamentoMOD = new OrcamentoMOD();
                //
                conexao.LimparParametros();
                //
                conexao.AdicionarParametros("@ID_ORCAMENTO", orcamentoItemMOD.Orcamento.CodigoOrcamento);
                conexao.AdicionarParametros("@ID_SERVICO", orcamentoItemMOD.Servico.CodigoServico);
                conexao.AdicionarParametros("@QTD_SERVICO", orcamentoItemMOD.Quantidade);
                conexao.AdicionarParametros("@VL_SERVICO_UNIT", orcamentoItemMOD.Servico.Valor);
                conexao.AdicionarParametros("@TP_DESCONTO", orcamentoItemMOD.TipoDesconto);
                conexao.AdicionarParametros("@VL_DESCONTO_UNIT", orcamentoItemMOD.DescontoValor);
                conexao.AdicionarParametros("@TP_ACRESCIMO", orcamentoItemMOD.TipoAcrescimo);
                conexao.AdicionarParametros("@VL_ACRESCIMO_UNIT", orcamentoItemMOD.AcrescimoValor);
                //
                DataTable dataTable = conexao.Pesquisar("USP_ORCAMENTO_SERVICO_INS");
                if (dataTable.Rows.Count > 0)
                {
                    DataRow item = dataTable.Rows[0];
                    orcamentoMOD = new OrcamentoMOD
                    {
                        ValorTotalBruto = Convert.ToDecimal(item["VL_TOTAL_BRUTO"]),
                        ValorTotalLiquido = Convert.ToDecimal(item["VL_TOTAL_LIQUIDO"]),
                        ValorTotalAcrescimo = Convert.ToDecimal(item["VL_TOTAL_ACRESCIMO"]),
                        ValorTotalDesconto = Convert.ToDecimal(item["VL_TOTAL_DESCONTO"]),
                        QuantidadeItens = Convert.ToInt32(item["QTD_ITENS"])
                    };
                }
                else
                {
                    throw new Exception("Não foi possíve gravar o item !");
                }
                //
                return orcamentoMOD;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
