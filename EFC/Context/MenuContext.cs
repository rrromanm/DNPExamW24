using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC.Context;
public class MenuContext : DbContext
{
    public DbSet<DrinksMenu> DrinksMenus => Set<DrinksMenu>();
    public DbSet<Drink> Drinks => Set<Drink>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());
        optionsBuilder.UseSqlite("Data Source=../../../menu.db");
    }
    
    
}