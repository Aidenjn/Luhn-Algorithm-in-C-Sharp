// Author: Aiden Nelson
// Date: 7/9/2018
// Description: Luhn's Algorithm implemented in C#.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnApplication
{
    class CardFunctions
    {
        public static int get_check_num(ulong num)
        {
            return Convert.ToInt32(num % 10);    // Get the last digit of the card number.
        }

        // Function: luhnCheck
        // Description: Runs Luhn's algorithm on a given number.
        // Uses Functions: get_check_num
        // Parameters: Number being tested.
        // Pre-Conditions: Positive integer input.
        // Post-Conditions: Output must be 0 or 1.
        // Return: 0 - passes algorithm, 1 - does not pass algorithm.
        public static int luhn_check(ulong num)
        {
            int sum = 0;
            int checkDigit = CardFunctions.get_check_num(num);
            int[] digits = num.ToString().Select(Convert.ToInt32).ToArray(); // Convert num into array of digits.

            digits.Reverse();
            for (int i = 1; i < digits.Length; i++)
            {
                digits[i] -= 48;
                if (i % 2 == 0)
                {
                    digits[i] *= 2;
                    if (digits[i] > 9)
                        digits[i] -= 9;
                }
                sum += digits[i];
            }

            // Number does not pass the test if the calculated check digit does not match the original last digit.
            if ((sum * 9) % 10 != checkDigit)
            {
                return 1;
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter card number: ");
            ulong num = Convert.ToUInt64(Console.ReadLine());

            Console.WriteLine("Result: " + CardFunctions.luhn_check(num));

            Console.ReadKey();
        }
    }
}