using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    private string _name = "Unknown";
    private int _level = 1;


    public string Name 
    { 
        get => _name; 
        init
        {
            value = value.Trim();
                
            if (value.Length > 25) value = value[..25].Trim();

            if (value.Length < 3) value = value.PadRight(3, '#');

            if (char.IsLower(value[0])) value = char.ToUpper(value[0]) + value[1..];

            _name = value;
        } 
    }
    public int Level 
    { 
        get => _level; 
        init
        {
            _level = value < 1 ? 1 : value > 10 ? 10 : value;
        }
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public string Info => $"{Name} [{Level}]";

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

}
