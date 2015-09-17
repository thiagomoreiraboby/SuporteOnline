using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{
    [CustomAuthorize(Roles = "User")]
    public class ClientesController : BaseController
    {
        private readonly ClienteRepositorio _clienteRepositotio = new ClienteRepositorio();
        private readonly GrupoRepositorio _grupoRepositotio = new GrupoRepositorio();

        public ActionResult Index(int? grupo)
        {
            
            if (UsuarioLogado == null || UsuarioLogado.UserId == 0)
                return RedirectToAction("LogOff", "Autenticacao");

            if (grupo != null)
            {
                Session["UltimoGrupo"] = (int)grupo;
            }
            var lista = new List<Cliente>();
            ViewBag.grcl_codigotodos =
                new SelectList(
                    _grupoRepositotio.GetTodos()
                        .Where(x => x.empr_codigo == UsuarioLogado.EmpresaId || x.grcl_codigo < 2).OrderBy(x=> x.grcl_nome), "grcl_codigo",
                    "grcl_nome", (int?)Session["UltimoGrupo"]);

            if ((int?)Session["UltimoGrupo"] == 0)
                lista =
                    _clienteRepositotio.GetTodos()
                        .Where(x => x.empresa.empr_codigo == UsuarioLogado.EmpresaId)

                        .OrderBy(x => x.grupo.grcl_nome)
                        .ThenBy(x => x.clie_nome)
                        .ThenBy(x => x.clie_status)

                        .ToList();
            else
                lista =
                    _clienteRepositotio.GetTodos()
                        .Where(x => x.empresa.empr_codigo == UsuarioLogado.EmpresaId && x.grcl_codigo == (int?)Session["UltimoGrupo"])
                        .OrderBy(x => x.clie_nome)
                        .ThenBy(x => x.clie_status)
                        .ToList();
            _clienteRepositotio.Commit();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (UsuarioLogado == null || UsuarioLogado.UserId == 0)
                return RedirectToAction("LogOff", "Autenticacao");
            var cliente = _clienteRepositotio.GetporId(id);
            if (cliente.empr_codigo == UsuarioLogado.EmpresaId)
            {
                ViewBag.grcl_codigo = new SelectList(_grupoRepositotio.GetTodos().Where(x => x.empr_codigo == UsuarioLogado.EmpresaId || x.grcl_codigo == 1).OrderBy(x => x.grcl_nome), "grcl_codigo", "grcl_nome",
                    cliente.grcl_codigo);
                _clienteRepositotio.Commit();
                _grupoRepositotio.Commit();
                return View(cliente);
            }
            return RedirectToAction("Index");
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                _clienteRepositotio.Update(cliente);
                _clienteRepositotio.Commit();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(cliente);
            }
        }

        [CustomAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cliente = _clienteRepositotio.GetporId(id);
            //_clienteRepositotio.Commit();
            if (cliente.empr_codigo == UsuarioLogado.EmpresaId)
                return View(cliente);
            return RedirectToAction("AccessDenied", "Error");
        }

        // POST: Usuario/Delete/5
         [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                var cli = _clienteRepositotio.GetporId((int)cliente.clie_codigo);
                _clienteRepositotio.Remove(cli);
                _clienteRepositotio.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }
    }
}