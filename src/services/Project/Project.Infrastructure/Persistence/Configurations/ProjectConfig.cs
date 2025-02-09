using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Contracts.Enums;
using Project.Domain.Entities;
using Project.Domain.ValueObjects;

namespace Project.Infrastructure.Persistence.Configurations;
public class ProjectConfig : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasConversion(name => name.Value, value => new ProjectName(value))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasConversion(desc => desc.Value, value => new ProjectDescription(value))
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Status)
            .HasConversion(status => status.ToString(), value => (EnProjectStatus)Enum.Parse(typeof(EnProjectStatus), value))
            .IsRequired();

        builder.ToTable("Projects");
    }
}
