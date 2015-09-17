using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UsuaPermissao
    {
        public int usua_codigo { get; set; }
        public int perm_codigo { get; set; }
        public virtual Permissao Permissao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
