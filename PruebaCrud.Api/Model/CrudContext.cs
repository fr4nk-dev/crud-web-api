using Microsoft.EntityFrameworkCore;

namespace PruebaCrud.Api.Model
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions options) : base(options){}

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pedido>().ToTable("Pedido");
       
        }
    }
}
