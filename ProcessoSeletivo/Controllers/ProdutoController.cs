using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoDAL objDs;

        public ProdutoController()
        {
            objDs = new ProdutoDAL(); 
        }
        //
        // GET: /Produto/
        public ActionResult Index()
        {
            var Produtos = objDs.GetProdutos();
            return View(Produtos);
            //return View(new ProcessoSeletivo.Models.CategoriaDAL().GetCategorias());
        }

        //
        // GET: /Produto/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //The field Preco must be a number
        // GET: /Produto/Create

        public ActionResult Create()
        {
            ViewData["categorias"] = new CategoriaDAL().GetCategorias();
            return View("Create");
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        public ActionResult Create(Produto Prod)
        {
            try
            {
                
                objDs.CreateProduto(Prod);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produto/Edit/2

        public ActionResult Edit(int id)
        {
            var Prod = objDs.GetProdutoById(id);
            return View(Prod);
        }

        //
        // POST: /Produto/Edit/2

        [HttpPost]
        public ActionResult Edit(int id, Produto Prod)
        {
            try
            {
                objDs.UpdateProduto(Prod);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produto/Delete/5

        public ActionResult Delete(int id)
        {
            var Prod = objDs.GetProdutoById(id);
            return View(Prod);
        }

        //
        // POST: /Produto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var Prod = objDs.GetProdutoById(id);
                objDs.DeleteProduto(Prod);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	}
}