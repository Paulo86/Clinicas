using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
   public class SexoBUS
    {
       public SexoListaMOD SexoLista()
       {
           try
           {
               return new SexoREP().SexoLista();
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
