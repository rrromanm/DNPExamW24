using System.ComponentModel.DataAnnotations;
using EFC.Context;
using EFC.Entities;

class Program
{
    static async Task Main(string[] args)
    {
        MenuContext ctx = new MenuContext();
        DataAccess dataAccess = new DataAccess(ctx);

        // await dataAccess.CreateMenuAsync(new DrinksMenu("Cocktails", true, new TimeOnly(17, 0, 0)));
        // await dataAccess.CreateMenuAsync(new DrinksMenu("Mocktails", false, new TimeOnly(9, 0, 0)));
        // await dataAccess.CreateMenuAsync(new DrinksMenu("Beers", true, new TimeOnly(12, 0, 0)));
        
        // await dataAccess.AddDrinkToMenuAsync(1, new Drink("Mojito", 5.99, 7, true));
        // await dataAccess.AddDrinkToMenuAsync(1, new Drink("Pina Colada", 6.99, 5, true));
        // await dataAccess.AddDrinkToMenuAsync(2, new Drink("Virgin Mojito", 3.99, 0, true));
        // await dataAccess.AddDrinkToMenuAsync(2, new Drink("Virgin Pina Colada", 4.99, 0, true));
        // await dataAccess.AddDrinkToMenuAsync(3, new Drink("Heineken", 3.99, 5, false));
        // await dataAccess.AddDrinkToMenuAsync(3, new Drink("Corona", 4.99, 5, false));

        var filter = await dataAccess.GetDrinksAsync(5, null, true);

        if (filter.Any())
        {
            foreach (var drink in filter)
            {
                Console.WriteLine(drink);
            }
        }
        else
        {
            Console.WriteLine("No drinks found matching the filter criteria.");
        }
        
        Console.WriteLine("Drinks Menu Ordered By Total Price:");
        var orderedMenus = await dataAccess.GetDrinksMenuOrderedByTotalPriceAsync();
        foreach (var drinksMenu in orderedMenus)
        {
            Console.WriteLine(drinksMenu);
        }
    }
}