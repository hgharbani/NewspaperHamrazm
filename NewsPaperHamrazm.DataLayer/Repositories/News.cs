using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaperHamrazm.DataLayer.Repositories
{
   public class News
    {
        /// <summary>
        /// 
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CityId { get; set; }

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
        public string Refrence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewsDiscription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
