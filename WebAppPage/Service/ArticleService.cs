using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppPage.Models;
using WebAppPage.Response;

namespace WebAppPage.Service
{
    public class ArticleService
    {
        public PagedResponse<IEnumerable<Article>> GetPaged(int pageSize, int currentPage)
        {
            PagedResponse<IEnumerable<Article>> response = new PagedResponse<IEnumerable<Article>>();

            response.List = GetFakesList().Skip(pageSize * (currentPage - 1)).Take(pageSize);
            response.TotalCount = GetFakesList().Count();

            return response;
        }

        private IEnumerable<Article> GetFakesList()
        {
            return new List<Article>
            {
                new Article { Id = 1, Title = "1",Content = "1" },
                new Article { Id = 2, Title = "2",Content = "2" },
                new Article { Id = 3, Title = "3",Content = "3" },
            };
        }
    }
}