﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Rectangle _bounds;
    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow.");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short.");

        SizeX = sizeX;
        SizeY = sizeY;
        _bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public abstract void Add(IMappable mappable, Point position);
    public abstract void Remove(IMappable mappable, Point position);
    public void Move(IMappable mappable, Point posFrom, Point posTo)
    {
        //if (!Exist(posFrom) || !Exist(posTo)) throw new ArgumentException("Oops! One of the positions is out of map!");
        Remove(mappable, posFrom);
        Add(mappable, posTo);
        //Remove(mappable, posFrom);
    }

    public abstract List<IMappable>? At(int x, int y);
    public abstract List<IMappable>? At(Point position);


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _bounds.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
