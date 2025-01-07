using EFC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFC;

public class DataAccess
{
    public readonly MenuContext ctx;
    
    public DataAccess(MenuContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task CreateDrinksMenu(DrinksMenu menu)
    {
        await ctx.DrinksMenus.AddAsync(menu);
        await ctx.SaveChangesAsync();
    }

    public async Task AddDrinksToMenu(int menuId, Drinks drink)
    {
        DrinksMenu? DrinksMenu = await ctx.DrinksMenus.FirstOrDefaultAsync(p => p.Id == menuId);
        if (DrinksMenu == null)
        {
            throw new ArgumentException("Menu not found");
        }
        drink.DrinksMenuId = menuId;
        drink.Id = await ctx.Drinks.MaxAsync(p => p.Id) + 1;
        DrinksMenu.Drinks.Add(drink);
        ctx.DrinksMenus.AddAsync(DrinksMenu);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Drinks>> getDrinks(double minAlcohol, double maxAlcohol, bool hasUmbrella)
    {
        List<Drinks>? filteredDrinks = await ctx.Drinks.Where(p => p.AlcoholPercentage >= minAlcohol && p.AlcoholPercentage <= maxAlcohol || p.IncludesUmbrella == hasUmbrella).ToListAsync();
        return filteredDrinks;
    }
    
    public async Task<List<DrinksMenu>> getMenusByTotalPrice()
    {
        List<DrinksMenu>? menus = await ctx.DrinksMenus.ToListAsync();
        menus.OrderBy(d => d.Drinks.Sum(p => p.Price));
        return menus;
    }
    
}