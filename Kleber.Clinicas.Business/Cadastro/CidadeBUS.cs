using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
    public class CidadeBUS
    {
        public CidadeListaMOD CidadeLista(Int32 CodigoEstado)
        {
            try
            {
                return new CidadeREP().ListaCidade(CodigoEstado);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
