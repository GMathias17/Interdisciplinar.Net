using BesyProject.Contexts;
using BesyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace BesyProject.Controllers
{
    public class ServicosController : Controller
    {

        private EFContext context = new EFContext();

        // GET: Servicos
        public ActionResult Index()
        {
            return View(context.Servicos.OrderBy(
              s => s.Descricao));
        }


        #region Create

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servico servico)
        {
            context.Servicos.Add(servico);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Servico servico = context.Servicos.
                Find(id);
            if (servico == null)
            {
                return HttpNotFound();
            }
            return View(servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Servico servico = context.Servicos.
            Find(id);
            context.Servicos.Remove(servico);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}



    
