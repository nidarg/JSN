using System;

namespace JsonInterface
{
    public class Program
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"D:\JuniorMind\JsonText.txt");
            Console.WriteLine(text);
            var pattern = new Value();
            Console.WriteLine(pattern.Match(text).RemainingText() == "" ? "Json Valid" : "Json Invalid");
            Console.WriteLine(pattern.Match(text).RemainingText());
            Console.Read();
        }
    }
}
