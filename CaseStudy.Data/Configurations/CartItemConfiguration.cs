using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaseStudy.Core;

namespace CaseStudy.Data.Configurations
{
    internal class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CartId).IsRequired().HasColumnType("int");
            builder.Property(x => x.ProductId).IsRequired().HasColumnType("int");
            builder.Property(x => x.Quantity).IsRequired().HasColumnType("tinyint");
            builder.Property(x => x.IsDeleted).IsRequired().HasColumnType("bit");
            builder.ToTable("CartItems");
            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId);
        }
    }
}
