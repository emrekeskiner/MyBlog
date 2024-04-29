using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.DataAccessLayer.EntityFramework;

public class EfWriterDal : GenericRepository<Writer>, IWriterDal
{
    public int GetWriterCount()
    {

        return 0;
    }
}
