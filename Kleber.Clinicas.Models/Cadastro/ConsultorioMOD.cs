using System;

namespace Kleber.Clinicas.Models.Cadastro
{
   public class ConsultorioMOD
    {
       public ConsultorioMOD()
       {
           Pessoa = new PessoaMOD();
           Status = new StatusMOD();
           Cidade = new CidadeMOD();
       }
       public PessoaMOD Pessoa { get; set; }
       public String RazaoSocial { get; set; }
       public String NomeFantasia { get; set; }
       public String CpfCnpj { get; set; }
       public String RgIE { get; set; }
       public String Telefone { get; set; }
       public String Fax { get; set; }
       public String Email { get; set; }
       public string NomeContato { get; set; }
       public String TelefoneContato { get; set; }
       public String CelularContato { get; set; }
       public String EmailContato { get; set; }
       public String Observacao { get; set; }
       public StatusMOD Status { get; set; }
       public CidadeMOD Cidade { get; set; }
       public String Cep { get; set; }
       public String Endereco { get; set; }
       public String Numero { get; set; }
       public String Complemento { get; set; }
       public String NomeBairro { get; set; }
    }
}
