using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oponeo.Domain;

namespace Oponeo.Infrastructure.Builders;

public static class OfferBuilder
{
    public static void Configure(this EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status).HasConversion(new EnumToStringConverter<OfferStatus>());

        builder.HasMany(x => x.Parameters);
    }
}