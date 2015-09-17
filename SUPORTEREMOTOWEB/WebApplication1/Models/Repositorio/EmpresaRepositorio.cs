using System.Data.Entity;
using System.Linq;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositorio
{
    public class EmpresaRepositorio : RepositotioBase<Empresa>, IEmpresaRepositorio
    {
        
    }
}
