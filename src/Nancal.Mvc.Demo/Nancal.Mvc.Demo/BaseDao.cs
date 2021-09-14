using NHibernate;

using Spring.Transaction.Interceptor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nancal.Mvc.Demo
{
    public class BaseDao:IBaseDao
    {
        private ISessionFactory sessionFactory;
        /// <summary>
        /// Session factory for sub-classes.
        /// </summary>
        public ISessionFactory SessionFactory
        {
            protected get { return sessionFactory; }
            set { sessionFactory = value; }
        }
        //public ISessionFactory GetSessionFactory() => SessionFactory;
        /// <summary>
        /// Get's the current active session. Will retrieve session as managed by the
        /// Open Session In View module if enabled.
        /// </summary>
        //protected ISession CurrentSession => SessionFactory.GetCurrentSession();
        private ISession _session => SessionFactory.GetCurrentSession();
        //public NhibernateHelper(ISession session)
        //{
        //    _session = session;
        //}
        //public ISession GetCurrentSession() => CurrentSession;
        [Transaction(ReadOnly = true)]
        public IQueryable<T> Query<T>() where T : class
        {
            return _session.Query<T>();
        }
        [Transaction(ReadOnly = false)]
        public object Save<T>(T t) where T : class
        {
            return _session.Save(t);
        }
    }
}