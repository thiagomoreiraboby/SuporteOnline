using System;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Models.CustomAuthorize;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{
    public class AutenticacaoController : BaseController
    {
        private readonly UsuarioRepositorio _usuarioRepositotio = new UsuarioRepositorio();
        private readonly UsuaPermissaoRepositorio _usuaPermissaoRepositotio = new UsuaPermissaoRepositorio();
        [HttpGet]
        public ActionResult LogOn(string returnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOff();
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(Usuario usuario, string returnUrl)
        {
                var usua = _usuarioRepositotio.LogarUsuario(usuario.usua_login, usuario.usua_senha);
                if (usua != null && usua.usua_codigo != null && usua.empresa.empr_ativo)
                {
                    string[] permissoes = _usuaPermissaoRepositotio.Getpermissoes((int)usua.usua_codigo).Select(x => x.perm_nome).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel
                    {
                        UserId = (int)usua.usua_codigo,
                        FirstName = usua.usua_login,
                        LastName = usua.usua_nome,
                        EmpresaId = usua.empr_codigo,
                        Roles = permissoes
                    };
                    var userData = JsonConvert.SerializeObject(serializeModel);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, usua.usua_login, DateTime.Now, DateTime.Now.AddMinutes(180), false, userData);

                    var encTicket = FormsAuthentication.Encrypt(authTicket);
                    var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);
                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("~/Clientes/Index");
                }
                else
                {
                    //this.Flash("Danger", FlashLevel.Danger);
                    this.Flash("Senha invalida", FlashLevel.Error);
                    //this.Flash("Info", FlashLevel.Info);
                    //this.Flash("Primary", FlashLevel.Primary);
                    //this.Flash("Success", FlashLevel.Success);
                    //this.Flash("Warning", FlashLevel.Warning);


                }
            return View(usuario);
            
        }
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn", "Autenticacao", null);
        }
    }
}