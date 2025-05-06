using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Skriv inn et romertall mellom I og LXXX (eller skriv 'avslutt' for å avslutte):");

        while (true)
        {
            Console.Write("Romertall: ");
            string input = Console.ReadLine().ToUpper();

            if (input == "AVSLUTT") break;

            int resultat = RomertallTilTall(input);

            if (resultat > 0 && resultat <= 80)
            {
                Console.WriteLine($"Vanlig tall: {resultat}\n");
            }
            else
            {
                Console.WriteLine("Ugyldig romertall (kun I til LXXX er støttet, altså opp til 80).\n");
            }
        }
    }

    static int RomertallTilTall(string romertall)
    {
        var romerskKart = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50}
        };

        int next = 0;
        int current = 0;

        for (int i = romertall.Length - 1; i >= 0; i--)
        {
            char tegn = romertall[i];

            if (!romerskKart.ContainsKey(tegn))
                return -1; // Ugyldig tegn

            int verdi = romerskKart[tegn];

            if (verdi < current)
                next -= verdi;
            else
            {
                next += verdi;
                current = verdi;
            }
        }

        return next;
    }
}