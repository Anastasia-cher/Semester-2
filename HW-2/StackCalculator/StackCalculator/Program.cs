
using StackCalculator;

Console.WriteLine("Enter:");
Console.WriteLine("1 - use list-based stack");
Console.WriteLine("2 - use array-based stack");
Console.WriteLine("3 - to calculate postfix expression");

var input = Console.ReadLine();
if (!int.TryParse(input, out int choice))
{
    Console.WriteLine("Invalid input");
    return;
}

IStack? stack = choice switch
{
    1 => new StackList(),
    2 => new StackArray(),
    _ => null,
};

if (stack == null)
{
    Console.WriteLine("Invalid input");
    return;
}

Console.WriteLine("Enter postfix expression: ");
input = Console.ReadLine();
var (isCorrect, result) = StackCalculate.Calculate(input, stack);

if (!isCorrect)
{
    Console.WriteLine("Invalid postfix expression");
    return;
}

Console.WriteLine($"Result: {result}");