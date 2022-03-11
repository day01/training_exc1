using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oponeo.Domain;

namespace Oponeo.Infrastructure.Builders;

public static class ExampleObjectBuilder
{
    public static void Configure(this EntityTypeBuilder<ExampleObject> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IntValue).IsRequired().HasPrecision(19, 2);
        builder.Property(x => x.StringValue).HasMaxLength(255);

        builder.Property(x => x.ExampleStatus).HasConversion(new EnumToStringConverter<ExampleStatus>());
        builder.Property(x => x.CreatedDate).IsRequired();

        builder.HasMany(x => x.SubExampleObjects).WithOne(x => x.ExampleObject);
    }
}