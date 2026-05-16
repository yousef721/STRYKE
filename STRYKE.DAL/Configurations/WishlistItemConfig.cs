namespace STRYKE.DAL.Configurations;

public class WishlistItemConfig : IEntityTypeConfiguration<WishlistItem>
{
    public void Configure(EntityTypeBuilder<WishlistItem> builder)
    {
        builder.HasKey(x => x.WishlistItemId);

        // Properties

        // Total Participation: Item MUST belong to a Wishlist
        builder.Property(x => x.WishlistId)
            .IsRequired();
 
        // Total Participation: Item MUST reference a Product
        builder.Property(x => x.ProductId)
            .IsRequired();
 

        // Relations
        // Total Participation: WishlistItem must belong to a Wishlist
        builder.HasOne(x => x.Wishlist)
            .WithMany(x => x.WishlistItems)
            .HasForeignKey(x => x.WishlistId)
            .OnDelete(DeleteBehavior.Cascade);

        // Total Participation: WishlistItem must reference a Product
        builder.HasOne(x => x.Product)
            .WithMany(x => x.WishlistItems)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);  // Prevent deleting product in wishlist

        // Indexes
        builder.HasIndex(x => x.WishlistId);
        builder.HasIndex(x => x.ProductId);

        // One product per wishlist only
        builder.HasIndex(x => new { x.WishlistId, x.ProductId })
            .IsUnique()
            .HasDatabaseName("UK_WishlistItem_Wishlist_Product");
    }
}