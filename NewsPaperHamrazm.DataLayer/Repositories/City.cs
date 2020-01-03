using System.Collections.Generic;

namespace NewsPaperHamrazm.DataLayer.Repositories
{

    /// <summary>
    /// 
    /// </summary>
    public class City
    {
        /// <summary>
        /// 
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<News> Newses { get; set; }
    }
}
