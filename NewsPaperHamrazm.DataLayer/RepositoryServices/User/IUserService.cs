namespace NewsPaperHamrazm.DataLayer.RepositoryServices.User
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        Repositories.User GetUser(Repositories.User user);

        HamrazmResult AddUser(Repositories.User user);
        HamrazmResult UpdateUser(Repositories.User user);
    }
}