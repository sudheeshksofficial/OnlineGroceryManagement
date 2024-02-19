using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserMail { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }



    }
}
