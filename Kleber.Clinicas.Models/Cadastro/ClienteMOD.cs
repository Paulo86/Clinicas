using System;

namespace Kleber.Clinicas.Models.Cadastro
{
   public class ClienteMOD
    {
       public ClienteMOD()
       {
           Pessoa = new PessoaMOD();
           Cidade = new CidadeMOD();
           Status = new StatusMOD();
           Sexo = new SexoMOD();
       }
       public DateTime DataEmissaoRg { get; set; }
       public DateTime DataNascimento { get; set; }
       public SexoMOD Sexo { get; set; }
        public PessoaMOD Pessoa { get; set; }
        public String PrimeiroNome { get; set; }
        public String SobreNome { get; set; }
        public String NomeCompleto { get; set; }
        public String Rg { get; set; }
        public String Cpf { get; set; }
        public String Email { get; set; }
        public StatusMOD Status { get; set; }
        public CidadeMOD Cidade { get; set; }
        public String NomeBairro { get; set; }
        public String Endereco { get; set; }
        public String Numero { get; set; }
        public String Cep { get; set; }
        public String Complemento { get; set; }
        public String Telefone { get; set; }
        public String Celular { get; set; }
    }
}
