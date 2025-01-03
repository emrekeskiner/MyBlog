﻿using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework;

public class EfArticleDal : GenericRepository<Article>, IArticleDal
{
    BlogContext blogContext = new BlogContext();
    public List<Article> GetArticlesByWriter(int id)
    {
        var values = blogContext.Articles.Where(x=>x.AppUserId==id).ToList();

        return values;
    }

    public List<Article> GetArticlesWithCategory()
    {
        var values = blogContext.Articles.Include(x=>x.Category).ToList();
        return values;
    }

    public List<Article> GetArticlesWithCategoryByWriter(int id)
    {
        var values = blogContext.Articles.Where(x=> x.AppUserId==id).Include(x=>x.Category).ToList();
        return values;
    }

    public Article GetArticleWithCategoryByArticleId(int id)
    {
        var values = blogContext.Articles.Where(x=>x.ArticleId==id).Include(y=>y.Category).FirstOrDefault();
        return values;
    }

   
}
