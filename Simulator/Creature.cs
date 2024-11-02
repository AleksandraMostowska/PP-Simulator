﻿using System;
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

            //value = value.Trim();

            //if (value.Length > 25) value = value[..25].Trim();

            //if (value.Length < 3) value = value.PadRight(3, '#');

            //if (char.IsLower(value[0])) value = char.ToUpper(value[0]) + value[1..];

            //_name = value;
        }
    }
    public int Level
    {
        get => _level;
        init
        {
            //_level = value < 1 ? 1 : value > 10 ? 10 : value;

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

    public abstract void SayHi();

    public abstract string Info { get; }

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

    public void Go(Direction direction) => Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");

    public void Go(Direction[] directions) 
    {
        foreach (var d in directions)
        {
            Go(d);
        }
    }

    public void Go(string directionSeq) => Go(DirectionParser.Parse(directionSeq));

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

}
