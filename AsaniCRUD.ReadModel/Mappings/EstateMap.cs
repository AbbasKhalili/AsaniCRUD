using AsaniCRUD.ReadModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsaniCRUD.ReadModel.Mappings
{
    public class EstateMap : IEntityTypeConfiguration<Estate>
    {
        public void Configure(EntityTypeBuilder<Estate> builder)
        {
            builder.ToTable("Estates");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Address).HasColumnName("Address");
            builder.Property(t => t.Area).HasColumnName("Area");
            builder.Property(t => t.Direction).HasColumnName("Direction");
            builder.Property(t => t.OwnerId).HasColumnName("OwnerId");
           
            builder.HasOne(x => x.Owner).WithMany(x => x.Estates).HasForeignKey(x => x.OwnerId);
        }
    }
}
