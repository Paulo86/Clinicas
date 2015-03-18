using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class SexoREP
    {
        public SexoListaMOD SexoLista()
        {
            try
            {
                var lista = new SexoListaMOD();
                var conexao = new AcessoSqlServer();
                foreach (DataRow sexo in conexao.Pesquisar("USP_SEXO_LIST").Rows)
                {
                    lista.Add(new SexoMOD
                    {
                        CodigoSexo = Convert.ToInt32(sexo["ID_SEXO"]),
                        Sexo = sexo["DS_SEXO"].ToString()
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
