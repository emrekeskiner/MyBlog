using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogContext blogContext = new BlogContext();
        public List<Article> GetArticlesByWriter(int id)
        {
            var values = blogContext.Articles.Where(x=>x.AppUserId==id).ToList();

            return values;
        }
    }
}
