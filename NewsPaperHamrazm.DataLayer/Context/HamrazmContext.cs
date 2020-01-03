using NewsPaperHamrazm.DataLayer.Repositories;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace NewsPaperHamrazm.DataLayer.Context
{
    public class HamrazmContext : DbContext
    {
        public HamrazmContext() : base("HamrazmContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasRequired<City>(x => x.City)
                .WithMany(y => y.Newses)
                .HasForeignKey(x => x.CityId);

            modelBuilder.Entity<News>().HasRequired<Category>(x => x.Category)
                .WithMany(y => y.Newses)
                .HasForeignKey(x => x.CategoryId);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            InitialDb initializer = new InitialDb(modelBuilder);
            Database.SetInitializer(initializer);
        }
        public DbSet<News> Newses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
