using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oponeo.Domain;

namespace Oponeo.Infrastructure.Builders;

public static class SubExampleObjectBuilder
{
    public static void Configure(this EntityTypeBuilder<SubExampleObject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(255);
    }
}
