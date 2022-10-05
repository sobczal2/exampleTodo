using Microsoft.EntityFrameworkCore;
using TodoExampleAPI.Models;

namespace TodoExampleAPI;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    // funkcja istotna przy generowaniu migracji
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ograniczamy długość kolumny name w tabeli Notes do 50 znaków
        // ef w ten sposób wygeneruje kolumnę typu NVARCHAR(50) a nie NVARCHAR(MAX)
        modelBuilder.Entity<Note>()
            .Property(x => x.Name)
            .HasMaxLength(50);
    }

    // abstrakcje nad kolumnami w bazie danych
    public DbSet<Note> Notes { get; set; }
    public DbSet<Notebook> Notebooks { get; set; }
}