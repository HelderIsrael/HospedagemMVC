using HospedagemMVC.Domain;
using System.Data.Entity;


namespace HospedagemMVC.Infra.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("CustomerContext")
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("TBCustomer");
            modelBuilder.Entity<Customer>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Accommodation>().ToTable("TBAccommodation");
            modelBuilder.Entity<Accommodation>()
                .Property(b => b.DateChekIn)
                .IsRequired();
            modelBuilder.Entity<Accommodation>()
                .Property(b => b.DateCheckOut)
                .IsRequired();

        }

    }
}
