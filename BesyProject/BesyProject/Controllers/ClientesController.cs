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
    public class ClientesController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(context.Clientes.OrderBy(
              c => c.Nome));
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cliente).State =
                EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        #endregion

        #region Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cliente cliente = context.Clientes.
            Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
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
            Cliente cliente = context.Clientes.
                Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Cliente cliente = context.Clientes.
            Find(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}
