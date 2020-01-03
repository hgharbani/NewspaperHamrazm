using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPaperHamrazm.DataLayer.Context;
using NewsPaperHamrazm.DataLayer.RepositoryServices.Category;
using NewsPaperHamrazm.DataLayer.RepositoryServices.City;
using NewsPaperHamrazm.DataLayer.RepositoryServices.News;
using NewsPaperHamrazm.DataLayer.RepositoryServices.User;

namespace NewsPaperHamrazm.DataLayer
{
   public class UnitOfWork:IDisposable
    {
        HamrazmContext db = new HamrazmContext();
        private IUserService _userServices;
        private ICityServices _cityServices;
        private ICategoryServices _categoryServices;
        private INewsServices _newsServices;

     
        public IUserService UserServices
        {
            get
            {
                if (_userServices == null)
                {
                    return _userServices = new UserService(db);

                }

                return _userServices;
            }
        }
        public ICityServices CityServices
        {
            get
            {
                if (_cityServices == null)
                {
                    return _cityServices = new CityServices(db);

                }

                return _cityServices;
            }
        }

        public ICategoryServices CategoryServices
        {
            get
            {
                if (_categoryServices == null)
                {
                    return _categoryServices = new CategoryServices(db);

                }

                return _categoryServices;
            }
        }

        public INewsServices NewsServices
        {
            get
            {
                if (_newsServices == null)
                {
                    return _newsServices = new NewsServices(db);

                }

                return _newsServices;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();

        }
    }
}
