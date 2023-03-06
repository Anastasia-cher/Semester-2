using System;
using System.Text;


namespace BWT
{
    internal class Program
    {
        //The method that prints the string
        //Param is string
        static void Print(string str)
        {
            char[] array = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write($"{array[i],3}");
            }
            Console.WriteLine();
        }

        //The method that rotates the string
        //Param is string
        //Rerturn is string
        static string Rotate(string str)
        {
            var newStr = new StringBuilder(str);
            for (int i = 0; i < newStr.Length - 1; i++)
            {
                newStr.Insert(newStr.Length, newStr[0]);
                newStr.Remove(0, 1);
            }
            return newStr.ToString();
        }

        //A method that converts a string using BWT
        //Param is string and its starting point
        //Return is string
        static string Encryption(string str, ref int point)
        {
            string temp = str;
            var strings = new string[temp.Length];
            strings[temp.Length - 1] = str;
            string resulte = null;

            for (int i = 0; i < temp.Length - 1; i++)
            {
                temp = Rotate(temp);
                strings[i] = temp;
            }
            Array.Sort(strings);

            for (int i = 0; i < strings.Length; i++)
            {
                resulte += strings[i][str.Length - 1];
                if (strings[i] == str)
                {
                    point = i;
                }
            }
            return resulte;
        }

        //A method that decrypts a string using BWT
        //Param is string and its point
        //Return is string
        static string Decryption(string encryptedStr, int point)
        {
            return "";
        }

        static bool Tests()
        {
            string str1 = "MJKSB.CNSKA.CNMFJ";
            int point1 = 0;
            string result1 = "ABKS..MMFSJNJCCKN";
            if (Encryption(str1, ref point1) != result1)
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


        static void Main(string[] args)
        {
            if (Tests())
            {
                Console.Write("Enter the line: ");
                string str = Console.ReadLine();
                int point = 0;
                string encryptedStr = Encryption(str, ref point);
                Console.Write($"Encrypted string:");
                Print(encryptedStr);
                Console.WriteLine($"Point: {point}");
                /*Decryption(encryptedStr, point);*/
            }
        }

    }
}