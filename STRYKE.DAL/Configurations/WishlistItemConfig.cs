namespace STRYKE.DAL.Configurations;

public class WishlistItemConfig : IEntityTypeConfiguration<WishlistItem>
{
    public void Configure(EntityTypeBuilder<WishlistItem> builder)
    {
        builder.HasKey(x => x.WishlistItemId);

        // Relations
        builder.HasOne(x => x.Wishlist)
            .WithMany(x => x.WishlistItems)
            .HasForeignKey(x => x.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.WishlistId);
        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => new { x.WishlistId, x.ProductId })
            .IsUnique();
    }
}