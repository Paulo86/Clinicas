using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.Models.Cadastro;

namespace Kleber.Clinicas.Models.Financeiro.Orcamento
{
   public class OrcamentoItemMOD
    {
        public OrcamentoItemMOD()
        {
            Servico = new ServicoMOD();
            Orcamento = new OrcamentoMOD();
        }
        public OrcamentoMOD Orcamento { get; set; }

        public ServicoMOD Servico { get; set; }

        public Int32 Quantidade { get; set; }

        public string TipoDesconto { get; set; }

        public Decimal DescontoValor { get; set; }

        public string TipoAcrescimo { get; set; }

        public Decimal AcrescimoValor { get; set; }

        public String Importancia { get; set; }

        public Decimal ValorTotalItem { get; set; }

    }
}
