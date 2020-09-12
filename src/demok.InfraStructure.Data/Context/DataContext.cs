using demok.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace demok.InfraStructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        #region DbSet

        public DbSet<Customer> Customer { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Mappings
            //modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
