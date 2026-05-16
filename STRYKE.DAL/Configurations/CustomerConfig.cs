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

        // Indexes
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.HasIndex(x => x.IsActive);

        // Constraints
        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "chk_customer_first_name_not_empty",
                "TRIM(FirstName) <> ''");

            t.HasCheckConstraint(
                "chk_customer_last_name_not_empty",
                "TRIM(LastName) <> ''");

            t.HasCheckConstraint(
                "chk_customer_username_not_empty",
                "TRIM(UserName) <> ''");

            t.HasCheckConstraint(
                "chk_customer_email_valid",
                "Email LIKE '%@%.%'");
        });

    }
}
