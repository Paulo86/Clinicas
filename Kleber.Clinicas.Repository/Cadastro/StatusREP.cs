using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
   public class StatusREP
    {
       public StatusListaMOD StatusLista()
       {
           try
           {
               var lista = new StatusListaMOD();
               var conexao = new AcessoSqlServer();
               foreach (DataRow status in conexao.Pesquisar("USP_STATUS_LISTA").Rows)
               {
                   lista.Add(new StatusMOD {
                       CodigoStatus = Convert.ToInt32(status["ID_STATUS"]),
                       Status = status["DS_STATUS"].ToString()                    
                   });
               }

               return lista;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
