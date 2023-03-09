using System.Text;
// The method that prints the string
// Param is string
void Print(string str)
{
    char[] array = str.ToCharArray();
    for (int i = 0; i < str.Length; i++)
    {
        Console.Write($"{array[i],3}");
    }
    Console.WriteLine();
}

// The method that rotates the string
// Param is string
// Rerturn rotated string
string Rotate(string str)
{
    var newStr = new StringBuilder(str);
    for (int i = 0; i < newStr.Length - 1; i++)
    {
        newStr.Insert(newStr.Length, newStr[0]);
        newStr.Remove(0, 1);
    }
    return newStr.ToString();
}

// A method that converts a string using BWT
// Param is string and its starting point
// Return is string
string Encryption(string str, out int point)
{
    string temp = str;
    var table = new string[temp.Length];
    table[temp.Length - 1] = str;
    string? resulte = null;
    point = 0;

    for (int i = 0; i < temp.Length - 1; i++)
    {
        temp = Rotate(temp);
        table[i] = temp;
    }
    Array.Sort(table);

    for (int i = 0; i < table.Length; i++)
    {
        resulte += table[i][str.Length - 1];
        if (table[i] == str)
        {
            point = i;
        }
    }
    return resulte;
}

// A method that decrypts a string using BWT
// Param is string and its point
// Return is string
string Decryption(string encryptedStr, int point)
{
    List<string> temp = new();
    for (int i = 0; i < encryptedStr.Length; i++)
    {
        temp.Add("" + encryptedStr[i]);
    }
    while (temp[0].Length != encryptedStr.Length)
    {
        temp.Sort();
        for (int i = 0; i < encryptedStr.Length; i++)
        {
            temp[i] = encryptedStr[i] + temp[i];
        }
        temp.Sort();
    }
    return temp[point];
}

bool Tests()
{
    string str1 = "MJKSB.CNSKA.CNMFJ";
    int point1 = 0;
    string result1 = "ABKS..MMFSJNJCCKN";
    if (Encryption(str1, out point1) != result1)
    {
        Console.WriteLine("Encryption error");
        return false;
    }

    string str2 = "ABKS..MMFSJNJCCKN";
    int point2 = 12;
    str2 = Decryption(str2, point2);
    string result2 = "MJKSB.CNSKA.CNMFJ";
    if (str2 != result2)
    {
        Console.WriteLine("Decryption error");
        return false;
    }
    return true;
}

if (Tests())
{
    Console.Write("Enter the line: ");
    string str = Console.ReadLine();
    int point = 0;
    string encryptedStr = Encryption(str, out point);
    Console.Write($"Encrypted string:");
    Print(encryptedStr);
    Console.WriteLine($"Point: {point}");
    string decryptedStr = Decryption(encryptedStr, point);
    Console.Write($"Decrypted string:");
    Print(decryptedStr);
}
