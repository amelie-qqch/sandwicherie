using System.Collections.Generic;

namespace sandwicherie.models
{
    public class Sandwich
    {
        public readonly string Name;
        public readonly float Price;
        public readonly List<Ingredient> Ingredients;
        

        public Sandwich(
            string name, 
            float price, 
            List<Ingredient> ingredients
        )
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}