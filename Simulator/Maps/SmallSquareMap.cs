using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private readonly Rectangle _bounds;
    public int Size { get; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Wrong size! Element must be withing range [5; 20]");
        Size = size;
        _bounds = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point p) => _bounds.Contains(p);

    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        if (!Exist(moved)) return p;
        return moved;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        if (!Exist(moved)) return p;
        return moved;
    }
}
