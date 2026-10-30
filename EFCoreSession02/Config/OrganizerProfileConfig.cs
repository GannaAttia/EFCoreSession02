using EFCoreSession02.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreSession02.Config
{
    public class OrganizerProfileConfig  :IEntityTypeConfiguration<OrganizerProfile>

    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Biography)
                   .HasMaxLength(500);

            builder.Property(p => p.WebsiteUrl)
                   .HasMaxLength(250);

            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
