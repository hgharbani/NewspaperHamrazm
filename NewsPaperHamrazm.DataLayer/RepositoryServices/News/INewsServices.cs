using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.News
{
    public interface INewsServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        Repositories.News GetNews(Repositories.News News);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        Repositories.News GetNewsById(int NewsId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsIds"></param>
        /// <returns></returns>
        List<Repositories.News> GetAllNews(List<int> NewsIds);

        HamrazmResult AddNews(Repositories.News News);
        HamrazmResult UpdateNews(Repositories.News News);
        HamrazmResult DeleteCompany(Repositories.News News);
        HamrazmResult DeleteNews(int NewsId);
    }
}