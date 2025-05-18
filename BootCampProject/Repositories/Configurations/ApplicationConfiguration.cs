using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ApplicantId).IsRequired();
        builder.Property(a => a.BootcampId).IsRequired();

        builder.Property(a => a.ApplicationState)
               .HasConversion<int>() 
               .IsRequired();

        builder.HasOne(a => a.Applicant)
               .WithMany()
               .HasForeignKey(a => a.ApplicantId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(a => a.Bootcamp)
               .WithMany()
               .HasForeignKey(a => a.BootcampId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}