using System;
using System.Collections.Generic;
using System.Linq;
using sandwicherie.models;

namespace sandwicherie.core
{
    public class CommandParser
    {
        private readonly CardService _cardService;
        private static CommandParser _instance;

        private CommandParser()
        {
            _cardService = CardService.GetInstance();
        }

        public static CommandParser GetInstance()
        {
            if (CommandParser._instance == null)
            {
                CommandParser._instance = new CommandParser();
            }
            
            return CommandParser._instance;
        }

        public List<ParsedCommand> ParseCommand(string command)
        {
            string[] commandItems = command.Trim().Split(',');
            try
            {
                List<ParsedCommand> parsedCommands = new List<ParsedCommand>();
                foreach (var item in commandItems)
                {
                    if (!isCommandItemValid(item))
                    {
                        throw new Exception("Invalid item command");
                    }

                    ParsedCommand parsedCommand = Parse(item);
                    parsedCommands.Add(parsedCommand);
                }

                return parsedCommands;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        private bool isCommandItemValid(string commandItem)
        {
            return commandItem.Split(' ').Length > 2;
        }

        private ParsedCommand Parse(string item)
        {
            List<string> parts = item.Split(' ').ToList();
            string id = parts.First();
            parts.RemoveAt(0);
            string name = String.Join(" ", parts.ToArray());

            Sandwich sandwich = _cardService.GetSandwichByName(name);
            
            return new ParsedCommand(id, sandwich);
        }
    }
}