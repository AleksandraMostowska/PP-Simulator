using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int singCtr = 0;
    public override char Symbol => 'E';

    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }

    public override int Power => 8 * Level + 2 * agility;

    public override string Info => $"{Name} [{Level}][{Agility}]";

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public void Sing()
    {
        singCtr++;

        if (singCtr % 3 == 0 && agility < 10) agility++;
    }

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
}
