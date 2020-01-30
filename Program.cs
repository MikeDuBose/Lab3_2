using System;
using System.Collections.Generic;

namespace DictionaryExample
{
    class Program
    {
        static int count = 1;
        static Dictionary<string, double> inventory = new Dictionary<string, double>();
        static Dictionary<string, double> shoppingCart = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            inventory["parmesan cheese"] = 3.99;
            inventory["ground beef"] = 3.99;
            inventory["noodle"] = 0.99;
            inventory["oregeno"] = 2.99;
            inventory["onions"] = 0.97;
            inventory["crushed tomatoes"] = 1.69;
            inventory["tomato paste"] = 0.79;
            inventory["garlic"] = 0.44;



            

            /*Console.WriteLine($"Is there ground beef?\t" + inventory.ContainsKey("Ground Beef"));

            if (inventory.ContainsKey("elderberry"))
            {
                Console.WriteLine(inventory["elderberry"]);
            }*/
            GetInput();
        }

        private static void GetInput()
        {
            Console.WriteLine("------Item-------------------Price----------");
            foreach (KeyValuePair<string, double> kvPair in inventory)
            {
                Console.WriteLine($"{count}: {kvPair.Key,-20}   :   {kvPair.Value,3}");
                count++;
            }
            Console.Write("Please type the name of the food you would like to add to your basket.  ");
            string input = Console.ReadLine();
            ValidateInput(input);
        }

        private static void ValidateInput(string input)
        {
            if (inventory.ContainsKey(input))
            {
                AddItem(input);
            }
            else
            {
                Console.WriteLine("That is not a valid input.  Please try again.  ");
                GetInput();
            }
        }

        private static void AddItem(string input)
        {
            shoppingCart[input] = inventory[input];
            double total = 0;
            Console.WriteLine();
            Console.WriteLine($"---------------Your shopping cart---------------");

            foreach (KeyValuePair<string, double> kvPair in shoppingCart)
            {
                Console.WriteLine($" {kvPair.Key,-20}   :   {kvPair.Value,3}");
                total += kvPair.Value;

            }
            Console.WriteLine("---------------TOTAL---------------");
            Console.WriteLine(total);
            Console.WriteLine("---------------AVERAGE---------------");
            Console.WriteLine((total/shoppingCart.Count));
            // Console.WriteLine($"You have chosen {input}" + " at " + value);
            AddAnother();
        }

        private static void AddAnother()
        {
            Console.WriteLine("Would you like to purchase another item? (Y/N): ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                GetInput();
            }
            else if (input == "n")
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("That input was invalid.  Please try again.");
                AddAnother();
            }
        }
    }
}
