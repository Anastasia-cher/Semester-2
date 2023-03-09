using System;

namespace StackCalculator;

internal class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Enter:");
        Console.WriteLine("1 - use list-based stack");
        Console.WriteLine("2 - use array-based stack");
        Console.WriteLine("To calculate postfix expression");

        var input = Console.ReadLine();
        if (!int.TryParse(input, out int choice))
        {
            Console.WriteLine("Invalid input");
            return;
        }
    }
}
