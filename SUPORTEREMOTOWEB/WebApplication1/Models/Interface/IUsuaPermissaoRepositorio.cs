using System.Collections.Generic;

namespace WebApplication1.Models.Interface
{
    public interface IUsuaPermissaoRepositorio : IRepositotioBase<UsuaPermissao>
    {
        List<Permissao> Getpermissoes(int idususario);
    }
}
