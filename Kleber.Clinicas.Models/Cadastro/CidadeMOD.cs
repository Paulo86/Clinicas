using System;

namespace Kleber.Clinicas.Models.Cadastro
{
   public class CidadeMOD
    {
        public CidadeMOD()
        {
            Estado = new EstadoMOD();
        }
        public Int32 Codigo { get; set; }
        public String NomeCidade { get; set; }
        public String CodigoIBGE { get; set; }
        public EstadoMOD Estado { get; set; }        
    }
}
