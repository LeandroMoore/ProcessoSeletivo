using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcessoSeletivo.Models;

namespace ProcessoSeletivo.Views.Catalogo
{
    public class CatalogoController : Controller
    {

        protected void PreencherBags()
        {
            CategoriaDAL categoriaDal = new CategoriaDAL();
            ProdutoDAL produtoDal = new ProdutoDAL();

            IList<Categoria> categoriaList = categoriaDal.GetCategorias();
            Categoria categoria = new Categoria();
            categoria.idCategoria = 0;
            categoria.DescricaoCategoria = "Selecione";
            categoriaList.OrderBy(cate => cate.DescricaoCategoria).ToList();
            categoriaList.Insert(0, categoria);
            ViewBag.Categorias = categoriaList;

            IList<Categoria> categoriaFilhaList = new List<Categoria>();
            Categoria categoriaFilha = new Categoria();
            categoriaFilha.idCategoriaPai = 0;
            categoriaFilha.DescricaoCategoria = "Selecione";
            categoriaFilhaList.Insert(0, categoriaFilha);
            ViewBag.CategoriasFilhas = categoriaFilhaList.OrderBy(cate => cate.DescricaoCategoria).ToList();

            IList<Produto> produtoList = produtoDal.GetProdutos();
            ViewBag.Produtos = produtoList.OrderBy(prod => prod.idProduto).ToList();
        }

        private void PreencherBagsDinamicas(Categoria categoria)
        {
            if (categoria.idCategoriaPai > 0)
            {
            //    CategoriaDAL categoriaDal = new CategoriaDAL();
            //    ProdutoDAL produtoDal = new ProdutoDAL();
            //    IList<Categoria> categoriaFilhaList = categoriaDal.GetCategoriaById(Convert.ToInt64(categoria.idCategoriaPai))
            //    Categoria categoriaFilha = new Categoria();
            //    categoriaFilha.idCategoriaPai = 0;
            //    categoriaFilha.DescricaoCategoria = "Selecione";
            //    categoriaFilhaList.Insert(0, categoriaFilha);
            //    ViewBag.CategoriasFilhas = categoriaFilhaList;

            //    IList<Produto> produtoList = produtoDal.GetProdutoById(Convert.ToInt64(categoria.idCategoriaPai));
            //    ViewBag.Produtos = produtoList.OrderBy(prod => prod.idProduto).ToList();
            //}

            //if (categoria.idCategoriaPai > 0)
            //{
            //    ProdutoDAL produtoDal = new ProdutoDAL();
            //    IList<Produto> produtoList = produtoDal.GetProdutoById(categoria.idCategoriaPai);
            //    ViewBag.Produtos = produtoList.OrderBy(prod => prod.idProduto).ToList();

            }
        }

        public ActionResult Catalogo()
        {
            this.PreencherBags();
            return View("Categoria");
        }

        public ActionResult Listar(Categoria categoria)
        {
            this.PreencherBags();
            this.PreencherBagsDinamicas(categoria);
            return View("Categoria");
        }

    }
}