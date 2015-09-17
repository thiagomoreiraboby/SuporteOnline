using System.Data.Entity;
using System.Linq;
using WebApplication1.Models.Interface;

namespace WebApplication1.Models.Repositorio
{
    public class GrupoRepositorio: RepositotioBase<GrupCliente>, IGrupoRepositorio
    {
        public void Deletargrupo(GrupCliente grupo)
        {
            foreach (var cliente in Db.Clientes.ToList().Where(x => x.grcl_codigo == grupo.grcl_codigo))
            {
                cliente.grcl_codigo = 1;
                Db.Entry(cliente).State = EntityState.Modified;
            }
            Db.Set<GrupCliente>().Remove(grupo);
            Db.SaveChanges();
        }
    }
}
