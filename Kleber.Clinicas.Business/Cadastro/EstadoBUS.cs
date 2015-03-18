using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
   public class EstadoBUS
    {
       public EstadoListaMOD EstadoLista()
       {
           try
           {
               return new EstadoREP().ListaEstados();
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
