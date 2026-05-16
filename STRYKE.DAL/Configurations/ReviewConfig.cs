namespace STRYKE.DAL.Configurations;

public class ReviewConfig : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.ReviewId);

        // Properties

        // Partial Participation: Review MAY be by a Customer
        builder.Property(x => x.CustomerId)
            .IsRequired(false);  // Allow anonymous reviews
 
        // Total Participation: Review MUST be for a Product
        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.Rating)
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(2000);

        // Relations
        // Total Participation: Review must be for a Product
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
 
        // Partial Participation: Review MAY be by a Customer
        builder.HasOne(x => x.Customer)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);  // Keep review if customer deleted

        // Indexes
        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => x.CustomerId);

        // Composite index for customer's reviews on a product
        builder.HasIndex(x => new { x.CustomerId, x.ProductId });

        // Index for finding high-rated reviews
        builder.HasIndex(x => x.Rating);

        // Constraints
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_review_rating",
                "Rating >= 1 AND Rating <= 5");

            t.HasCheckConstraint(
                "chk_review_comment_not_empty",
                "Comment IS NULL OR TRIM(Comment) <> ''");
        });
        
    }
}