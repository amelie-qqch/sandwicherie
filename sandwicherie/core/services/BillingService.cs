using System;
using System.Collections.Generic;
using System.Linq;
using sandwicherie.models;

namespace sandwicherie.services.core
{
    public class BillingService
    {
        private readonly CardService _cardService;
        private static BillingService _instance;

        private BillingService()
        {
            _cardService = CardService.GetInstance();
        }

        public static BillingService GetInstance()
        {
            return BillingService._instance ?? (BillingService._instance = new BillingService());
        }

        public string EditBill(ParsedCommand commands)
        {
            var totalPrice = 0f;
            var bill = "";

            foreach (var parsedCommand in commands.items)
            {
                totalPrice += parsedCommand.Sandwich.Price * parsedCommand.Quantity;
                bill += EditBillSandwich(parsedCommand.Quantity, parsedCommand.Sandwich);
            }

            return $"{bill} Prix total: {totalPrice}";
        }

        private string EditBillSandwich(int id, Sandwich sandwich)
        {
            var sandwichLine = $"{id} {sandwich.Name}\n";
            var ingredientsLine = sandwich.Ingredients.Select(EditBillIngredient).ToList();

            return sandwichLine + string.Join("", ingredientsLine);
        }

        private string EditBillIngredient(Ingredient ingredient)
        {
            return string.Format(ingredient.unit.value == Unit.Gram ? "\t{0}g de {1}\n" : "\t{0} {1}\n", ingredient.quantity, ingredient.name);
        }
    }
}