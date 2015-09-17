using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Services.Protocols;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositorio
{
    public class PermissaoRepositorio : RepositotioBase<Permissao>, IPermissaoRepositorio
    {

    }
}
