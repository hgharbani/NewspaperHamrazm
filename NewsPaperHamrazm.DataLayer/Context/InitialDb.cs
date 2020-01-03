using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPaperHamrazm.DataLayer.Repositories;


namespace NewsPaperHamrazm.DataLayer.Context
{
   public class InitialDb:SQLite.CodeFirst.SqliteCreateDatabaseIfNotExists<HamrazmContext>
   {
   public InitialDb(DbModelBuilder modelBuilder) : base(modelBuilder)
   {
   }
   string _data = "jelveh";
   byte[] hash;
   protected override void Seed(HamrazmContext context)
   {
       IList<User> defaultStandards = new List<User>();
       
       var addMinPassword = "12345";
       defaultStandards.Add(new User()
       {
           UserName = "admin",
           Password = addMinPassword.ToHashCode(),
           UserGroup = UserGroup.Admin
       });

       context.Users.AddRange(defaultStandards);
       base.Seed(context);
   }


   }
}
