namespace WebApplication1.Models.Interface
{
    public interface IUsuarioRepositorio : IRepositotioBase<Usuario>
    {
        Usuario LogarUsuario(string login, string senha);
        bool Usuariojacadastrado(string login, int? id);
    }
}
