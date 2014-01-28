using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using ProcessoSeletivo.Models;

namespace ProcessoSeletivo.Models
{
    /// <summary>
    /// Crud para Produto
    /// </summary>
    /// <returns></returns>

    public class ProdutoCategoriaDAL
    {
        public IList<ProdutoCategoria> GetProdutosCategoria()
        {
            IList<ProdutoCategoria> ProdutoCategorias;
            using (ISession session = SessionFactory.OpenSession())
            {
                //NHibernate query
                IQuery query = session.CreateQuery("from ProdutoCategoria");
                ProdutoCategorias = query.List<ProdutoCategoria>();
            }
            return ProdutoCategorias;
        }

        public ProdutoCategoria GetProdutoCategoriaById(Int64 Id)
        {
            ProdutoCategoria ProdCat = new ProdutoCategoria();
            using (ISession session = SessionFactory.OpenSession())
            {
                ProdCat = session.Get<ProdutoCategoria>(Id);
            }
            return ProdCat;
        }
    }


}