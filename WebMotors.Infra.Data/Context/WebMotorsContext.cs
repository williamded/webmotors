using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebMotors.Domain.Entities;
using WebMotors.Infra.Data.Mapping;

namespace WebMotors.Infra.Data.Context
{
    public class WebMotorsContext : DbContext
    {
        public WebMotorsContext() : base("WebMotorsContext")
        {
                
        }

        public DbSet<AnunciosWebMotors> AnunciosWebMotors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AnunciosWebMotorsMapping());

        }
    }
}
