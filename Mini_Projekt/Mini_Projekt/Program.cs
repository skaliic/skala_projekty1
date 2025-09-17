using system;

using System;

class Program
{
    static void Main()
    {
        string[] moznosti = { "kámen", "nůžky", "papír" };
        Random rnd = new Random();

        Console.Write("Zadej kámen, nůžky nebo papír: ");
        string hrac = Console.ReadLine().ToLower();

        string pocitac = moznosti[rnd.Next(moznosti.Length)];
        Console.WriteLine($"Počítač zvolil: {pocitac}");

        if (hrac == pocitac)
        {
            Console.WriteLine("Remíza!");
        }
        else if ((hrac == "kámen" && pocitac == "nůžky") ||
                 (hrac == "nůžky" && pocitac == "papír") ||
                 (hrac == "papír" && pocitac == "kámen"))
        {
            Console.WriteLine("Vyhrál jsi!");
        }
        else
        {
            Console.WriteLine("Prohrál jsi!");
        }

        Console.WriteLine("Stiskni libovolnou klávesu proghg ukončení...");
        Console.ReadKey();
    }
}

