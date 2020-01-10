using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NewsPaperHamrazm.DataLayer.Context;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.City
{
   public class CityServices : ICityServices
   {

        private HamrazmContext _db;

        public CityServices(HamrazmContext context)
        {
            _db = context;
        }

        private bool IsAnyCity(string CityName)
        {
            return _db.Cities.Any(a => a.CityName == CityName);
        }

        private bool IsAnyCity(Repositories.City City)
        {
            return _db.Cities.Any(a => a.CityId != City.CityId && a.CityName == City.CityName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        public Repositories.City GetCity(Repositories.City city)
        {

           var result= _db.Cities.AsNoTracking();
           if (city.CityId > 0)
           {
               return result.FirstOrDefault(a => a.CityId == city.CityId);

           }

           return result.FirstOrDefault(a => a.CityName == city.CityName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public Repositories.City GetCityById(int cityId)
        {

            var result = _db.Cities.Find(cityId);
           
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityIds"></param>
        /// <returns></returns>
        public List<Repositories.City> GetAllCity(List<int> cityIds)
        {

            var citiesQuery = _db.Cities.AsQueryable();
            if (cityIds.Any())
            {
                citiesQuery = citiesQuery.Where(a => cityIds.Contains(a.CityId) );

            }

            var result = citiesQuery.ToList();
            return result;

        }
        public HamrazmResult AddCity(Repositories.City City)
        {
            var result = new HamrazmResult();
            if (IsAnyCity(City.CityName))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }

            _db.Entry(City).State = EntityState.Added;
            result.Message = "رکورد با موفقیت ثبت شد";
            return result;
        }

        public HamrazmResult UpdateCity(Repositories.City city)
        {
            var result = new HamrazmResult();
            if (IsAnyCity(city))
            {
                result.IsChange = false;
                result.Message = "رکورد تکراری می باشد";
                return result;
            }
            var searchCity = GetCity(city);
            if (searchCity == null)
            {
                result.IsChange = false;
                result.Message = "شهر یافت نشد";
            }
            _db.Entry(city).State = EntityState.Modified;
            result.Message = "با موفقیت تغییر  یافت";
            return result;

        }


        public HamrazmResult DeleteCompany(Repositories.City city)
        {
            var result = new HamrazmResult();
            try
            {

                _db.Entry(city).State = EntityState.Deleted;

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

        public HamrazmResult DeleteCity(int cityId)
        {
            var result = new HamrazmResult();
            try
            {
                var foodCompanyModel = GetCityById(cityId);

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

        public  IList<Repositories.City> GetByParamert(string CompanyParaMert)
        {
            var result = _db.Cities.AsNoTracking().Include(a => a.NewsRelationses).Where(a => a.CityName.Contains(CompanyParaMert)).ToList();
            return result;
        }
    }
}
