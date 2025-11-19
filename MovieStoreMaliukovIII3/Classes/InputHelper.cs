using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMaliukovIII3.Classes
{
    public static class InputHelper
    {
        public static string CheckString(string prompt)
        {
            string input;
            Console.Write(prompt);
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                Console.Write("Input cannot be empty. Please try again: ");
            }
            return input;
        }
        public static int CheckInt(string prompt, int min, int max)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return value;
        }
        public static double CheckDouble(string prompt, double min, double max)
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }
            return value;
        }
        public static bool CheckBool(string prompt)
        {
            Console.Write(prompt);
            string input;
            while (true)
            {
                input = Console.ReadLine().ToLower();
                if (input == "yes" || input == "y" || input == "true" || input == "1")
                {
                    return true;
                }
                else if (input == "no" || input == "n" || input == "false" || input == "0")
                {
                    return false;
                }
                else
                {
                    Console.Write("Invalid input. Please enter yes or no: ");
                }
            }
        }
    }
}
