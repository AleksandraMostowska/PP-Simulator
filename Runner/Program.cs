using Simulator.Maps;
using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using System.Text;

namespace Simulator;

public class Program
{
    static void Main(string[] args)
    {

        //Lab8();

        //Lab7();

        //Lab5a();

        //Lab5b();

        //Lab4a();

        //Lab4b();

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
        //o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            //o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        //e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            //e.SayHi();
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


        Creature c = new Elf("Elandor", 5, 3);
        Console.WriteLine(c);  // ELF: Elandor [5][3]
    }

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void Lab5a()
    {
        try
        {
            var r1 = new Rectangle(3, 5, 1, 1);
            Console.WriteLine(r1);

            var r2 = new Rectangle(1, 5, 3, 1);
            Console.WriteLine(r2);

            try
            {
                var r3 = new Rectangle(1, 1, 1, 5);
                Console.WriteLine(r3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            var p1 = new Point(1, 1);
            var p2 = new Point(3, 5);
            var r4 = new Rectangle(p1, p2);
            Console.WriteLine(r4);

            var pointInside = new Point(2, 3);
            var pointOutside = new Point(4, 6);
            var pointOnEdge = new Point(1, 5);
            var pointOnEdge2 = new Point(3, 1);

            Console.WriteLine($"Point {pointInside} in rectangle? {r4.Contains(pointInside)}");
            Console.WriteLine($"Point {pointOutside} in rectangle? {r4.Contains(pointOutside)}");
            Console.WriteLine($"Point {pointOnEdge} in rectangle? {r4.Contains(pointOnEdge)}");
            Console.WriteLine($"Point {pointOnEdge2} in rectangle? {r4.Contains(pointOnEdge2)}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex.Message}");
        }
    }


    static void Lab7()
    {
        var squareMap = new SmallSquareMap(5);
        var torusMap = new SmallTorusMap(5, 5);

        var elf = new Elf("Elf1", 3, 5);
        var elf2 = new Elf("Elf1", 1, 4);
        var orc = new Orc("Orc1", 2, 4);

        elf.InitMapAndPosition(squareMap, new Point(4, 4));
        elf2.InitMapAndPosition(squareMap, new Point(3, 3));
        //elf2.InitMapAndPosition(torusMap, new Point(3, 3));
        orc.InitMapAndPosition(torusMap, new Point(0, 0));

        Console.WriteLine($"Initial Position on Square Map (Elf): {elf.Position}");
        Console.WriteLine($"Initial Position on Torus Map (Orc): {orc.Position}");

        Console.WriteLine(elf.Go(Direction.Up));
        Console.WriteLine(elf.Go(Direction.Right));

        Console.WriteLine(orc.Go(Direction.Right));
        Console.WriteLine(orc.Go(Direction.Down));

        Console.WriteLine($"New Position on Square Map (Elf): {elf.Position}");
        Console.WriteLine($"New Position on Torus Map (Orc): {orc.Position}");

        Console.WriteLine("Square Map Creatures at (2,2):");
        var squareCreatures = squareMap.At(2, 2);
        Console.WriteLine($"Number of creatures at (2, 2) on Square Map: {squareCreatures?.Count ?? 0}");

        Console.WriteLine("Square Map Creatures at (3,3):");
        var squareCreatures2 = squareMap.At(3, 3);
        Console.WriteLine($"Number of creatures at (3, 3) on Square Map: {squareCreatures2?.Count ?? 0}");

        Console.WriteLine("Torus Map Creatures at (0,0):");
        var torusCreatures = torusMap.At(0, 0);
        Console.WriteLine($"Number of creatures at (0, 0) on Torus Map: {torusCreatures?.Count ?? 0}");

        Console.WriteLine("Torus Map Creatures at (1,4):");
        var torusCreatures2 = torusMap.At(1, 4);
        Console.WriteLine($"Number of creatures at (1, 4) on Torus Map: {torusCreatures2?.Count ?? 0}");
    }

    //public static void Lab8()
    //{
    //    Console.OutputEncoding = Encoding.UTF8;

    //    SmallSquareMap map = new SmallSquareMap(5);
    //    List<Creature> creatures = new List<Creature>
    //{
    //    new Orc("Gorbag"),
    //    new Elf("Elandor")
    //};
    //    List<Point> points = new List<Point>
    //{
    //    new Point(2, 2),
    //    new Point(3, 1)
    //};
    //    string moves = "dlrludl";

    //    Simulation simulation = new Simulation(map, creatures, points, moves);
    //    MapVisualizer mapVisualizer = new MapVisualizer(map);


    //    Console.WriteLine("SIMULATION!");
    //    Console.WriteLine();
    //    Console.WriteLine("Starting positions:");

    //    mapVisualizer.Draw();
    //    var turn = 1;

    //    while (!simulation.Finished)
    //    {
    //        ConsoleKeyInfo key = Console.ReadKey(intercept: true);
    //        Console.WriteLine($"Turn {turn}");
    //        Console.WriteLine($"{simulation.CurrentCreature.Info} moves {simulation.CurrentMoveName}");

    //        if (key.Key == ConsoleKey.Spacebar)
    //        {
    //            simulation.Turn();

    //            mapVisualizer.Draw();
    //            turn++;
    //        }
    //    }
    //}
}