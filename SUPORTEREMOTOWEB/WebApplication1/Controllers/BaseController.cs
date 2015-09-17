using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected virtual new CustomPrincipal UsuarioLogado
        {
            get
            {
                return HttpContext.User as CustomPrincipal;
            }
        }
    }
}
