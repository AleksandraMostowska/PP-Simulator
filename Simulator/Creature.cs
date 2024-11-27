using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    private string _name = "Unknown";
    private int _level = 1;


    public string Name
    {
        get => _name;
        init
        {

            _name = Validator.Shortener(value, 3, 25, '#');
        }
    }
    public int Level
    {
        get => _level;
        init
        {

            _level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract int Power { get; }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract string Greeting();

    public abstract string Info { get; }

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException($"This creature is already on a map. It cannot be moved to a new map.");
        if (!map.Exist(position)) throw new ArgumentException("Non-existing position for this map.");

        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public void Go(Direction direction)
    {

        if (Map == null) throw new InvalidOperationException("Creature cannot move since it's not on the map!");

        var newPosition = Map.Next(Position, direction);

        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

}
