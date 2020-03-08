using Divar.Core.Domain.Advertisements.Entities;
using Divar.Core.Domain.Advertisements.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divar.Infrastructures.Data.SqlServer.Advertisements
{
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(c => c.Location).HasConversion(c => c.Url, 
                d => PictureUrl.FromString(d));
            builder.OwnsOne(c => c.Size);
        }
    }
}