using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Mapping
{
    public partial class GradeMap
        : IEntityTypeConfiguration<Repository.Data.Entities.Grade>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Repository.Data.Entities.Grade> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Grade");

            // key
            builder.HasKey(t => t.Id);

            // properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("INTEGER")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("TEXT");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "";
            public const string Name = "Grade";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
        }
        #endregion
    }
}
