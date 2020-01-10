using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPaperHamrazm.DataLayer.Repositories;

namespace NewsPaperHamrazm.DataLayer.ViewModel
{
   public class NewsModel
    {

        public NewsModel()
        {
            NewsRelationses=new List<NewsRelations>();
        }
        public List<NewsRelations> NewsRelationses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> CategoryIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> CityIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<int> SourceIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime NewsDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime InsertTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewsDiscription { get; set; }

    }
}
