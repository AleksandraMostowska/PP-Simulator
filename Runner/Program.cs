using Simulator.Maps;
using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Lab5a();

        Lab5b();

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

    static void Lab5b()
    {
        try
        {
            Console.WriteLine("\n===================================== [CREATE MAP] =====================================");
            var map5 = new SmallSquareMap(5);
            Console.WriteLine(map5.Size);

            var map20 = new SmallSquareMap(20);
            Console.WriteLine(map20.Size);

            try
            {
                var map21 = new SmallSquareMap(21);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}"); 
            }

            Console.WriteLine("\n===================================== [POINT BELONGING TO THE MAP] =====================================");
            var pointInside = new Point(3, 3);
            Console.WriteLine($"Point {pointInside} inside map 5x5? {map5.Exist(pointInside)}");


            var pointOutside = new Point(6, 6);
            Console.WriteLine($"Point {pointOutside} inside map 5x5? {map5.Exist(pointOutside)}");

            var startPoint = new Point(2, 2);
            var newPointUp = map5.Next(startPoint, Direction.Up);
            var newPointRight = map5.Next(startPoint, Direction.Right);
            var newPointDown = map5.Next(startPoint, Direction.Down);
            var newPointLeft = map5.Next(startPoint, Direction.Left);

            Console.WriteLine("\n===================================== [MOVING POINT] =====================================");
            Console.WriteLine($"Start point: {startPoint},\nUp: {newPointUp},\nRight: {newPointRight},\nDown: {newPointDown},\nLeft: {newPointLeft}");


            var outsideMove = new Point(4, 4);
            var outsideMove2 = new Point(0, 0);
            var movedOut = map5.Next(outsideMove, Direction.Up);
            Console.WriteLine($"Point {outsideMove} after UP: {movedOut}");
            movedOut = map5.Next(outsideMove2, Direction.Left);
            Console.WriteLine($"Point {outsideMove2} after LEFT: {movedOut}");

            var movedDiagonal = map5.NextDiagonal(startPoint, Direction.Up);
            Console.WriteLine($"Point {startPoint} after UP-DIAGONAL: {movedDiagonal}");
            movedDiagonal = map5.NextDiagonal(startPoint, Direction.Right);
            Console.WriteLine($"Point {startPoint} after RIGHT-DIAGONAL: {movedDiagonal}");
            movedDiagonal = map5.NextDiagonal(outsideMove2, Direction.Down);
            Console.WriteLine($"Point {outsideMove2} after DOWN-DIAGONAL: {movedDiagonal}");

            var movedDiagonalOut = map5.NextDiagonal(outsideMove, Direction.Up);
            Console.WriteLine($"Point {outsideMove} after UP-DIAGONAL: {movedDiagonalOut}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex.Message}");
        }

    }
}