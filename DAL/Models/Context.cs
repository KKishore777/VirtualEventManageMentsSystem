using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        //To Declare Prop of type DbSet<TEntity>
        //This DbSet<> Is Used To Perform CURD Operations
        public DbSet <UserInfo>userInfos{ get; set; }
        public DbSet<EventDetails> eventDetails { get; set; }
        public DbSet<SessionInfo> sessionInfos { get; set; }
        public DbSet<SpeakersDetails> speakersDetails { get; set; }
        public DbSet<ParticipantEventDetails>participantEventDetails { get; set; }

        //WHY We want to override Because i want to configure connection String for DataBase
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //To Configure a Connection String
            if (!optionsBuilder.IsConfigured)
            {
                var conStr= DataBaseHelper.GetConnectionString();
                optionsBuilder.UseSqlServer(conStr);
            }
            base.OnConfiguring(optionsBuilder);
        }

        //To Configure Entities/Model using fluent api(changing Of Methods) for relationShips one to many
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantEventDetails>().HasOne<UserInfo>().WithMany().HasForeignKey(p => p.EmailId).HasPrincipalKey(u => u.EmailId).OnDelete(DeleteBehavior.Cascade); // Add this to prevent cycles
            modelBuilder.Entity<SessionInfo>().HasOne<EventDetails>().WithMany().HasForeignKey(even => even.EventId);
            modelBuilder.Entity<SessionInfo>().HasOne<SpeakersDetails>().WithMany().HasForeignKey(speak => speak.SpeakerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ParticipantEventDetails>().HasOne<SessionInfo>().WithMany().HasForeignKey(session => session.SessionId).OnDelete(DeleteBehavior.Cascade); // Add this as well

            modelBuilder.Entity<UserInfo>().HasData(new UserInfo { EmailId = "Admin@gmail.com", UserName = "Kishore", password = "admin123", Role = "Admin" }); base.OnModelCreating(modelBuilder);
        }
    }
}
