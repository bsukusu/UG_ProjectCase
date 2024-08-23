using Microsoft.EntityFrameworkCore;


namespace UGCase.Models.Context
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }
        public DbSet<musteri> musteris { get; set; }
        public DbSet<musteriFatura> musterisFatura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<musteriFatura>()
                .Property(f => f.faturaTutari)
                .HasColumnType("decimal(18,2)"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
