﻿using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    private Direction _currentDirection;
    public override char Symbol => CanFly ? 'B' : 'b';
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get => $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>";
    }

    //protected override Point GetNewPosition(Direction direction)
    //{
    //    //Console.WriteLine(direction);
    //    _currentDirection = direction;
    //    return CanFly
    //        ? Map.Next(Map.Next(Position, direction), _currentDirection)
    //        : Map.NextDiagonal(Position, direction);
    //}


    // Powyzej zakomentowana jest pierwotna postac funkcji, dla ktorej ptaki potrafiące latać na mapie typu BigBounceMap będąc przy krawedzi zostają w miejscu.
    // Stwierdzilam, ze zmienie to tak, aby znajdujac sie przy krawedzi mapy poruszaly sie dwa razy w odwrotnym kierunku. 
    protected override Point GetNewPosition(Direction direction)
    {
        _currentDirection = direction;
        var moved = Position.Next(direction);
        var newPosition = Map.Next(Position, direction);
        if (CanFly)
        {
            if (!Map.Exist(moved) && (Map.GetType() == typeof(BigBounceMap))) _currentDirection = DirectionParser.Reverse(_currentDirection);
            return Map.Next(newPosition, _currentDirection);
        }
        return Map.NextDiagonal(Position, direction);

    }
}
