using System;
using System.Web.Mvc;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{

    [CustomAuthorize(Roles = "User")]
    public class UsuarioLogadoController : BaseController
    {
        private readonly UsuarioRepositorio _usuarioRepositotio = new UsuarioRepositorio();
        [HttpGet]
        public ActionResult Edit()
        {
            if (UsuarioLogado == null || UsuarioLogado.UserId == 0)
                return RedirectToAction("LogOff", "Autenticacao");
            var usuario = _usuarioRepositotio.GetporId(UsuarioLogado.UserId);
           //_usuarioRepositotio.Commit();
            return View(usuario);
        }

        // POST: usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (!_usuarioRepositotio.Usuariojacadastrado(usuario.usua_login, usuario.usua_codigo))
                {
                    var usua = _usuarioRepositotio.GetporId((int)usuario.usua_codigo);
                    usua.usua_login = usuario.usua_login;
                    usua.usua_nome = usuario.usua_nome;
                    usua.usua_senha = usuario.usua_senha;
                    _usuarioRepositotio.Update(usua);
                    _usuarioRepositotio.Commit();
                    return RedirectToAction("Index", "Clientes");
                }
                this.Flash("E-mail login já cadastrado", FlashLevel.Info);
                return View(usuario);




               
            }
            catch (Exception ex)
            {
                return View(usuario);
            }
        }
    }
}
