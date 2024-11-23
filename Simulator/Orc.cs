using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int huntCtr = 0;

    public int Rage 
    { 
        get => rage; 
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public override int Power => 7 * Level + 3 * rage;

    public override string Info => $"ORC: {Name} [{Level}][{Rage}]";

    public void Hunt()
    {

        huntCtr++;

        if (huntCtr % 2 == 0 && rage < 10) rage++;

    }

    public Orc() : base() { }


    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
}
