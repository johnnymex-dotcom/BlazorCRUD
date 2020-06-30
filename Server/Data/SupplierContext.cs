using Microsoft.EntityFrameworkCore;
using BlazorCRUD.Shared;


namespace BlazorCRUD.Server.Data
{
    public class SuppliersContext : DbContext
    {
        public SuppliersContext(DbContextOptions options) : base(options)
        {
        }

        //public virtual DbSet<Suppliers> Supplier { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }

}
