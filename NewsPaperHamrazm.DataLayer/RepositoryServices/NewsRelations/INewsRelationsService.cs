using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.NewsRelations
{
    public interface INewsRelationsService
    {
        HamrazmResult AddNewsRelations(List<Repositories.NewsRelations> newsRelationses);
    }
}