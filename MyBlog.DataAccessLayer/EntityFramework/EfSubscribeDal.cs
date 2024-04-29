﻿using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfSubscribeDal:GenericRepository<Subscribe>,ISubscribeDal
    {
    }
}
