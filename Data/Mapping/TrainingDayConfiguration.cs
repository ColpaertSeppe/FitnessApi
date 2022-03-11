using FitnessApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApi.Data.Mapping
{
    public class TrainingDayConfiguration : IEntityTypeConfiguration<TrainingDay>
    {
        public void Configure(EntityTypeBuilder<TrainingDay> builder)
        {
            builder.ToTable("trainingday");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.TrainingDate).IsRequired();
        }
    }
}
