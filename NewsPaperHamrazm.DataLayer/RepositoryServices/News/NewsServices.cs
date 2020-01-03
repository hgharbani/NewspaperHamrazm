using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NewsPaperHamrazm.DataLayer.Context;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.News
{
    public class NewsServices : INewsServices
    {

        private HamrazmContext _db;

        public NewsServices(HamrazmContext context)
        {
            _db = context;
        }

        private bool IsAnyNews(string NewsName)
        {
            return _db.Newses.Any(a => a.NewsDiscription == NewsName);
        }

        private bool IsAnyNews(Repositories.News News)
        {
            return _db.Newses.Any(a => a.NewsId != News.NewsId && a.NewsDiscription == News.NewsDiscription);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        public Repositories.News GetNews(Repositories.News News)
        {

            var result = _db.Newses.AsNoTracking();
            if (News.NewsId > 0)
            {
                return result.FirstOrDefault(a => a.NewsId == News.NewsId);

            }

            return result.FirstOrDefault(a => a.NewsDiscription == News.NewsDiscription);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        public Repositories.News GetNewsById(int NewsId)
        {

            var result = _db.Newses.Find(NewsId);

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewsIds"></param>
        /// <returns></returns>
        public List<Repositories.News> GetAllNews(List<int> NewsIds)
        {

            var NewsesQuery = _db.Newses.AsQueryable();
            if (NewsIds.Any())
            {
                NewsesQuery = NewsesQuery.Where(a => NewsIds.Contains(a.NewsId));

            }

            var result = NewsesQuery.ToList();
            return result;

        }
        public HamrazmResult AddNews(Repositories.News News)
        {
            var result = new HamrazmResult();
            if (IsAnyNews(News.NewsDiscription))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }

            _db.Entry(News).State = EntityState.Added;
            result.Message = "رکورد با موفقیت ثبت شد";
            return result;
        }

        public HamrazmResult UpdateNews(Repositories.News News)
        {
            var result = new HamrazmResult();
            if (IsAnyNews(News))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }
            var searchNews = GetNews(News);
            if (searchNews == null)
            {
                result.IsChange = false;
                result.Message = "شهر یافت نشد";
            }
            _db.Entry(News).State = EntityState.Modified;
            result.Message = "کاربر تعریف شدرمز عبور با موفقیت تغییر  یافت";
            return result;

        }


        public HamrazmResult DeleteCompany(Repositories.News News)
        {
            var result = new HamrazmResult();
            try
            {

                _db.Entry(News).State = EntityState.Deleted;

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

        public HamrazmResult DeleteNews(int NewsId)
        {
            var result = new HamrazmResult();
            try
            {
                var foodCompanyModel = GetNewsById(NewsId);

                if (foodCompanyModel == null)
                {
                    result.IsChange = false;
                    result.Message = "این شرکت حذف شده است";
                    return result;
                }


                result = DeleteCompany(foodCompanyModel);
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
