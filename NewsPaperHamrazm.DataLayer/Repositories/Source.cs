using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaperHamrazm.DataLayer.Repositories
{
  public  class Source
    {
        /// <summary>
        /// 
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Collection<NewsRelations> NewsRelationses { get; set; }

}
}
