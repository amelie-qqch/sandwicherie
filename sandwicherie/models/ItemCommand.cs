namespace sandwicherie.models
{
    public class ItemCommand
    {
        public int Quantity;
        public readonly Sandwich Sandwich;

        private ItemCommand(int quantity, Sandwich sandwich)
        {
            Quantity = quantity;
            Sandwich = sandwich;
        }

        public static ItemCommand Of(int id, Sandwich sandwich)
        {
            return new ItemCommand(id, sandwich);
        }
    }
}