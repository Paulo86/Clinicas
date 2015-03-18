using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
   public class CidadeREP
    {
       public CidadeListaMOD ListaCidade(Int32 CodigoEstado)
       {
           try
           {
               var lista = new CidadeListaMOD();
               var conexao = new AcessoSqlServer();
               conexao.AdicionarParametros("@ID_ESTADO",CodigoEstado);
               foreach (DataRow Cidade in conexao.Pesquisar("USP_CIDADE_LISTA").Rows)
               {
                   lista.Add(new CidadeMOD { 
                        Codigo = Convert.ToInt32(Cidade["ID_CIDADE"]),
                         NomeCidade = Cidade["NM_CIDADE"].ToString()
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
