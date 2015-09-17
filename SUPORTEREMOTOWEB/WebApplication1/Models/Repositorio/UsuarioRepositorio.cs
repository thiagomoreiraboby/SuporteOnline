using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Protocols;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositorio
{
    public class UsuarioRepositorio : RepositotioBase<Usuario>, IUsuarioRepositorio
    {

        public Usuario LogarUsuario(string login, string senha)
        {
            var usuario =
                Db.Set<Usuario>().ToList().FirstOrDefault(usua => usua.usua_login == login && usua.usua_senha == senha);
          
            return usuario;

        }


        public bool Usuariojacadastrado(string login, int? id)
        {
            if (id != null)
                return Db.Set<Usuario>().ToList().Any(usua => usua.usua_login == login && usua.usua_codigo != id);
            return Db.Set<Usuario>().ToList().Any(usua => usua.usua_login == login);
        }
    }
}
