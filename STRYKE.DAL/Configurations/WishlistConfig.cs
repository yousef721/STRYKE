namespace STRYKE.DAL.Configurations;

public class WishlistConfig : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.HasKey(x => x.WishlistId);

        // Partial Participation: Customer MAY or MAY NOT have a Wishlist
        builder.Property(x => x.CustomerId)
            .IsRequired(false);

        // Relations
        // Partial Participation: Customer MAY or MAY NOT have a Wishlist
        // Wishlist is created on-demand, not auto-created with customer
        builder.HasOne(x => x.Customer)
            .WithOne(x => x.Wishlist)
            .HasForeignKey<Wishlist>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.CustomerId);
    }
}