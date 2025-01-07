using EFC.Entities;

namespace EFC.Context;

public class DataAccess
{
    private readonly MenuContext ctx;
    
    public DataAccess(MenuContext ctx)
    {
        this.ctx = ctx;
    }
    
    public async Task<DrinksMenu> CreateMenuAsync(DrinksMenu menu)
    {
        await ctx.DrinksMenus.AddAsync(menu);
        await ctx.SaveChangesAsync();
        return menu;
    }
    
    public async Task AddDrinkToMenuAsync(int menuId, Drink drink)
    {
        var menu = ctx.DrinksMenus.FirstOrDefault(p => p.Id == menuId);
        if (menu == null)
        {
            throw new ArgumentException("Menu not found");
        }
        drink.MenuId = menuId;
        await ctx.Drinks.AddAsync(drink);
        await ctx.SaveChangesAsync();
    }
    
    public async Task<List<Drink>> GetDrinksAsync(double? minAlcoholPercentage, double? maxAlcoholPercentage, bool? hasUmbrella)
    {
        var filteredDrinks = ctx.Drinks.Where(d =>
            (!minAlcoholPercentage.HasValue || d.AlcoholPercentage >= minAlcoholPercentage)
            && (!maxAlcoholPercentage.HasValue || d.AlcoholPercentage <= maxAlcoholPercentage)
            && (!hasUmbrella.HasValue || d.IncludesUmbrella == hasUmbrella)).ToList();
        return filteredDrinks;
    }
    
    public async Task<List<DrinksMenu>> GetDrinksMenuOrderedByTotalPriceAsync()
    {
        List<DrinksMenu> menus = ctx.DrinksMenus.ToList();
        menus.OrderBy(p => p.Drinks.Sum(p => p.Price));
        return menus;
    }
}