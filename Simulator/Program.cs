using System;
using System.Diagnostics;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {

        Lab4a();

        //checkSpeed();
    }

    static void checkSpeed()
    {
        var size = 100000000;
        var randomNumbers = new int[size];
        var intNumbers = new int[size];
        var objectNumbers = new object[size];
        var random = new Random();
        var sw = new Stopwatch();

        for (int i = 0; i < size; i++)
        {
            randomNumbers[i] = random.Next();
        }

        sw.Start();
        for (int i = 0; i < size; i++)
        {
            intNumbers[i] = randomNumbers[i];
        }
        sw.Stop();
        var res1 = sw.ElapsedMilliseconds;

        sw.Restart();
        for (int i = 0; i < size; i++)
        {
            objectNumbers[i] = randomNumbers[i];
        }
        sw.Stop();
        var res2 = sw.ElapsedMilliseconds;

        Console.WriteLine(res1);
        Console.WriteLine(res2);
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
            o,
            e,
            new Orc("Morgash", 3, 8),
            new Elf("Elandor", 5, 3)
        };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

}
