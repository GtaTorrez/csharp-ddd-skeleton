namespace CodelyTv.Mooc.Shared.Infrastructure.Persistence.EntityFramework.EntityConfigurations
{
    using CodelyTv.Shared.Infrastructure.Persistence.EntityFramework.Extension;
    using CoursesCounter.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ValueConverter;

    public class CoursesCounterConfiguration : IEntityTypeConfiguration<CoursesCounter>
    {
        public void Configure(EntityTypeBuilder<CoursesCounter> builder)
        {
            builder.ToTable(nameof(MoocContext.CoursesCounter).ToDatabaseFormat());

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(v => v.Value, v => new CoursesCounterId(v))
                .HasColumnName(nameof(CoursesCounter.Id).ToDatabaseFormat());

            builder.OwnsOne(x => x.Total)
                .Property(x => x.Value)
                .HasColumnName(nameof(CoursesCounter.Total).ToDatabaseFormat());

            builder.Property(e => e.ExistingCourses)
                .HasConversion(new ExistingCoursesConverter())
                .HasColumnName(nameof(CoursesCounter.ExistingCourses).ToDatabaseFormat());
        }
    }
}