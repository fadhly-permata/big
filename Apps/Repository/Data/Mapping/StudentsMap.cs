using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Mapping
{
    public partial class StudentsMap
        : IEntityTypeConfiguration<Repository.Data.Entities.Students>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Repository.Data.Entities.Students> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Students");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.BioId)
                .IsRequired()
                .HasColumnName("BioId")
                .HasColumnType("INTEGER");

            builder.Property(t => t.GradeId)
                .IsRequired()
                .HasColumnName("GradeId")
                .HasColumnType("INTEGER");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "";
            public const string Name = "Students";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string BioId = "BioId";
            public const string GradeId = "GradeId";
        }
        #endregion
    }
}
