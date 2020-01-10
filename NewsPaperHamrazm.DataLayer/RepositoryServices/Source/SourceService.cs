using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NewsPaperHamrazm.DataLayer.Context;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.Source
{
    public class SourceService : ISourceService
    {

        private HamrazmContext _db;

        public SourceService(HamrazmContext context)
        {
            _db = context;
        }

        private bool IsAnySource(string SourceName)
        {
            return _db.Sources.Any(a => a.SourceName == SourceName);
        }

        private bool IsAnySource(Repositories.Source Source)
        {
            return _db.Sources.Any(a => a.SourceId != Source.SourceId && a.SourceName == Source.SourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        public Repositories.Source GetSource(Repositories.Source Source)
        {

            var result = _db.Sources.AsNoTracking();
            if (Source.SourceId > 0)
            {
                return result.FirstOrDefault(a => a.SourceId == Source.SourceId);

            }

            return result.FirstOrDefault(a => a.SourceName == Source.SourceName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceId"></param>
        /// <returns></returns>
        public Repositories.Source GetSourceById(int SourceId)
        {

            var result = _db.Sources.Find(SourceId);

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceIds"></param>
        /// <returns></returns>
        public List<Repositories.Source> GetAllSource(List<int> SourceIds)
        {

            var SourcesQuery = _db.Sources.AsQueryable();
            if (SourceIds.Any())
            {
                SourcesQuery = SourcesQuery.Where(a => SourceIds.Contains(a.SourceId));

            }

            var result = SourcesQuery.ToList();
            return result;

        }
        public HamrazmResult AddSource(Repositories.Source Source)
        {
            var result = new HamrazmResult();
            if (IsAnySource(Source.SourceName))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }

            _db.Entry(Source).State = EntityState.Added;
            result.Message = "رکورد با موفقیت ثبت شد";
            return result;
        }

        public HamrazmResult UpdateSource(Repositories.Source Source)
        {
            var result = new HamrazmResult();
            if (IsAnySource(Source))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }
            var searchSource = GetSource(Source);
            if (searchSource == null)
            {
                result.IsChange = false;
                result.Message = "منبع یافت نشد";
            }
            _db.Entry(Source).State = EntityState.Modified;
            result.Message = "کاربر تعریف شدرمز عبور با موفقیت تغییر  یافت";
            return result;

        }


        public HamrazmResult DeleteCompany(Repositories.Source Source)
        {
            var result = new HamrazmResult();
            try
            {

                _db.Entry(Source).State = EntityState.Deleted;

                result.IsChange = true;
                result.Message = "منبع با موفقیت حذف شد";
                return result;


            }
            catch (Exception e)
            {
                result.IsChange = false;
                result.Message = e.Message;

                return result;
            }

        }

        public HamrazmResult DeleteSource(int SourceId)
        {
            var result = new HamrazmResult();
            try
            {
                var foodCompanyModel = GetSourceById(SourceId);

                if (foodCompanyModel == null)
                {
                    result.IsChange = false;
                    result.Message = "این منبع حذف شده است";
                    return result;
                }

                if (foodCompanyModel.NewsRelationses.Any())
                {
                    result.IsChange = false;
                    result.Message = "قادر به حذف این منبع نمی باشد زیرا دارای چند خبر می باشد";
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
