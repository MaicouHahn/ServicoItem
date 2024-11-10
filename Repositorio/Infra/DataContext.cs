using Microsoft.EntityFrameworkCore;
using ServicoItem.Models;

namespace ServicoItem.Repositorio.Infra
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) 
        {
        }

        public DbSet<Item> itens {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey(p => p.IdItem);
            base.OnModelCreating(modelBuilder);
        }
    }
}
