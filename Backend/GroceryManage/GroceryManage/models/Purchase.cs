﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public int Stars { get; set; }
    }
}
