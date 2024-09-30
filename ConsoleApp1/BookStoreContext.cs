using Microsoft.EntityFrameworkCore;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Sales> Sales { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=2;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.BookId);
            entity.Property(b => b.CostPrice).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(b => b.SalePrice).HasColumnType("decimal(18,2)").IsRequired();

            entity.HasOne(b => b.Author)
                  .WithMany(a => a.Books)
                  .HasForeignKey(b => b.AuthorId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.Publisher)
                  .WithMany(p => p.Books)
                  .HasForeignKey(b => b.PublisherId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.Genre)
                  .WithMany(g => g.Books)
                  .HasForeignKey(b => b.GenreId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.PreviousBook)
                  .WithMany()
                  .HasForeignKey(b => b.PreviousBookId)
                  .OnDelete(DeleteBehavior.Restrict); // Change to Restrict to prevent cycles
        });
    }
}
