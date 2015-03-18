using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
   public class PessoaTipoBUS
    {
       public PessoaTipoListaMOD PessoaTipoLista()
       {
           try
           {               
               return new PessoaTipoREP().PessoaTipoLista();               
              // var repositorio = new PessoaTipoREP();
              // return repositorio.PessoaTipoLista();
               
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
