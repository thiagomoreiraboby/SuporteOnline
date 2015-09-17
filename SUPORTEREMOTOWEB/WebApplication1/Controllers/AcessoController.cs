using System;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{
    [CustomAuthorize(Roles = "User")]
    public class AcessoController : BaseController
    {
        private readonly ClienteRepositorio _repositorio = new ClienteRepositorio();

        [HttpGet]
        public ActionResult Abrir(int id)
        {
            var cliente = _repositorio.GetporId(id);
            _repositorio.Commit();
            if (cliente.clie_status && !cliente.clie_emuso)
            {
                //if (System.IO.File.Exists(@"C:\SihlSuporte\sihlviewer.exe"))
                    return View(cliente);

                //return RedirectToAction("Download", "Acesso");
            }
            return RedirectToAction("Index", "Clientes");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Abrir(Cliente clientes)
        {
                try
                {
                    //clientes.clie_status = false;
                    clientes.usua_codigo = UsuarioLogado.UserId;
                    _repositorio.Update(clientes);
                    _repositorio.Commit();
                }
                catch (Exception ex)
                {
                    // ignored
                }

            return View(clientes);
        }
        [AllowAnonymous]
        public ActionResult Download()
        {
            return View();
        }
    }


}