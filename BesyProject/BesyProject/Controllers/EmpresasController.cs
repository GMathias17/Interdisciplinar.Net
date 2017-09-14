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
        private static IList<Empresa> empresasList =
            new List<Empresa>()
            {
                new Empresa()
                {
                    EmpresaId = 1,
                    Nome = "Mecanic",
                    Endereco = "Avenida Teste",
                    Telefone = 88549635,
                    Cnpj = 954187364875236,
                    Especialidade = "Concerto de carros"
                },
                new Empresa()
                {
                    EmpresaId = 2,
                    Nome = "Hydraulis",
                    Endereco = "Avenida Teste n5",
                    Telefone = 58463874,
                    Cnpj = 524545345436546,
                    Especialidade = "Concerto de pias"
                },
                new Empresa()
                {
                    EmpresaId = 3,
                    Nome = "Luzis",
                    Endereco = "Avenida Teste n87",
                    Telefone = 99596665,
                    Cnpj = 795434195432846,
                    Especialidade = "Manutenção de energia elétrica"
                }
            };

        
        // GET: Empresa
        public ActionResult Index()
        {
            return View(empresasList);
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empresa empresa)
        {
            empresasList.Add(empresa);
            empresa.EmpresaId =
            empresasList.Select(m => m.EmpresaId).Max() + 1;
            return RedirectToAction("Index");   
        }
        #endregion

        #region Edit
        public ActionResult Edit(long id)
        {
            var empresa = empresasList
                .Where(c => c.EmpresaId == id)
                .First();

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa modified)
        {
            var empresa = empresasList
                .Where(c => c.EmpresaId == modified.EmpresaId)
                .First();

            empresa.Nome = modified.Nome;
            empresa.Endereco = modified.Endereco;
            empresa.Telefone = modified.Telefone;
            empresa.Cnpj = modified.Cnpj;
            empresa.Especialidade = modified.Especialidade;

            return RedirectToAction("Index");
        }
        #endregion

        #region Details
        public ActionResult Details(long id)
        {
            var empresa = empresasList
                .Where(c => c.EmpresaId == id)
                .First();

            return View(empresa);
        }
        #endregion

        #region Delete
        public ActionResult Delete(long id)
        {
            var empresa = empresasList
                .Where(c => c.EmpresaId == id)
                .First();

            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empresa toDelete)
        {
            var empresa = empresasList
                .Where(c => c.EmpresaId == toDelete.EmpresaId)
                .First();

            empresasList.Remove(empresa);

            return RedirectToAction("Index");

        }
        #endregion
    }
}