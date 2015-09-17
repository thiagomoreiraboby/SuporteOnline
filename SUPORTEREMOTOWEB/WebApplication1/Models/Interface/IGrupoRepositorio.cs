namespace WebApplication1.Models.Interface
{
    public interface IGrupoRepositorio : IRepositotioBase<GrupCliente>
    {
        void Deletargrupo(GrupCliente grupo);
    }
}
