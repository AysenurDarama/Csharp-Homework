using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.NationalIdentity).HasColumnName("NationalIdentity").IsRequired();
        builder.Property(u => u.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.Password).HasColumnName("Password").IsRequired();
        builder.Property(u => u.UserType).HasColumnName("UserType").IsRequired();
    }
}