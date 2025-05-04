using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configurations;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamps");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.InstructorId).IsRequired();
        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
        builder.Property(b => b.BootcampState).IsRequired();

        builder.HasOne(b => b.Instructor)
               .WithMany()
               .HasForeignKey(b => b.InstructorId);
    }

}
