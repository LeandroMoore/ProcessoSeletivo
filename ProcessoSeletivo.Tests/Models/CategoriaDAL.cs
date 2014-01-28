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
    /// Crud para Categoria
    /// </summary>
    public class CategoriaDAL
    {
        public IList<Categoria> GetCategorias()
        {
            IList<Categoria> Categorias;
            using (ISession session = SessionFactory.OpenSession())
            {
                //NHibernate query
                IQuery query = session.CreateQuery("from Categoria");
                Categorias = query.List<Categoria>();
            }
            return Categorias;
        }

        public Categoria GetCategoriaById(Int64 Id)
        {
            Categoria Cat = new Categoria();
            using (ISession session = SessionFactory.OpenSession())
            {
                Cat = session.Get<Categoria>(Id);
            }
            return Cat;
        }

        public int CreateCategoria(Categoria Cat)
        {
            int IdCat = 0;

            using (ISession session = SessionFactory.OpenSession())
            {
                //Perform transaction
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(Cat);
                    tran.Commit();
                }
            }

            return IdCat;
        }


        public void UpdateCategoria(Categoria Cat)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(Cat);
                    tran.Commit();
                }
            }
        }

        public void DeleteCategoria(Categoria Cat)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(Cat);
                    tran.Commit();
                }
            }
        }
    }
}