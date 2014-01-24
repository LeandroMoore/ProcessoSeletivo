using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDAL objDs;

        public CategoriaController()
        {
            objDs = new CategoriaDAL(); 
        }
        //
        // GET: /Categoria/
        public ActionResult Index()
        {
            var Categorias = objDs.GetCategorias();
            return View(Categorias);
            //return View(new ProcessoSeletivo.Models.CategoriaDAL().GetCategorias());
        }

        //
        // GET: /Categoria/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            var Cat = new Categoria();
            return View(Cat);
        }

        //
        // POST: /Categoria/Create

        [HttpPost]
        public ActionResult Create(Categoria Cat)
        {
            try
            {
                objDs.CreateCategoria(Cat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categoria/Edit/2

        public ActionResult Edit(int id)
        {
            var Cat = objDs.GetCategoriaById(id);
            return View(Cat);
        }

        //
        // POST: /Categoria/Edit/2

        [HttpPost]
        public ActionResult Edit(int id, Categoria Cat)
        {
            try
            {
                objDs.UpdateCategoria(Cat);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categoria/Delete/5

        public ActionResult Delete(int id)
        {
            var Cat = objDs.GetCategoriaById(id);
            return View(Cat);
        }

        //
        // POST: /Categoria/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var Cat = objDs.GetCategoriaById(id);
                objDs.DeleteCategoria(Cat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}