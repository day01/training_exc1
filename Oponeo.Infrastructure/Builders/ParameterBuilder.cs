using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oponeo.Domain;

namespace Oponeo.Infrastructure.Builders;

public static class ParameterBuilder
{
    // TPH Example
    public static void Configure(this EntityTypeBuilder<Parameter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(255);

        builder
            .HasDiscriminator(x => x.Type)
            .HasValue<StringParameter>("String")
            .HasValue<IntParameter>("Int");
    }
}