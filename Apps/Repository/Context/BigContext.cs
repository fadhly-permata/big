using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Context
{
    public partial class BigContext : DbContext
    {
        public BigContext(DbContextOptions<BigContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            #pragma warning disable CS1030 // #warning directive
            => optionsBuilder.UseSqlite("Data Source=/home/permata/Documents/DB/big.sqlite");

        #region Generated Properties
        public virtual DbSet<Repository.Data.Entities.Bio> Bios { get; set; } = null!;

        public virtual DbSet<Repository.Data.Entities.Grade> Grades { get; set; } = null!;

        public virtual DbSet<Repository.Data.Entities.Students> Students { get; set; } = null!;

        public virtual DbSet<Repository.Data.Entities.vCompiledStudent> VCompiledStudents { get; set; } = null!;

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Generated Configuration
            modelBuilder.ApplyConfiguration(new Repository.Data.Mapping.BioMap());
            modelBuilder.ApplyConfiguration(new Repository.Data.Mapping.GradeMap());
            modelBuilder.ApplyConfiguration(new Repository.Data.Mapping.StudentsMap());
            modelBuilder.ApplyConfiguration(new Repository.Data.Mapping.vCompiledStudentMap());
            #endregion
        }
    }
}
