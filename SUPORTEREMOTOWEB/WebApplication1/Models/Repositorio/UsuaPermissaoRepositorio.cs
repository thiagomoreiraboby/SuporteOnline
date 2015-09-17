using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Protocols;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositorio
{
    public class UsuaPermissaoRepositorio : RepositotioBase<UsuaPermissao>, IUsuaPermissaoRepositorio
    {
        public List<Permissao> Getpermissoes(int idususario)
        {
            return Db.Set<UsuaPermissao>().ToList().Where(x => x.usua_codigo == idususario).Select(x=> x.Permissao).ToList();
        }
        
    }
}
