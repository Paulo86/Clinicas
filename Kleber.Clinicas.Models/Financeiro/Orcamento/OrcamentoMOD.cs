using Kleber.Clinicas.Models.Cadastro;
using System;

namespace Kleber.Clinicas.Models.Financeiro
{
    public class OrcamentoMOD
    {
        public OrcamentoMOD()
        {
            Status = new StatusMOD();
            Cliente = new ClienteMOD();
            Consultorio = new ConsultorioMOD();
            Medico = new MedicoMOD();
            FormaPagamento = new FormaPagamentoMOD();

        }
        public string NumeroFicha { get; set; }
        public int QuantidadeItens { get; set; }
        public Int32 CodigoOrcamento { get; set; }

        public StatusMOD Status { get; set; }

        public ClienteMOD Cliente { get; set; }

        public ConsultorioMOD Consultorio { get; set; }

        public MedicoMOD Medico { get; set; }

        public FormaPagamentoMOD FormaPagamento { get; set; }

        public String CondiccaoPagamento { get; set; }

        public DateTime DataOrcamento { get; set; }

        public DateTime Validade { get; set; }

        public Decimal ValorTotalBruto { get; set; }

        public Decimal ValorTotalDesconto { get; set; }

        public Decimal ValorTotalAcrescimo { get; set; }

        public Decimal ValorTotalLiquido { get; set; }

        public String Observacao { get; set; }
    }
}
