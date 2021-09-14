using Spring.Transaction.Interceptor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nancal.Mvc.Demo
{
    // This TodayWriter is where it all comes together.
    // Notice it takes a constructor parameter of type
    // IOutput - that lets the writer write to anywhere
    // based on the implementation. Further, it implements
    // WriteDate such that today's date is written out;
    // you could have one that writes in a different format
    // or a different date.
    public class TodayWriter : IDateWriter
    {
        private IBaseDao dao { get; set; }
        public TodayWriter()
        {
            //this._output = output;
        }

        public void WriteDate()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            //this._output.Write(DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
        [Transaction]
        public List<Book> Query()
        {
            var data = dao.Query<Book>().ToList();
            return data;
        }

        [Transaction]
        public Guid Save()
        {
            return (Guid)dao.Save(new Book()
            {
                Title = "Hello Spring World!",
                Remark = "",
            });
        }
    }
}