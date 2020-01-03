using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.City
{
    public interface ICityServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        Repositories.City GetCity(Repositories.City city);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Repositories.City GetCityById(int cityId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityIds"></param>
        /// <returns></returns>
        List<Repositories.City> GetAllCity(List<int> cityIds);

        HamrazmResult AddCity(Repositories.City City);
        HamrazmResult UpdateCity(Repositories.City city);
        HamrazmResult DeleteCompany(Repositories.City city);
        HamrazmResult DeleteCity(int cityId);
    }
}