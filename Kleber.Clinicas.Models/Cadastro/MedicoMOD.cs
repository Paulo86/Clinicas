using System;

namespace Kleber.Clinicas.Models.Cadastro
{
   public class MedicoMOD
    {
       public MedicoMOD()
       {
           this.Pessoa = new PessoaMOD();
           this.Cidade = new CidadeMOD();
           this.Consultorio = new ConsultorioMOD();
           this.Status = new StatusMOD();
           this.Sexo = new SexoMOD();
       }

       public SexoMOD Sexo { get; set; }
       public DateTime DataNascimento { get; set; }
        public PessoaMOD Pessoa { get; set; }

        public CidadeMOD Cidade { get; set; }

        public String NomeMedico { get; set; }
       
       public String  Rg { get; set; }

        public String Cpf { get; set; }
       
       public String Crm { get; set; }

       public ConsultorioMOD Consultorio { get; set; }

       public StatusMOD Status { get; set; }

       public String Email { get; set; }

       public String Telefone { get; set; }

       public String Celular { get; set; }

       public String Cep { get; set; }

       public String Endereco { get; set; }

       public String Numero { get; set; }

       public String Bairro { get; set; }

       public String Complemento { get; set; }
    }
}
