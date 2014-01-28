using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class ProdutoCategoriaController : Controller
    {
        ProdutoCategoriaDAL objDs;

        public ProdutoCategoriaController()
        {
            objDs = new ProdutoCategoriaDAL(); 
        }
        //
        // GET: /Produto/
        public ActionResult Index()
        {
            var ProdutoCategorias = objDs.GetProdutosCategoria();
            return View(ProdutoCategorias);
            //return View(new ProcessoSeletivo.Models.CategoriaDAL().GetCategorias());
        }
	}
}