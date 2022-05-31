namespace sandwicherie.models
{
    public class Ingredient
    {
        public readonly string name;
        public readonly float quantity;
        public readonly Unit unit;

        public Ingredient(string name, float quantity, Unit unit)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = unit;
        }
    }
}