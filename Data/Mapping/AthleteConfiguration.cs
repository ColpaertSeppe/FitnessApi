﻿using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApi.Data.Mapping
{
    public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
            builder.ToTable("athlete");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x=>x.Height).IsRequired();

            //builder.HasMany(x => x.TrainingPlans)
            //        .WithMany(x => x.Athletes);
        }
    }
}
