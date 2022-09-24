using Sample.Domains;
using System.Data.Entity;

namespace Sample.Repositories
{
    public class BusinessDBContext : DbContext
    {
        public BusinessDBContext()
            : base("BusinessDBConnectionString")
        {
            Database.SetInitializer<BusinessDBContext>(null);
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
        }
    }
}
