using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;


namespace Kleber.Clinicas.Business.Cadastro
{
    public class ServicoBUS
    {
        public String Inserir(ServicoMOD servico)
        {
            try
            {
                return new ServicoREP().Inserir(servico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Atualizar(ServicoMOD servico)
        {
            try
            {
                return new ServicoREP().Atualizar(servico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Excluir(Int32 CodigoServico)
        {
            try
            {
                return new ServicoREP().Excluir(CodigoServico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServicoMOD ServicoById(Int32 CodigoServico)
        {
            try
            {
                return new ServicoREP().ServicoById(CodigoServico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServicoListaMOD ServicoList()
        {
            try
            {
                return new ServicoREP().ServicoList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ValidarDados(ServicoMOD servico)
        {
            try
            {
                if (servico.Descricao.Trim().Equals(string.Empty))
                    throw new Exception("Informe a Descrição do Serviço !");
                else if (servico.Valor == 0M)
                    servico.Valor = 0M;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
