using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
    public class ConsultorioBUS
    {
        public void ValidaDados(ConsultorioMOD consultorio)
        {
            try
            {
                if (String.IsNullOrEmpty(consultorio.RazaoSocial.Trim()))
                    throw new Exception("O preenchimento do campo Razão Social é Obrigatório !");
                else if (String.IsNullOrEmpty(consultorio.NomeFantasia.Trim()))
                    throw new Exception("O preenchimento do campo Nome Fantasia é Obrigatório !");
                else if (String.IsNullOrEmpty(consultorio.CpfCnpj.Trim()))
                    throw new Exception("O preenchimento do campo CPF/CNPJ é Obrigatório !");
                else if (String.IsNullOrEmpty(consultorio.CpfCnpj.Trim()))
                    throw new Exception("O preenchimento do campo RG/IE é Obrigatório !");
                else if (consultorio.Status.CodigoStatus == 0)
                    throw new Exception("O campo Status é Obrigatório !");
                else if (consultorio.Pessoa.PessoaTipo.CodigoPessoaTipo == 0)
                    throw new Exception("O campo Tipo de Pessoa é Obrigatório !");
                else if (consultorio.Cidade.Codigo == 0)
                    throw new Exception("O campo Cidade é Obrigatório !");
                else if (consultorio.Cidade.Estado.CodigoEstado == 0)
                    throw new Exception("O campo Status é Obrigatório !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Inserir(ConsultorioMOD consultorio)
        {
            try
            {
                return new ConsultorioREP().Inserir(consultorio);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ConsultorioListaMOD ListaGridPrincipal()
        {
            try
            {
                return new ConsultorioREP().ListaGridPrincipal();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ConsultorioMOD Detalhes(Int32 CodigoCosultorio)
        {
            try
            {
                return new ConsultorioREP().Detalhes(CodigoCosultorio);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Excluir(Int32 CodigoConsultorio)
        {
            try
            {
                return new ConsultorioREP().Excluir(CodigoConsultorio);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Atualizar(ConsultorioMOD consultorio)
        {
            try
            {
                return new ConsultorioREP().Atualizar(consultorio);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
