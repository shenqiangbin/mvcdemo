using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppPage.Response
{
    public class PagedResponse<T>
    {
        public int TotalCount { get; set; }
        public T List { get; set; }
    }
}