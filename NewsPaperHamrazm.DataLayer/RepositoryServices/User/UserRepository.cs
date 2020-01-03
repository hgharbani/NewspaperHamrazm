using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using NewsPaperHamrazm.DataLayer.Context;
using NewsPaperHamrazm.DataLayer.Repositories;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.User
{
  
    public class UserService : IUserService
    {
        private HamrazmContext db;

        public UserService(HamrazmContext context)
        {
            db = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        public Repositories.User GetUser(Repositories.User user)
        {
            return db.Users.AsNoTracking().FirstOrDefault(a => (a.UserName.ToLower() == user.UserName && a.Password == user.Password) || a.UserId == user.UserId);
        }

        public HamrazmResult AddUser(Repositories.User user)
        {
            var result = new HamrazmResult();
            var userName = GetUser(user);
            if (userName != null)
            {
                db.Entry(user).State = EntityState.Added;
                result.Message = "کاربر تعریف شد";
                return result;
            }

            result.IsChange = false;
            result.Message = "کاربر تکراری میباشد";
            return result;
        }

        public HamrazmResult UpdateUser(Repositories.User user)
        {
            var result = new HamrazmResult();
            var userName = GetUser(user);
            var data = Encoding.ASCII.GetBytes(user.Password);
            user.UserName = userName.UserName;
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            var hashedPassword = Encoding.UTF8.GetString(md5data);
            user.Password = hashedPassword;
            db.Entry(user).State = EntityState.Modified;

            result.Message = "کاربر تعریف شدرمز عبور با موفقیت تغییر  یافت";
            return result;

        }
    }
}
