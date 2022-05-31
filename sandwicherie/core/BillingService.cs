using System;
using System.Collections.Generic;
using System.Linq;
using sandwicherie.models;

namespace sandwicherie.core
{
    public class BillingService
    {
        private readonly CardService _cardService;
        private static BillingService _instance;

        public BillingService()
        {
            _cardService = CardService.GetInstance();
        }

        public static BillingService GetInstance()
        {
            if (null == BillingService._instance)
            {
                BillingService._instance = new BillingService();
            }

            return BillingService._instance;
        }

        public string Editbill(List<ParsedCommand> commands)
        {
            float totalPrice = 0f;
            string bill = "";

            foreach (var parsedCommand in commands)
            {
                totalPrice += parsedCommand.Sandwich.Price;
                bill += EditBillSandwich(parsedCommand.Id, parsedCommand.Sandwich);
            }

            return String.Format(
                "{0} Prix total: {1}",
                bill,
                totalPrice
            );
        }

        private string EditBillSandwich(string id, Sandwich sandwich)
        {
            string sandwichLine = String.Format("{0} {1}\n", id, sandwich.Name);
            List<string> ingredientsLine = new List<string>();

            foreach (var ingredient in sandwich.Ingredients)
            {
                ingredientsLine.Add(EditBillIngredient(ingredient));
            }

            return sandwichLine + String.Join("", ingredientsLine);
        }

        private string EditBillIngredient(Ingredient ingredient)
        {
            if (ingredient.unit.value == Unit.Gram)
            {
                return String.Format(
                    "\t{0}g de {1}\n",
                    ingredient.quantity,
                    ingredient.name
                );
            }
            
            return String.Format(
                "\t{0} {1}\n",
                ingredient.quantity,
                ingredient.name
            );
        }
    }
}