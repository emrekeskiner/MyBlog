using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public About TGetById(int id)
        {
           return _aboutDal.GetById(id);
        }

        public List<About> TGetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void TInsert(About entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About entity)
        {
           _aboutDal.Update(entity);
        }
    }
}
