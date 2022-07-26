using System.Collections.Generic;

namespace sandwicherie.models
{
    public class ParsedCommand
    {
        public List<ItemCommand> items;

        public ParsedCommand()
        {
            items = new List<ItemCommand>();
        }

        public void AddOrAppend(ItemCommand itemCommand)
        {
            var index = items.FindIndex(command => command.Sandwich.Equals(itemCommand.Sandwich));
            if (index != -1)
            {
                items[index].Quantity += 1;
                return;
            }
            items.Add(itemCommand);
        }
    }
}