using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaperHamrazm.DataLayer.Repositories
{
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserGroup UserGroup { get; set; }

    }
    public enum UserGroup : byte
    {
        /// <summary>
        /// Heading
        /// سرفصل
        /// </summary>
        [Display(Name = "Admin")]
        [Description("Admin")]
        Admin = 1,

        /// <summary>
        /// Heading
        /// سرفصل
        /// </summary>
        [Display(Name = "User")]
        [Description("User")]
        User = 2,
    }
}
