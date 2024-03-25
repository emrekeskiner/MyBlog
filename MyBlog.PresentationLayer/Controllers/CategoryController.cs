using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
             return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _categoryService.TInsert(category);

            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        { 
         _categoryService.TDelete(id);
            return RedirectToAction("CategoryList");
        }

    }
}
