using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.models
{
    public class AdminUser
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminMail { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}
