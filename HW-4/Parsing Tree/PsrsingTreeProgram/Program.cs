using ParsingTree;

var newTree = new Tree();
string newFile = @"C:\Users\Анастасия\Documents\GitHub\Semester-2\HW-4\File.txt";
var file = new StreamReader(newFile);
string arithmeticExpression = file.ReadToEnd();
Console.WriteLine($"\nArithmetic expression: {newTree.PrintParsingTree(arithmeticExpression)}");
Console.WriteLine($"Result: {newTree.CalculateArithmeticExpression(arithmeticExpression)}");