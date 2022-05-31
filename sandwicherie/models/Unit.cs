namespace sandwicherie.models
{
    public class Unit
    {
        public static readonly string Gram = "Gram";
        public static readonly string Unity = "Unity";
        public readonly string value;

        public Unit(string value)
        {
            this.value = value;
        }
    }
}