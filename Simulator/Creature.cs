using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature
{
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

    public string Go(Direction direction) => $"{Name} goes {direction.ToString().ToLower()}.";

    public string[] Go(Direction[] directions) 
    {
        var results = new string[directions.Length];
        for(int i = 0; i < directions.Length; i++) results[i] = Go(directions[i]);
        return results;
    }

    public string[] Go(string directionSeq) => Go(DirectionParser.Parse(directionSeq));

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

}
