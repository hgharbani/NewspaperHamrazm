using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.Category
{
    public interface ICategoryServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        Repositories.Category GetCategory(Repositories.Category Category);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        Repositories.Category GetCategoryById(int CategoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryIds"></param>
        /// <returns></returns>
        List<Repositories.Category> GetAllCategory(List<int> CategoryIds);

        HamrazmResult AddCategory(Repositories.Category Category);
        HamrazmResult UpdateCategory(Repositories.Category Category);
        HamrazmResult DeleteCategory(Repositories.Category Category);
        HamrazmResult DeleteCategory(int CategoryId);
    }
}