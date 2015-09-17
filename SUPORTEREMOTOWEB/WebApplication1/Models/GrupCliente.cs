using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class GrupCliente
    {
        [DisplayName("Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? grcl_codigo { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o Nome")]
        public string grcl_nome { get; set; }
        [DisplayName("Ativo")]
        public bool grcl_ativo { get; set; }
        [DisplayName("Empresa")]
        public int? empr_codigo { get; set; }
        public virtual Empresa empresa { get; set; }
    }
}
