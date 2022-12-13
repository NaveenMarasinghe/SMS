using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Models;
using System.Threading;

namespace SMS.DataAccess
{
    public class SMSDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }    
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SubjectEnroll> SubjectEnroll { get; set; }
        public DbSet<SubjectMarks> SubjectMarks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=SMSDB;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                NameWithInitials = "H.A.Perera",
                FirstName = "Aravinda",
                LastName = "Perera",
                Email = "aravindaperera@gmail.com",
                Address = "Kelaniya"
            });

            modelBuilder.Entity<Subject>().HasData(new Subject[]
            {
                new Subject {Id = 1, Name = "Science", Credits= 3},
                new Subject {Id = 2, Name = "English", Credits= 3},
                new Subject {Id = 3, Name = "Maths", Credits= 3},

            });

            modelBuilder.Entity<Grade>().HasData(new Grade[]
            {
                new Grade {Id = 1, Name = "D", Min_mark = 0 , Max_mark = 9},
                new Grade {Id = 2, Name = "C-", Min_mark = 10 , Max_mark = 19},
                new Grade {Id = 3, Name = "C", Min_mark = 20 , Max_mark = 29},
                new Grade {Id = 4, Name = "C+", Min_mark = 30 , Max_mark = 39},
                new Grade {Id = 5, Name = "B-", Min_mark = 40 , Max_mark = 49},
                new Grade {Id = 6, Name = "B", Min_mark = 50 , Max_mark = 59},
                new Grade {Id = 7, Name = "B+", Min_mark = 60 , Max_mark = 69},
                new Grade {Id = 8, Name = "A-", Min_mark = 70 , Max_mark = 79},
                new Grade {Id = 9, Name = "A", Min_mark = 80 , Max_mark = 89},
                new Grade {Id = 10, Name = "A+", Min_mark = 90 , Max_mark = 100}

            });

            modelBuilder.Entity<SubjectEnroll>().HasData(new SubjectEnroll[]
            {
                new SubjectEnroll {Id = 1, StudentId= 1, SubjectId= 1},
                new SubjectEnroll {Id = 2, StudentId= 1, SubjectId= 2},
                new SubjectEnroll {Id = 3, StudentId= 1, SubjectId= 3},
                new SubjectEnroll {Id = 4, StudentId= 2, SubjectId= 1},

            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Get all the entities that inherit from AuditableEntity
            // and have a state of Added or Modified
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            // For each entity we will set the Audit properties
            foreach (var entityEntry in entries)
            {
                // If the entity state is Added let's set
                // the CreatedAt and CreatedBy properties
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    // If the state is Modified then we don't want
                    // to modify the CreatedAt and CreatedBy properties
                    // so we set their state as IsModified to false
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;                }

                // In any case we always want to set the properties
                // ModifiedAt and ModifiedBy
                ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
            }

            // After we set all the needed properties
            // we call the base implementation of SaveChangesAsync
            // to actually save our entities in the database
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
