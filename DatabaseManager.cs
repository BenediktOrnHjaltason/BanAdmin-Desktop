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
using Microsoft.EntityFrameworkCore.Migrations;

namespace BanAdmin
{
    public class BanAdminDBContext : DbContext
    {
        public static BanAdminDBContext activeContext = null;

        public DbSet<LoginDetails> loginDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
        }

        public static void Initialize()
        {
            activeContext = new BanAdminDBContext();
            activeContext.Database.EnsureCreated();

        }

        [Table("Login")]
        public class LoginDetails
        {
            [Key]
            public string Username { get; set; }
            public string Password { get; set; }

        }

        /*
        [Table("Ban")]
        public class Ban
        {
            [Key]
            public int ID { get; set; }

            public DateTime BanStart { get; set; }

            public DateTime BanEnd { get; set; }

            

            [MaxLength(20)]
            public string FirstName { get; set; }

            [MaxLength(20)]
            public string LastName { get; set; }


        }
        */

    }

    public static class DBContextSeeder 
    {
        public static void Seed(BanAdminDBContext context)
        {
            /*
            context.Database.EnsureDeleted();
            

            context.loginDetails.Add(new BanAdminDBContext.LoginDetails()
            {
                username = "Nellie", 
                password = "Schmoyoho"
            }) ;

            context.SaveChanges();
            */
        }
    }
}
