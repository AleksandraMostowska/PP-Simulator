using System;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Starting Simulator!\n");

        //var c1 = new Creature("Creature");
        //Console.WriteLine(c1.Info());
        //c1.SayHi();

        //var c2 = new Creature("Another creature", 2);
        //Console.WriteLine(c2.Info());
        //c2.SayHi();

        //var a1 = new Animals { Description = "Dogs" };
        //Console.WriteLine(a1.Info());

        Lab3a();
    }

    static void Lab3a()
    {
        Creature c = new() { Name = "   Shrek    ", Level = 20 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  ", -5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  donkey ") { Level = 7 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("Puss in Boots – a clever and brave cat.");
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("a                            troll name", 5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);

    }
}
