using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using ProcessoSeletivo.Models;

namespace ProcessoSeletivo.Models
{
    public sealed class SessionFactory
    {
        private static ISessionFactory sessionFactory;

        public static ISession OpenSession()
        {
            if (SessionFactory.sessionFactory == null)
            {
                var cgf = new Configuration();
                //var data = cgf.Configure(HttpContext.Current.Server.MapPath(@"Models\Nhibernate\Configuration\hibernate.cfg.xml"));
                var data = cgf.Configure(System.Web.Hosting.HostingEnvironment.MapPath(@"\Models\Nhibernate\Configuration\hibernate.cfg.xml"));
                //cgf.AddDirectory(new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(@"Models\Nhibernate\Mappings")));
                cgf.AddDirectory(new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath(@"\Models\Nhibernate\Mappings")));
                SessionFactory.sessionFactory = data.BuildSessionFactory();
            }

            return SessionFactory.sessionFactory.OpenSession();
        }

    }
}