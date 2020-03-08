using Divar.Core.Domain.Advertisements.Entities;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divar.Infrastructures.Data.SqlServer.Advertisements
{
    public class AdvertisementConfig : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(c => c.Price).HasConversion(c => c.Value.Value,
                d => Price.FromLong(d));

            builder.Property(c => c.OwnerId).HasConversion(c => c.Value.ToString(),
                d => UserId.FromString(d));

            builder.Property(c => c.ApprovedBy).HasConversion(c => c.Value.ToString(),
                d => UserId.FromString(d));

            builder.Property(c => c.Description).HasConversion(c => c.Value,
                d => AdvertisementDescription.FromString(d));

            builder.Property(c => c.Title).HasConversion(c => c.Value,
                d => AdvertisementTitle.FromString(d));
        }
    }
}