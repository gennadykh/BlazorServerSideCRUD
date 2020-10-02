using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleSurvey;
using System.Data;

namespace BlazorServerSideCRUD.Data
{
    public class SurveyDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; } // whole collection
        public DbSet<Role> Roles { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Survey_Questions> SurveyQuestions { get; set; } // questions selected for survey
        public DbSet<SurveyResponse> Responses { get; set; }
        public DbSet<User> Users { get; set; }

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Question>().HasData(
                new
                {
                    ID = 1,
                    Text = "CADWorx Plant: Rank the following items with the highest priority for you and your market first.",
                    QuestionType = SimpleSurvey.QuestionTypes.MultiLineTextBox.ToString(),
                    Options = "TX:15521 Import CAESAR,TX:4877 Support Jacketed Piping,TX:9146-Main Thickness Table"
                },
                new
                {
                    ID = 2,
                    Text = "CADWorx Structure: Rank the following items with the highest priority for you and your market first.",
                    QuestionType = SimpleSurvey.QuestionTypes.MultiLineTextBox.ToString(),
                    Options = "TX:20983-Support Circular,TX:5002-Steel BOM TOTAL"
                }
            );

            builder.Entity<Role>().HasData(
                new
                {
                    ID = 1,
                    Name = "DBO",
                },
                new
                {
                    ID = 2,
                    Name = "SA",
                },
                new
                {
                    ID = 3,
                    Name = "PUBLIC",
                }
            );

            builder.Entity<Survey>().HasData(
                new
                {
                    ID = 1,
                    Title = "Title 1",
                    Description = "my description",
                    CreatedOn = DateTime.Now,
                    ExpiresOn = DateTime.Now.AddMonths(12),
                    CreatedBy = 2,
                    Publish = true
                },
                new
                {
                    ID = 2,
                    Title = "Feed back from",
                    Description = "my description",
                    CreatedOn = DateTime.Now,
                    ExpiresOn = DateTime.Now.AddMonths(12),
                    CreatedBy = 2,
                    Publish = true
                }
            );

            // gok To set composite primary key, use fluent API
            builder.Entity<Survey_Questions>().HasKey(c => new { c.SurveyID, c.QuestionID });

            // gok To set composite primary key, use fluent API
            builder.Entity<SurveyResponse>().HasKey( c => new { c.SurveyID, c.QuestionID});

            builder.Entity<User>().HasData(
                new
                {
                    ID = 2,
                    FirstName = "Gennady",
                    LastName = "Khokhorin",
                    UserName = "GOK",
                    Password = "12345",
                    Role = 1
                },
                new
                {
                    ID = 3,
                    FirstName = "Gopi",
                    LastName = "Kandru",
                    UserName = "Gk",
                    Password = "12345",
                    Role = 4
                },
                new
                {
                    ID = 4,
                    FirstName = "Garrett",
                    LastName = "Walker",
                    UserName = "Gw",
                    Password = "12345",
                    Role = 4
                }
            );
        }
    }
}
