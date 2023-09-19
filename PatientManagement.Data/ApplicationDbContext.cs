using Microsoft.EntityFrameworkCore;
using PatientManagement.Data.Models;

namespace PatientManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PatientManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            return this;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Get types with reflection
            //Criteria:
            //- GetExportedTypes s--> public
            //- every class derived from IEntity (Baseentity. And Entity inherits BaseEntity.)
            //- class, not abstract, etc.

            var entities = GetType().Assembly.GetExportedTypes()
                .Where(x => typeof(IEntity).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract && !x.IsInterface );

            foreach (var entity in entities)
            {
                modelBuilder.Entity(entity);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}