using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual  ICollection<News> Newses { get; set; }
    }
}
