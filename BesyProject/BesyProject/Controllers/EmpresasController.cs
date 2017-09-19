using BesyProject.Contexts;
using BesyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BesyProject.Controllers
{
    public class EmpresasController : Controller
    {
        private EFContext context = new EFContext();
            
        // GET: Empresa
        public ActionResult Index()
        {
              return View(context.Empresas.OrderBy(
                c => c.Nome));
        }

    }
}