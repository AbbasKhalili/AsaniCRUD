using AsaniCRUD.ReadModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaniCRUD.ReadModel.Mappings
{
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Family).HasColumnName("Family");
            builder.Property(t => t.Phone).HasColumnName("Phone");
            
            builder.HasMany(x => x.Estates).WithOne(x => x.Owner).HasForeignKey(x => x.OwnerId);
        }
    }
}