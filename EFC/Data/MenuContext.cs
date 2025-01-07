using EFC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFC;

public class MenuContext : DbContext
{
    public DbSet<DrinksMenu> DrinksMenus => Set<DrinksMenu>();
    public DbSet<Drinks> Drinks => Set<Drinks>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("Current directory: " + Environment.CurrentDirectory);
        optionsBuilder.UseSqlite("Data Source=../../../menu.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drinks>()
            .HasOne(d => d.DrinksMenu)
            .WithMany(d => d.Drinks)
            .HasForeignKey(d => d.DrinksMenuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}