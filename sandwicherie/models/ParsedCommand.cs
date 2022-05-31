namespace sandwicherie.models
{
    public class ParsedCommand
    {
        public readonly string Id;
        public readonly Sandwich Sandwich;

        public ParsedCommand(string id, Sandwich sandwich)
        {
            Id = id;
            Sandwich = sandwich;
        }
    }
}