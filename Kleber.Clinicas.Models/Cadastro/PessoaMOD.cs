using System;

namespace Kleber.Clinicas.Models.Cadastro
{
   public class PessoaMOD
    {
        public PessoaMOD()
        {
            PessoaTipo = new PessoaTipoMOD();
        }
        public Int32 CodigoPessoa { get; set; }
        public PessoaTipoMOD PessoaTipo { get; set; }
    }
}
