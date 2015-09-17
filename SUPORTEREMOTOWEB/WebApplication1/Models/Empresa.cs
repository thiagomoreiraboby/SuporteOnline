using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Empresa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? empr_codigo { get; set; }
        public bool empr_ativo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o Nome")]
        public string empr_nome { get; set; }
        [DisplayName("CNPJ/CPF")]
        [Required(ErrorMessage = "Digite o CNPJ ou CPF")]
        public string empr_documento { get; set; }
        [DisplayName("Enderço")]
        [Required(ErrorMessage = "Digite o Enderço")]
        public string empr_endereco { get; set; }
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Digite o Telefone")]
        public string empr_telefone { get; set; }
        [DisplayName("Contato")]
        [Required(ErrorMessage = "Digite o Contato")]
        public string empr_contato { get; set; }

        [NotMapped]
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Digite o Login")]
        [MaxLength(80, ErrorMessage = "O campo {0}, tem o tamanho maximo: {1}")]
        [MinLength(4, ErrorMessage = "O campo {0}, tem o tamanho minimo: {1}")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail invalido")]
        [EmailAddress]
        public string empr_email { get; set; }
        [NotMapped]
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Digite a Senha")]
        [MaxLength(80, ErrorMessage = "O campo {0}, tem o tamanho maximo: {1}")]
        [MinLength(4, ErrorMessage = "O campo {0}, tem o tamanho minimo: {1}")]
        [DataType(DataType.Password)]
        public string empr_senha { get; set; }

        
    }
}
