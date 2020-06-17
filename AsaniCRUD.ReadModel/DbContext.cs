using System;
using System.Threading;
using System.Threading.Tasks;
using AsaniCRUD.ReadModel.Mappings;
using AsaniCRUD.ReadModel.Models;
using Microsoft.EntityFrameworkCore;

namespace AsaniCRUD.ReadModel
{
    public class AsaniContext : DbContext
    {
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Owner> Owners { get; set; }


        public AsaniContext(DbContextOptions<AsaniContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurations(typeof(EstateMap).Assembly);

        }

        public override int SaveChanges()
        {
            throw new NotSupportedException();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}
