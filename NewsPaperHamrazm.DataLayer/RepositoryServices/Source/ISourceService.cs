using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.RepositoryServices.Source
{
    public interface ISourceService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceName"></param>
        /// <param name="pasword"></param>
        /// <returns></returns>
        Repositories.Source GetSource(Repositories.Source Source);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceId"></param>
        /// <returns></returns>
        Repositories.Source GetSourceById(int SourceId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceIds"></param>
        /// <returns></returns>
        List<Repositories.Source> GetAllSource(List<int> SourceIds);

        HamrazmResult AddSource(Repositories.Source Source);
        HamrazmResult UpdateSource(Repositories.Source Source);
        HamrazmResult DeleteCompany(Repositories.Source Source);
        HamrazmResult DeleteSource(int SourceId);
    }
}