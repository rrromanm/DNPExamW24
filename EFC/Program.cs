using EFC;
using EFC.Entities;

class Program
{
    static void Main(string[] args)
    {
        MenuContext ctx = new MenuContext();
        DataAccess dataAccess = new DataAccess(ctx);
        
        dataAccess.CreateDrinksMenu(new DrinksMenu("Cocktails", true, new TimeOnly(19,0)));
        dataAccess.CreateDrinksMenu(new DrinksMenu("Mocktails", false, new TimeOnly(14,0)));
        dataAccess.CreateDrinksMenu(new DrinksMenu("Beers", true, new TimeOnly(9,0)));
        
        dataAccess.AddDrinksToMenu(1, new Drinks("Margarita", 10.0, 10.0, true));
        dataAccess.AddDrinksToMenu(1, new Drinks("Mojito", 10.0, 10.0, true));
        dataAccess.AddDrinksToMenu(1, new Drinks("Pina Colada", 10.0, 10.0, true));
        dataAccess.AddDrinksToMenu(2, new Drinks("Virgin Mojito", 5.0, 0.0, true));
        dataAccess.AddDrinksToMenu(2, new Drinks("Virgin Pina Colada", 5.0, 0.0, true));
        dataAccess.AddDrinksToMenu(3, new Drinks("Heineken", 5.0, 5.0, false));
        dataAccess.AddDrinksToMenu(3, new Drinks("Corona", 5.0, 5.0, false));
        
        Console.WriteLine("Drinks by filter:");
        List<Drinks> drinksByFilter = dataAccess.getDrinks(0.0, 5.0, true).Result;
        Console.WriteLine(drinksByFilter);
        
        Console.WriteLine("Drinks by price:");
        List<DrinksMenu> drinksByPrice = dataAccess.getMenusByTotalPrice().Result;
        Console.WriteLine(drinksByPrice);
        
        
        
    }
}