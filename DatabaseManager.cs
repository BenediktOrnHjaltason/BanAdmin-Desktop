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
        public DbSet<Incident> Incidents { get; set; }

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

            foreach(Incident incident in activeContext.Incidents)
            {
                Debug.WriteLine("INCIDENT: Key: " + incident.ID + ". Date and time: " + incident.DateAndTime + ". Description: " + incident.Description + ". Involved persons:");

                if (incident.InvolvedBannedPersonIDs != null) for (int i = 0; i < incident.InvolvedBannedPersonIDs.Length; i++) Debug.WriteLine(incident.InvolvedBannedPersonIDs[i]);
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
        
        
        [Table("Incident")]
        public class Incident
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public short ID { get; set; }

            [Required]
            public DateTime DateAndTime { get; set; }

            [Required, MaxLength(1500)]
            public string Description { get; set; }

            public string InvolvedBannedPersonIDs { get; set; }
        }
        
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
            */


            context.Bans.Add(new BanAdminDBContext.Ban()
            {
                FirstName = "Bobby",
                LastName = "Socks",
                DescriptionOfPerson = "Small and skinny Bob",
                BanStart = new DateTime(20, 6, 10),
                BanEnd = new DateTime(22, 3, 5),
                BanType = (byte)Enums.BanType.NOTALLOWEDONPROPERTY,
                CustomBanDescription = "DONT LET HIM TOUCH THE WOMEN"
            }) ;

            List<short> temp = new List<short>();
            temp.Add(1);
            temp.Add(2);

            context.Incidents.Add(new BanAdminDBContext.Incident()
            {
                DateAndTime = new DateTime(20, 6, 2),
                Description = "He yelled in the face of the bar maid",
                InvolvedBannedPersonIDs = "123"

            });

            context.SaveChanges();

            
        }
    }

}
