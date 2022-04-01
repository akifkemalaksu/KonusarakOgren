using KonusarakOgren.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KonusarakOgren.DataAccess.EntityFramework
{
    public class KonusarakOgrenContext : DbContext
    {
        public KonusarakOgrenContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserQuestionAnswer> UserQuestionAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasOne<Topic>()
                .WithMany()
                .HasForeignKey(q => q.TopicId);

            modelBuilder.Entity<Answer>()
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<UserQuestionAnswer>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(map => map.UserId);
            modelBuilder.Entity<UserQuestionAnswer>()
                .HasOne<Question>()
                .WithMany()
                .HasForeignKey(map => map.QuestionId);
            modelBuilder.Entity<UserQuestionAnswer>()
                .HasOne<Answer>()
                .WithMany()
                .HasForeignKey(map => map.AnswerId);
        }
    }
}