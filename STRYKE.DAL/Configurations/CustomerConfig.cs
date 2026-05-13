namespace STRYKE.DAL.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.CustomerId);

        // Properties
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.PasswordHash)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.Gender)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        // Indexes (important for performance)
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        // Relations
        builder.HasMany(x => x.Addresses)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Reviews)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.Cart)
            .WithOne(x => x.Customer)
            .HasForeignKey<Cart>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Wishlist)
            .WithOne(x => x.Customer)
            .HasForeignKey<Wishlist>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
