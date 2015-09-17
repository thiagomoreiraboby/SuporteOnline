using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{
    public class EmpresaController : BaseController
    {
        private readonly EmpresaRepositorio _empresaRepositorio = new EmpresaRepositorio();
        private readonly UsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();
        private readonly UsuaPermissaoRepositorio _usuaPermissaoRepositorio = new UsuaPermissaoRepositorio();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
            try
            {
                if (!_usuarioRepositorio.Usuariojacadastrado(empresa.empr_email, null))
                {
                    empresa.empr_ativo = true;
                    _empresaRepositorio.Add(empresa);


                    var usuario = new Usuario();
                    usuario.empr_codigo = (int) empresa.empr_codigo;
                    usuario.usua_login = empresa.empr_email;
                    usuario.usua_senha = empresa.empr_senha;
                    usuario.usua_nome = empresa.empr_nome;
                    _usuarioRepositorio.Add(usuario);


                    if (usuario.usua_codigo != null)
                    {
                        var permissaoadm = new UsuaPermissao()
                        {
                            perm_codigo = 1,
                            usua_codigo = (int) usuario.usua_codigo
                        };
                        var permissaousr = new UsuaPermissao()
                        {
                            perm_codigo = 2,
                            usua_codigo = (int) usuario.usua_codigo
                        };
                        _usuaPermissaoRepositorio.Add(permissaoadm);
                        _usuaPermissaoRepositorio.Add(permissaousr);
                    }
                    return RedirectToAction("Index", "Home");
                }
                this.Flash("E-mail login já cadastrado", FlashLevel.Info);
                return View(empresa);
            }
            catch
            {
                return View(empresa);
            }
        }


        [CustomAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit()
        {
            if (UsuarioLogado == null || UsuarioLogado.UserId == 0)
                return RedirectToAction("LogOff", "Autenticacao");
            var empresa = _empresaRepositorio.GetporId(UsuarioLogado.EmpresaId);
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa)
        {
            try
            {
                if (!_usuarioRepositorio.Usuariojacadastrado(empresa.empr_email, null))
                {
                _empresaRepositorio.Update(empresa);
                _empresaRepositorio.Commit();
                return RedirectToAction("Index", "Clientes");
                }
                this.Flash("E-mail login já cadastrado", FlashLevel.Info);
                return View(empresa);
            }
            catch
            {
                return View(empresa);
            }
        }

    }
}
