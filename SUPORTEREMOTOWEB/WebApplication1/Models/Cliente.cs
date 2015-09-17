using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Cliente
    {
        [DisplayName("Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? clie_codigo { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o Nome")]
        public string clie_nome { get; set; }
        [DisplayName("ID VNC")]
        public int clie_idvnc { get; set; }
        [DisplayName("Online?")]
        public bool clie_status { get; set; }
        [DisplayName("Em Uso?")]
        public bool clie_emuso { get; set; }
        [DisplayName("OBS")]
        [DataType(DataType.MultilineText)]
        public string clie_obs { get; set; }
        [DisplayName("Grupo")]
        public int grcl_codigo { get; set; }
        [DisplayName("Empresa")]
        public int empr_codigo { get; set; }
        [DisplayName("Usuário")]
        public int? usua_codigo { get; set; }
        public virtual GrupCliente grupo { get; set; }
        public virtual Empresa empresa { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}
