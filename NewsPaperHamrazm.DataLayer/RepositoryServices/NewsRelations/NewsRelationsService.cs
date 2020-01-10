using System.Collections.Generic;
using System.Data.Entity;
using NewsPaperHamrazm.DataLayer.Context;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.NewsRelations
{
    public class NewsRelationsService : INewsRelationsService
    {
        private HamrazmContext _db;
        public NewsRelationsService(HamrazmContext context)
        {
            _db = context;
        }

        public HamrazmResult AddNewsRelations(List<Repositories.NewsRelations> newsRelationses)
        {
            var result=new HamrazmResult();

            foreach (var newsRelationse in newsRelationses)
            {
                _db.Entry(newsRelationse).State = EntityState.Added;
               
            }
            result.Message = "رکورد با موفقیت ثبت شد";
            return result;
        }
    }
}
