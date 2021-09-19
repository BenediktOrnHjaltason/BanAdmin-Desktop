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
using System.Diagnostics;

namespace BanAdmin
{
    public class BanAdminDBContext : DbContext
    {
        public static BanAdminDBContext activeContext = null;

        public DbSet<LoginDetails> loginDetails { get; set; }
        public DbSet<Ban> Bans { get; set; }
        //public DbSet<Incident> Incidents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
        }

        public static void Initialize()
        {
            activeContext = new BanAdminDBContext();

            activeContext.Database.Migrate();      

            //DBContextSeeder.Seed(activeContext);

            
            foreach(LoginDetails login in activeContext.loginDetails)
            {
                Debug.WriteLine("USERNAME: =" + login.Username + " PASSWORD= " + login.Password);
            }

            foreach(Ban ban in activeContext.Bans)
            {
                Debug.WriteLine("BAN: KEY: " + ban.ID + ". First name = " + ban.FirstName + ". Last name = " + ban.LastName + " " + ban.DescriptionOfPerson + " " + ban.BanStart.ToString() + " " + (ban.BanEnd == DateTime.MinValue ? ban.BanEnd.ToString() : "Ban End is NULL"));
            }
        }

        
        [Table("Login")]
        public class LoginDetails
        {
            [Key]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

        }

        
        [Table("Ban")]
        public class Ban
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public short ID { get; set; }


            [MaxLength(30), Required]
            public string FirstName { get; set; }

            [MaxLength(30), Required]
            public string LastName { get; set; }

            [MaxLength(200)]
            public string DescriptionOfPerson { get; set; }

            [Required]
            public DateTime BanStart { get; set; }

            [Required]
            public DateTime BanEnd { get; set; }

            [Required]
            public byte BanType { get; set; }

            [MaxLength(200)]
            public string CustomBanDescription { get; set; }

        }
        
        /*
        [Table("Incident")]
        public class Incident
        {
            [Key]
            public short ID { get; set; }

            public DateTime DateAndTime { get; set; }

            [MaxLength(1500)]
            public string Description { get; set; }

            public List<short> InvolvedBannedPersonIDs { get; set; }
        }
        */
    }

    public static class DBContextSeeder 
    {
        public static void Seed(BanAdminDBContext context)
        {
            /*
            context.loginDetails.Add(new BanAdminDBContext.LoginDetails()
            {
                Username = "1", 
                Password = "2"
            }) ;
            


            context.Bans.Add(new BanAdminDBContext.Ban()
            {
                FirstName = "Franky",
                LastName = "Powers",
                DescriptionOfPerson = "Tall and fat like a pig",
                BanStart = new DateTime(2021, 6, 10),
                BanEnd = DateTime.MinValue,
                BanType = (byte)Enums.BanType.NOTALLOWEDONPROPERTY,
                CustomBanDescription = null
            }) ;

            context.SaveChanges();

            */
        }
    }

}
