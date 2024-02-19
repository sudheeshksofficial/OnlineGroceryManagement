using GroceryManage.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.DataAccess
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions options) : base(options) 
        {
           
        }

        public  DbSet<UserModel> userModel { get; set; }

        public DbSet<AdminUser> adminUsers { get; set; }

        public DbSet<Purchase> purchase { get; set; }

        public DbSet<Stocks> stocks { get; set; }
    }
}
