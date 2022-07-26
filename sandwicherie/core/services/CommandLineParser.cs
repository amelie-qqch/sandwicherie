using System;
using System.Collections.Generic;
using System.Linq;
using sandwicherie.core.interfaces;
using sandwicherie.models;

namespace sandwicherie.services.core
{
    public class CommandLineParser: IParser
    {
        private readonly CardService _cardService;

        public CommandLineParser()
        {
            _cardService = CardService.GetInstance();
        }

        public ParsedCommand ParseCommand(string command)
        {
            var commandItems = command.Trim().Split(',');
            try
            {
                var parsedCommands = new ParsedCommand();
                foreach (var item in commandItems)
                {
                    if (!IsCommandItemValid(item))
                    {
                        throw new Exception("Invalid item command");
                    }

                    var parsedCommand = Parse(item);
                    parsedCommands.AddOrAppend(parsedCommand);
                }

                return parsedCommands;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        private static bool IsCommandItemValid(string commandItem)
        {
            return commandItem.Split(' ').Length > 2;
        }

        private ItemCommand Parse(string item)
        {
            
            var parts = item.Trim().Split(' ').ToList();
            var id = int.Parse(parts.First());
            parts.RemoveAt(0);
            var name = string.Join(" ", parts.ToArray());

            var sandwich = _cardService.GetSandwichByName(name);
            
            return ItemCommand.Of(id, sandwich);
        }
    }
}