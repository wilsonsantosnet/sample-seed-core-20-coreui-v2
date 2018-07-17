using Microsoft.EntityFrameworkCore;
using Seed.Data.Map;
using Seed.Domain.Entitys;

namespace Seed.Data.Context
{
    public class DbContextSeed : DbContext
    {

        public DbContextSeed(DbContextOptions<DbContextSeed> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SampleStandartMap(modelBuilder.Entity<SampleStandart>());
            new SampleMap(modelBuilder.Entity<Sample>());
            new SampleDetailMap(modelBuilder.Entity<SampleDetail>());
            new SampleTypeMap(modelBuilder.Entity<SampleType>());
            new ProductMap(modelBuilder.Entity<Product>());
            new SampleProductMap(modelBuilder.Entity<SampleProduct>());

        }


    }
}
