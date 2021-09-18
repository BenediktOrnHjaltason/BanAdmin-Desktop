using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BanAdmin
{
    public class BanAdminDBContext : DbContext
    {
        public DbSet<LoginDetails> loginDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
        }

        [Table("Login")]
        public class LoginDetails
        {
            [Key]
            public string username { get; set; }
            public string password { get; set; }

        }

    }

    public static class DBContextSeeder 
    {
        public static void Seed(BanAdminDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.loginDetails.Add(new BanAdminDBContext.LoginDetails()
            {
                username = "Nellie", 
                password = "Schmoyoho"
            }) ;

            context.SaveChanges();
        }
    }
}
