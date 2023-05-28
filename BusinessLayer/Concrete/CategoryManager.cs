using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager()
        {
                _categoryDal=
        }
        //GenericRepository<Category> repo = new GenericRepository<Category>();
        //public List<Category> GetAll()
        //{
        //    return repo.List();
        //}
        //public void AddCategory(Category category)
        //{
        //    if (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryName.Length >= 51)
        //    {
        //        //error code
        //    }
        //    else
        //    {
        //        repo.Add(category);
        //    }
        //}
        public List<Category> GetListCategory()
        {
            return 
        }
    }
}
