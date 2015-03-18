using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class EstadoREP
    {
        public EstadoListaMOD ListaEstados()
        {
            try
            {
                var lista = new EstadoListaMOD();

                var conexao = new AcessoSqlServer();
                foreach (DataRow Estado in conexao.Pesquisar("USP_ESTADO_LISTA").Rows)
                {
                    lista.Add(new EstadoMOD
                    {
                        CodigoEstado = Convert.ToInt32(Estado["ID_ESTADO"]),
                        NomeEstado = Estado["NM_ESTADO"].ToString()
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
