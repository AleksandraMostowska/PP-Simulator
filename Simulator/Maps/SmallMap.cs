﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{


    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");
        if (sizeY > 20) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high.");
        //_fields = new List<IMappable>?[sizeX, sizeY];
    }


}
