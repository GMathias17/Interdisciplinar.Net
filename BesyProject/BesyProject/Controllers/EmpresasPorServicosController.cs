using BesyProject.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BesyProject.Models;
using System.Data;
using System.Data.Entity;

namespace BesyProject.Controllers
{
    
    public class EmpresasPorServicosController : Controller
    {
        private EFContext db = new EFContext();
        // GET: EmpresasPorServicos

        public ActionResult Index()
        {
            var servicos = db.Servicos.Include(e => e.Empresas);
            return View(servicos.ToList());
        }
    }
}