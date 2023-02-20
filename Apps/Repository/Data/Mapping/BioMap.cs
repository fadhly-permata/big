using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Mapping
{
    public partial class BioMap
        : IEntityTypeConfiguration<Repository.Data.Entities.Bio>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Repository.Data.Entities.Bio> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("Bio");

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

            builder.Property(t => t.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate")
                .HasColumnType("TEXT");

            builder.Property(t => t.Height)
                .IsRequired()
                .HasColumnName("Height")
                .HasColumnType("INTEGER");

            builder.Property(t => t.Weight)
                .IsRequired()
                .HasColumnName("Weight")
                .HasColumnType("INTEGER");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "";
            public const string Name = "Bio";
        }

        public struct Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string BirthDate = "BirthDate";
            public const string Height = "Height";
            public const string Weight = "Weight";
        }
        #endregion
    }
}
