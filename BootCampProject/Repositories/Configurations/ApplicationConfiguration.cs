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
        builder.Property(a => a.ApplicationState).IsRequired();

        builder.HasOne(a => a.Applicant)
               .WithMany()
               .HasForeignKey(a => a.ApplicantId);

        builder.HasOne(a => a.Bootcamp)
               .WithMany()
               .HasForeignKey(a => a.BootcampId);
    }

}
