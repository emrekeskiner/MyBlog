using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.BusinessLayer.Concrete
{
    public class ContactMessageManager : IContactMessageService
    {
        private readonly IContactMessageDal _contactMessageDal;

        public ContactMessageManager(IContactMessageDal contactMessageDal)
        {
            _contactMessageDal = contactMessageDal;
        }

        public void TDelete(int id)
        {
            _contactMessageDal.Delete(id);
        }

        public ContactMessage TGetById(int id)
        {
            return _contactMessageDal.GetById(id);
        }

        public List<ContactMessage> TGetListAll()
        {
            return _contactMessageDal.GetListAll();
        }

        public void TInsert(ContactMessage entity)
        {
            _contactMessageDal.Insert(entity);
        }

        public void TUpdate(ContactMessage entity)
        {
            _contactMessageDal.Update(entity);
        }
    }
}
