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
            optionsBuilder.UseSqlite(@"Data Source=MyDatabase.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasOne<Topic>()
                .WithMany()
                .HasForeignKey(e => e.TopicId);

            modelBuilder.Entity<Question>()
                .HasOne<Exam>()
                .WithMany()
                .HasForeignKey(q => q.ExamId);

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
