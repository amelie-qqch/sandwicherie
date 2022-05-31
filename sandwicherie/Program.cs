using System;
using System.Collections.Generic;
using sandwicherie.core;
using sandwicherie.models;

namespace sandwicherie
{
    internal class Program
    {
        private static CommandParser _commandParser = CommandParser.GetInstance();
        private static BillingService _billingService = BillingService.GetInstance();
        private static CardService _cardService = CardService.GetInstance();
        public static void Main(string[] args)
        {
            while (true)
            {
                _cardService.DisplayMenu();
                Console.WriteLine("Enter your command :");
                
                string command = Console.ReadLine();

                try
                {
                    List<ParsedCommand> parsedCommands = _commandParser.ParseCommand(command);
                    Console.WriteLine(_billingService.Editbill(parsedCommands));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

        }
    }
}