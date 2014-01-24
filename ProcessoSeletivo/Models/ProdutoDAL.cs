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

    public class ProdutoDAL
    {
        public IList<Produto> GetProdutos()
        {
            IList<Produto> Produtos;
            using (ISession session = SessionFactory.OpenSession())
            {
                //NHibernate query
                IQuery query = session.CreateQuery("from Produto");
                Produtos = query.List<Produto>();
            }
            return Produtos;
        }

        public Produto GetProdutoById(Int64 Id)
        {
            Produto Prod = new Produto();
            using (ISession session = SessionFactory.OpenSession())
            {
                Prod = session.Get<Produto>(Id);
            }
            return Prod;
        }

        public int CreateProduto(Produto Prod)
        {
            int IdProd = 0;

            using (ISession session = SessionFactory.OpenSession())
            {
                //Perform transaction
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(Prod);
                    tran.Commit();
                }
            }

            return IdProd;
        }


        public void UpdateProduto(Produto Prod)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(Prod);
                    tran.Commit();
                }
            }
        }

        public void DeleteProduto(Produto Prod)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(Prod);
                    tran.Commit();
                }
            }
        }
    }


}