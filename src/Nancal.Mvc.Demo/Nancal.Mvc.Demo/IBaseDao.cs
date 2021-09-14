using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancal.Mvc.Demo
{
    public interface IBaseDao
    {
        IQueryable<T> Query<T>() where T : class;
        object Save<T>(T t) where T : class;
    }
}
