using Kleber.Clinicas.Models.Cadastro;
using Kleber.Clinicas.Repository.Cadastro;
using System;

namespace Kleber.Clinicas.Business.Cadastro
{
    public class ClienteBUS
    {
        public void ValidarCliente(ClienteMOD cliente)
        {
            try
            {
                if (cliente.Status.CodigoStatus <= 0)
                    throw new Exception("Status do Cliente é Obrigatório !");
                else if (cliente.Sexo.CodigoSexo <= 0)
                    throw new Exception("Sexo do Cliente é Obrigatório !");
                else if (cliente.PrimeiroNome.Trim().Equals(String.Empty))
                    throw new Exception("Primeiro Nome do Cliente é Obrigatório !");
                else if (cliente.SobreNome.Trim().Equals(String.Empty))
                    throw new Exception("Sobre Nome do Cliente é Obrigatório !");
                else if (cliente.NomeCompleto.Trim().Equals(String.Empty))
                    throw new Exception("Nome Completo do Cliente é Obrigatório !");
                else if (cliente.Rg.Trim().Equals(String.Empty))
                    throw new Exception("RG é Obrigatório !");
                else if (cliente.DataEmissaoRg > DateTime.Now)
                    throw new Exception("Data de Emissão do RG não pode Ser Maior que a Data Atual !");
                else if (cliente.DataEmissaoRg < new DateTime(1900, 1, 1))
                    throw new Exception("Data de Emissão do RG tem que Ser Maior que 01/01/1900 !");
                else if (cliente.DataNascimento > DateTime.Now)
                    throw new Exception("Data de Nascimento não pode Ser Maior que a Data Atual !");
                else if (cliente.DataNascimento < new DateTime(1900, 1, 1))
                    throw new Exception("Data de Nacimento tem que Ser Maior que 01/01/1900 !");
                else if (cliente.Cpf.Trim().Equals(String.Empty))
                    throw new Exception("CPF é Obrigatório !");
                else if (cliente.Telefone.Trim().Equals(String.Empty) && cliente.Celular.Trim().Equals(String.Empty))
                    throw new Exception("Preencha um numero de Telefone !");
                else if (cliente.Cidade.Codigo <= 0)
                    throw new Exception("O campo Cidade é Obriatório !");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public String Inserir(ClienteMOD cliente)
        {
            try
            {
                return new ClienteREP().Inserir(cliente);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Atualizar(ClienteMOD cliente)
        {
            try
            {
                return new ClienteREP().Atualizar(cliente);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public String Excluir(Int32 CodigoCliente)
        {
            try
            {
                return new ClienteREP().Excluir(CodigoCliente);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ClienteMOD ClienteByID(Int32 CodigoCliente)
        {
            try
            {
                return new ClienteREP().ClienteByID(CodigoCliente);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ClienteListaMOD ClienteLista()
        {
            try
            {
                return new ClienteREP().ClienteLista();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ClienteListaMOD ClienteListaByDesc(String Descricao)
        {
            try
            {
                return new ClienteREP().ClienteListaByDesc(Descricao);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
