﻿
using FitnessApi.Data.Mapping;
using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FitnessApi.Data
{
    public class DataContext : DbContext
    {
        DataInitializer _initializer = null;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            if (_initializer==null)
            {
                _initializer = new(this);
                _initializer.InitializeData();
            }
        }

        public DbSet<Athlete> Athletes => Set<Athlete>();
        public DbSet<Coach> Coaches => Set<Coach>();
        public DbSet<TrainingDay> TrainingDays => Set<TrainingDay>();
        public DbSet<TrainingPlan> TrainingPlans => Set<TrainingPlan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
