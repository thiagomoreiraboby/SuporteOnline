using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    public class Permissao
    {

        
        [DisplayName("Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? perm_codigo { get; set; }
        [DisplayName("Premissão")]
        [Required(ErrorMessage = "Digite o nome")]
        public string perm_nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Digite a descriçao")]
        public string perm_descricao { get; set; }

        

    }
}
