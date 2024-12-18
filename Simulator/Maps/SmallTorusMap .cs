using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        FNext = MoveRules.SmallTorusNext;
        FNextDiagonal = MoveRules.SmallTorusNextDiagonal;
    }

    //public override Point Next(Point p, Direction d)
    //{
    //    var moved = p.Next(d);
    //    return new Point((moved.X + SizeX) % SizeX, (moved.Y + SizeY) % SizeY);
    //}

    //public override Point NextDiagonal(Point p, Direction d)
    //{
    //    var moved = p.NextDiagonal(d);
    //    return new Point((moved.X + SizeX) % SizeX, (moved.Y + SizeY) % SizeY);
    //}
}
