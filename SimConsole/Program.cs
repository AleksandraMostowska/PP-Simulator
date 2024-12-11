using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = Encoding.UTF8;

        //BigBounceMap map = new BigBounceMap(8, 6);

        ////SmallSquareMap map = new(5);
        ////List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        ////List<Point> points = [new(2, 2), new(3, 1)];
        ////string moves = "dlrludl";


        ////SmallTorusMap map = new(8, 6);

        //List<IMappable> creatures2 = new()
        //{
        //    new Elf("Elandor"),
        //    new Orc("Gorbag"),
        //    new Animals { Description = "Rabbits", Size = 3 },
        //    new Birds { Description = "Eagles", Size = 2, CanFly = true },
        //    new Birds { Description = "Ostriches", Size = 2, CanFly = false }
        //};

        //List<Point> points2 = new()
        //{
        //    new Point(2, 3),
        //    new Point(4, 4), 
        //    new Point(1, 1), 
        //    new Point(5, 5), 
        //    new Point(0, 0) 
        //};

        //string moves2 = "drrluud";




        //Simulation simulation = new Simulation(map, creatures2, points2, moves2);
        //MapVisualizer mapVisualizer = new MapVisualizer(map);


        //Console.WriteLine("SIMULATION!");
        //Console.WriteLine();
        //Console.WriteLine("Starting positions:");

        //mapVisualizer.Draw();
        //var turn = 0;

        ////while (!simulation.Finished)
        ////{
        ////    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
        ////    Console.WriteLine($"Turn {turn}");
        ////    Console.WriteLine($"{simulation.CurrentMappable} moves {simulation.CurrentMoveName}");

        ////    if (key.Key == ConsoleKey.Spacebar)
        ////    {
        ////        simulation.Turn();
        ////        mapVisualizer.Draw();
        ////        turn++;
        ////    }
        ////}

        //var history = new SimulationHistory(simulation);
        ////foreach (var log in history.TurnLogs)
        ////{
        ////    Console.WriteLine($"Turn:{turn} {log.Mappable} moved {log.Move}");
        ////}


        //var log5 = history.TurnLogs[5];
        //Console.WriteLine(history._simulation.Moves);
        //Console.WriteLine($"Turn: 5 - {log5.Mappable} moved {log5.Move}");
        //foreach (var symbol in log5.Symbols)
        //{
        //    Console.WriteLine($"Position: {symbol.Key}, Symbol: {symbol.Value}");
        //}




        Console.OutputEncoding = Encoding.UTF8;

        BigBounceMap map = new BigBounceMap(8, 6);

        List<IMappable> creatures2 = new()
            {
                new Elf("Elandor"),
                new Orc("Gorbag"),
                new Animals { Description = "Rabbits", Size = 3 },
                new Birds { Description = "Eagles", Size = 2, CanFly = true },
                new Birds { Description = "Ostriches", Size = 2, CanFly = false }
            };

        List<Point> points2 = new()
            {
                new Point(2, 3),
                new Point(4, 4),
                new Point(1, 1),
                new Point(5, 5),
                new Point(0, 0)
            };

        string moves2 = "drrluud";

        Simulation simulation = new Simulation(map, creatures2, points2, moves2);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine();
        Console.WriteLine("Starting positions:");
        mapVisualizer.Draw();

        var turn = 0;

        //while (!simulation.Finished)
        //{
        //    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
        //    Console.WriteLine($"Turn {turn}");
        //    Console.WriteLine($"{simulation.CurrentMappable} moves {simulation.CurrentMoveName}");

        //    if (key.Key == ConsoleKey.Spacebar)
        //    {
        //        simulation.Turn();
        //        mapVisualizer.Draw();
        //        turn++;
        //    }
        //}
        var history = new SimulationHistory(simulation);
        var logVisualizer = new LogVisulizer(history);

        logVisualizer.Draw(5);
        logVisualizer.Draw(3);


    }
}
