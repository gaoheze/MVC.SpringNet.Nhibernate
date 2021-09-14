using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nancal.Mvc.Demo
{
    //[Class(Table = "Book")]
    //[Cache(Usage = CacheUsage.ReadWrite, Include = CacheInclude.All)]
    public class Book
    {
        //[Id(Name = "Id",Column = "Id",Generator = "guid", Type = "guid")]
        public virtual Guid Id { get; set; }
        //[Property(Column = "Title")]
        public virtual string Title { get; set; }
        //[Property(Column = "Remark")]
        public virtual string Remark { get; set; }

        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
    }
}