namespace STRYKE.DAL.Configurations;

public class CartConfig : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.CartId);
        
        // Total Participation: Cart MUST belong to a Customer
        builder.Property(x => x.CustomerId)
            .IsRequired();

        // Relations
        // Total Participation: Cart MUST belong to a Customer
        builder.HasOne(x => x.Customer)
            .WithOne(x => x.Cart)
            .HasForeignKey<Cart>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.CustomerId);

    }
}
