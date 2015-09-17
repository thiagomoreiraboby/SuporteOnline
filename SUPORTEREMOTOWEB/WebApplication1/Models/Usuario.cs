
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Usuario
    {


        [DisplayName("Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? usua_codigo { get; set; }
        [DisplayName("Login")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail invalido")]
        [EmailAddress]
        [Required(ErrorMessage = "Digite o Login")]
        [MaxLength(80, ErrorMessage = "O campo {0}, tem o tamanho maximo: {1}")]
        [MinLength(4, ErrorMessage = "O campo {0}, tem o tamanho minimo: {1}")]
        public string usua_login { get; set; }
        [DisplayName("Senha")]
        [Required( ErrorMessage = "Digite a Senha")]
        [MaxLength(80, ErrorMessage = "O campo {0}, tem o tamanho maximo: {1}")]
        [MinLength(4, ErrorMessage = "O campo {0}, tem o tamanho minimo: {1}")]
        [DataType(DataType.Password)]
        public string usua_senha { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o Nome")]
        [MaxLength(120, ErrorMessage = "O campo {0}, tem o tamanho maximo: {1}")]
        [MinLength(5, ErrorMessage = "O campo {0}, tem o tamanho minimo: {1}")]
        public string usua_nome { get; set; }

        public int empr_codigo { get; set; }
        public virtual Empresa empresa { get; set; }

        [NotMapped] 
        public int idpermissao { get; set; }

        [NotMapped]
        public string addtipo { get; set; }

    }
}
