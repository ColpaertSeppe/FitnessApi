using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApi.Data.Mapping
{
    public class TrainingPlanConfiguration : IEntityTypeConfiguration<TrainingPlan>
    {
        public void Configure(EntityTypeBuilder<TrainingPlan> builder)
        {
            builder.ToTable("trainingplan");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        }
    }
}
