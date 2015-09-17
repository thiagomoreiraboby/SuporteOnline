using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Repositorio;

namespace WebApplication1.Controllers
{
    [CustomAuthorize(Roles = "User")]
    public class GrupoController : BaseController
    {
        private readonly GrupoRepositorio _grupoRepositotio = new GrupoRepositorio();
        // GET: Grupo
        public ActionResult Index()
        {
            if (UsuarioLogado == null || UsuarioLogado.UserId == 0)
                return RedirectToAction("LogOff", "Autenticacao");
            var lista =
                _grupoRepositotio.GetTodos().Where(x => x.empr_codigo == UsuarioLogado.EmpresaId).OrderBy(x=> x.grcl_nome);
            return View(lista);
        }

      [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupo/Create
      [HttpPost]
        public ActionResult Create(GrupCliente grupo)
        {
            try
            {
                grupo.empr_codigo = UsuarioLogado.EmpresaId;
                _grupoRepositotio.Add(grupo);
                _grupoRepositotio.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(grupo);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var grupo = _grupoRepositotio.GetporId(id);
            if (grupo.empr_codigo == UsuarioLogado.EmpresaId)
            {
                return View(grupo);
            }
            return RedirectToAction("Index");
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GrupCliente grupo)
        {
            try
            {
                _grupoRepositotio.Update(grupo);
                _grupoRepositotio.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(grupo);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
           var grupo = _grupoRepositotio.GetporId(id);
            if (grupo.empr_codigo == UsuarioLogado.EmpresaId)
            {
                return View(grupo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GrupCliente grupo)
        {
            try
            {
                var grupo1 = _grupoRepositotio.GetporId((int)grupo.grcl_codigo);
                _grupoRepositotio.Deletargrupo(grupo1);
                _grupoRepositotio.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(grupo);
            }
        }
    }
}
