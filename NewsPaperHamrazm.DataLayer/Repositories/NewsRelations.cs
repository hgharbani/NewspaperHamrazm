using System.ComponentModel.DataAnnotations;

namespace NewsPaperHamrazm.DataLayer.Repositories
{
    public class NewsRelations
    {

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int RelationId { get; set; }

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
        public int SourceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Source Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual News news { get; set; }

    }
}
