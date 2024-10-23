using System;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        var c1 = new Creature("Creature");
        Console.WriteLine(c1.Info());
        c1.SayHi();

        var c2 = new Creature("Another creature", 2);
        Console.WriteLine(c2.Info());
        c2.SayHi();

        var a1 = new Animals { Description = "Dogs" };
        Console.WriteLine(a1.Info());
    }
}
