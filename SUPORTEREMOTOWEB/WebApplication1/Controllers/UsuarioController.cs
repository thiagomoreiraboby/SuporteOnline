using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helper;
using WebApplication1.Models;
using WebApplication1.Models.Interface;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class UsuarioController : BaseController
    {

        private readonly UsuarioRepositorio _usuarioRepositotio = new UsuarioRepositorio();
        private readonly PermissaoRepositorio _permissaoRepositorio = new PermissaoRepositorio();
        private readonly UsuaPermissaoRepositorio _usuaPermissaoRepositorio = new UsuaPermissaoRepositorio();
        private readonly EmpresaRepositorio _empresaRepositorio = new EmpresaRepositorio();

        public ActionResult Index()
        {
            if (UsuarioLogado == null || UsuarioLogado.UserId == 0)
                return RedirectToAction("LogOff", "Autenticacao");
            var usuarios = _usuarioRepositotio.GetTodos().Where(x => x.empr_codigo == UsuarioLogado.EmpresaId).OrderBy(x => x.usua_nome);
            _usuarioRepositotio.Commit();
            return View(usuarios);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (!_usuarioRepositotio.Usuariojacadastrado(usuario.usua_login, null))
                {
                usuario.empr_codigo = UsuarioLogado.EmpresaId;
                _usuarioRepositotio.Add(usuario);

                return RedirectToAction("Index");
                }
                this.Flash("E-mail login já cadastrado", FlashLevel.Info);
                return View(usuario);
            }
            catch (Exception ex)
            {

                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.perm_codigo = new SelectList(_permissaoRepositorio.GetTodos().Where(x=> x.perm_codigo > 0), "perm_codigo", "perm_descricao");
            ViewBag.Permissoes = _usuaPermissaoRepositorio.GetTodos().Where(x => x.usua_codigo == id);

            var usuario = _usuarioRepositotio.GetporId(id);
            //ViewBag.usuario = usuario;
            //_usuarioRepositotio.Commit();
            if (usuario.empr_codigo == UsuarioLogado.EmpresaId)
                return View(usuario);
            return RedirectToAction("AccessDenied", "Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            switch (usuario.addtipo)
            {
                case "1":
                    addpermissao(usuario);
                    ViewBag.perm_codigo = new SelectList(
                        _permissaoRepositorio.GetTodos().Where(x => x.perm_codigo > 0), "perm_codigo", "perm_descricao");
                    ViewBag.Permissoes =
                        _usuaPermissaoRepositorio.GetTodos().Where(x => x.usua_codigo == usuario.usua_codigo);
                    return RedirectToAction("Edit", new { id = usuario.usua_codigo });
               
                default:


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
                            
                            return RedirectToAction("Index");
                            
                        }
                        this.Flash("E-mail login já cadastrado", FlashLevel.Info);
                        ViewBag.perm_codigo =
                            new SelectList(_permissaoRepositorio.GetTodos().Where(x => x.perm_codigo > 0),
                                "perm_codigo", "perm_descricao");
                        ViewBag.Permissoes =
                            _usuaPermissaoRepositorio.GetTodos().Where(x => x.usua_codigo == usuario.usua_codigo);
                        return View(usuario);
                    }
                    catch
                    {
                        ViewBag.perm_codigo =
                            new SelectList(_permissaoRepositorio.GetTodos().Where(x => x.perm_codigo > 0),
                                "perm_codigo", "perm_descricao");
                        ViewBag.Permissoes =
                            _usuaPermissaoRepositorio.GetTodos().Where(x => x.usua_codigo == usuario.usua_codigo);
                        return View(usuario);
                    }

                    break;
            }

            

        }

        public ActionResult DeletePermissao(int id, int ucodigo)
        {

            var per =
                _usuaPermissaoRepositorio.GetTodos()
                    .FirstOrDefault(x => x.perm_codigo == id && x.usua_codigo == ucodigo);
            _usuaPermissaoRepositorio.Remove(per);
            _usuaPermissaoRepositorio.Commit();
            return RedirectToAction("Edit", new {id = ucodigo});
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioRepositotio.GetporId(id);
            _usuarioRepositotio.Commit();
            if (usuario.empr_codigo == UsuarioLogado.EmpresaId)
                return View(usuario);
            return RedirectToAction("AccessDenied", "Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                if (usuario.usua_codigo != null)
                {
                    var usua = _usuarioRepositotio.GetporId((int) usuario.usua_codigo);
                    _usuarioRepositotio.Remove(usua);

                    _usuarioRepositotio.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View(usuario);
        }

        [CustomAuthorize(Roles = "Sihl")]
        public ActionResult ReplicadorView()
        {

            return View();
        }

        public void addpermissao(Usuario usuario)
        {
            if (usuario != null && usuario.usua_codigo > 0)
            {
                if(usuario.idpermissao == null)
                return;
                var permissoes = _usuaPermissaoRepositorio.Getpermissoes((int) usuario.usua_codigo);
                if (permissoes.Any(x => x.perm_codigo == usuario.idpermissao))
                    return;
                _usuaPermissaoRepositorio.Add(new UsuaPermissao()
                {
                    perm_codigo = (int)usuario.idpermissao,
                    usua_codigo = (int) usuario.usua_codigo
                });
                //_usuaPermissaoRepositorio.Commit();
            }
        }

    }
}
