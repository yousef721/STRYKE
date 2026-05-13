namespace STRYKE.DAL.Configurations;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.AddressId);

        // Properties
        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Street)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Building)
            .IsRequired()
            .HasMaxLength(100);

        // Index (performance improvement)
        builder.HasIndex(x => x.CustomerId);
    }
}
