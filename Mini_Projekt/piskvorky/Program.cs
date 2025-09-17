using System;

namespace Piskvorky
{
    class Program
    {
        static char[,] hraci_pole = new char[3, 3];
        static char aktualni_hrac = 'X';
        static bool hra_bezi = true;

        static void Main(string[] args)
        {
            Console.WriteLine("=== PIŠKVORKY ===");
            Console.WriteLine("Hráč X začína!");
            Console.WriteLine();

            InitializujPole();

            while (hra_bezi)
            {
                VykresliBoardPole();
                Console.WriteLine($"Na řadě je hráč: {aktualni_hrac}");
                Console.Write("Zadej pozici (řádek 1-3, sloupec 1-3) oddělené mezerou: ");

                string vstup = Console.ReadLine();
                if (ZpracujTah(vstup))
                {
                    if (ZkontrolujVitezstvi())
                    {
                        VykresliBoardPole();
                        Console.WriteLine($"🎉 Vyhrál hráč {aktualni_hrac}! 🎉");
                        hra_bezi = false;
                    }
                    else if (JeRemiza())
                    {
                        VykresliBoardPole();
                        Console.WriteLine("🤝 Remíza! Nikdo nevyhrál.");
                        hra_bezi = false;
                    }
                    else
                    {
                        PresunNaDalsihoHrace();
                    }
                }
                else
                {
                    Console.WriteLine("❌ Neplatný tah! Zkus to znovu.");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Stiskni libovolnou klávesu pro ukončení...");
            Console.ReadKey();
        }

        static void InitializujPole()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    hraci_pole[i, j] = ' ';
                }
            }
        }

        static void VykresliBoardPole()
        {
            Console.Clear();
            Console.WriteLine("=== PIŠKVORKY ===");
            Console.WriteLine();
            Console.WriteLine("   1   2   3");
            Console.WriteLine("1  {0} | {1} | {2}", hraci_pole[0, 0], hraci_pole[0, 1], hraci_pole[0, 2]);
            Console.WriteLine("  -----------");
            Console.WriteLine("2  {0} | {1} | {2}", hraci_pole[1, 0], hraci_pole[1, 1], hraci_pole[1, 2]);
            Console.WriteLine("  -----------");
            Console.WriteLine("3  {0} | {1} | {2}", hraci_pole[2, 0], hraci_pole[2, 1], hraci_pole[2, 2]);
            Console.WriteLine();
        }

        static bool ZpracujTah(string vstup)
        {
            try
            {
                string[] casti = vstup.Split(' ');
                if (casti.Length != 2)
                    return false;

                int radek = int.Parse(casti[0]) - 1;
                int sloupec = int.Parse(casti[1]) - 1;

                if (radek < 0 || radek > 2 || sloupec < 0 || sloupec > 2)
                    return false;

                if (hraci_pole[radek, sloupec] != ' ')
                    return false;

                hraci_pole[radek, sloupec] = aktualni_hrac;
                return true;
            }
            catch
            {
                return false;
            }
        }

        static bool ZkontrolujVitezstvi()
        {
            // Kontrola řádků
            for (int i = 0; i < 3; i++)
            {
                if (hraci_pole[i, 0] == aktualni_hrac &&
                    hraci_pole[i, 1] == aktualni_hrac &&
                    hraci_pole[i, 2] == aktualni_hrac)
                    return true;
            }

            // Kontrola sloupců
            for (int j = 0; j < 3; j++)
            {
                if (hraci_pole[0, j] == aktualni_hrac &&
                    hraci_pole[1, j] == aktualni_hrac &&
                    hraci_pole[2, j] == aktualni_hrac)
                    return true;
            }

            // Kontrola úhlopříček
            if (hraci_pole[0, 0] == aktualni_hrac &&
                hraci_pole[1, 1] == aktualni_hrac &&
                hraci_pole[2, 2] == aktualni_hrac)
                return true;

            if (hraci_pole[0, 2] == aktualni_hrac &&
                hraci_pole[1, 1] == aktualni_hrac &&
                hraci_pole[2, 0] == aktualni_hrac)
                return true;

            return false;
        }

        static bool JeRemiza()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (hraci_pole[i, j] == ' ')
                        return false;
                }
            }
            return true;
        }

        static void PresunNaDalsihoHrace()
        {
            aktualni_hrac = (aktualni_hrac == 'X') ? 'O' : 'X';
        }
    }

