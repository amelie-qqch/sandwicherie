using System;
using System.Collections.Generic;
using System.IO;
using sandwicherie.models;
using Newtonsoft.Json;

namespace sandwicherie.core
{
    public class CardService
    {
        private readonly List<Sandwich> _sandwiches;
        private static CardService _instance;

        private CardService()
        {
            _sandwiches = JsonConvert.DeserializeObject<List<Sandwich>>(
                File.ReadAllText(@"../../assets/card.json")
            );
        }

        public static CardService GetInstance()
        {
            if (null == CardService._instance)
            {
                CardService._instance = new CardService();
            }

            return CardService._instance;
        }

        public Sandwich GetSandwichByName(string name)
        {
            Sandwich found = _sandwiches.Find(
                sandwich => sandwich.Name.Equals(name)
            );

            if (null == found)
            {
                throw new Exception("Sandwich not found");
            }
            
            return found;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu");
            foreach (var sandwich in _sandwiches)
            {
                Console.WriteLine(
                    "  - {0} {1}€", 
                    sandwich.Name, 
                    sandwich.Price
                );
            }
        }
    }
}