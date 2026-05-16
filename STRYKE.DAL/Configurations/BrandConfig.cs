namespace STRYKE.DAL.Configurations;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.BrandId);

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Logo)
            .HasMaxLength(500);

        // Indexes
        builder.HasIndex(x => x.Name)
            .IsUnique();

        
        // Constraints
        builder.ToTable("Brands", t =>
        {
            t.HasCheckConstraint(
                "chk_brand_name_not_empty",
                "TRIM(Name) <> ''");
        });
    }
}
