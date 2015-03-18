using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
   public class StatusBUS
    {
       public StatusListaMOD StatusLista()
       {
           try
           {
               return new StatusREP().StatusLista();              

           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
