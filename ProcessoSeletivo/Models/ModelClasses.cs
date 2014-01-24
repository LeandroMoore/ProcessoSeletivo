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
    /// class to perform the CRUD operations
    /// </summary>
    public class CategoriaDAL
    {
        //Define the session factory, this is per database 
        ISessionFactory sessionFactory;

        /// <summary>
        /// Method to create session and manage entities
        /// </summary>
        /// <returns></returns>
        ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                var cgf = new Configuration();
                //var data = cgf.Configure(HttpContext.Current.Server.MapPath(@"Models\Nhibernate\Configuration\hibernate.cfg.xml"));
                var data = cgf.Configure(System.Web.Hosting.HostingEnvironment.MapPath(@"\Models\Nhibernate\Configuration\hibernate.cfg.xml"));
                //cgf.AddDirectory(new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(@"Models\Nhibernate\Mappings")));
                cgf.AddDirectory(new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath(@"\Models\Nhibernate\Mappings")));
                sessionFactory = data.BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }

        public IList<Categoria> GetCategorias()
        {
            IList<Categoria> Categorias;
            using (ISession session = OpenSession())
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
            using (ISession session = OpenSession())
            {
                Cat = session.Get<Categoria>(Id);
            }
            return Cat;
        }

        public int CreateCategoria(Categoria Cat)
        {
            int IdCat = 0;

            using (ISession session = OpenSession())
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
            using (ISession session = OpenSession())
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
            using (ISession session = OpenSession())
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