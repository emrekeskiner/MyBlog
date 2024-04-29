using Microsoft.EntityFrameworkCore;
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
    
    public class EfCommentDal : GenericRepository<Comment>,ICommentDal
    {
        BlogContext blogContext = new BlogContext();

       public List<Comment> GetCommentsByBlog(int id)
        {
            var values = blogContext.Comments.Include(y=>y.AppUser).Where(x=>x.ArticleId == id).ToList();
            return values;
        }
    }
}//2
