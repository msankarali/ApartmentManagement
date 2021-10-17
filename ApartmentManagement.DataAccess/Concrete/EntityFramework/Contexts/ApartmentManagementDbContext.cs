using System.Reflection;
using ApartmentManagement.Entities.Models;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework.Contexts
{
    public partial class ApartmentManagementDbContext : BaseDbContext
    {
        public ApartmentManagementDbContext(DbContextOptions<ApartmentManagementDbContext> options) : base(options) { }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<ChatGroup> ChatGroups { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceType> InvoiceTypes { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Occupant> Occupants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}