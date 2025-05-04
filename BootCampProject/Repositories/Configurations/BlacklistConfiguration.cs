using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configurations;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>

{
    public void Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.ToTable("Blacklists");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Reason).IsRequired();
        builder.Property(b => b.Date).IsRequired();
        builder.Property(b => b.ApplicantId).IsRequired();

        builder.HasOne(b => b.Applicant)
               .WithMany()
               .HasForeignKey(b => b.ApplicantId);
    }

}
