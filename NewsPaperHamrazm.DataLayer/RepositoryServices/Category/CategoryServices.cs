using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPaperHamrazm.DataLayer.Context;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.Category
{
   public class CategoryServices : ICategoryServices
   {
        private HamrazmContext _db;

        public CategoryServices(HamrazmContext context)
        {
            _db = context;
        }

        private bool IsAnyCategory(string CategoryName)
        {
            return _db.Categories.Any(a => a.CategoryName == CategoryName);
        }

        private bool IsAnyCategory(Repositories.Category Category)
        {
            return _db.Categories.Any(a => a.CategoryId != Category.CategoryId && a.CategoryName == Category.CategoryName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        public Repositories.Category GetCategory(Repositories.Category Category)
        {

            var result = _db.Categories.AsNoTracking();
            if (Category.CategoryId > 0)
            {
                return result.FirstOrDefault(a => a.CategoryId == Category.CategoryId);

            }

            return result.FirstOrDefault(a => a.CategoryName == Category.CategoryName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public Repositories.Category GetCategoryById(int CategoryId)
        {

            var result = _db.Categories.Find(CategoryId);

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryIds"></param>
        /// <returns></returns>
        public List<Repositories.Category> GetAllCategory(List<int> CategoryIds)
        {

            var CategoriesQuery = _db.Categories.AsQueryable();
            if (CategoryIds.Any())
            {
                CategoriesQuery = CategoriesQuery.Where(a => CategoryIds.Contains(a.CategoryId));

            }

            var result = CategoriesQuery.ToList();
            return result;

        }
        public HamrazmResult AddCategory(Repositories.Category Category)
        {
            var result = new HamrazmResult();
            if (IsAnyCategory(Category.CategoryName))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }

            _db.Entry(Category).State = EntityState.Added;
            result.Message = "رکورد با موفقیت ثبت شد";
            return result;
        }

        public HamrazmResult UpdateCategory(Repositories.Category Category)
        {
            var result = new HamrazmResult();
            if (IsAnyCategory(Category))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }
            var searchCategory = GetCategory(Category);
            if (searchCategory == null)
            {
                result.IsChange = false;
                result.Message = "شهر یافت نشد";
            }
            _db.Entry(Category).State = EntityState.Modified;
            result.Message = "کاربر تعریف شدرمز عبور با موفقیت تغییر  یافت";
            return result;

        }


        public HamrazmResult DeleteCategory(Repositories.Category Category)
        {
            var result = new HamrazmResult();
            try
            {

                _db.Entry(Category).State = EntityState.Deleted;

                result.IsChange = true;
                result.Message = "شهر با موفقیت حذف شد";
                return result;


            }
            catch (Exception e)
            {
                result.IsChange = false;
                result.Message = e.Message;

                return result;
            }

        }

        public HamrazmResult DeleteCategory(int CategoryId)
        {
            var result = new HamrazmResult();
            try
            {
                var foodCompanyModel = GetCategoryById(CategoryId);

                if (foodCompanyModel == null)
                {
                    result.IsChange = false;
                    result.Message = "این شرکت حذف شده است";
                    return result;
                }

                if (foodCompanyModel.NewsRelationses.Any())
                {
                    result.IsChange = false;
                    result.Message = "قادر به حذف این شهر نمی باشد زیرا دارای چند خبر می باشد";
                    return result;

                }

                result = DeleteCategory(foodCompanyModel);
                return result;
            }
            catch (Exception)
            {
                result.IsChange = false;
                result.Message = "خطایی رخ داده است";
                return result;
            }
        }

    }
}
