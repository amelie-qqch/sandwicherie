using System;
using System.Collections.Generic;
using sandwicherie.core.interfaces;
using sandwicherie.models;
using sandwicherie.services.core;

namespace sandwicherie
{
    internal class Program
    {
        private static readonly IParser Parser = new CommandLineParser();
        private static readonly BillingService BillingService = BillingService.GetInstance();
        private static readonly CardService CardService = CardService.GetInstance();
        public static void Main(string[] args)
        {
            while (true)
            {
                CardService.DisplayMenu();
                Console.WriteLine("Enter your command :");
                
                var command = Console.ReadLine();

                try
                {
                    var parsedCommands = Parser.ParseCommand(command);
                    Console.WriteLine(BillingService.EditBill(parsedCommands));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

        }
    }
}