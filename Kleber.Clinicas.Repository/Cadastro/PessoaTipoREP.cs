using Kleber.Clinicas.DataAccess;
using Kleber.Clinicas.Models.Cadastro;
using System;
using System.Data;

namespace Kleber.Clinicas.Repository.Cadastro
{
    public class PessoaTipoREP
    {
        public PessoaTipoListaMOD PessoaTipoLista()
        {
            try
            {
                var conexao = new AcessoSqlServer();
                var lista = new PessoaTipoListaMOD();

                foreach (DataRow PessoaTipo in conexao.Pesquisar("USP_PESSOA_TIPO_LISTA").Rows)
                {
                    lista.Add(new PessoaTipoMOD
                    {
                        CodigoPessoaTipo = Convert.ToInt32(PessoaTipo["ID_TIPO_PESSOA"]),
                        TipoPessoa = PessoaTipo["DS_TIPO_PESSOA"].ToString()
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
