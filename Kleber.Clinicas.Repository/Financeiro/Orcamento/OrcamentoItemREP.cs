using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Financeiro.Orcamento;
using Kleber.Clinicas.Models.Financeiro;
using Kleber.Clinicas.Models.Cadastro;
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

        public OrcamentoItemListaMOD itensOrcamento(int idOrcamento)
        {
            try
            {
                OrcamentoItemListaMOD lista = new OrcamentoItemListaMOD();
                //
                AcessoSqlServer aSql = new AcessoSqlServer();
                aSql.LimparParametros();
                aSql.AdicionarParametros("@ID_ORCAMENTO", idOrcamento);
                foreach (DataRow item in aSql.Pesquisar("USP_ORCAMENTO_SEL_LIST_ITENS_ORCAMENTO").Rows)
                {
                    OrcamentoItemMOD orcamentoItemMOD = new OrcamentoItemMOD();
                    lista.Add(new OrcamentoItemMOD
                    {
                        Orcamento = new OrcamentoMOD
                        {
                            CodigoOrcamento = Convert.ToInt32(item["ID_ORCAMENTO"]),
                            ValorTotalBruto = Convert.ToDecimal(item["VL_SERVICO_TOTAL_BRUTO"]),
                            ValorTotalDesconto = Convert.ToDecimal(item["VL_DESCONTO_TOTAL"]),
                            ValorTotalAcrescimo = Convert.ToDecimal(item["VL_ACRESCIMO_TOTAL"]),

                        },
                        Servico = new ServicoMOD
                        {
                            CodigoServico = Convert.ToInt32(item["ID_SERVICO"]),
                            Descricao = item["DS_SERVICO"].ToString(),
                            Valor = Convert.ToDecimal(item["VL_SERVICO_UNIT"])
                        },
                        Quantidade = Convert.ToInt32(item["QTD_SERVICO"]),
                        AcrescimoValor = Convert.ToDecimal(item["VL_ACRESCIMO_UNIT"]),
                        DescontoValor = Convert.ToDecimal(item["VL_DESCONTO_UNIT"]),
                        ValorTotalItem = Convert.ToDecimal(item["VL_SERVICO_TOTAL_LIQ"]),
                        Sequencia = Convert.ToInt32(item["NM_SEQUENCIA"])
                    });
                }
                //
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public OrcamentoMOD Delete(int idOrcamento, int sequencia, int idServico)
        {
            try
            {
                OrcamentoMOD orcamentoMOD = new OrcamentoMOD();
                //
                AcessoSqlServer aSql = new AcessoSqlServer();
                aSql.LimparParametros();
                aSql.AdicionarParametros("@ID_ORCAMENTO", idOrcamento);
                aSql.AdicionarParametros("@ID_SERVICO", idServico);
                aSql.AdicionarParametros("@NM_SEQUENCIA", sequencia);
                //
                DataTable dt = aSql.Pesquisar("USP_ORCAMENTO_SERVICO_DEL");
                if (dt.Rows.Count > 0)
                {
                    DataRow resultado = dt.Rows[0];
                    orcamentoMOD = new OrcamentoMOD
                    {
                        CodigoOrcamento = Convert.ToInt32(resultado["ID_ORCAMENTO"]),
                        ValorTotalBruto = Convert.ToDecimal(resultado["VL_TOTAL_BRUTO"]),
                        ValorTotalLiquido = Convert.ToDecimal(resultado["VL_TOTAL_LIQUIDO"]),
                        ValorTotalAcrescimo = Convert.ToDecimal(resultado["VL_TOTAL_ACRESCIMO"]),
                        ValorTotalDesconto = Convert.ToDecimal(resultado["VL_TOTAL_DESCONTO"]),
                        QuantidadeItens = Convert.ToInt32(resultado["QTD_ITENS"])
                    };
                }

                return orcamentoMOD;

            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
