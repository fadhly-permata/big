using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Mapping
{
    public partial class vCompiledStudentMap
        : IEntityTypeConfiguration<Repository.Data.Entities.vCompiledStudent>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Repository.Data.Entities.vCompiledStudent> builder)
        {
            #region Generated Configure
            // table
            builder.ToView("v_compiled_student");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Name)
                .HasColumnName("Name")
                .HasColumnType("TEXT");

            builder.Property(t => t.Grade)
                .HasColumnName("Grade")
                .HasColumnType("TEXT");

            builder.Property(t => t.Age)
                .HasColumnName("Age");

            builder.Property(t => t.Height)
                .HasColumnName("Height")
                .HasColumnType("INTEGER");

            builder.Property(t => t.Weight)
                .HasColumnName("Weight")
                .HasColumnType("INTEGER");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "";
            public const string Name = "v_compiled_student";
        }

        public struct Columns
        {
            public const string Name = "Name";
            public const string Grade = "Grade";
            public const string Age = "Age";
            public const string Height = "Height";
            public const string Weight = "Weight";
        }
        #endregion
    }
}
