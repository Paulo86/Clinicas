using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;

namespace Kleber.Clinicas.Business.Cadastro
{
    public class MedicoBUS
    {
        public String Inserir(MedicoMOD medico)
        {
            try
            {
                return new MedicoREP().Inserir(medico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Atualizar(MedicoMOD medico)
        {
            try
            {
                return new MedicoREP().Atualizar(medico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MedicoMOD MedicoById(Int32 CodigoMedico)
        {
            try
            {
                return new MedicoREP().MedicoById(CodigoMedico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MedicoListaMOD MedicoList()
        {
            try
            {
                return new MedicoREP().MedicoList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ValidarDados(MedicoMOD medico)
        {
            try
            {
                if (medico.Consultorio.Pessoa.CodigoPessoa == 0)
                    throw new Exception("Consultório do médico é obrigatório !");
                else if (medico.Sexo.CodigoSexo == 0)
                    throw new Exception("Sexo do médico é obrigatório !");
                else if (medico.NomeMedico.Trim().Equals(string.Empty))
                    throw new Exception("Nome do médico é obrigatório !");
                else if (medico.Cpf.Trim().Equals(string.Empty))
                    throw new Exception("CPDF do médico é obrigatório !");
                else if (medico.Rg.Trim().Equals(string.Empty))
                    throw new Exception("RG do médico é obrigatório !");
                else if (medico.Crm.Trim().Equals(string.Empty))
                    throw new Exception("Numero do CRM do médico é obrigatório !");
                else if (medico.Status.CodigoStatus == 0)
                    throw new Exception("Informe o Status do médico !");
                else if (medico.Cidade.Codigo == 0)
                    throw new Exception("Cidade é obrigatório !");
                else if (medico.DataNascimento.ToString().Trim().Equals(string.Empty))
                    throw new Exception("Data de Nascimento é Obrigatório !");
                else if (medico.DataNascimento < new DateTime(1900, 01, 01))
                    throw new Exception("Data de Nascimento não pode ser menor que 01/01/1900 !");
                else if (medico.DataNascimento > DateTime.Now)
                    throw new Exception("Data de Nascimento não pode ser maior que a data atual !");
                else if (medico.Sexo.CodigoSexo == 0)
                    throw new Exception("Sexo é Obrigatório !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Excluir(Int32 CodigoMedico)
        {
            try
            {
                return new MedicoREP().Excluir(CodigoMedico);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
